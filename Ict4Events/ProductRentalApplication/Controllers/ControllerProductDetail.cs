using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ProductRentalApplication.Views;
using SharedClasses.Controller;
using SharedClasses.Data.Models;
using SharedClasses.Extensions;
using SharedClasses.MVC;
using SharedClasses.Views;

namespace ProductRentalApplication.Controllers
{
    public class ControllerProductDetail : ControllerMVC<ViewProductDetail>
    {
        public UserAccount Account { get; set; }

        public ControllerProductDetail()
        {
            View.ButtonCancelClick += ViewOnButtonCancelClick;
            View.BrowseProductsClick += ViewOnBrowseProductsClick;
            View.ButtonOKClick += ViewOnButtonOkClick;
        }

        public override void Activate()
        {
            Account = Values.SafeGetValue<UserAccount>("UserAccount");
        }

        private void ViewOnButtonOkClick(object sender, EventArgs eventArgs)
        {
            // Aquiring user session

            MessageBox.Show("Je hebt "+ View.numericUpDownAmount.Value +" " + View.Product.Name +"(s) gehuurd!");

            IEnumerable<Rental> rentals = Rental.Select("VISITORCODE = " + Account.VisitorCode.ToSqlFormat());

            Rental r = rentals.FirstOrDefault();
            r.ProductId = View.Product.Id;
            r.VisitorCode = Account.VisitorCode;
            r.IsPaid = false;
            r.Amount = View.Amount;
            r.VisitorCode = Account.VisitorCode;
            r.StartTime = DateTime.Now;
            r.Insert();
            Close();
        }

        private void ViewOnBrowseProductsClick(object sender, EventArgs eventArgs)
        {
            var lookup = MainForm.PopupController<ControllerLookup<Product>>();
            var product = lookup.SelectedRows.FirstOrDefault();

            View.Product = product;
        }

        private void ViewOnButtonCancelClick(object sender, EventArgs eventArgs)
        {
            Close();
        }
    }
}