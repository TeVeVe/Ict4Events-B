using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace ReservationSystem.Views
{
    public partial class ViewVisitors : UserControl
    {
        public ViewVisitors()
        {
            InitializeComponent();
        }

        public event EventHandler ButtonAddVisitorClick;
        public event EventHandler<DataGridViewCellMouseEventArgs> CellModifyVisitorClick;

        protected virtual void OnCellModifyVisitorClick(DataGridViewCellMouseEventArgs e)
        {
            EventHandler<DataGridViewCellMouseEventArgs> handler = CellModifyVisitorClick;
            if (handler != null) handler(this, e);
        }

        protected virtual void OnButtonAddVisitorClick()
        {
            EventHandler handler = ButtonAddVisitorClick;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void buttonAddVisitor_Click(object sender, EventArgs e)
        {
            OnButtonAddVisitorClick();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            OnCheckboxIsOnSiteCheckChanged();
        }

        public event EventHandler CheckboxIsOnSiteCheckChanged;

        protected virtual void OnCheckboxIsOnSiteCheckChanged()
        {
            EventHandler handler = CheckboxIsOnSiteCheckChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void DataGridViewVisitors_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            OnCellModifyVisitorClick(e);
        }

        private void DataGridViewVisitors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
