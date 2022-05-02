using System;
using System.Collections.Generic;

namespace P9
{
    //Sortarea datelor de tip definit de utilizator folosind colectiile generice si definirea criteriului de sortare. Sa se
    //creeze un tip de date, numit Persoana, care sa contina numele de tip string si varsta de tip intreg reprezentate ca
    //autoproprietati de tip read-only. Clasa va contine un constructor pentru initializare, avand 2 parametrii corespunzatori
    //celor 2 campuri. In metoda main se vor adauga mai multe obiecte de tipul Persoana intr-o colectie generica<list> List[t].
    //Se cere afisarea persoanelor din colectie sortate lexicografic dupa nume si respectiv in ordine crescatoare in functie de
    //varsta.

    class Program
    {
        public static void print(List<Persoana> a)
        {
            foreach (object o in a)
                Console.WriteLine(o);
        }

        static void Main(string[] args)
        {
            List<Persoana> pers = new List<Persoana>();
            pers.Add(new Persoana("Ion", 50));
            pers.Add(new Persoana("Ana", 30));
            pers.Add(new Persoana("Vasile", 20));
            pers.Add(new Persoana("Gheorghe", 20));
            pers.Add(new Persoana("Adrian", 25));
            pers.Add(new Persoana("Adriana", 30));
            pers.Add(new Persoana("Andrei", 14));
            pers.Add(new Persoana("Dumitru", 68));

            pers.Sort(new SortByName());
            Console.WriteLine("\nSortarea dupa nume: \n");
            print(pers);

            pers.Sort(new SortByAge());
            Console.WriteLine("\nSortarea dupa varsta: \n");
            print(pers);

            Console.WriteLine();
        }
    }

    class Persoana
    {
        public string Nume { get; }
        public int Varsta { get; }

        public Persoana(string n, int v)
        {
            Nume = n;
            Varsta = v;
        }

        public override string ToString()
        {
            return Nume + " " + Varsta.ToString() + " ani";
        }
    }

    class SortByName : IComparer<Persoana>
    {
        public int Compare(Persoana p1, Persoana p2)
        {
            return string.Compare(p1.Nume, p2.Nume);
        }
    }

    class SortByAge : IComparer<Persoana>
    {
        public int Compare(Persoana p1, Persoana p2)
        {
            if (p1.Varsta < p2.Varsta)
                return -1;
            if (p1.Varsta > p2.Varsta)
                return 1;
            return 0;
        }
    }
}
