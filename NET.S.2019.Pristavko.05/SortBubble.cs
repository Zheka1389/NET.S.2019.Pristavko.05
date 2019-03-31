using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Pristavko._05
{
    public class SortBubble
    {
        #region Sorting public methods
        /// <summary>
        /// An implementation of bubble sorting algorithm for a jagged array
        /// </summary>
        /// <param name="array">Jagged array</param>
        /// <returns>Sorted in ascending order jagged array</returns>
        public static int[][] SortAscending(int[][] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException("Jagged array cannot be null", nameof(array));
            }
            if (array.Length == 0)
            {
                throw new ArgumentException("Jagged array cannot be empty.", nameof(array));
            }
            foreach (var item in array)
            {
                BubbleSortAscending(item);
            }
            return array;
        }

        /// <summary>
        /// Algorithm of ascending bubble sorting for an array
        /// </summary>
        public static int[] BubbleSortAscending(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
            return array;
        }
        /// <summary>
        /// An implementation of bubble sorting algorithm for a jagged array
        /// </summary>
        /// <param name="array">Jagged array</param>
        /// <returns>Sorted in descending order jagged array</returns>
        public static int[][] SortDescending(int[][] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException("Jagged array cannot be null", nameof(array));
            }
            if (array.Length == 0)
            {
                throw new ArgumentException("Jagged array cannot be empty.", nameof(array));
            }
            foreach (var item in array)
            {
                BubbleSortDescending(item);
            }
            return array;
        }

        /// <summary>
        /// Algorithm of descending bubble sorting for an array
        /// </summary>
        public static int[] BubbleSortDescending(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] < array[j])
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
            return array;
        }
        /// <summary>
        /// An emplementation of row sum sorting algorithm
        /// </summary>
        /// <param name="array">Two dementional array for sorting</param>
        /// <returns>Sorted array</returns>
        public static int[] SortRowsSum(int[][] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException("Jagged array cannot be null", nameof(array));
            }
            if (array.Length == 0)
            {
                throw new ArgumentException("Jagged array cannot be empty.", nameof(array));
            }
            int[] sum = array.RowsSum();
            BubbleSortAscending(sum);
            return sum;
        }

        /// <summary>
        /// Element exchange method
        /// </summary>
        private static void Swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }
    }
    #endregion
}
