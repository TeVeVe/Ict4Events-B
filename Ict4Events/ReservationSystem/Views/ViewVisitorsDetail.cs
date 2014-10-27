using System;
using System.Windows.Forms;

namespace ReservationSystem.Views
{
    public partial class ViewVisitorsDetail : UserControl
    {
        public ViewVisitorsDetail()
        {
            InitializeComponent();
        }

        public event EventHandler ButtonCancel;
        public event EventHandler ButtonSave;

        protected virtual void OnButtonCancel()
        {
            EventHandler handler = ButtonCancel;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnButtonSave()
        {
            EventHandler handler = ButtonSave;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            OnButtonCancel();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            OnButtonSave();
        }
    }
}