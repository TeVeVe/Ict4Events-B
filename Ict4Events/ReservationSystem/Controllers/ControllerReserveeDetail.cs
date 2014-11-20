using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using ReservationSystem.Views;
using SharedClasses.Controls.WinForms;
using SharedClasses.Data.Models;
using SharedClasses.Extensions;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    internal class ControllerReserveeDetail : ControllerMVC<ViewReserveeDetail>
    {
        private Reservee reservee;

        public ControllerReserveeDetail()
        {
            View.ButtonCancelClick += ViewOnButtonCancelClick;
            View.ButtonSaveClick += ViewOnButtonSaveClick;
        }

        public override void Activate()
        {
            reservee = Values.SafeGetValue<Reservee>("RESERVEE");
            if (reservee != null)
            {
                // Fill fields with UserAccount properties.
                var visitor = Visitor.Select("VISITORCODE = " + reservee.VisitorCode.ToSqlFormat()).FirstOrDefault();
                if (visitor != null)
                {
                    View.TextBoxName.Text = visitor.FirstName;
                    View.TextBoxInsertion.Text = visitor.Insertion;
                    View.TextBoxLastName.Text = visitor.LastName;
                }
                
                View.TextBoxStreet.Text = reservee.Street;
                View.TextBoxCity.Text = reservee.City;
                View.TextBoxPostalCode.Text = reservee.PostalCode;
                View.TextBoxHouseNumber.Text = reservee.HouseNumber;
                View.TextBoxPhone.Text = reservee.Phone;
                View.TextBoxMail.Text = reservee.EmailAddress;
            }
            else
            {
                View.InvokeAll<NamedClearableTextBox>(t => t.Clear());
            }

            View.TextBoxName.FocusSelectAll();
        }

        private void ViewOnButtonCancelClick(object sender, EventArgs eventArgs)
        {
            MainForm.Open<ControllerReservees>();
        }

        private void ViewOnButtonSaveClick(object sender, EventArgs eventArgs)
        {
            bool insertNew = reservee == null;
            if (reservee == null) reservee = new Reservee();

            // Set fields.
            Visitor visitor = null;
            if (insertNew)
                visitor = new Visitor();
            else
                visitor = Visitor.Select("VISITORCODE = " + reservee.VisitorCode.ToSqlFormat()).FirstOrDefault();

            visitor.FirstName = View.TextBoxName.Text;
            visitor.Insertion = View.TextBoxInsertion.Text;
            visitor.LastName = View.TextBoxLastName.Text;
            reservee.Street = View.TextBoxStreet.Text;
            reservee.City = View.TextBoxCity.Text;
            reservee.PostalCode = View.TextBoxPostalCode.Text;
            reservee.Phone = View.TextBoxPhone.Text;
            reservee.EmailAddress = View.TextBoxMail.Text;

            if (insertNew)
            {
                visitor.Insert();
                reservee.Insert();
            }
            else
            {
                visitor.Update();
                reservee.Update();
            }

            MainForm.Open<ControllerReservees>();
            SendReservationConfirmationEmail(View.TextBoxMail.Text);
        }

        public void SendReservationConfirmationEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(reservee.EmailAddress))
                return;

            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587;
            bool enableSSL = true;

            string emailFrom = "reservationict4events@gmail.com";
            string password = "Administrator01";

            string subject = string.Format("Ict4Events: Uw reservering is succesvol verwerkt!");
            var visitor = Visitor.Select("VISITORCODE = " + reservee.VisitorCode.ToSqlFormat()).FirstOrDefault();
            string body =
                string.Format(
                    "Geachte {0}, <br><br>bij deze is uw reservering succesvol verwerkt in ons systeem! <br>Uw bestelde polsbandjes zullen zo snel mogelijk naar u verstuurd worden. <br>" +
                    "Op de dag van het evenement kunt u dit polsbandje gebruiken om toegang te krijgen tot het evenemententerein. <br>" +
                    "U kunt het te betalen bedrag overmaken naar het volgende rekeningnummer: <b>123456</b>.<br><br>" +
                    "Veel plezier op het event!",
                    visitor.FirstName +
                    (!string.IsNullOrWhiteSpace(visitor.Insertion) ? " " + visitor.Insertion + " " : "") +
                    visitor.LastName);

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
    }
}