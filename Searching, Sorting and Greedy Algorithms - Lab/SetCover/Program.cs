using System;
using System.Collections.Generic;
using System.Linq;

namespace SetCover
{
    class Program
    {
        static void Main(string[] args)
        {
            var universe = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();
            int n = int.Parse(Console.ReadLine());

            var sets = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                sets.Add(Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToList());
            }

            ExtractSubsets(universe, sets);
        }

        private static void ExtractSubsets(List<int> universe, List<List<int>> sets)
        {
            var takenSets = new List<List<int>>();

            while (universe.Count > 0)
            {
                var topSet = sets
                    .OrderByDescending(s => s.Count(el => universe.Contains(el)))
                    .FirstOrDefault();

                foreach (var element in topSet)
                {
                    universe.Remove(element);
                }

                takenSets.Add(topSet);
                sets.Remove(topSet);
            }

            Console.WriteLine($"Sets to take ({takenSets.Count}):");
            foreach (var set in takenSets)
            {
                Console.WriteLine(string.Join(", ", set));
            }
        }
    }
}
