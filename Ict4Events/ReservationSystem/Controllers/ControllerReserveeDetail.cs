﻿using System;
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
        private string emailTo;
        private string name;

        public override void Create()
        {
            View.ButtonCancelClick += ViewOnButtonCancelClick;
            View.ButtonSaveClick += ViewOnButtonSaveClick;

            if (Values.ContainsKey("USERACCOUNT"))
            {
                // Fill fields with UserAccount properties.
                var account = (UserAccount) Values["USERACCOUNT"];
                View.TextBoxName.Text = account.Username;
            }
        }

        private void ViewOnButtonCancelClick(object sender, EventArgs eventArgs)
        {
            MainForm.ActiveMenuItemText = "Bezoekers";
        }

        private void ViewOnButtonSaveClick(object sender, EventArgs eventArgs)
        {
            MainForm.ActiveMenuItemText = "Bezoekers";
            // TODO:  Validation of data
            // TODO: Insert data in database

            emailTo = View.TextBoxEmail.Text;
            name = View.TextBoxName.Text;
            SendReservationConfirmationEmail(emailTo);
        }

        public void SendReservationConfirmationEmail(string email)
        {
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
                    "Veel plezier op het event!", name);

            using (var mail = new MailMessage())
            {
                
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(emailTo);
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
                    MessageBox.Show("Bevestigingsmail succesvol verstuurd!");
            }
        }
    }
}