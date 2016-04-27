using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace LibCore.Security
{
    public class Hashing
    {
        // MD5
        public static string MD5(string str)
        {
            using (MD5 hashProvider = System.Security.Cryptography.MD5.Create())
            {
                byte[] data = hashProvider.ComputeHash(Encoding.UTF8.GetBytes(str));

                return byte2String(data);
            }
        }

        public static bool MD5Verify(string str, string hash)
        {
            return MD5(str).Equals(hash);
        }

        // SHA1
        public static string SHA1(string str)
        {
            using (SHA1 hashProvider = System.Security.Cryptography.SHA1.Create())
            {
                byte[] data = hashProvider.ComputeHash(Encoding.UTF8.GetBytes(str));

                return byte2String(data);
            }
        }

        // SHA256
        public static string SHA256(string str)
        {
            using (SHA256 hashProvider = System.Security.Cryptography.SHA256.Create())
            {
                byte[] data = hashProvider.ComputeHash(Encoding.UTF8.GetBytes(str));

                return byte2String(data);
            }
        }

        // SHA384
        public static string SHA384(string str)
        {
            using (SHA384 hashProvider = System.Security.Cryptography.SHA384.Create())
            {
                byte[] data = hashProvider.ComputeHash(Encoding.UTF8.GetBytes(str));

                return byte2String(data);
            }
        }

        // SHA512
        public static string SHA512(string str)
        {
            using (SHA512 hashProvider = System.Security.Cryptography.SHA512.Create())
            {
                byte[] data = hashProvider.ComputeHash(Encoding.UTF8.GetBytes(str));

                return byte2String(data);
            }
        }

        // RIPEMD160
        public static string RIPEMD160(string str)
        {
            using (RIPEMD160 hashProvider = System.Security.Cryptography.RIPEMD160.Create())
            {
                byte[] data = hashProvider.ComputeHash(Encoding.UTF8.GetBytes(str));

                return byte2String(data);
            }
        }

        private static string byte2String(byte[] data)
        {
            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
    }
}