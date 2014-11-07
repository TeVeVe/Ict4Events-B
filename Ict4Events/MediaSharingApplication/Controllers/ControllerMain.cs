using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MediaSharingApplication.Views;
using SharedClasses.Controls.WinForms;
using SharedClasses.Data;
using SharedClasses.Data.Models;
using SharedClasses.Extensions;
using SharedClasses.MVC;

namespace MediaSharingApplication.Controllers
{
    public class ControllerMain : ControllerMVC<ViewMain>
    {
        public override void Activate()
        {
            //CreateNodes();
            FillFileFlowPanel("Muziek");
        }

        private void FillFileFlowPanel(string catName)
        {
            IEnumerable<File> files =
                File.Select("CATEGORYID = (SELECT CATEGORYID FROM CATEGORY WHERE NAME = " + catName.ToSqlFormat() + ")");

            foreach (File file in files)
            {
                var pt = new PanelTile(file.Name, file.Description);
                pt.Tag = file;
                pt.Click += pt_Click;
                View.CategoryFiles.FileFlowLayout.Controls.Add(pt);
            }
        }

        private void pt_Click(object sender, EventArgs e)
        {
            MainForm.Open<ControllerFileDetail>(new KeyValuePair<string, object>("File", ((PanelTile)sender).Tag));
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
                level = (int)dr["LEVEL"];

                if (level == 1)
                {
                    root = new TreeNode();
                    root.Text = (string)dr["NAME"];
                    root.ToolTipText = (string)dr["DESCRIPTION"];

                    treeView.Nodes.Add(root);
                    prevNode = root;
                }
                else if (level > 1 && level > prevLevel)
                {
                    parent = prevNode;

                    node = new TreeNode();
                    node.Text = (string)dr["NAME"];
                    node.ToolTipText = (string)dr["DESCRIPTION"];

                    parent.Nodes.Add(node);
                    prevNode = node;
                }
                else
                {
                    node = new TreeNode();
                    node.Text = (string)dr["NAME"];
                    node.ToolTipText = (string)dr["DESCRIPTION"];

                    prevNode.Parent.Nodes.Add(node);
                }
            }
        }
    }
}