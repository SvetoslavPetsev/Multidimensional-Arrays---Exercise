using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
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
            var matrixParam = ReadArrFromConsole();
            var rows = matrixParam[0];
            var cols = matrixParam[1];
            var matrix = new int[rows, cols];
            Fillmatrix(rows, cols, matrix);
            var x = 0;
            var y = 0;
            var maxSum = int.MinValue;
            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    var currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] 
                                + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                                + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        x = row;
                        y = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[x, y]} {matrix[x, y + 1]} {matrix[x, y + 2]}");
            Console.WriteLine($"{matrix[x + 1, y]} {matrix[x + 1, y + 1]} {matrix[x + 1, y + 2]}");
            Console.WriteLine($"{matrix[x + 2, y]} {matrix[x + 2, y + 1]} {matrix[x + 2, y + 2]}");
        }
    }
}
