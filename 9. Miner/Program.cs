using System;
using System.Linq;
using System.Collections.Generic;

namespace _9._Miner
{
    class Program
    {
        static bool IsValidCell(int row, int col, char[,]matrix)
        {
            return !(row < 0 || row > matrix.GetLength(0) - 1 || col < 0 || col > matrix.GetLength(1) - 1);
        }
        static void Main()
        {
            var matrixParam = int.Parse(Console.ReadLine());
            var commandsList = new List<string>(Console.ReadLine().Split());
            var matrix = new char[matrixParam, matrixParam];

            var coalNumber = 0;
            var minerRow = 0;
            var minerCol = 0;
            for (int row = 0; row < matrixParam; row++)
            {
                var rowInput = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrixParam; col++)
                {
                    matrix[row, col] = rowInput[col];
                    if (rowInput[col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                    else if (rowInput[col] == 'c')
                    {
                        coalNumber++;
                    }
                }
            }
            foreach (var command in commandsList)
            {
                var tempRow = -1;
                var tempCol = -1;
                if (command == "up")
                {
                    tempRow = minerRow - 1;
                    tempCol = minerCol;  
                }
                else if (command == "down")
                {
                    tempRow = minerRow + 1;
                    tempCol = minerCol;
                }
                else if (command == "left")
                {
                    tempRow = minerRow;
                    tempCol = minerCol - 1;
                }
                else if (command == "right")
                {
                    tempRow = minerRow;
                    tempCol = minerCol + 1;
                }
                if (IsValidCell(tempRow, tempCol, matrix))
                {
                    char cellElement = matrix[tempRow, tempCol];
                    if (cellElement == 'e')
                    {
                        Console.WriteLine($"Game over! ({tempRow}, {tempCol})");
                        return;
                    }
                    else if (cellElement == 'c' || cellElement == '*')
                    {
                        if (cellElement == 'c')
                        {
                            coalNumber--;
                        }
                        matrix[tempRow, tempCol] = 's';
                        matrix[minerRow, minerCol] = '*';
                        minerRow = tempRow;
                        minerCol = tempCol;
                    }
                    if (coalNumber == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{coalNumber} coals left. ({minerRow}, {minerCol})");
        }
    }
}
