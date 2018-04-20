namespace IRCSharp
{
    partial class ConnectForm
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
            this.HostnameLabel = new System.Windows.Forms.Label();
            this.connectLabel = new System.Windows.Forms.Label();
            this.HostnameInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NicknameInput = new System.Windows.Forms.TextBox();
            this.nickNameLabel = new System.Windows.Forms.Label();
            this.AutojoinInput = new System.Windows.Forms.TextBox();
            this.autoJoinChannelLabel = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HostnameLabel
            // 
            this.HostnameLabel.Location = new System.Drawing.Point(12, 73);
            this.HostnameLabel.Name = "HostnameLabel";
            this.HostnameLabel.Size = new System.Drawing.Size(452, 23);
            this.HostnameLabel.TabIndex = 0;
            this.HostnameLabel.Text = "Hostname";
            this.HostnameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // connectLabel
            // 
            this.connectLabel.BackColor = System.Drawing.SystemColors.Control;
            this.connectLabel.Location = new System.Drawing.Point(15, 9);
            this.connectLabel.Name = "connectLabel";
            this.connectLabel.Size = new System.Drawing.Size(449, 23);
            this.connectLabel.TabIndex = 1;
            this.connectLabel.Text = "Connection";
            this.connectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HostnameInput
            // 
            this.HostnameInput.Location = new System.Drawing.Point(12, 99);
            this.HostnameInput.Name = "HostnameInput";
            this.HostnameInput.Size = new System.Drawing.Size(455, 22);
            this.HostnameInput.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(452, 2);
            this.label1.TabIndex = 4;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NicknameInput
            // 
            this.NicknameInput.Location = new System.Drawing.Point(12, 172);
            this.NicknameInput.Name = "NicknameInput";
            this.NicknameInput.Size = new System.Drawing.Size(455, 22);
            this.NicknameInput.TabIndex = 6;
            // 
            // nickNameLabel
            // 
            this.nickNameLabel.Location = new System.Drawing.Point(12, 146);
            this.nickNameLabel.Name = "nickNameLabel";
            this.nickNameLabel.Size = new System.Drawing.Size(452, 23);
            this.nickNameLabel.TabIndex = 5;
            this.nickNameLabel.Text = "Nickname";
            this.nickNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AutojoinInput
            // 
            this.AutojoinInput.Location = new System.Drawing.Point(12, 253);
            this.AutojoinInput.Name = "AutojoinInput";
            this.AutojoinInput.Size = new System.Drawing.Size(452, 22);
            this.AutojoinInput.TabIndex = 8;
            // 
            // autoJoinChannelLabel
            // 
            this.autoJoinChannelLabel.Location = new System.Drawing.Point(12, 227);
            this.autoJoinChannelLabel.Name = "autoJoinChannelLabel";
            this.autoJoinChannelLabel.Size = new System.Drawing.Size(452, 23);
            this.autoJoinChannelLabel.TabIndex = 7;
            this.autoJoinChannelLabel.Text = "Autojoin Channel";
            this.autoJoinChannelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(15, 419);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(452, 23);
            this.ConnectButton.TabIndex = 9;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // ConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 454);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.AutojoinInput);
            this.Controls.Add(this.autoJoinChannelLabel);
            this.Controls.Add(this.NicknameInput);
            this.Controls.Add(this.nickNameLabel);
            this.Controls.Add(this.HostnameInput);
            this.Controls.Add(this.connectLabel);
            this.Controls.Add(this.HostnameLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ConnectForm";
            this.Text = "Connect";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HostnameLabel;
        private System.Windows.Forms.Label connectLabel;
        private System.Windows.Forms.TextBox HostnameInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NicknameInput;
        private System.Windows.Forms.Label nickNameLabel;
        private System.Windows.Forms.TextBox AutojoinInput;
        private System.Windows.Forms.Label autoJoinChannelLabel;
        private System.Windows.Forms.Button ConnectButton;
    }
}