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
                    View.TextBoxPhone.Text = visitor.Phone;
                }
                
                View.TextBoxStreet.Text = reservee.Street;
                View.TextBoxCity.Text = reservee.City;
                View.TextBoxPostalCode.Text = reservee.PostalCode;
                View.TextBoxHouseNumber.Text = reservee.HouseNumber;
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
            //Visitor visitor = null;
            //if (insertNew)
            //    visitor = new Visitor();
            //else
            //    visitor = Visitor.Select("VISITORCODE = " + reservee.VisitorCode.ToSqlFormat()).FirstOrDefault();

            //visitor.FirstName = View.TextBoxName.Text;
            //visitor.Insertion = View.TextBoxInsertion.Text;
            //visitor.LastName = View.TextBoxLastName.Text;
            //visitor.Phone = View.TextBoxPhone.Text;
            reservee.HouseNumber = View.TextBoxHouseNumber.Text;
            reservee.Street = View.TextBoxStreet.Text;
            reservee.City = View.TextBoxCity.Text;
            reservee.PostalCode = View.TextBoxPostalCode.Text;
            reservee.EmailAddress = View.TextBoxMail.Text;

            if (insertNew)
            {
                //visitor.Insert();
                reservee.Insert();
            }
            else
            {
                //visitor.Update();
                reservee.Update();
            }

            MainForm.Open<ControllerReservees>();
        }
    }
}