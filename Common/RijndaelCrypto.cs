using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace EasyConnect.Common
{
	public class RijndaelCrypto : ICrypto
	{
		protected Rijndael _crypto = null;

		public RijndaelCrypto(SecureString encryptionKey)
		{
			Rijndael rijndael = Rijndael.Create();
			rijndael.KeySize = 256;

			// Get the bytes for the password
			IntPtr marshalledKeyBytes = Marshal.SecureStringToGlobalAllocAnsi(encryptionKey);
			byte[] keyBytes = new byte[rijndael.KeySize / 8];

			Marshal.Copy(marshalledKeyBytes, keyBytes, 0, Math.Min(keyBytes.Length, encryptionKey.Length));

			// Set the encryption key to the key bytes and the IV to a predetermined string
			rijndael.Key = keyBytes;
			rijndael.IV = Convert.FromBase64String("QGWyKbe+W9H0mL2igm73jw==");

			Marshal.ZeroFreeGlobalAllocAnsi(marshalledKeyBytes);

			_crypto = rijndael;
		}

		public byte[] Encrypt(byte[] data)
		{
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, _crypto.CreateEncryptor(), CryptoStreamMode.Write);

			cryptoStream.Write(data, 0, data.Length);
			cryptoStream.Close();
			memoryStream.Close();

			return memoryStream.ToArray();
		}

		public byte[] Decrypt(byte[] data)
		{
			byte[] decryptedData = new byte[data.Length];
			MemoryStream memoryStream = new MemoryStream(data, 0, data.Length);
			CryptoStream cryptoStream = new CryptoStream(memoryStream, ((SymmetricAlgorithm)_crypto).CreateDecryptor(), CryptoStreamMode.Read);

			cryptoStream.Read(decryptedData, 0, decryptedData.Length);
			cryptoStream.Close();
			memoryStream.Close();

			return decryptedData;
		}
	}
}
