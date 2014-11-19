using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharedClasses.Controls.WinForms
{
    public partial class CommentInput : UserControl
    {
        public CommentInput()
        {
            InitializeComponent();
        }

        private void CommentTextBox_TextChanged(object sender, EventArgs e)
        {
            int textLength = CommentTextBox.Text.Length;
            LabelTextLength.Text = String.Format("{0}/140 tekens", textLength);
            if (textLength <= 140)
            {
                LabelTextLength.ForeColor = Color.Black;
                SendCommentButton.Enabled = true;
            }

            else
            {
                LabelTextLength.ForeColor = Color.Red;
                SendCommentButton.Enabled = false;
            }
        }
    }
}
