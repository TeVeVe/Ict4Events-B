using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationSystem.Views;
using SharedClasses.Controls.WinForms;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    class ControllerProducts : ControllerMVC<ViewProducts>
    {
        public override void Activate()
        {
            View.flowLayoutPanel1.Controls.Clear();
            View.flowLayoutPanel1.Controls.Add(new PanelTile("moeder", "kees"));
        }
    }
}
