using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationSystem.Views;
using SharedClasses.Data.Models;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    class ControllerReservation : ControllerMVC<ViewReservation>
    {
        public override void Activate()
        {
            View.dataGridViewVisitors.DataSource = Reservation.Select().ToList();
        }

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
