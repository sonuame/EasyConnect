using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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

		public string GetThumbprint()
		{
			SHA256CryptoServiceProvider shaCrypto = new SHA256CryptoServiceProvider();
			return Convert.ToBase64String(shaCrypto.ComputeHash(new UnicodeEncoding().GetBytes(_crypto.ToXmlString(true))));
		}

		public RSAParameters GetRsaParameters()
		{
			return _crypto.ExportParameters(true);
		}

		public string ToXmlString()
		{
			return _crypto.ToXmlString(true);
		}

		public byte[] GetEncryptedKeyContainer(SecureString sharingPassword)
		{
			using (new CryptoContext(new RijndaelCrypto(sharingPassword)))
			{
				return CryptoUtilities.Encrypt(_crypto.ExportCspBlob(true));
			}
		}
	}
}
