using System;
using System.Windows.Forms;

namespace SharedClasses.Views
{
    public partial class ViewRegisterAccount : UserControl
    {
        public string Username
        {
            get { return textBoxUsername.Text; }
            set { textBoxUsername.Text = value; }
        }

        public string Password
        {
            get { return textBoxPassword.Text; }
            set { textBoxPassword.Text = value; }
        }

        public bool PasswordIsMatch
        {
            get { return Password == textBoxPasswordCheck.Text; }
        }

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

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            OnRegisterClick();
        }
    }
}