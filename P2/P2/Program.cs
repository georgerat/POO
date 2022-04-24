using System;

namespace P2
{
    // Se considera clasa dreptunghi, avand caracteristicile lungime si latime de tip real. Sa se scrie un constructor,
    // o proprietate si o autoproprietate. Sa se calculeze in Main aria prin intermediul proprietatilor.

    class Program
    {
        static void Main(string[] args)
        {
            Dreptunghi d = new Dreptunghi();
            Console.Write("Lungime = ");
            d.Lungime = double.Parse(Console.ReadLine());
            Console.Write("Latime = ");
            d.Latime = double.Parse(Console.ReadLine());
            double aria = d.Lungime * d.Latime;
            Console.WriteLine($"Aria dreptunghiului = {aria}");
        }
    }

    class Dreptunghi
    {
        double lungime, latime;

        public double Lungime
        {
            get { return lungime; }
            set { if (value > 0) lungime = value; }
        }

        public double Latime
        {
            get { return latime; }
            set { if (value > 0) latime = value; }
        }
    }
}
