using MediaSharingApplication.Controllers;
using SharedClasses.Data.Models;
using SharedClasses.MVC;

namespace MediaSharingApplication
{
    public partial class FormMain : FormMVC
    {
        public FormMain()
        {
            InitializeComponent();

            MarkAsMain<ControllerMain>();
            MarkAsMain<ControllerLogin>();
        }

        public UserAccount UserSession { get; set; }
    }
}