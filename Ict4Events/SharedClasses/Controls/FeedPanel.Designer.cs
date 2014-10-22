namespace SharedClasses.Controls
{
    partial class FeedPanel
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelYourMessage = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonPost = new System.Windows.Forms.Button();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.CausesValidation = false;
            this.panel1.Controls.Add(this.textBoxInput);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.labelYourMessage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 208);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 109);
            this.panel1.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(305, 208);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // labelYourMessage
            // 
            this.labelYourMessage.AutoSize = true;
            this.labelYourMessage.Location = new System.Drawing.Point(3, 3);
            this.labelYourMessage.Name = "labelYourMessage";
            this.labelYourMessage.Size = new System.Drawing.Size(105, 13);
            this.labelYourMessage.TabIndex = 3;
            this.labelYourMessage.Text = "[YOUR_MESSAGE]:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonPost);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 79);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(305, 30);
            this.panel2.TabIndex = 10;
            // 
            // buttonPost
            // 
            this.buttonPost.Location = new System.Drawing.Point(229, 3);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(75, 23);
            this.buttonPost.TabIndex = 5;
            this.buttonPost.Text = "Post";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // textBoxInput
            // 
            this.textBoxInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxInput.Location = new System.Drawing.Point(0, 22);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxInput.Size = new System.Drawing.Size(305, 57);
            this.textBoxInput.TabIndex = 11;
            // 
            // FeedPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "FeedPanel";
            this.Size = new System.Drawing.Size(305, 317);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelYourMessage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonPost;

    }
}
