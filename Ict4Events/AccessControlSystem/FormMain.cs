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
            Form = this;

            MarkAsMain<ControllerScanRFID>();
        }
    }
}