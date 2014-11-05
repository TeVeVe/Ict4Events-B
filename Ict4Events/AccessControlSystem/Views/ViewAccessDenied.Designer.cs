namespace AccessControlSystem.Views
{
    partial class ViewAccessDenied
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
            this.panelCenteredMessage1.BackColor = System.Drawing.Color.Red;
            this.panelCenteredMessage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenteredMessage1.Location = new System.Drawing.Point(0, 0);
            this.panelCenteredMessage1.Message = "Toegang geweigerd! Betaling niet in orde...";
            this.panelCenteredMessage1.Name = "panelCenteredMessage1";
            this.panelCenteredMessage1.Size = new System.Drawing.Size(718, 434);
            this.panelCenteredMessage1.TabIndex = 0;
            this.panelCenteredMessage1.Load += new System.EventHandler(this.panelCenteredMessage1_Load_1);
            // 
            // ViewAccessDenied
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCenteredMessage1);
            this.Name = "ViewAccessDenied";
            this.Size = new System.Drawing.Size(718, 434);
            this.ResumeLayout(false);

        }

        #endregion

        private SharedClasses.Controls.WinForms.PanelCenteredMessage panelCenteredMessage1;
    }
}
