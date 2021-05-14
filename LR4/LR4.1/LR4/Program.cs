using System;
using System.Threading;
using System.Runtime.InteropServices;

namespace LR4
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        static void Main(string[] args)
        {
            while (true)
            {
                for (int i = 0; i < 255; i++)
                {
                    if (GetAsyncKeyState(i) == 32769)
                    {
                        Console.Write((ConsoleKey)i + " ");
                    }
                }
                Thread.Sleep(10);
            }
        }
    }
}
