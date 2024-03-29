﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaSharingApplication.Views;
using SharedClasses.Controls.WinForms;
using SharedClasses.Data.Models;
using SharedClasses.Extensions;
using SharedClasses.FTP;
using SharedClasses.MVC;
using File = SharedClasses.Data.Models.File;

namespace MediaSharingApplication.Controllers
{
    internal class ControllerFileDetail : ControllerMVC<ViewFileDetail>
    {
        private File _file;
        private UserAccount _userAccount;

        public ControllerFileDetail()
        {
            View.BackButtonClick += ViewOnBackButtonClick;
            View.DownloadButtonClick += ViewOnDownloadButtonClick;
            View.ButtonPlus.Click += ButtonPlus_Click;
            View.ButtonMinus.Click += ButtonMinus_Click;
            View.Comment.SendCommentButton.Click += SendCommentButton_Click;
        }

        public CancellationTokenSource DownloadFileTokenSource { get; set; }

        public override void Activate()
        {
            // Reset.
            View.FilePicture.ImageLocation = "Icons\\spinner.gif";
            View.FilePicture.SizeMode = PictureBoxSizeMode.CenterImage;
            View.FilePicture.Visible = false;

            _userAccount = ((FormMain)MainForm).UserSession;
            _file = Values.SafeGetValue<File>("File");
            string ext = Path.GetExtension(_file.Name);

            View.TextBoxTitel.Text = _file.Name;
            View.TextBoxOmschrijving.Text = _file.Description;
            View.LabelDescription.Text = _file.Description;

            if (new[]
            {
                ".png", ".jpg", ".gif"
            }.Contains(ext))
            {
                View.FilePicture.Visible = true;
                DownloadPhoto();
            }

            FillCommentSection();
            CalculateScore();
        }

        private void DownloadPhoto()
        {
            var pt = Values.SafeGetValue<PanelTile>("fileName");
            IEnumerable<string> directoryList = null;

            string fileName = ((File)pt.Tag).Name;
            string filePath = null;
            directoryList = FileTransfer.GetDirectoryNames(Values.SafeGetValue<TreeNode>("TreeNode"));

            foreach (string d in directoryList)
                filePath += d + "/";

            filePath += fileName;

            DownloadFileTokenSource = new CancellationTokenSource();
            Task.Factory.StartNew(() =>
            {
                bool success = false;
                string path = null;
                Task<string> downloadTask =
                    Task.Factory.StartNew(() => path = FileTransfer.DownloadFileTemp(filePath, out success));

                while (!downloadTask.IsCompleted && !DownloadFileTokenSource.IsCancellationRequested)
                {
                    Task.Delay(100).Wait();
                    if (DownloadFileTokenSource.IsCancellationRequested)
                        return;
                }

                if (success)
                {
                    View.FilePicture.InvokeSafe(c =>
                    {
                        View.FilePicture.SizeMode = PictureBoxSizeMode.Zoom;
                        View.FilePicture.ImageLocation = path;
                    });
                }
            }, DownloadFileTokenSource.Token);
        }

        private void ButtonMinus_Click(object sender, EventArgs e)
        {
            Vote currentVote =
                Vote.Select(String.Format("UserAccountId = {0} AND FILEID = {1} ", _userAccount.Id, _file.Id))
                    .FirstOrDefault();

            if (currentVote != null)
            {
                if (currentVote.Type)
                {
                    currentVote.Type = false;
                    currentVote.Update();
                    View.LabelScore.ForeColor = Color.Red;
                    CalculateScore();
                }
            }

            else
            {
                var vote = new Vote();
                vote.FileId = _file.Id;
                vote.UserAccountId = _userAccount.Id;
                vote.Type = false;

                vote.Insert();

                View.LabelScore.ForeColor = Color.Red;
                CalculateScore();
            }
        }

        private void ButtonPlus_Click(object sender, EventArgs e)
        {
            Vote currentVote =
                Vote.Select(String.Format("UserAccountId = {0} AND FILEID = {1} ", _userAccount.Id, _file.Id))
                    .FirstOrDefault();

            if (currentVote != null)
            {
                if (!currentVote.Type)
                {
                    currentVote.Type = true;
                    currentVote.Update();
                    CalculateScore();
                }
            }

            else
            {
                var vote = new Vote();
                vote.FileId = _file.Id;
                vote.UserAccountId = _userAccount.Id;
                vote.Type = true;

                vote.Insert();
                CalculateScore();
            }
        }

        private void SendCommentButton_Click(object sender, EventArgs e)
        {
            if (View.Comment.CommentTextBox.Text.Length >= 140)
                MessageBox.Show("Vul alstublieft niet meer dan 140 tekens in.");

            else
            {
                var comment = new Comment();

                comment.Content = View.Comment.CommentTextBox.Text;
                comment.ParentComment = null;
                comment.FileId = (Values.SafeGetValue<File>("File")).Id;
                comment.UserAccountId = _userAccount.Id;
                comment.PostTime = DateTime.Now;

                comment.Insert();
                FillCommentSection();
            }
        }

        private void ViewOnDownloadButtonClick(object sender, EventArgs eventArgs)
        {
            var pt = Values.SafeGetValue<PanelTile>("fileName");
            IEnumerable<string> directoryList = null;

            if (Values.SafeGetValue<TreeNode>("TreeNode") != null && pt != null && pt.Tag != null)
            {
                string fileName = ((File)pt.Tag).Name;
                string filePath = null;
                directoryList = FileTransfer.GetDirectoryNames(Values.SafeGetValue<TreeNode>("TreeNode"));

                foreach (string d in directoryList)
                    filePath += d + "/";

                filePath += fileName;

                FileTransfer.DownloadFile(filePath);
            }
        }

        private void FillCommentSection()
        {
            if (_file.Id != 0)
            {
                View.CommentSection.FlowLayoutPanel.Controls.Clear();
                IEnumerable<Comment> comments = Comment.Select("FILEID =" + _file.Id);

                foreach (Comment comment in comments)
                {
                    Debug.WriteLine(comment.Content);
                    var cc = new CommentControl();
                    cc.LabelNaam.Text =
                        UserAccount.Select("UserAccountID = " + comment.UserAccountId).FirstOrDefault().Username;
                    cc.LabelContent.Text = comment.Content;

                    View.CommentSection.Add(cc);
                }
            }
        }

        private void CalculateScore()
        {
            Vote vote =
                Vote.Select(String.Format("USERACCOUNTID = {0} AND FILEID = {1}", _userAccount.Id.ToSqlFormat(),
                    _file.Id)).FirstOrDefault();
            int positiveVotes = Vote.Count(String.Format("FILEID = {0} AND VOTETYPE = 'Y'", _file.Id.ToSqlFormat()));
            int negativeVotes = Vote.Count(String.Format("FILEID = {0} AND VOTETYPE = 'N'", _file.Id.ToSqlFormat()));

            Debug.WriteLine("{0} - {1}", positiveVotes, negativeVotes);

            if (vote != null)
            {
                bool currentVote = vote.Type;
                if (currentVote)
                    View.LabelScore.ForeColor = Color.Green;

                else
                    View.LabelScore.ForeColor = Color.Red;
            }


            View.LabelScore.Text = (positiveVotes - negativeVotes).ToString();
        }

        private void ViewOnBackButtonClick(object sender, EventArgs eventArgs)
        {
            if (DownloadFileTokenSource != null)
                DownloadFileTokenSource.Cancel();

            MainForm.Open<ControllerMain>();
        }
    }
}