using System;
using System.Collections.Generic;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var memo = new Dictionary<int, long>();

            long result = Fibonacci(n, memo);
            Console.WriteLine(result);
        }

        private static long Fibonacci(int n, Dictionary<int, long> memo)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            if (memo.ContainsKey(n))
            {
                return memo[n];
            }
            else
            {
                long result = Fibonacci(n - 1, memo) + Fibonacci(n - 2, memo);
                memo.Add(n, result);
                return result;
            }
        }
    }
}
