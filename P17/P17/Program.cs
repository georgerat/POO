using System;

namespace P17
{
    //Sa se implementeze clasele Cerc si Patrat pe baza interfetei IForma2D care va contine metodele aria si lungimea frontierei
    //precum si proprietatea de numire de tip read-only. Metodele vor fi apelate din interiorul unei alte metode care are un
    //parametru de tipul interfetei care poate referi orice obiect care implementeza interfata.

    class Program
    {
        static void DisplayInfo(IForma2D f)
        {
            Console.WriteLine("Aria = {0:#.##} \t Lungimea frontierei = {1:#.##}", f.Aria(), f.LungimeaFrontierei());
            Console.WriteLine();
        }

        static void DisplayInfo(IForma3D f)
        {
            Console.WriteLine("Volumul = {0:#.##}", f.Volum());
            Console.WriteLine();
        }

        static void Main()
        {
            Cerc c = new Cerc(3);
            Console.WriteLine("Afiseaza informatii despre {0}:", c.denumire);
            DisplayInfo(c);
            //sau Console.WriteLine("aria = {0:#.##} \t lungimea frontierei = {1:#.##}", c.Aria(), c.LungimeaFrontierei());

            Patrat p = new Patrat(5);
            Console.WriteLine("Afiseaza informatii despre {0}:", p.denumire);
            DisplayInfo(p);

            Cub cub = new Cub(5);
            Console.WriteLine("Afiseaza informatii despre {0}:", cub.denumire);
            DisplayInfo(cub);
            //sau Console.WriteLine("Volumul = {0:#.##}", cub.Volum());
        }
    }

    public interface IForma
    {
        string denumire { get; }
    }

    public interface IForma2D : IForma
    {
        double Aria();
        double LungimeaFrontierei();
    }

    public interface IForma3D : IForma
    {
        double Volum();
    }

    public class Cerc : IForma2D
    {
        public double raza;
        private const float PI = 3.14159F;
        string s = "cerc";

        public Cerc(double r)
        {
            raza = r;
        }

        public double Aria()
        {
            return (PI * raza * raza);
        }

        public double LungimeaFrontierei()
        {
            return (2 * PI * raza);
        }

        public string denumire
        {
            get
            {
                return s;
            }
        }
    }

    public class Patrat : IForma2D
    {
        public double latura;
        string s = "patrat";

        public Patrat(double l)
        {
            latura = l;
        }

        public double Aria()
        {
            return latura * latura;
        }

        public double LungimeaFrontierei()
        {
            return 4 * latura;
        }

        public string denumire
        {
            get
            {
                return s;
            }
        }
    }

    public class Cub : IForma3D
    {
        public double latura;
        string s = "cub";

        public Cub(double l)
        {
            latura = l;
        }

        public double Volum()
        {
            return latura * latura * latura;
        }

        public string denumire
        {
            get
            {
                return s;
            }
        }
    }
}
