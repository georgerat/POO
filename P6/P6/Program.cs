using System;
using System.Text;

namespace P6
{
    //Sa se scrie un tip de date pentru lucrul cu numere rationale(numarator si numitor). Sa se implementeze pentru acest tip
    //operatiile de adunare, scadere, inmultire, impartire, ridicare la putere, operatori relationari, precum si o operatie
    //pentru aducerea fractiei la forma ireductibila. Se vor utiliza 3 modalitati de initializare a unui obiect de acest tip,
    //si anume rational(), rational(n), rational(n, m).

    class Program
    {
        static void Main(string[] args)
        {
            Rational r1 = new Rational(6, 4);
            Rational r2 = new Rational(8, 10);
            Console.WriteLine($"x = {r1}");
            Console.WriteLine($"y = {r2}");

            Console.WriteLine($"x + y = {r1 + r2}");
            Console.WriteLine($"x - y = {r1 - r2}");
            Console.WriteLine($"x * y = {r1 * r2}");
            Console.WriteLine($"x : y = {r1 / r2}");

            int k = 3;
            Console.WriteLine($"x ^ {k} = {r1 ^ k}");

            if (r1 == r2)
                Console.WriteLine($"{r1} = {r2}");
            else
            {
                if (r1 < r2)
                    Console.WriteLine($"{r1} < {r2}");
                else if (r1 > r2)
                    Console.WriteLine($"{r1} > {r2}");
            }
        }
    }

    class Rational
    {
        private int a, b;

        public Rational(int a = 0, int b = 1)
        {
            if (b < 0)
                this.a = -a;
            else
                this.a = a;
            if (b == 0)
            {
                Console.WriteLine("EROARE!");
                return;
            }
            this.b = Math.Abs(b);
            this.ireductibil();
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            if (b == 1 || a == 0)
                s.AppendFormat($"{a}");
            else
                s.AppendFormat($"{a} / {b}");
            return s.ToString();
        }

        public static Rational operator +(Rational r1, Rational r2)
        {
            return new Rational(r1.a * r2.b + r1.b * r2.a, r1.b * r2.b);
        }

        public static Rational operator -(Rational r1, Rational r2)
        {
            return new Rational(r1.a * r2.b - r1.b * r2.a, r1.b * r2.b);
        }

        public static Rational operator *(Rational r1, Rational r2)
        {
            return new Rational(r1.a * r2.a, r1.b * r2.b);
        }

        public static Rational operator /(Rational r1, Rational r2)
        {
            return new Rational(r1.a * r2.b, r1.b * r2.a);
        }

        public static Rational operator ^(Rational r1, int k)
        {
            int a = 1, b = 1;
            for (int i = 0; i < k; i++)
            {
                a = a * r1.a;
                b = b * r1.b;
            }
            return new Rational(a, b);
        }

        public static bool operator <(Rational r1, Rational r2)
        {
            double a = (double)(r1.a) / (double)(r1.b);
            double b = (double)(r2.a) / (double)(r2.b);
            if (a < b)
                return true;
            return false;
        }

        public static bool operator >(Rational r1, Rational r2)
        {
            double a = (double)(r1.a) / (double)(r1.b);
            double b = (double)(r2.a) / (double)(r2.b);
            if (a > b)
                return true;
            return false;
        }

        public static bool operator ==(Rational r1, Rational r2)
        {
            double a = (double)(r1.a) / (double)(r1.b);
            double b = (double)(r2.a) / (double)(r2.b);
            if (a == b)
                return true;
            return false;
        }

        public static bool operator !=(Rational r1, Rational r2)
        {
            double a = (double)(r1.a) / (double)(r1.b);
            double b = (double)(r2.a) / (double)(r2.b);
            if (a != b)
                return true;
            return false;
        }

        static int cmmdc(int a, int b)
        {
            if (b == 0)
                return a;
            else
                return cmmdc(b, a % b);
        }

        public void ireductibil()
        {
            int k = cmmdc(a, b);
            a /= k;
            b /= k;
        }
    }
}
