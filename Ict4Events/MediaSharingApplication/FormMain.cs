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
            //UserSession = UserAccount.Select("USERACCOUNTID = 1").FirstOrDefault();
            MarkAsMain<ControllerLogin>();
#else
            MarkAsMain<ControllerLogin>();
#endif
        }

        public UserAccount UserSession { get; set; }
    }
}