namespace ReservationSystem.Views
{
    partial class ViewEvents
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
            this.label2 = new System.Windows.Forms.Label();
            this.DateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.DateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonDeleteEvent = new System.Windows.Forms.Button();
            this.buttonAddEvent = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.TextBoxPostalCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TextBoxCity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.TextBoxHouseNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.TextBoxStreet = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDelName = new System.Windows.Forms.Button();
            this.TextBoxEventName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DataGridEvents = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 136);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Startdatum:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DateTimePickerStartDate
            // 
            this.DateTimePickerStartDate.Location = new System.Drawing.Point(102, 132);
            this.DateTimePickerStartDate.Margin = new System.Windows.Forms.Padding(2);
            this.DateTimePickerStartDate.Name = "DateTimePickerStartDate";
            this.DateTimePickerStartDate.Size = new System.Drawing.Size(184, 20);
            this.DateTimePickerStartDate.TabIndex = 9;
            this.DateTimePickerStartDate.Value = new System.DateTime(2014, 11, 8, 0, 0, 0, 0);
            // 
            // DateTimePickerEndDate
            // 
            this.DateTimePickerEndDate.Location = new System.Drawing.Point(102, 156);
            this.DateTimePickerEndDate.Margin = new System.Windows.Forms.Padding(2);
            this.DateTimePickerEndDate.Name = "DateTimePickerEndDate";
            this.DateTimePickerEndDate.Size = new System.Drawing.Size(184, 20);
            this.DateTimePickerEndDate.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 160);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Einddatum:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonDeleteEvent
            // 
            this.buttonDeleteEvent.Location = new System.Drawing.Point(80, 5);
            this.buttonDeleteEvent.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDeleteEvent.Name = "buttonDeleteEvent";
            this.buttonDeleteEvent.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteEvent.TabIndex = 17;
            this.buttonDeleteEvent.Text = "Verwijderen";
            this.buttonDeleteEvent.UseVisualStyleBackColor = true;
            this.buttonDeleteEvent.Click += new System.EventHandler(this.buttonDeleteEvent_Click);
            // 
            // buttonAddEvent
            // 
            this.buttonAddEvent.Location = new System.Drawing.Point(2, 5);
            this.buttonAddEvent.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddEvent.Name = "buttonAddEvent";
            this.buttonAddEvent.Size = new System.Drawing.Size(74, 23);
            this.buttonAddEvent.TabIndex = 18;
            this.buttonAddEvent.Text = "Toevoegen";
            this.buttonAddEvent.UseVisualStyleBackColor = true;
            this.buttonAddEvent.Click += new System.EventHandler(this.buttonAddEvent_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.TextBoxPostalCode);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.TextBoxCity);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.TextBoxHouseNumber);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.TextBoxStreet);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonDelName);
            this.panel1.Controls.Add(this.TextBoxEventName);
            this.panel1.Controls.Add(this.labelName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.DateTimePickerStartDate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.DateTimePickerEndDate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 190);
            this.panel1.TabIndex = 19;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(292, 107);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(28, 20);
            this.button4.TabIndex = 30;
            this.button4.Text = "X";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(292, 81);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(28, 20);
            this.button3.TabIndex = 30;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // TextBoxPostalCode
            // 
            this.TextBoxPostalCode.Location = new System.Drawing.Point(102, 107);
            this.TextBoxPostalCode.Name = "TextBoxPostalCode";
            this.TextBoxPostalCode.Size = new System.Drawing.Size(184, 20);
            this.TextBoxPostalCode.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Postcode:";
            // 
            // TextBoxCity
            // 
            this.TextBoxCity.Location = new System.Drawing.Point(102, 81);
            this.TextBoxCity.Name = "TextBoxCity";
            this.TextBoxCity.Size = new System.Drawing.Size(184, 20);
            this.TextBoxCity.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Plaats:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(292, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 20);
            this.button2.TabIndex = 27;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // TextBoxHouseNumber
            // 
            this.TextBoxHouseNumber.Location = new System.Drawing.Point(102, 55);
            this.TextBoxHouseNumber.Name = "TextBoxHouseNumber";
            this.TextBoxHouseNumber.Size = new System.Drawing.Size(184, 20);
            this.TextBoxHouseNumber.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Huisnummer:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(292, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 20);
            this.button1.TabIndex = 24;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TextBoxStreet
            // 
            this.TextBoxStreet.Location = new System.Drawing.Point(102, 29);
            this.TextBoxStreet.Name = "TextBoxStreet";
            this.TextBoxStreet.Size = new System.Drawing.Size(184, 20);
            this.TextBoxStreet.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Straat:";
            // 
            // buttonDelName
            // 
            this.buttonDelName.Location = new System.Drawing.Point(292, 3);
            this.buttonDelName.Name = "buttonDelName";
            this.buttonDelName.Size = new System.Drawing.Size(28, 20);
            this.buttonDelName.TabIndex = 21;
            this.buttonDelName.Text = "X";
            this.buttonDelName.UseVisualStyleBackColor = true;
            this.buttonDelName.Click += new System.EventHandler(this.buttonDelName_Click);
            // 
            // TextBoxEventName
            // 
            this.TextBoxEventName.Location = new System.Drawing.Point(102, 3);
            this.TextBoxEventName.Name = "TextBoxEventName";
            this.TextBoxEventName.Size = new System.Drawing.Size(184, 20);
            this.TextBoxEventName.TabIndex = 20;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(58, 7);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 19;
            this.labelName.Text = "Name:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonDeleteEvent);
            this.panel2.Controls.Add(this.buttonAddEvent);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 190);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(501, 30);
            this.panel2.TabIndex = 20;
            // 
            // DataGridEvents
            // 
            this.DataGridEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridEvents.Location = new System.Drawing.Point(0, 220);
            this.DataGridEvents.Margin = new System.Windows.Forms.Padding(2);
            this.DataGridEvents.Name = "DataGridEvents";
            this.DataGridEvents.RowTemplate.Height = 24;
            this.DataGridEvents.Size = new System.Drawing.Size(501, 179);
            this.DataGridEvents.TabIndex = 21;
            // 
            // ViewEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataGridEvents);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ViewEvents";
            this.Size = new System.Drawing.Size(501, 399);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridEvents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonDeleteEvent;
        private System.Windows.Forms.Button buttonAddEvent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DataGridView DataGridEvents;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonDelName;
        public System.Windows.Forms.TextBox TextBoxEventName;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox TextBoxHouseNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox TextBoxStreet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.TextBox TextBoxPostalCode;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox TextBoxCity;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DateTimePicker DateTimePickerStartDate;
        public System.Windows.Forms.DateTimePicker DateTimePickerEndDate;

    }
}
