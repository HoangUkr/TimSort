using System;

namespace Demo_1
{
    public class Program
    {
        
        public static int[] ArrayGenerator(int n)
        {
            int[] array = new int[n];
            Random random = new Random();
            for(int i = 0; i < n; i++)
            {
                array[i] = random.Next(50);
            }
            return array;
        }
        public static void PrintArray(int n, int[] array)
        {
            Console.WriteLine("Output array: ");
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("Element {0}: {1}",i+1,array[i]);
            }
        }
        public const int RUN = 32;
        public static void insertionSort(int[] arr, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int temp = arr[i];
                int j = i - 1;
                while (j >= left && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp;
            }
        }
        public static void merge(int[] arr, int l, int m, int r)
        {
            int len1 = m - l + 1;
            int len2 = r - m;
            int[] left = new int[len1];
            int[] right = new int[len2];
            for (int x = 0; x < len1; x++)
            {
                left[x] = arr[l + x];
            }
            for (int x = 0; x < len2; x++)
            {
                right[x] = arr[m + 1 + x];
            }
            int i = 0;
            int j = 0;
            int k = l;
            while (i < len1 && j < len2)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }
            while (i < len1)
            {
                arr[k] = left[i];
                k++;
                i++;
            }
            while (j < len2)
            {
                arr[k] = right[j];
                k++;
                j++;
            }
        }
        public static void timSort(int[] arr, int n)
        {
            for (int i = 0; i < n; i += RUN)
            {
                insertionSort(arr, i, Math.Min((i + 31), (n - 1)));
            }
            for (int size = RUN; size < n; size = 2 * size)
            {
                for (int left = 0; left < n; left += 2 * size)
                {
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1), (n - 1));
                    merge(arr, left, mid, right);
                }
            }
        }
        static void Main(string[] args)
        {
            char s;
            do
            {
                Console.WriteLine("Enter size of array: ");
                int n = Convert.ToInt32(Console.ReadLine());
                int[] a = ArrayGenerator(n);
                PrintArray(n, a);
                timSort(a, n);
                PrintArray(n, a);
                Console.WriteLine("Try again? y/n");
                s = Console.ReadLine()[0];
                Console.Clear();
            } while (s != 'n');
            Console.ReadKey();
        }
    }
}
