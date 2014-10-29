using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationSystem.Views;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    class ControllerReservation : ControllerMVC<ViewReservation>
    {
        public ControllerReservation()
        {
            View.ButtonAddReservationClick += ViewOnButtonAddReservationClick;
        }

        private void ViewOnButtonAddReservationClick(object sender, EventArgs eventArgs)
        {
            MainForm.ActiveController = new ControllerReservationDetail();
        }
    }
}
