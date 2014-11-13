using System;
using System.Windows.Forms;

namespace SharedClasses.Views
{
    public partial class ViewRegisterAccount : UserControl
    {
        public ViewRegisterAccount()
        {
            InitializeComponent();
            Load += (sender, args) => textBoxUsername.Focus();
        }

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

        public event EventHandler RegisterClick;

        protected virtual void OnRegisterClick()
        {
            EventHandler handler = RegisterClick;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        public event EventHandler CancelClick;

        protected virtual void OnCancelClick()
        {
            EventHandler handler = CancelClick;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            OnRegisterClick();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            OnCancelClick();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    buttonCancel.PerformClick();
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}