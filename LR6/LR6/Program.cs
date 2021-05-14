using System;
using System.Collections.Generic;
using System.Text;

namespace LR5
{

    public class Human : IComparer<Human>
    {
        private static int num = 1;
        public int Id { get; }
        public FIO fio;
        public struct FIO
        { 
            public string Name { get; set; }
            public string Surname { get; set; }
            public string MiddleName { get; set; }
        }
        public int Age { get; set; }
        public static int HowMuch { get; private set; } = 0;
        public Human(string name, string surname, int age)
        {
            HowMuch++;
            fio.Name = name;
            fio.Surname = surname;
            Age = age;
            fio.MiddleName = default;

            Id = GetNextId();
        }
        public Human(string name, string middleName, string surname, int age)
        {
            HowMuch++;
            fio.Name = name;
            fio.MiddleName = middleName;
            fio.Surname = surname;
            Age = age;

            Id = GetNextId();
        }
        public Human() { }
        private static int GetNextId()
        {
            return num++;
        }
        public override string ToString()
        {
            string info;
            if (fio.MiddleName == default)
            {
                info = $"ID: {Id}| {fio.Name} {fio.Surname}, age: {Age}";
            }
            else
            {
                info = $"ID: {Id}| {fio.Name} {fio.Surname} {fio.MiddleName}, age: {Age}";
            }
            return info;
        }
        public string this[string field]
        {
            get
            {
                switch (field)
                {
                    case "Name":
                        return fio.Name;
                    case "MiddleName":
                        return fio.MiddleName;
                    case "Surname":
                        return fio.Surname;
                    case "Age":
                        return Convert.ToString(Age);
                    default:
                        return null;

                }
            }
        }
        public int Compare(Human p1, Human p2)
        {
            if (p1.Age > p2.Age)
                return 1;
            else if (p1.Age < p2.Age)
                return -1;
            else
                return 0;
        }
    }
    public abstract class Student : Human
    {
        int GroupNumber;
        YearofStudy сourse;
        public enum YearofStudy
        {
            first = 1,
            second,
            third,
            fourth,
            fifth
        }
        public Student(string name, string surname, int age, YearofStudy сourse, int GroupNumber) : base(name, surname, age)
        {
            this.сourse = сourse;
            this.GroupNumber = GroupNumber;
        }
        public override string ToString()
        {
            string info = base.ToString();
            return info + $", is a {сourse} year student, group number: {GroupNumber}";
        }
        public abstract void GetInfo();
        public abstract void ITeach();
    }
    public interface ITechie
    {
        void IStudyTechnicalSciences();
    }
    public interface IHumanitarian
    {
        void IStudyHumanitarianSciences();  
    }
    public class StudentBSUIR : Student, ITechie, IHumanitarian
    {
        const string university = "BSUIR";
        Faculty faculty;
        public enum Faculty
        {
            FCD,
            FITM,
            FCSN,
        }
        public StudentBSUIR(string name, string surname, int age, YearofStudy сourse, int GroupNumber, Faculty faculty) : base(name, surname, age, сourse, GroupNumber)
        {
            this.faculty = faculty;
        }
        public override void GetInfo()
        {
            Console.WriteLine(fio.Name + " " + fio.Surname + " " + fio.MiddleName + "study in " + university + " at the faculty of " + faculty);
        }  
        public override string ToString()
        {
            string info = base.ToString();
            return info + $", university: {university}, faculty: {faculty}";
        } 
        public override void ITeach()
        {
            IStudyHumanitarianSciences();
            Console.Write("and ");
            IStudyTechnicalSciences();
        }
        public void IStudyTechnicalSciences()
        {
            Console.WriteLine("studies such technical sciences as: mathematics, physics, computer science, logic");
        }
        public void IStudyHumanitarianSciences() 
        {
            Console.WriteLine("studies such humanities as: philosophy, history, political science, Belarusian language");
        }
    }
    public class StudentBSU : Student, IHumanitarian
    {
        const string university = "BSU";
        Faculty faculty;
        public enum Faculty
        {
            GSTH,
            GDH,
        }
        public StudentBSU(string name, string surname, int age, YearofStudy сourse, int GroupNumber, Faculty faculty) : base(name, surname, age, сourse, GroupNumber)
        {
            this.faculty = faculty;
        }
        public override void GetInfo()
        {
            Console.WriteLine(fio.Name + " " + fio.Surname + " " + fio.MiddleName + "study in " + university + " at the faculty of " + faculty);
        }
        public override string ToString()
        {
            string info = base.ToString();
            return info + $", university: {university}, faculty: {faculty}";
        }
        public override void ITeach()
        {
            IStudyHumanitarianSciences();
        }
        public void IStudyHumanitarianSciences()
        {
            Console.WriteLine("studies such humanities as: philosophy, history, political science, Belarusian language");
        }
    }
    public class StudentBNTU : Student
    {
        const string university = "BNTU";
        Faculty faculty;
        public enum Faculty
        {
            FAGH,
            PAraPA,
            FILI,
            DCWG,
            FCD,
            FITM,
            FCSN,
        }
        public StudentBNTU(string name, string surname, int age, YearofStudy сourse, int GroupNumber, Faculty faculty) : base(name, surname, age, сourse, GroupNumber)
        {
            this.faculty = faculty;
        }

        public override void GetInfo()
        {
            Console.WriteLine(fio.Name + " " + fio.Surname + " " + fio.MiddleName + "study in " + university + " at the faculty of " + faculty);
        }
        public override string ToString()
        {
            string info = base.ToString();
            return info + $", university: {university}, faculty: {faculty}";
        }
        public override void ITeach()
        {
            Console.WriteLine("i don't learn anything");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Human.HowMuch);
            Human human1 = new Human("Daniil", "Drozd", 139);
            StudentBSUIR human3 = new StudentBSUIR("Alien", "Riply", 35, Student.YearofStudy.first, 233131, StudentBSUIR.Faculty.FCSN);
            StudentBSU human2 = new StudentBSU("Tarantul", "Taran", 67, Student.YearofStudy.third, 2358581, StudentBSU.Faculty.GDH);
            
            Console.WriteLine(human1);
            Console.WriteLine(human1["Name"]);

            Console.WriteLine(human3);

            Console.WriteLine(Human.HowMuch);

            Console.WriteLine();
            human3.GetInfo();
            human3.ITeach();
            Console.WriteLine();

            Human[] people = new Human[] { human1, human2, human3 };
            Array.Sort(people, new Human());

            foreach (Human p in people)
            {
                Console.WriteLine($"{p.fio.Name} - {p.Age}");
            }
            Console.ReadKey();
        }
    }
}