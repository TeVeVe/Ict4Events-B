using System;
using System.Windows.Forms;
using SharedClasses.Controls.WinForms;

namespace AccessControlSystem.Views
{
    public partial class ViewLocationDetails : UserControl
    {
        public ViewLocationDetails()
        {
            InitializeComponent();
        }

        public InteractiveMap InteractiveMap
        {
            get { return interactiveMap1; }
        }

        private void interactiveMap1_Click(object sender, EventArgs e)
        {
        }

        private void labelMessage_Click(object sender, EventArgs e)
        {

        }
    }
}