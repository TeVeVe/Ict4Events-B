using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        public override void Activate()
        {
            Task.Factory.StartNew(() =>
            {
                Task.Delay(5000).Wait();
                FormMain.Form.Open<ControllerScanRFID>();
            });
            InteractiveMap map = View.InteractiveMap;
            map.ImageMap = Image.FromFile("location1.png");
            map.MouseClick += (sender, e) => { MessageBox.Show(string.Format("X: {0}, Y: {1}", e.X, e.Y)); };
            var visitor = Values.SafeGetValue<Visitor>("visitor");
            int reservationID = visitor.ReservationId;


            IEnumerable<ReservationSpot> reservation =
                ReservationSpot.Select("RESERVATIONID = " + reservationID.ToSqlFormat());
            double x = reservation.FirstOrDefault().Spot.LocX;
            double y = reservation.FirstOrDefault().Spot.LocY;

            map.Add(x, y);
        }
    }
}