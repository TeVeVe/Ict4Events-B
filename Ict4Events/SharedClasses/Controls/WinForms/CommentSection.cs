using System;
using System.Windows.Forms;

namespace SharedClasses.Controls.WinForms
{
    public partial class CommentSection : UserControl
    {
        public CommentSection()
        {
            InitializeComponent();
        }

        public void Add(CommentControl commentControl)
        {
            commentControl.Width = FlowLayoutPanel.Width - 25;
            FlowLayoutPanel.Controls.Add(commentControl);
        }

        private void CommentSection_SizeChanged(object sender, EventArgs e)
        {
        }
    }
}