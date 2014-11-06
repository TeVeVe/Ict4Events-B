﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ReservationSystem.Views;
using SharedClasses.Data.Models;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    internal class ControllerVisitor : ControllerMVC<ViewVisitors>
    {
        public ControllerVisitor()
        {
            View.ButtonAddVisitorClick += ViewOnButtonAddVisitorClick;
            View.CheckboxIsOnSiteCheckChanged += ViewOnCheckboxIsOnSiteCheckChanged;
            View.DataGridViewVisitors.DataSource = Wristband.Select().ToList();
        }

        private void ViewOnCheckboxIsOnSiteCheckChanged(object sender, EventArgs eventArgs)
        {
            if (View.CheckBoxIsOnSite.Checked)
            {
                IEnumerable<Wristband> wristbands = Wristband.Select("IsOnSite = 'Y'");
                int NumberOfVisitorsOnSite = wristbands.Count();
                if (NumberOfVisitorsOnSite > 0)
                {
                    if (NumberOfVisitorsOnSite == 1)
                    {
                        MessageBox.Show("Er is " + NumberOfVisitorsOnSite + " gast aanwezig.");
                    }
                    else
                    {
                        MessageBox.Show("Er zijn " + NumberOfVisitorsOnSite + " gasten aanwezig.");
                    }
                    View.DataGridViewVisitors.DataSource = Wristband.Select("IsOnSite = 'Y'").ToList();
                }
            }
            else
            {
                View.DataGridViewVisitors.DataSource = Wristband.Select().ToList();
            }
        }

        private void ViewOnButtonAddVisitorClick(object sender, EventArgs eventArgs)
        {
            MainForm.ActiveController = new ControllerVisitorDetail();
        }
    }
}