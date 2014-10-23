using System.Windows.Forms;
using SharedClasses.Interfaces;

namespace SharedClasses.Models.MVC
{
    public abstract class ControllerMVC<T> : IController<T> where T : class, new()
    {
        protected ControllerMVC()
        {
            View = new T();
        }

        Control IController.View
        {
            get { return (Control)(object)View; }
            set { View = (T)(object)value; }
        }
        public T View { get; set; }
    }
}