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
        public override void Create()
        {
            View.DataGridViewReservees.DataSource = Reservee.Select().ToList();
            View.DataGridViewReserveesDoubleClick += ViewOnDataGridViewReserveesDoubleClick;
            View.ButtonReserveesAdd += ViewOnAddClick;

        }

        private void ViewOnDataGridViewReserveesDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var reservee = (Reservee) View.DataGridViewReservees.Rows[e.RowIndex].DataBoundItem;
            MainForm.Open<ControllerReserveeDetail>();
        }

        private void ViewOnAddClick(object sender, EventArgs e)
        {
            MainForm.Open<ControllerReserveeDetail>();
        }
    }
}
