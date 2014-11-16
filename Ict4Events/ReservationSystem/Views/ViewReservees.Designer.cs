using SharedClasses.Controls.WinForms;

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
            this.buttonAddRow = new System.Windows.Forms.Button();
            this.buttonDeleteRow = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DataGridViewReservees = new ExtendedDataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewReservees)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddRow
            // 
            this.buttonAddRow.Location = new System.Drawing.Point(2, 2);
            this.buttonAddRow.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddRow.Name = "buttonAddRow";
            this.buttonAddRow.Size = new System.Drawing.Size(75, 23);
            this.buttonAddRow.TabIndex = 16;
            this.buttonAddRow.Text = "Toevoegen";
            this.buttonAddRow.UseVisualStyleBackColor = true;
            this.buttonAddRow.Click += new System.EventHandler(this.buttonAddVisitor_Click);
            // 
            // buttonDeleteRow
            // 
            this.buttonDeleteRow.Location = new System.Drawing.Point(81, 2);
            this.buttonDeleteRow.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDeleteRow.Name = "buttonDeleteRow";
            this.buttonDeleteRow.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteRow.TabIndex = 17;
            this.buttonDeleteRow.Text = "Verwijderen";
            this.buttonDeleteRow.UseVisualStyleBackColor = true;
            this.buttonDeleteRow.Click += new System.EventHandler(this.buttonDeleteRow_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonDeleteRow);
            this.panel1.Controls.Add(this.buttonAddRow);
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
            this.DataGridViewReservees.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewReservees_CellDoubleClick);
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

        private System.Windows.Forms.Button buttonAddRow;
        private System.Windows.Forms.Button buttonDeleteRow;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView DataGridViewReservees;

    }
}
