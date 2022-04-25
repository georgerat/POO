using System;
using System.Text;

namespace P3
{
    //Sa se creeze un tip de date definit de utilizator, numit date pentru reprezentarea datei calendaristice, sub forma: 
    //zi luna an. Pentru acest tip de date sa se implementeze operatorii operationali, precum si o operatie pentru determinarea
    //diferentei in numar de zile dintre doua date. Se vor utiliza doua modalitati de initializare a unui obiect de tip date,
    //si anume date(zi, luna, an) si date("zi.luna.an").

    class Program
    {
        static void Main(string[] args)
        {
            Date d1 = new Date("15.12.2021");
            Date d2 = new Date(28, 10, 2022);
            Console.WriteLine($"Data 1: {d1}");
            Console.WriteLine($"Data 2: {d2}");

            if (d1 == d2)
                Console.WriteLine("Datele coincid.");
            else
            {
                if (d1 < d2)
                {
                    Console.WriteLine("Data 1 este anterioara datei 2.");
                    Console.WriteLine($"Numarul de zile dintre data 1 si data 2 este {d2 - d1}.");
                }
                else
                {
                    Console.WriteLine("Data 2 este anterioara datei 1.");
                    Console.WriteLine($"Numarul de zile dintre data 2 si data 1 este {d1 - d2}.");
                }
            }
        }
    }

    class Date
    {
        private int zi, luna, an;

        public Date(int zi, int luna, int an)
        {
            this.zi = zi;
            this.luna = luna;
            this.an = an;
        }

        public Date(string s)
        {
            char[] separator = { '.', ',', '/', ':' };
            string[] x = s.Split(separator);
            if (x.Length != 3)
                Console.WriteLine("Data incorecta!");
            else
            {
                this.zi = Convert.ToInt32(x[0]);
                this.luna = Convert.ToInt32(x[1]);
                this.an = Convert.ToInt32(x[2]);
            }
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("{0}.{1}.{2}", zi, luna, an);
            return s.ToString();
        }

        public static int GetDays(Date d)
        {
            int zile = 0;
            for (int i = 1; i < d.an; i++)
                zile += (DateTime.IsLeapYear(i)) ? 365 : 366;
            for (int i = 1; i < d.luna; i++)
                zile += (DateTime.DaysInMonth(d.an, i));
            zile += d.zi;
            return zile;
        }

        public static int operator -(Date d1, Date d2)
        {
            return Math.Abs(GetDays(d1) - GetDays(d2));
        }

        public static bool operator ==(Date d1, Date d2)
        {
            if ((d1.an == d2.an) && (d1.luna == d2.luna) && (d1.zi == d2.zi))
                return true;
            return false;
        }

        public static bool operator !=(Date d1, Date d2)
        {
            if (d1 == d2)
                return false;
            return true;
        }

        public static bool operator <(Date d1, Date d2)
        {
            if (d1.an < d2.an)
                return true;
            if ((d1.an == d2.an) && (d1.luna < d2.luna))
                return true;
            if ((d1.an == d2.an) && (d1.luna == d2.luna) && (d1.zi < d2.zi))
                return true;
            return false;
        }

        public static bool operator <=(Date d1, Date d2)
        {
            if (d1 < d2 || d1 == d2)
                return true;
            return false;
        }

        public static bool operator >(Date d1, Date d2)
        {
            if (d1 <= d2)
                return false;
            return true;
        }

        public static bool operator >=(Date d1, Date d2)
        {
            if (d1 < d2)
                return false;
            return true;
        }
    }
}
