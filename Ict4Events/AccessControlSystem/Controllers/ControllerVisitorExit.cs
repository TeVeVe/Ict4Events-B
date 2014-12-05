using System.Threading.Tasks;
using AccessControlSystem.Views;
using SharedClasses.MVC;

namespace AccessControlSystem.Controllers
{
    internal class ControllerVisitorExit : ControllerMVC<ViewVisitorExit>
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