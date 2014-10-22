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
        public ViewMain ViewMain { get; set; }

        public FormMain()
        {
            InitializeComponent();
            ViewMain = new ViewMain();
            panelMainView.ShowInView(ViewMain);
        }
    }
}