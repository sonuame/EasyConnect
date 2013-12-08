using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace EasyConnect
{
	public interface IEncryptionConversionForm
	{
		SecureString SharingPassword
		{
			get;
			set;
		}
	}
}
