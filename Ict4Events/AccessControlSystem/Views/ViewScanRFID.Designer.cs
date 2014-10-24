using SharedClasses.Controls.WinForms;

namespace AccessControlSystem.Views
{
    sealed partial class ViewScanRFID
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
            this.centeredMessagePanel1 = new SharedClasses.Controls.WinForms.PanelCenteredMessage();
            this.SuspendLayout();
            // 
            // centeredMessagePanel1
            // 
            this.centeredMessagePanel1.BackColor = System.Drawing.SystemColors.Window;
            this.centeredMessagePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centeredMessagePanel1.Location = new System.Drawing.Point(0, 0);
            this.centeredMessagePanel1.Message = "Toon uw polsbandje aan de scanner";
            this.centeredMessagePanel1.Name = "centeredMessagePanel1";
            this.centeredMessagePanel1.Size = new System.Drawing.Size(606, 321);
            this.centeredMessagePanel1.TabIndex = 0;
            // 
            // ViewScanRFID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.centeredMessagePanel1);
            this.Name = "ViewScanRFID";
            this.Size = new System.Drawing.Size(606, 321);
            this.ResumeLayout(false);

        }

        #endregion

        private PanelCenteredMessage centeredMessagePanel1;
    }
}
