using System;
using System.Linq;
using System.Collections.Generic;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static int[] GetPlayerPosition(int currRow, int currCol, char command)
        {
            var tempRow = -1;
            var tempCol = -1;
            if (command == 'U')
            {
                tempRow = currRow - 1;
                tempCol = currCol;
            }
            else if (command == 'D')
            {
                tempRow = currRow + 1;
                tempCol = currCol;
            }
            else if (command == 'L')
            {
                tempRow = currRow;
                tempCol = currCol - 1;
            }
            else if (command == 'R')
            {
                tempRow = currRow;
                tempCol = currCol + 1;
            }
            return new int[2] { tempRow, tempCol };
        }
        static bool IsValidCell(int row, int col, char[,] matrix)
        {
            return !(row < 0 || row > matrix.GetLength(0) - 1 || col < 0 || col > matrix.GetLength(1) - 1);
        }
        static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }
        }
        static void Main()
        {
            var matrixParam = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = matrixParam[0];
            var cols = matrixParam[1];
            var matrix = new char[rows, cols];
            var playerRow = -1;
            var playerCol = -1;
            for (int row = 0; row < rows; row++)
            {
                var rowInput = Console.ReadLine().ToCharArray();
                var filteredInput = new List<char>();
                for (int i = 0; i < rowInput.Length; i++)
                {
                    if (rowInput[i] == '.' || rowInput[i] == 'B' || rowInput[i] == 'P')
                    {
                        filteredInput.Add(rowInput[i]);
                    }
                }
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = filteredInput[col];
                    if (filteredInput[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
            var commands = Console.ReadLine().ToCharArray();
            bool playerDead = false;
            bool playerWon = false;

            foreach (var command in commands)
            {
                var newPlayerPosition = GetPlayerPosition(playerRow, playerCol, command);
                var newPlayerRow = newPlayerPosition[0];
                var newPlayerCol = newPlayerPosition[1];

                if (IsValidCell(newPlayerRow, newPlayerCol, matrix))
                {
                    if (matrix[newPlayerRow, newPlayerCol] == 'B')
                    {
                        playerDead = true;
                        matrix[playerRow, playerCol] = '.';
                    }
                    else if (matrix[newPlayerRow, newPlayerCol] == '.')
                    {
                        matrix[newPlayerRow, newPlayerCol] = 'P';
                        matrix[playerRow, playerCol] = '.';
                    }
                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }
                else
                {
                    matrix[playerRow, playerCol] = '.';
                    playerWon = true;
                }

                char[,] temp = (char[,])matrix.Clone();
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        char element = temp[row, col];
                        if (element == 'B')
                        {
                            List<int[]> affectedArea = new List<int[]>
                                    {
                                    new int[]{ row - 1, col},
                                    new int[]{ row + 1, col},
                                    new int[]{ row, col - 1 },
                                    new int[]{ row, col + 1 },
                                    };
                            for (int i = 0; i < affectedArea.Count; i++)
                            {
                                var affectedCell = affectedArea[i];
                                if (IsValidCell(affectedCell[0], affectedCell[1], matrix))
                                {
                                    var affRow = affectedCell[0];
                                    var affCol = affectedCell[1];
                                    if (matrix[affRow, affCol] == 'P')
                                    {
                                        playerDead = true;
                                        matrix[playerRow, playerCol] = 'B';
                                    }
                                    else if (matrix[affRow, affCol] == '.')
                                    {
                                        matrix[affRow, affCol] = 'B';
                                    }
                                }
                            }
                        }
                    }
                }

                if (playerDead)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    return;
                }
                else if (playerWon)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    return;
                }
            }
        }
    }
}
