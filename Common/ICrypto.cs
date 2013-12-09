using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyConnect.Common
{
	public interface ICrypto
	{
		byte[] Encrypt(byte[] data);
		byte[] Decrypt(byte[] data);
	}
}
