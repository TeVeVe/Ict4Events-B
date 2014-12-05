using System;
using System.Windows.Forms;

namespace ReservationSystem.Views
{
    public partial class ViewVisitorDetail : UserControl
    {
        public ViewVisitorDetail()
        {
            InitializeComponent();
        }

        public event EventHandler ButtonDeleteRentalClick;

        protected virtual void OnButtonDeleteRentalClick()
        {
            EventHandler handler = ButtonDeleteRentalClick;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void buttonDeleteRental_Click(object sender, EventArgs e)
        {
            OnButtonDeleteRentalClick();
        }
    }
}