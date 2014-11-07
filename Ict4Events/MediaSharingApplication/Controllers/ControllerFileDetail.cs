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
        public override void Activate()
        {
            File file = Values.SafeGetValue<File>("File");

            View.nameLabel.Text = file.Name.ToString();
            View.DescriptionLabel.Text = file.Description.ToString();
        }
    }
}
