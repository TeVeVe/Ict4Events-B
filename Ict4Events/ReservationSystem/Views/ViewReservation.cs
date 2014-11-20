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
        public event EventHandler Check_Clicked;

        protected virtual void OnCheckClicked()
        {
            EventHandler handler = Check_Clicked;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        protected virtual void OnGridDoubleClick(DataGridViewCellEventArgs e)
        {
            EventHandler<DataGridViewCellEventArgs> handler = GridDoubleClick;
            if (handler != null)
                handler(this, e);
        }

        public event EventHandler ButtonAddReservationClick;
        public event EventHandler ButtonDeleteReservationClick;
        public event EventHandler CheckboxChecked;

        protected virtual void OnCheckboxChecked()
        {
            EventHandler handler = CheckboxChecked;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

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

        private void DataGridViewVisitors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            OnCheckboxChecked();
        }
    }
}