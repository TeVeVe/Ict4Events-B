using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReservationSystem.Views;
using SharedClasses.Controls.WinForms;
using SharedClasses.Data.Models;
using SharedClasses.Extensions;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    class ControllerAddVisitorsToReservation : ControllerMVC<ViewAddVisitorsToReservation>
    {
        public List<VisitorInfoPanel> Panels { get; set; } 

        public ControllerAddVisitorsToReservation()
        {
            Panels = new List<VisitorInfoPanel>();

            View.ButtonSave += ViewOnButtonSave;
            View.ButtonCancel += ViewOnButtonCancel;
        }

        private void ViewOnButtonCancel(object sender, EventArgs eventArgs)
        {
            Close();
        }

        private void ViewOnButtonSave(object sender, EventArgs eventArgs)
        {
            // Save visitors to the database.
            foreach (var panel in Panels)
            {
                Visitor v = new Visitor();
                v.FirstName = panel.FirstName;
                v.Insertion = panel.Insertion;
                v.LastName = panel.LastName;
                v.ReservationId = 1;
                v.VisitorCode = (string)panel.Tag;

                v.Insert();
            }
        }

        public override void Activate()
        {
            var rfids = Values.SafeGetValue<IEnumerable<string>>("Visitors");
            if (rfids != null)
            {
                int num = 0;
                foreach (var rfid in rfids)
                {
                    num++;
                    var panel = new VisitorInfoPanel
                    {
                        Dock = DockStyle.Top,
                        Tag = rfid,
                        Title = num + ": " + rfid
                    };
                    View.FlowLayoutPanel.Controls.Add(panel);
                    Panels.Add(panel);
                }
            }
        }
    }
}
