using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReservationSystem.Views;
using SharedClasses.MVC;
using SharedClasses.Data.Models;

namespace ReservationSystem.Controllers
{
    class ControllerVitsitorsOnSite : ControllerMVC<ViewVisitorsOnSite>
    {
        public override void Create()
        {
            IEnumerable<Wristband> wristbands = Wristband.Select();
            var NumberOfWristbands = wristbands.Count();

            MessageBox.Show(""+NumberOfWristbands);
        }
    }
}
