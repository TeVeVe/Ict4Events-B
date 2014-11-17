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
    }
}