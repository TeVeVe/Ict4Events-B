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
        public ControllerReservation()
        {
            View.ButtonAddReservationClick += ViewOnButtonAddReservationClick;
            View.dataGridViewVisitors.DataSource = Reservee.Select().ToList();
            View.onDoubleClick += ViewOnButtonAddReservationClick;
        }

        private void ViewOnButtonAddReservationClick(object sender, EventArgs eventArgs)
        {
            MainForm.ActiveController = new ControllerReservationDetail();
        }
    }
}
