﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControlSystem.Views;
using SharedClasses.MVC;

namespace AccessControlSystem.Controllers
{
    class ControllerVisitorExit : ControllerMVC<ViewVisitorExit>
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