using System;
using System.Linq;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            QuickSort(arr, 0, arr.Length - 1);
            Console.WriteLine(string.Join(" ", arr));
        }

        private static void QuickSort(int[] arr, int startIdx, int endIdx)
        {
            if (startIdx >= endIdx)
            {
                return;
            }

            int pivotIdx = Partition(arr, startIdx, endIdx);

            QuickSort(arr, startIdx, pivotIdx - 1);
            QuickSort(arr, pivotIdx + 1, endIdx);
        }

        private static int Partition(int[] arr, int pivot, int endIdx)
        {
            var left = pivot + 1;
            var right = endIdx;

            while (left <= right)
            {
                if (arr[left] > arr[pivot] &&
                    arr[right] < arr[pivot])
                {
                    Swap(arr, left, right);
                }

                if (arr[left] <= arr[pivot])
                {
                    left++;
                }

                if (arr[right] >= arr[pivot])
                {
                    right--;
                }
            }

            Swap(arr, pivot, right);
            return right;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
