using System;
using ProductRentalApplication.Views;
using SharedClasses.Data.Models;
using SharedClasses.MVC;

namespace ProductRentalApplication.Controllers
{
    public class ControllerProductDetail : ControllerMVC<ViewProductDetail>
    {
        public ControllerProductDetail()
        {
            View.ButtonCancelClick += ViewOnButtonCancelClick;
            View.BrowseProductsClick += ViewOnBrowseProductsClick;
        }

        private void ViewOnBrowseProductsClick(object sender, EventArgs eventArgs)
        {
            
        }

        private void ViewOnButtonCancelClick(object sender, EventArgs eventArgs)
        {
            Close();
        }
    }
}