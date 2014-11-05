using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using MediaSharingApplication.Controllers;
using MediaSharingApplication.Views;
using SharedClasses.Data;
using SharedClasses.Data.Models;
using SharedClasses.MVC;

namespace MediaSharingApplication
{
    public partial class FormMain : FormMVC
    {
        public UserAccount UserSession { get; set; }

        public FormMain()
        {
            InitializeComponent();
            
            MarkAsMain<ControllerMain>();

            Open<ControllerLogin>();
        }
    }
}