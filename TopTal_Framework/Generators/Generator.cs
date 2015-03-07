using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopTal_Framework.Generators
{
    public class Generator
    {
        public static string GetEpochTime()
        {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;
            return secondsSinceEpoch.ToString();
        }

        public static string GenerateEmail()
        {
            return "random" + Generator.GetEpochTime() + "@random.com";
        }

        public static string GeneratePhone()
        {
            return "+1-541-754-3010";
        }

        public static string GenerateName()
        {
            return "randomName" + Generator.GetEpochTime();
        }

        public static string GenerateInvalidEmail()
        {
            Random r = new Random();
            int number = r.Next(0, 4);
            switch (number)
            {
                case 0:
                    return "random" + Generator.GetEpochTime() + "invalid.com";
                case 1:
                    return "random" + Generator.GetEpochTime() + "@invalid";
                case 3:
                    return Generator.GetEpochTime();
                default:
                    return "random" + Generator.GetEpochTime() + "invalid.com";
            }
        }

        public static string GenerateInvalidPhone()
        {
            Random r = new Random();
            int number = r.Next(0, 4);
            switch (number)
            {
                case 0:
                    return "invalid";
                case 1:
                    return "invalid" + Generator.GetEpochTime();
                case 3:
                    return Generator.GetEpochTime() + ")(*&^%$#@!";
                default:
                    return r.Next(1000, 100000).ToString();
            }
        }

        public static string GenerateInvalidPassword()
        {
            Random r = new Random();
            int number = r.Next(0, 4);
            switch (number)
            {
                case 0:
                    return "Aa3";
                case 1:
                    return "a3^";
                case 3:
                    return ")A*";
                default:
                    return r.Next(1000, 1000).ToString();
            }
        }

        public const string alphabet = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string GeneratePassword()
        {
            Random r = new Random();
            int size = r.Next(6, 10);
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = alphabet[r.Next(alphabet.Length)];
            }
            return new string(chars);
        }

        public static string DefaultPassword { get { return "123456"; } }
    }

    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Company { get; set; }
    }
}
