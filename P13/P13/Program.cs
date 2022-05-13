using System;

namespace P12
{
    //Sa se implementeze clasa matrice cu membrii data bidimensionali cu valori integi precum si dimensiunile acestuia. Sa se
    //scrie un constructor cu doi parametrii reprezentand dimensiunile tabloului si un indexator bidimensional in care sa se
    //trateze eventuale erori posibile.

    class Tablou
    {
        int[,] a;
        public int n;
        public int m;
        public bool err;

        public Tablou(int linii, int coloane)
        {
            a = new int[linii, coloane];
            n = linii;
            m = coloane;
        }

        public int this[int index1, int index2]
        {
            get
            {
                if (index1 >= 0 && index1 < n && index2 >= 0 && index2 < m)
                {
                    err = false;
                    return a[index1, index2];
                }
                else
                {
                    err = true;
                    return -1;
                }
            }
            set
            {
                if (index1 >= 0 && index1 < n && index2 >= 0 && index2 < m)
                {
                    a[index1, index2] = value;
                    err = false;
                }
                else
                    err = true;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tablou t = new Tablou(5, 6);
            for (int i = 0; i < t.n * 2; i++)
                for (int j = 0; j < t.m * 2; j++)
                    t[i, j] = 10 * i;
            for (int i = 0; i < t.n * 2; i++)
            {
                for (int j = 0; j < t.m * 2; j++)
                {
                    int x = t[i, j];
                    if (!t.err)
                        Console.Write("{0}\t", x);
                }
                Console.WriteLine();
            }
            for (int i = 0; i < t.n * 2; i++)
                for (int j = 0; j < t.m * 2; j++)
                {
                    int x = t[i, j];
                    if (t.err)
                        Console.Write("\n t[{0} {1}] depaseste marginile", i, j);
                }
            Console.WriteLine("\n");
        }
    }
}
