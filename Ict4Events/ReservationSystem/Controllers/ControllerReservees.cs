using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ReservationSystem.Views;
using SharedClasses.Data.Models;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    internal class ControllerReservees : ControllerMVC<ViewReservees>
    {
        public ControllerReservees()
        {
            View.DataGridViewReserveesDoubleClick += ViewOnDataGridViewReserveesDoubleClick;
            View.ButtonAddRowClick += ViewOnAddRowClickClick;
            View.ButtonDeleteRowClick += ViewOnButtonDeleteRowClick;
        }

        private void ViewOnButtonDeleteRowClick(object sender, EventArgs eventArgs)
        {
            if (View.DataGridViewReservees.SelectedCells.Count == 0)
                return;

            var reservee = (Reservee)View.DataGridViewReservees.SelectedCells[0].OwningRow.DataBoundItem;

            reservee.Delete();

            MainForm.ResetController();
        }

        public override void Activate()
        {
            View.DataGridViewReservees.DataSource = Reservee.Select().ToList();
        }

        private void ViewOnDataGridViewReserveesDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var reservee = (Reservee)View.DataGridViewReservees.Rows[e.RowIndex].DataBoundItem;

            // Open a new detail page with selected data.
            MainForm.Open<ControllerReserveeDetail>(new KeyValuePair<string, object>("RESERVEE", reservee));
        }

        private void ViewOnAddRowClickClick(object sender, EventArgs e)
        {
            // Open a new detail page with empty data.
            MainForm.Open<ControllerReserveeDetail>(new KeyValuePair<string, object>("RESERVEE", null));
        }
    }
}