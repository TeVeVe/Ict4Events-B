using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedClasses.MVC;
using SharedClasses.Views;

namespace MediaSharingApplication.Controllers
{
    class ControllerRegisterAccount : ControllerMVC<ViewRegisterAccount>
    {
        public ControllerRegisterAccount()
        {
            View.RegisterClick += ViewOnRegisterClick;
        }

        private void ViewOnRegisterClick(object sender, EventArgs eventArgs)
        {
            
        }
    }
}
