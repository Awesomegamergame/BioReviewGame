using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace BioReviewGame
{
    internal class Security
    {
        public static string Encrypt(string dir, string name)
        {
            try
            {
                string cutname = name.Substring(0, name.Length - 5);
                string OutString = "";
                string textToEncrypt = File.ReadAllText(dir);
                string publickey = "apbiologypocowta";
                string secretkey = "luckybuster6996!";
                byte[] secretkeyByte = { };
                secretkeyByte = Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = Encoding.UTF8.GetBytes(textToEncrypt);
                using (AesCryptoServiceProvider des = new AesCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    OutString = Convert.ToBase64String(ms.ToArray());
                }
                File.WriteAllText($"{cutname}.q&a", OutString);
                return OutString;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public static string Decrypt(string dir, string name, bool write)
        {
            string cutname = name.Substring(0, name.Length - 4);
            string textToDecrypt = File.ReadAllText(dir);
            string ToReturn = "";
            string publickey = "apbiologypocowta";
            string privatekey = "luckybuster6996!";
            byte[] privatekeyByte = { };
            privatekeyByte = Encoding.UTF8.GetBytes(privatekey);
            byte[] publickeybyte = { };
            publickeybyte = Encoding.UTF8.GetBytes(publickey);
            MemoryStream ms = null;
            CryptoStream cs = null;
            byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
            inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
            using (AesCryptoServiceProvider des = new AesCryptoServiceProvider())
            {
                ms = new MemoryStream();
                cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = Encoding.UTF8;
                ToReturn = encoding.GetString(ms.ToArray());
            }
            if (write)
            {
                File.WriteAllText($"{cutname}.json", ToReturn);
            }
            return ToReturn;
        }
    }
}
