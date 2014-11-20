using System;
using System.Windows.Forms;

namespace ReservationSystem.Views
{
    public partial class ViewReservation : UserControl
    {
        public ViewReservation()
        {
            InitializeComponent();
        }

        public event EventHandler<DataGridViewCellEventArgs> GridDoubleClick;

        protected virtual void OnGridDoubleClick(DataGridViewCellEventArgs e)
        {
            EventHandler<DataGridViewCellEventArgs> handler = GridDoubleClick;
            if (handler != null)
                handler(this, e);
        }

        public event EventHandler ButtonAddReservationClick;
        public event EventHandler ButtonDeleteReservationClick;

        protected virtual void OnButtonDeleteReservationClick()
        {
            EventHandler handler = ButtonDeleteReservationClick;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        protected virtual void OnButtonAddReservationClick()
        {
            EventHandler handler = ButtonAddReservationClick;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void buttonAddReservation_Click(object sender, EventArgs e)
        {
            OnButtonAddReservationClick();
        }

        private void dataGridViewVisitors_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OnGridDoubleClick(e);
        }

        private void buttonDeleteREservation_Click(object sender, EventArgs e)
        {
            OnButtonDeleteReservationClick();
        }
    }
}