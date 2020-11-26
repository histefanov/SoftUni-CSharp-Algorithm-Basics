using System;
using System.Linq;

namespace CombinationsWithoutRepetitions
{
    class Program
    {
        static char[] collection;
        static int k;
        static char[] combination;

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

        static void Combine(int index, int loopStartIndex)
        {
            if (index == k)
            {
                PrintCombination();
                return;
            }

            for (int i = loopStartIndex; i < collection.Length; i++)
            {
                combination[index] = collection[i];
                Combine(index + 1, i + 1);
            }
        }

        private static void PrintCombination()
        {
            Console.WriteLine(String.Join(" ", combination));
        }
    }
}
