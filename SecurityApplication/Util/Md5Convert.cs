using System.Security.Cryptography;
using System.Text;

namespace SecurityApplication.Util
{
    public class Md5Convert
    {
        /// <summary>
        /// Function MD5Parse use for parse password to MD5
        /// </summary>
        /// <param name="password"></param>
        /// <returns>Password Convert</returns>
        public static string Md5Parse(string password)
        {
            var md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            foreach (var t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
