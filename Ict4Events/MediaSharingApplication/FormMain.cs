using System.Windows.Forms;
using MediaSharingApplication.Controllers;
using SharedClasses.Data;
using SharedClasses.MVC;

namespace MediaSharingApplication
{
    public partial class FormMain : FormMVC
    {
        public FormMain()
        {
            InitializeComponent();

            MarkAsMain<ControllerLogin>();

            DataModel.Database = new Database("SYSTEM", "admin", "localhost");
        }
    }
}