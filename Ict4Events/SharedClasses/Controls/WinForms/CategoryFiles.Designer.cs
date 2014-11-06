namespace SharedClasses.Controls.WinForms
{
    partial class CategoryFiles
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
            this.AddFileButton = new System.Windows.Forms.Button();
            this.FileFlowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddFileButton
            // 
            this.AddFileButton.Location = new System.Drawing.Point(3, 3);
            this.AddFileButton.Name = "AddFileButton";
            this.AddFileButton.Size = new System.Drawing.Size(75, 23);
            this.AddFileButton.TabIndex = 0;
            this.AddFileButton.Text = "Toevoegen";
            this.AddFileButton.UseVisualStyleBackColor = true;
            this.AddFileButton.Click += new System.EventHandler(this.AddFileButton_Click);
            // 
            // FileFlowLayout
            // 
            this.FileFlowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileFlowLayout.Location = new System.Drawing.Point(0, 29);
            this.FileFlowLayout.Name = "FileFlowLayout";
            this.FileFlowLayout.Size = new System.Drawing.Size(253, 355);
            this.FileFlowLayout.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AddFileButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 29);
            this.panel1.TabIndex = 0;
            // 
            // CategoryFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.FileFlowLayout);
            this.Controls.Add(this.panel1);
            this.Name = "CategoryFiles";
            this.Size = new System.Drawing.Size(253, 384);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddFileButton;
        private System.Windows.Forms.FlowLayoutPanel FileFlowLayout;
        private System.Windows.Forms.Panel panel1;
    }
}
