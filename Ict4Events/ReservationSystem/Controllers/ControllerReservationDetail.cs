using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ReservationSystem.Views;
using SharedClasses.Controller;
using SharedClasses.Controls.WinForms;
using SharedClasses.Data.Models;
using SharedClasses.Extensions;
using SharedClasses.MVC;
using IOFile = System.IO.File;

namespace ReservationSystem.Controllers
{
    internal class ControllerReservationDetail : ControllerMVC<ViewReservationDetail>
    {
        public ControllerReservationDetail()
        {
            View.AddEventClick += ViewOnAddEventClick;
            View.AddVisitorClick += ViewOnAddReserveeClick;

            View.SaveReservationClick += ViewOnSaveReservationClick;
            View.CancelClick += ViewOnCancelClick;
            View.InteractiveMap.SpotClick += InteractiveMapOnSpotClick;
        }

        public bool IsNewRecord { get; set; }

        public Reservation Reservation { get; set; }

        private void InteractiveMapOnSpotClick(object sender, InteractiveMap.SpotClickEventArgs e)
        {
            e.Spot.Checked = !e.Spot.Checked;
        }

        public override void Activate()
        {
            Reservation = Values.SafeGetValue<Reservation>("Reservation");

            if (Reservation == null)
            {
                IsNewRecord = true;
                View.NumericUpDownVisitorAmount.Increment = 1;
                View.NumericUpDownVisitorAmount.Value = View.NumericUpDownVisitorAmount.Minimum;
                View.ButtonAddEvent.Enabled = true;
                View.ButtonAddReservee.Enabled = true;
                View.ButtonAddProduct.Enabled = true;
                View.ButtonDeleteProduct.Enabled = true;
                View.InteractiveMap.Clear();

                View.TextBoxReservee.Clear();
                View.TextBoxEvent.Clear();
            }
            else
            {
                IsNewRecord = false;

                // Reset everything.
                View.NumericUpDownVisitorAmount.Increment = 0;
                View.ButtonAddEvent.Enabled = false;
                View.ButtonAddReservee.Enabled = false;
                View.ButtonAddProduct.Enabled = false;
                View.ButtonDeleteProduct.Enabled = false;
                View.InteractiveMap.Clear();

                // Fill TextBoxReservee.
                Reservee reservee =
                    Reservee.Select("RESERVEEID = " + Reservation.ReserveeId.ToSqlFormat()).FirstOrDefault();
                if (reservee != null)
                    View.TextBoxReservee.Text = reservee.FullName;

                // Fill TextBoxEvent.
                Event dbEvent = Event.Select("EVENTID = " + Reservation.EventId.ToSqlFormat()).FirstOrDefault();
                if (dbEvent != null)
                    View.TextBoxEvent.Text = dbEvent.Name;

                // Fill NumericUpDownValue.
                View.NumericUpDownVisitorAmount.Value = Reservation.AmountOfPeople;

                // Fill interactive map.
                if (dbEvent != null)
                    UpdateMap(dbEvent.Id);

                // Fill products.
                IEnumerable<Rental> rentals = Rental.Select("VISITORCODE = " + reservee.VisitorCode.ToSqlFormat());
                View.DataGridViewProducts.DataSource = rentals.ToList();
            }
        }

        private void ViewOnAddReserveeClick(object sender, EventArgs e)
        {
            // Open lookup to select a reservee.
            var lookup =
                MainForm.PopupController<LookupController<Reservee>>(new KeyValuePair<string, object>("Description",
                    "Selecteer een reserverder om een reservering aan toe te voegen."));

            // Store selected reservee in TextBox.
            Reservee dbReservee = lookup.SelectedRows.FirstOrDefault();
            if (dbReservee != null && lookup.DialogResult == DialogResult.OK)
            {
                View.TextBoxReservee.Tag = dbReservee;
                View.TextBoxReservee.Text = dbReservee.FullName;
            }
        }

        private void ViewOnAddEventClick(object sender, EventArgs eventArgs)
        {
            // Open lookup to select an event.
            var lookup =
                MainForm.PopupController<LookupController<Event>>(new KeyValuePair<string, object>("Description",
                    "Selecteer een evenement om een reservering aan toe te voegen."));

            Event dbEvent = lookup.SelectedRows.FirstOrDefault();
            if (dbEvent != null && lookup.DialogResult == DialogResult.OK)
            {
                View.TextBoxEvent.Tag = dbEvent;
                View.TextBoxEvent.Text = dbEvent.Name;

                UpdateMap(dbEvent.Id);
            }
        }

        private void ViewOnSaveReservationClick(object sender, EventArgs e)
        {
            if (IsNewRecord)
                Reservation = new Reservation();

            Reservation.EventId = ((Event)View.TextBoxEvent.Tag).Id;
            Reservation.ReserveeId = ((Reservee)View.TextBoxReservee.Tag).Id;
            Reservation.AmountOfPeople = (int)View.NumericUpDownVisitorAmount.Value;

            if (IsNewRecord)
                Reservation.Insert();
            else
                Reservation.Update();

            // Clear all reservations first.
            foreach (ReservationSpot spot in Reservation.ReservationSpots)
                spot.Delete();

            // Insert all spots into database.
            foreach (InteractiveMap.Spot spot in View.InteractiveMap.Spots)
            {
                var dbSpot = new ReservationSpot();
                dbSpot.SpotId = (int)spot.Tag;
                dbSpot.ReservationId = Reservation.Id;
                dbSpot.Insert();
            }

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
            MainForm.PopupControllerOptions<ControllerAddVisitorsToReservation>(true,
                new KeyValuePair<string, object>("Visitors",
                    randomRFIDs), new KeyValuePair<string, object>("Reservation", Reservation));
        }

        private void ViewOnCancelClick(object sender, EventArgs eventArgs)
        {
            MainForm.Open<ControllerReservation>();
        }

        private void UpdateMap(int eventId)
        {
            Event dbEvent = Event.Select("EVENTID = " + eventId.ToSqlFormat()).FirstOrDefault();
            if (dbEvent == null)
                return;

            // Update map image.
            string fileName = string.Format("location{0}.png", dbEvent.LocationId);
            if (!IOFile.Exists(fileName))
                return;

            View.InteractiveMap.ImageMap = Image.FromFile(fileName);

            // Load reservation spots.
            View.InteractiveMap.AddRange(dbEvent.Spots.Select(s => new InteractiveMap.Spot(s.LocX, s.LocY)
            {
                Tag = s.Id
            }));
        }
    }
}