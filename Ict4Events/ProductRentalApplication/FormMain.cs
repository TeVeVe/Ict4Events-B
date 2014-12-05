using ProductRentalApplication.Controllers;
using SharedClasses.Data.Models;
using SharedClasses.MVC;

namespace ProductRentalApplication
{
    public partial class FormMain : FormMVC
    {
        public FormMain()
        {
            InitializeComponent();

            Open<ControllerLogin>();
        }

        public UserAccount UserSession { get; set; }
    }
}