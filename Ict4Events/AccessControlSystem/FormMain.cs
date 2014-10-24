using AccessControlSystem.Controllers;
using SharedClasses.Controls.WinForms.MVC;

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