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
        public event EventHandler<EventArgs> ButtonAddRowClick;
        public event EventHandler<EventArgs> ButtonDeleteRowClick;

        protected virtual void OnButtonDeleteRowClick()
        {
            EventHandler<EventArgs> handler = ButtonDeleteRowClick;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        protected virtual void OnBottonReserveesAdd(EventArgs e)
        {
            EventHandler<EventArgs> handler = ButtonAddRowClick;
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
        private void buttonAddVisitor_Click(object sender, EventArgs e)
        {
            OnBottonReserveesAdd(e);
        }

        private void DataGridViewReservees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OnDataGridViewReserveesDoubleClick(e);
        }

        private void buttonDeleteRow_Click(object sender, EventArgs e)
        {
            OnButtonDeleteRowClick();
        }
    }
}
