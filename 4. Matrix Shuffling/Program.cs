using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static string[] ReadArrFromConsole() => Console.ReadLine().Split(SplitSymbol(), StringSplitOptions.RemoveEmptyEntries);
        static char[] SplitSymbol() => new char[] { ',', ' ' };
        static void Fillmatrix(int rows, int cols, string[,] matrix)
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
        static void PrintError() => Console.WriteLine("Invalid input!");

        static void PrintMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main()
        {
            int[] matrixParam = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = matrixParam[0];
            var cols = matrixParam[1];
            var matrix = new string[rows, cols];
            Fillmatrix(rows, cols, matrix);
            string input;
            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] cmdInfo = input.Split();
                string cmd = cmdInfo[0];
                if (cmd == "swap")
                {
                    if (cmdInfo.Length != 5)
                    {
                        PrintError();
                        continue;
                    }
                    int x1 = int.Parse(cmdInfo[1]);
                    int y1 = int.Parse(cmdInfo[2]);
                    int x2 = int.Parse(cmdInfo[3]);
                    int y2 = int.Parse(cmdInfo[4]);

                    if (x1 < 0 || x1 > rows - 1 || x2 < 0 || x2 > rows - 1
                     || y1 < 0 || y1 > cols - 1 || y2 < 0 || y2 > cols - 1)
                    {
                        PrintError();
                        continue;
                    }
                    string firstElement = matrix[x1, y1];
                    string secondElement = matrix[x2, y2];
                    matrix[x1, y1] = secondElement;
                    matrix[x2, y2] = firstElement;
                    PrintMatrix(matrix);
                }
                else
                {
                    PrintError();
                }
            }
        }
    }
}
