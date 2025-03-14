using System;
namespace _5_Sorting_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Write("Fill the array:");
            int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
            while (true)
            {
                Console.WriteLine("1 - SelectionSort \n2 - BubbleSort \n3 - InsertionSort \n4 - ShakerSort \n5 - QuickSort");
                int choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        PrintArray(SelectionSort(arr));
                        break;
                    case 2:
                        PrintArray(BubbleSort(arr));
                        break;
                    case 3:
                        PrintArray(InsertionSort(arr));
                        break;
                    case 4:
                        PrintArray(ShakerSort(arr));
                        break;
                    case 5:
                        PrintArray(QuickSort(arr, 0, arr.Length - 1));
                        break;
                    default:
                        Console.WriteLine("Something is going wrong");
                        break;
                }

            }
        }
        static void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        static int[] SelectionSort(int[] arr)
        {
            int firstIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                firstIndex = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[firstIndex]) firstIndex = j;
                }
                if (i != firstIndex) Swap(ref arr[i], ref arr[firstIndex]);
            }
            return arr;
        }
        static int[] BubbleSort(int[] arr)
        {
            bool flag;
            for (int i = 0; i < arr.Length; i++)
            {
                flag = true;
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                        flag = false;
                    }
                }
                if (flag) break;
            }
            return arr;
        }
        static int[] InsertionSort(int[] arr)
        {
            for(int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int next = i - 1;
                while (next >= 0 && arr[next] > key)
                {
                    arr[next + 1] = arr[next];
                    next--;
                }
                arr[next + 1] = key;
            }
            
            return arr;
        }
        static int[] ShakerSort(int[] arr)
        {
            int left = 0;
            int right = arr.Length - 1;
            while (left <= right)
            {
                for (int i = right; i > left; i--)
                {
                    if (arr[i] < arr[i - 1])
                    {
                        Swap(ref arr[i], ref arr[i - 1]);
                    }
                }
                left++;
                for (int i = left; i < right; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(ref arr[i], ref arr[i + 1]);
                    }
                }
                right--;
            }

            return arr;
        }
        static int[] QuickSort(int[] arr, int left, int right)
        {
            if(left >= right) return arr;

            int pivot = arr[(left + right) / 2];
            int i = left, j = right;

            do
            {
                while (arr[i] < pivot) i++;
                while (arr[j] > pivot) j--;

                if (i <= j)
                {
                    Swap(ref arr[i], ref arr[j]);
                    i++;
                    j--;
                }
                    
             } while (i <= j);

            QuickSort(arr, left, j);
            QuickSort(arr, i, right);
            return arr;
        }
        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
