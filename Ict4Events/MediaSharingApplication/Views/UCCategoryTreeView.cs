using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaSharingApplication.Views
{
    public partial class UCCategoryTreeView : UserControl
    {
        public Action AddCategoryAction { get; set; }

        public string SearchFilter
        {
            get { return textBoxSearchFilter.Text; }
            set
            {
                if (value == textBoxSearchFilter.Text) return;
                treeViewCategories.Nodes.Cast<TreeNode>().SelectMany<TreeNode>(n => n.Nodes);
            }
        }

        public UCCategoryTreeView()
        {
            InitializeComponent();
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            if (AddCategoryAction == null) return;
            AddCategoryAction();
        }
    }
}
