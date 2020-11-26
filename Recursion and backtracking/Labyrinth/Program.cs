using System;
using System.Collections.Generic;

namespace Labyrinth
{
    class Program
    {
        static List<char> path = new List<char>();

        static void Main(string[] args)
        {
            int height = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());

            var labyrinth = GenerateLabyrinth(height, width);

            FindPath(labyrinth, 0, 0, 'S', new bool[height, width]);
        }

        static void FindPath(char[,] labirynth, int row, int col, char direction, bool[,] visited)
        {
            if (!IsInBounds(row, col, labirynth.GetLength(0), labirynth.GetLength(1)))
            {
                return;
            }

            path.Add(direction);

            if (IsExit(labirynth, row, col))
            {
                PrintPath();
            }
            else if (!IsVisited(row, col, visited) && IsUnobstructed(row, col, labirynth))
            {
                visited[row, col] = true;
                FindPath(labirynth, row, col + 1, 'R', visited);
                FindPath(labirynth, row + 1, col, 'D', visited);
                FindPath(labirynth, row, col - 1, 'L', visited);
                FindPath(labirynth, row - 1, col, 'U', visited);
                visited[row, col] = false;
            }

            path.RemoveAt(path.Count - 1);
        }

        static bool IsUnobstructed(int row, int col, char[,] labirynth)
        {
            return labirynth[row, col] != '*';
        }

        static bool IsVisited(int row, int col, bool[,] visited)
        {
            return visited[row, col];
        }

        static bool IsInBounds(int row, int col, int height, int width)
        {
            if (row >= 0 && row < height &&
                col >= 0 && col < width)
            {
                return true;
            }
            return false;
        }
         
        static bool IsExit(char[,] labyrinth, int row, int col)
        {
            return labyrinth[row, col] == 'e';
        }

        static char[,] GenerateLabyrinth(int height, int width)
        {
            char[,] labyrinth = new char[height, width];

            for (int i = 0; i < height; i++)
            {
                var line = Console.ReadLine().ToCharArray();

                for (int j = 0; j < width; j++)
                {
                    labyrinth[i, j] = line[j];
                }
            }

            return labyrinth;
        }

        static void PrintPath()
        {
            var pathString = string.Join("", path);
            Console.WriteLine(pathString.Substring(1));
        }
    }
}
