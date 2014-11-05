using System;
using System.Diagnostics;
using System.Windows.Forms;
using MediaSharingApplication.Controllers;
using SharedClasses.Data;
using MediaSharingApplication.Controllers;
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

            MarkAsMain<ControllerMain>();
            MarkAsMain<ControllerLogin>();

            DataModel.Database = Database.FromSettings();

            // DB Test:
            var products = Product.Select();
            foreach (var product in products)
            {
                Debug.WriteLine(product.Name);
            }
        }
    }
}