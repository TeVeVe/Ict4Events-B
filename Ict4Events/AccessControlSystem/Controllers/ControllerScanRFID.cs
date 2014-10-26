using System.Windows.Forms;
using AccessControlSystem.Views;
using SharedClasses.Controls;
using SharedClasses.Interfaces;
using SharedClasses.MVC;

namespace AccessControlSystem.Controllers
{
    public class ControllerScanRFID : ControllerMVC<ViewScanRFID>
    {
        public void StartRFIDListener()
        {
            // TODO: Identify user with RFID tag.
            // 1. Wait for RFID reader event.
            // 2. Look up visitor by RFID.
            // 3. Check payments.
            // 4. If all good: Show map with location to go to.
            // 4. If all bad: Notify user what is wrong.
        }
    }
}