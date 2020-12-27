using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoveDownRightSum
{
    class Cell
    {
        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            int[,] matrix = ReadMatrix(rows, cols);

            int[,] sums = GetSums(matrix);

            Stack<Cell> path = ExtractBestPath(sums);

            var result = new StringBuilder();

            foreach (var cell in path)
            {
                result.Append($"[{cell.Row}, {cell.Col}] ");
            }

            Console.WriteLine(result.ToString().TrimEnd());
        }

        private static Stack<Cell> ExtractBestPath(int[,] sums)
        {
            var path = new Stack<Cell>();

            int row = sums.GetLength(0) - 1;
            int col = sums.GetLength(1) - 1;
            int currentCell = sums[row, col];

            path.Push(new Cell(row, col));

            while (row != 0 || col != 0)
            {
                if (row == 0)
                {
                    col--;
                }
                else if (col == 0)
                {
                    row--;
                }
                else if (sums[row - 1, col] > sums[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }

                path.Push(new Cell(row, col));
            }

            return path;
        }

        private static int[,] GetSums(int[,] matrix)
        {
            int[,] sums = new int[matrix.GetLength(0), matrix.GetLength(1)];
            sums[0, 0] = matrix[0, 0];

            for (int col = 1; col < sums.GetLength(1); col++)
            {
                sums[0, col] = sums[0, col - 1] + matrix[0, col];
            }

            for (int row = 1; row < sums.GetLength(0); row++)
            {
                sums[row, 0] = sums[row - 1, 0] + matrix[row, 0];
            }

            for (int row = 1; row < sums.GetLength(0); row++)
            {
                for (int col = 1; col < sums.GetLength(1); col++)
                {
                    sums[row, col] = matrix[row, col] + Math.Max(sums[row - 1, col], sums[row, col - 1]);
                }
            }

            return sums;
        }

        private static int[,] ReadMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = currentRow[c];
                }
            }

            return matrix;
        }
    }
}
