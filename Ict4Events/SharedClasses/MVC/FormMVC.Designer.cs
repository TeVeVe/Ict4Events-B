namespace SharedClasses.MVC
{
    partial class FormMVC
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
            this.menuStripNavigation = new System.Windows.Forms.MenuStrip();
            this.panelContent = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // menuStripNavigation
            // 
            this.menuStripNavigation.Location = new System.Drawing.Point(0, 0);
            this.menuStripNavigation.Name = "menuStripNavigation";
            this.menuStripNavigation.Size = new System.Drawing.Size(527, 24);
            this.menuStripNavigation.TabIndex = 0;
            this.menuStripNavigation.Text = "menuStripTop";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.SystemColors.Window;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 24);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(527, 294);
            this.panelContent.TabIndex = 1;
            // 
            // FormMVC
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(527, 318);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.menuStripNavigation);
            this.MainMenuStrip = this.menuStripNavigation;
            this.Name = "FormMVC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip menuStripNavigation;
        public System.Windows.Forms.Panel panelContent;
    }
}
