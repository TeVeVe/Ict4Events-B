using System.Windows.Forms;
using SharedClasses.Controls.WinForms;

namespace ReservationSystem.Views
{
    partial class ViewReservationDetail
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
            this.ButtonAddReservee = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBoxReservee = new System.Windows.Forms.TextBox();
            this.TextBoxEvent = new System.Windows.Forms.TextBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSaveReservation = new System.Windows.Forms.Button();
            this.ButtonAddEvent = new System.Windows.Forms.Button();
            this.NumericUpDownVisitorAmount = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ButtonDeleteProduct = new System.Windows.Forms.Button();
            this.ButtonAddProduct = new System.Windows.Forms.Button();
            this.InteractiveMap = new SharedClasses.Controls.WinForms.InteractiveMap();
            this.DataGridViewProducts = new SharedClasses.Controls.WinForms.ExtendedDataGridView();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownVisitorAmount)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonAddReservee
            // 
            this.ButtonAddReservee.Location = new System.Drawing.Point(315, 1);
            this.ButtonAddReservee.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonAddReservee.Name = "ButtonAddReservee";
            this.ButtonAddReservee.Size = new System.Drawing.Size(22, 21);
            this.ButtonAddReservee.TabIndex = 22;
            this.ButtonAddReservee.Text = "...";
            this.ButtonAddReservee.UseVisualStyleBackColor = true;
            this.ButtonAddReservee.Click += new System.EventHandler(this.buttonAddVisitor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Reserveerder*:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Evenement*:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Aantal polsbandjes:";
            // 
            // TextBoxReservee
            // 
            this.TextBoxReservee.Location = new System.Drawing.Point(108, 2);
            this.TextBoxReservee.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxReservee.Name = "TextBoxReservee";
            this.TextBoxReservee.ReadOnly = true;
            this.TextBoxReservee.Size = new System.Drawing.Size(203, 20);
            this.TextBoxReservee.TabIndex = 31;
            // 
            // TextBoxEvent
            // 
            this.TextBoxEvent.Location = new System.Drawing.Point(108, 27);
            this.TextBoxEvent.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxEvent.Name = "TextBoxEvent";
            this.TextBoxEvent.ReadOnly = true;
            this.TextBoxEvent.Size = new System.Drawing.Size(203, 20);
            this.TextBoxEvent.TabIndex = 32;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.buttonCancel);
            this.panelBottom.Controls.Add(this.buttonSaveReservation);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 368);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(754, 31);
            this.panelBottom.TabIndex = 36;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(187, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 39;
            this.buttonCancel.Text = "Annuleren";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSaveReservation
            // 
            this.buttonSaveReservation.Location = new System.Drawing.Point(108, 3);
            this.buttonSaveReservation.Name = "buttonSaveReservation";
            this.buttonSaveReservation.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveReservation.TabIndex = 40;
            this.buttonSaveReservation.Text = "Opslaan";
            this.buttonSaveReservation.UseVisualStyleBackColor = true;
            this.buttonSaveReservation.Click += new System.EventHandler(this.buttonSaveReservation_Click);
            // 
            // ButtonAddEvent
            // 
            this.ButtonAddEvent.Location = new System.Drawing.Point(315, 26);
            this.ButtonAddEvent.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonAddEvent.Name = "ButtonAddEvent";
            this.ButtonAddEvent.Size = new System.Drawing.Size(22, 21);
            this.ButtonAddEvent.TabIndex = 22;
            this.ButtonAddEvent.Text = "...";
            this.ButtonAddEvent.UseVisualStyleBackColor = true;
            this.ButtonAddEvent.Click += new System.EventHandler(this.ButtonAddEvent_Click);
            // 
            // NumericUpDownVisitorAmount
            // 
            this.NumericUpDownVisitorAmount.Location = new System.Drawing.Point(108, 51);
            this.NumericUpDownVisitorAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownVisitorAmount.Name = "NumericUpDownVisitorAmount";
            this.NumericUpDownVisitorAmount.Size = new System.Drawing.Size(120, 20);
            this.NumericUpDownVisitorAmount.TabIndex = 37;
            this.NumericUpDownVisitorAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.InteractiveMap);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(108, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 288);
            this.panel1.TabIndex = 38;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitter1.Location = new System.Drawing.Point(303, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 288);
            this.splitter1.TabIndex = 45;
            this.splitter1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DataGridViewProducts);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(303, 288);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Producten";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ButtonDeleteProduct);
            this.panel2.Controls.Add(this.ButtonAddProduct);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(299, 29);
            this.panel2.TabIndex = 37;
            // 
            // ButtonDeleteProduct
            // 
            this.ButtonDeleteProduct.Location = new System.Drawing.Point(82, 3);
            this.ButtonDeleteProduct.Name = "ButtonDeleteProduct";
            this.ButtonDeleteProduct.Size = new System.Drawing.Size(75, 23);
            this.ButtonDeleteProduct.TabIndex = 39;
            this.ButtonDeleteProduct.Text = "Verwijderen";
            this.ButtonDeleteProduct.UseVisualStyleBackColor = true;
            // 
            // ButtonAddProduct
            // 
            this.ButtonAddProduct.Location = new System.Drawing.Point(3, 3);
            this.ButtonAddProduct.Name = "ButtonAddProduct";
            this.ButtonAddProduct.Size = new System.Drawing.Size(75, 23);
            this.ButtonAddProduct.TabIndex = 40;
            this.ButtonAddProduct.Text = "Toevoegen";
            this.ButtonAddProduct.UseVisualStyleBackColor = true;
            // 
            // InteractiveMap
            // 
            this.InteractiveMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InteractiveMap.DrawImageRealSize = false;
            this.InteractiveMap.ImageMap = null;
            this.InteractiveMap.KeepAspectRatio = true;
            this.InteractiveMap.Location = new System.Drawing.Point(311, 0);
            this.InteractiveMap.Name = "InteractiveMap";
            this.InteractiveMap.Size = new System.Drawing.Size(332, 288);
            this.InteractiveMap.TabIndex = 47;
            this.InteractiveMap.Text = "interactiveMap1";
            // 
            // DataGridViewProducts
            // 
            this.DataGridViewProducts.AllowUserToResizeRows = false;
            this.DataGridViewProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewProducts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DataGridViewProducts.Location = new System.Drawing.Point(2, 44);
            this.DataGridViewProducts.Margin = new System.Windows.Forms.Padding(2);
            this.DataGridViewProducts.Name = "DataGridViewProducts";
            this.DataGridViewProducts.RowTemplate.Height = 24;
            this.DataGridViewProducts.ShowCellToolTips = false;
            this.DataGridViewProducts.Size = new System.Drawing.Size(299, 242);
            this.DataGridViewProducts.TabIndex = 38;
            // 
            // ViewReservationDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.NumericUpDownVisitorAmount);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.TextBoxEvent);
            this.Controls.Add(this.TextBoxReservee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ButtonAddEvent);
            this.Controls.Add(this.ButtonAddReservee);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ViewReservationDetail";
            this.Size = new System.Drawing.Size(754, 399);
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownVisitorAmount)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSaveReservation;
        public System.Windows.Forms.Button ButtonAddReservee;
        public System.Windows.Forms.TextBox TextBoxReservee;
        public System.Windows.Forms.TextBox TextBoxEvent;
        public System.Windows.Forms.Button ButtonAddEvent;
        public NumericUpDown NumericUpDownVisitorAmount;
        private Panel panel1;
        private GroupBox groupBox1;
        public ExtendedDataGridView DataGridViewProducts;
        private Panel panel2;
        public Button ButtonDeleteProduct;
        public Button ButtonAddProduct;
        private Splitter splitter1;
        public InteractiveMap InteractiveMap;

    }
}
