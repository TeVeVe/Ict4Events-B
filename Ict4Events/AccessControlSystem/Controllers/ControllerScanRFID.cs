using System.Collections.Generic;
using System.Linq;
using System.Windows;
using AccessControlSystem.Views;
using SharedClasses.Data.Models;
using SharedClasses.Detectors;
using SharedClasses.Extensions;
using SharedClasses.MVC;

namespace AccessControlSystem.Controllers
{
    public class ControllerScanRFID : ControllerMVC<ViewScanRFID>
    {
        private RadioFrequency rfid;

        public ControllerScanRFID()
        {
            rfid = new RadioFrequency();

            // Retrieve payment status of scanned wristband.
            rfid.Tag += (sender, args) =>
            {
                IEnumerable<Wristband> wristbands = Wristband.Select("VISITORCODE = " + args.Value.ToSqlFormat());

                // If wristband doesn't occur in database.
                if (!wristbands.Any())
                {
                    // Show unknown wristband message.
                    FormMain.Form.Open<ControllerUnknownWristband>();
                }
                else
                {
                    // wristband does exist in database.
                    IEnumerable<Reservation> reservation =
                        Reservation.Select("RESERVATIONID = " + wristbands.First().ReservationId);

                    if (reservation.First().PaymentStatus)
                    {
                        // if payment status is OK
                        FormMain.Form.Open<ControllerLocationDetails>();
                        Wristband wristband = wristbands.First();

                        if (!wristband.IsOnSite)
                        {
                            // User is not yet on site but checkin is successful: access granted, update database to set guest as present (on site).
                            wristband.IsOnSite = true;
                            wristband.Update();
                        }
                        else
                        {
                            // User was already on site but checked out: update database to set guest as away (not on site).
                            wristband.IsOnSite = !wristband.IsOnSite;
                            wristband.Update();
                        }
                    }
                    // Access denied due to negative payment status.
                    else
                        FormMain.Form.Open<ControllerAccessDenied>();
                }
            };
        }
    }
}