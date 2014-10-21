using System;
using System.Windows.Forms;
using AccessControlSystem.Views;
using SharedClasses.Extensions;
using SharedClasses.Views;

namespace AccessControlSystem
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            // Display first screen
            panelMainView.ShowInView(new UCAccessControlSystemRFID());
        }
    }
}
