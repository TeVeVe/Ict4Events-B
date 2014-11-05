using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using SharedClasses;
using SharedClasses.Data.Models;
using SharedClasses.MVC;

namespace MediaSharingApplication
{
    public partial class FormMain : FormMVC
    {
        public FormMain()
        {
            InitializeComponent();


            Shown += (sender, args) =>
            {
                var categories = new List<string>();
                string filePath = "";

                var ofd = new OpenFileDialog();
                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Debug.WriteLine(ofd.FileName);
                    filePath = ofd.FileName;

                    categories.AddRange(new List<string> {"Media", "Muziek"});
                    FileTransfer.UploadFile(filePath, categories);
                }
            };
        }

        public UserAccount UserSession { get; set; }
    }
}