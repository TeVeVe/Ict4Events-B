﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
        public override void Activate()
        {
            CreateNodes();

            View.CategoryTreeView.NodeClick += CategoryTreeView_NodeClick;
            View.CategoryFiles.AddFileButton.Click += AddFileButton_Click;
        }

        void AddFileButton_Click(object sender, EventArgs e)
        {
            if (View.CategoryTreeView.SelectedNode == null)
            {
                MessageBox.Show("Selecteer een categorie om een bestand toe te kunnen voegen.");
                return;
            }
            string filePath = "";
            

            var ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog();
            if (result == DialogResult.OK)
            {
                filePath = ofd.FileName;

                var directoryNames = GetDirectoryNames(View.CategoryTreeView.SelectedNode);
                FileTransfer.UploadFile(filePath, directoryNames);

                // Insert file into database.
                File file = new File();
                file.Name = Path.GetFileName(filePath);
                file.PostTime = DateTime.Now;
                file.ReportCount = 0;
                file.CategoryId = (int)View.CategoryTreeView.SelectedNode.Tag;
                file.Description = "File";
#if DEBUG
                file.UserAccountId = 1;
#else
                file.UserAccountId = MainForm.UserSession;
#endif
                file.Insert();
            }
        }

        private IEnumerable<string> GetDirectoryNames(TreeNode node)
        {
            List<String> categoryList = new List<String>();
            TreeNode parent = node.Parent;

            categoryList.Add(node.Text);
            while (parent != null)
            {
                categoryList.Add(parent.Text);
                parent = parent.Parent;
            }

            categoryList.Reverse();
            return categoryList;
        }

        void CategoryTreeView_NodeClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FillFileFlowPanel(e.Node.Text);
        }

        private void FillFileFlowPanel(string catName)
        {
            View.CategoryFiles.FileFlowLayout.Controls.Clear();

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
                    root.Tag = (int) dr["CATEGORYID"];

                    treeView.Nodes.Add(root);
                    prevNode = root;
                }
                else if (level > 1 && level > prevLevel)
                {
                    parent = prevNode;

                    node = new TreeNode();
                    node.Text = (string)dr["NAME"];
                    node.ToolTipText = (string)dr["DESCRIPTION"];
                    node.Tag = (int)dr["CATEGORYID"];

                    parent.Nodes.Add(node);
                    prevNode = node;
                }
                else
                {
                    node = new TreeNode();
                    node.Text = (string)dr["NAME"];
                    node.ToolTipText = (string)dr["DESCRIPTION"];
                    node.Tag = (int)dr["CATEGORYID"];

                    prevNode.Parent.Nodes.Add(node);
                }
            }
        }
    }
}