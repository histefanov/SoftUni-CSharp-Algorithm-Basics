using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DividingPresents
{
    class Program
    {
        static void Main(string[] args)
        {
            var presents = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var lesserSumTarget = presents.Sum() / 2;

            var sums = GetAllSums(presents);

            var adamsSum = sums
                .Where(s => s.Key <= lesserSumTarget)
                .OrderByDescending(s => s.Key)
                .FirstOrDefault()
                .Key;

            List<int> adamsPresents = RecoverPresents(adamsSum, sums);

            var result = new StringBuilder();
            result
                .AppendLine($"Difference: {presents.Sum() - adamsSum * 2}")
                .AppendLine($"Alan:{adamsSum} Bob:{presents.Sum() - adamsSum}")
                .AppendLine($"Alan takes: {string.Join(" ", adamsPresents)}")
                .Append("Bob takes the rest.");

            Console.WriteLine(result);
        }

        private static List<int> RecoverPresents(int sum, Dictionary<int, int> sums)
        {
            var presents = new List<int>();

            while (sum > 0)
            {
                var currentPresent = sums[sum];
                presents.Add(currentPresent);
                sum -= currentPresent;
            }

            return presents;
        }

        private static Dictionary<int, int> GetAllSums(int[] presents)
        {
            var sums = new Dictionary<int, int> { { 0, 0 } };

            foreach (var present in presents)
            {
                var currentSums = sums.Keys.ToArray();
                foreach (var sum in currentSums)
                {
                    var newSum = sum + present;

                    if (!sums.ContainsKey(newSum))
                    {
                        sums.Add(newSum, present);
                    }
                }
            }

            return sums;
        }
    }
}
