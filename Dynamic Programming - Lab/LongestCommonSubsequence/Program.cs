using System;
using System.Collections.Generic;

namespace LongestCommonSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var lcsMatrix = new int[str1.Length + 1, str2.Length + 1];

            FillMatrix(lcsMatrix, str1, str2);

            var result = lcsMatrix[str1.Length, str2.Length];
            Console.WriteLine(result);

            var commonSubsequence = ExtractCommonSubsequence(lcsMatrix, str1, str2);
            Console.WriteLine($"Longest common subsequence: [{commonSubsequence}] ({commonSubsequence.Length})");
        }

        private static string ExtractCommonSubsequence(int[,] lcsMatrix, string str1, string str2)
        {
            List<char> commonCharacters = new List<char>();

            int row = lcsMatrix.GetLength(0) - 1;
            int col = lcsMatrix.GetLength(1) - 1;

            while (row > 0 && col > 0)
            {
                if (str1[row - 1] == str2[col - 1])
                {
                    commonCharacters.Add(str1[row - 1]);
                    row--;
                    col--;
                }
                else
                {
                    if (lcsMatrix[row, col] == lcsMatrix[row - 1, col])
                    {
                        row--;
                    }
                    else
                    {
                        col--;
                    }
                }
            }

            commonCharacters.Reverse();
            return string.Join("", commonCharacters);
        }

        private static void FillMatrix(int[,] lcsMatrix, string str1, string str2)
        {
            for (int r = 1; r < lcsMatrix.GetLength(0); r++)
            {
                for (int c = 1; c < lcsMatrix.GetLength(1); c++)
                {
                    if (str1[r - 1] == str2[c - 1])
                    {
                        lcsMatrix[r, c] = lcsMatrix[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        lcsMatrix[r, c] = Math.Max(lcsMatrix[r - 1, c], lcsMatrix[r, c - 1]);
                    }
                }
            }
        }
    }
}
