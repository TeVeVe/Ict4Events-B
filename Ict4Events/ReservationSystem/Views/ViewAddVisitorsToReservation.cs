using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReservationSystem.Views
{
    public partial class ViewAddVisitorsToReservation : UserControl
    {
        public event EventHandler ButtonSave;
        public event EventHandler ButtonCancel;

        protected virtual void OnButtonCancel()
        {
            EventHandler handler = ButtonCancel;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        protected virtual void OnButtonSave()
        {
            EventHandler handler = ButtonSave;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public ViewAddVisitorsToReservation()
        {
            InitializeComponent();
        }

        private void FlowLayoutPanel_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel.Focus();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            OnButtonCancel();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            OnButtonSave();
        }
    }
}
