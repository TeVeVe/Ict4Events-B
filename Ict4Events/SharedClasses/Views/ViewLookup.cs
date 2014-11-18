using System;
using System.Windows.Forms;

namespace SharedClasses.Views
{
    public partial class ViewLookup : UserControl
    {
        public ViewLookup()
        {
            InitializeComponent();
        }

        public string Description
        {
            get { return labelDescription.Text; }
            set { labelDescription.Text = value; }
        }

        public event EventHandler SaveClick;
        public event EventHandler CancelClick;

        protected virtual void OnCancelClick()
        {
            EventHandler handler = CancelClick;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public event DataGridViewCellEventHandler CellDoubleClick;

        protected virtual void OnCellDoubleClick(DataGridViewCellEventArgs e)
        {
            DataGridViewCellEventHandler handler = CellDoubleClick;
            if (handler != null)
                handler(this, e);
        }

        protected virtual void OnSaveClick()
        {
            EventHandler handler = SaveClick;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            OnSaveClick();
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OnCellDoubleClick(e);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            OnCancelClick();
        }
    }
}