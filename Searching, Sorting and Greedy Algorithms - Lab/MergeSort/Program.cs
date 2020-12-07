using System;
using System.Linq;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            MergeSort(arr, 0, arr.Length - 1);

            Console.WriteLine(String.Join(" ", arr));
        }

        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int mid = (left + right) / 2;
            
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int[] temp = new int[right - left + 1];
            int i = left;
            int j = mid + 1;
            int k = 0;

            while (i <= mid && j <= right)
            {
                if (arr[i] <= arr[j])
                {
                    temp[k] = arr[i];
                    i++;
                }
                else
                {
                    temp[k] = arr[j];
                    j++;
                }
                k++;
            }

            while (i <= mid)
            {
                temp[k] = arr[i];
                i++; 
                k++;
            }

            while (j <= right)
            {
                temp[k] = arr[j];
                j++;
                k++;
            }

            for (int l = left; l <= right; l++)
            {
                arr[l] = temp[l - left];
            }
        }
    }
}
