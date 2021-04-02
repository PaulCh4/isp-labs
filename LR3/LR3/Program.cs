using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR3
{
    class Human
    {
        private static int Num = 1;
        private static int GetNextId()
        {
            return Num++;
        }

        private int years;
        private int id; 
        private char gender;
        private string[] Full_name = new string[3];
        
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
            human.SetFullName("Tanya", "Troik");

            human.PrintInfo();
            human2.PrintInfo();
            human3.PrintInfo();

            human3.ScanInfo();
            human.PrintInfo();

            Console.ReadLine();
        }
    }
}
