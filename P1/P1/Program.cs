using System;

namespace P1
{
    class Program
    {
        static void Main(string[] args)
        {          
            Intern c1 = new Intern();
            Intern c2 = new Intern();

            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            Operatii o = new Operatii(a, b);

            Console.WriteLine($"a + b = {a + b:0.00}");
            Console.WriteLine($"a - b = {a - b:0.00}");
            Console.WriteLine($"a * b = {a * b:0.00}");
            Console.WriteLine($"a / b = {a / b:0.00}");
            
            int n;
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
            Stelute s = new Stelute(n);
        }
    }

    class Intern
    {
        public Intern()
        {
            Console.WriteLine("Hello World!");
        }
        static Intern()
        {
            Console.WriteLine("Hello!");
        }
        private Intern(int a)
        {
            Console.WriteLine("Hello C#!");
        }
        ~Intern()
        {
            Console.WriteLine("Destruct!");
        }
    }

    class Operatii
    {
        private double a, b;

        public Operatii(double a, double b)
        {
            this.a = a;
            this.b = b;

            Adunare();
            Scadere();
            Inmultire();
            Impartire();
        }

        private double Impartire()
        {
            return a / b;
        }

        private double Inmultire()
        {
            return a * b;
        }

        private double Scadere()
        {
            return a - b;
        }

        private double Adunare()
        {
            return a + b;
        }
    }

    class Stelute
    {
        int n;
        public Stelute(int n)
        {
            this.n = n;
            Afisare();
        }

        private void Afisare()
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                    Console.Write('*');
                Console.WriteLine();
            }
        }
    }
}
