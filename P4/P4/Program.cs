using System;
using System.Text;

namespace P4
{
    //Sa se creeze un tip de date definit de utilizator, numit time pentru reprezentarea timpului sub forma ore(nelimitat),
    //minute(0-59), secunde(0-59), sutimi(0-100). Pentru acest tip de date sa se implementeze operatiile de adunare a 2 timpi,
    //respectiv de scadere, precum si operatorii relationari. Se vor utiliza 4 modalitati de initializare a unui obiect de tip
    //time si anume, time(ore, minute), time(ore, minute, secunde), time(ore, minute, secunde, sutimi) si string.

    class Program
    {
        static void Main(string[] args)
        {
            Time t1 = new Time(10, 28, 59, 86);
            Time t2 = new Time("18:35:0.16");
            Console.WriteLine($"Timp1: {t1}");
            Console.WriteLine($"Timp2: {t2}");

            if (t1 == t2)
                Console.WriteLine("Datele coincid.");
            else
            {
                if (t1 < t2)
                {
                    Console.WriteLine("Time 1 este mai mic decat time 2.");
                    Console.WriteLine($"Diferenta dintre time 2 si time 1 este {t2 - t1}");
                    Console.WriteLine($"Suma dintre time 1 si time 2 este {t1 + t2}");
                }
                else
                {
                    Console.WriteLine("Time 2 este mai mic decat time 1.");
                    Console.WriteLine($"Diferenta dintre time 1 si time 2 este {t1 - t2}");
                    Console.WriteLine($"Suma dintre time 1 si time 2 este {t1 + t2}");
                }
            }
        }
    }

    class Time
    {
        private int ora, minute, secunde, sutimi;

        public Time(int ora, int minute, int secunde = 0, int sutimi = 0)
        {
            this.ora = ora;
            this.minute = minute;
            this.secunde = secunde;
            this.sutimi = sutimi;
        }

        public Time(string s)
        {
            char[] sep = { '.', ',', ':' };
            string[] x = s.Split(sep);

            if (x.Length != 4)
                Console.WriteLine("Timp incomplet.");
            else
            {
                this.ora = Convert.ToInt32(x[0]);
                this.minute = Convert.ToInt32(x[1]);
                this.secunde = Convert.ToInt32(x[2]);
                this.sutimi = Convert.ToInt32(x[3]);
            }
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.AppendFormat("{0}:{1}:{2}.{3}", ora, minute, secunde, sutimi);
            return s.ToString();
        }

        public static Time operator +(Time t1, Time t2)
        {
            Time t = new Time(0, 0, 0, 0);
            int k;
            t.sutimi = (t1.sutimi + t2.sutimi) % 100;
            k = (t1.sutimi + t2.sutimi) / 100;
            t.secunde = (t1.secunde + t2.secunde + k) % 60;
            k = (t1.secunde + t2.secunde) / 60;
            t.minute = (t1.minute + t2.minute + k) % 60;
            k = (t1.minute + t2.minute) / 60;
            t.ora = t1.ora + t2.ora + k;
            return t;
        }

        public static Time operator -(Time t1, Time t2)
        {
            Time t = new Time(0, 0, 0, 0);
            int k = 0;

            if (t1.sutimi - t2.sutimi > 0)
            {
                t.sutimi = (t1.sutimi - t2.sutimi);
                k = 0;
            }
            else
            {
                t.sutimi = 100 + t1.sutimi - t2.sutimi;
                k = 1;
            }

            if (t1.secunde - t2.secunde - k > 0)
            {
                t.secunde = (t1.secunde - t2.secunde) - k;
                k = 0;
            }
            else
            {
                t.secunde = 60 + t1.secunde - t2.secunde - k;
                k = 1;
            }

            if (t1.minute - t2.minute - k > 0)
            {
                t.minute = (t1.minute - t2.minute) - k;
                k = 0;
            }
            else
            {
                t.minute = 60 + t1.minute - t2.minute - k;
                k = 1;
            }

            t.ora = t1.ora - t2.ora - k;
            return t;
        }

        public static bool operator ==(Time t1, Time t2)
        {
            if ((t1.ora == t2.ora) && (t1.minute == t2.minute) && (t1.secunde == t2.secunde) && (t1.sutimi == t2.sutimi))
                return true;
            return false;
        }

        public static bool operator !=(Time t1, Time t2)
        {
            if (t1 == t2)
                return false;
            return true;
        }

        public static bool operator <(Time t1, Time t2)
        {
            if (t1.ora < t2.ora)
                return true;
            if ((t1.ora == t2.ora) && (t1.minute < t2.minute))
                return true;
            if ((t1.ora == t2.ora) && (t1.minute == t2.minute) && (t1.secunde < t2.secunde))
                return true;
            if ((t1.ora == t2.ora) && (t1.minute == t2.minute) && (t1.secunde == t2.secunde) && (t1.sutimi < t2.sutimi))
                return true;
            return false;
        }

        public static bool operator <=(Time t1, Time t2)
        {
            if (t1 < t2 || t1 == t2)
                return true;
            return false;
        }

        public static bool operator >(Time t1, Time t2)
        {
            if (t1 <= t2)
                return false;
            return true;
        }

        public static bool operator >=(Time t1, Time t2)
        {
            if (t1 < t2)
                return false;
            return true;
        }
    }
}
