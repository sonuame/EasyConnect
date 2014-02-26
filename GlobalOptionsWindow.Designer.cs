namespace EasyConnect
{
    partial class GlobalOptionsWindow
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
			this._defaultProtocolLabel = new System.Windows.Forms.Label();
			this._generalLabel = new System.Windows.Forms.Label();
			this._defaultProtocolDropdown = new System.Windows.Forms.ComboBox();
			this._autoHideCheckbox = new System.Windows.Forms.CheckBox();
			this._autoHideLabel = new System.Windows.Forms.Label();
			this._encryptionTypeDropdown = new System.Windows.Forms.ComboBox();
			this._encryptionTypeLabel = new System.Windows.Forms.Label();
			this._titleLabel = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this._appDataFolderRadioButton = new System.Windows.Forms.RadioButton();
			this._sharedLocationRadioButton = new System.Windows.Forms.RadioButton();
			this._sharedLocationTextBox = new System.Windows.Forms.TextBox();
			this._sharedLocationBrowseButton = new System.Windows.Forms.Button();
			this._bookmarksLocationLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// _defaultProtocolLabel
			// 
			this._defaultProtocolLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._defaultProtocolLabel.Location = new System.Drawing.Point(47, 102);
			this._defaultProtocolLabel.Name = "_defaultProtocolLabel";
			this._defaultProtocolLabel.Size = new System.Drawing.Size(174, 20);
			this._defaultProtocolLabel.TabIndex = 65;
			this._defaultProtocolLabel.Text = "Default protocol:";
			this._defaultProtocolLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _generalLabel
			// 
			this._generalLabel.AutoSize = true;
			this._generalLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._generalLabel.Location = new System.Drawing.Point(26, 75);
			this._generalLabel.Name = "_generalLabel";
			this._generalLabel.Size = new System.Drawing.Size(53, 17);
			this._generalLabel.TabIndex = 67;
			this._generalLabel.Text = "General";
			// 
			// _defaultProtocolDropdown
			// 
			this._defaultProtocolDropdown.BackColor = System.Drawing.SystemColors.Control;
			this._defaultProtocolDropdown.DisplayMember = "ProtocolTitle";
			this._defaultProtocolDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._defaultProtocolDropdown.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._defaultProtocolDropdown.ForeColor = System.Drawing.SystemColors.ControlText;
			this._defaultProtocolDropdown.FormattingEnabled = true;
			this._defaultProtocolDropdown.Location = new System.Drawing.Point(227, 101);
			this._defaultProtocolDropdown.Name = "_defaultProtocolDropdown";
			this._defaultProtocolDropdown.Size = new System.Drawing.Size(182, 21);
			this._defaultProtocolDropdown.TabIndex = 68;
			// 
			// _autoHideCheckbox
			// 
			this._autoHideCheckbox.AutoSize = true;
			this._autoHideCheckbox.ForeColor = System.Drawing.SystemColors.ControlText;
			this._autoHideCheckbox.Location = new System.Drawing.Point(228, 130);
			this._autoHideCheckbox.Name = "_autoHideCheckbox";
			this._autoHideCheckbox.Size = new System.Drawing.Size(15, 14);
			this._autoHideCheckbox.TabIndex = 69;
			this._autoHideCheckbox.UseVisualStyleBackColor = true;
			// 
			// _autoHideLabel
			// 
			this._autoHideLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this._autoHideLabel.Location = new System.Drawing.Point(47, 125);
			this._autoHideLabel.Name = "_autoHideLabel";
			this._autoHideLabel.Size = new System.Drawing.Size(174, 20);
			this._autoHideLabel.TabIndex = 70;
			this._autoHideLabel.Text = "Auto-hide connection toolbar?:";
			this._autoHideLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _encryptionTypeDropdown
			// 
			this._encryptionTypeDropdown.BackColor = System.Drawing.SystemColors.Control;
			this._encryptionTypeDropdown.DisplayMember = "Text";
			this._encryptionTypeDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._encryptionTypeDropdown.ForeColor = System.Drawing.SystemColors.ControlText;
			this._encryptionTypeDropdown.FormattingEnabled = true;
			this._encryptionTypeDropdown.Location = new System.Drawing.Point(227, 149);
			this._encryptionTypeDropdown.Name = "_encryptionTypeDropdown";
			this._encryptionTypeDropdown.Size = new System.Drawing.Size(182, 21);
			this._encryptionTypeDropdown.TabIndex = 71;
			this._encryptionTypeDropdown.ValueMember = "Value";
			this._encryptionTypeDropdown.SelectedIndexChanged += new System.EventHandler(this._encryptionTypeDropdown_SelectedIndexChanged);
			// 
			// _encryptionTypeLabel
			// 
			this._encryptionTypeLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this._encryptionTypeLabel.Location = new System.Drawing.Point(48, 149);
			this._encryptionTypeLabel.Name = "_encryptionTypeLabel";
			this._encryptionTypeLabel.Size = new System.Drawing.Size(173, 20);
			this._encryptionTypeLabel.TabIndex = 72;
			this._encryptionTypeLabel.Text = "Encryption type:";
			this._encryptionTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _titleLabel
			// 
			this._titleLabel.AutoSize = true;
			this._titleLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._titleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(97)))), ((int)(((byte)(102)))));
			this._titleLabel.Location = new System.Drawing.Point(24, 19);
			this._titleLabel.Name = "_titleLabel";
			this._titleLabel.Size = new System.Drawing.Size(151, 30);
			this._titleLabel.TabIndex = 73;
			this._titleLabel.Text = "Global Options";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BackColor = System.Drawing.Color.Silver;
			this.panel1.Location = new System.Drawing.Point(29, 62);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(544, 1);
			this.panel1.TabIndex = 74;
			// 
			// _appDataFolderRadioButton
			// 
			this._appDataFolderRadioButton.AutoSize = true;
			this._appDataFolderRadioButton.Location = new System.Drawing.Point(227, 176);
			this._appDataFolderRadioButton.Name = "_appDataFolderRadioButton";
			this._appDataFolderRadioButton.Size = new System.Drawing.Size(142, 17);
			this._appDataFolderRadioButton.TabIndex = 75;
			this._appDataFolderRadioButton.TabStop = true;
			this._appDataFolderRadioButton.Text = "User\'s AppData directory";
			this._appDataFolderRadioButton.UseVisualStyleBackColor = true;
			this._appDataFolderRadioButton.CheckedChanged += new System.EventHandler(this._appDataFolderRadioButton_CheckedChanged);
			// 
			// _sharedLocationRadioButton
			// 
			this._sharedLocationRadioButton.AutoSize = true;
			this._sharedLocationRadioButton.Location = new System.Drawing.Point(228, 200);
			this._sharedLocationRadioButton.Name = "_sharedLocationRadioButton";
			this._sharedLocationRadioButton.Size = new System.Drawing.Size(107, 17);
			this._sharedLocationRadioButton.TabIndex = 76;
			this._sharedLocationRadioButton.TabStop = true;
			this._sharedLocationRadioButton.Text = "A shared location";
			this._sharedLocationRadioButton.UseVisualStyleBackColor = true;
			// 
			// _sharedLocationTextBox
			// 
			this._sharedLocationTextBox.Enabled = false;
			this._sharedLocationTextBox.Location = new System.Drawing.Point(245, 226);
			this._sharedLocationTextBox.Name = "_sharedLocationTextBox";
			this._sharedLocationTextBox.Size = new System.Drawing.Size(191, 20);
			this._sharedLocationTextBox.TabIndex = 77;
			// 
			// _sharedLocationBrowseButton
			// 
			this._sharedLocationBrowseButton.Enabled = false;
			this._sharedLocationBrowseButton.Location = new System.Drawing.Point(441, 224);
			this._sharedLocationBrowseButton.Name = "_sharedLocationBrowseButton";
			this._sharedLocationBrowseButton.Size = new System.Drawing.Size(24, 23);
			this._sharedLocationBrowseButton.TabIndex = 78;
			this._sharedLocationBrowseButton.Text = "...";
			this._sharedLocationBrowseButton.UseVisualStyleBackColor = true;
			// 
			// _bookmarksLocationLabel
			// 
			this._bookmarksLocationLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this._bookmarksLocationLabel.Location = new System.Drawing.Point(48, 176);
			this._bookmarksLocationLabel.Name = "_bookmarksLocationLabel";
			this._bookmarksLocationLabel.Size = new System.Drawing.Size(173, 20);
			this._bookmarksLocationLabel.TabIndex = 79;
			this._bookmarksLocationLabel.Text = "Bookmarks location:";
			this._bookmarksLocationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// GlobalOptionsWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
			this.ClientSize = new System.Drawing.Size(597, 384);
			this.Controls.Add(this._bookmarksLocationLabel);
			this.Controls.Add(this._sharedLocationBrowseButton);
			this.Controls.Add(this._sharedLocationTextBox);
			this.Controls.Add(this._sharedLocationRadioButton);
			this.Controls.Add(this._appDataFolderRadioButton);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this._titleLabel);
			this.Controls.Add(this._encryptionTypeLabel);
			this.Controls.Add(this._encryptionTypeDropdown);
			this.Controls.Add(this._autoHideLabel);
			this.Controls.Add(this._autoHideCheckbox);
			this.Controls.Add(this._defaultProtocolLabel);
			this.Controls.Add(this._generalLabel);
			this.Controls.Add(this._defaultProtocolDropdown);
			this.Name = "GlobalOptionsWindow";
			this.Text = "Global Options";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GlobalOptionsWindow_FormClosing);
			this.Shown += new System.EventHandler(this.GlobalOptionsWindow_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _defaultProtocolLabel;
        private System.Windows.Forms.Label _generalLabel;
        private System.Windows.Forms.ComboBox _defaultProtocolDropdown;
        private System.Windows.Forms.CheckBox _autoHideCheckbox;
        private System.Windows.Forms.Label _autoHideLabel;
        private System.Windows.Forms.ComboBox _encryptionTypeDropdown;
        private System.Windows.Forms.Label _encryptionTypeLabel;
		private System.Windows.Forms.Label _titleLabel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton _appDataFolderRadioButton;
		private System.Windows.Forms.RadioButton _sharedLocationRadioButton;
		private System.Windows.Forms.TextBox _sharedLocationTextBox;
		private System.Windows.Forms.Button _sharedLocationBrowseButton;
		private System.Windows.Forms.Label _bookmarksLocationLabel;
    }
}