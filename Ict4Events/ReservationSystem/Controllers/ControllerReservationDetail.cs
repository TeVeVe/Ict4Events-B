using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReservationSystem.Views;
using SharedClasses.Interfaces;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    class ControllerReservationDetail : ControllerMVC<ViewReservationDetail>
    {
        public ControllerReservationDetail()
        {
            View.ButtonAddEvent += ViewOnButtonAddEvent;
            View.ButtonSaveReservationClick += ViewOnButtonSaveReservationClick;
            View.ButtonCancelClick += ViewOnButtonCancelClick;
        }

        private void ViewOnButtonAddEvent(object sender, EventArgs eventArgs)
        {
            //
        }

        private void ViewOnButtonAddProductClick(object sender, EventArgs eventArgs)
        {
            MainForm.ActiveMenuItemText = "Producten";
        }

        private void ViewOnButtonSaveReservationClick(object sender, EventArgs eventArgs)
        {
            Random r = new Random();
            var randomRFIDs =
                Enumerable.Repeat("", (int)View.NumericUpDownVisitorAmount.Value).Select(s => Enumerable.Repeat("", 8).Select(s2 => r.Next(16).ToString("X")).Aggregate((s1, s2) => s1 + s2)).ToList();

            MainForm.PopupController<ControllerAddVisitorsToReservation>(new KeyValuePair<string, object>("Visitors", randomRFIDs));
        }

        private void ViewOnButtonCancelClick(object sender, EventArgs eventArgs)
        {
            MainForm.Open<ControllerReservation>();
        }
    }
}
