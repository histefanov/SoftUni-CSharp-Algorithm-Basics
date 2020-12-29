using System;

namespace WordDifferences
{
    class Program
    {
        static void Main(string[] args)
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var minSteps = GetMinSteps(str1, str2);

            Console.WriteLine($"Deletions and Insertions: {minSteps}");
        }

        private static int GetMinSteps(string str1, string str2)
        {
            int[,] matrix = new int[str1.Length + 1, str2.Length + 1];

            for (int r = 1; r < matrix.GetLength(0); r++)
            {
                matrix[r, 0] = r;
            }

            for (int c = 1; c < matrix.GetLength(1); c++)
            {
                matrix[0, c] = c;
            }

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (str1[i - 1] != str2[j - 1])
                    {
                        matrix[i, j] = Math.Min(matrix[i - 1, j], matrix[i, j - 1]) + 1;
                    }
                    else
                    {
                        matrix[i, j] = matrix[i - 1, j - 1];
                    }
                }
            }

            return matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
        }
    }
}
