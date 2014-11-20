using System;
using System.Linq;
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
                View.TextBoxName.Text = reservee.FirstName;
                View.TextBoxInsertion.Text = reservee.Insertion;
                View.TextBoxLastName.Text = reservee.LastName;
                View.TextBoxStreet.Text = reservee.Street;
                View.TextBoxCity.Text = reservee.City;
                View.TextBoxPostalCode.Text = reservee.PostalCode;
                View.TextBoxHouseNumber.Text = reservee.HouseNumber;
                View.TextBoxMail.Text = reservee.EmailAddress;
            }
            else
                View.InvokeAll<NamedClearableTextBox>(t => t.Clear());

            View.TextBoxName.FocusSelectAll();
        }

        private void ViewOnButtonCancelClick(object sender, EventArgs eventArgs)
        {
            MainForm.Open<ControllerReservees>();
        }

        private void ViewOnButtonSaveClick(object sender, EventArgs eventArgs)
        {
            bool insertNew = reservee == null;
            if (reservee == null)
                reservee = new Reservee();

            // Set fields
            reservee.FirstName = View.TextBoxName.Text;
            reservee.Insertion = View.TextBoxInsertion.Text;
            reservee.LastName = View.TextBoxLastName.Text;
            reservee.HouseNumber = View.TextBoxHouseNumber.Text;
            reservee.Street = View.TextBoxStreet.Text;
            reservee.City = View.TextBoxCity.Text;
            reservee.PostalCode = View.TextBoxPostalCode.Text;
            reservee.EmailAddress = View.TextBoxMail.Text;

            if (insertNew)
                reservee.Insert();
            else
                reservee.Update();

            MainForm.Open<ControllerReservees>();
        }
    }
}