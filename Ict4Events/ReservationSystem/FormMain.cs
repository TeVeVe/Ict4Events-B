using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ReservationSystem.Controllers;
using ReservationSystem.Views;
using SharedClasses.Extensions;
using SharedClasses;
using SharedClasses.Detectors;
using SharedClasses.MVC;

namespace ReservationSystem
{
    public partial class FormMain : FormMVC
    {
        public FormMain()
        {
            InitializeComponent();

            AddMenuItem("Bezoekers", new ControllerVisitor());
            AddMenuItem("Evenementen", new ControllerEvent());
            AddMenuItem("Reserveringen", null);
            AddMenuItem("Producten", null);

            MarkAsMain<ControllerVisitor>();
        }
    }
}
