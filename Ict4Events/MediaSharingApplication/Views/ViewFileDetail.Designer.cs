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
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ButtonPlus = new System.Windows.Forms.Button();
            this.ButtonMinus = new System.Windows.Forms.Button();
            this.LabelScore = new System.Windows.Forms.Label();
            this.CommentSection = new SharedClasses.Controls.WinForms.CommentSection();
            this.FileComment = new SharedClasses.Controls.WinForms.FileCommentInput();
            ((System.ComponentModel.ISupportInitialize)(this.filePicture)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naam:";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(3, 454);
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
            this.filePicture.Location = new System.Drawing.Point(3, 31);
            this.filePicture.Name = "filePicture";
            this.filePicture.Size = new System.Drawing.Size(394, 296);
            this.filePicture.TabIndex = 3;
            this.filePicture.TabStop = false;
            // 
            // downloadButton
            // 
            this.downloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadButton.Location = new System.Drawing.Point(322, 3);
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
            this.TextBoxTitel.Location = new System.Drawing.Point(47, 5);
            this.TextBoxTitel.Name = "TextBoxTitel";
            this.TextBoxTitel.Size = new System.Drawing.Size(269, 20);
            this.TextBoxTitel.TabIndex = 8;
            // 
            // TextBoxOmschrijving
            // 
            this.TextBoxOmschrijving.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxOmschrijving.Location = new System.Drawing.Point(62, 230);
            this.TextBoxOmschrijving.Multiline = true;
            this.TextBoxOmschrijving.Name = "TextBoxOmschrijving";
            this.TextBoxOmschrijving.Size = new System.Drawing.Size(654, 0);
            this.TextBoxOmschrijving.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Reacties:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ButtonPlus);
            this.panel1.Controls.Add(this.ButtonMinus);
            this.panel1.Controls.Add(this.LabelScore);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.downloadButton);
            this.panel1.Controls.Add(this.TextBoxTitel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.filePicture);
            this.panel1.Controls.Add(this.backButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 480);
            this.panel1.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(339, 454);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Opslaan";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.CommentSection);
            this.panel2.Controls.Add(this.FileComment);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(400, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 480);
            this.panel2.TabIndex = 9;
            // 
            // ButtonPlus
            // 
            this.ButtonPlus.Location = new System.Drawing.Point(215, 454);
            this.ButtonPlus.Name = "ButtonPlus";
            this.ButtonPlus.Size = new System.Drawing.Size(35, 23);
            this.ButtonPlus.TabIndex = 13;
            this.ButtonPlus.Text = "+";
            this.ButtonPlus.UseVisualStyleBackColor = true;
            // 
            // ButtonMinus
            // 
            this.ButtonMinus.Location = new System.Drawing.Point(133, 454);
            this.ButtonMinus.Name = "ButtonMinus";
            this.ButtonMinus.Size = new System.Drawing.Size(35, 23);
            this.ButtonMinus.TabIndex = 14;
            this.ButtonMinus.Text = "-";
            this.ButtonMinus.UseVisualStyleBackColor = true;
            // 
            // LabelScore
            // 
            this.LabelScore.Location = new System.Drawing.Point(174, 454);
            this.LabelScore.Name = "LabelScore";
            this.LabelScore.Size = new System.Drawing.Size(35, 21);
            this.LabelScore.TabIndex = 15;
            this.LabelScore.Text = "-9999";
            this.LabelScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CommentSection
            // 
            this.CommentSection.AutoSize = true;
            this.CommentSection.BackColor = System.Drawing.Color.White;
            this.CommentSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommentSection.Location = new System.Drawing.Point(0, 0);
            this.CommentSection.Margin = new System.Windows.Forms.Padding(10);
            this.CommentSection.Name = "CommentSection";
            this.CommentSection.Size = new System.Drawing.Size(400, 375);
            this.CommentSection.TabIndex = 10;
            // 
            // FileComment
            // 
            this.FileComment.AutoSize = true;
            this.FileComment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FileComment.Location = new System.Drawing.Point(0, 375);
            this.FileComment.Name = "FileComment";
            this.FileComment.Size = new System.Drawing.Size(400, 105);
            this.FileComment.TabIndex = 12;
            // 
            // ViewFileDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBoxOmschrijving);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "ViewFileDetail";
            this.Size = new System.Drawing.Size(800, 480);
            ((System.ComponentModel.ISupportInitialize)(this.filePicture)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        public SharedClasses.Controls.WinForms.FileCommentInput FileComment;
        public SharedClasses.Controls.WinForms.CommentSection CommentSection;
        public System.Windows.Forms.Button ButtonPlus;
        public System.Windows.Forms.Button ButtonMinus;
        public System.Windows.Forms.Label LabelScore;
    }
}
