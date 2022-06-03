using System;

namespace P19
{
    //Delegare care apeleaza metode ale unor obiecte.

    class Program
    {
        static void Main()
        {
            Cerc c = new Cerc(3);
            MyDelegate del = new MyDelegate(c.Aria);
            Console.WriteLine($"Aria : {del():#.##}");
            del = new MyDelegate(c.LungimeFrontiera);
            Console.WriteLine($"Lungimea frontierei : {del():#.##}");
        }
    }

    public delegate double MyDelegate();

    public class Cerc
    {
        public double raza;
        private const float PI = 3.14159f;

        public Cerc(double r)
        {
            raza = r;
        }

        public double Aria()
        {
            return PI * raza * raza;
        }

        public double LungimeFrontiera()
        {
            return 2 * PI * raza;
        }
    }
}
