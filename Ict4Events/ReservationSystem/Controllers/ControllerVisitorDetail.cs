using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationSystem.Views;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    class ControllerVisitorDetail : ControllerMVC<ViewVisitorsDetail>
    {
        public ControllerVisitorDetail()
        {
            View.ButtonCancel += ViewOnButtonCancel;
            View.ButtonSave += ViewOnButtonSave;
        }

        private void ViewOnButtonCancel(object sender, EventArgs eventArgs)
        {
            MainForm.ActiveMenuItemText = "Bezoekers";
        }

        private void ViewOnButtonSave(object sender, EventArgs eventArgs)
        {
            MainForm.ActiveMenuItemText = "Bezoekers";
        }
    }
}
