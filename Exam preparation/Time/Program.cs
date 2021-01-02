using System;
using System.Collections.Generic;
using System.Linq;

namespace Time
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] line1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] line2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] commonLine = GetLSC(line1, line2);

            Console.WriteLine(String.Join(" ", commonLine));
            Console.WriteLine(commonLine.Length);
        }

        private static int[] GetLSC(int[] line1, int[] line2)
        {
            int[,] lcsMatrix = new int[line1.Length + 1, line2.Length + 1];

            for (int row = 1; row < lcsMatrix.GetLength(0); row++)
            {
                for (int col = 1; col < lcsMatrix.GetLength(1); col++)
                {
                    if (line1[row - 1] == line2[col - 1])
                    {
                        lcsMatrix[row, col] = lcsMatrix[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        lcsMatrix[row, col] = Math.Max(lcsMatrix[row - 1, col], lcsMatrix[row, col - 1]);
                    }
                }
            }

            int[] result = ExtractCommonLine(lcsMatrix, line1, line2);

            return result;
        }

        private static int[] ExtractCommonLine(int[,] lcsMatrix, int[] line1, int[] line2)
        {
            Stack<int> line = new Stack<int>();
            int row = lcsMatrix.GetLength(0) - 1;
            int col = lcsMatrix.GetLength(1) - 1;

            while (row > 0 && col > 0)
            {
                if (line1[row - 1] == line2[col - 1])
                {
                    line.Push(line1[row - 1]);
                    row--;
                    col--;
                }
                else if (lcsMatrix[row - 1, col] > lcsMatrix[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }           

            return line.ToArray();
        }
    }
}
