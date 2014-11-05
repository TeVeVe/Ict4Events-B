using System.Collections.Generic;
using System.Linq;
using AccessControlSystem.Views;
using SharedClasses.Data.Models;
using SharedClasses.Detectors;
using SharedClasses.Extensions;
using SharedClasses.MVC;

namespace AccessControlSystem.Controllers
{
    public class ControllerScanRFID : ControllerMVC<ViewScanRFID>
    {
        public override void Create()
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
                IEnumerable<Wristband> wristbands = Wristband.Select("VISITORCODE = " + args.Value.ToSqlFormat());
                if (wristbands.Count() == 0)
                {
                    //MessageBox.Show("Niet herkend.");
                    FormMain.Form.Open<ControllerUnknownWristband>();
                }
                else
                {
                    IEnumerable<Reservation> reservation =
                        Reservation.Select("RESERVATIONID = " + wristbands.First().ReservationId);
                    if (reservation.First().PaymentStatus)
                    {
                        Wristband wristband = wristbands.First();
                        wristband.IsOnSite = !wristband.IsOnSite;
                        wristband.Update();

                        if (wristband.IsOnSite)
                            FormMain.Form.Open<ControllerLocationDetails>();
                        else
                            FormMain.Form.Open<ControllerVisitorExit>();
                    }
                    else
                        FormMain.Form.Open<ControllerAccessDenied>();
                }
            };
        }
    }
}