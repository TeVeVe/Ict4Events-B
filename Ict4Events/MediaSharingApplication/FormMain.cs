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

#if DEBUG
            UserSession = 1;
            MarkAsMain<ControllerMain>();
#else
            MarkAsMain<ControllerLogin>();
#endif
        }

        public int UserSession { get; set; }
    }
}