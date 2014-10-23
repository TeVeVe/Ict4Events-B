namespace SharedClasses.Controls.WinForms
{
    partial class PanelCenteredMessage
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
            this.labelCenteredLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCenteredLabel
            // 
            this.labelCenteredLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCenteredLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCenteredLabel.Location = new System.Drawing.Point(0, 0);
            this.labelCenteredLabel.Name = "labelCenteredLabel";
            this.labelCenteredLabel.Size = new System.Drawing.Size(882, 274);
            this.labelCenteredLabel.TabIndex = 1;
            this.labelCenteredLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCFullscreenMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.labelCenteredLabel);
            this.Name = "UCFullscreenMessage";
            this.Size = new System.Drawing.Size(882, 274);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelCenteredLabel;

    }
}
