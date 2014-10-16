using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReservationSystem
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        UserControl mCurrent;

        public void DisplayScreen(UserControl uc)
        {
            if (mCurrent != null)
            {
                this.Controls.Remove(mCurrent);
                mCurrent.Dispose();
            }
            mCurrent = uc;
            if (uc != null)
            {
                uc.Location = new Point(5, 5);
                uc.Size = new Size(this.ClientSize.Width - 10,
                  this.ClientSize.Height - 10);
                this.Controls.Add(uc);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            // Display first screen
            DisplayScreen(new UCreservationSystemVisitors());
        }
    }
}
