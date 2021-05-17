using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using Newtonsoft.Json;

namespace SimpleChatSharedCode
{
    static class Utilities
    {
        public static byte[] GetASCIIBytes(this string s)
        {
            return Encoding.ASCII.GetBytes(s);
        }

        public static string GetStringFromASCIIBytes(this byte[] b)
        {
            return Encoding.ASCII.GetString(b);
        }

        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.ASCII.GetBytes(rawData));

                // Convert byte array to a string   
                return bytes.GetStringFromASCIIBytes();
            }
        }

        public static string GetFirstStringRecord(this ICollection<string> s)
        {
            return s.ToArray()[0];
        }

        public static byte[] GetFirstByteRecord(this ICollection<string> s)
        {
            return s.ToArray()[0].GetASCIIBytes();
        }

        public static byte[] GetByte(this Net_Base b)
        {
            return JsonConvert.SerializeObject(b).GetASCIIBytes();
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
