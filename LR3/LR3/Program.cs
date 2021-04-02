using System;

namespace LR3
{
    class Human
    {
        private static int Num = 1;
        private static int GetNextId()
        {
            return Num++;
        }

        public int years { get; set; }
        private int id; 
        private char gender;
        private string[] Full_name = new string[3];

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
            Gender = gender;

            id = GetNextId();
        }
        
        public char Gender
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
            if (Gender == 'M') Console.WriteLine("Genader: male");
            else if (Gender == 'F') Console.WriteLine("Genader: female");
            else Console.WriteLine("Gender: ---");
            Console.WriteLine("ID: " + id);
            if (Leng != 0)
            {
                Console.WriteLine("Additional Information: ");
                for (int i = 0; i < Leng; i++)
                {
                    if(AddInfo[i]==null) AddInfo[i] = "---";
                    Console.WriteLine((i+1) + ". " + AddInfo[i]);
                    
                }
            }
            Console.WriteLine("----------------------------------------------------");
        }
        public void ScanInfo()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.Write("Enter your name: ");
            Full_name[0] = Console.ReadLine();
            Console.Write("Enter your surname: ");
            Full_name[1] = Console.ReadLine();
            Console.Write("Enter your secondname: ");
            Full_name[2] = Console.ReadLine();
            Console.Write("Enter your year of birth: ");
            years = Convert.ToInt32(Console.ReadLine());
            Console.Write("Choos your gender - male[M] or female[F]:");
            Gender = Convert.ToChar(Console.ReadLine());
         
            Console.WriteLine("add a couple of points? Yes[Y] or No[N]");
            ConsoleKey consoleKey = Console.ReadKey().Key;
            switch (consoleKey)
            {
                case ConsoleKey.Y:
                    int k;
                    Console.WriteLine("how much ?");                
                    Add_Info(Convert.ToInt32(Console.ReadLine()));
                    for (int i = 0; i < Leng; i++)
                    {
                        Console.WriteLine((i+1)+". ");
                        AddInfo[i] = Console.ReadLine();
                    }
                    break;

                case ConsoleKey.N:
                    break;
            }
            Console.WriteLine("----------------------------------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Human human = new Human("Losyn","Egor","Igorevich",1985,'M');
            Human human2 = new Human("Dub", "Nastya", "Dmitriyvna", 2007, 'F');
            Human human3 = new Human("Ktulhu", "Oleg", "Marat", 1997, 'M');

            human.PrintInfo();
            human.SetFullName("Troik", "Tanya", "Losyanavna");
            human.Gender = 'F';
            human.PrintInfo();

            human.SetFullName("Will", "Smith");
            human.Gender = 'M';
            human.Add_Info(3);
            human[1] = "loves music very much";

            human.PrintInfo();
            human2.PrintInfo();
            human3.PrintInfo();
    
            Console.WriteLine(human.Leng); 

            human3.ScanInfo();
            human3.PrintInfo();

            Console.ReadLine();
        }
    }
}
