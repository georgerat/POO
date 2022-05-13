using System;

namespace P14
{
    //Sa se implementeze o clasa care sa contina un indexator care returneraza puterile intregi pozitive ale lui 3.

    class Putere3
    {
        public int this[int index]
        {
            get
            {
                if (index >= 0)
                    return (int)Math.Pow(3, index);
                else
                    return -1;
            }
        }
    }

    //Sa se implementeze o clasa care sa contina un indexator care returneraza puterile reale pozitive ale lui 3.

    class Puterereala3
    {
        public double this[double index]
        {
            get
            {
                if (index >= 0)
                    return Math.Pow(3, index);
                else
                    return -1;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Putere3 p = new Putere3();
            for (int i = 0; i < 10; i++)
                Console.WriteLine("3 ^ {0} = {1}", i, p[i]);
            Console.WriteLine();

            Puterereala3 p1 = new Puterereala3();
            for (double i = 0; i < 1; i += 0.1)
                Console.WriteLine("3 ^ {0:0.00} = {1:0.00}", i, p1[i]);
        }
    }
}
