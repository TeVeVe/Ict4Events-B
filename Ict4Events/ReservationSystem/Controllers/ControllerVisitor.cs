using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationSystem.Views;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    class ControllerVisitor : ControllerMVC<ViewVisitors>
    {

        public ControllerVisitor()
        {
            View.ButtonAddVisitor += ViewOnButtonAddVisitor;
        }

        private void ViewOnButtonAddVisitor(object sender, EventArgs eventArgs)
        {
            MainForm.ActiveController = new ControllerVisitorDetail();
        }
    }
}
