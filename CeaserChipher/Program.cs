using System;

namespace CeaserChipher
{
    public class CaesarCipher
    {
        //alphabets
        const string RUalphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        const string ENalphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public string alphabet;
        private string EncryptDecrypt(string language, string text, int k)
        {
            if (language == "RU")
            {
                alphabet = RUalphabet;
            }
            else if (language == "EN")
            {
                alphabet = ENalphabet;
            }
            //add small letters to the alphabet
            var fullAlphabet = alphabet + alphabet.ToLower();
            var letterQty = fullAlphabet.Length;
            var returnValue = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var index = fullAlphabet.IndexOf(c);
                if (index < 0)
                {
                    //if the symbol is not found, then add it unchanged
                    returnValue += c.ToString();
                }
                else
                {
                    var codeIndex = (letterQty + index + k) % letterQty;
                    returnValue += fullAlphabet[codeIndex];
                }
            }
            return returnValue;
        }

        //text encryption
        public string Encrypt(string language, string plainMessage, int key)
            => EncryptDecrypt(language, plainMessage, key);

        //text decryption
        public string Decrypt(string language, string encryptedMessage, int key)
            => EncryptDecrypt(language, encryptedMessage, -key);
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cipher = new CaesarCipher();
            string language;
            while (true)
            {
                Console.Write("Enter the required language (\"RU\" or \"EN\"): ");
                var answer = Console.ReadLine();
                if (answer == "RU")
                {
                    language = "RU";
                    break;
                }
                else if (answer == "EN")
                {
                    language = "EN";
                    break;
                }
            }
            Console.Write("Enter text: ");
            var message = Console.ReadLine();
            Console.Write("Enter key (number): ");
            var key = Convert.ToInt32(Console.ReadLine());
            var encryptedText = cipher.Encrypt(language, message, key);
            Console.WriteLine("Encrypted message: {0}", encryptedText);
            Console.WriteLine("Decrypted message: {0}", cipher.Decrypt(language, encryptedText, key));
            Console.ReadLine();
        }
    }
}