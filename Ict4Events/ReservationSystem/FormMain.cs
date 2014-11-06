using ReservationSystem.Controllers;
using SharedClasses.MVC;

namespace ReservationSystem
{
    public partial class FormMain : FormMVC
    {
        public FormMain()
        {
            InitializeComponent();

            AddMenuItem<ControllerVisitor>("Bezoekers");
            AddMenuItem<ControllerEvent>("Evenementen");
            AddMenuItem<ControllerReservation>("Reserveringen");
            AddMenuItem<ControllerProducts>("Producten");
            AddMenuItem<ControllerReservees>("Reserveerders");

            MarkAsMain<ControllerVisitor>();

            AllowUserResize = true;
        }
    }
}