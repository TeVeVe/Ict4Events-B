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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evenementenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reserveringenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
            this.evenementenToolStripMenuItem,
            this.reserveringenToolStripMenuItem,
            this.productenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(160, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(160, 0);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Reserveringssysteem";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem evenementenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reserveringenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productenToolStripMenuItem;
    }
}

