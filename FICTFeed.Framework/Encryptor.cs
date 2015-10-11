using System.Security.Cryptography;
using System.Text;

namespace FICTFeed.Framework
{
    public class Encryptor
    {
        private const string salt = "ttKjZwmYXhQNGxGI2wAU_lFkaJDYCoYJyu1xVTmIp";
        public Encryptor()
        {

        }

        public string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            var result = md5.Hash;

            var strBuilder = new StringBuilder();
            foreach (var item in result)
            {
                strBuilder.Append(item.ToString("x2"));
            }

            return strBuilder.ToString();
        }

        public string CryptPassword(string password)
        {
            return MD5Hash(password + salt);
        }
    }
}
