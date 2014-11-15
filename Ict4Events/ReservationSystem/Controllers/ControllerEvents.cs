using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReservationSystem.Views;
using SharedClasses.Data.Models;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    class ControllerEvent : ControllerMVC<ViewEvents>
    {
        public ControllerEvent()
        {
            View.ButtonDeleteEvent += ViewOnButtonDeleteEvent;
            View.ButtonSave += ViewOnButtonSave;
        }

        private void ViewOnButtonSave(object sender, EventArgs eventArgs)
        {
            if (string.IsNullOrWhiteSpace(View.TextBoxEventName.Text))
            {
                MessageBox.Show("De naam van een event mag niet leeg zijn.", "Invoergegevens zijn onjuist", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Event e = new Event();
            e.Name = View.TextBoxEventName.Text;
            e.Street = View.TextBoxStreet.Text;
            e.HouseNumber = View.TextBoxHouseNumber.Text;
            e.City = View.TextBoxCity.Text;
            e.PostalCode = View.TextBoxPostalCode.Text;
            e.StartDate = View.DateTimePickerStartDate.Value;
            e.EndDate = View.DateTimePickerEndDate.Value;
            e.Insert();

            MainForm.ResetController();
        }

        private void ViewOnButtonDeleteEvent(object sender, EventArgs eventArgs)
        {
            if (View.DataGridEvents.SelectedCells.Count <= 0)
                return;
            var dataEvent = (Event)View.DataGridEvents.SelectedCells[0].OwningRow.DataBoundItem;
            
            // Disable the event.
            dataEvent.Delete();

            // Refresh grid.
            MainForm.ResetController();
        }

        public override void Activate()
        {
            View.DataGridEvents.DataSource = Event.Select().ToList();
        }
    }
}
