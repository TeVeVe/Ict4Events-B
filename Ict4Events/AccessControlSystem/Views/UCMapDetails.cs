using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedClasses.Extensions;
using SharedClasses;
using SharedClasses.Detectors;

namespace AccessControlSystem.Views
{
    public partial class UCMapDetails : UserControl
    {
        public string Description
        {
            get { return labelDescription.Text; }
            set { labelDescription.Text = value; }
        }

        public UCMapDetails()
        {
            InitializeComponent();
        }

        public void DisplayScreen(UserControl uc)
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            // Display first screen
            panelMainView.ShowInView(new ());
        }
    }
}
