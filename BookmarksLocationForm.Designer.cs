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
			this.SuspendLayout();
			// 
			// _descriptionLabel
			// 
			this._descriptionLabel.AutoSize = true;
			this._descriptionLabel.Location = new System.Drawing.Point(13, 13);
			this._descriptionLabel.Name = "_descriptionLabel";
			this._descriptionLabel.Size = new System.Drawing.Size(328, 13);
			this._descriptionLabel.TabIndex = 0;
			this._descriptionLabel.Text = "You\'ll also need to choose where you want to store your bookmarks:";
			// 
			// _userFolderRadioButton
			// 
			this._userFolderRadioButton.AutoSize = true;
			this._userFolderRadioButton.Location = new System.Drawing.Point(16, 43);
			this._userFolderRadioButton.Name = "_userFolderRadioButton";
			this._userFolderRadioButton.Size = new System.Drawing.Size(198, 17);
			this._userFolderRadioButton.TabIndex = 1;
			this._userFolderRadioButton.TabStop = true;
			this._userFolderRadioButton.Text = "Your user\'s application data directory";
			this._userFolderRadioButton.UseVisualStyleBackColor = true;
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
			// BookmarksLocationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(596, 348);
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
	}
}