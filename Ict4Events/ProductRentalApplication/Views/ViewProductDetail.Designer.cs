namespace ProductRentalApplication.Views
{
    partial class ViewProductDetail
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
            this.numericUpDownAmount = new System.Windows.Forms.NumericUpDown();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonBrowseProducts = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownAmount
            // 
            this.numericUpDownAmount.Location = new System.Drawing.Point(53, 26);
            this.numericUpDownAmount.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownAmount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownAmount.Name = "numericUpDownAmount";
            this.numericUpDownAmount.Size = new System.Drawing.Size(44, 20);
            this.numericUpDownAmount.TabIndex = 35;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(102, 52);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(79, 24);
            this.buttonCancel.TabIndex = 34;
            this.buttonCancel.Text = "Annuleren";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(53, 52);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(44, 24);
            this.buttonOK.TabIndex = 33;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Aantal:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonBrowseProducts
            // 
            this.buttonBrowseProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseProducts.Location = new System.Drawing.Point(191, 2);
            this.buttonBrowseProducts.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBrowseProducts.Name = "buttonBrowseProducts";
            this.buttonBrowseProducts.Size = new System.Drawing.Size(22, 21);
            this.buttonBrowseProducts.TabIndex = 31;
            this.buttonBrowseProducts.Text = "...";
            this.buttonBrowseProducts.UseVisualStyleBackColor = true;
            this.buttonBrowseProducts.Click += new System.EventHandler(this.buttonBrowseProducts_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Product:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProductName.Location = new System.Drawing.Point(53, 2);
            this.textBoxProductName.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(134, 20);
            this.textBoxProductName.TabIndex = 29;
            // 
            // ViewProductDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownAmount);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonBrowseProducts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxProductName);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ViewProductDetail";
            this.Size = new System.Drawing.Size(215, 79);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownAmount;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonBrowseProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxProductName;


    }
}
