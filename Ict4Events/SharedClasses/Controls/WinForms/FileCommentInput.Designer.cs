namespace SharedClasses.Controls.WinForms
{
    partial class FileCommentInput
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
            this.CommentTextBox.Location = new System.Drawing.Point(6, 20);
            this.CommentTextBox.Multiline = true;
            this.CommentTextBox.Name = "CommentTextBox";
            this.CommentTextBox.Size = new System.Drawing.Size(382, 53);
            this.CommentTextBox.TabIndex = 1;
            // 
            // SendCommentButton
            // 
            this.SendCommentButton.Location = new System.Drawing.Point(313, 79);
            this.SendCommentButton.Name = "SendCommentButton";
            this.SendCommentButton.Size = new System.Drawing.Size(75, 23);
            this.SendCommentButton.TabIndex = 2;
            this.SendCommentButton.Text = "Verstuur";
            this.SendCommentButton.UseVisualStyleBackColor = true;
            // 
            // LabelTextLength
            // 
            this.LabelTextLength.AutoSize = true;
            this.LabelTextLength.Location = new System.Drawing.Point(3, 84);
            this.LabelTextLength.Name = "LabelTextLength";
            this.LabelTextLength.Size = new System.Drawing.Size(36, 13);
            this.LabelTextLength.TabIndex = 3;
            this.LabelTextLength.Text = "0/140";
            // 
            // FileCommentInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LabelTextLength);
            this.Controls.Add(this.SendCommentButton);
            this.Controls.Add(this.CommentTextBox);
            this.Controls.Add(this.label1);
            this.Name = "FileCommentInput";
            this.Size = new System.Drawing.Size(391, 105);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox CommentTextBox;
        public System.Windows.Forms.Button SendCommentButton;
        public System.Windows.Forms.Label LabelTextLength;
    }
}
