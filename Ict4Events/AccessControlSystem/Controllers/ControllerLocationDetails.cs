
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using AccessControlSystem.Views;
using SharedClasses.Controls.WPF;
using SharedClasses.Models.MVC;

namespace AccessControlSystem.Controllers
{
    public class ControllerLocationDetails : ControllerMVC<ViewLocationDetails>
    {
        public ControllerLocationDetails(string name)
        {
            View.VisitorName = name;
        }
    }
}