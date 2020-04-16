using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static int[] ReadArrFromConsole() => Console.ReadLine().Split(SplitSymbol(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        static char[] SplitSymbol() => new char[] { ',', ' ' };
        private static void Fillmatrix(int rows, int cols, int[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                var rowInput = ReadArrFromConsole();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }
        }
        static void Main()
        {
            var matrixParam = int.Parse(Console.ReadLine());
            var matrix = new int[matrixParam, matrixParam];
            Fillmatrix(matrixParam, matrixParam, matrix);
            var primary = 0;
            var secondary = 0;

            for (int row = 0; row < matrixParam; row++)
            {
                for (int col = 0; col < matrixParam; col++)
                {
                    if (col == row)
                    {
                        primary += matrix[row, col];
                    }
                    if (col == matrixParam - 1 - row)
                    {
                        secondary += matrix[row, col];
                    }
                }
            }
            int diff = Math.Abs(primary - secondary);
            Console.WriteLine(diff);
        }
    }
}
