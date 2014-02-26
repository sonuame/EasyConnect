using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using EasyConnect.Common;

namespace EasyConnect.Protocols
{
	[Serializable]
	public class EncryptedBookmarks
	{
		[XmlAttribute]
		public string KeyThumbprint
		{
			get;
			set;
		}

		[XmlAttribute]
		public string EncryptedKeyContainer
		{
			get;
			set;
		}

		public BookmarksFolder RootFolder
		{
			get;
			set;
		}

		public static EncryptedBookmarks Load(Form ownerForm, XmlReader bookmarksReader, Func<SecureString> showPasswordWindow)
		{
			if (bookmarksReader.LocalName != "EncryptedBookmarks")
				throw new Exception("Unrecognized bookmarks file type.  Root node name was " + bookmarksReader.LocalName);

			string keyThumbprint = bookmarksReader.GetAttribute("KeyThumbprint");
			bool keyExists = false;
			CspParameters parameters = new CspParameters
				                           {
					                           ProviderName = "EasyConnect Bookmarks " + keyThumbprint,
					                           Flags = CspProviderFlags.UseExistingKey
				                           };
			RSACryptoServiceProvider rsaCrypto = null;

			try
			{
				rsaCrypto = new RSACryptoServiceProvider(parameters);
				keyExists = true;
			}

			catch (Exception)
			{
			}

			if (!keyExists)
			{
				parameters.Flags = CspProviderFlags.NoFlags;
				rsaCrypto = new RSACryptoServiceProvider(parameters);

				// It's the first time that this bookmarks file has been opened, so we don't have the matching key container in the store; decrypt
				// it and import it
				byte[] encryptedKeyContainer = Convert.FromBase64String(bookmarksReader.GetAttribute("EncryptedKeyContainer"));

				MessageBox.Show(ownerForm, "Sharing Password Required",
@"Since we don't have the encryption key for this bookmarks file in the local store, 
you'll need to enter its sharing password, which you can get from the person who 
created the bookmarks file.", MessageBoxButtons.OK, MessageBoxIcon.Information);

				bool encryptionKeyImported = false;

				while (!encryptionKeyImported)
				{
					SecureString sharingPassword = showPasswordWindow();

					try
					{
						using (new CryptoContext(new RijndaelCrypto(sharingPassword)))
						{
							rsaCrypto.ImportCspBlob(CryptoUtilities.Decrypt(encryptedKeyContainer));
							encryptionKeyImported = true;
						}
					}

					catch (CryptographicException)
					{
						MessageBox.Show(ownerForm, "Password Incorrect", "The sharing password that you provided was incorrect.");
					}
				}
			}

			XmlSerializer bookmarksSerializer = new XmlSerializer(typeof(EncryptedBookmarks));

			using (new CryptoContext(new RsaCrypto("EasyConnect Bookmarks " + keyThumbprint)))
			{
				return (EncryptedBookmarks)bookmarksSerializer.Deserialize(bookmarksReader);
			}
		}

		public static EncryptedBookmarks Load(Form ownerForm, string fileName, Func<SecureString> showPasswordWindow)
		{
			using (XmlReader bookmarksReader = new XmlTextReader(fileName))
			{
				// Read past the XML preprocessor directive to the root node
				bookmarksReader.Read();
				bookmarksReader.Read();

				return Load(ownerForm, bookmarksReader, showPasswordWindow);
			}
		}

		public void Save(string fileName)
		{
			FileInfo destinationFile = new FileInfo(fileName);
			XmlSerializer bookmarksSerializer = new XmlSerializer(typeof (EncryptedBookmarks));

			// ReSharper disable AssignNullToNotNullAttribute
			Directory.CreateDirectory(destinationFile.DirectoryName);
			// ReSharper restore AssignNullToNotNullAttribute

			using (new CryptoContext(new RsaCrypto("EasyConnect Bookmarks " + KeyThumbprint)))
			using (XmlWriter bookmarksWriter = new XmlTextWriter(fileName, new UnicodeEncoding()))
			{
				bookmarksSerializer.Serialize(bookmarksWriter, this);
				bookmarksWriter.Flush();
			}
		}
	}
}
