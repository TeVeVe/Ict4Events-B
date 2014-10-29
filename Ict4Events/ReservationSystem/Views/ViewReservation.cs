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
    }
}
