using System;
using System.Linq;

namespace CombinationsWithRepetition
{
    class Program
    {
        static char[] collection;
        static char[] combination;
        static int k;

        static void Main(string[] args)
        {
            collection = Console.ReadLine()
                .Split()
                .Select(char.Parse)
                .ToArray();

            k = int.Parse(Console.ReadLine());
            combination = new char[k];

            Combine(0, 0);
        }

        private static void Combine(int index, int loopStartIndex)
        {
            if (index == combination.Length)
            {
                PrintCombination();
                return;
            }

            for (int i = loopStartIndex; i < collection.Length; i++)
            {
                combination[index] = collection[i];
                Combine(index + 1, i);
            }
        }

        private static void PrintCombination()
        {
            Console.WriteLine(String.Join(" ", combination));
        }
    }
}
