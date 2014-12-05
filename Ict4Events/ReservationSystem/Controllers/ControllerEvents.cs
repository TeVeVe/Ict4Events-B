using System;
using System.Linq;
using System.Windows.Forms;
using ReservationSystem.Views;
using SharedClasses.Data.Models;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    internal class ControllerEvent : ControllerMVC<ViewEvents>
    {
        public ControllerEvent()
        {
            View.ButtonDeleteEvent += ViewOnButtonDeleteEvent;
            View.ButtonSave += ViewOnButtonSave;
        }

        private void ClearInputFields()
        {
            View.TextBoxEventName.Clear();
            View.TextBoxStreet.Clear();
            View.TextBoxHouseNumber.Clear();
            View.TextBoxCity.Clear();
            View.TextBoxPostalCode.Clear();
            View.DateTimePickerStartDate.Value = DateTime.Now;
            View.DateTimePickerStartDate.Value = DateTime.Now.AddDays(7);
        }

        private void ViewOnButtonSave(object sender, EventArgs eventArgs)
        {
            if (string.IsNullOrWhiteSpace(View.TextBoxEventName.Text))
            {
                MessageBox.Show("De naam van een event mag niet leeg zijn.", "Invoergegevens zijn onjuist",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var e = new Event();
            e.Name = View.TextBoxEventName.Text;
            e.Street = View.TextBoxStreet.Text;
            e.HouseNumber = View.TextBoxHouseNumber.Text;
            e.City = View.TextBoxCity.Text;
            e.PostalCode = View.TextBoxPostalCode.Text;
            e.StartDate = View.DateTimePickerStartDate.Value.Date;
            e.EndDate = View.DateTimePickerEndDate.Value.Date;
            e.LocationId = 1;

            e.Insert();
            ClearInputFields();

            MainForm.ResetController();
        }

        private void ViewOnButtonDeleteEvent(object sender, EventArgs eventArgs)
        {
            if (View.DataGridEvents.SelectedCells.Count <= 0)
                return;
            var dataEvent = (Event)View.DataGridEvents.SelectedCells[0].OwningRow.DataBoundItem;

            MessageBox.Show(
                string.Format(
                    "Als u het evenement '{0}' verwijderd. Worden alle reserveringen ook verwijderd. Wilt u doorgaan?",
                    dataEvent.Name),
                "Eventment verwijderen", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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