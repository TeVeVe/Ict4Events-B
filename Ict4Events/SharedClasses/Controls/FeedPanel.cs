using System.Windows.Forms;
using SharedClasses.Events;

namespace SharedClasses.Controls
{
    public partial class FeedPanel : UserControl
    {
        public event MessageEventHandler Post;

        protected virtual void OnPost(MessageEventArgs e)
        {
            MessageEventHandler handler = Post;
            if (handler != null) handler(this, e);
        }

        public string LabelMessage
        {
            set { labelYourMessage.Text = value.TrimEnd(':') + ':'; }
        }

        public string InputMessage
        {
            get { return textBoxInput.Text; }
            set { textBoxInput.Text = value; }
        }

        public FeedPanel()
        {
            InitializeComponent();
        }

        private void buttonPost_Click(object sender, System.EventArgs e)
        {
            OnPost(new MessageEventArgs(textBoxInput.Text));
            textBoxInput.Clear();
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
    }
}
