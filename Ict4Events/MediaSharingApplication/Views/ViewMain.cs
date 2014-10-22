using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharedClasses.Controls;
using SharedClasses.Extensions;

namespace MediaSharingApplication.Views
{
    public partial class ViewMain : UserControl
    {
        public CategoryTreeView CategoryTreeView { get; set; }
        public FeedPanel FeedPanel { get; set; }

        public ViewMain()
        {
            InitializeComponent();

            // Initialize views.
            CategoryTreeView = new CategoryTreeView();

            FeedPanel = new FeedPanel();
            FeedPanel.PostLabelText = "Uw bericht";
            FeedPanel.PostButtonText = "Plaats bericht";

            // Display first screen
            this.ShowInView(CategoryTreeView, DockStyle.Left);
            this.ShowInView(FeedPanel, DockStyle.Right);
        }
    }
}
