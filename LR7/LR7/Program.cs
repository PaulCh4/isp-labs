using System;
using System.Text;

namespace LR7
{
    class Rational : IComparable, IEquatable<Rational>
    {
        public int num;
        public int den;
        public string fraction { get; set; }
        public Rational(string num)
        {
            defineFormat(num);
            fraction = num;
        }
        public Rational(int a, int b)
        {
            num = a;
            den = b;
            fraction = $"{num}/{den}";
        }
        public Rational(){}

        public bool Equals(Rational other)
        {
            int commondem = ComDen(this.den, other.den, other);
            int multiply1 = commondem / this.den;
            int multiply2 = commondem / other.den;

            this.Contract();
            other.Contract();

            if (this.num * multiply1 == other.num * multiply2)
                return true;

            return false;
        }

        public int CompareTo(object obj)
        {
            Rational other = obj as Rational;

            other.Contract();
            this.Contract();


            if (this.den == other.den)
            {
                return (this.num).CompareTo(other.num);
            }
            else if (this.den != other.den)
            {

                int commondem = ComDen(this.den, other.den, other);
                int multiply1 = commondem / this.den;
                int multiply2 = commondem / other.den;
                return (this.num * multiply1).CompareTo(other.num * multiply2);

            }
            if (obj == null) return 1;
            else
                return 2;
        }

        private int ComDen(int a, int b, Rational r)
        {

            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            return Math.Abs(den * r.den) / a;
        }

        public void defineFormat(string str)
        {
            int format = 2;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '/' || str[i] == '\\')
                {
                    format = 0;
                    break;
                }
                else if (str[i] == '.' || str[i] == ',')
                {
                    format = 1;
                    break;
                }
            }

           
            StringBuilder _temp = new StringBuilder();
            int pos = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '/' || str[i] == '.' || str[i] == ',' || str[i] == '\\')
                {
                    pos = i + 1;
                    break;
                }
                else
                {
                    _temp.Append(str[i]);
                }
            }
            string temp = _temp.ToString();
            int a = int.Parse(temp);

            StringBuilder _temp2 = new StringBuilder();
            for (int i = pos; i < str.Length; i++)
            {
                _temp2.Append(str[i]);
            }
            string temp2 = _temp2.ToString();
            int b = int.Parse(temp2);
            

            if (format == 0) 
            {
                num = a;
                den = b;
            }
            else if (format == 1) 
            {
                int pdten = (int)Math.Pow(10, temp2.Length);
                if (a > 0)
                {
                    num = b + (pdten * a);
                }
                else
                {
                    num = b;
                }
                den = pdten;
                Format("0");
            }
            else
            {
                num = a;
                den = 1;
            }
        }

        public int Format(string pick)
        {
            Contract();
            if(pick == "0")
                fraction = ((double)num / den).ToString();
            else 
                fraction = $"{num}/{den}";
                return 0;
        }

        public void Contract()
        {
            int a = num;
            int b = den;
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            den /= a;
            num /= b;
        }

        public override string ToString()
        {
            return fraction;
        }

        public static Rational operator +(Rational a, Rational b)
        {
            a.Contract();
            b.Contract();
            int commondem = a.ComDen(a.den, b.den, b);
            int multiply1 = commondem / a.den;
            int multiply2 = commondem / b.den;

            if (a.den == b.den)
            {
                return new Rational(a.num + b.num, a.den);
            }
            else
            {
                return new Rational((a.num * multiply1) + (b.num * multiply2), commondem);
            }
        }

        public static Rational operator -(Rational a, Rational b)
        {
            int commondem = a.ComDen(a.den, b.den, b);
            int multiply1 = commondem / a.den;
            int multiply2 = commondem / b.den;

            if (a.den == b.den)
            {
                return new Rational(a.num - b.num, a.den);
            }
            else
            {
                return new Rational((a.num * multiply1) - (b.num * multiply2), commondem);
            }
        }

        public static Rational operator *(Rational a, Rational b)
        {
            a.Contract();
            b.Contract();
            return new Rational(a.num * b.num, a.den * b.den);
        }

        public static Rational operator /(Rational a, Rational b)
        {
            a.Contract();
            b.Contract();
            return new Rational(a.num * b.den, a.den * b.num);
        }

        public static Rational operator -(Rational a)
        {
            return new Rational(-a.num, a.den);
        }

        public static Rational operator ++(Rational a)
        {
            return new Rational(a.num + a.den, a.den);
        }

        public static bool operator >(Rational a, Rational b)
        {
            a.Contract();
            b.Contract();
            int _t = a.CompareTo(b);
            if (_t == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <(Rational a, Rational b)
        {
            a.Contract();
            b.Contract();
            int _t = a.CompareTo(b);
            if (_t == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator ==(Rational a, Rational b)
        {
            a.Contract();
            b.Contract();
            return a.Equals(b);
        }

        public static bool operator !=(Rational a, Rational b)
        {
            a.Contract();
            b.Contract();
            return !a.Equals(b);
        }

        public static explicit operator int(Rational a)
        {
            double _d = (double)a;
            double mod = _d - Math.Truncate(_d);
            if (mod >= 0.5)
            {
                return (a.num / a.den) + 1;
            }
            else
            {
                return a.num / a.den;
            }
        }

        public static implicit operator Rational(double a)
        {
            return new Rational(a.ToString());
        }

        public static implicit operator Rational(int a)
        {
            return new Rational(a, 1);
        }

        public static explicit operator double(Rational a)
        {
            return (double)a.num / a.den;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Rational first = new Rational("12/3"); 
            Rational second = new Rational("2.13");

            
            Console.WriteLine(first.ToString());
            Console.WriteLine(second.ToString());
            Console.WriteLine();

            Rational result = first + second;
            result.Format("0");
            Console.WriteLine("(+) " + result.ToString());

            result = first - second;
            result.Format("0");
            Console.WriteLine("(-) " + result.ToString());

            result = first * second;
            result.Format("1");
            Console.WriteLine("(*) " + result.ToString());

            result = first / second;
            result.Format("1");
            Console.WriteLine("(/) " + result.ToString());
            Console.WriteLine();

            second.Format("1");
            if (first == second)
            {
                Console.WriteLine($"{first} = {second}");
            }
            else if (first < second)
            {
                Console.WriteLine($"{first} < {second}");
            }
            else if (first > second)
            {
                Console.WriteLine($"{first} > {second}");
            }

             Console.ReadLine();
        }    
    }
}
