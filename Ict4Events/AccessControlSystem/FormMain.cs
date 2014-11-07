using AccessControlSystem.Controllers;
using SharedClasses.Data;
using SharedClasses.Data.Models;
using SharedClasses.Interfaces;
using SharedClasses.MVC;

namespace AccessControlSystem
{
    public partial class FormMain : FormMVC
    {
        public FormMain()
        {
            InitializeComponent();

            MarkAsMain<ControllerScanRFID>();
        }
    }
}