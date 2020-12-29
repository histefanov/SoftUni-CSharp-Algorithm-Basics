using System;
using System.Linq;

namespace ConnectingCables
{
    class Program
    {
        static void Main(string[] args)
        {
            var permutatedCables = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var orderedCables = permutatedCables.OrderBy(x => x).ToArray();

            int maxConnections = GetMaximumConnections(permutatedCables, orderedCables);
            Console.WriteLine($"Maximum pairs connected: {maxConnections}");
        }

        private static int GetMaximumConnections(int[] permutatedCables, int[] orderedCables)
        {
            int[,] table = new int[orderedCables.Length + 1, permutatedCables.Length + 1];

            for (int r = 1; r < table.GetLength(0); r++)
            {
                for (int c = 1; c < table.GetLength(1); c++)
                {
                    if (orderedCables[r - 1] == permutatedCables[c - 1])
                    {
                        table[r, c] = table[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        table[r, c] = Math.Max(table[r - 1, c], table[r, c - 1]);
                    }
                }
            }

            return table[table.GetLength(0) - 1, table.GetLength(1) - 1];
        }
    }
}
