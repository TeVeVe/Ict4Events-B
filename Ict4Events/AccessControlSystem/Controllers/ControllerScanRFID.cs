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
        public override void Create()
        {
            var rfid = new RadioFrequency();

            // Retrieve payment status of scanned wristband
            rfid.Tag += (sender, args) =>
            {
                IEnumerable<Wristband> wristbands = Wristband.Select("VISITORCODE = " + args.Value.ToSqlFormat());

                // If wristband doesn't occur in database
                if (wristbands.Count() == 0)
                {
                    // Show unknown wristband message
                    FormMain.Form.Open<ControllerUnknownWristband>();
                }

                    // wristband does exist in database
                else
                {
                    IEnumerable<Reservation> reservation =
                        Reservation.Select("RESERVATIONID = " + wristbands.First().ReservationId);

                    // if payment status is OK
                    if (reservation.First().PaymentStatus)
                    {
                        FormMain.Form.Open<ControllerLocationDetails>();
                        Wristband wristband = wristbands.First();

                        // User is not yet on site but checkin is successful: access granted, update database to set guest as present (on site)
                        if (!wristband.IsOnSite)
                        {
                            wristband.IsOnSite = true;
                            wristband.Update();
                        }
                            // User was already on site but checked out: update database to set guest as away (not on site)
                        else
                        {
                            wristband.IsOnSite = !wristband.IsOnSite;
                            wristband.Update();
                        }
                    }
                        // Access denied due to negative payment status
                    else FormMain.Form.Open<ControllerAccessDenied>();
                }
            };
        }
    }
}