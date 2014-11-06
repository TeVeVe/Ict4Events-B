using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccessControlSystem.Views;
using SharedClasses.Controls.WinForms;
using SharedClasses.MVC;

namespace AccessControlSystem.Controllers
{
    public class ControllerLocationDetails : ControllerMVC<ViewLocationDetails>
    {
        public override void Activate()
        {
            Task.Factory.StartNew(() =>
            {
                Task.Delay(5000).Wait();
                MainForm.Open<ControllerScanRFID>();
            });
        }
    }
}