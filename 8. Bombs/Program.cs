using System;
using System.Linq;
using System.Collections.Generic;

namespace _8._Bombs
{
    class Program
    {
        private static void Fillmatrix(int param, int[,] matrix)
        {
            var rows = param;
            var cols = param;
            for (int row = 0; row < rows; row++)
            {
                var rowInput = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }
        }
        static bool IsValidTarget(int[,] arr, int[] target)
        {
            int row = target[0];
            int col = target[1];
            return !(row < 0 || row > arr.GetLength(0) - 1 || col < 0 || col > arr.GetLength(1) - 1);
        }
        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        static void Main()
        {
            var matrixParam = int.Parse(Console.ReadLine());
            var matrix = new int[matrixParam, matrixParam];
            Fillmatrix(matrixParam, matrix);

            var input = Console.ReadLine().Split();
            List<int[]> bombs = new List<int[]>();
            for (int i = 0; i < input.Length; i++)
            {
                var positon = input[i].Split(",").Select(int.Parse).ToArray();
                bombs.Add(positon);
            }
            foreach (var bomb in bombs)
            {
                var bRow = bomb[0];
                var bCol = bomb[1];
                var bombPower = matrix[bRow, bCol];
                if (matrix[bRow, bCol] > 0)
                {
                    matrix[bRow, bCol] = 0;
                    List<int[]> affectedArea = new List<int[]>
                    {
                    new int[]{ bRow -1, bCol - 1 },
                    new int[]{ bRow -1, bCol},
                    new int[]{ bRow -1, bCol + 1 },
                    new int[]{ bRow, bCol - 1 },
                    new int[]{ bRow, bCol + 1 },
                    new int[]{ bRow +1, bCol - 1 },
                    new int[]{ bRow +1, bCol},
                    new int[]{ bRow +1, bCol + 1 },
                    };

                    for (int i = 0; i < affectedArea.Count; i++)
                    {
                        var affectedCell = affectedArea[i];
                        if (IsValidTarget(matrix, affectedCell))
                        {

                            var affRow = affectedCell[0];
                            var affCol = affectedCell[1];
                            if (matrix[affRow, affCol] > 0)
                            {
                                matrix[affRow, affCol] -= bombPower;
                            }
                        }
                    }
                }
            }
            var aliveCell = 0;
            var sumAlliveCells = 0;
            foreach (var cell in matrix)
            {
                if (cell > 0)
                {
                    aliveCell++;
                    sumAlliveCells += cell;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCell}");
            Console.WriteLine($"Sum: {sumAlliveCells}");
            PrintMatrix(matrix);
        }
    }
}
