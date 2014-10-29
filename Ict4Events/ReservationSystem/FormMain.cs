using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ReservationSystem.Controllers;
using ReservationSystem.Views;
using SharedClasses.Data;
using SharedClasses.Data.AbstractClasses;
using SharedClasses.Data.Models;
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
            AddMenuItem("Reserveringen", new ControllerReservation());
            AddMenuItem("Producten", new ControllerProducts());

            MarkAsMain<ControllerVisitor>();

            // DEBUG
            Database db = Database.FromSettings();
            DataModel.Database = db;
            Product.Select(p => p.Name == "pizza");
        }
    }
}
