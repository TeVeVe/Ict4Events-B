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
                FormMain.Form.Open<ControllerScanRFID>();
            });
        }
    }
}