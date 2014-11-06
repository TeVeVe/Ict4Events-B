using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using MediaSharingApplication.Controllers;
using SharedClasses;
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
        }

        public UserAccount UserSession { get; set; }
    }
}