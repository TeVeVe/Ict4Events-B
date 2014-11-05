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

        public string RFID
        {
            get { return textBoxRFID.Text; }
            set { textBoxRFID.Invoke(new Action(() => textBoxRFID.Text = value)); }
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

        public event EventHandler<AuthenticateEventArgs> Authenticate;

        protected virtual void OnAuthenticate(AuthenticateEventArgs e)
        {
            var handler = Authenticate;
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
            else if (!string.IsNullOrWhiteSpace(textBoxUsername.Text) && !string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                // Account authentication.
                authArgs = new AuthenticateEventArgs(textBoxUsername.Text, textBoxPassword.Text);
            }
            else
            {
                MessageBox.Show("U dient de velden in een van de groepen in te vullen voordat u kunt inloggen.",
                    "Velden zijn leeg", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Allow authorizers to authenticate the input.
            OnAuthenticate(authArgs);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.Enter:
                    buttonOK.PerformClick();
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
