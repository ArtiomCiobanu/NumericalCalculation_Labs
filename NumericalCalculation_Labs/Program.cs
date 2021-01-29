using System;

namespace NumericalCalculation_Labs
{
    internal class Root
    {
        public double A { get; set; }
        public double B { get; set; }

        public Root(double a, double b)
        {
            A = a;
            B = b;
        }
    }

    //Отделение корней
    internal class Program
    {
        private static double F(double x)
            => 1.5 - 0.4 * Math.Sqrt(Math.Pow(x, 3)) + 0.5 * Math.Log(x);

        private static void Main()
        {
            var r = FindRoot(2, 0.5);
            Console.WriteLine($"Первый корень находится между {r.A} и {r.B}");

            var r2 = FindRoot(2, 0.5, false);
            Console.WriteLine($"Первый корень находится между {r2.A} и {r2.B}");
        }

        private static Root FindRoot(
            double startingPoint,
            double step,
            bool moveRight = true)
        {
            var root = new Root(startingPoint, startingPoint + step);

            Func<Root, Root> moveAction = moveRight ?
                r => new Root(r.A + step, r.B + step) :
                r => new Root(r.A - step, r.B - step);

            while (F(root.A) * F(root.B) > 0)
            {
                root = moveAction(root);
            }

            return root;
        }
    }
}