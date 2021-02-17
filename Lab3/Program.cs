using System;
using System.Collections.Generic;

namespace Lab3
{
    internal class Program
    {
        private static int length = 3;

        private static double[,] A =
        {
            //b, b, a2, a3
            {10, 1, 1},
            {2, 10, 1},
            {2, 2, 10}
        };
        /*{
            {0.979, 0.427, 0.406, 0.348, 0.341},
            {0.273, 3.951, 0.217, 0.327, 0.844},
            {0.318, 0.197, 2.875, 0.166, 0.131},
            {0.219, 0.231, 0.187, 3.276, 0.381}
        };*/

        private static double[] B =
        {
            12,
            13,
            14
        };
        /*private static double[] B =
        {
            0.341,
            0.844,
            0.131,
            0.381
        };*/

        private static void Main()
        {
            IterationMethod();
        }

        private static void IterationMethod()
        {
            double[,] a = new double[length, length];

            for (int i = 0; i < length; i++)
            {
                a[i, 0] = B[i] / A[i, i];

                int pos = 1;

                for (int j = 0; j < length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    a[i, pos] = A[i, j] / A[i, i];
                    pos++;
                }
            }

            a.Display(length);
            Console.WriteLine();

            for (int i = 0; i < length; i++)
            {
                var c = a[i, i];
                a[i, i] = a[i, 0];
                a[i, 0] = c;
            }

            a.Display(length);

            var x = GetMainDiagonal(a);
            var e = 0.01;

            bool continueIteration = true;
            while (continueIteration)
            {
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < length; j++)
                    {
                        if (i == j)
                        {
                            continue;
                        }

                        a[i, i] -= a[i, j] * x[j];
                    }
                }

                var newX = GetMainDiagonal(a);

                for (int i = 0; i < length; i++)
                {
                    if (Math.Abs(x[i] - newX[i]) < e || newX[i] < 0)
                    {
                        continueIteration = false;
                    }
                }

                if (continueIteration)
                {
                    x = newX;

                    Console.WriteLine("------------------------------");
                    a.Display(length);
                    //Console.WriteLine();
                    //x.Display();
                    //newX.Display();
                }
            }

            Console.WriteLine("Ответ:");
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"x[{i}] = {x[i]}");
            }
        }

        private static double[] GetMainDiagonal(double[,] mtx)
        {
            var x = new double[length];
            for (int i = 0; i < length; i++)
            {
                x[i] = mtx[i, i];
            }

            return x;
        }
    }
}