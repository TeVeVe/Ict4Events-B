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
    class ControllerVisitorDetail : ControllerMVC<ViewVisitorDetail>
    {
        public ControllerVisitorDetail()
        {
            View.ButtonDeleteRentalClick += OnButtonDeleteRentalClick;
        }

        public override void Activate()
        {
            IEnumerable<Rental> rentals = Rental.Select();//Rental.Select("VISITORCODE = " + reservee.VisitorCode.ToSqlFormat());
            View.extendedDataGridView1.DataSource = rentals.ToList();
        }

        private void OnButtonDeleteRentalClick(object sender, EventArgs e)
        {
            var rental = (Rental)View.extendedDataGridView1.SelectedCells[0].OwningRow.DataBoundItem;
            rental.Delete();
        }
    }
}
