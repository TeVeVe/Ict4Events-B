using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedClasses.Data.Models;

namespace ReservationSystem.Views
{
    public partial class ViewVisitorDetail : UserControl
    {
        public event EventHandler ButtonDeleteRentalClick;

        protected virtual void OnButtonDeleteRentalClick()
        {
            EventHandler handler = ButtonDeleteRentalClick;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public ViewVisitorDetail()
        {
            InitializeComponent();
        }

        private void buttonDeleteRental_Click(object sender, EventArgs e)
        {
            OnButtonDeleteRentalClick();
        }
    }
}
