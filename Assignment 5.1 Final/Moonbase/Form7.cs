﻿using System;
using System.Windows.Forms;

namespace Moonbase
{
    public partial class Form7 : Form
    {
        private MoonbaseAssignment1 mainForm;

        public Form7()
        {
            InitializeComponent();
            SetFormProperties();
        }

        public Form7(MoonbaseAssignment1 mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            SetFormProperties();
            InitializeButtonHandlers();
        }

        private void SetFormProperties()
        {
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InitializeButtonHandlers()
        {
            button1.Click += (sender, e) => OpenForm<Form2>(0);
            button2.Click += (sender, e) => OpenForm<Form3>(1);
            button3.Click += (sender, e) => OpenForm<Form4>(2);
            button4.Click += (sender, e) => OpenForm<Form5>(3);
            button5.Click += (sender, e) => OpenForm<Form6>(4);
            button6.Click += (sender, e) => ShowCurrentLocation();
            button7.Click += (sender, e) => OpenForm<Form8>(6);
        }

        private void ShowCurrentLocation()
        {
            MessageBox.Show("You are currently in the North West section of the Moonbase.", "North West", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OpenForm<T>(int locationIndex) where T : Form, new()
        {
            mainForm.ShowForm<T>(locationIndex);
        }

        private void Form7_Load(object sender, EventArgs e) { }
    }
}
