using System;
using System.Drawing;
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
            get { return labelYourMessage.Text; }
            set { labelYourMessage.Text = value.TrimEnd(':') + ':'; }
        }

        public string PostButtonText
        {
            get { return buttonPost.Text; }
            set { buttonPost.Text = value; }
        }

        public string InputMessage
        {
            get { return textBoxInput.Text; }
            set { textBoxInput.Text = value; }
        }

        public event MessageEventHandler Post;
        public event EventHandler PostDoubleClicked;

        protected virtual void OnPostDoubleClicked(object sender)
        {
            EventHandler handler = PostDoubleClicked;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnPost(MessageEventArgs e)
        {
            MessageEventHandler handler = Post;
            if (handler != null) handler(this, e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Control | Keys.Enter):
                    buttonPost.PerformClick();
                    return true;
                    // Apparently this is needed for using Ctrl+A on the FeedPanel. Otherwise Windows gives a *ding* sound.
                case (Keys.Control | Keys.A):
                    textBoxInput.Focus();
                    textBoxInput.SelectAll();
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            OnPost(new MessageEventArgs(textBoxInput.Text));

#if DEBUG_NODB
            // Allow adding of new posts without database.
            Add(null, textBoxInput.Text);
#endif
            textBoxInput.Clear();
        }

        public void Add(Image image, string message)
        {
            // Add a new message.
            var newPanel = new FeedPostPanel
            {
                Content = message,
                Image = image
            };
            newPanel.DoubleClick += (sender, args) => OnPostDoubleClicked(sender);
            flowLayoutPanelFeedPosts.Controls.Add(newPanel);

            // Reapply styling.
            flowLayoutPanelFeedPosts.Controls[0].Dock = DockStyle.None;
            flowLayoutPanelFeedPosts.Controls[0].Width = flowLayoutPanelFeedPosts.DisplayRectangle.Width -
                                                         flowLayoutPanelFeedPosts.Controls[0].Margin.Horizontal;

            for (int i = 1; i < flowLayoutPanelFeedPosts.Controls.Count; i++)
                flowLayoutPanelFeedPosts.Controls[i].Dock = DockStyle.Top;
        }
    }
}