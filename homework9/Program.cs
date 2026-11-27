using System;

namespace Task1_Cipher
{
    public interface ICipher
    {
        string Encode(string input);
        string Decode(string input);
    }
    public class ACipher : ICipher
    {
        public string Encode(string input)
        {
            char[] chars = input.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetter(chars[i]))
                {
                    chars[i] = (char)(chars[i] + 1); 
                }
            }
            return new string(chars);
        }

        public string Decode(string input)
        {
            char[] chars = input.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetter(chars[i]))
                {
                    chars[i] = (char)(chars[i] - 1); 
                }
            }
            return new string(chars);
        }
    }
    public class BCipher : ICipher
    {
        public string Encode(string input)
        {
            char[] chars = input.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetter(chars[i]))
                {
                    if (char.IsUpper(chars[i]))
                        chars[i] = (char)('Z' - (chars[i] - 'A'));
                    else
                        chars[i] = (char)('z' - (chars[i] - 'a'));
                }
            }
            return new string(chars);
        }

        public string Decode(string input)
        {
            return Encode(input);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Упражнение 10.1: Шифрование ===\n");
            Console.Write("Введите строку для шифрования: ");
            string text = Console.ReadLine();

            ICipher cipherA = new ACipher();
            ICipher cipherB = new BCipher();

            Console.WriteLine($"\nОригинал: {text}");

            string encodedA = cipherA.Encode(text);
            Console.WriteLine($"\n[ACipher]");
            Console.WriteLine($"Зашифровано: {encodedA}");
            Console.WriteLine($"Расшифровано: {cipherA.Decode(encodedA)}");

            string encodedB = cipherB.Encode(text);
            Console.WriteLine($"\n[BCipher]");
            Console.WriteLine($"Зашифровано: {encodedB}");
            Console.WriteLine($"Расшифровано: {cipherB.Decode(encodedB)}");

            Console.ReadLine();
        }
    }
}
