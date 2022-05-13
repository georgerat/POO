using System;

namespace P12
{
    //Sa se implementeze clasa tablou cu membrii data unidimensionali cu valori integi precum si dimensiunea acestuia. Sa se
    //scrie un constructor cu un parametru reprezentand lungimea tabloului si un indexator unidimensional in care sa se
    //trateze eventuale erori posibile.

    class Tablou
    {
        int[] a;
        public int dimensiune;
        public bool err;

        public Tablou(int lungime)
        {
            a = new int[lungime];
            dimensiune = lungime;
        }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < dimensiune)
                {
                    err = false;
                    return a[index];
                }
                else
                {
                    err = true;
                    return -1;
                }
            }
            set
            {
                if (index >= 0 && index < dimensiune)
                {
                    a[index] = value;
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
            Tablou t = new Tablou(5);
            for (int i = 0; i < t.dimensiune * 2; i++)
                t[i] = 10 * i;
            for (int i = 0; i < t.dimensiune * 2; i++)
            {
                int x = t[i];
                if (t.err)
                    Console.Write("\n t[{0}] depaseste marginile", i);
                else
                    Console.Write("{0}\t", x);
            }
            Console.WriteLine("\n");
        }
    }
}
