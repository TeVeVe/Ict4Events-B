namespace MediaSharingApplication.Views
{
    partial class ViewFileDetail
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
            this.label1 = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.filePicture = new System.Windows.Forms.PictureBox();
            this.downloadButton = new System.Windows.Forms.Button();
            this.TextBoxTitel = new System.Windows.Forms.TextBox();
            this.TextBoxOmschrijving = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.filePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naam:";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(3, 36);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(51, 23);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "Terug";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // filePicture
            // 
            this.filePicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePicture.Location = new System.Drawing.Point(62, 36);
            this.filePicture.Name = "filePicture";
            this.filePicture.Size = new System.Drawing.Size(200, 150);
            this.filePicture.TabIndex = 3;
            this.filePicture.TabStop = false;
            // 
            // downloadButton
            // 
            this.downloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadButton.Location = new System.Drawing.Point(268, 8);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(75, 23);
            this.downloadButton.TabIndex = 4;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // TextBoxTitel
            // 
            this.TextBoxTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxTitel.Location = new System.Drawing.Point(62, 10);
            this.TextBoxTitel.Name = "TextBoxTitel";
            this.TextBoxTitel.Size = new System.Drawing.Size(200, 20);
            this.TextBoxTitel.TabIndex = 8;
            // 
            // TextBoxOmschrijving
            // 
            this.TextBoxOmschrijving.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxOmschrijving.Location = new System.Drawing.Point(62, 192);
            this.TextBoxOmschrijving.Multiline = true;
            this.TextBoxOmschrijving.Name = "TextBoxOmschrijving";
            this.TextBoxOmschrijving.Size = new System.Drawing.Size(281, 219);
            this.TextBoxOmschrijving.TabIndex = 9;
            // 
            // ViewFileDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBoxOmschrijving);
            this.Controls.Add(this.TextBoxTitel);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.filePicture);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.label1);
            this.Name = "ViewFileDetail";
            this.Size = new System.Drawing.Size(346, 414);
            ((System.ComponentModel.ISupportInitialize)(this.filePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button downloadButton;
        public System.Windows.Forms.PictureBox filePicture;
        public System.Windows.Forms.TextBox TextBoxTitel;
        public System.Windows.Forms.TextBox TextBoxOmschrijving;
    }
}
