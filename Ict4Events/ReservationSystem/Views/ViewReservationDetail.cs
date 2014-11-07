using System;
using System.Windows.Forms;

namespace ReservationSystem.Views
{
    public partial class ViewReservationDetail : UserControl
    {
        public ViewReservationDetail()
        {
            InitializeComponent();
        }

        public event EventHandler ButtonSaveReservationClick;
        public event EventHandler ButtonCancelClick;
        public event EventHandler ButtonAddProductClick;
        public event EventHandler ButtonAddVisitorClick;

        protected virtual void OnButtonAddVisitorClick()
        {
            EventHandler handler = ButtonAddVisitorClick;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        protected virtual void OnButtonAddProductClick()
        {
            EventHandler handler = ButtonAddProductClick;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnButtonSaveReservationClick()
        {
            EventHandler handler = ButtonSaveReservationClick;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnButtonCancelClick()
        {
            EventHandler handler = ButtonCancelClick;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            OnButtonAddProductClick();
        }

        private void buttonSaveReservation_Click(object sender, System.EventArgs e)
        {
            OnButtonSaveReservationClick();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            OnButtonCancelClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnButtonAddVisitorClick();
        }
    }
}
