namespace ProductRentalApplication
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
            // panelContent
            // 
            this.panelContent.Margin = new System.Windows.Forms.Padding(2);
            this.panelContent.Size = new System.Drawing.Size(504, 260);
            // 
            // panelMainView
            // 
            this.panelMainView.BackColor = System.Drawing.SystemColors.Window;
            this.panelMainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainView.Location = new System.Drawing.Point(0, 24);
            this.panelMainView.Margin = new System.Windows.Forms.Padding(4);
            this.panelMainView.Name = "panelMainView";
            this.panelMainView.Size = new System.Drawing.Size(504, 260);
            this.panelMainView.TabIndex = 5;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 284);
            this.Controls.Add(this.panelMainView);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.Text = "Verhuursysteem";
            this.Controls.SetChildIndex(this.panelMainView, 0);
            this.Controls.SetChildIndex(this.panelContent, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMainView;
    }
}

