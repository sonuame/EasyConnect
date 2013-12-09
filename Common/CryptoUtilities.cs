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
	public class CryptoUtilities
	{
		protected static ICrypto _crypto = null;

		internal static ICrypto Crypto
		{
			get;
			set;
		}

		/// <summary>
		/// Decrypts <paramref name="data"/> by using the <see cref="_crypto"/> currently set.
		/// </summary>
		/// <param name="data">Data that we are to decrypt.</param>
		/// <returns>Decrypted data.</returns>
		public static byte[] Decrypt(byte[] data)
		{
			if (_crypto == null)
				throw new Exception("Crypto object not set, use a CryptoContext object wrapped in a using block.");

			return _crypto.Decrypt(data);
		}

		/// <summary>
		/// Encrypts <paramref name="data"/> by using the <see cref="_crypto"/> currently set.
		/// </summary>
		/// <param name="data">Data that we are to encrypt.</param>
		/// <returns>Encrypted data.</returns>
		public static byte[] Encrypt(byte[] data)
		{
			if (_crypto == null)
				throw new Exception("Crypto object not set, use a CryptoContext object wrapped in a using block.");

			return _crypto.Encrypt(data);
		}

		/// <summary>
		/// Encrypts a password specified in <paramref name="data"/> by using the <see cref="_crypto"/> currently set.
		/// </summary>
		/// <param name="data">Data that we are to encrypt.</param>
		/// <returns>Encrypted data.</returns>
		public static byte[] Encrypt(SecureString data)
		{
			IntPtr marshalledDataBytes = Marshal.SecureStringToGlobalAllocAnsi(data);
			byte[] dataBytes = new byte[data.Length];

			Marshal.Copy(marshalledDataBytes, dataBytes, 0, dataBytes.Length);

			byte[] encryptedData = Encrypt(dataBytes);

			// Clear the data bytes from memory
			for (int i = 0; i < dataBytes.Length; i++)
				dataBytes[i] = 0;

			Marshal.ZeroFreeGlobalAllocAnsi(marshalledDataBytes);

			return encryptedData;
		}
	}
}
