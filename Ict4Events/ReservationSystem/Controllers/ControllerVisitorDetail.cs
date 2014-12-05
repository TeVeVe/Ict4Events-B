using System;
using System.Collections.Generic;
using System.Linq;
using ReservationSystem.Views;
using SharedClasses.Data.Models;
using SharedClasses.Extensions;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    internal class ControllerVisitorDetail : ControllerMVC<ViewVisitorDetail>
    {
        public ControllerVisitorDetail()
        {
            View.ButtonDeleteRentalClick += OnButtonDeleteRentalClick;
        }

        public override void Activate()
        {
            var visitor = Values.SafeGetValue<Visitor>("Visitor");
            if (visitor == null)
                return;
            string visitorcode = visitor.VisitorCode;

            IEnumerable<Rental> rentals = Rental.Select("VISITORCODE = " + visitorcode);
            View.extendedDataGridView1.DataSource = rentals.ToList();
        }

        private void OnButtonDeleteRentalClick(object sender, EventArgs e)
        {
            var rental = (Rental)View.extendedDataGridView1.SelectedCells[0].OwningRow.DataBoundItem;
            rental.Delete();
            MainForm.ResetController();
        }
    }
}