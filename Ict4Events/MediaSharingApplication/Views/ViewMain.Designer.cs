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
            this.feedPanel1 = new PanelFeed();
            this.categoryTreeView1 = new TreeViewCategory();
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
            // categoryTreeView1
            // 
            this.categoryTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.categoryTreeView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.categoryTreeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.categoryTreeView1.Location = new System.Drawing.Point(0, 0);
            this.categoryTreeView1.Name = "categoryTreeView1";
            this.categoryTreeView1.SearchFilter = "";
            this.categoryTreeView1.Size = new System.Drawing.Size(257, 425);
            this.categoryTreeView1.TabIndex = 0;
            // 
            // ViewMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.feedPanel1);
            this.Controls.Add(this.categoryTreeView1);
            this.Name = "ViewMain";
            this.Size = new System.Drawing.Size(871, 425);
            this.ResumeLayout(false);

        }

        #endregion

        public PanelFeed feedPanel1;
        public TreeViewCategory categoryTreeView1;
    }
}
