namespace ReservationSystem.Views
{
    partial class ViewReserveeDetail
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TextBoxEmail = new SharedClasses.Controls.WinForms.NamedClearableTextBox();
            this.TextBoxPhone = new SharedClasses.Controls.WinForms.NamedClearableTextBox();
            this.TextBoxPostalCode = new SharedClasses.Controls.WinForms.NamedClearableTextBox();
            this.TextBoxCity = new SharedClasses.Controls.WinForms.NamedClearableTextBox();
            this.TextBoxHouseNumber = new SharedClasses.Controls.WinForms.NamedClearableTextBox();
            this.TextBoxStreet = new SharedClasses.Controls.WinForms.NamedClearableTextBox();
            this.TextBoxLastName = new SharedClasses.Controls.WinForms.NamedClearableTextBox();
            this.TextBoxInsertion = new SharedClasses.Controls.WinForms.NamedClearableTextBox();
            this.TextBoxName = new SharedClasses.Controls.WinForms.NamedClearableTextBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TextBoxEmail);
            this.groupBox1.Controls.Add(this.TextBoxPhone);
            this.groupBox1.Controls.Add(this.TextBoxPostalCode);
            this.groupBox1.Controls.Add(this.TextBoxCity);
            this.groupBox1.Controls.Add(this.TextBoxHouseNumber);
            this.groupBox1.Controls.Add(this.TextBoxStreet);
            this.groupBox1.Controls.Add(this.TextBoxLastName);
            this.groupBox1.Controls.Add(this.TextBoxInsertion);
            this.groupBox1.Controls.Add(this.TextBoxName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(504, 286);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Persoonlijke gegevens";
            // 
            // TextBoxEmail
            // 
            this.TextBoxEmail.AutoSize = true;
            this.TextBoxEmail.ClearButtonAction = null;
            this.TextBoxEmail.LabelText = "E-mailadres:";
            this.TextBoxEmail.Location = new System.Drawing.Point(0, 219);
            this.TextBoxEmail.Margin = new System.Windows.Forms.Padding(0);
            this.TextBoxEmail.Name = "TextBoxEmail";
            this.TextBoxEmail.Size = new System.Drawing.Size(279, 25);
            this.TextBoxEmail.TabIndex = 8;
            // 
            // TextBoxPhone
            // 
            this.TextBoxPhone.AutoSize = true;
            this.TextBoxPhone.ClearButtonAction = null;
            this.TextBoxPhone.LabelText = "Telefoon:";
            this.TextBoxPhone.Location = new System.Drawing.Point(0, 194);
            this.TextBoxPhone.Margin = new System.Windows.Forms.Padding(0);
            this.TextBoxPhone.Name = "TextBoxPhone";
            this.TextBoxPhone.Size = new System.Drawing.Size(279, 25);
            this.TextBoxPhone.TabIndex = 7;
            // 
            // TextBoxPostalCode
            // 
            this.TextBoxPostalCode.AutoSize = true;
            this.TextBoxPostalCode.ClearButtonAction = null;
            this.TextBoxPostalCode.LabelText = "Postcode:";
            this.TextBoxPostalCode.Location = new System.Drawing.Point(0, 168);
            this.TextBoxPostalCode.Margin = new System.Windows.Forms.Padding(0);
            this.TextBoxPostalCode.Name = "TextBoxPostalCode";
            this.TextBoxPostalCode.Size = new System.Drawing.Size(279, 25);
            this.TextBoxPostalCode.TabIndex = 6;
            // 
            // TextBoxCity
            // 
            this.TextBoxCity.AutoSize = true;
            this.TextBoxCity.ClearButtonAction = null;
            this.TextBoxCity.LabelText = "Woonplaats:";
            this.TextBoxCity.Location = new System.Drawing.Point(0, 143);
            this.TextBoxCity.Margin = new System.Windows.Forms.Padding(0);
            this.TextBoxCity.Name = "TextBoxCity";
            this.TextBoxCity.Size = new System.Drawing.Size(279, 25);
            this.TextBoxCity.TabIndex = 5;
            // 
            // TextBoxHouseNumber
            // 
            this.TextBoxHouseNumber.AutoSize = true;
            this.TextBoxHouseNumber.ClearButtonAction = null;
            this.TextBoxHouseNumber.LabelText = "Huisnummer:";
            this.TextBoxHouseNumber.Location = new System.Drawing.Point(14, 118);
            this.TextBoxHouseNumber.Margin = new System.Windows.Forms.Padding(0);
            this.TextBoxHouseNumber.Name = "TextBoxHouseNumber";
            this.TextBoxHouseNumber.Size = new System.Drawing.Size(265, 25);
            this.TextBoxHouseNumber.TabIndex = 4;
            // 
            // TextBoxStreet
            // 
            this.TextBoxStreet.AutoSize = true;
            this.TextBoxStreet.ClearButtonAction = null;
            this.TextBoxStreet.LabelText = "Straat:";
            this.TextBoxStreet.Location = new System.Drawing.Point(57, 93);
            this.TextBoxStreet.Margin = new System.Windows.Forms.Padding(0);
            this.TextBoxStreet.Name = "TextBoxStreet";
            this.TextBoxStreet.Size = new System.Drawing.Size(222, 25);
            this.TextBoxStreet.TabIndex = 3;
            // 
            // TextBoxLastName
            // 
            this.TextBoxLastName.AutoSize = true;
            this.TextBoxLastName.ClearButtonAction = null;
            this.TextBoxLastName.LabelText = "Achternaam:";
            this.TextBoxLastName.Location = new System.Drawing.Point(0, 68);
            this.TextBoxLastName.Margin = new System.Windows.Forms.Padding(0);
            this.TextBoxLastName.Name = "TextBoxLastName";
            this.TextBoxLastName.Size = new System.Drawing.Size(279, 25);
            this.TextBoxLastName.TabIndex = 2;
            // 
            // TextBoxInsertion
            // 
            this.TextBoxInsertion.AutoSize = true;
            this.TextBoxInsertion.ClearButtonAction = null;
            this.TextBoxInsertion.LabelText = "Tussenvoegsel:";
            this.TextBoxInsertion.Location = new System.Drawing.Point(0, 43);
            this.TextBoxInsertion.Margin = new System.Windows.Forms.Padding(0);
            this.TextBoxInsertion.Name = "TextBoxInsertion";
            this.TextBoxInsertion.Size = new System.Drawing.Size(279, 25);
            this.TextBoxInsertion.TabIndex = 1;
            // 
            // TextBoxName
            // 
            this.TextBoxName.AutoSize = true;
            this.TextBoxName.ClearButtonAction = null;
            this.TextBoxName.LabelText = "Naam:";
            this.TextBoxName.Location = new System.Drawing.Point(0, 18);
            this.TextBoxName.Margin = new System.Windows.Forms.Padding(0);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(279, 25);
            this.TextBoxName.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.buttonCancel);
            this.panelBottom.Controls.Add(this.buttonSave);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 250);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(504, 36);
            this.panelBottom.TabIndex = 1;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.Location = new System.Drawing.Point(204, 2);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 24);
            this.buttonCancel.TabIndex = 32;
            this.buttonCancel.Text = "Annuleren";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Location = new System.Drawing.Point(124, 2);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 24);
            this.buttonSave.TabIndex = 31;
            this.buttonSave.Text = "Opslaan";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // ViewReserveeDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ViewReserveeDetail";
            this.Size = new System.Drawing.Size(504, 286);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public SharedClasses.Controls.WinForms.NamedClearableTextBox TextBoxName;
        public SharedClasses.Controls.WinForms.NamedClearableTextBox TextBoxEmail;
        public SharedClasses.Controls.WinForms.NamedClearableTextBox TextBoxPhone;
        public SharedClasses.Controls.WinForms.NamedClearableTextBox TextBoxPostalCode;
        public SharedClasses.Controls.WinForms.NamedClearableTextBox TextBoxCity;
        public SharedClasses.Controls.WinForms.NamedClearableTextBox TextBoxStreet;
        public SharedClasses.Controls.WinForms.NamedClearableTextBox TextBoxInsertion;
        public SharedClasses.Controls.WinForms.NamedClearableTextBox TextBoxLastName;
        public SharedClasses.Controls.WinForms.NamedClearableTextBox TextBoxHouseNumber;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
    }
}
