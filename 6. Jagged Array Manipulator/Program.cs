using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main()
        {
            var rows = int.Parse(Console.ReadLine());
            var arr = new decimal[rows][];
            for (int i = 0; i < rows; i++)
            {
                var fillRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                arr[i] = new decimal[fillRow.Length];
                for (int j = 0; j < fillRow.Count(); j++)
                {
                    arr[i][j] = fillRow[j];
                }
            }
            for (int i = 0; i < arr.GetLength(0) - 1; i++)
            {
                if (arr[i].Length == arr[i + 1].Length)
                {
                    for (int j = 0; j < arr[i].Length; j++)
                    {
                        arr[i][j] *= 2;
                    }
                    for (int j = 0; j < arr[i].Length; j++)
                    {
                        arr[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < arr[i].Length; j++)
                    {
                        arr[i][j] /= 2;
                    }
                    for (int j = 0; j < arr[i + 1].Length; j++)
                    {
                        arr[i + 1][j] /= 2;
                    }
                }
            }

            string input;
            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                var cmdArgs = input.Split();
                var cmd = cmdArgs[0];
                var row = int.Parse(cmdArgs[1]);
                var col = int.Parse(cmdArgs[2]);
                var number = decimal.Parse(cmdArgs[3]);
                if (row < 0 || row > rows - 1 || col < 0 || col > arr[row].Length - 1)
                {
                    continue;
                }
                if (cmd == "add")
                {
                    arr[row][col] += number;
                }
                else if (cmd == "subtract")
                {
                    arr[row][col] -= number;
                }
            }

            foreach (var row in arr)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
