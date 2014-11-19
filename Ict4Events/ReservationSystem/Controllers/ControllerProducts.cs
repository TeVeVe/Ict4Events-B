using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReservationSystem.Views;
using SharedClasses.Data.Models;
using SharedClasses.Extensions;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    internal class ControllerProducts : ControllerMVC<ViewProducts>
    {
        public override void Activate()
        {
            View.TextBoxSearch.TextChanged += (sender, args) => Task.Factory.StartNew(() =>
            {
                IEnumerable<Product> foundProducts =
                    Product.Select(String.Format("NAME LIKE '%{0}%' OR DESCRIPTION LIKE '%{0}%'",
                        View.TextBoxSearch.Text));
                View.ExtendedDataGridView.InvokeSafe((c) =>
                {
                    View.ExtendedDataGridView.DataSource = foundProducts.ToList();
                });
            });

            IEnumerable<Product> products = Product.Select();
            View.ExtendedDataGridView.DataSource = products.ToList();
        }
    }
}