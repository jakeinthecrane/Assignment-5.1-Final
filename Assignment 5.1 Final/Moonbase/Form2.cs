using System;
using System.Windows.Forms;

namespace Moonbase
{
    public partial class Form2 : Form //declares the 'form2' class, which inherits from the 'from' class,
    {
        private MoonbaseAssignment1 mainForm; //mainForm reference 

        public Form2() //constructor for form2 class
        {
            InitializeComponent();//handles the initialization of all visual components and controls on the form. 
            SetFormProperties(); // custom method used to set up additional properties and perform custom initialization tasks specific to form2.
        }

        public Form2(MoonbaseAssignment1 mainForm) //defines a constructor that takes MoonbaseAssignment1 object as a parameter.
        {
            InitializeComponent(); //initializes the forms components
            this.mainForm = mainForm; //assigns the passed 'mainForm' parameter to the class's private 'mainForm' variable
            SetFormProperties(); //sets the form properties like size and start position
            InitializeButtonHandlers();//initializes the button eventhandlers 
        }

        private void SetFormProperties()//this method isused to set up the forms when called
        {
            this.Size = new System.Drawing.Size(800, 600); //this statement sets up the size of the form
            this.StartPosition = FormStartPosition.CenterScreen; //this statement places the screen in the center
            //these dimensions were selected becuase they are default to fit most screens.  
        }

        private void InitializeButtonHandlers()//all button event handlers in one method for better organization.
        {
            button1.Click += (sender, e) => ShowCurrentLocation(); //attaches an event handler using a lambda expression.  
            button2.Click += (sender, e) => OpenForm<Form3>(1);//these other buttons will open a form and pass an index to the 'OpenForm' method. In this case index 1. 
            button3.Click += (sender, e) => OpenForm<Form4>(2);
            button4.Click += (sender, e) => OpenForm<Form5>(3);
            button5.Click += (sender, e) => OpenForm<Form6>(4);
            button6.Click += (sender, e) => OpenForm<Form7>(5);
            button7.Click += (sender, e) => OpenForm<Form8>(6);
        }

        private void ShowCurrentLocation() //private method to show current location message.
        {
            MessageBox.Show("You are currently here on the North Side of the Moon. Relax, make yourself at home.", "North", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //This method delegates the task of opening a new form to the 'mainForm' instance.  So there isn't a duplication of forms...
        private void OpenForm<T>(int locationIndex) where T : Form, new()
        {
            mainForm.ShowForm<T>(locationIndex);//calls the ShowForm method on the mainForm instance passing the locationIndex and the generic tyoe 'T'.
        }

        private void Form2_Load(object sender, EventArgs e) { }
    }

}
//ALL FORMS FROM HERE OUT REPEAT.  ONLY FORM 1 REMAINS ON 