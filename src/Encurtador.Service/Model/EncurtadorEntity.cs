
using System;
namespace Encurtador.Service.Model
{
    public class EncurtadorEntity
    {
        public int Id { get; set; }
        public string LinkOrig { get; set; }
        public string LinkEncurt { get; set; }

        public static string Encurtado()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
    }
}