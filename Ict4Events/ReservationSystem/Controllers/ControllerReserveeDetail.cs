using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;
using ReservationSystem.Views;
using SharedClasses.Data.Models;
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

            if (Values.ContainsKey("RESERVEE"))
            {
                // Fill fields with UserAccount properties.
                reservee = (Reservee)Values["RESERVEE"];
                View.TextBoxName.Text = reservee.FirstName;
            }
        }

        public override void Activate()
        {
            
        }

        private void ViewOnButtonCancelClick(object sender, EventArgs eventArgs)
        {
            MainForm.Open<ControllerReservees>();
        }

        private void ViewOnButtonSaveClick(object sender, EventArgs eventArgs)
        {
            if (reservee == null)
                throw new NullReferenceException("Reservee was not send to the detail page.");

            reservee.FirstName = View.TextBoxName.Text;
            reservee.Insertion = View.TextBoxInsertion.Text;

            MainForm.Open<ControllerReservees>();
            //SendReservationConfirmationEmail(emailTo);
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
            string body =
                string.Format(
                    "Geachte {0}, <br><br>bij deze is uw reservering succesvol verwerkt in ons systeem! <br>Uw bestelde polsbandjes zullen zo snel mogelijk naar u verstuurd worden. <br>" +
                    "Op de dag van het evenement kunt u dit polsbandje gebruiken om toegang te krijgen tot het evenemententerein. <br>" +
                    "U kunt het te betalen bedrag overmaken naar het volgende rekeningnummer: <b>123456</b>.<br><br>" +
                    "Veel plezier op het event!",
                    reservee.FirstName +
                    (!string.IsNullOrWhiteSpace(reservee.Insertion) ? " " + reservee.Insertion + " " : "") +
                    reservee.LastName);

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