using System;

namespace NChooseKCount
{
    class Program
    {
        static void Main(string[] args)
        {
            double n = int.Parse(Console.ReadLine());
            double k = int.Parse(Console.ReadLine());

            double res = Factorial(n) / (Factorial(k) * Factorial(n - k));

            Console.WriteLine(res);
        }

        static double Factorial(double num)
        {
            if (num <= 0)
            {
                return 1;
            }

            return num * Factorial(num - 1);
        }
    }
}
