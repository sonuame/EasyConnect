using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EasyConnect.Common
{
	public class RsaCrypto : ICrypto
	{
		protected RSACryptoServiceProvider _crypto = null;

		public RsaCrypto(string keyContainerName)
		{
			CspParameters parameters = new CspParameters
				                           {
					                           KeyContainerName = keyContainerName
				                           };

			_crypto = new RSACryptoServiceProvider(parameters);
		}

		public byte[] Encrypt(byte[] data)
		{
			return _crypto.Encrypt(data, true);
		}

		public byte[] Decrypt(byte[] data)
		{
			return _crypto.Decrypt(data, true);
		}
	}
}
