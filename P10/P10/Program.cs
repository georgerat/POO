using System.Collections.Generic;
using System.IO;

namespace P10
{
    //Se considera un fisier text de intrare avand liniile de forma "Nume Prenume n nota1 ... nota n", unde n reprezinta
    //numarul notelor. Datele din fisier se adauga intr-o colectie generica prin intermediul unei clase denumite Elev, avand ca
    //membrii data numele, prenumele si media aritmetica a notelor. Sa se afiseze intru-un fisier de iesire lista inregistrarilor
    //sortate descrescator in functie de medie, iar pentru medii egale in ordiene alfabetica in functie de nume si prenume.

    class Program
    {
        static void Main(string[] args)
        {
            TextReader load = new StreamReader(@"../../TextFile1.txt");
            TextWriter wr = new StreamWriter(@"../../TextFile2.txt");
            List<Elev> e = new List<Elev>();

            int k = 6;
            while (k > 0)
            {
                string[] buffer = load.ReadLine().Split(' ');
                double suma = 0;
                for (int i = 3; i < buffer.Length; i++)
                    suma += double.Parse(buffer[i]);
                double media = suma / (double.Parse(buffer[2]));
                e.Add(new Elev(buffer[0], buffer[1], media));
                for (int i = 0; i < buffer.Length; i++)
                    buffer[i] = "";
                k--;
            }

            wr.WriteLine("\nInainte de sortare: \n");
            foreach (object o in e)
                wr.WriteLine(o);

            for (int i = 0; i < 5; i++)
                for (int j = i + 1; j < 6; j++)
                {
                    if (e[i].Media < e[j].Media)
                    {
                        Elev aux = e[i];
                        e[i] = e[j];
                        e[j] = aux;
                    }
                    else if (e[i].Media == e[j].Media)
                    {
                        List<Elev> medii_egale = new List<Elev>();
                        medii_egale.Add(new Elev(e[i].Nume, e[i].Prenume, e[i].Media));
                        medii_egale.Add(new Elev(e[j].Nume, e[j].Prenume, e[j].Media));

                        if (e[i].Nume != e[j].Nume)
                            medii_egale.Sort(new SortByNume());
                        else
                            medii_egale.Sort(new SortByPrenume());

                        e[i] = medii_egale[0];
                        e[j] = medii_egale[1];
                        medii_egale.Clear();
                    }
                }

            wr.WriteLine("\nDupa sortare: \n");
            foreach (object o in e)
                wr.WriteLine(o);

            wr.Close();
        }
        /*
        public static void print(List<Elev> e)
        {
            TextWriter wr = new StreamWriter(@"../../TextFile2.txt");
            foreach (object o in e)
                wr.WriteLine(o);
        }
        */
    }

    class Elev
    {
        public string Nume { get; }
        public string Prenume { get; }
        public double Media { get; }

        public Elev(string n, string p, double m)
        {
            Nume = n;
            Prenume = p;
            Media = m;
        }

        public override string ToString()
        {
            return Nume + " " + Prenume + " " + Media.ToString();
        }
    }

    class SortByNume : IComparer<Elev>
    {
        public int Compare(Elev e1, Elev e2)
        {
            return string.Compare(e1.Nume, e2.Nume);
        }
    }

    class SortByPrenume : IComparer<Elev>
    {
        public int Compare(Elev e1, Elev e2)
        {
            return string.Compare(e1.Prenume, e2.Prenume);
        }
    }
}
