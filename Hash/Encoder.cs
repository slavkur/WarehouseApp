using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace WarehouseApp
{
    public class Encoder
    {
        public static string _HashString(string value)
        {
            UTF8Encoding UTF8 = new UTF8Encoding();
            byte[] data = UTF8.GetBytes(value);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(data);
            return System.Text.Encoding.UTF8.GetString(result);
        }

        public static string HashString(string originalPassword)
        {
            //Declarations
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;

            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string
            return System.Convert.ToBase64String(encodedBytes);
        }
    }
}
