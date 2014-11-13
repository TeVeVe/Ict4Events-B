using ProductRentalApplication.Controllers;
using SharedClasses.Data.Models;
using SharedClasses.Events;
using SharedClasses.MVC;
using SharedClasses.Views;

namespace ProductRentalApplication
{
    public partial class FormMain : FormMVC
    {
        public UserAccount UserSession { get; set; }

        public FormMain()
        {
            InitializeComponent();

            ActiveController = new ControllerLogin();
        }
    }
}