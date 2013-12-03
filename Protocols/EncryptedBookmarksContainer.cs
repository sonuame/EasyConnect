using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyConnect.Protocols
{
	[Serializable]
	public class EncryptedBookmarksContainer
	{
		public string KeyThumbprint
		{
			get;
			set;
		}

		public string EncryptedKey
		{
			get;
			set;
		}
	}
}
