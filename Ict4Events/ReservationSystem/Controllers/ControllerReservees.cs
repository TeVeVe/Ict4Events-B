using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReservationSystem.Views;
using SharedClasses.Data;
using SharedClasses.Data.Models;
using SharedClasses.Extensions;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    class ControllerReservees : ControllerMVC<ViewReservees>
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

            // TODO: Instead of removing all references we should update the reservee with a active boolean in the database. Then check further.
            var reservee = (Reservee)View.DataGridViewReservees.SelectedCells[0].OwningRow.DataBoundItem;
            var reserveeId = reservee.ReserveeId;
            DataModel.Database.ExecuteNonQuery("DELETE FROM Rental r WHERE r.VISITORCODE IN (SELECT VISITORCODE FROM Wristband w JOIN reservation re ON w.RESERVATIONID = re.RESERVATIONID WHERE re.RESERVATIONID =  " + reserveeId.ToSqlFormat()+")");
            DataModel.Database.ExecuteNonQuery(
    string.Format(
        "DELETE FROM FEEDPOST fp WHERE fp.USERACCOUNTID IN (SELECT ua.USERACCOUNTID FROM USERACCOUNT ua WHERE ua.VISITORCODE IN (SELECT w.VISITORCODE FROM Wristband w WHERE w.RESERVATIONID IN (SELECT r.RESERVATIONID FROM RESERVATION R WHERE R.RESERVEEID = {0})))", reserveeId.ToSqlFormat()));
            DataModel.Database.ExecuteNonQuery(string.Format("DELETE FROM USERACCOUNT a WHERE a.VISITORCODE IN (SELECT w.VISITORCODE FROM Wristband w WHERE w.RESERVATIONID IN (SELECT r.reservationid FROM RESERVATION r WHERE r.RESERVEEID = {0}))", reserveeId));
            DataModel.Database.ExecuteNonQuery("DELETE FROM Wristband w WHERE w.RESERVATIONID IN (SELECT r.RESERVATIONID FROM Reservation r WHERE r.ReserveeID = " + reserveeId.ToSqlFormat() + ")");
            DataModel.Database.ExecuteNonQuery("DELETE FROM Reservation WHERE reserveeID = "+reserveeId.ToSqlFormat());

            reservee.Delete();
            MainForm.ResetController();
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

        private void ViewOnAddRowClickClick(object sender, EventArgs e)
        {
            MainForm.Open<ControllerReserveeDetail>(new KeyValuePair<string, object>("RESERVEE", null));
        }
    }
}
