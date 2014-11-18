using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using MediaSharingApplication.Views;
using SharedClasses.Controls.WinForms;
using SharedClasses.Data.Models;
using SharedClasses.Extensions;
using SharedClasses.FTP;
using SharedClasses.MVC;

namespace MediaSharingApplication.Controllers
{
    class ControllerFileDetail:ControllerMVC<ViewFileDetail>
    {
        public ControllerFileDetail()
        {
            View.BackButtonClick += ViewOnBackButtonClick;
            View.DownloadButtonClick += ViewOnDownloadButtonClick;
            View.FileComment.SendCommentButton.Click += SendCommentButton_Click;
            View.FileComment.CommentTextBox.TextChanged += (sender, args) =>
            {
                int textLength = View.FileComment.CommentTextBox.Text.Length;
                View.FileComment.LabelTextLength.Text = String.Format("{0}/140 tekens", textLength);
                if (textLength <= 140)
                {
                    View.FileComment.LabelTextLength.ForeColor = Color.Black;
                    View.FileComment.SendCommentButton.Enabled = true;
                }

                else
                {
                    View.FileComment.LabelTextLength.ForeColor = Color.Red;
                    View.FileComment.SendCommentButton.Enabled = false;
                }
            };
        }

        public override void Activate()
        {
            File file = Values.SafeGetValue<File>("File");

            View.TextBoxTitel.Text = file.Name;
            View.TextBoxOmschrijving.Text = file.Description;
            FillCommentSection();

        }

        void SendCommentButton_Click(object sender, EventArgs e)
        {
            if (View.FileComment.CommentTextBox.Text.Length >= 140)
            {
                MessageBox.Show("Vul alstublieft niet meer dan 140 karakters in.");
            }

            else
            {
                Comment comment = new Comment();
                int accountId = ((FormMain)MainForm).UserSession;

                comment.Content = View.FileComment.CommentTextBox.Text;
                comment.ParentComment = null;
                comment.FileId = (Values.SafeGetValue<File>("File")).Id;
                comment.UserAccountId = accountId;
                comment.PostTime = DateTime.Now;

                comment.Insert();
                FillCommentSection();
            }
        }

        private void ViewOnDownloadButtonClick(object sender, EventArgs eventArgs)
        {
            PanelTile pt = Values.SafeGetValue<PanelTile>("fileName");
            IEnumerable<string> directoryList = null;

            if (Values.SafeGetValue<TreeNode>("TreeNode") != null && pt != null && pt.Tag != null)
            {
                string fileName = ((File) pt.Tag).Name;
                string filePath = null;
                directoryList = FileTransfer.GetDirectoryNames(Values.SafeGetValue<TreeNode>("TreeNode"));

                foreach (var d in directoryList)
                {
                    filePath += d + "/";
                }

                filePath += fileName;

                FileTransfer.DownloadFile(filePath);
            }

        }

        private void FillCommentSection()
        {
            File file = Values.SafeGetValue<File>("File");

            if (file.Id != null)
            {
                View.CommentSection.FlowLayoutPanel.Controls.Clear();
                IEnumerable<Comment> comments = Comment.Select("FILEID =" + file.Id);

                foreach (var comment in comments)
                {
                    Debug.WriteLine(comment.Content);
                    FileComment fc = new FileComment();
                    fc.LabelNaam.Text = UserAccount.Select("UserAccountID = " + comment.UserAccountId).FirstOrDefault().Username;
                    fc.LabelContent.Text = comment.Content;

                    View.CommentSection.Add(fc);
                }
            }
        }

        private void ViewOnBackButtonClick(object sender, EventArgs eventArgs)
        {
            MainForm.Open<ControllerMain>();
        }
    }
}
