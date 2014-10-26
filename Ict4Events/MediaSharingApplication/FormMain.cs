using System.Windows.Forms;
using MediaSharingApplication.Controllers;
using SharedClasses.Controls.WinForms.MVC;

namespace MediaSharingApplication
{
    public partial class FormMain : FormMVC
    {
        public FormMain()
        {
            InitializeComponent();
            
            ActiveController = new ControllerMain();
        }
    }
}