using System;
using System.Linq;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            BubbleSort(arr);
            Console.WriteLine(String.Join(" ", arr));
        }

        private static void BubbleSort(int[] arr)
        {
            bool needsSwapping = true;
            while (needsSwapping)
            {
                needsSwapping = false;

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i + 1] < arr[i])
                    {
                        Swap(arr, i, i + 1);
                        needsSwapping = true;
                    }
                }
            }
        }

        private static void Swap(int[] arr, int firstIdx, int secondIdx)
        {
            var temp = arr[firstIdx];
            arr[firstIdx] = arr[secondIdx];
            arr[secondIdx] = temp;
        }
    }
}
