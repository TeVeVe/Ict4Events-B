using System;
using System.Windows.Forms;
using MediaSharingApplication.Views;
using SharedClasses.Controls;
using SharedClasses.Extensions;
using SharedClasses.Views;

namespace MediaSharingApplication
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            panelMainView.ShowInView(new ViewMain());
        }
    }
}