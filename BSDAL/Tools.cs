using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BSDAL
{
    public static class Tools
    {
        public static string ToMD5Encrypt(this string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] btr = Encoding.UTF8.GetBytes(text);
            byte[] md5btr = md5.ComputeHash(btr);
            return Convert.ToBase64String(md5btr);
        }

        public static string ToValid(this string text)
        {
            //Bu metodumuzlada Türkçe karakterleri temizleyip ingilizceye uyarlıyoruz
            string Temp = text.ToLower();
            Temp = Temp.Replace("-", "").ToString();
            Temp = Temp.Replace(" ", "-").ToString();
            Temp = Temp.Replace("ç", "c").ToString();
            Temp = Temp.Replace("ğ", "g").ToString();
            Temp = Temp.Replace("ı", "i").ToString();
            Temp = Temp.Replace("ö", "o").ToString();
            Temp = Temp.Replace("ş", "s").ToString();
            Temp = Temp.Replace("ü", "u").ToString();
            Temp = Temp.Replace("\"", "").ToString();
            Temp = Temp.Replace("/", "").ToString();
            Temp = Temp.Replace("(", "").ToString();
            Temp = Temp.Replace(")", "").ToString();
            Temp = Temp.Replace("{", "").ToString();
            Temp = Temp.Replace("}", "").ToString();
            Temp = Temp.Replace("%", "").ToString();
            Temp = Temp.Replace("&", "").ToString();
            Temp = Temp.Replace("+", "").ToString();
            Temp = Temp.Replace(",", "").ToString();
            Temp = Temp.Replace("?", "").ToString();
            Temp = Temp.Replace(".", "_").ToString();
            Temp = Temp.Replace("ı", "i").ToString();
            Temp = Temp.Replace("!", "").ToString();
            Temp = Temp.Replace("#", "").ToString();
            Temp = Temp.Replace("$", "").ToString();
            Temp = Temp.Replace("Ğ", "G").ToString();
            Temp = Temp.Replace("Ç", "C").ToString();
            Temp = Temp.Replace("İ", "I").ToString();
            Temp = Temp.Replace("Ş", "S").ToString();
            Temp = Temp.Replace("Ü", "U").ToString();
            Temp = Temp.Replace("Ö", "O").ToString();
            Temp = Temp.Replace(":", "-").ToString();
            return Temp;
        }

        public static string ControlLength(this string word, int length)
        {
            if (word.Length > length)
            {
                return word.Substring(0, length - 3);
            }
            else
            {
                return word;
            }
        }

        public static void DeleteFile(string path)
        {
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                File.Delete(HttpContext.Current.Server.MapPath(path));
            }
        }

        public static class Enumeration
        {
            public static IDictionary<int, string> GetAll<TEnum>() where TEnum : struct
            {
                var enumerationType = typeof(TEnum);

                if (!enumerationType.IsEnum)
                    throw new ArgumentException("Enumeration type is expected.");

                var dictionary = new Dictionary<int, string>();

                foreach (int value in Enum.GetValues(enumerationType))
                {
                    var name = Enum.GetName(enumerationType, value);
                    dictionary.Add(value, name);
                }

                return dictionary;
            }
        }

    }
}
