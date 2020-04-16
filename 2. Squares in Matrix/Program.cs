using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        private static void Fillmatrix(int rows, int cols, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                var rowInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }
        }
        static void Main()
        {
            var matrixParam = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = matrixParam[0];
            var cols = matrixParam[1];
            var matrix = new char[rows, cols];
            Fillmatrix(rows, cols, matrix);
            var counter = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    var currSymbol = matrix[row, col];
                    if (currSymbol == matrix[row, col + 1]
                        && currSymbol == matrix[row + 1, col]
                        && currSymbol == matrix[row + 1, col + 1])
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
