namespace EasyConnect
{
	partial class RijndaelConversionForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RijndaelConversionForm));
			System.Security.SecureString secureString1 = new System.Security.SecureString();
			this._descriptionLabel = new System.Windows.Forms.Label();
			this._passwordTextBox = new SecurePasswordTextBox.SecureTextBox();
			this._passwordLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// _descriptionLabel
			// 
			this._descriptionLabel.AutoSize = true;
			this._descriptionLabel.Location = new System.Drawing.Point(13, 13);
			this._descriptionLabel.Name = "_descriptionLabel";
			this._descriptionLabel.Size = new System.Drawing.Size(558, 78);
			this._descriptionLabel.TabIndex = 0;
			this._descriptionLabel.Text = resources.GetString("_descriptionLabel.Text");
			// 
			// _passwordTextBox
			// 
			this._passwordTextBox.Location = new System.Drawing.Point(74, 121);
			this._passwordTextBox.Name = "_passwordTextBox";
			this._passwordTextBox.PasswordChar = '*';
			this._passwordTextBox.SecureText = secureString1;
			this._passwordTextBox.Size = new System.Drawing.Size(146, 20);
			this._passwordTextBox.TabIndex = 1;
			// 
			// _passwordLabel
			// 
			this._passwordLabel.AutoSize = true;
			this._passwordLabel.Location = new System.Drawing.Point(12, 124);
			this._passwordLabel.Name = "_passwordLabel";
			this._passwordLabel.Size = new System.Drawing.Size(56, 13);
			this._passwordLabel.TabIndex = 2;
			this._passwordLabel.Text = "Password:";
			// 
			// RijndaelConversionForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(596, 348);
			this.Controls.Add(this._passwordLabel);
			this.Controls.Add(this._passwordTextBox);
			this.Controls.Add(this._descriptionLabel);
			this.Name = "RijndaelConversionForm";
			this.Text = "Rijndael Conversion Form";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label _descriptionLabel;
		private SecurePasswordTextBox.SecureTextBox _passwordTextBox;
		private System.Windows.Forms.Label _passwordLabel;
	}
}