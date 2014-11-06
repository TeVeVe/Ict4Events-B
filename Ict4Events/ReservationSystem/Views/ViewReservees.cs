using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReservationSystem.Views
{
    public partial class ViewReservees : UserControl
    {
        public event EventHandler<DataGridViewCellEventArgs> DataGridViewReserveesDoubleClick;
        public event EventHandler<EventArgs> ButtonReserveesAdd;

        protected virtual void OnBottonReserveesAdd(EventArgs e)
        {
            EventHandler<EventArgs> handler = ButtonReserveesAdd;
            if (handler != null) handler(this, e);
        }


        protected virtual void OnDataGridViewReserveesDoubleClick(DataGridViewCellEventArgs e)
        {
            EventHandler<DataGridViewCellEventArgs> handler = DataGridViewReserveesDoubleClick;
            if (handler != null) handler(this, e);
        }

        public ViewReservees()
        {
            InitializeComponent();

        }

        private void DataGridViewReservees_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OnDataGridViewReserveesDoubleClick(e);
        }

        private void buttonAddVisitor_Click(object sender, EventArgs e)
        {
            OnBottonReserveesAdd(e);
        }
    }
}
