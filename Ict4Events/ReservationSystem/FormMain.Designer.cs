namespace ReservationSystem
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
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evenementenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reserveringenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMainView = new System.Windows.Forms.Panel();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
            this.evenementenToolStripMenuItem,
            this.reserveringenToolStripMenuItem,
            this.productenToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStripMain.Size = new System.Drawing.Size(653, 28);
            this.menuStripMain.TabIndex = 3;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.testToolStripMenuItem.Text = "Bezoeker";
            // 
            // evenementenToolStripMenuItem
            // 
            this.evenementenToolStripMenuItem.Name = "evenementenToolStripMenuItem";
            this.evenementenToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.evenementenToolStripMenuItem.Text = "Evenementen";
            // 
            // reserveringenToolStripMenuItem
            // 
            this.reserveringenToolStripMenuItem.Name = "reserveringenToolStripMenuItem";
            this.reserveringenToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.reserveringenToolStripMenuItem.Text = "Reserveringen";
            // 
            // productenToolStripMenuItem
            // 
            this.productenToolStripMenuItem.Name = "productenToolStripMenuItem";
            this.productenToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.productenToolStripMenuItem.Text = "Producten";
            // 
            // panelMainView
            // 
            this.panelMainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainView.Location = new System.Drawing.Point(0, 28);
            this.panelMainView.Margin = new System.Windows.Forms.Padding(4);
            this.panelMainView.Name = "panelMainView";
            this.panelMainView.Size = new System.Drawing.Size(653, 388);
            this.panelMainView.TabIndex = 4;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(653, 416);
            this.Controls.Add(this.panelMainView);
            this.Controls.Add(this.menuStripMain);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.Text = "Reserveringssysteem";
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem evenementenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reserveringenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productenToolStripMenuItem;
        private System.Windows.Forms.Panel panelMainView;

    }
}

