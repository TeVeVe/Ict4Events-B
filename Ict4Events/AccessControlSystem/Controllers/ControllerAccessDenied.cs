﻿using System.Threading.Tasks;
using AccessControlSystem.Views;
using SharedClasses.MVC;

namespace AccessControlSystem.Controllers
{
    public class ControllerAccessDenied : ControllerMVC<ViewAccessDenied>
    {
        public override void Create()
        {
            Task.Factory.StartNew(() =>
            {
                Task.Delay(2000).Wait();
                MainForm.Open<ControllerScanRFID>();
            });
        }
    }
}