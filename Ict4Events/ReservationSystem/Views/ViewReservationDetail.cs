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
        public event EventHandler ButtonAddEvent;

        protected virtual void OnButtonAddEvent()
        {
            EventHandler handler = ButtonAddEvent;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public event EventHandler ButtonAddVisitorClick;

        protected virtual void OnButtonAddVisitorClick()
        {
            EventHandler handler = ButtonAddVisitorClick;
            if (handler != null)
                handler(this, EventArgs.Empty);
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

        private void buttonSaveReservation_Click(object sender, System.EventArgs e)
        {
            OnButtonSaveReservationClick();
        }

        private void buttonAddVisitor_Click(object sender, EventArgs e)
        {
            OnButtonAddVisitorClick();
        }

        private void buttonAddEvent_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            OnButtonCancelClick();
        }
    }
}
