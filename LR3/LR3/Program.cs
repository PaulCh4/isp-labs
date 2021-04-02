using System;

namespace LR3
{
    class Human
    {
        private int id;
        private char gender;
        private string[] Full_name = new string[3];
        public int years { get; set; }

        private static int num = 1;
        private static int GetNextId()
        {
            return num++;
        }

        public string[] AddInfo;
        public int Leng = 0;
        public void Add_Info(int Size)
        {
            AddInfo = new string[Size];
            Leng = Size;
        }
        public string this[int index]
        {
            set
            {
                AddInfo[index] = value;
            }
            get
            {
                return AddInfo[index];
            }
        }

        public Human(string Name, string Surname, string Secondname, int years, char gender)
        {
            Full_name[0] = Name;
            Full_name[1] = Surname;
            Full_name[2] = Secondname;
            this.years = years;
            _gender = gender;

            id = GetNextId();
        }
        public Human() { }

        public char _gender
        {
            get
            {
                return gender;
            }
            set
            {
                if (value == 'M' || value == 'F') gender = value;
                else gender = '-';
            }
        }

        public void SetFullName(string Name, string Surname, string Secondname)
        {
            Full_name[0] = Name;
            Full_name[1] = Surname;
            Full_name[2] = Secondname;

        }
        public void SetFullName(string Name, string Surname)
        {
            Full_name[0] = Name;
            Full_name[1] = Surname;
            Full_name[2] = null;
        }
        public void SetFullName(string Name)
        {
            Full_name[0] = Name;
            Full_name[1] = null;
            Full_name[2] = null;
        }
        private void WriteFullName()
        {
            Console.WriteLine(Full_name[0] + " " + Full_name[1] + " " + Full_name[2]);
        }

        public void PrintInfo()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.Write("Full name: ");
            WriteFullName();
            Console.WriteLine("Year of birth: " + years);
            if (_gender == 'M') Console.WriteLine("Genader: male");
            else if (_gender == 'F') Console.WriteLine("Genader: female");
            else Console.WriteLine("Gender: ---");
            Console.WriteLine("ID: " + id);
            if (Leng != 0)
            {
                Console.WriteLine("Additional Information: ");
                for (int i = 0; i < Leng; i++)
                {
                    if (AddInfo[i] == null) AddInfo[i] = "---";
                    Console.WriteLine("\t" + (i + 1) + ". " + AddInfo[i]);

                }
            }
        }
        public void ScanInfo()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Enter your name: ");
            Full_name[0] = Console.ReadLine();
            Console.WriteLine("Enter your surname: ");
            Full_name[1] = Console.ReadLine();
            Console.WriteLine("Enter your secondname: ");
            Full_name[2] = Console.ReadLine();
            Console.WriteLine("Enter your year of birth: ");
            years = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choos your gender - male[M] or female[F]:");
            _gender = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("add a couple of points? Yes[Y] or No[N]");
            ConsoleKey consoleKey = Console.ReadKey().Key;
            switch (consoleKey)
            {
                case ConsoleKey.Y:
                    int k;
                    Console.WriteLine("\nhow much ?");
                    Add_Info(Convert.ToInt32(Console.ReadLine()));
                    for (int i = 0; i < Leng; i++)
                    {
                        Console.Write((i + 1) + ". ");
                        AddInfo[i] = Console.ReadLine();
                    }
                    break;

                case ConsoleKey.N:
                    break;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Human human = new Human("Benedict", "Timothy", "Carlton", 1979, 'M');
            Human human2 = new Human("Elizabeth", "Alexandra", "Mary", 1975, 'F');
            Human human3 = new Human("Elapidae", "Severus", "Snape", 1988, '7');

            human.PrintInfo();
            human.SetFullName("Ellen", "Louise", "Ripley");
            human._gender = 'F';
            human.PrintInfo();

            human.SetFullName("Will", "Smith");
            human._gender = 'M';
            human.Add_Info(3);
            human[1] = "loves music very much";

            human.PrintInfo();
            human2.PrintInfo();
            human3.PrintInfo();

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Change human 3:");
            human3.ScanInfo();
            human3.PrintInfo();

            Console.ReadLine();
        }
    }
}
