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
using SharedClasses.Extensions;
using SharedClasses;
using SharedClasses.Detectors;

namespace ReservationSystem
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        public void DisplayScreen(UserControl uc)
        {
            panelMainView.ShowInView(uc);
        }

        protected override void OnLoad(EventArgs e)
        {
            // Display first screen
            DisplayScreen(new UCReservationSystemProducts());
        }
    }
}
