using System;
using System.Linq;

namespace Sortings
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 4, 45, 23, 22, 36, 58, 27, 2, 65, 34, 10, 19, 44, 1, 57, 59, 37, 29, 30 };
            arr = BubbleSort(arr);
            Array.ForEach(arr, a=> Console.Write($"{a} "));
            Console.WriteLine();

            arr = new int[] { 4, 45, 23, 22, 36, 58, 27, 2, 65, 34, 10, 19, 44, 1, 57, 59, 37, 29, 30 };
            arr = MergeSort(arr);
            Array.ForEach(arr, a => Console.Write($"{a} "));
            Console.WriteLine();

            arr = new int[] { 4, 45, 23, 22, 36, 58, 27, 2, 65, 34, 10, 19, 44, 1, 57, 59, 37, 29, 30 };
            arr = QuickSort(arr);
            Array.ForEach(arr, a => Console.Write($"{a} "));

        }

        static int[] BubbleSort(int[] arr)
        {
            if (arr == null) return null;
            for(int i= arr.Length - 1; i > 0; i--)
            {
                for(int j = 0; j < i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }

        static int[] MergeSort(int[] arr)
        {
            if (arr.Length > 1)
            {
                var firstHalf = MergeSort(arr.Take(arr.Length / 2).ToArray());
                var secondHalf = MergeSort(arr.Skip(arr.Length / 2).ToArray());
                return MergeSort(firstHalf, secondHalf);
            }
            return arr;

        }
        private static int[] MergeSort(int[] left,int[] right)
        {
            if (left == null || right == null) return null;
            var lIndex = 0;
            var rIndex = 0;
            var lItem = left[0];
            var rItem = right[0];
            int[] result = new int[] { };
            while (true)
            {
                if (lItem < rItem)
                {
                    result = result.Append(lItem).ToArray();
                    if (lIndex + 1 >= left.Length)
                    {
                        result = result.Concat(right.Skip(rIndex)).ToArray();
                        return result;
                    }
                    lIndex++;
                    lItem = left[lIndex];
                    continue;
                }
                result = result.Append(rItem).ToArray();
                if (rIndex + 1 >= right.Length)
                {
                    result = result.Concat(left.Skip(lIndex)).ToArray();
                    return result;
                }
                rIndex++;
                rItem = right[rIndex];
                continue;
            }
        }

        static int[] QuickSort(int[] arr)
        {
            if (arr.Length <= 1) return arr;
            return QuickSort(arr, 0, arr.Length - 1);
        }
        static int[] QuickSort(int[] arr, int left, int right)
        {
            if (arr.Length <= 1) return arr;
            if (left >= right) return arr;
            var start = left;
            var end = right;

            var pivotPoint = arr[left];
            left++;
            while (left < right)
            {
                if (arr[left] < pivotPoint)
                {
                    left++;
                    continue;
                }
                    
                if (arr[right] > pivotPoint)
                {
                    right--;
                    continue;
                }
                int temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;                    
            }

            if (arr[left] < arr[start])
            {
                arr[start] = arr[left];
                arr[left] = pivotPoint;
            }
            arr = QuickSort(arr, start, left - 1);
            arr = QuickSort(arr, left + 1, arr.Length - 1);
            return arr;
        }
    }
}
