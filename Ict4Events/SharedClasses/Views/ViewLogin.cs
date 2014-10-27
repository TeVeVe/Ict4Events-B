using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedClasses.Events;

namespace SharedClasses.Views
{
    public partial class ViewLogin : UserControl
    {
        public ViewLogin()
        {
            InitializeComponent();
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

        public event AuthenticateEventHandler Authenticate;

        protected virtual void OnAuthenticate(AuthenticateEventArgs e)
        {
            AuthenticateEventHandler handler = Authenticate;
            if (handler != null) handler(this, e);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            AuthenticateEventArgs authArgs;
            if (!string.IsNullOrWhiteSpace(textBoxRFID.Text))
            {
                // RFID authentication.
                authArgs = new AuthenticateEventArgs(textBoxRFID.Text);
            }
            else
            {
                // Account authentication.
                authArgs = new AuthenticateEventArgs(textBoxUsername.Text, textBoxPassword.Text);
            }

            // Allow authorizers to authenticate the input.
            OnAuthenticate(authArgs);
        }
    }
}
