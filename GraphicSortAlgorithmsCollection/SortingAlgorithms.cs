using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GraphicSortAlgorithmsCollection
{
    class SortingAlgorithms
    {
        public static void InsertionSort(ref List<int> input)
        {
            for(int i = 0; i < input.Count; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (input[j] < input[j - 1])
                    {
                        int temp = input[j];
                        input[j] = input[j - 1];
                        input[j - 1] = temp;
                    }
                }
            }
        }
        public static void BubbleSort(ref List<int> input)
        {
            bool swapped = true;
            int j = 0;
            while(swapped)
            {
                swapped = false;
                j++;
                for(int i = 0; i < input.Count - j; i++)
                {
                    if(input[i] > input[i+1])
                    {
                        swapped = true;
                        //Swap
                        int temp = input[i];
                        input[i] = input[i + 1];
                        input[i + 1] = temp;
                    }
                }
            }
        }
        public static void SelectionSort(ref List<int> input)
        {
            int minIndex;
            for(int i = 0; i < input.Count; i++)
            {
                minIndex = i;
                for(int j = i; j < input.Count; j++)
                {
                    if (input[minIndex] > input[j])
                        minIndex = j;
                }
                if (minIndex != i)
                {
                    //Swap
                    int temp = input[i];
                    input[i] = input[minIndex];
                    input[minIndex] = temp;
                }
            }
        }

        public static List<int> MergeSort(List<int> input)
        {
            if (input.Count <= 1)
                return input;

            List<int> left = new List<int>();
            List<int> right = new List<int>();
            List<int> result = new List<int>();

            int mid = input.Count / 2;
            for (int i = 0; i <= mid - 1; i++)
                left.Add(input[i]);
            for (int i = mid; i < input.Count; i++)
                right.Add(input[i]);

            //Recursive calls
            left = MergeSort(left);
            right = MergeSort(right);
            result = Merge(ref left, ref right);

            return result;
        }


        //Merge two lists
        private static List<int> Merge(ref List<int> left, ref List<int> right)
        {
            List<int> result = new List<int>();

            while(left.Count > 0 && right.Count > 0)
            {
                //if(left.Count > 0 && right.Count > 0)
                //{
                    if(left.First<int>() <= right.First<int>())
                    {
                        result.Add(left.First<int>());
                        left.Remove(left.First<int>());
                    }
                    else
                    {
                        result.Add(right.First<int>());
                        right.Remove(right.First<int>());
                    }
                //}
            }
            while (left.Count > 0)
            {
                result.Add(left.First<int>());
                left.Remove(left.First<int>());
            }
            while (right.Count > 0)
            {
                result.Add(right.First<int>());
                right.Remove(right.First<int>());
            }
            
            return result;
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
