using AccessControlSystem.Views;
using SharedClasses.Controls.WinForms;
using SharedClasses.MVC;

namespace AccessControlSystem.Controllers
{
    public class ControllerLocationDetails : ControllerMVC<ViewLocationDetails>
    {
        public ControllerLocationDetails(string name)
        {
            View.VisitorName = name;

            View.Spots.Add(new InteractiveMap.Spot(0, 0));
        }
    }
}