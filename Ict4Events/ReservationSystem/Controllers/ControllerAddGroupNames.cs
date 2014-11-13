using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationSystem.Views;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    class ControllerAddGroupNames : ControllerMVC<ViewReservationDetail>
    {
        public ControllerAddGroupNames()
        {
            View.ButtonAddGroupNames += ViewOnButtonAddGroupNames;
        }

        private void ViewOnButtonAddGroupNames(object sender, EventArgs e)
        {
            MainForm.PopupController<ControllerAddGroupNames>();
        }
    }
}
