using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ReservationSystem.Views;
using SharedClasses.Data.Models;
using SharedClasses.Extensions;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    internal class ControllerReservation : ControllerMVC<ViewReservation>
    {
        public ControllerReservation()
        {
            View.ButtonAddReservationClick += ViewButtonAddReservationClick;
            View.ButtonDeleteReservationClick += ViewOnButtonDeleteReservationClick;
            
            View.GridDoubleClick += ViewOnGridDoubleClick;
            View.CheckboxChecked += ViewOnGridCheckboxClick;
        }

        private void ViewOnGridCheckboxClick(object sender, EventArgs e)
        {
            DataGridViewCheckBoxCell ch = new DataGridViewCheckBoxCell();
            ch = (DataGridViewCheckBoxCell)View.DataGridViewVisitors.Rows[View.DataGridViewVisitors.CurrentRow.Index].Cells[1];

            if (ch.Value == null)
                ch.Value = false;
            switch (ch.Value.ToString())
            {
                case "True":
                    ch.Value = false;
                    break;
                case "False":
                    ch.Value = true;
                    break;
            }
            var hasPaid = (Reservation)View.DataGridViewVisitors.SelectedCells[0].OwningRow.DataBoundItem;
            if (ch.Value.ToString() == "False")
            {
                hasPaid.PaymentStatus = false;
                hasPaid.Update();
            }
            else
            {
                hasPaid.PaymentStatus = true;
                hasPaid.Update();
            }
        }

        private void ViewOnButtonDeleteReservationClick(object sender, EventArgs eventArgs)
        {
            if (View.DataGridViewVisitors.SelectedCells.Count <= 0)
                return;
            var reservation = (Reservation)View.DataGridViewVisitors.SelectedCells[0].OwningRow.DataBoundItem;
            reservation.Delete();
            MainForm.ResetController();
        }

        private void ViewOnGridDoubleClick(object sender, DataGridViewCellEventArgs dataGridViewCellEventArgs)
        {
            Reservation reservation = null;
            if (View.DataGridViewVisitors.SelectedCells.Count > 0)
                reservation = (Reservation)View.DataGridViewVisitors.SelectedCells[0].OwningRow.DataBoundItem;

            MainForm.Open<ControllerReservationDetail>(new KeyValuePair<string, object>("Reservation", reservation));
        }

        public override void Activate()
        {
            View.DataGridViewVisitors.DataSource = Reservation.Select().ToList();
        }

        private void ViewButtonAddReservationClick(object sender, EventArgs eventArgs)
        {
            MainForm.Open<ControllerReservationDetail>(new KeyValuePair<string, object>("Reservation", null));
        }

        private void DataGridViewVisitors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}