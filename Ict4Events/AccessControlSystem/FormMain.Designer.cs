namespace AccessControlSystem
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inEnUitcheckenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aanwezigenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.geschiedenisToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMainView = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inEnUitcheckenToolStripMenuItem,
            this.aanwezigenToolStripMenuItem1,
            this.geschiedenisToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(788, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inEnUitcheckenToolStripMenuItem
            // 
            this.inEnUitcheckenToolStripMenuItem.Name = "inEnUitcheckenToolStripMenuItem";
            this.inEnUitcheckenToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
            this.inEnUitcheckenToolStripMenuItem.Text = "In- en uitchecken";
            // 
            // aanwezigenToolStripMenuItem1
            // 
            this.aanwezigenToolStripMenuItem1.Name = "aanwezigenToolStripMenuItem1";
            this.aanwezigenToolStripMenuItem1.Size = new System.Drawing.Size(102, 24);
            this.aanwezigenToolStripMenuItem1.Text = "Aanwezigen";
            // 
            // geschiedenisToolStripMenuItem1
            // 
            this.geschiedenisToolStripMenuItem1.Name = "geschiedenisToolStripMenuItem1";
            this.geschiedenisToolStripMenuItem1.Size = new System.Drawing.Size(107, 24);
            this.geschiedenisToolStripMenuItem1.Text = "Geschiedenis";
            // 
            // panelMainView
            // 
            this.panelMainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainView.Location = new System.Drawing.Point(0, 0);
            this.panelMainView.Margin = new System.Windows.Forms.Padding(4);
            this.panelMainView.Name = "panelMainView";
            this.panelMainView.Size = new System.Drawing.Size(788, 356);
            this.panelMainView.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(788, 356);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelMainView);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.Text = "Toegangsysteem";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inEnUitcheckenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aanwezigenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem geschiedenisToolStripMenuItem1;
        private System.Windows.Forms.Panel panelMainView;


    }
}

