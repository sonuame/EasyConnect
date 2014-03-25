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

		public void SetSharingPassword(SecureString password)
		{
			RsaCrypto rsaCrypto = new RsaCrypto("EasyConnect Bookmarks " + KeyThumbprint);
			EncryptedKeyContainer = Convert.ToBase64String(rsaCrypto.GetEncryptedKeyContainer(password));
		}

		public EncryptedBookmarks()
		{
			RootFolder = new BookmarksFolder();
		}

		public static EncryptedBookmarks Load(Form ownerForm, XmlReader bookmarksReader, Func<SecureString> showPasswordWindow)
		{
			if (bookmarksReader.LocalName != "EncryptedBookmarks")
				throw new Exception("Unrecognized bookmarks file type.  Root node name was " + bookmarksReader.LocalName);

			string keyThumbprint = bookmarksReader.GetAttribute("KeyThumbprint");
			RsaCrypto rsaCrypto = new RsaCrypto("EasyConnect Bookmarks " + keyThumbprint);

			if (rsaCrypto.GetThumbprint() != keyThumbprint)
			{
				// It's the first time that this bookmarks file has been opened, so we don't have the matching key container in the store; decrypt it and 
				// import it
				byte[] encryptedKeyContainer = Convert.FromBase64String(bookmarksReader.GetAttribute("EncryptedKeyContainer"));

				MessageBox.Show(
					ownerForm,
					"Since we don't have the encryption key for this bookmarks file in the local store, you'll need to enter its sharing password, which you can get from the person who created the bookmarks file.",
					"Sharing Password Required", MessageBoxButtons.OK, MessageBoxIcon.Information);

				bool encryptionKeyImported = false;

				while (!encryptionKeyImported)
				{
					SecureString sharingPassword = showPasswordWindow();

					try
					{
						CryptoUtilities.ImportRsaKeyContainer("EasyConnect Bookmarks " + keyThumbprint, keyThumbprint, encryptedKeyContainer, sharingPassword);
						encryptionKeyImported = true;
					}

					catch (CryptographicException)
					{
						MessageBox.Show(
							ownerForm, "The sharing password that you provided was incorrect.", "Password Incorrect", MessageBoxButtons.OK,
							MessageBoxIcon.Error);
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
