using System;

namespace P18
{
    //Delegare care apeleaza metode statice

    public delegate double MyDelegate(double a);

    class Circle
    {
        const float PI = 3.14159f;

        static double Aria(double r)
        {
            return PI * r * r;
        }

        static double LungFrontiera(double r)
        {
            return 2 * PI * r;
        }

        public static void Main()
        {
            double raza = 3;
            MyDelegate del = new MyDelegate(Aria);
            Console.WriteLine($"Aria : {del(raza):#.##}");
            del = new MyDelegate(LungFrontiera);
            Console.WriteLine($"Lungimea frontierei : {del(raza):#.##}");
        }
    }
}
