namespace MediaSharingApplication.Views
{
    partial class ViewAddFile
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
            this.ButtonUploadFile = new System.Windows.Forms.Button();
            this.TextBoxFilePath = new System.Windows.Forms.TextBox();
            this.TextBoxDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonUploadFile
            // 
            this.ButtonUploadFile.Location = new System.Drawing.Point(275, 3);
            this.ButtonUploadFile.Name = "ButtonUploadFile";
            this.ButtonUploadFile.Size = new System.Drawing.Size(75, 23);
            this.ButtonUploadFile.TabIndex = 1;
            this.ButtonUploadFile.Text = "Bladeren...";
            this.ButtonUploadFile.UseVisualStyleBackColor = true;
            // 
            // TextBoxFilePath
            // 
            this.TextBoxFilePath.Enabled = false;
            this.TextBoxFilePath.Location = new System.Drawing.Point(3, 5);
            this.TextBoxFilePath.Name = "TextBoxFilePath";
            this.TextBoxFilePath.Size = new System.Drawing.Size(266, 20);
            this.TextBoxFilePath.TabIndex = 2;
            // 
            // TextBoxDescription
            // 
            this.TextBoxDescription.Location = new System.Drawing.Point(3, 44);
            this.TextBoxDescription.Multiline = true;
            this.TextBoxDescription.Name = "TextBoxDescription";
            this.TextBoxDescription.Size = new System.Drawing.Size(347, 74);
            this.TextBoxDescription.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Beschrijving";
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(275, 124);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 5;
            this.ButtonCancel.Text = "Annuleren";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(194, 124);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 6;
            this.ButtonSave.Text = "Opslaan";
            this.ButtonSave.UseVisualStyleBackColor = true;
            // 
            // ViewAddFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxDescription);
            this.Controls.Add(this.TextBoxFilePath);
            this.Controls.Add(this.ButtonUploadFile);
            this.Name = "ViewAddFile";
            this.Size = new System.Drawing.Size(350, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button ButtonCancel;
        public System.Windows.Forms.Button ButtonSave;
        public System.Windows.Forms.TextBox TextBoxDescription;
        public System.Windows.Forms.Button ButtonUploadFile;
        public System.Windows.Forms.TextBox TextBoxFilePath;
    }
}
