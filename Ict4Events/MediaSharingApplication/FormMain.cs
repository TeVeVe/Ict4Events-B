using System;
using System.Windows.Forms;
using SharedClasses.Controls;
using SharedClasses.Extensions;
using SharedClasses.Views;

namespace MediaSharingApplication
{
    public partial class FormMain : Form
    {
        public CategoryTreeView CategoryTreeView { get; set; }
        public FeedPanel FeedPanel { get; set; }

        public FormMain()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            // Initialize views.
            CategoryTreeView = new CategoryTreeView();
            
            FeedPanel = new FeedPanel();
            FeedPanel.PostLabelText = "Uw bericht";
            FeedPanel.PostButtonText = "Plaats bericht";

            // Display first screen
            panelMainView.ShowInView(CategoryTreeView, DockStyle.Left);
            panelMainView.ShowInView(FeedPanel, DockStyle.Right);
        }
    }
}