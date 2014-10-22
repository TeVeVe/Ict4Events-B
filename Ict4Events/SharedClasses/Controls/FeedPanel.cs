using System;
using System.Windows.Forms;
using SharedClasses.Events;

namespace SharedClasses.Controls
{
    public partial class FeedPanel : UserControl
    {
        public FeedPanel()
        {
            InitializeComponent();
        }

        public string PostLabelText
        {
            set { labelYourMessage.Text = value.TrimEnd(':') + ':'; }
        }

        public string PostButtonText
        {
            get { return buttonPost.Text; }
            set
            {
                buttonPost.Text = value;
            }
        }

        public string InputMessage
        {
            get { return textBoxInput.Text; }
            set { textBoxInput.Text = value; }
        }

        public event MessageEventHandler Post;

        protected virtual void OnPost(MessageEventArgs e)
        {
            MessageEventHandler handler = Post;
            if (handler != null) handler(this, e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Enter))
            {
                buttonPost.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            OnPost(new MessageEventArgs(textBoxInput.Text));
            textBoxInput.Clear();
        }
    }
}