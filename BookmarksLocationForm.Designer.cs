namespace EasyConnect
{
	partial class BookmarksLocationForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookmarksLocationForm));
			this._descriptionLabel = new System.Windows.Forms.Label();
			this._userFolderRadioButton = new System.Windows.Forms.RadioButton();
			this._userFolderDescriptionLabel = new System.Windows.Forms.Label();
			this._sharedFileRadioButton = new System.Windows.Forms.RadioButton();
			this._sharedFileDescriptionLabel = new System.Windows.Forms.Label();
			this._sharedFilePathTextBox = new System.Windows.Forms.TextBox();
			this._sharedFilePathBrowseButton = new System.Windows.Forms.Button();
			this._sharedFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// _descriptionLabel
			// 
			this._descriptionLabel.AutoSize = true;
			this._descriptionLabel.Location = new System.Drawing.Point(13, 13);
			this._descriptionLabel.Name = "_descriptionLabel";
			this._descriptionLabel.Size = new System.Drawing.Size(306, 13);
			this._descriptionLabel.TabIndex = 0;
			this._descriptionLabel.Text = "You\'ll need to choose where you want to store your bookmarks:";
			// 
			// _userFolderRadioButton
			// 
			this._userFolderRadioButton.AutoSize = true;
			this._userFolderRadioButton.Checked = true;
			this._userFolderRadioButton.Location = new System.Drawing.Point(16, 43);
			this._userFolderRadioButton.Name = "_userFolderRadioButton";
			this._userFolderRadioButton.Size = new System.Drawing.Size(198, 17);
			this._userFolderRadioButton.TabIndex = 1;
			this._userFolderRadioButton.TabStop = true;
			this._userFolderRadioButton.Text = "Your user\'s application data directory";
			this._userFolderRadioButton.UseVisualStyleBackColor = true;
			this._userFolderRadioButton.CheckedChanged += new System.EventHandler(this._userFolderRadioButton_CheckedChanged);
			// 
			// _userFolderDescriptionLabel
			// 
			this._userFolderDescriptionLabel.AutoSize = true;
			this._userFolderDescriptionLabel.Location = new System.Drawing.Point(31, 63);
			this._userFolderDescriptionLabel.Name = "_userFolderDescriptionLabel";
			this._userFolderDescriptionLabel.Size = new System.Drawing.Size(359, 26);
			this._userFolderDescriptionLabel.TabIndex = 2;
			this._userFolderDescriptionLabel.Text = "This will store the bookmarks file in your user\'s application data directory at \r" +
    "\n%HOME%\\AppData\\Local\\EasyConnect.";
			// 
			// _sharedFileRadioButton
			// 
			this._sharedFileRadioButton.AutoSize = true;
			this._sharedFileRadioButton.Location = new System.Drawing.Point(16, 108);
			this._sharedFileRadioButton.Name = "_sharedFileRadioButton";
			this._sharedFileRadioButton.Size = new System.Drawing.Size(83, 17);
			this._sharedFileRadioButton.TabIndex = 3;
			this._sharedFileRadioButton.TabStop = true;
			this._sharedFileRadioButton.Text = "A shared file";
			this._sharedFileRadioButton.UseVisualStyleBackColor = true;
			this._sharedFileRadioButton.CheckedChanged += new System.EventHandler(this._sharedFileRadioButton_CheckedChanged);
			// 
			// _sharedFileDescriptionLabel
			// 
			this._sharedFileDescriptionLabel.AutoSize = true;
			this._sharedFileDescriptionLabel.Location = new System.Drawing.Point(31, 128);
			this._sharedFileDescriptionLabel.Name = "_sharedFileDescriptionLabel";
			this._sharedFileDescriptionLabel.Size = new System.Drawing.Size(532, 39);
			this._sharedFileDescriptionLabel.TabIndex = 4;
			this._sharedFileDescriptionLabel.Text = resources.GetString("_sharedFileDescriptionLabel.Text");
			// 
			// _sharedFilePathTextBox
			// 
			this._sharedFilePathTextBox.Enabled = false;
			this._sharedFilePathTextBox.Location = new System.Drawing.Point(34, 180);
			this._sharedFilePathTextBox.Name = "_sharedFilePathTextBox";
			this._sharedFilePathTextBox.Size = new System.Drawing.Size(235, 20);
			this._sharedFilePathTextBox.TabIndex = 5;
			// 
			// _sharedFilePathBrowseButton
			// 
			this._sharedFilePathBrowseButton.Enabled = false;
			this._sharedFilePathBrowseButton.Location = new System.Drawing.Point(274, 178);
			this._sharedFilePathBrowseButton.Name = "_sharedFilePathBrowseButton";
			this._sharedFilePathBrowseButton.Size = new System.Drawing.Size(24, 23);
			this._sharedFilePathBrowseButton.TabIndex = 6;
			this._sharedFilePathBrowseButton.Text = "...";
			this._sharedFilePathBrowseButton.UseVisualStyleBackColor = true;
			this._sharedFilePathBrowseButton.Click += new System.EventHandler(this._sharedFilePathBrowseButton_Click);
			// 
			// _sharedFileDialog
			// 
			this._sharedFileDialog.CheckFileExists = false;
			this._sharedFileDialog.FileName = "Bookmarks.xml";
			this._sharedFileDialog.Filter = "Bookmarks files|*.xml|All files|*.*";
			// 
			// BookmarksLocationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(596, 348);
			this.Controls.Add(this._sharedFilePathBrowseButton);
			this.Controls.Add(this._sharedFilePathTextBox);
			this.Controls.Add(this._sharedFileDescriptionLabel);
			this.Controls.Add(this._sharedFileRadioButton);
			this.Controls.Add(this._userFolderDescriptionLabel);
			this.Controls.Add(this._userFolderRadioButton);
			this.Controls.Add(this._descriptionLabel);
			this.Name = "BookmarksLocationForm";
			this.Text = "Bookmarks Location Form";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label _descriptionLabel;
		private System.Windows.Forms.RadioButton _userFolderRadioButton;
		private System.Windows.Forms.Label _userFolderDescriptionLabel;
		private System.Windows.Forms.RadioButton _sharedFileRadioButton;
		private System.Windows.Forms.Label _sharedFileDescriptionLabel;
		private System.Windows.Forms.TextBox _sharedFilePathTextBox;
		private System.Windows.Forms.Button _sharedFilePathBrowseButton;
		private System.Windows.Forms.OpenFileDialog _sharedFileDialog;
	}
}