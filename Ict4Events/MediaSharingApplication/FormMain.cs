using System;
using System.Windows.Forms;
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
            // Display first screen
            panelMainView.ShowInView(new UCTreeView(), DockStyle.Left);
        }
    }
}