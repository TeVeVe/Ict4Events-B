using System;
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
            View.CellModifyVisitorClick += ViewOnCellModifyVisitorClick;
        }

        public override void Activate()
        {
            View.DataGridViewVisitors.DataSource = Wristband.Select().ToList();
        }

        private void ViewOnCellModifyVisitorClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MainForm.Open<ControllerReserveeDetail>(new KeyValuePair<string, object>("USERACCOUNT", View.DataGridViewVisitors.Rows[e.RowIndex].DataBoundItem));
        }

        private void ViewOnCheckboxIsOnSiteCheckChanged(object sender, EventArgs eventArgs)
        {
            if (View.CheckBoxIsOnSite.Checked)
            {
                // All visitors on site
                IEnumerable<Wristband> wristbands = Wristband.Select("IsOnSite = 'Y'");

                // Storing the amount of visitors on site
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
                else
                {
                    View.DataGridViewVisitors.DataSource = Wristband.Select("IsOnSite = 'Y'").ToList();
                    MessageBox.Show("Er zijn momenteel geen gasten aanwezig.");
                }
            }
            else
            {
                // Refresh data.
                View.DataGridViewVisitors.DataSource = Wristband.Select().ToList();
            }
        }

        private void ViewOnButtonAddVisitorClick(object sender, EventArgs eventArgs)
        {
            MainForm.Open<ControllerVisitorDetail>();
        }
    }
}