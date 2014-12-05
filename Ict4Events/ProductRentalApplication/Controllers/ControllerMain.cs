using System;
using System.Collections.Generic;
using System.Linq;
using ProductRentalApplication.Views;
using SharedClasses.Data.Models;
using SharedClasses.Extensions;
using SharedClasses.MVC;

namespace ProductRentalApplication.Controllers
{
    public class ControllerMain : ControllerMVC<ViewMain>
    {
        public ControllerMain()
        {
            View.AddProductClick += ViewOnAddProductClick;
        }

        public override void Activate()
        {
            UserAccount account = ((FormMain)MainForm).UserSession;
            View.DataGridView.DataSource = Rental.Select("VISITORCODE = " + account.VisitorCode.ToSqlFormat()).ToList();
        }

        private void ViewOnAddProductClick(object sender, EventArgs eventArgs)
        {
            MainForm.PopupController<ControllerProductDetail>(new KeyValuePair<string, object>("UserAccount",
                ((FormMain)MainForm).UserSession));
            MainForm.ResetController();
        }
    }
}