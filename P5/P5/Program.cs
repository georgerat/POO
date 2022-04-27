using System;
using System.Text;

namespace P5
{
    //Sa se creeze un tip de date definit de utilizator pentru lucrul cu numere complexe.Sa se implementeze pentru acest tip
    //operatiile de adunare, scadere si inmultire a doua numere complexe, ridicarea la putere si afisarea in forma
    //trigonometrica. Se vor utiliza trei modalitati de initializare a unui obiect de tipul complex: complex(),
    //complex cu un parametru(partea reala), complex cu doi parametri(real si imaginar).

    class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(12, 2.38);
            Complex c2 = new Complex(6.26, 8.80);
            Console.WriteLine(c1);
            Console.WriteLine(c2);
            Console.WriteLine($"Suma: {c1 + c2}");
            Console.WriteLine($"Diferenta: {c1 - c2}");
            Console.WriteLine($"Inmultirea: {c1 * c2}");
            int k = 3;
            Console.WriteLine($"c1 ^ {k} = {c1 ^ k}");
            Console.WriteLine($"Forma trigonometrica: c1 = {c1.trigo()}");
            Console.WriteLine($"Forma trigonometrica: c2 = {c2.trigo()}");
        }
    }

    class Complex
    {
        private double re, im;

        public Complex(double re = 0.0, double im = 0.0)
        {
            this.re = re;
            this.im = im;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();

            if (im > 0)
                s.AppendFormat("{0:0.##} + {1:0.##}i", re, im);
            else
            {
                if (im < 0)
                    s.AppendFormat("{0:0.##} - {1:0.##}i", re, Math.Abs(im));
                else
                    s.AppendFormat("{0:0.##}", re);
            }

            return s.ToString();
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.re + c2.re, c1.im + c2.im);
        }

        public static Complex operator -(Complex c1, Complex c2)
        {
            return new Complex(c1.re - c2.re, c1.im - c2.im);
        }

        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex(c1.re * c2.re - c1.im * c2.im, c1.re * c2.im + c1.im * c2.re);
        }

        public static Complex operator ^(Complex c1, int putere)
        {
            Complex c2 = new Complex(c1.re, c1.im);
            for (int i = 0; i < putere - 1; i++)
                c2 = c2 * c1;
            return c2;
        }

        public string trigo()
        {
            double r = Math.Sqrt(Math.Pow(re, 2) + Math.Pow(im, 2));
            double fi = Math.Atan(im / re);
            return String.Format("{0:0.##}", r) + " ( cos " + String.Format("{0:0.##}", fi) + " + i * sin " + String.Format("{0:0.##}", fi) + " )";
        }
    }
}
