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
    class ControllerReservees : ControllerMVC<ViewReservees>
    {
        public ControllerReservees()
        {
            View.DataGridViewReserveesDoubleClick += ViewOnDataGridViewReserveesDoubleClick;
            View.ButtonReserveesAdd += ViewOnAddClick;
        }

        public override void Activate()
        {
            View.DataGridViewReservees.DataSource = Reservee.Select().ToList();
        }

        private void ViewOnDataGridViewReserveesDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var reservee = (Reservee) View.DataGridViewReservees.Rows[e.RowIndex].DataBoundItem;
            MainForm.Open<ControllerReserveeDetail>(new KeyValuePair<string, object>("RESERVEE", reservee));
        }

        private void ViewOnAddClick(object sender, EventArgs e)
        {
            MainForm.Open<ControllerReserveeDetail>(new KeyValuePair<string, object>("RESERVEE", null));
        }
    }
}
