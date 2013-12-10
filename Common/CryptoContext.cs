using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyConnect.Common
{
	public class CryptoContext : IDisposable
	{
		protected ICrypto _oldCrypto = null;

		public CryptoContext(ICrypto crypto)
		{
			_oldCrypto = CryptoUtilities.Crypto;
			CryptoUtilities.Crypto = crypto;
		}

		public void Dispose()
		{
			CryptoUtilities.Crypto = _oldCrypto;
		}
	}
}
