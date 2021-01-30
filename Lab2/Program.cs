using System;

namespace Lab2
{
    internal class Program
    {
        private static double F(double x)
            => 1.5 - 0.4 * Math.Sqrt(Math.Pow(x, 3)) - 0.5 * Math.Log(x);

        private static void Main()
        {
            double a = 2;
            double b = 2.5;

            var iterationsAmount = (int) Math.Ceiling(Math.Log2(Math.Abs(b - a) / Math.Pow(10000, -5)));

            Console.WriteLine(F(a) * F(b) > 0 ?
                $"На отрезке[{a}, {b}] нет корня." :
                $"Примерный ответ: {Dichotomy(a, b, iterationsAmount)}");
        }

        private static double Dichotomy(double a, double b, int iterationsAmount)
        {
            for (int i = 0; i < iterationsAmount; i++)
            {
                var c = (a + b) / 2;

                var value = F(a) * F(c);
                if (value > 0)
                {
                    a = c;
                }
                else
                {
                    b = c;
                }
            }

            return a > b ? b : a;
        }
    }
}