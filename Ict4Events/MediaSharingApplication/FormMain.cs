using System;
using System.Windows.Forms;
using MediaSharingApplication.Views;
using SharedClasses.Extensions;

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
            // Display first screen
            panelMainView.ShowInView(new UCCategoryTreeView(), DockStyle.Left);
        }
    }
}