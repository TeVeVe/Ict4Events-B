using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
                View.DataGridViewProducts.DataSource = null;
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

        public void SendReservationConfirmationEmail(Reservee reservee)
        {
            if (string.IsNullOrWhiteSpace(reservee.EmailAddress))
                return;

            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;

            string emailFrom = "reservationict4events@gmail.com";
            string password = "Administrator01";

            string subject = string.Format("Ict4Events: Uw reservering is succesvol verwerkt!");
            Visitor visitor = Visitor.Select("VISITORCODE = " + reservee.VisitorCode.ToSqlFormat()).FirstOrDefault();
            IEnumerable<Visitor> visitors = Visitor.Select("RESERVATIONID = " + Reservation.Id);

            string defaultBody = string.Format(
                "Geachte {0}, <br><br>bij deze is uw reservering succesvol verwerkt in ons systeem! <br>Uw bestelde polsbandjes zullen zo snel mogelijk naar u verstuurd worden. <br>" +
                "Op de dag van het evenement kunt u dit polsbandje gebruiken om toegang te krijgen tot het evenemententerein. <br>" +
                "U kunt het te betalen bedrag overmaken naar het volgende rekeningnummer: <b>123456</b>.<br><br>" +
                "Geef de bandjes met de juiste code aan de juiste bezoeker.<br><br>",
                visitor.FirstName +
                (!string.IsNullOrWhiteSpace(visitor.Insertion) ? " " + visitor.Insertion + " " : "") +
                visitor.LastName);

            foreach (Visitor v in visitors)
                defaultBody += v.FullName + "  -  " + v.VisitorCode + "<br>";

            defaultBody += "<br>Veel plezier op het event!";

            string body = defaultBody;


            using (var mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(reservee.EmailAddress);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;


                using (var smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Timeout = 10000;
                    smtp.Send(mail);
                }
                MessageBox.Show("Bevestigingsmail verstuurd.");
            }
        }

        private void ViewOnAddReserveeClick(object sender, EventArgs e)
        {
            // Open lookup to select a reservee.
            var lookup =
                MainForm.PopupController<ControllerLookup<Reservee>>(new KeyValuePair<string, object>("Description",
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
                MainForm.PopupController<ControllerLookup<Event>>(new KeyValuePair<string, object>("Description",
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
            {
                Reservation.Insert();
                Reservation =
                    Reservation.Select("RESERVATIONID = (SELECT MAX(RESERVATIONID) FROM RESERVATION)").First();
            }
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
            var rfidPopup = MainForm.PopupControllerOptions<ControllerAddVisitorsToReservation>(true,
                new KeyValuePair<string, object>("Visitors",
                    randomRFIDs), new KeyValuePair<string, object>("Reservation", Reservation),
                new KeyValuePair<string, object>("Reservee", View.TextBoxReservee.Tag));
            if (rfidPopup.DialogResult == DialogResult.OK)
            {
                // Send the mail.
                SendReservationConfirmationEmail(((Reservee)View.TextBoxReservee.Tag));
            }
            else
                Reservation.Delete();
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