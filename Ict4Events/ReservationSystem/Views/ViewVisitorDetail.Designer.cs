namespace ReservationSystem.Views
{
    partial class ViewVisitorDetail
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
            this.extendedDataGridView1 = new SharedClasses.Controls.WinForms.ExtendedDataGridView();
            this.buttonDeleteRental = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.extendedDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // extendedDataGridView1
            // 
            this.extendedDataGridView1.AllowUserToResizeRows = false;
            this.extendedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.extendedDataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.extendedDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.extendedDataGridView1.Location = new System.Drawing.Point(0, 32);
            this.extendedDataGridView1.Name = "extendedDataGridView1";
            this.extendedDataGridView1.ShowCellToolTips = false;
            this.extendedDataGridView1.Size = new System.Drawing.Size(745, 398);
            this.extendedDataGridView1.TabIndex = 0;
            // 
            // buttonDeleteRental
            // 
            this.buttonDeleteRental.Location = new System.Drawing.Point(17, 3);
            this.buttonDeleteRental.Name = "buttonDeleteRental";
            this.buttonDeleteRental.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteRental.TabIndex = 1;
            this.buttonDeleteRental.Text = "Verwijderen";
            this.buttonDeleteRental.UseVisualStyleBackColor = true;
            this.buttonDeleteRental.Click += new System.EventHandler(this.buttonDeleteRental_Click);
            // 
            // ViewVisitorDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonDeleteRental);
            this.Controls.Add(this.extendedDataGridView1);
            this.Name = "ViewVisitorDetail";
            this.Size = new System.Drawing.Size(745, 430);
            ((System.ComponentModel.ISupportInitialize)(this.extendedDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button buttonDeleteRental;
        public SharedClasses.Controls.WinForms.ExtendedDataGridView extendedDataGridView1;
    }
}
