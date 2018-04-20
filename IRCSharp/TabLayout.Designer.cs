namespace IRCSharp
{
    partial class TabLayout
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.userListBox = new System.Windows.Forms.ListBox();
            this.chatBox = new System.Windows.Forms.TextBox();
            this.ChatDisplay = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(716, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Users";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // userListBox
            // 
            this.userListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userListBox.FormattingEnabled = true;
            this.userListBox.IntegralHeight = false;
            this.userListBox.ItemHeight = 16;
            this.userListBox.Location = new System.Drawing.Point(716, 28);
            this.userListBox.Name = "userListBox";
            this.userListBox.Size = new System.Drawing.Size(166, 500);
            this.userListBox.TabIndex = 6;
            // 
            // chatBox
            // 
            this.chatBox.AcceptsReturn = true;
            this.chatBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.chatBox.Location = new System.Drawing.Point(12, 534);
            this.chatBox.Name = "chatBox";
            this.chatBox.Size = new System.Drawing.Size(870, 32);
            this.chatBox.TabIndex = 5;
            this.chatBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.chatBox_KeyUp);
            // 
            // ChatDisplay
            // 
            this.ChatDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatDisplay.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ChatDisplay.Location = new System.Drawing.Point(12, 28);
            this.ChatDisplay.Name = "ChatDisplay";
            this.ChatDisplay.ReadOnly = true;
            this.ChatDisplay.Size = new System.Drawing.Size(698, 500);
            this.ChatDisplay.TabIndex = 4;
            this.ChatDisplay.Text = "";
            // 
            // TabLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 570);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userListBox);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.ChatDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TabLayout";
            this.Text = "TabLayoutcs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox userListBox;
        private System.Windows.Forms.TextBox chatBox;
        private System.Windows.Forms.RichTextBox ChatDisplay;
    }
}