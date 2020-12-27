using System;
using System.Collections.Generic;
using System.Linq;

namespace Subset_Sum
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
            var sums = GetAllSums(nums);

            if (!sums.ContainsKey(targetSum))
            {
                Console.WriteLine("Available numbers could not be amounted to the target sum.");
            }
            else
            {
                while (targetSum != 0)
                {
                    var usedNum = sums[targetSum];
                    Console.WriteLine(usedNum);

                    targetSum -= usedNum;
                }
            }
        }

        private static Dictionary<int, int> GetAllSums(int[] nums)
        {
            var sums = new Dictionary<int, int> { { 0, 0 } };

            foreach (var num in nums)
            {
                var newSums = new Dictionary<int, int>();

                var currentSums = sums.Keys.ToArray();
                foreach (var sum in currentSums)
                {
                    var newSum = sum + num;

                    if (!sums.ContainsKey(newSum))
                    {
                        sums.Add(newSum, num);
                    }
                }
            }

            return sums;
        }
    }
}
