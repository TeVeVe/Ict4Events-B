using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MediaSharingApplication.Views;
using SharedClasses.Data.Models;
using SharedClasses.Extensions;
using SharedClasses.FTP;
using SharedClasses.MVC;
using File = SharedClasses.Data.Models.File;

namespace MediaSharingApplication.Controllers
{
    internal class ControllerAddFile : ControllerMVC<ViewAddFile>
    {
        private string _filePath;
        private UserAccount _userAccount;

        public ControllerAddFile()
        {
            View.ButtonUploadFile.Click += (sender, args) =>
            {
                var ofd = new OpenFileDialog();
                ofd.Filter = "Media bestanden | *.png; *.jpg; *.gif; *.mp4; *.wmv; *.mp3; *.wav; *.aac";
                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _filePath = ofd.FileName.ToLower();
                    View.TextBoxFilePath.Text = _filePath;
                }
            };

            View.ButtonCancel.Click += (sender, args) => { Close(); };

            View.ButtonSave.Click += (sender, args) =>
            {
                if (!String.IsNullOrEmpty(View.TextBoxDescription.Text) &&
                    !String.IsNullOrEmpty(View.TextBoxFilePath.Text))
                {
                    var selectedNode = Values.SafeGetValue<TreeNode>("selectedNode");
                    IEnumerable<string> directoryNames = FileTransfer.GetDirectoryNames(selectedNode);
                    FileTransfer.UploadFile(_filePath, directoryNames);

                    // Insert file into database.
                    var file = new File();
                    file.Name = Path.GetFileName(_filePath);
                    file.PostTime = DateTime.Now;
                    file.ReportCount = 0;
                    file.CategoryId = (int)selectedNode.Tag;
                    file.Description = View.TextBoxDescription.Text;

                    // TODO: Use user session.
#if DEBUG
                    file.UserAccountId = 1;
#else
                    file.UserAccountId = _userAccount.Id;
#endif
                    file.Insert();
                    Close();
                }

                else
                    MessageBox.Show("Vul alstublieft beide velden in.");
            };
        }

        public override void Activate()
        {
            _userAccount = Values.SafeGetValue<UserAccount>("UserSession");
        }
    }
}