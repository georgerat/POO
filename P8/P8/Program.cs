using System;
using System.Text;

namespace P5
{
    //Sa se implementeze clasa ComplexD derivata din clasa Complex. Noua clasa va suprascrie metoda de ridicare la putere,
    //utilizand forma trigonometrica a unui numar complex si va contine in plus o metoda care sa returneze distanta de la un
    //numar complex la o multime de numere complexe.

    class Program
    {
        static void Main(string[] args)
        {
            /*
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
            */
            ComplexD cd1 = new ComplexD(1.3, 2.7);
            Console.WriteLine($"x1 = {cd1}");
            ComplexD cd2 = new ComplexD(1.7, 3.57);
            Console.WriteLine($"x2 = {cd2}");
            Console.WriteLine($"x1 + x2 = {cd1 + cd2}");
            ComplexD c = new ComplexD(1.7, 2.3);
            Console.WriteLine($"x = {c}");
            Console.WriteLine($"Forma trigonometrica: x = {c.trigo()}");
            int k = 3;
            Console.WriteLine($"x ^ {k} = {c.ridicare_la_putere(k)}");
            ComplexD cd3 = new ComplexD(1.3, 2.7);
            Console.WriteLine($"x = {cd3}");
            cd3.dist();
        }
    }

    class Complex
    {
        protected double re, im;

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

        public virtual string ridicare_la_putere(int k)
        {
            Complex c = new Complex(re, im);
            for (int i = 0; i < k - 1; i++)
                c = c * this;
            return c.ToString();
        }

        public string trigo()
        {
            double r = Math.Sqrt(Math.Pow(re, 2) + Math.Pow(im, 2));
            double fi = Math.Atan(im / re);
            return String.Format("{0:0.##}", r) + " ( cos " + String.Format("{0:0.##}", fi) + " + i * sin " + String.Format("{0:0.##}", fi) + " )";
        }
    }

    class ComplexD : Complex
    {
        public ComplexD(double re = 0.0, double im = 0.0)
        {
            this.re = re;
            this.im = im;
        }

        public override string ridicare_la_putere(int k)
        {
            double r = Math.Sqrt(Math.Pow(re, 2) + Math.Pow(im, 2));
            double fi = Math.Atan(im / re);

            return string.Format("{0:0.##}", Math.Pow(r, k)) + " " + "( cos " + string.Format("{0:0.##}", k * fi) + " + i * sin " + string.Format("{0:0.##}", k * fi) + " )";
        }

        public void dist()
        {
            Console.Write("n = ");
            int j = 1, n = Convert.ToInt32(Console.ReadLine());

            double x, y, d = double.MaxValue, dd;
            for (int i = 0; i < n; i++)
            {
                Console.Write($"x{i + 1} = ");
                x = Convert.ToDouble(Console.ReadLine());
                Console.Write($"y{i + 1} = ");
                y = Convert.ToDouble(Console.ReadLine());
                dd = Math.Sqrt(Math.Pow(re - x, 2) + Math.Pow(im - y, 2));
                if (dd < d)
                {
                    j = i + 1;
                    d = dd;
                }
            }
            Console.WriteLine($"Distanta minima este fata de punctul (x{j}, y{j}) si are valoarea {d:0.##}");
        }
    }
}
