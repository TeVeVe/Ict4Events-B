using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReservationSystem.Views;
using SharedClasses.Extensions;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    class ControllerAddVisitorsToReservation : ControllerMVC<ViewAddVisitorsToReservation>
    {
        public override void Activate()
        {
            var rfids = Values.SafeGetValue<IEnumerable<string>>("Visitors");
            if (rfids != null)
            {

            }
        }

        private void ViewOnButtonAddGroupNames(object sender, EventArgs e)
        {
            MainForm.Open<ControllerAddVisitorsToReservation>();
        }
    }
}
