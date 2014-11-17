using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharedClasses.Controls.WinForms
{
    public partial class VisitorInfoPanel : UserControl
    {
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
            get { return TextBoxPhoneNumber.ToString();  }
            set { TextBoxPhoneNumber.Text = value; }
        }

        public string Title
        {
            get { return groupBox.Text; }
            set { groupBox.Text = value; }
        }

        public VisitorInfoPanel()
        {
            InitializeComponent();
        }
    }
}
