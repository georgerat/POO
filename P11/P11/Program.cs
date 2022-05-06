using System;

namespace P11
{
    //Sa se implementeze o clasa abstracta denumita AbstractPoint care sa contina: un membru data public de tip enumerare,
    //denumit PointRepresentation cu valorile posibile polar si rectangular, 4 proprietati abstracte corespunzatoare
    //coordonatelor careteziene si polare, metoda publica Move(dx, dy) pentru translatarea punctului, metoda publica
    //Rotate(angel) pentru rotatia punctului, suprascrierea metodei ToString pentru afisarea sub forma(a, b) :[r, A]; 4 metode
    //protejate statice care sa returneze r si A in functie de a si b respectiv a si b in functie de r si A. Sa se implementeze
    //clasa Point derivata din AbstractPoint care sa contina membrii data r, A (corespunzatori reprezentarii polare a unui punct),
    //un constructor cu 3 parametri tipul reprezentarii si 2 valori numerice si implementarea celor 4 proprietati din clasa de
    //baza.

    class Program
    {
        public static Point PromptPoint(string prompt)
        {
            double x, y;
            AbstractPoint.PointRepresentation mode = AbstractPoint.PointRepresentation.Rectangular;
            Console.WriteLine(prompt);
            x = double.Parse(Console.ReadLine());
            y = double.Parse(Console.ReadLine());
            return new Point(mode, x, y);
        }

        static void Main(string[] args)
        {
            AbstractPoint p1, p2, p3;
            double p1p2Dist, p2p3Dist, p3p1Dist, perimeter;

            p1 = PromptPoint("Introduceti primul punct:");
            p2 = PromptPoint("Introduceti al doilea punct:");
            p3 = PromptPoint("Introduceti al treilea punct:");

            p1.Rotate(Math.PI);
            p2.Move(1.0, 2.0);

            p1p2Dist = Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
            p2p3Dist = Math.Sqrt((p2.X - p3.X) * (p2.X - p3.X) + (p2.Y - p3.Y) * (p2.Y - p3.Y));
            p3p1Dist = Math.Sqrt((p3.X - p1.X) * (p3.X - p1.X) + (p3.Y - p1.Y) * (p3.Y - p1.Y));

            perimeter = p1p2Dist + p2p3Dist + p3p1Dist;

            Console.WriteLine("Circumferinta:\n {0}\n {1}\n {2}", p1, p2, p3);
            Console.WriteLine("Perimeter: {0:0.00}", perimeter);
        }
    }

    public abstract class AbstractPoint
    {
        public enum PointRepresentation { Polar, Rectangular }

        public abstract double X
        {
            get;
            set;
        }
        public abstract double Y
        {
            get;
            set;
        }
        public abstract double R
        {
            get;
            set;
        }
        public abstract double A
        {
            get;
            set;
        }

        public void Move(double dx, double dy)
        {
            X += dx;
            Y += dy;
        }

        public void Rotate(double angel)
        {
            A += angel;
        }

        public override string ToString()
        {
            return "(" + string.Format("{0:0.00}", X) + "," + string.Format("{0:0.00}", Y) + ")" + " " +
                "[r:" + string.Format("{0:0.00}", R) + ", a:" + string.Format("{0:0.00}", A) + "]";
        }

        protected static double RadiusGivenXy(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }

        protected static double AngleGivenXy(double x, double y)
        {
            return Math.Atan2(y, x);
        }

        protected static double XGivenRadiusAngle(double r, double a)
        {
            return r * Math.Cos(a);
        }

        protected static double YGivenRadiusAngle(double r, double a)
        {
            return r * Math.Sin(a);
        }
    }

    public class Point : AbstractPoint
    {
        private double radius, angle;

        public Point(PointRepresentation pr, double n1, double n2)
        {
            if (pr == PointRepresentation.Polar)
            {
                radius = n1;
                angle = n2;
            }
            else if (pr == PointRepresentation.Rectangular)
            {
                radius = RadiusGivenXy(n1, n2);
                angle = AngleGivenXy(n1, n2);
            }
            else
            {
                throw new Exception("Nu trebuie sa se intample.");
            }
        }

        public override double X
        {
            get
            {
                return XGivenRadiusAngle(radius, angle);
            }
            set
            {
                double yBefore = YGivenRadiusAngle(radius, angle);
                angle = AngleGivenXy(value, yBefore);
                radius = RadiusGivenXy(value, yBefore);
            }
        }

        public override double Y
        {
            get
            {
                return YGivenRadiusAngle(radius, angle);
            }
            set
            {
                double xBefore = XGivenRadiusAngle(radius, angle);
                angle = AngleGivenXy(xBefore, value);
                radius = RadiusGivenXy(xBefore, value);
            }
        }

        public override double R
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }

        public override double A
        {
            get
            {
                return angle;
            }
            set
            {
                angle = value;
            }
        }
    }
}
