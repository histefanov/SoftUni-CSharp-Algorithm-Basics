using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedAreasInMatrix
{
    class Program
    {
        static bool[,] connected;
        static int connectionsCounter;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            List<Area> areas = new List<Area>();
            connected = new bool[rows, cols];
            connectionsCounter = 0;

            char[,] matrix = GenerateMatrix(rows, cols);

            var startingCell = FindUnvisitedStartingCell(matrix);
            while (startingCell.Item1 != -1)
            {
                FindArea(matrix, startingCell.Item1, startingCell.Item2);

                areas.Add(new Area(
                    connectionsCounter,
                    startingCell.Item1,
                    startingCell.Item2));

                connectionsCounter = 0;

                startingCell = FindUnvisitedStartingCell(matrix);
            }

            PrintAreasData(areas);
        }

        static void FindArea(char[,] matrix, int row, int col)
        {
            if (!IsWithinBounds(matrix, row, col) ||
                matrix[row, col] == '*' ||
                connected[row, col])
            {
                return;
            }

            connectionsCounter++;
            connected[row, col] = true;
            FindArea(matrix, row + 1, col);
            FindArea(matrix, row, col + 1);
            FindArea(matrix, row - 1, col);
            FindArea(matrix, row, col - 1);
        }

        private static Tuple<int, int> FindUnvisitedStartingCell(char[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (matrix[r, c] == '-' && !connected[r, c])
                    {
                        return new Tuple<int, int>(r, c);
                    }
                }
            }

            return new Tuple<int, int>(-1, -1);
        }

        private static bool IsWithinBounds(char[,] matrix, int row, int col)
        {
            return row >= 0 &&
                   row < matrix.GetLength(0) &&
                   col >= 0 &&
                   col < matrix.GetLength(1);
        }

        private static char[,] GenerateMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                string line = Console.ReadLine();

                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = line[c];
                }
            }
            return matrix;
        }

        private static void PrintAreasData(List<Area> areas)
        {
            areas = areas
                .OrderByDescending(a => a.Size)
                .ToList();

            Console.WriteLine($"Total areas found: {areas.Count}");

            for (int i = 0; i < areas.Count; i++)
            {
                Console.WriteLine($"Area #{i + 1} at {areas[i]}");
            }
        }
    }

    class Area
    {
        public Area(int connectedArea, int rowPosition, int colPosition)
        {
            Size = connectedArea;
            RowPosition = rowPosition;
            ColPosition = colPosition;
        }

        public int Size { get; set; }

        public int RowPosition { get; set; }

        public int ColPosition { get; set; }

        public override string ToString()
        {
            return $"({RowPosition}, {ColPosition}), size: {Size}";
        }
    }
}
