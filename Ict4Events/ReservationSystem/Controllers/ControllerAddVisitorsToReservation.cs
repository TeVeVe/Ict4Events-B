using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReservationSystem.Views;
using SharedClasses.Controls.WinForms;
using SharedClasses.Extensions;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    class ControllerAddVisitorsToReservation : ControllerMVC<ViewAddVisitorsToReservation>
    {
        public ControllerAddVisitorsToReservation()
        {
            View.ButtonSave += ViewOnButtonSave;
            View.ButtonCancel += ViewOnButtonCancel;
        }

        private void ViewOnButtonCancel(object sender, EventArgs eventArgs)
        {
            MainForm.Open<ControllerReservationDetail>();
        }

        private void ViewOnButtonSave(object sender, EventArgs eventArgs)
        {
            // TODO: Store data in database
        }

        public override void Activate()
        {
            var rfids = Values.SafeGetValue<IEnumerable<string>>("Visitors");
            if (rfids != null)
            {
                foreach (var rfid in rfids)
                {
                    View.FlowLayoutPanel.Controls.Add(new VisitorInfoPanel() { Dock = DockStyle.Top, Tag = rfid });
                    
                }
            }
        }
    }
}
