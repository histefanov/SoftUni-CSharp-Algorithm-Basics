using System;
using System.Text;

namespace GeneratingVectors
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] vector = new int[n];

            GenerateVectors(vector, 0);

        }

        static void GenerateVectors(int[] vector, int index)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join("", vector));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                vector[index] = i;
                GenerateVectors(vector, index + 1);
            }
        }
    }
}
