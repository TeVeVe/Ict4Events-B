using SharedClasses.Controls.WinForms;

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
            this.feedPanel1 = new SharedClasses.Controls.WinForms.PanelFeed();
            this.CategoryTreeView = new SharedClasses.Controls.WinForms.TreeViewCategory();
            this.CategoryFiles = new SharedClasses.Controls.WinForms.CategoryFiles();
            this.SuspendLayout();
            // 
            // feedPanel1
            // 
            this.feedPanel1.AutoScroll = true;
            this.feedPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.feedPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.feedPanel1.InputMessage = "";
            this.feedPanel1.Location = new System.Drawing.Point(566, 0);
            this.feedPanel1.Name = "feedPanel1";
            this.feedPanel1.PostButtonText = "Bericht plaatsen";
            this.feedPanel1.PostLabelText = "Uw bericht:";
            this.feedPanel1.Size = new System.Drawing.Size(305, 425);
            this.feedPanel1.TabIndex = 1;
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
            // CategoryFiles
            // 
            this.CategoryFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CategoryFiles.Location = new System.Drawing.Point(257, 0);
            this.CategoryFiles.Name = "CategoryFiles";
            this.CategoryFiles.Size = new System.Drawing.Size(309, 425);
            this.CategoryFiles.TabIndex = 2;
            // 
            // ViewMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CategoryFiles);
            this.Controls.Add(this.feedPanel1);
            this.Controls.Add(this.CategoryTreeView);
            this.Name = "ViewMain";
            this.Size = new System.Drawing.Size(871, 425);
            this.ResumeLayout(false);

        }

        #endregion

        public PanelFeed feedPanel1;
        public TreeViewCategory CategoryTreeView;
        private CategoryFiles CategoryFiles;
    }
}
