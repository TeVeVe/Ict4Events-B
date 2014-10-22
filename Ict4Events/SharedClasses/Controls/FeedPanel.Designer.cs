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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.panelMessage = new System.Windows.Forms.Panel();
            this.labelYourMessage = new System.Windows.Forms.Label();
            this.panelPost = new System.Windows.Forms.Panel();
            this.buttonPost = new System.Windows.Forms.Button();
            this.flowLayoutPanelFeedPosts = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panelMessage.SuspendLayout();
            this.panelPost.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanelFeedPosts);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBoxInput);
            this.splitContainer1.Panel2.Controls.Add(this.panelMessage);
            this.splitContainer1.Panel2.Controls.Add(this.panelPost);
            this.splitContainer1.Size = new System.Drawing.Size(305, 317);
            this.splitContainer1.SplitterDistance = 198;
            this.splitContainer1.TabIndex = 0;
            // 
            // textBoxInput
            // 
            this.textBoxInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxInput.Location = new System.Drawing.Point(0, 20);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxInput.Size = new System.Drawing.Size(305, 65);
            this.textBoxInput.TabIndex = 24;
            // 
            // panelMessage
            // 
            this.panelMessage.Controls.Add(this.labelYourMessage);
            this.panelMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMessage.Location = new System.Drawing.Point(0, 0);
            this.panelMessage.Name = "panelMessage";
            this.panelMessage.Size = new System.Drawing.Size(305, 20);
            this.panelMessage.TabIndex = 23;
            // 
            // labelYourMessage
            // 
            this.labelYourMessage.AutoSize = true;
            this.labelYourMessage.Location = new System.Drawing.Point(3, 3);
            this.labelYourMessage.Name = "labelYourMessage";
            this.labelYourMessage.Size = new System.Drawing.Size(105, 13);
            this.labelYourMessage.TabIndex = 4;
            this.labelYourMessage.Text = "[YOUR_MESSAGE]:";
            // 
            // panelPost
            // 
            this.panelPost.Controls.Add(this.buttonPost);
            this.panelPost.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPost.Location = new System.Drawing.Point(0, 85);
            this.panelPost.Name = "panelPost";
            this.panelPost.Size = new System.Drawing.Size(305, 30);
            this.panelPost.TabIndex = 22;
            // 
            // buttonPost
            // 
            this.buttonPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPost.AutoSize = true;
            this.buttonPost.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonPost.Location = new System.Drawing.Point(264, 3);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(38, 23);
            this.buttonPost.TabIndex = 5;
            this.buttonPost.Text = "Post";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
            // 
            // flowLayoutPanelFeedPosts
            // 
            this.flowLayoutPanelFeedPosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelFeedPosts.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelFeedPosts.Name = "flowLayoutPanelFeedPosts";
            this.flowLayoutPanelFeedPosts.Size = new System.Drawing.Size(305, 198);
            this.flowLayoutPanelFeedPosts.TabIndex = 5;
            // 
            // FeedPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.splitContainer1);
            this.Name = "FeedPanel";
            this.Size = new System.Drawing.Size(305, 317);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panelMessage.ResumeLayout(false);
            this.panelMessage.PerformLayout();
            this.panelPost.ResumeLayout(false);
            this.panelPost.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFeedPosts;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Panel panelMessage;
        private System.Windows.Forms.Label labelYourMessage;
        private System.Windows.Forms.Panel panelPost;
        private System.Windows.Forms.Button buttonPost;


    }
}
