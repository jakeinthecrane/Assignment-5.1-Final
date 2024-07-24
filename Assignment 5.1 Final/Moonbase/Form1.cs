using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Moonbase
{      //here we declare the MoonbaseAssignment1 that inherits from Form
    public partial class MoonbaseAssignment1 : Form

    //We declare private fields for tracking user position, storing locations, and keeping track of the current form. 
    {
        private readonly UserPositionTracker _positionTracker;
        private readonly Location[] locations;
        private Form currentForm;

        // Constructor for our MoonbaseAssignment1 class
        public MoonbaseAssignment1()
        {
            InitializeComponent(); //initializes the UI components, sets properties as well as visual elements. 
            _positionTracker = new UserPositionTracker(); //creates a new instane of the UPTclass and assigns it to the _PTF
            this.MouseMove += new MouseEventHandler(Form_MouseMove); //calls the mouseEH and tracks the mouse updating UI elements.
            locations = InitializeLocations(); //method that assigns its return value to the locations field.
            currentForm = this; //keeps track of the currently active form within the application. CF field.
            this.Load += new EventHandler(MoonbaseAssignment1_Load); //hooks up the load event. 
        }

        // MouseMove event handler. It is called whenever the mouse is moved within the form. 
        private void Form_MouseMove(object sender, MouseEventArgs e)
        {   //this takes the current mouse position and updates the UserPosition property of the _PT object.
            _positionTracker.UserPosition = e.Location;
        }

        // Locations method that initializes and returns an array of 'Location' objects
        private Location[] InitializeLocations()
        {
            return new Location[]
            {
                new Location("Check in Lounge", "North", "Welcome to the North Side of the Moon"),
                new Location("Sauna Time", "West", "Welcome to the West Side of the Moon"),
                new Location("Salt Time", "East", "Welcome to the East Side of the Moon"),
                new Location("Weightless Zone", "South", "Welcome to the South Side of the Moon")

            };
        }

        // Method that displays information about a location given its index
        private void DisplayLocationInfo(int index)
        {
            if (index >= 0 && index < locations.Length) //verifies that the index is within the given test range of the array
            {
                Location location = locations[index]; //retrieves the location object at the specified index
                //this method will show the message when called with this interpolated string.  
                MessageBox.Show($"Name: {location.LocationName}\nDescription: {location.LocationDescription}\nBackground: {location.ScenicView}");
            }
        }

        // Button event handler for a discount code
        private void Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Use the code MOONDANCE for 20% off treatment");
        }

        // Button event handlers for navigation
        private void Button2_Click(object sender, EventArgs e)
        {
            ShowForm<Form2>(0);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ShowForm<Form3>(1);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ShowForm<Form4>(2);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            ShowForm<Form5>(3);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ShowForm<Form6>(4);

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            ShowForm<Form7>(5);

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            ShowForm<Form8>(6);

        }

        // Show form method without opening a new window
        public void ShowForm<T>(int locationIndex) where T : Form, new()
        {
            try//try catch exception block.
            {
                // Close and dispose of the current form if it is not the main form.  Only the main form will remain in the background. 
                if (currentForm != this)
                {
                    currentForm.Close();
                    currentForm.Dispose();
                }

                // Create a new instance of the form
                currentForm = Activator.CreateInstance(typeof(T), this) as Form;

                // Subscribe to the form closed event
                currentForm.FormClosed += (s, args) => this.Show();

                // Show the new form
                currentForm.Show();

                // Display location info
                DisplayLocationInfo(locationIndex);
            }
            catch (Exception ex) //this is the catch block that will perform if any exception occurs during the execution 
                                 //of the try block.. the message below will display
            {
                MessageBox.Show("An error occurred while trying to show the form: " + ex.Message);
            }
        }

        // Loop created to log a users position at 1 second intervals for a 10 second duration.  Something simple..
        private void LogUserPositions()
        {
            for (int i = 0; i < 10; i++) //for Loop runs 10 times 
            {
                Point position = _positionTracker.UserPosition; //retrieves the users current position.
                _positionTracker.LogPosition(position); //logs the position
                System.Threading.Thread.Sleep(1000); // pauses the loop for 1 second before the next iteration...
            }
        }

        private void MoonbaseAssignment1_Load(object sender, EventArgs e)
        {

        }

       
    }
    
    }

    // Class to track and log the user's position
    public class UserPositionTracker
    {
        private Point _userPosition; //this private field stores the users position using x and y coordinates due to 'Point'.

        public Point UserPosition //this public property provides access to the _userPosition field.  
        {
            get { return _userPosition; }//'get' accessor returns the current value of the _userPosition field.
            set
            {
                if (_userPosition != value) //verifies that the value is different from the current value.  If so, it proceeds.
                {
                    _userPosition = value; //updates the _userPosition field with the new value . 
                    LogPosition(_userPosition); //this method call logs the ne position 
                }
            }
        }

        public void LogPosition(Point position)//public method 
        {
            try //try block to catch any IOException.
            {
                string logPath = "User_position_log.txt";//log path to where the file of the positions are stored. 
                string logEntry = $"X: {position.X}, Y: {position.Y}, Time: {DateTime.Now}";//log entry consisting of x, y coorinates along with date and time.
                File.AppendAllText(logPath, logEntry + Environment.NewLine);//append method for logpath to logentry to have a new line format.
            }
            catch (IOException ex) //catch exception with an error message below.  
            {
                MessageBox.Show("An error occurred while trying to log the position: " + ex.Message);
            }
        }
    }

    // Location class designed to encapsulate all the relevant information about a location in the Moonbase application
    public class Location
    {
        public string ScenicView { get; set; } //property to store the scenic view of the location
        public string LocationName { get; set; } //property to store the name of the location
        public string LocationDescription { get; set; } //property to store the description of the location. 

           //Constructor to initialize a location object with specific values
        public Location(string scenicView, string locationName, string locationDescription)
        {
            ScenicView = scenicView; //initializes the scenicview, locationname, and locationdescription.
            LocationName = locationName; 
            LocationDescription = locationDescription; 
        }
    }

