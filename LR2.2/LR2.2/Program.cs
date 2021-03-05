using System;
using System.Text;


namespace LR2._2
{
    class Program
    {
        static int Main(string[] args)
        {
            Random random = new Random ();

            Console.WriteLine("Сгенерировать равновероятно случайную строку длиной не более четырех строч-ных английских букв");

            while (true)
            {
                StringBuilder a = new StringBuilder("    ");
                for (int i = 0; i < random.Next(0, 5); i++)
                {
                    a[i] = Convert.ToChar(random.Next(97, 122));
                }

                Console.WriteLine(a+ "\n________________\nRepeat the set:\n     Y   N");

                ConsoleKey consoleKey = Console.ReadKey().Key;
                Console.Clear();

                switch (consoleKey)
                {
                    case ConsoleKey.Y: continue;

                    case ConsoleKey.N: return 0;
                }

            }       

            Console.ReadLine();
        }
    }
}
