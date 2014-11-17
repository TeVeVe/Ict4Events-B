namespace SharedClasses.Controls.WinForms
{
    partial class FileComment
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
            this.LabelNaam = new System.Windows.Forms.Label();
            this.LabelContent = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelNaam
            // 
            this.LabelNaam.AutoSize = true;
            this.LabelNaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNaam.Location = new System.Drawing.Point(3, 3);
            this.LabelNaam.Name = "LabelNaam";
            this.LabelNaam.Size = new System.Drawing.Size(39, 13);
            this.LabelNaam.TabIndex = 1;
            this.LabelNaam.Text = "Naam";
            // 
            // LabelContent
            // 
            this.LabelContent.AutoSize = true;
            this.LabelContent.Location = new System.Drawing.Point(3, 16);
            this.LabelContent.Name = "LabelContent";
            this.LabelContent.Size = new System.Drawing.Size(44, 13);
            this.LabelContent.TabIndex = 2;
            this.LabelContent.Text = "Content";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Beantwoorden";
            // 
            // FileComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LabelContent);
            this.Controls.Add(this.LabelNaam);
            this.Name = "FileComment";
            this.Size = new System.Drawing.Size(322, 98);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label LabelNaam;
        public System.Windows.Forms.Label LabelContent;
    }
}
