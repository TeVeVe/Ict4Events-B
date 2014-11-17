namespace SharedClasses.Controls.WinForms
{
    partial class TreeViewCategory
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
            this.components = new System.ComponentModel.Container();
            this.panelTop = new System.Windows.Forms.Panel();
            this.textBoxSearchFilter = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.treeViewCategories = new System.Windows.Forms.TreeView();
            this.contextMenuStripTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.textBoxSearchFilter);
            this.panelTop.Controls.Add(this.labelSearch);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(247, 33);
            this.panelTop.TabIndex = 1;
            // 
            // textBoxSearchFilter
            // 
            this.textBoxSearchFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearchFilter.Location = new System.Drawing.Point(56, 6);
            this.textBoxSearchFilter.Name = "textBoxSearchFilter";
            this.textBoxSearchFilter.Size = new System.Drawing.Size(188, 20);
            this.textBoxSearchFilter.TabIndex = 2;
            this.textBoxSearchFilter.TextChanged += new System.EventHandler(this.textBoxSearchFilter_TextChanged);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(3, 9);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(47, 13);
            this.labelSearch.TabIndex = 1;
            this.labelSearch.Text = "Zoeken:";
            // 
            // treeViewCategories
            // 
            this.treeViewCategories.ContextMenuStrip = this.contextMenuStripTreeView;
            this.treeViewCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewCategories.Location = new System.Drawing.Point(0, 33);
            this.treeViewCategories.Name = "treeViewCategories";
            this.treeViewCategories.Size = new System.Drawing.Size(247, 305);
            this.treeViewCategories.TabIndex = 2;
            this.treeViewCategories.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewCategories_NodeMouseClick);
            this.treeViewCategories.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewCategories_KeyDown);
            // 
            // contextMenuStripTreeView
            // 
            this.contextMenuStripTreeView.Name = "contextMenuStripTreeView";
            this.contextMenuStripTreeView.Size = new System.Drawing.Size(61, 4);
            // 
            // TreeViewCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.treeViewCategories);
            this.Controls.Add(this.panelTop);
            this.Name = "TreeViewCategory";
            this.Size = new System.Drawing.Size(247, 338);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox textBoxSearchFilter;
        private System.Windows.Forms.Label labelSearch;
        public System.Windows.Forms.TreeView treeViewCategories;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTreeView;
    }
}
