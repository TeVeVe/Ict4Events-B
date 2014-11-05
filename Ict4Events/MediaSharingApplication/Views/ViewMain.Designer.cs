﻿using SharedClasses.Controls.WinForms;

namespace MediaSharingApplication.Views
{
    partial class ViewMain
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FeedPanel = new SharedClasses.Controls.WinForms.PanelFeed();
            this.CategoryTreeView = new SharedClasses.Controls.WinForms.TreeViewCategory();
            this.categoryFiles1 = new SharedClasses.Controls.WinForms.CategoryFiles();
            this.SuspendLayout();
            // 
            // FeedPanel
            // 
            this.FeedPanel.AutoScroll = true;
            this.FeedPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FeedPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.FeedPanel.InputMessage = "";
            this.FeedPanel.Location = new System.Drawing.Point(566, 0);
            this.FeedPanel.Name = "FeedPanel";
            this.FeedPanel.PostButtonText = "Bericht plaatsen";
            this.FeedPanel.PostLabelText = "Uw bericht:";
            this.FeedPanel.Size = new System.Drawing.Size(305, 425);
            this.FeedPanel.TabIndex = 1;
            // 
            // CategoryTreeView
            // 
            this.CategoryTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CategoryTreeView.Cursor = System.Windows.Forms.Cursors.Default;
            this.CategoryTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.CategoryTreeView.Location = new System.Drawing.Point(0, 0);
            this.CategoryTreeView.Name = "CategoryTreeView";
            this.CategoryTreeView.SearchFilter = "";
            this.CategoryTreeView.Size = new System.Drawing.Size(257, 425);
            this.CategoryTreeView.TabIndex = 0;
            // 
            // categoryFiles1
            // 
            this.categoryFiles1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryFiles1.Location = new System.Drawing.Point(257, 0);
            this.categoryFiles1.Name = "categoryFiles1";
            this.categoryFiles1.Size = new System.Drawing.Size(309, 425);
            this.categoryFiles1.TabIndex = 2;
            // 
            // ViewMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.categoryFiles1);
            this.Controls.Add(this.FeedPanel);
            this.Controls.Add(this.CategoryTreeView);
            this.Name = "ViewMain";
            this.Size = new System.Drawing.Size(871, 425);
            this.Load += new System.EventHandler(this.ViewMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public PanelFeed FeedPanel;
        public TreeViewCategory CategoryTreeView;
        private CategoryFiles categoryFiles1;
    }
}
