using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyConnect.Common
{
	public class CryptoContext : IDisposable
	{
		public CryptoContext(ICrypto crypto)
		{
			CryptoUtilities.Crypto = crypto;
		}

		public void Dispose()
		{
			CryptoUtilities.Crypto = null;
		}
	}
}
