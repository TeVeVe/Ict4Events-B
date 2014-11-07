namespace AccessControlSystem.Views
{
    partial class ViewLocationDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewLocationDetails));
            this.panelMessage = new System.Windows.Forms.Panel();
            this.labelMessage = new System.Windows.Forms.Label();
            this.InteractiveMap = new SharedClasses.Controls.WinForms.InteractiveMap();
            this.panelMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMessage
            // 
            this.panelMessage.Controls.Add(this.labelMessage);
            this.panelMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMessage.Location = new System.Drawing.Point(0, 0);
            this.panelMessage.Name = "panelMessage";
            this.panelMessage.Size = new System.Drawing.Size(474, 47);
            this.panelMessage.TabIndex = 2;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMessage.Location = new System.Drawing.Point(0, 0);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(209, 39);
            this.labelMessage.TabIndex = 1;
            this.labelMessage.Text = "Welkom! \r\n\r\nUw campingplek is hieronder aangegeven:";
            // 
            // InteractiveMap
            // 
            this.InteractiveMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InteractiveMap.DrawImageRealSize = false;
            this.InteractiveMap.ImageMap = ((System.Drawing.Image)(resources.GetObject("InteractiveMap.ImageMap")));
            this.InteractiveMap.Location = new System.Drawing.Point(0, 47);
            this.InteractiveMap.Name = "InteractiveMap";
            this.InteractiveMap.Size = new System.Drawing.Size(474, 464);
            this.InteractiveMap.TabIndex = 3;
            this.InteractiveMap.Text = "interactiveMap";
            // 
            // ViewLocationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.InteractiveMap);
            this.Controls.Add(this.panelMessage);
            this.Name = "ViewLocationDetails";
            this.Size = new System.Drawing.Size(474, 511);
            this.panelMessage.ResumeLayout(false);
            this.panelMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMessage;
        private System.Windows.Forms.Label labelMessage;
        public SharedClasses.Controls.WinForms.InteractiveMap InteractiveMap;

    }
}
