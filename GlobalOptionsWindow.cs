using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Windows.Forms;
using EasyConnect.Protocols;

namespace EasyConnect
{
	/// <summary>
	/// Displays the global options for the application:  the default protocol and whether they want the toolbar to auto-hide.
	/// </summary>
	public partial class GlobalOptionsWindow : Form
	{
		/// <summary>
		/// If the user selected an encryption type of <see cref="EncryptionType.Rijndael"/>, this is the encryption key to use with that method.
		/// </summary>
		protected SecureString _bookmarksSharingPassword = null;

		/// <summary>
		/// Main application form for this window.
		/// </summary>
		protected MainForm _parentTabs = null;

		/// <summary>
		/// Default constructor; populates the protocol dropdown.
		/// </summary>
		public GlobalOptionsWindow()
		{
			InitializeComponent();

			foreach (IProtocol protocol in ConnectionFactory.GetProtocols())
				_defaultProtocolDropdown.Items.Add(protocol);

			_defaultProtocolDropdown.SelectedItem = ConnectionFactory.GetDefaultProtocol();
		}

		/// <summary>
		/// Handler method that's called when the form is closing; sets the properties for various options and then saves them.
		/// </summary>
		/// <param name="sender">Object from which this event originated.</param>
		/// <param name="e">Arguments associated with this event.</param>
		private void GlobalOptionsWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (_parentTabs == null)
				return;

			ConnectionFactory.SetDefaultProtocol((IProtocol) _defaultProtocolDropdown.SelectedItem);

			_parentTabs.Options.AutoHideToolbar = _autoHideCheckbox.Checked;
			_parentTabs.Options.UseSharedBookmarks = _sharedLocationRadioButton.Checked;
			_parentTabs.Options.SharedBookmarksFileName = _sharedLocationRadioButton.Checked
				                                              ? _sharedLocationTextBox.Text
				                                              : null;

			_parentTabs.Options.Save();

			if (!File.Exists(_parentTabs.Bookmarks.BookmarksFileName))
				_parentTabs.Bookmarks.Save();

			else
				_parentTabs.Bookmarks.Load();

			if (_bookmarksSharingPassword != null)
			{
				_parentTabs.Bookmarks.SetSharingPassword(_bookmarksSharingPassword);
				_parentTabs.Bookmarks.Save();
			}
		}

		/// <summary>
		/// Handler method that's called when the form is shown; sets the state of <see cref="_autoHideCheckbox"/>.
		/// </summary>
		/// <param name="sender">Object from which this event originated.</param>
		/// <param name="e">Arguments associated with this event.</param>
		private void GlobalOptionsWindow_Shown(object sender, EventArgs e)
		{
			_parentTabs = Parent.TopLevelControl as MainForm;
			_autoHideCheckbox.Checked = _parentTabs.Options.AutoHideToolbar;

			if (!_parentTabs.Options.UseSharedBookmarks)
				_appDataFolderRadioButton.Checked = true;

			else
			{
				_sharedLocationRadioButton.Checked = true;
				_sharedLocationTextBox.Text = _parentTabs.Options.SharedBookmarksFileName;
				_sharedLocationTextBox.Enabled = true;
				_sharedLocationBrowseButton.Enabled = true;
			}
		}

		/// <summary>
		/// Class to provide text and value members to <see cref="ComboBox"/> instances.
		/// </summary>
		protected class ListItem
		{
			/// <summary>
			/// Text that should be displayed for the item.
			/// </summary>
			public string Text
			{
				get;
				set;
			}

			/// <summary>
			/// Value that should be used for the item.
			/// </summary>
			public string Value
			{
				get;
				set;
			}
		}

		private void _appDataFolderRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			_sharedLocationTextBox.Enabled = !_appDataFolderRadioButton.Checked;
			_sharedLocationBrowseButton.Enabled = !_appDataFolderRadioButton.Checked;
		}

		private void _sharedLocationBrowseButton_Click(object sender, EventArgs e)
		{
			if (!String.IsNullOrEmpty(_sharedLocationTextBox.Text))
				_sharedLocationFileDialog.FileName = _sharedLocationTextBox.Text;

			if (_sharedLocationFileDialog.ShowDialog(this) == DialogResult.OK)
				_sharedLocationTextBox.Text = _sharedLocationFileDialog.FileName;
		}

		private void _setSharingPasswordButton_Click(object sender, EventArgs e)
		{
			PasswordWindow passwordWindow = new PasswordWindow
				                                {
					                                ShowCancelButton = true
				                                };

			_bookmarksSharingPassword = passwordWindow.ShowDialog() == DialogResult.OK
				                            ? passwordWindow.Password
				                            : null;
		}
	}
}