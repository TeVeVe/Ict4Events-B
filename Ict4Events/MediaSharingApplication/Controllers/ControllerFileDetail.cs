using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            View.fileComment1.SendCommentButton.Click += SendCommentButton_Click;
        }

        void SendCommentButton_Click(object sender, EventArgs e)
        {
            Comment c = new Comment();
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

        private void ViewOnBackButtonClick(object sender, EventArgs eventArgs)
        {
            MainForm.Open<ControllerMain>();
        }

        public override void Activate()
        {
            File file = Values.SafeGetValue<File>("File");

            View.TextBoxTitel.Text = file.Name;
            View.TextBoxOmschrijving.Text = file.Description;
        }
    }
}
