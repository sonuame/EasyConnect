using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EasyConnect
{
	public partial class BookmarksLocationForm : Form
	{
		public BookmarksLocationForm()
		{
			InitializeComponent();
		}

		public bool UseSharedBookmarksFile
		{
			get
			{
				return _sharedFileRadioButton.Checked;
			}

			set
			{
				_sharedFileRadioButton.Checked = value;
			}
		}

		public string SharedBookmarksFilePath
		{
			get
			{
				return _sharedFilePathTextBox.Text;
			}

			set
			{
				_sharedFilePathTextBox.Text = value;
			}
		}

		private void _sharedFilePathBrowseButton_Click(object sender, EventArgs e)
		{
			if (_sharedFileDialog.ShowDialog(this) == DialogResult.OK)
				_sharedFilePathTextBox.Text = _sharedFileDialog.FileName;
		}

		private void _userFolderRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (_userFolderRadioButton.Checked)
			{
				_sharedFilePathTextBox.Enabled = false;
				_sharedFilePathBrowseButton.Enabled = false;
			}
		}

		private void _sharedFileRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (_sharedFileRadioButton.Checked)
			{
				_sharedFilePathTextBox.Enabled = true;
				_sharedFilePathBrowseButton.Enabled = true;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			_userFolderRadioButton.Focus();
		}
	}
}
