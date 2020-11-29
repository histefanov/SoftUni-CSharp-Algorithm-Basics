using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolTeams
{
    class Program
    {
        private const int GIRLS_SIZE = 3;
        private const int BOYS_SIZE = 2;

        static void Main(string[] args)
        {
            var girls = Console.ReadLine().Split(", ");
            var boys = Console.ReadLine().Split(", ");

            var girlsCombList = new List<string[]>();
            var boysCombList = new List<string[]>();

            var girlsCombination = new string[GIRLS_SIZE];
            var boysCombination = new string[BOYS_SIZE];

            Combine(0, 0, girlsCombination, girls, girlsCombList);
            Combine(0, 0, boysCombination, boys, boysCombList);

            foreach (var girlsComb in girlsCombList)
            {
                foreach (var boysComb in boysCombList)
                {
                    MergeCombinations(girlsComb, boysComb);
                }
            }
        }

        private static void Combine(int combIndex, int loopIndex, string[] combination, string[] collection, List<string[]> combinationsList)
        {
            if (combIndex == combination.Length)
            {
                combinationsList.Add(combination.ToArray());
                return;
            }

            for (int i = loopIndex; i < collection.Length; i++)
            {
                combination[combIndex] = collection[i];
                Combine(combIndex + 1, i + 1, combination, collection, combinationsList);
            }
        }

        private static void PrintCombination(string[] combination)
        {
            Console.WriteLine(String.Join(", ", combination));
        }

        private static void MergeCombinations(string[] girls, string[] boys)
        {
            var combinedArrays = girls.Concat(boys);
            Console.WriteLine(String.Join(", ", combinedArrays));
        }
    }
}
