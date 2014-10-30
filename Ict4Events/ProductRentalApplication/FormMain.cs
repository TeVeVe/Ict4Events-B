using ProductRentalApplication.Controllers;
using SharedClasses.Events;
using SharedClasses.MVC;
using SharedClasses.Views;

namespace ProductRentalApplication
{
    public partial class FormMain : FormMVC
    {
        public FormMain()
        {
            InitializeComponent();

            ActiveController = new ControllerLogin();
        }
    }
}