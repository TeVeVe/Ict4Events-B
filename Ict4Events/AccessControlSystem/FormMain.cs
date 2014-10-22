using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using AccessControlSystem.Views;
using SharedClasses.Controls;
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
            panelMainView.ShowInView(new FullscreenMessagePanel());
        }
    }
}
