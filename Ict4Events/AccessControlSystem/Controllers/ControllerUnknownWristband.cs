using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControlSystem.Views;
using SharedClasses.MVC;

namespace AccessControlSystem.Controllers
{
    public class ControllerUnknownWristband : ControllerMVC<ViewUnknownWristband>
    {
        public override void Activate()
        {
            Task.Factory.StartNew(() =>
            {
                Task.Delay(2000).Wait();
                MainForm.Open<ControllerScanRFID>();
            });
        }
    }
}
