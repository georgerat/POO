using System;
using System.Text;
using System.Threading;

namespace P7
{
    //Sa se creeze un tip de date pentru lucrul cu matrici. Sa se implementeze operatiile de adunare, scadere si inmultire a
    //doua matrici, ridicare la putere si determinarea inversei. Se va tine cont de dimensiunile matricilor pentru fiecare
    //operatie. Operatiile se vor implementa ca metode cu un singur parametru, operanzii fiind membrul data din clasa si
    //parametrul respectiv.

    class Program
    {
        static void Main(string[] args)
        {
            int n1 = 2, m1 = 2, n2 = 2, m2 = 2;
            Matrice a = new Matrice(n1, m1);
            Matrice b = new Matrice(n2, m2);
            Console.WriteLine($"Matricea A\n{a}");
            Console.WriteLine($"Matricea B\n{b}");
            Console.WriteLine($"Matricea A + B\n{a.adunare(b)}");
            Console.WriteLine($"Matricea A - B\n{a.scadere(b)}");
            Console.WriteLine($"Matricea A * B\n{a.inmultire(b)}");
            int k = 3;
            Console.WriteLine($"Matricea A ^ {k}\n{a.putere(k)}");
            Console.WriteLine($"Matricea inversa A ^ (-1)\n{a.inversa()}");
        }
    }

    class Matrice
    {
        private int n, m;
        private double[,] mat;

        public Matrice(int n = 0, int m = 0)
        {
            this.n = n;
            this.m = m;
            mat = new double[this.n, this.m];
            Random r = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    mat[i, j] = r.Next(100) * r.NextDouble();
                    Thread.Sleep(1);
                }
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    s.AppendFormat("{0,10:0.##}", mat[i, j]);
                s.AppendFormat("\n");
            }
            return s.ToString();
        }

        public Matrice adunare(Matrice a)
        {
            if (a.n == n && a.m == m)
            {
                Matrice rez = new Matrice(n, m);
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        rez.mat[i, j] = mat[i, j] + a.mat[i, j];
                return rez;
            }
            Console.WriteLine("Matricele nu se pot aduna deoarece nu au aceleasi dimensiuni.");
            return null;
        }

        public Matrice scadere(Matrice a)
        {
            if (a.n == n && a.m == m)
            {
                Matrice rez = new Matrice(n, m);
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        rez.mat[i, j] = mat[i, j] - a.mat[i, j];
                return rez;
            }
            Console.WriteLine("Matricele nu se pot scadea deoarece nu au aceleasi dimensiuni.");
            return null;
        }

        public Matrice inmultire(Matrice a)
        {
            if (m == a.n)
            {
                Matrice rez = new Matrice(n, a.m);
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                    {
                        rez.mat[i, j] = 0.0;
                        for (int k = 0; k < a.m; k++)
                            rez.mat[i, j] += mat[i, k] * a.mat[k, j];
                    }
                return rez;
            }
            Console.WriteLine("Matricele nu se pot inmulti.");
            return null;
        }

        public Matrice putere(int k)
        {
            if (n == m)
            {
                Matrice m1 = new Matrice(n, m);
                m1.mat = mat;
                Matrice rez = new Matrice(n, m);
                rez.mat = mat;
                for (int i = 0; i < k - 1; i++)
                    rez = rez.inmultire(m1);
                return rez;
            }
            Console.WriteLine($"Matricea nu se poate ridica la puterea {k} deoarece nu este patratica.");
            return null;
        }

        private double det(double[,] a, int n)
        {
            int i, j;
            double d, e, aux;

            if (n == 1)
                return a[0, 0];
            else
            {
                d = 0.0;
                for (j = 0; j < n; j++)
                {
                    if (((n - 1 - j) % 2 == 1) || (j == n - 1))
                        e = a[n - 1, j];
                    else
                        e = -a[n - 1, j];
                    for (i = 0; i < n - 1; i++)
                    {
                        aux = a[i, j];
                        a[i, j] = a[i, n - 1];
                        a[i, n - 1] = aux;
                    }
                    if ((n - 1 + j) % 2 == 0)
                        d += e * det(a, n - 1);
                    else
                        d -= e * det(a, n - 1);
                    for (i = 0; i < n - 1; i++)
                    {
                        aux = a[i, j];
                        a[i, j] = a[i, n - 1];
                        a[i, n - 1] = aux;
                    }
                }
                return d;
            }
        }

        public Matrice inversa()
        {
            if (n == m)
            {
                double d = det(mat, n);
                if (d != 0)
                {
                    Matrice rez = new Matrice(n, n);
                    Matrice temp = new Matrice(n, n);
                    // matricea transpusa
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                            temp.mat[i, j] = mat[j, i];
                    double aux;
                    int semn;
                    // matricea adjuncta
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                        {
                            for (int k = 0; k < n; k++)
                            {
                                aux = temp.mat[i, k];
                                temp.mat[i, k] = temp.mat[n - 1, k];
                                temp.mat[n - 1, k] = aux;
                            }
                            for (int k = 0; k < n; k++)
                            {
                                aux = temp.mat[k, j];
                                temp.mat[k, j] = temp.mat[k, n - 1];
                                temp.mat[k, n - 1] = aux;
                            }
                            semn = 1;
                            if (((n - 1 - i) % 2 == 0) && (i != n - 1))
                                semn *= -1;
                            if (((n - 1 - j) % 2 == 0) && (j != n - 1))
                                semn *= -1;
                            if ((i + j) % 2 == 1)
                                semn *= -1;
                            rez.mat[i, j] = semn * det(temp.mat, n - 1);
                            // refacere matrice
                            for (int k = 0; k < n; k++)
                            {
                                aux = temp.mat[i, k];
                                temp.mat[i, k] = temp.mat[n - 1, k];
                                temp.mat[n - 1, k] = aux;
                            }
                            for (int k = 0; k < n; k++)
                            {
                                aux = temp.mat[k, j];
                                temp.mat[k, j] = temp.mat[k, n - 1];
                                temp.mat[k, n - 1] = aux;
                            }
                        }
                    // matricea inversa
                    for (int i = 0; i < n; i++)
                        for (int j = 0; j < n; j++)
                            rez.mat[i, j] /= d;
                    return rez;
                }
                Console.WriteLine("Matricea nu este inversabila deoarece are determinantul nul.");
                return null;
            }
            Console.WriteLine("Matricea nu este inversabila deoarece nu este patratica.");
            return null;
        }
    }
}
