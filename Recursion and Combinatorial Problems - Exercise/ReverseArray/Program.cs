using System;
using System.Linq;

namespace ReverseArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            ReverseRecursively(arr, 0);
            Console.WriteLine(String.Join(" ", arr));
        }

        private static void ReverseRecursively(int[] arr, int index)
        {
            if (index == arr.Length / 2)
            {
                return;
            }

            Swap(arr, index, arr.Length - 1 - index);
            ReverseRecursively(arr, index + 1);
        }

        private static void Swap(int[] arr, int leftIndex, int rightIndex)
        {
            int temp = arr[leftIndex];
            arr[leftIndex] = arr[rightIndex];
            arr[rightIndex] = temp;
        }
    }
}
