using System;
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
    }
}
