﻿using System;
using System.Windows.Forms;

namespace SharedClasses.Controls.WinForms
{
    public partial class VisitorInfoPanel : UserControl
    {
        public VisitorInfoPanel()
        {
            InitializeComponent();
        }

        public string FirstName
        {
            get { return TextBoxFirstName.Text; }
            set { TextBoxFirstName.Text = value; }
        }

        public string Insertion
        {
            get { return TextBoxInsertion.Text; }
            set { TextBoxInsertion.Text = value; }
        }

        public string LastName
        {
            get { return TextBoxLastName.Text; }
            set { TextBoxLastName.Text = value; }
        }

        public DateTime BirthDate
        {
            get { return DateTimeBirthDate.Value; }
            set { DateTimeBirthDate.Value = value; }
        }

        public string PhoneNumber
        {
            get { return TextBoxPhoneNumber.Text; }
            set { TextBoxPhoneNumber.Text = value; }
        }

        public string Title
        {
            get { return groupBox.Text; }
            set { groupBox.Text = value; }
        }
    }
}