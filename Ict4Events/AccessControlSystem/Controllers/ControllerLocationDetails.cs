using AccessControlSystem.Views;
using SharedClasses.Models.MVC;

namespace AccessControlSystem.Controllers
{
    public class ControllerLocationDetails : ControllerMVC<ViewLocationDetails>
    {
        public ControllerLocationDetails(string name)
        {
            View.VisitorName = name;
        }
    }
}