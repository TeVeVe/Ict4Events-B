using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ReservationSystem.Views;
using SharedClasses.Controls.WinForms;
using SharedClasses.Data.Models;
using SharedClasses.Extensions;
using SharedClasses.MVC;

namespace ReservationSystem.Controllers
{
    internal class ControllerAddVisitorsToReservation : ControllerMVC<ViewAddVisitorsToReservation>
    {
        public ControllerAddVisitorsToReservation()
        {
            Panels = new List<VisitorInfoPanel>();

            View.ButtonSave += ViewOnButtonSave;
            View.ButtonCancel += ViewOnButtonCancel;

            DialogResult = DialogResult.None;
        }

        public DialogResult DialogResult { get; set; }
        public List<VisitorInfoPanel> Panels { get; set; }
        public Reservation Reservation { get; set; }

        private void ViewOnButtonCancel(object sender, EventArgs eventArgs)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ViewOnButtonSave(object sender, EventArgs eventArgs)
        {
            // Save visitors to the database.
            foreach (VisitorInfoPanel panel in Panels)
            {
                var v = new Visitor();

                v.VisitorCode = (string)panel.Tag;
                v.FirstName = panel.FirstName;
                v.Insertion = panel.Insertion;
                v.LastName = panel.LastName;
                v.ReservationId = Reservation.Id;
                v.VisitorCode = (string)panel.Tag;
                v.Phone = panel.PhoneNumber;

                v.Insert();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        public override void Activate()
        {
            Reservation = Values.SafeGetValue<Reservation>("Reservation");
            var reservee = Values.SafeGetValue<Reservee>("Reservee");
            var rfids = Values.SafeGetValue<IEnumerable<string>>("Visitors");
            if (rfids != null)
            {
                int num = 0;
                foreach (string rfid in rfids)
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

            if (reservee != null)
            {
                VisitorInfoPanel panel = Panels.First();
                panel.FirstName = reservee.FirstName;
                panel.Insertion = reservee.Insertion;
                panel.LastName = reservee.LastName;
                panel.PhoneNumber = reservee.Phone;
            }
        }
    }
}