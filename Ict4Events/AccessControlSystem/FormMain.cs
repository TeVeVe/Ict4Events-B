using AccessControlSystem.Controllers;
using SharedClasses.Interfaces;
using SharedClasses.MVC;

namespace AccessControlSystem
{
    public partial class FormMain : FormMVC
    {
        public FormMain()
        {
            InitializeComponent();

            // Add menu items, and set active:
            AddMenuItem("Show RFID", new ControllerScanRFID());
            AddMenuItem("Show location", new ControllerLocationDetails("Test"));

            MarkAsMain<ControllerScanRFID>();
        }
    }
}