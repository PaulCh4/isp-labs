using System;

namespace LR5  
{
    public class Human
    {
        private static int num = 1;
        public int Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; }
        public static int HowMuch { get; private set; } = 0;
        public Human(string name, string surname, int age)
        {
            HowMuch++;
            Name = name;
            Surname = surname;
            Age = age;
            MiddleName = default;

            Id = GetNextId();
        }
        public Human(string name, string middleName, string surname, int age)
        {
            HowMuch++;
            Name = name;
            MiddleName = middleName;
            Surname = surname;
            Age = age;

            Id = GetNextId();
        }      
        private static int GetNextId()
        {
            return num++;
        }
        public override string ToString()
        {
            string info;
            if (MiddleName == default)
            {
                info = $"ID: {Id}| {Name} {Surname}, age: {Age}";
            }
            else
            {
                info = $"ID: {Id}| {Name} {Surname} {MiddleName}, age: {Age}";
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
                        return Name;
                    case "MiddleName":
                        return MiddleName;
                    case "Surname":
                        return Surname;
                    case "Age":
                        return Convert.ToString(Age);
                    default:
                        return null;
                }
            }
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
    }
    public class StudentBSUIR : Student  
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
            Console.WriteLine(Name + " " + Surname + " " + MiddleName + "study in " + university + " at the faculty of " + faculty);
        }
        public override string ToString()
        {
            string info = base.ToString();
            return info + $", university: {university}, faculty: {faculty}";
        }
    }
    public class StudentBSU : Student
    {
        const string university = "BSU";
        Faculty faculty;
        public enum Faculty
        {
            FAED,
            GGG,
            DBHUW,
            DCWG,
            VDTA
        }
        public StudentBSU(string name, string surname, int age, YearofStudy сourse, int GroupNumber, Faculty faculty) : base(name, surname, age, сourse, GroupNumber)
        {
            this.faculty = faculty;
        }
        public override void GetInfo()
        {
            Console.WriteLine(Name + " " + Surname + " " + MiddleName + "study in " + university + " at the faculty of " + faculty);
        }
        public override string ToString()
        {
            string info = base.ToString();
            return info + $", university: {university}, faculty: {faculty}";
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
            Console.WriteLine(Name + " " + Surname + " " + MiddleName + "study in " + university + " at the faculty of " + faculty);
        }
        public override string ToString()
        {
            string info = base.ToString();
            return info + $", university: {university}, faculty: {faculty}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Human.HowMuch);
            Human human1 = new Human("Gendalph", "White", 130);
            Human human2 = new Human("Vasy", "Vasyn", "Vasyninov", 20);
            Student human3 = new StudentBSUIR("Road", "Warrior", 35, Student.YearofStudy.first, 233131, StudentBSUIR.Faculty.FCSN);
         
            Console.WriteLine(human1);
            Console.WriteLine(human2["Name"]);          
            Console.WriteLine(human3);

            Console.WriteLine(Human.HowMuch);

            Console.WriteLine();
            human3.GetInfo();

            Console.ReadKey();
        }
    }
}