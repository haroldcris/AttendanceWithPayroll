using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace AiTech
{
    public class Password
    {
        static SimpleAES Generator = new SimpleAES();

        public static string Encrypt(string str)
        {
            return Generator.Encrypt(str);
        }

        public static string Decrypt(string str)
        {
            return Generator.Decrypt(str);
        }

    }




}
