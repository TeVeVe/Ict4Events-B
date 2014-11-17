namespace SharedClasses.Controls.WinForms
{
    partial class VisitorInfoPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.DateTimeBirthDate = new System.Windows.Forms.DateTimePicker();
            this.TextBoxPhoneNumber = new SharedClasses.Controls.WinForms.NamedClearableTextBox();
            this.TextBoxLastName = new SharedClasses.Controls.WinForms.NamedClearableTextBox();
            this.TextBoxInsertion = new SharedClasses.Controls.WinForms.NamedClearableTextBox();
            this.TextBoxFirstName = new SharedClasses.Controls.WinForms.NamedClearableTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Geboortedag:";
            // 
            // DateTimeBirthDate
            // 
            this.DateTimeBirthDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTimeBirthDate.Location = new System.Drawing.Point(105, 103);
            this.DateTimeBirthDate.Name = "DateTimeBirthDate";
            this.DateTimeBirthDate.Size = new System.Drawing.Size(174, 20);
            this.DateTimeBirthDate.TabIndex = 2;
            // 
            // TextBoxPhoneNumber
            // 
            this.TextBoxPhoneNumber.AutoSize = true;
            this.TextBoxPhoneNumber.ClearButtonAction = null;
            this.TextBoxPhoneNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextBoxPhoneNumber.LabelText = "Telefoonnummer:";
            this.TextBoxPhoneNumber.Location = new System.Drawing.Point(0, 75);
            this.TextBoxPhoneNumber.Margin = new System.Windows.Forms.Padding(0);
            this.TextBoxPhoneNumber.Name = "TextBoxPhoneNumber";
            this.TextBoxPhoneNumber.Size = new System.Drawing.Size(279, 25);
            this.TextBoxPhoneNumber.TabIndex = 3;
            // 
            // TextBoxLastName
            // 
            this.TextBoxLastName.AutoSize = true;
            this.TextBoxLastName.ClearButtonAction = null;
            this.TextBoxLastName.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextBoxLastName.LabelText = "Achternaam:";
            this.TextBoxLastName.Location = new System.Drawing.Point(0, 50);
            this.TextBoxLastName.Margin = new System.Windows.Forms.Padding(0);
            this.TextBoxLastName.Name = "TextBoxLastName";
            this.TextBoxLastName.Size = new System.Drawing.Size(279, 25);
            this.TextBoxLastName.TabIndex = 4;
            // 
            // TextBoxInsertion
            // 
            this.TextBoxInsertion.AutoSize = true;
            this.TextBoxInsertion.ClearButtonAction = null;
            this.TextBoxInsertion.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextBoxInsertion.LabelText = "Tussenvoegsel:";
            this.TextBoxInsertion.Location = new System.Drawing.Point(0, 25);
            this.TextBoxInsertion.Margin = new System.Windows.Forms.Padding(0);
            this.TextBoxInsertion.Name = "TextBoxInsertion";
            this.TextBoxInsertion.Size = new System.Drawing.Size(279, 25);
            this.TextBoxInsertion.TabIndex = 5;
            // 
            // TextBoxFirstName
            // 
            this.TextBoxFirstName.AutoSize = true;
            this.TextBoxFirstName.ClearButtonAction = null;
            this.TextBoxFirstName.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextBoxFirstName.LabelText = "Voornaam:";
            this.TextBoxFirstName.Location = new System.Drawing.Point(0, 0);
            this.TextBoxFirstName.Margin = new System.Windows.Forms.Padding(0);
            this.TextBoxFirstName.Name = "TextBoxFirstName";
            this.TextBoxFirstName.Size = new System.Drawing.Size(279, 25);
            this.TextBoxFirstName.TabIndex = 6;
            // 
            // VisitorInfoPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBoxPhoneNumber);
            this.Controls.Add(this.TextBoxLastName);
            this.Controls.Add(this.TextBoxInsertion);
            this.Controls.Add(this.TextBoxFirstName);
            this.Controls.Add(this.DateTimeBirthDate);
            this.Controls.Add(this.label1);
            this.Name = "VisitorInfoPanel";
            this.Size = new System.Drawing.Size(279, 135);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DateTimeBirthDate;
        private NamedClearableTextBox TextBoxPhoneNumber;
        private NamedClearableTextBox TextBoxLastName;
        private NamedClearableTextBox TextBoxInsertion;
        private NamedClearableTextBox TextBoxFirstName;
    }
}
