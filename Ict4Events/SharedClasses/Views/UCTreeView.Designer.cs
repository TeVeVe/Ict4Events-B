namespace SharedClasses.Views
{
    partial class UCTreeView
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.textBoxSearchFilter = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.buttonAddCategory = new System.Windows.Forms.Button();
            this.treeViewCategories = new System.Windows.Forms.TreeView();
            this.buttonAddSubcategory = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.textBoxSearchFilter);
            this.panelTop.Controls.Add(this.labelSearch);
            this.panelTop.Controls.Add(this.buttonAddSubcategory);
            this.panelTop.Controls.Add(this.buttonAddCategory);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(249, 89);
            this.panelTop.TabIndex = 1;
            // 
            // textBoxSearchFilter
            // 
            this.textBoxSearchFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearchFilter.Location = new System.Drawing.Point(56, 61);
            this.textBoxSearchFilter.Name = "textBoxSearchFilter";
            this.textBoxSearchFilter.Size = new System.Drawing.Size(190, 20);
            this.textBoxSearchFilter.TabIndex = 2;
            this.textBoxSearchFilter.TextChanged += new System.EventHandler(this.textBoxSearchFilter_TextChanged);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(3, 64);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(47, 13);
            this.labelSearch.TabIndex = 1;
            this.labelSearch.Text = "Zoeken:";
            // 
            // buttonAddCategory
            // 
            this.buttonAddCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddCategory.Location = new System.Drawing.Point(3, 3);
            this.buttonAddCategory.Name = "buttonAddCategory";
            this.buttonAddCategory.Size = new System.Drawing.Size(243, 23);
            this.buttonAddCategory.TabIndex = 0;
            this.buttonAddCategory.Text = "Categorie toevoegen";
            this.buttonAddCategory.UseVisualStyleBackColor = true;
            this.buttonAddCategory.Click += new System.EventHandler(this.buttonAddCategory_Click);
            // 
            // treeViewCategories
            // 
            this.treeViewCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewCategories.Location = new System.Drawing.Point(0, 89);
            this.treeViewCategories.Name = "treeViewCategories";
            this.treeViewCategories.Size = new System.Drawing.Size(249, 251);
            this.treeViewCategories.TabIndex = 2;
            this.treeViewCategories.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeViewCategories_KeyDown);
            // 
            // buttonAddSubcategory
            // 
            this.buttonAddSubcategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddSubcategory.Location = new System.Drawing.Point(3, 32);
            this.buttonAddSubcategory.Name = "buttonAddSubcategory";
            this.buttonAddSubcategory.Size = new System.Drawing.Size(243, 23);
            this.buttonAddSubcategory.TabIndex = 0;
            this.buttonAddSubcategory.Text = "Subcategorie toevoegen";
            this.buttonAddSubcategory.UseVisualStyleBackColor = true;
            this.buttonAddSubcategory.Click += new System.EventHandler(this.buttonAddSubcategory_Click);
            // 
            // UCCategoryTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeViewCategories);
            this.Controls.Add(this.panelTop);
            this.Name = "UCCategoryTreeView";
            this.Size = new System.Drawing.Size(249, 340);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button buttonAddCategory;
        private System.Windows.Forms.TreeView treeViewCategories;
        private System.Windows.Forms.TextBox textBoxSearchFilter;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.Button buttonAddSubcategory;
    }
}
