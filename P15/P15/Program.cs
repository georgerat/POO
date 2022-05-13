using System;

namespace P15
{
    //Sa se implemnteze o clasa, numita Names, pentru reprezentarea unei liste de nume(tablou unidimensionala cu stringuri).
    //Constructorul initializeaza toate elementele din lista cu o valoare predefinita. Clasa va contine si un indexator de tip
    //intreg care va accesa valoarea din sir aflata pe o anumita pozitie si care va trata exceptiile posibile (index out of
    //range), precum si suprascrierea acestuia intr-un indexator de tip string (doar pentru get) care va returna pozitia pe
    //care se afla o anumita valoare din sir.

    class Program
    {
        static void Main()
        {
            Names n = new Names(5);
            for (int i = 2; i < n.size * 2; i++)
                n[i] = "A";
            for (int i = 0; i < n.size; i++)
                Console.WriteLine("{0}\t", n[i]);
            Console.WriteLine("\nFinding a on index {0}.\n", n["A"]);
        }
    }

    class Names
    {
        public int size;
        string[] name;

        public Names(int n)
        {
            size = n;
            name = new string[size];
            for (int i = 0; i < size; i++)
                name[i] = "N.A.";
        }

        public string this[int index]
        {
            get
            {
                return (index >= 0 && index < size) ? name[index] : "";
            }
            set
            {
                if (index >= 0 && index < size)
                    name[index] = value;
            }
        }

        public int this[string nm]
        {
            get
            {
                int index = 0;
                while (index < size)
                {
                    if (string.Compare(name[index], nm) == 0)
                        return index;
                    index++;
                }
                return -1;
            }
        }
    }
}
