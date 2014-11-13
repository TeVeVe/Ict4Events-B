using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaSharingApplication.Views;
using SharedClasses.Data.Models;
using SharedClasses.Extensions;
using SharedClasses.MVC;

namespace MediaSharingApplication.Controllers
{
    class ControllerFileDetail:ControllerMVC<ViewFileDetail>
    {
        public ControllerFileDetail()
        {
            View.BackButtonClick += ViewOnBackButtonClick;
            View.DownloadButtonClick += ViewOnDownloadButtonClick;
        }

        private void ViewOnDownloadButtonClick(object sender, EventArgs eventArgs)
        {
            // TODO: Download the file from FTP.
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
