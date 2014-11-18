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

            // Retrieve payment status of scanned Visitor.
            rfid.Tag += (sender, args) =>
            {
                IEnumerable<Visitor> wristbands = Visitor.Select("VISITORCODE = " + args.Value.ToSqlFormat());

                // If Visitor doesn't occur in database.
                if (!wristbands.Any())
                {
                    // Show unknown Visitor message.
                    FormMain.Form.Open<ControllerUnknownWristband>();
                }
                else
                {
                    // Visitor does exist in database.
                    IEnumerable<Reservation> reservation = Reservation.Select("RESERVATIONID = " + wristbands.First().ReservationId);

                    if (reservation.First().PaymentStatus)
                    {
                        // if payment status is OK
                        Visitor visitor = wristbands.First();

                        if (!visitor.IsOnSite)
                        {
                            // User is not yet on site but checkin is successful: access granted, update database to set guest as present (on site).
                            visitor.IsOnSite = true;
                            visitor.Update();
                            FormMain.Form.Open<ControllerLocationDetails>(new KeyValuePair<string, object>("visitor", wristbands.First()));
                        }
                        else
                        {
                            // User was already on site but checked out: update database to set guest as away (not on site).
                            visitor.IsOnSite = false;
                            visitor.Update();
                            FormMain.Form.Open<ControllerVisitorExit>();
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