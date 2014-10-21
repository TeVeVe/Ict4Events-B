namespace MediaSharingApplication
{
    partial class FormMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMainView = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelMainView
            // 
            this.panelMainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainView.Location = new System.Drawing.Point(0, 0);
            this.panelMainView.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelMainView.Name = "panelMainView";
            this.panelMainView.Size = new System.Drawing.Size(1051, 438);
            this.panelMainView.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1051, 438);
            this.Controls.Add(this.panelMainView);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "FormMain";
            this.Text = "Media Sharing Applicatie";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMainView;

    }
}

