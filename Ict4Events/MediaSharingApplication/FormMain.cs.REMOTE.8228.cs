using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using MediaSharingApplication.Controllers;
using SharedClasses;
using SharedClasses.Data;
using SharedClasses.Data.Models;
using SharedClasses.MVC;

namespace MediaSharingApplication
{
    public partial class FormMain : FormMVC
    {
        public FormMain()
        {
            InitializeComponent();
            MarkAsMain<ControllerLogin>();

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

                    categories.AddRange(new List<string> { "Media", "Muziek" });
                    FileTransfer.UploadFile(filePath, categories);
                }
            };
        }
    }
}