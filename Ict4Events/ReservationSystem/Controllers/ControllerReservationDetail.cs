using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationSystem.Views;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    class ControllerReservationDetail : ControllerMVC<ViewReservationDetail>
    {
        public ControllerReservationDetail()
        {
            View.ButtonAddProductClick += ViewOnButtonAddProductClick;
            View.ButtonSaveReservationClick += ViewOnButtonSaveReservationClick;
            View.ButtonCancelClick += ViewOnButtonCancelClick;
        }

        private void ViewOnButtonAddProductClick(object sender, EventArgs eventArgs)
        {
            MainForm.ActiveMenuItemText = "Producten";
        }

        private void ViewOnButtonSaveReservationClick(object sender, EventArgs eventArgs)
        {
            MainForm.ActiveMenuItemText = "Reserveringen";
        }

        private void ViewOnButtonCancelClick(object sender, EventArgs eventArgs)
        {
            MainForm.ActiveMenuItemText = "Reserveringen";
        }
    }
}
