using System;
using System.Collections.Generic;
using System.Linq;

namespace PermutationsWithoutRepetitions
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] collection = Console.ReadLine()
                .Split()
                .Select(e => char.Parse(e))
                .ToArray();

            Permutate(0, collection);
        }

        private static void Permutate(int index, char[] collection)
        {
            if (index == collection.Length)
            {
                Print(collection);
                return;
            }

            Permutate(index + 1, collection);

            for (int i = index + 1; i < collection.Length; i++)
            {
                Swap(collection, index, i);
                Permutate(index + 1, collection);
                Swap(collection, index, i);
            }
        }

        private static void Swap(char[] collection, int index, int i)
        {
            var temp = collection[index];
            collection[index] = collection[i];
            collection[i] = temp;
        }

        private static void Print(char[] permutation)
        {
            Console.WriteLine(String.Join(" ", permutation));
        }
    }
}
