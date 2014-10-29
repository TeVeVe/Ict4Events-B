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
            View.ButtonAddVisitorClick += ViewOnButtonAddVisitorClick;
        }

        private void ViewOnButtonAddVisitorClick(object sender, EventArgs eventArgs)
        {
            MainForm.ActiveController = new ControllerVisitorDetail();
        }
    }
}
