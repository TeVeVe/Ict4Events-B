using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Security.AccessControl;
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
            var files = File.Select("CATEGORYID = (SELECT CATEGORYID FROM CATEGORY WHERE NAME = " + catName.ToSqlFormat() + ")");

            foreach (var file in files)
            {
                var pt = new PanelTile(file.Name, file.Description);
                pt.Tag = file;
                pt.Click += pt_Click;
                View.CategoryFiles.FileFlowLayout.Controls.Add(pt);

            }

        }

        void pt_Click(object sender, System.EventArgs e)
        {
            MainForm.Open<ControllerFileDetail>(new KeyValuePair<string, object>("File", ((PanelTile)sender).Tag));
        }

        private void CreateNodes()
        {
            TreeView treeView = View.CategoryTreeView.treeViewCategories;

            var categories = DataModel.Database.ExecuteCursorProcedure("PROC_ORDEREDNODES");

            DataRow[] rows = new DataRow[categories.Rows.Count];
            categories.Rows.CopyTo(rows, 0);

            treeView.Nodes.Clear();

            FillTreeView(rows, treeView);
        }

        private void FillTreeView (DataRow[] rows, TreeView treeView)
        {
            TreeNode node = null;

            foreach (var dr in rows)
            {
                node.Name = dr["NAME"].ToString();
                node.ToolTipText = dr["DESCRIPTION"].ToString();
                treeView.Nodes.Add(node);
                node = null;
            }
        }
    }
}