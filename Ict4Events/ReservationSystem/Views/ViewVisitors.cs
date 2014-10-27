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

        public event EventHandler ButtonAddVisitor;

        protected virtual void OnButtonAddVisitor()
        {
            EventHandler handler = ButtonAddVisitor;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void buttonAddVisitor_Click(object sender, EventArgs e)
        {
            OnButtonAddVisitor();
        }
    }
}
