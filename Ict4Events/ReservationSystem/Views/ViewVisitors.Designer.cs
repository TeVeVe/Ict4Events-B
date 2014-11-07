namespace ReservationSystem.Views
{
    partial class ViewVisitors
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.CheckBoxIsOnSite = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.buttonAddVisitor = new System.Windows.Forms.Button();
            this.DataGridViewVisitors = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewVisitors)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CheckBoxIsOnSite);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(378, 56);
            this.panel1.TabIndex = 15;
            // 
            // CheckBoxIsOnSite
            // 
            this.CheckBoxIsOnSite.AutoSize = true;
            this.CheckBoxIsOnSite.Location = new System.Drawing.Point(7, 19);
            this.CheckBoxIsOnSite.Margin = new System.Windows.Forms.Padding(2);
            this.CheckBoxIsOnSite.Name = "CheckBoxIsOnSite";
            this.CheckBoxIsOnSite.Size = new System.Drawing.Size(115, 17);
            this.CheckBoxIsOnSite.TabIndex = 24;
            this.CheckBoxIsOnSite.Text = "Alleen aanwezigen";
            this.CheckBoxIsOnSite.UseVisualStyleBackColor = true;
            this.CheckBoxIsOnSite.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.buttonAddVisitor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 56);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(378, 36);
            this.panel2.TabIndex = 16;
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(86, 4);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 16;
            this.button7.Text = "Verwijderen";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // buttonAddVisitor
            // 
            this.buttonAddVisitor.Enabled = false;
            this.buttonAddVisitor.Location = new System.Drawing.Point(7, 4);
            this.buttonAddVisitor.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddVisitor.Name = "buttonAddVisitor";
            this.buttonAddVisitor.Size = new System.Drawing.Size(75, 23);
            this.buttonAddVisitor.TabIndex = 15;
            this.buttonAddVisitor.Text = "Toevoegen";
            this.buttonAddVisitor.UseVisualStyleBackColor = true;
            this.buttonAddVisitor.Click += new System.EventHandler(this.buttonAddVisitor_Click);
            // 
            // DataGridViewVisitors
            // 
            this.DataGridViewVisitors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewVisitors.Location = new System.Drawing.Point(0, 92);
            this.DataGridViewVisitors.Margin = new System.Windows.Forms.Padding(2);
            this.DataGridViewVisitors.Name = "DataGridViewVisitors";
            this.DataGridViewVisitors.RowTemplate.Height = 24;
            this.DataGridViewVisitors.Size = new System.Drawing.Size(378, 238);
            this.DataGridViewVisitors.TabIndex = 17;
            this.DataGridViewVisitors.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewVisitors_CellContentClick);
            this.DataGridViewVisitors.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewVisitors_CellMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Klik hier om alleen de aanwezige gasten te zien:";
            // 
            // ViewVisitors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataGridViewVisitors);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ViewVisitors";
            this.Size = new System.Drawing.Size(378, 330);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewVisitors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button buttonAddVisitor;
        public System.Windows.Forms.DataGridView DataGridViewVisitors;
        public System.Windows.Forms.CheckBox CheckBoxIsOnSite;
        private System.Windows.Forms.Label label1;


    }
}
