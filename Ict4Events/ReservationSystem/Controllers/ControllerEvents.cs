using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationSystem.Views;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    class ControllerEvent : ControllerMVC<ViewEvents>
    {
        public ControllerEvent()
        {
            //View.ButtonCancel += ViewOnButtonCancel;
        }
    }
}
