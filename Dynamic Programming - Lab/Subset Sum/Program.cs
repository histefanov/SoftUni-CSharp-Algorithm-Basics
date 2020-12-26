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

            Console.WriteLine(String.Join(" ", sums));
        }

        private static HashSet<int> GetAllSums(int[] nums)
        {
            var sums = new HashSet<int> { 0 };

            foreach (var num in nums)
            {
                var newSums = new HashSet<int>();
                foreach (var sum in sums)
                {
                    newSums.Add(sum + num);
                }

                sums.UnionWith(newSums);
            }

            return sums;
        }
    }
}
