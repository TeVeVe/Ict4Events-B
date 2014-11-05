using AccessControlSystem.Controllers;
using SharedClasses.Data;
using SharedClasses.Data.Models;
using SharedClasses.Interfaces;
using SharedClasses.MVC;

namespace AccessControlSystem
{
    public partial class FormMain : FormMVC
    {
        public static FormMain Form;

        public FormMain()
        {
            InitializeComponent();

            // Add menu items, and set active:
            AddMenuItem("Show RFID", new ControllerScanRFID());
            AddMenuItem("Show location", new ControllerLocationDetails());

            MarkAsMain<ControllerScanRFID>();

            Form = this;
        }
    }
}