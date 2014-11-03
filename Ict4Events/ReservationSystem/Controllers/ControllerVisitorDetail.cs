﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationSystem.Views;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    class ControllerVisitorDetail : ControllerMVC<ViewVisitorsDetail>
    {
        public ControllerVisitorDetail()
        {
            View.ButtonCancelClick += ViewOnButtonCancelClick;
            View.ButtonSaveClick += ViewOnButtonSaveClick;
        }

        private void ViewOnButtonCancelClick(object sender, EventArgs eventArgs)
        {
            MainForm.ActiveMenuItemText = "Bezoekers";
        }

        private void ViewOnButtonSaveClick(object sender, EventArgs eventArgs)
        {
            MainForm.ActiveMenuItemText = "Bezoekers";
        }
    }
}