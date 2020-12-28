using System;
using System.Collections.Generic;
using System.Linq;

namespace Dynamic_Programming___Exercise
{
    class BinomalCoefficient
    {
        public int N { get; set; }

        public int K { get; set; }

        public long Value { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());
            var memo = new List<BinomalCoefficient>();

            long result = Binom(n, k, memo);

            Console.WriteLine(result);
        }

        private static long Binom(int n, int k, List<BinomalCoefficient> memo)
        {
            var memoizedCoefficient = memo.FirstOrDefault(x => x.N == n && x.K == k);

            if (memoizedCoefficient != null)
            {
                return memoizedCoefficient.Value;
            }

            if (k == 0 || n == k)
            {
                return 1;
            }

            long result = Binom(n - 1, k, memo) + Binom(n - 1, k - 1, memo);
            memo.Add(new BinomalCoefficient() { N = n, K = k, Value = result });

            return result;
        }
    }
}
