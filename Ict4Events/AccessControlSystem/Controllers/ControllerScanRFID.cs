using System.Linq;
using System.Windows.Forms;
using AccessControlSystem.Views;
using SharedClasses.Controls;
using SharedClasses.Data.Models;
using SharedClasses.Detectors;
using SharedClasses.Extensions;
using SharedClasses.Interfaces;
using SharedClasses.MVC;

namespace AccessControlSystem.Controllers
{
    public class ControllerScanRFID : ControllerMVC<ViewScanRFID>
    {
        public ControllerScanRFID()
        {
            StartRFIDListener();
        }

        public void StartRFIDListener()
        {
            // TODO: Identify user with RFID tag.
            // 1. Wait for RFID reader event.
            // 2. Look up visitor by RFID.
            // 3. Check payments.
            // 4. If all good: Show map with location to go to.
            // 4. If all bad: Notify user what is wrong.

            var rfid = new RadioFrequency();

            // Retrieve payment status of scanned wristband
            rfid.Tag += (sender, args) =>
            {
                var wristband = Wristband.Select("VISITORCODE = " + args.Value.ToSqlFormat());
                var reservation = Reservation.Select("RESERVATIONID = " + wristband.First().ReservationId);
                // MessageBox.Show(reservation.First().PaymentStatus.ToString());
                if (reservation.First().PaymentStatus)
                {
                    MessageBox.Show("Gebruiker " + args.Value + " heeft betaald.");
                }
                else
                {
                    MainForm.Open<ControllerLocationDetails>();
                }
                rfid.Dispose();
            };

        }
    }
}