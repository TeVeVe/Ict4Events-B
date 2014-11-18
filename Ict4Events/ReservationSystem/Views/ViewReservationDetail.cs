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

        public event EventHandler SaveReservationClick;
        public event EventHandler CancelClick;
        public event EventHandler AddEventClick;

        protected virtual void OnAddEventClick()
        {
            EventHandler handler = AddEventClick;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public event EventHandler AddVisitorClick;

        protected virtual void OnAddVisitorClick()
        {
            EventHandler handler = AddVisitorClick;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        protected virtual void OnSaveReservationClick()
        {
            EventHandler handler = SaveReservationClick;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        protected virtual void OnCancelClick()
        {
            EventHandler handler = CancelClick;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void buttonSaveReservation_Click(object sender, EventArgs e)
        {
            OnSaveReservationClick();
        }

        private void buttonAddVisitor_Click(object sender, EventArgs e)
        {
            OnAddVisitorClick();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            OnCancelClick();
        }

        private void ButtonAddEvent_Click(object sender, EventArgs e)
        {
            OnAddEventClick();
        }
    }
}