namespace SharedClasses.Controls.WinForms
{
    partial class CommentInput
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
            this.CommentTextBox = new System.Windows.Forms.TextBox();
            this.SendCommentButton = new System.Windows.Forms.Button();
            this.LabelTextLength = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reageer";
            // 
            // CommentTextBox
            // 
            this.CommentTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommentTextBox.Location = new System.Drawing.Point(0, 26);
            this.CommentTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.CommentTextBox.Multiline = true;
            this.CommentTextBox.Name = "CommentTextBox";
            this.CommentTextBox.Size = new System.Drawing.Size(280, 53);
            this.CommentTextBox.TabIndex = 1;
            this.CommentTextBox.TextChanged += new System.EventHandler(this.CommentTextBox_TextChanged);
            // 
            // SendCommentButton
            // 
            this.SendCommentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SendCommentButton.Location = new System.Drawing.Point(205, 3);
            this.SendCommentButton.Name = "SendCommentButton";
            this.SendCommentButton.Size = new System.Drawing.Size(75, 23);
            this.SendCommentButton.TabIndex = 2;
            this.SendCommentButton.Text = "Verstuur";
            this.SendCommentButton.UseVisualStyleBackColor = true;
            // 
            // LabelTextLength
            // 
            this.LabelTextLength.AutoSize = true;
            this.LabelTextLength.Location = new System.Drawing.Point(3, 8);
            this.LabelTextLength.Name = "LabelTextLength";
            this.LabelTextLength.Size = new System.Drawing.Size(36, 13);
            this.LabelTextLength.TabIndex = 3;
            this.LabelTextLength.Text = "0/140";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SendCommentButton);
            this.panel1.Controls.Add(this.LabelTextLength);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 26);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 26);
            this.panel2.TabIndex = 5;
            // 
            // CommentInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CommentTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MinimumSize = new System.Drawing.Size(280, 105);
            this.Name = "CommentInput";
            this.Size = new System.Drawing.Size(280, 105);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox CommentTextBox;
        public System.Windows.Forms.Button SendCommentButton;
        public System.Windows.Forms.Label LabelTextLength;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
