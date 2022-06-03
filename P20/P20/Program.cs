using System;

namespace P20
{
    //Delegare care inglobeaza mai multe metode.

    public delegate void MyDelegate(double r, ref double[] a, ref int i);

    class Cerc
    {
        const float PI = 3.14159f;

        static void Aria(double r, ref double[] a, ref int i)
        {
            a[++i] = PI * r * r;
        }

        static void LungimeaFrontierei(double r, ref double[] a, ref int i)
        {
            a[++i] = 2 * PI * r;
        }

        static void Cercul(double r, ref double[] a, ref int i)
        {
            Console.WriteLine($"Cercul de raza {r} are : ");
            a[++i] = 0;
        }

        public static void Main()
        {
            double raza = 3;
            double[] rez = new double[3];
            int i = -1;

            MyDelegate del = new MyDelegate(Cercul);
            del += new MyDelegate(Aria);
            del += new MyDelegate(LungimeaFrontierei);
            del(raza, ref rez, ref i);
            Console.WriteLine($"\t Aria : {rez[1]:#.##} \n\t Lungimea frontierei : {rez[2]:#.##}");

            del -= new MyDelegate(LungimeaFrontierei);
            rez = new double[3];
            i = -1;
            del(raza, ref rez, ref i);
            Console.WriteLine($"\t Aria : {rez[1]:#.##} \n\t Lungimea frontierei : {rez[2]:#.##}");
        }
    }
}
