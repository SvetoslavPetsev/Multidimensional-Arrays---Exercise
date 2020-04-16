using System;
using System.Collections.Generic;

namespace _7._Knight_Game
{
    class Program
    {
        private static void Fillmatrix(int rows, int cols, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                var rowInput = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }
        }
        static bool IsValidTarget(char[,] arr, int[] target)
        {
            int x = target[0];
            int y = target[1];
            return !(x < 0 || x > arr.GetLength(0) - 1 || y < 0 || y > arr.GetLength(1) - 1);
        }
        static char GetChar(char[,] matrix, int[] target)
        {
            int x = target[0];
            int y = target[1];
            return matrix[x, y];
        }
        static void Main()
        {
            var matrixParam = int.Parse(Console.ReadLine());
            var matrix = new char[matrixParam, matrixParam];
            Fillmatrix(matrixParam, matrixParam, matrix);

            int removedKing = 0;
            int mostDengerousRow = 0;
            int mostDangerousCol = 0;

            while (true)
            {
                int maxReservedArea = 0;
                for (int row = 0; row < matrixParam; row++)
                {
                    for (int col = 0; col < matrixParam; col++)
                    {
                        char currArea = matrix[row, col];
                        if (currArea == 'K')
                        {
                            List<int[]> targetArea = new List<int[]>
                            {   new int[] { row - 2, col - 1 }, new int[] { row - 2, col + 1 },
                                new int[] { row - 1, col - 2 }, new int[] { row - 1, col + 2 },
                                new int[] { row + 1, col - 2 }, new int[] { row + 1, col + 2 },
                                new int[] { row + 2, col - 1 }, new int[] { row + 2, col + 1 },
                            };

                            int reservedArea = 0;
                            foreach (var target in targetArea)
                            {
                                if (IsValidTarget(matrix, target))
                                {
                                    if (GetChar(matrix, target) == 'K')
                                    {
                                        reservedArea++;
                                    }
                                }
                            }
                            if (reservedArea > maxReservedArea)
                            {
                                maxReservedArea = reservedArea;
                                mostDengerousRow = row;
                                mostDangerousCol = col;
                            }
                        }
                    }
                }
                if (maxReservedArea != 0)
                {
                    matrix[mostDengerousRow, mostDangerousCol] = '0';
                    removedKing++;
                }
                else
                {
                    Console.WriteLine(removedKing);
                    return;
                }
            }
        }
    }
}