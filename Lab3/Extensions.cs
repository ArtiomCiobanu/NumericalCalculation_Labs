﻿using System;

namespace Lab3
{
    public static class Extensions
    {
        public static void Display(this double[,] matrix, int len)
        {
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}