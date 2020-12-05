using System;
using System.Linq;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
             var collection = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int targetNum = int.Parse(Console.ReadLine());

            collection = collection.OrderBy(x => x).ToArray();

            int targetNumIndex = RecursiveBinarySearch(collection, targetNum, 0, collection.Length - 1);

            Console.WriteLine(targetNumIndex);
        }

        // Iterative approach:
        private static int BinarySearch(int[] collection, int target)
        {
            var left = 0;
            var right = collection.Length - 1;

            while (left <= right)
            {
                var mid = (left + right) / 2;
                var element = collection[mid];

                if (element > target)
                {
                    right = mid - 1;
                }
                else if (element < target)
                {
                    left = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return -1;
        }

        // Recursive approach:
        private static int RecursiveBinarySearch(int[] collection, int target, int leftBoundary, int rightBoundary)
        {
            int middleIdx = (leftBoundary + rightBoundary) / 2;

            if (collection[middleIdx] == target)
            {
                return middleIdx;
            }

            if (leftBoundary > rightBoundary)
            {
                return -1;
            }

            if (collection[middleIdx] > target)
            {
                return RecursiveBinarySearch(collection, target, leftBoundary, middleIdx - 1);
            }
            else
            {
                return RecursiveBinarySearch(collection, target, middleIdx + 1, rightBoundary);
            }
        }
    }
}
