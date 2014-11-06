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

        public event EventHandler ButtonCancelClick;
        public event EventHandler ButtonSaveClick;

        protected virtual void OnButtonCancelClick()
        {
            EventHandler handler = ButtonCancelClick;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnButtonSaveClick()
        {
            EventHandler handler = ButtonSaveClick;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            OnButtonCancelClick();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            OnButtonSaveClick();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}