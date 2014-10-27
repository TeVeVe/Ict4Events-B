using System;
using System.Windows.Forms;
using ProductRentalApplication.Views;
using SharedClasses.MVC;

namespace ProductRentalApplication.Controller
{
    public class ControllerMain : ControllerMVC<ViewMain>
    {
        public ControllerMain()
        {
            View.AddProductClick += ViewOnAddProductClick;
        }

        private void ViewOnAddProductClick(object sender, EventArgs eventArgs)
        {
            MainForm.PopupController(new ControllerProductDetail());
        }
    }
}