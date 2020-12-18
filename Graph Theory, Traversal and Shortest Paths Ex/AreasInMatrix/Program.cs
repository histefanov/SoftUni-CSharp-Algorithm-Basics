using System;
using System.Collections.Generic;
using System.Linq;

namespace AreasInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            var matrix = ReadMatrix(row, col);
            var visited = new bool[row, col];

            Dictionary<char, int> areas = GetAreas(matrix, visited);

            Console.WriteLine($"Areas: {areas.Select(a => a.Value).Sum()}");
            foreach (var area in areas.OrderBy(a => a.Key))
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static Dictionary<char, int> GetAreas(char[,] matrix, bool[,] visited)
        {
            var areas = new Dictionary<char, int>();

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    if (!visited[r, c])
                    {
                        var symbol = matrix[r, c];
                        DFS(matrix, r, c, visited, symbol);


                        if (!areas.ContainsKey(symbol))
                        {
                            areas.Add(symbol, 0);
                        }
                        areas[symbol]++;
                    }
                }
            }

            return areas;
        }

        private static void DFS(char[,] matrix, int r, int c, bool[,] visited, char symbol)
        {
            if (!IsSafe(matrix, r, c) || 
                matrix[r, c] != symbol || 
                visited[r,c])
            {
                return;
            }

            visited[r, c] = true;
            
            DFS(matrix, r + 1, c, visited, symbol);
            DFS(matrix, r, c + 1, visited, symbol);
            DFS(matrix, r - 1, c, visited, symbol);
            DFS(matrix, r, c - 1, visited, symbol);
        }

        private static bool IsSafe(char[,] matrix, int r, int c)
        {
            return r >= 0 && r < matrix.GetLength(0) &&
                   c >= 0 && c < matrix.GetLength(1);
        }

        private static char[,] ReadMatrix(int row, int col)
        {
            char[,] matrix = new char[row, col];

            for (int i = 0; i < row; i++)
            {
                var line = Console.ReadLine().ToCharArray();

                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = line[j];
                }
            }
            return matrix;
        }
    }
}
