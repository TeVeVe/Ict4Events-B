using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using AccessControlSystem.Controllers;
using SharedClasses.Controls;
using SharedClasses.Controls.MVC;
using SharedClasses.Extensions;
using SharedClasses.Interfaces;
using SharedClasses.Views;

namespace AccessControlSystem
{
    public partial class FormMain : FormMVC
    {
        public FormMain()
        {
            InitializeComponent();

            // Add menu items:
            AddMenuItem("Show location", new ControllerLocationDetails("Test"));

            // First action that this system needs to do:
            ActiveController = new ControllerScanRFID();
        }
    }
}
