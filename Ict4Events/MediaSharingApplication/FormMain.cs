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

            DataModel.Database = Database.FromSettings();
        }
    }
}