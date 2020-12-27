using System;
using System.Collections.Generic;
using System.Linq;

namespace SubsetSumWithRepetition
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var targetSum = int.Parse(Console.ReadLine());

            var possibleSums = GetAllSums(nums, targetSum);
            var combination = ExtractCombination(nums, targetSum, possibleSums);

            Console.WriteLine(combination);
        }

        private static object ExtractCombination(int[] nums, int targetSum, bool[] sums)
        {
            if (!sums[targetSum])
            {
                return "Could not reach target sum with the provided integers.";
            }
            else
            {
                var usedNums = new List<int>();

                while (targetSum > 0)
                {
                    foreach (var num in nums)
                    {
                        targetSum -= num;

                        if (targetSum < 0 || !sums[targetSum])
                        {
                            targetSum += num;
                        }
                        else if (sums[targetSum])
                        {
                            usedNums.Add(num);
                            break;
                        }
                    }
                }

                return $"Combination used: {string.Join(", ", usedNums)}";
            }
        }

        private static bool[] GetAllSums(int[] nums, int targetSum)
        {
            var sums = new bool[targetSum + 1];
            sums[0] = true;

            for (int currentSum = 0; currentSum < sums.Length; currentSum++)
            {
                if (sums[currentSum])
                {
                    foreach (var num in nums)
                    {
                        var newSum = currentSum + num;

                        if (newSum <= targetSum)
                        {
                            sums[newSum] = true;
                        }
                    }
                }
            }

            return sums;
        }
    }
}
