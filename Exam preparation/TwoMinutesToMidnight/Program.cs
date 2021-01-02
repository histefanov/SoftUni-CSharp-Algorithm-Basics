using System;
using System.Collections.Generic;

namespace TwoMinutesToMidnight
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            var cache = new Dictionary<string, long>();

            long result = GetAllWays(n, k, cache);

            Console.WriteLine(result);
        }

        private static long GetAllWays(int n, int k, Dictionary<string, long> cache)
        {
            string nk = $"{n} {k}";

            if (k == 0 || n == k)
            {
                return 1;
            }

            if (cache.ContainsKey(nk))
            {
                return cache[nk];
            }

            var result = GetAllWays(n - 1, k, cache) + GetAllWays(n - 1, k - 1, cache);
            cache.Add($"{n} {k}", result);
            return result;
        }
    }
}
