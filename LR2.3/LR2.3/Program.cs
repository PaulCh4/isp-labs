using System;
using System.Text;


namespace LR2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            StringBuilder text = new StringBuilder("ajxyieualtirctbayultwuyrabyzikyudfilctayrxlnwiafhusd,tcyilyxiaofhnguailtyux.nHz.xtu,zgbhjcdtyara;io;zuitryicwtau");
            StringBuilder vowels = new StringBuilder("eyuioa ");

            Console.WriteLine("Дана строка, состоящая из строчных английских букв. Заменить в ней все буквы, стоящие после гласных, на следующие по алфавиту (z заменяется на a).");
            Console.WriteLine(text);

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < vowels.Length; j++)
                {
                    if(text[i]==vowels[j])
                    {
                        if (text[i + 1] == 'z')
                        {
                            text[i + 1] = 'a';
                            continue;
                        }
                        text[i+1] = Convert.ToChar(Convert.ToInt32(text[i+1])+1);
                    }
                }
            }

            Console.WriteLine(text);
            Console.ReadLine();
        }
    }
}
