using System;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        static int GetSnakeIndex(int index, string snake)
        {
            if (index >= snake.Length - 1)
            {
                index = -1;
            }
            index++;
            return index;
        }
        static void Main()
        {
            int[] matrixParam = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = matrixParam[0];
            var cols = matrixParam[1];
            var matrix = new char[rows, cols];
            string snake = Console.ReadLine();
            int snakeLength = snake.Length;
            int indexSnake = -1;
            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        indexSnake = GetSnakeIndex(indexSnake, snake);
                        char snakeElement = snake[indexSnake];
                        matrix[row, col] = snakeElement;
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        indexSnake = GetSnakeIndex(indexSnake, snake);
                        char snakeElement = snake[indexSnake];
                        matrix[row, col] = snakeElement;
                    }
                }
            }
            PrintMatrix(matrix);
        }
    }
}
