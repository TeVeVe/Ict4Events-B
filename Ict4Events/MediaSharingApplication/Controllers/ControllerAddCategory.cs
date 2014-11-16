using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            if (!String.IsNullOrWhiteSpace(View.textBoxName.Text) && !String.IsNullOrWhiteSpace(View.textBoxDescription.Text))
            {
                Debug.WriteLine("{0} - {1}", View.textBoxName.Text, View.textBoxDescription.Text);
                Category cat = new Category();
                cat.Name = View.textBoxName.Text;
                cat.Description = View.textBoxDescription.Text;
                cat.ParentCategory = Values.SafeGetValue<int>("Parent");
                TreeNode parent = Values.SafeGetValue<TreeNode>("parent");
                if (parent != null)
                {
                    cat.ParentCategory = ((Category) parent.Tag).ParentCategory;
                }

                cat.Insert();
                this.Close();
            }

            else
            {
                MessageBox.Show("Vul Alstublieft alle velden in.");
            }
        }
    }
}
