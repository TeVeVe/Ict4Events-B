using System;
using System.Windows.Forms;

namespace SharedClasses.Controls.WinForms
{
    public partial class CategoryFiles : UserControl
    {
        public CategoryFiles()
        {
            InitializeComponent();
        }

        //private void AddFileButton_Click(object sender, EventArgs e)
        //{
        //    var categories = new List<string>();
        //    string filePath = "";

        //    var ofd = new OpenFileDialog();
        //    DialogResult result = ofd.ShowDialog();
        //    if (result == DialogResult.OK)
        //    {
        //        Debug.WriteLine(ofd.FileName);
        //        filePath = ofd.FileName;

        //        categories = GetAllParents(View.)
        //        FileTransfer.UploadFile(filePath, categories);
        //    }
        //}

        private void DownloadButton_Click(object sender, EventArgs e)
        {
        }
    }
}