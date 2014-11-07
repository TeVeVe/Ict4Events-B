using System;
using System.Windows.Forms;
using ReservationSystem.Controllers;

namespace ReservationSystem.Views
{
    public partial class ViewReservation : UserControl
    {
        public event EventHandler<DataGridViewCellEventArgs> onDoubleClick;

        protected virtual void OnOnDoubleClick(DataGridViewCellEventArgs e)
        {
            EventHandler<DataGridViewCellEventArgs> handler = onDoubleClick;
            if (handler != null)
                handler(this, e);
        }

        public ViewReservation()
        {
            InitializeComponent();
        }

        public event EventHandler ButtonAddReservationClick;

        protected virtual void OnButtonAddReservationClick()
        {
            EventHandler handler = ButtonAddReservationClick;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void buttonAddReservation_Click(object sender, System.EventArgs e)
        {
            OnButtonAddReservationClick();
        }

        private void dataGridViewVisitors_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OnOnDoubleClick(e);
        }
    }
}
