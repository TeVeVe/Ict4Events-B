using System;
using System.Windows.Forms;

namespace ReservationSystem.Views
{
    public partial class ViewEvents : UserControl
    {
        public event EventHandler ButtonSave;
        public event EventHandler ButtonDeleteEvent;

        protected virtual void OnButtonDeleteEvent()
        {
            EventHandler handler = ButtonDeleteEvent;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        protected virtual void OnButtonSave()
        {
            EventHandler handler = ButtonSave;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public ViewEvents()
        {
            InitializeComponent();
        }

        private void buttonDeleteEvent_Click(object sender, EventArgs e)
        {
            OnButtonDeleteEvent();
        }

        private void buttonAddEvent_Click(object sender, EventArgs e)
        {
            OnButtonSave();
        }

        private void buttonDelName_Click(object sender, EventArgs e)
        {
            TextBoxEventName.Clear();
        }
    }
}
