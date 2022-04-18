using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ET
{
	public static class MD5Helper
	{
		public static string FileMD5(string filePath)
		{
			byte[] retVal;
            using (FileStream file = new FileStream(filePath, FileMode.Open))
            {
	            MD5 md5 = MD5.Create();
				retVal = md5.ComputeHash(file);
			}
			return retVal.ToHex("x2");
		}
		
		/// <summary>
		/// 将字符串以MD5码的形式进行加密
		/// </summary>
		/// <param name="content"></param>
		/// <returns></returns>
		public static string StringMD5(string content)
		{
			MD5 md5 = MD5.Create();
			byte[] result = Encoding.Default.GetBytes(content);
			byte[] output = md5.ComputeHash(result);
			return BitConverter.ToString(output).Replace("-", "");
		}
	}
}
