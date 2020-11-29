using System;

namespace NestedLoopsToRecursion
{
    class Program
    {
        static int n;

        static void Main(string[] args)
        {            
            n = int.Parse(Console.ReadLine());
            int[] result = new int[n];

            PrintLoop(result, 0);
        }

        private static void PrintLoop(int[] result, int index)
        {
            if (index == result.Length)
            {
                Print(result);
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                result[index] = i;
                PrintLoop(result, index + 1);
            }
        }

        private static void Print(int[] result)
        {
            Console.WriteLine(String.Join(" ", result));
        }
    }
}
