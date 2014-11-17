using System;
using System.Collections.Generic;
using System.Linq;
using ReservationSystem.Views;
using SharedClasses.Data.Models;
using SharedClasses.Extensions;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    internal class ControllerReservationDetail : ControllerMVC<ViewReservationDetail>
    {
        public Reservation Reservation { get; set; }

        public ControllerReservationDetail()
        {
            View.ButtonAddEvent += ViewOnButtonAddEvent;
            View.ButtonSaveReservationClick += ViewOnButtonSaveReservationClick;
            View.ButtonCancelClick += ViewOnButtonCancelClick;
        }

        public override void Activate()
        {
            Reservation = Values.SafeGetValue<Reservation>("Reservation");

            if (Reservation == null)
            {
                View.TextBoxReservee.ReadOnly = false;
                View.TextBoxEvent.ReadOnly = false;
                View.NumericUpDownVisitorAmount.ReadOnly = false;
                
                View.TextBoxReservee.Clear();
                View.TextBoxEvent.Clear();
            }
            else
            {
                View.TextBoxReservee.ReadOnly = true;
                View.TextBoxEvent.ReadOnly = true;
                View.NumericUpDownVisitorAmount.ReadOnly = true;

                // Fill TextBoxReservee.
                var reservee = Reservee.Select("RESERVEEID = " + Reservation.ReserveeId.ToSqlFormat()).FirstOrDefault();
                if (reservee != null)
                {
                    View.TextBoxReservee.Text = reservee.FullName;
                }

                // Fill TextBoxEvent.
                var dbEvent = Event.Select("EVENTID = " + Reservation.EventId.ToSqlFormat()).FirstOrDefault();
                if (dbEvent != null)
                {
                    View.TextBoxEvent.Text = dbEvent.Name;
                }

                // Fill NumericUpDownValue.
                View.NumericUpDownVisitorAmount.Value = Reservation.AmountOfPeople;

                // Fill products.
                var rentals = Rental.Select("VISITORCODE = " + reservee.ToSqlFormat());
            }
        }

        private void ViewOnButtonAddEvent(object sender, EventArgs eventArgs)
        {

        }

        private void ViewOnButtonSaveReservationClick(object sender, EventArgs eventArgs)
        {
            // Generate random RFIDs.
            var r = new Random();
            List<string> randomRFIDs =
                Enumerable.Repeat("", (int)View.NumericUpDownVisitorAmount.Value)
                    .Select(
                        s =>
                            Enumerable.Repeat("", 8)
                                .Select(s2 => r.Next(16).ToString("X"))
                                .Aggregate((s1, s2) => s1 + s2))
                    .ToList();

            // Popup window which shows input fields based on the amount of RFIDs required.
            MainForm.PopupControllerOptions<ControllerAddVisitorsToReservation>(true, new KeyValuePair<string, object>("Visitors",
                randomRFIDs), new KeyValuePair<string, object>("Reservation", Reservation));
        }

        private void ViewOnButtonCancelClick(object sender, EventArgs eventArgs)
        {
            MainForm.Open<ControllerReservation>();
        }
    }
}