using System;
using System.Linq;

namespace SumWithUnlimitedAmountOfCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            var coins = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var targetSum = int.Parse(Console.ReadLine());

            var combinationsCount = GetAllSums(coins, targetSum);

            Console.WriteLine(combinationsCount);
        }

        private static int GetAllSums(int[] coins, int targetSum)
        {
            var sums = new int[targetSum + 1];
            sums[0] = 1;

            foreach (var coin in coins)
            {
                for (int sum = coin; sum < sums.Length; sum++)
                {
                    sums[sum] += sums[sum - coin];
                }
            }

            return sums[targetSum];
        }
    }
}
