namespace ReservationSystem.Views
{
    partial class ViewReservees
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
            this.buttonAddVisitor = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DataGridViewReservees = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewReservees)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddVisitor
            // 
            this.buttonAddVisitor.Location = new System.Drawing.Point(2, 2);
            this.buttonAddVisitor.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddVisitor.Name = "buttonAddVisitor";
            this.buttonAddVisitor.Size = new System.Drawing.Size(75, 23);
            this.buttonAddVisitor.TabIndex = 16;
            this.buttonAddVisitor.Text = "Toevoegen";
            this.buttonAddVisitor.UseVisualStyleBackColor = true;
            this.buttonAddVisitor.Click += new System.EventHandler(this.buttonAddVisitor_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(81, 2);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 17;
            this.button7.Text = "Verwijderen";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.buttonAddVisitor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(987, 27);
            this.panel1.TabIndex = 18;
            // 
            // DataGridViewReservees
            // 
            this.DataGridViewReservees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewReservees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewReservees.Location = new System.Drawing.Point(0, 27);
            this.DataGridViewReservees.Name = "DataGridViewReservees";
            this.DataGridViewReservees.Size = new System.Drawing.Size(987, 368);
            this.DataGridViewReservees.TabIndex = 19;
            // 
            // ViewReservees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataGridViewReservees);
            this.Controls.Add(this.panel1);
            this.Name = "ViewReservees";
            this.Size = new System.Drawing.Size(987, 395);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewReservees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAddVisitor;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView DataGridViewReservees;

    }
}
