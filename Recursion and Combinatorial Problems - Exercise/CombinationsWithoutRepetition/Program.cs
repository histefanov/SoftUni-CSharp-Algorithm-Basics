using System;

namespace CombinationsWithoutRepetition
{
    class Program
    {
        static int numberOfElements;
        static int[] combination;

        static void Main(string[] args)
        {
            numberOfElements = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            combination = new int[k];

            Combine(0, 1);
        }

        private static void Combine(int index, int loopStartIndex)
        {
            if (index >= combination.Length)
            {
                Print(combination);
                return;
            }

            for (int i = loopStartIndex; i <= numberOfElements; i++)
            {
                combination[index] = i;
                Combine(index + 1, i + 1);
            }
        }

        private static void Print(int[] combination)
        {
            Console.WriteLine(String.Join(" ", combination));
        }
    }
}
