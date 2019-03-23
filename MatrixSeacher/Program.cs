using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSeacher
{
    class Program
    {
        static double[,] m1 = new double[,]
        {
            { 1, 2, 3 },
            { 1, 4, 3 },
            { 1, 5, 9 },
            { 3, 4, 3 },
        };

        static double[,] m2 = new double[,]
        {
            { 9, 2, 3, 6},
            { 9, 4, 3, 1 },
            { 1, 5, 9, 1 },
        };

        static void Main(string[] args)
        {
            double[,] res = multiple(m1, m2);

            printMatrix(res);

            Console.Write("enter target: ");
            double target = double.Parse(Console.ReadLine());
            double eps = 0.01;

            Console.Write("enter epsilant (or not): ");
            double.TryParse(Console.ReadLine(), out eps);

            int count = countNumber(res, target, eps);
            Console.Write("count:");
            Console.WriteLine(count);

            Console.ReadKey();
        }

        static int countNumber(double[,] m, double target, double eps)
        {
            int count = 0;
            for (int y = 0; y < m.GetLength(0); y++)
                for (int x = 0; x < m.GetLength(1); x++)
                    if (Math.Abs(target - m[y, x]) <= eps)
                        count++;

            return count;
        }

        static double[,] multiple(double[,] m1, double[,] m2)
        {
            if (m1.GetLength(1) != m2.GetLength(0))
                throw new Exception("not compatible");

            double[,] r = new double[m1.GetLength(0), m2.GetLength(1)];
            for (int i = 0; i < m1.GetLength(0); i++)            
                for (int j = 0; j < m2.GetLength(1); j++)                
                    for (int k = 0; k < m2.GetLength(0); k++)                    
                        r[i, j] += m1[i, k] * m2[k, j];

            return r;
        }

        static void printMatrix(double[,] m)
        {
            for (int y = 0; y < m.GetLength(0); y++) {
                string line = "";
                for (int x = 0; x < m.GetLength(1); x++)
                    line += m[y, x].ToString() + ' ';

                Console.WriteLine(line);
            }
        }
    }
}

