using System;
using System.Linq;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            InsertionSort(arr);
            Console.WriteLine(String.Join(" ", arr));
        }

        private static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                var j = i;

                while (j > 0 && arr[j] < arr[j - 1])
                {
                    Swap(arr, j, j - 1);
                    j--;
                }
            }
        }

        private static void Swap(int[] arr, int j, int k)
        {
            var temp = arr[j];
            arr[j] = arr[k];
            arr[k] = temp;
        }
    }
}
