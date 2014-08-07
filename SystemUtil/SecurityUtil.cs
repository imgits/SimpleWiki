using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SimpleWiki.SystemUtil
{
    public static class SecurityUtil
    {
        /// <summary>
        /// Get md5 hash value of the string.
        /// </summary>
        /// <param name="value"></param>
        public static string GetMD5Hash(string value)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
