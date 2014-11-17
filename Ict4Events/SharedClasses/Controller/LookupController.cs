using SharedClasses.Extensions;
using SharedClasses.MVC;
using SharedClasses.Views;

namespace SharedClasses.Controller
{
    public class LookupController<T> : ControllerMVC<ViewLookup>
    {
        public override void Activate()
        {
            var data = Values.SafeGetValue<T[]>("Data");

            View.DataGridView.DataSource = data;
        }
    }
}