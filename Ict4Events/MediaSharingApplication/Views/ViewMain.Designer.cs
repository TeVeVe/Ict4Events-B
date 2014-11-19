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
            this.panel1 = new System.Windows.Forms.Panel();
            this.CategoryFiles = new SharedClasses.Controls.WinForms.CategoryFiles();
            this.CategoryTreeView = new SharedClasses.Controls.WinForms.TreeViewCategory();
            this.CommentInput = new SharedClasses.Controls.WinForms.CommentInput();
            this.CommentSection = new SharedClasses.Controls.WinForms.CommentSection();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CommentSection);
            this.panel1.Controls.Add(this.CommentInput);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(591, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 425);
            this.panel1.TabIndex = 4;
            // 
            // CategoryFiles
            // 
            this.CategoryFiles.AutoScroll = true;
            this.CategoryFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CategoryFiles.Location = new System.Drawing.Point(280, 0);
            this.CategoryFiles.Name = "CategoryFiles";
            this.CategoryFiles.Size = new System.Drawing.Size(311, 425);
            this.CategoryFiles.TabIndex = 3;
            // 
            // CategoryTreeView
            // 
            this.CategoryTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CategoryTreeView.Cursor = System.Windows.Forms.Cursors.Default;
            this.CategoryTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.CategoryTreeView.LastSelectedNode = null;
            this.CategoryTreeView.Location = new System.Drawing.Point(0, 0);
            this.CategoryTreeView.Name = "CategoryTreeView";
            this.CategoryTreeView.SearchFilter = "";
            this.CategoryTreeView.Size = new System.Drawing.Size(280, 425);
            this.CategoryTreeView.TabIndex = 0;
            // 
            // CommentInput
            // 
            this.CommentInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CommentInput.Location = new System.Drawing.Point(0, 295);
            this.CommentInput.MinimumSize = new System.Drawing.Size(260, 105);
            this.CommentInput.Name = "CommentInput";
            this.CommentInput.Padding = new System.Windows.Forms.Padding(3);
            this.CommentInput.Size = new System.Drawing.Size(280, 130);
            this.CommentInput.TabIndex = 0;
            // 
            // CommentSection
            // 
            this.CommentSection.BackColor = System.Drawing.Color.White;
            this.CommentSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommentSection.Location = new System.Drawing.Point(0, 0);
            this.CommentSection.Name = "CommentSection";
            this.CommentSection.Size = new System.Drawing.Size(280, 295);
            this.CommentSection.TabIndex = 1;
            // 
            // ViewMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CategoryFiles);
            this.Controls.Add(this.CategoryTreeView);
            this.Controls.Add(this.panel1);
            this.Name = "ViewMain";
            this.Size = new System.Drawing.Size(871, 425);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public TreeViewCategory CategoryTreeView;
        public CategoryFiles CategoryFiles;
        private System.Windows.Forms.Panel panel1;
        public CommentInput CommentInput;
        public CommentSection CommentSection;
    }
}
