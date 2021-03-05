using System;

namespace CSharp_Shell
{

    public class Program
    {
        public static void Output(int[,] Arr)
        {
            int Sum = 0;

            Console.Clear();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Arr[i, j] % 2 == 1) Arr[i, j]--; 
                    Sum += Arr[i, j];
                }
            }

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Arr[i,j]!=0) Console.Write("\t" + Arr[i, j]);
                    else Console.Write("\t"+".");
                    if (i == 0 && j == 3) Console.Write("          Your Score: " + Sum);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("\tTo Controle Use: WASD" );
        }

        public static void Spawn(int[,] Arr, Random rnd)
        {
            while (true)
            {
                int x = rnd.Next(0, 4);
                int y = rnd.Next(0, 4);
                int SHANS = rnd.Next(0, 101);
                if (Arr[x, y] == 0)
                {
                    if (SHANS <= 90)
                    {
                        Arr[x, y] = 2;
                        break;
                    }
                    if (SHANS > 90)
                    {
                        Arr[x, y] = 2;
                        break;
                    }
                }
            }
        }

        public static void SwipeA(int[,] Arr)
        {
            int k = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Arr[i, j] > 0)
                    {
                        while (true)
                        {
                            if (j - k - 1 < 0)
                            {
                                k = 0;
                                break;
                            }
                            if (Arr[i, j - k - 1] == Arr[i, j - k])
                            {
                                Arr[i, j - k - 1] = Arr[i, j - k] * 2+1;
                                Arr[i, j - k] = 0;
                                k = 0;
                                break;
                            }
                            if (Arr[i, j - k - 1] != Arr[i, j - k] && Arr[i, j - k - 1] != 0)
                            {
                                k = 0;
                                break;
                            }
                            Arr[i, j - k - 1] = Arr[i, j - k];
                            Arr[i, j - k] = 0;
                            k++;
                        }
                    }
                }
            }
        }


        public static void SwipeD(int[,] Arr)
        {
            int k = 0;
            for (int i = 3; i > -1; i--)
            {
                for (int j = 3; j > -1; j--)
                {
                    if (Arr[i, j] > 0)
                    {
                        while (true)
                        {
                            if (j + k + 1 > 3)
                            {
                                k = 0;
                                break;
                            }
                            if (Arr[i, j + k + 1] == Arr[i, j + k])
                            {
                                Arr[i, j + k + 1] = Arr[i, j + k] * 2+1;
                                Arr[i, j + k] = 0;
                                k = 0;
                                break;
                            }
                            if (Arr[i, j + k + 1] != Arr[i, j + k] && Arr[i, j + k + 1] != 0)
                            {
                                k = 0;
                                break;
                            }
                            Arr[i, j + k + 1] = Arr[i, j + k];
                            Arr[i, j + k] = 0;
                            k++;
                        }
                    }
                }
            }
        }

        public static void SwipeS(int[,] Arr)
        {
            int k = 0;
            for (int i = 3; i > -1; i--)
            {
                for (int j = 3; j > -1; j--)
                {
                    if (Arr[i, j] > 0)
                    {
                        while (true)
                        {
                            if (i + k + 1 > 3)
                            {
                                k = 0;
                                break;
                            }
                            if (Arr[i + k + 1, j] == Arr[i + k, j])
                            {
                                Arr[i + k + 1, j] = Arr[i + k, j] * 2+1;
                                Arr[i + k, j] = 0;
                                k = 0;
                                break;
                            }
                            if (Arr[i + k + 1, j] != Arr[i + k, j] && Arr[i + k + 1, j] != 0)
                            {
                                k = 0;
                                break;
                            }
                            Arr[i + k + 1, j] = Arr[i + k, j];
                            Arr[i + k, j] = 0;
                            k++;
                        }
                    }
                }
            }
        }


        public static void SwipeW(int[,] Arr)
        {
            int k = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Arr[i, j] > 0)
                    {
                        while (true)
                        {
                            if (i - k - 1 < 0)
                            {
                                k = 0;
                                break;
                            }
                            if (Arr[i - k - 1, j] == Arr[i - k, j])
                            {
                                Arr[i - k - 1, j] = Arr[i - k, j] * 2+1;
                                Arr[i - k, j] = 0;
                                k = 0;
                                break;
                            }
                            if (Arr[i - k - 1, j] != Arr[i - k, j] && Arr[i - k - 1, j] != 0)
                            {
                                k = 0;
                                break;
                            }
                            Arr[i - k - 1, j] = Arr[i - k, j];
                            Arr[i - k, j] = 0;
                            k++;
                        }
                    }
                }
            }
        }

        public static bool Win(int[,] Arr)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Arr[i, j] == 2048)
                    {
                        Console.Clear();
                        Console.WriteLine("                   YOU WIN                   ");
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool ArrCmp(int[,] Arr1, int[,] Arr2)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Arr2[i, j] != Arr1[i, j]) return false;
                }
            }
            return true;
        }

        public static bool Lose(int[,] Arr1, int[,] Arr2)
        {
            int a = 0, b = 0, c = 0, d = 0;

            SwipeA(Arr2);
            if (ArrCmp(Arr1, Arr2)) a = 1;
            Array.Copy(Arr1, Arr2, 16);

            SwipeW(Arr2);
            if (ArrCmp(Arr1, Arr2)) b = 1;
            Array.Copy(Arr1, Arr2, 16);

            SwipeS(Arr2);
            if (ArrCmp(Arr1, Arr2)) c = 1;
            Array.Copy(Arr1, Arr2, 16);

            SwipeD(Arr2);
            if (ArrCmp(Arr1, Arr2)) d = 1;
            Array.Copy(Arr1, Arr2, 16);

            if (a == 1 && b == 1 && c == 1 && d == 1)
            {
                Console.Clear();
                Console.WriteLine("                   YOU LOSE                 ");
                return true;
            }
            else return false;
        }

        public static void Main()
        {
            Random rnd = new Random();
            int[,] Arr = new int[4, 4];

            Arr[rnd.Next(0, 4), rnd.Next(0, 4)] = 2;
            Spawn(Arr, rnd);
            Output(Arr);

            while (true)
            {
                int[,] ArrCopy = new int[4, 4];
                Array.Copy(Arr, ArrCopy, 16);

                ConsoleKey consoleKey = Console.ReadKey().Key;

                switch(consoleKey)
                {
                    case ConsoleKey.W:
                        SwipeW(Arr);
                        break;

                    case ConsoleKey.A:
                        SwipeA(Arr);                       
                        break;

                    case ConsoleKey.S:
                        SwipeS(Arr);                       
                        break;

                    case ConsoleKey.D:
                        SwipeD(Arr);                     
                        break;
                }
                
                if (!ArrCmp(Arr,ArrCopy)) Spawn(Arr, rnd);
                else if (Lose(Arr, ArrCopy)) break;
                Output(Arr);

                if (Win(Arr)) break;
                if (Lose(Arr, ArrCopy)) break;
            }
            Console.ReadLine();
        }
    }
}