using SharedClasses.Controls.WinForms;

namespace ReservationSystem.Views
{
    partial class ViewReservation
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
            this.DataGridViewVisitors = new ExtendedDataGridView();
            this.button7 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonAddReservation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewVisitors)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGridViewVisitors
            // 
            this.DataGridViewVisitors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewVisitors.Location = new System.Drawing.Point(0, 31);
            this.DataGridViewVisitors.Location = new System.Drawing.Point(0, 134);
            this.DataGridViewVisitors.Margin = new System.Windows.Forms.Padding(2);
            this.DataGridViewVisitors.Name = "DataGridViewVisitors";
            this.DataGridViewVisitors.RowTemplate.Height = 24;
            this.DataGridViewVisitors.Size = new System.Drawing.Size(497, 446);
            this.DataGridViewVisitors.TabIndex = 20;
            this.DataGridViewVisitors.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVisitors_CellDoubleClick);
            
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(82, 4);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 16;
            this.button7.Text = "Verwijderen";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.buttonAddReservation);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Location = new System.Drawing.Point(0, 103);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(497, 31);
            this.panel2.TabIndex = 19;
            // 
            // buttonAddReservation
            // 
            this.buttonAddReservation.Location = new System.Drawing.Point(2, 4);
            this.buttonAddReservation.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddReservation.Name = "buttonAddReservation";
            this.buttonAddReservation.Size = new System.Drawing.Size(75, 23);
            this.buttonAddReservation.TabIndex = 15;
            this.buttonAddReservation.Text = "Toevoegen";
            this.buttonAddReservation.UseVisualStyleBackColor = true;
            this.buttonAddReservation.Click += new System.EventHandler(this.buttonAddReservation_Click);
            
            // 
            // ViewReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataGridViewVisitors);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ViewReservation";
            this.Size = new System.Drawing.Size(497, 477);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewVisitors)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonAddReservation;
        public System.Windows.Forms.DataGridView DataGridViewVisitors;
    }
}
