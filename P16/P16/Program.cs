using System;
using System.Linq;

namespace P16
{
    //Sa se implementeze clasa generica Stiva, care sa permita stocarea unui numar maxim precizat de elemente. Clasa va contine
    //trei metode: push, pop, clear. Metodele vor contine tratarea exceptiilor. Stiva se va folosi pentru doua tipuri de date
    //concrete.

    class Program
    {
        static void Main()
        {
            Stiva<char> st = new Stiva<char>(5);

            for (char ch = 'a'; ch <= 'f'; ch++)
                st.Push(ch);

            for (int i = 0; i < 7; i++)
            {
                char x = st.Pop();
                if (x != default)
                    Console.WriteLine($"Element scos din stiva {x}");
                else
                    Console.WriteLine("Stiva este goala!");
            }

            st.Clear();
        }
    }

    public class Stiva<T>
    {
        private T[] elem;
        private int nivel;

        public Stiva(int max)
        {
            elem = new T[max];
            nivel = -1;
        }

        public void Push(T data)
        {
            if (nivel < elem.Count() - 1)
            {
                elem[++nivel] = data;
                Console.WriteLine($"Element adaugat in stiva {data}");
            }
            else
                Console.WriteLine("Stiva este plina!");
        }

        public T Pop()
        {
            if (nivel >= 0)
                return elem[nivel--];
            return default;
        }

        public void Clear()
        {
            nivel = -1;
            elem = new T[0];
            Console.WriteLine("Eliberare memorie.");
        }
    }
}
