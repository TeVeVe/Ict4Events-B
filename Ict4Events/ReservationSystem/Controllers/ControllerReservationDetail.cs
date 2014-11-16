using System;
using System.Collections.Generic;
using System.Linq;
using ReservationSystem.Views;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    internal class ControllerReservationDetail : ControllerMVC<ViewReservationDetail>
    {
        public ControllerReservationDetail()
        {
            View.ButtonAddEvent += ViewOnButtonAddEvent;
            View.ButtonSaveReservationClick += ViewOnButtonSaveReservationClick;
            View.ButtonCancelClick += ViewOnButtonCancelClick;
        }

        private void ViewOnButtonAddEvent(object sender, EventArgs eventArgs)
        {
        }

        private void ViewOnButtonAddProductClick(object sender, EventArgs eventArgs)
        {
            MainForm.ActiveMenuItemText = "Producten";
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
            MainForm.PopupController<ControllerAddVisitorsToReservation>(new KeyValuePair<string, object>("Visitors",
                randomRFIDs));
        }

        private void ViewOnButtonCancelClick(object sender, EventArgs eventArgs)
        {
            MainForm.Open<ControllerReservation>();
        }
    }
}