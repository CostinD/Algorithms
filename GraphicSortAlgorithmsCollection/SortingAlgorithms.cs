using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicSortAlgorithmsCollection
{
    class SortingAlgorithms
    {
        public static void InsertionSort(ref int[] input)
        {
            for(int i = 0; i < input.Length; i++)
            {
                int x = input[i];
                for (int j = i; j > 0; j--)
                {
                    if (input[j] < input[j - 1])
                        Swap(ref input[j], ref input[j - 1]);
                }
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
