using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedClasses.Controls.WinForms;
using SharedClasses.Data.Models;
using SharedClasses.Extensions;
using SharedClasses.MVC;

namespace MediaSharingApplication.Controllers
{
    class ControllerAddCategory:ControllerMVC<ViewInputBox>
    {
        public ControllerAddCategory()
        {
            View.buttonSave.Click += buttonSave_Click;
            View.buttonCancel.Click += buttonCancel_Click;
        }

        public override void Activate()
        {
            
        }

        void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void buttonSave_Click(object sender, EventArgs e)
        {
            if (View.textBoxName.Text != null && View.textBoxDescription != null)
            {
                Category cat = new Category();
                cat.Name = View.textBoxName.Text;
                cat.Description = View.textBoxDescription.Text;

                TreeNode parent = Values.SafeGetValue<TreeNode>("parent");
                if (parent != null)
                {
                    cat.ParentCategory = ((Category) parent.Tag).ParentCategory;
                }

                cat.Insert();
            }
        }
    }
}
