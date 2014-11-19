namespace SharedClasses.Controls.WinForms
{
    partial class CommentControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelNaam
            // 
            this.LabelNaam.AutoSize = true;
            this.LabelNaam.BackColor = System.Drawing.SystemColors.Control;
            this.LabelNaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNaam.Location = new System.Drawing.Point(3, 3);
            this.LabelNaam.Name = "LabelNaam";
            this.LabelNaam.Size = new System.Drawing.Size(39, 13);
            this.LabelNaam.TabIndex = 1;
            this.LabelNaam.Text = "Naam";
            // 
            // LabelContent
            // 
            this.LabelContent.BackColor = System.Drawing.SystemColors.Control;
            this.LabelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelContent.Location = new System.Drawing.Point(0, 22);
            this.LabelContent.MinimumSize = new System.Drawing.Size(206, 48);
            this.LabelContent.Name = "LabelContent";
            this.LabelContent.Size = new System.Drawing.Size(206, 48);
            this.LabelContent.TabIndex = 2;
            this.LabelContent.Text = "Content";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.LabelContent);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 70);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.LabelNaam);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(206, 22);
            this.panel2.TabIndex = 5;
            // 
            // CommentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(206, 70);
            this.Name = "CommentControl";
            this.Size = new System.Drawing.Size(206, 70);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label LabelNaam;
        public System.Windows.Forms.Label LabelContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
