using System;
using System.Collections.Generic;
using System.Linq;

namespace SumOfCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            var coinSet = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .ToHashSet();

            int targetSum = int.Parse(Console.ReadLine());

            ReturnCoins(coinSet, targetSum);
        }

        private static void ReturnCoins(HashSet<int> coinSet, int targetSum)
        {
            var usedCoins = new Dictionary<int, int>();

            foreach (var coin in coinSet)
            {
                if (targetSum >= coin)
                {
                    int coinCount = targetSum / coin;
                    usedCoins.Add(coin, coinCount);
                    targetSum -= coin * coinCount;
                }

                if (targetSum == 0)
                {
                    break;
                }
            }

            if (targetSum != 0)
            {
                Console.WriteLine("Error");
            }
            else
            {
                Console.WriteLine($"Number of coins to take: {usedCoins.Sum(x => x.Value)}");
                PrintCoins(usedCoins);
            }
        }

        private static void PrintCoins(Dictionary<int, int> usedCoins)
        {
            foreach (var coin in usedCoins)
            {
                Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
            }
        }
    }
}
