using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Pristavko._05
{
    public static class Extensions
    {
        /// <summary>
        ///An extension which calculates the sum of the row in a two dimensional array
        /// </summary>
        /// <returns>An array with sum of elements</returns>
        public static int[] RowsSum(this int[][] array)
        {
            int[] sum = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    sum[i] += array[i][j];
                }
            }
            return sum;
        }
    }
}
