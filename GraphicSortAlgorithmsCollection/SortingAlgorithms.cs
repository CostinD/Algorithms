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
        public static void InsertionSort(ref int[] input)
        {
            for(int i = 0; i < input.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (input[j] < input[j - 1])
                        Swap(ref input[j], ref input[j - 1]);
                }
            }
        }
        public static void BubbleSort(ref int[] input)
        {
            bool swapped = true;
            int j = 0;
            while(swapped)
            {
                swapped = false;
                j++;
                for(int i = 0; i < input.Length - j; i++)
                {
                    if(input[i] > input[i+1])
                    {
                        swapped = true;
                        Swap(ref input[i], ref input[i + 1]);
                    }
                }
            }
        }
        public static void SelectionSort(ref int[] input)
        {
            int minIndex;
            for(int i = 0; i < input.Length; i++)
            {
                minIndex = i;
                for(int j = i; j < input.Length; j++)
                {
                    if (input[minIndex] > input[j])
                        minIndex = j;
                }
                if(minIndex != i)
                    Swap(ref input[i], ref input[minIndex]);
            }
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
