namespace AccessControlSystem.Views
{
    partial class ViewVisitorExit
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
            this.panelCenteredMessage1 = new SharedClasses.Controls.WinForms.PanelCenteredMessage();
            this.SuspendLayout();
            // 
            // panelCenteredMessage1
            // 
            this.panelCenteredMessage1.BackColor = System.Drawing.SystemColors.Control;
            this.panelCenteredMessage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenteredMessage1.Location = new System.Drawing.Point(0, 0);
            this.panelCenteredMessage1.Message = "Bedankt voor uw komst! ";
            this.panelCenteredMessage1.Name = "panelCenteredMessage1";
            this.panelCenteredMessage1.Size = new System.Drawing.Size(501, 238);
            this.panelCenteredMessage1.TabIndex = 0;
            // 
            // ViewVisitorExit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenteredMessage1);
            this.Name = "ViewVisitorExit";
            this.Size = new System.Drawing.Size(501, 238);
            this.ResumeLayout(false);

        }

        #endregion

        private SharedClasses.Controls.WinForms.PanelCenteredMessage panelCenteredMessage1;
    }
}
