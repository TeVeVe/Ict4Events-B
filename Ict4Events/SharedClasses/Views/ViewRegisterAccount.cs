using System;
using System.Windows.Forms;

namespace SharedClasses.Views
{
    public partial class ViewRegisterAccount : UserControl
    {
        public ViewRegisterAccount()
        {
            InitializeComponent();
        }

        public event EventHandler<EventArgs> RegisterClick;

        protected virtual void OnRegisterClick()
        {
            EventHandler<EventArgs> handler = RegisterClick;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OnRegisterClick();
        }
    }
}