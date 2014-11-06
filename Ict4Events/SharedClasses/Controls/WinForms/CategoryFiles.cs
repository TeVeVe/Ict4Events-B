using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using SharedClasses.FTP;

namespace SharedClasses.Controls.WinForms
{
    public partial class CategoryFiles : UserControl
    {
        public CategoryFiles()
        {
            InitializeComponent();
        }

        private void AddFileButton_Click(object sender, EventArgs e)
        {
            var categories = new List<string>();
            string filePath = "";

            var ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                Debug.WriteLine(ofd.FileName);
                filePath = ofd.FileName;

                categories.AddRange(new List<string> {"testmap1", "testmap2"});
                FileTransfer.UploadFile(filePath, categories);
            }
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            string filePath = String.Format("ftp://{0}/Media/Bestanden/bookmarks.html", Properties.Settings.Default.FTP_Server);
            FileTransfer.DownloadFile(filePath);
        }
    }
}