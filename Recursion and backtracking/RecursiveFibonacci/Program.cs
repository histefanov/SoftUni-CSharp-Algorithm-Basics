using System;
using System.Collections.Generic;

namespace RecursiveFibonacci
{
    class Program
    {
        static Dictionary<int, int> fibMemo = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int res = GetFibonacci(n);

            Console.WriteLine(res);
        }

        static int GetFibonacci(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            if (fibMemo.ContainsKey(n))
            {
                return fibMemo[n];
            }

            int res = GetFibonacci(n - 1) + GetFibonacci(n - 2);
            fibMemo.Add(n, res);

            return res;
        }
    }
}
