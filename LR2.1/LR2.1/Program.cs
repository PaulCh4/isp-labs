using System;

namespace LR2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Tobias Booon Noob Saibot";
            string[] words = text.Split(' ');
            Console.WriteLine("В заданной строке поменять порядок слов на обратный (слова разделены пробелами).");
            Console.WriteLine(text);            
            Console.WriteLine("reversed:");
            Array.Reverse(words);
            for (int i = 0; i < words.Length; i++)
            {
                Console.Write(words[i] + " ");
            }
            Console.ReadKey();
        }
    }
} 

