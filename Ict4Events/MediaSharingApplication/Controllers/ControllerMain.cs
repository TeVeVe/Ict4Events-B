using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using MediaSharingApplication.Views;
using SharedClasses.Controls.WinForms;
using SharedClasses.Data;
using SharedClasses.Extensions;
using SharedClasses.FTP;
using SharedClasses.MVC;
using File = SharedClasses.Data.Models.File;

namespace MediaSharingApplication.Controllers
{
    public class ControllerMain : ControllerMVC<ViewMain>
    {
        private ResourceManager _rm = new ResourceManager("Icons", Assembly.GetExecutingAssembly());

        public ControllerMain()
        {
            View.CategoryTreeView.NodeClick += CategoryTreeView_NodeClick;
            View.CategoryFiles.AddFileButton.Click += AddFileButton_Click;

            // Fill contextmenu of category treeview.
            View.CategoryTreeView.TreeViewContextMenu.Opening += (sender, args) =>
            {
                if (View.CategoryTreeView.SelectedNode == null)
                {
                    if (View.CategoryTreeView.TreeViewContextMenu.Items["ContextMenuNodeDelete"] != null)
                        View.CategoryTreeView.TreeViewContextMenu.Items["ContextMenuNodeDelete"].Visible = false;

                    if (View.CategoryTreeView.TreeViewContextMenu.Items["ContextMenuNodeEdit"] != null)
                        View.CategoryTreeView.TreeViewContextMenu.Items["ContextMenuNodeEdit"].Visible = false;

                    if (View.CategoryTreeView.TreeViewContextMenu.Items["ContextMenuNodeAdd"] != null)
                        View.CategoryTreeView.TreeViewContextMenu.Items["ContextMenuNodeAdd"].Visible = false;
                }
                else
                {
                    if (View.CategoryTreeView.TreeViewContextMenu.Items["ContextMenuNodeDelete"] != null)
                        View.CategoryTreeView.TreeViewContextMenu.Items["ContextMenuNodeDelete"].Visible = false;

                    if (View.CategoryTreeView.TreeViewContextMenu.Items["ContextMenuNodeEdit"] != null)
                        View.CategoryTreeView.TreeViewContextMenu.Items["ContextMenuNodeEdit"].Visible = false;

                    if (View.CategoryTreeView.TreeViewContextMenu.Items["ContextMenuNodeAdd"] != null)
                        View.CategoryTreeView.TreeViewContextMenu.Items["ContextMenuNodeAdd"].Visible = true;
                }
            };

            var addToolStripButton = new ToolStripMenuItem("Toevoegen") {Name = "ContextMenuNodeAddSub"};
            var addSubCategoryToolStripButton = new ToolStripMenuItem("Subcategorie")
            {
                Width = TextRenderer.MeasureText("Subcategorie", addToolStripButton.Font).Width
            };
            var addCategoryToolStripButton = new ToolStripMenuItem("Categorie");
            var editToolStripButton = new ToolStripMenuItem("Wijzigen") { Name = "ContextMenuNodeEdit" };
            var deleteToolStripButton = new ToolStripMenuItem("Verwijderen") {Name = "ContextMenuNodeDelete"};
            

            addCategoryToolStripButton.Click += (sender, args) =>
            {
                MainForm.PopupController<ControllerAddCategory>();
                CreateNodes();
            };

            addSubCategoryToolStripButton.Click += (sender, args) =>
            {
                if (View.CategoryTreeView.SelectedNode != null)
                {
                    MainForm.PopupController<ControllerAddCategory>(new KeyValuePair<string, object>("Parent",
                        View.CategoryTreeView.SelectedNode.Tag));
                    CreateNodes();
                }

                else
                {
                    MessageBox.Show("Selecteer alstublieft een categorie als u een subcategorie toe wilt voegen.");
                }
            };

            View.CategoryTreeView.TreeViewContextMenu.Items.Add(addToolStripButton);
            addToolStripButton.DropDownItems.Add(addCategoryToolStripButton);
            addToolStripButton.DropDownItems.Add(addSubCategoryToolStripButton);
            View.CategoryTreeView.TreeViewContextMenu.Items.Add(editToolStripButton);
            View.CategoryTreeView.TreeViewContextMenu.Items.Add(deleteToolStripButton);
        }

        public override void Activate()
        {
            CreateNodes();
        }

        private void AddFileButton_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = View.CategoryTreeView.SelectedNode;

            if (View.CategoryTreeView.SelectedNode == null)
            {
                MessageBox.Show("Selecteer een categorie om een bestand toe te kunnen voegen.");
                return;
            }

            MainForm.PopupController<ControllerAddFile>(new KeyValuePair<string, object>("selectedNode", selectedNode));

            FillFileFlowPanel((int)selectedNode.Tag);
        }

        private void CategoryTreeView_NodeClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FillFileFlowPanel((int) e.Node.Tag);
        }

        private void pt_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(((PictureBox) sender).Parent.Tag);
            
            MainForm.Open<ControllerFileDetail>(
                new KeyValuePair<string, object>("File", ((PictureBox) sender).Parent.Tag),
                new KeyValuePair<string, object>("TreeNode", View.CategoryTreeView.SelectedNode),
                new KeyValuePair<string, object>("fileName", ((PictureBox) sender).Parent));
        }

        private string setFileImage(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            Debug.WriteLine(ext);

            if (new[] {".png", ".jpg", ".gif"}.Contains(ext))
            {
                return "Icons\\camera.png";
            }

            if (new[] {".avi", ".mkv", ".wmv"}.Contains(ext))
            {
                return "Icons\\music.png";
            }

            if (new[] {".mp3", ".aac", ".ac3"}.Contains(ext))
            {
                return "Icons\\wmp.png";
            }

            return "Icons\\writing.png";
        }

        private void CreateNodes()
        {
            TreeView treeView = View.CategoryTreeView.treeViewCategories;

            DataTable categories = DataModel.Database.ExecuteCursorProcedure("PROC_ORDEREDNODES");

            var rows = new DataRow[categories.Rows.Count];
            categories.Rows.CopyTo(rows, 0);

            treeView.Nodes.Clear();

            FillTreeView(rows, treeView);
        }

        private void FillTreeView(DataRow[] rows, TreeView treeView)
        {
            TreeNode root = null;
            TreeNode parent = null;
            TreeNode node = null;
            TreeNode prevNode = null;

            int level = 1;
            int prevLevel = 1;

            foreach (DataRow dr in rows)
            {
                prevLevel = level;
                level = (int) dr["LEVEL"];

                if (level == 1)
                {
                    root = new TreeNode();
                    root.Text = (string) dr["NAME"];
                    root.ToolTipText = (string) dr["DESCRIPTION"];
                    root.Tag = (int) dr["CATEGORYID"];

                    treeView.Nodes.Add(root);
                    prevNode = root;
                }
                else if (level > 1 && level > prevLevel)
                {
                    parent = prevNode;

                    node = new TreeNode();
                    node.Text = (string) dr["NAME"];
                    node.ToolTipText = (string) dr["DESCRIPTION"];
                    node.Tag = (int) dr["CATEGORYID"];

                    parent.Nodes.Add(node);
                    prevNode = node;
                }
                else
                {
                    node = new TreeNode();
                    node.Text = (string) dr["NAME"];
                    node.ToolTipText = (string) dr["DESCRIPTION"];
                    node.Tag = (int) dr["CATEGORYID"];

                    prevNode.Parent.Nodes.Add(node);
                }
            }
        }

        private void FillFileFlowPanel(int id)
        {
            View.CategoryFiles.FileFlowLayout.Controls.Clear();
            IEnumerable<File> files =
                File.Select("CATEGORYID = " + id.ToSqlFormat());

            foreach (File file in files)
            {
                var pt = new PanelTile(file.Name, file.Description);
                pt.Tag = file;
                pt.pictureBox1.ImageLocation = setFileImage(file.Name);
                pt.pictureBox1.Click += pt_Click;

                View.CategoryFiles.FileFlowLayout.Controls.Add(pt);
            }
        }
    }
}