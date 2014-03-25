using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;

namespace EasyConnect.Common
{
	public class CryptoUtilities
	{
		internal static ICrypto Crypto
		{
			get;
			set;
		}

		/// <summary>
		/// Decrypts <paramref name="data"/> by using the <see cref="Crypto"/> currently set.
		/// </summary>
		/// <param name="data">Data that we are to decrypt.</param>
		/// <returns>Decrypted data.</returns>
		public static byte[] Decrypt(byte[] data)
		{
			if (Crypto == null)
				throw new Exception("Crypto object not set, use a CryptoContext object wrapped in a using block.");

			return Crypto.Decrypt(data);
		}

		/// <summary>
		/// Encrypts <paramref name="data"/> by using the <see cref="Crypto"/> currently set.
		/// </summary>
		/// <param name="data">Data that we are to encrypt.</param>
		/// <returns>Encrypted data.</returns>
		public static byte[] Encrypt(byte[] data)
		{
			if (Crypto == null)
				throw new Exception("Crypto object not set, use a CryptoContext object wrapped in a using block.");

			return Crypto.Encrypt(data);
		}

		/// <summary>
		/// Encrypts a password specified in <paramref name="data"/> by using the <see cref="Crypto"/> currently set.
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

		public static void ImportRsaKeyContainer(string keyContainerName, string keyThumbprint, byte[] encryptedKeyContainer, SecureString password)
		{
			RsaCrypto rsaCrypto = new RsaCrypto(keyContainerName);

			// It's already in the local key store, so just return
			if (rsaCrypto.GetThumbprint() == keyThumbprint)
				return;

			using (RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider())
			using (new CryptoContext(new RijndaelCrypto(password)))
			{
				rsaCryptoServiceProvider.ImportCspBlob(Decrypt(encryptedKeyContainer));

				// It's a little ridiculous to have to go through this two phase process of instantiating RSACryptoServiceProvider objects, but it's necessary 
				// because you can't call ImportCspBlob() on RSACryptoServiceProvider objects constructed with a CspParameters parameter, since it either loads 
				// up a matching existing key from the local key store or creates and saves a new one.  Because of this, you can't call ImportCspBlob() on top 
				// of that.  So, we have to instead call ImportCspBlob() on one instance created without CspParameters, construct another instance with 
				// CspParameters, and then call ImportParameters() on that second instance to properly persist the imported key to the keystore.  Laborious and 
				// verbose, but necessary.
				using (RSACryptoServiceProvider saveCryptoServiceProvider = new RSACryptoServiceProvider(
					new CspParameters
					{
						KeyContainerName = keyContainerName
					}))
				{
					saveCryptoServiceProvider.ImportParameters(rsaCryptoServiceProvider.ExportParameters(true));
				}
			}
		}
	}
}
