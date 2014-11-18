using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccessControlSystem.Views;
using SharedClasses.Controls.WinForms;
using SharedClasses.Data.Models;
using SharedClasses.Extensions;
using SharedClasses.MVC;

namespace AccessControlSystem.Controllers
{
    public class ControllerLocationDetails : ControllerMVC<ViewLocationDetails>
    {
        public ControllerLocationDetails()
        {
        }

        public override void Activate()
        {
            Task.Factory.StartNew(() =>
            {
                Task.Delay(5000).Wait();
                FormMain.Form.Open<ControllerScanRFID>();
            });
            var map = View.InteractiveMap;
            map.MouseClick += (sender, e) =>
            {
                MessageBox.Show(string.Format("X: {0}, Y: {1}", e.X, e.Y));
            };
            var visitor = Values.SafeGetValue<Visitor>("visitor");
            var reservationID = visitor.ReservationId;


            var reservation = ReservationSpot.Select("RESERVATIONID = " + reservationID.ToSqlFormat());
            var x = reservation.FirstOrDefault().Spot.LocX;
            var y = reservation.FirstOrDefault().Spot.LocY;

            map.Spots.Add(new InteractiveMap.Spot(x,y) { Color = Color.Red, Checked = false});
        }
    }
}