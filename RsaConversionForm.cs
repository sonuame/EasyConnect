using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows.Forms;

namespace EasyConnect
{
	public partial class RsaConversionForm : Form, IEncryptionConversionForm
	{
		public RsaConversionForm()
		{
			InitializeComponent();
		}

		public SecureString SharingPassword
		{
			get
			{
				return _passwordTextBox.SecureText;
			}

			set
			{
				_passwordTextBox.SecureText = value;
			}
		}
	}
}
