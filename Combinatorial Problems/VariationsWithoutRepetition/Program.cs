using System;
using System.Linq;

namespace VariationsWithoutRepetition
{
    class Program
    {
        static int k;
        static char[] collection;
        static char[] variation;

        static void Main(string[] args)
        {
            collection = Console.ReadLine()
                .Split()
                .Select(char.Parse)
                .ToArray();

            k = int.Parse(Console.ReadLine());
            variation = new char[k];

            Variate(0);
        }

        static void Variate(int index)
        {
            if (index == variation.Length)
            {
                PrintVariation();
                return;
            }

            for (int i = 0; i < collection.Length; i++)
            {
                if (!variation.Contains(collection[i]))
                {
                    variation[index] = collection[i];
                    Variate(index + 1);
                    variation[index] = '\0';
                }
            }
        }

        private static void PrintVariation()
        {
            Console.WriteLine(String.Join(" ", variation));
        }
    }
}
