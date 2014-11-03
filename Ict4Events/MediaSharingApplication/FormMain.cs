using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using MediaSharingApplication.Controllers;
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

            DataModel.Database = Database.FromSettings();

            // DB Test:
            var product = Product.Select().First();
            Debug.WriteLine(product.Name);
            product.Name = "Test :D";
            product.Update();
        }
    }
}