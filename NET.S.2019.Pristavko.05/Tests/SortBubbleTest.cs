using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Pristavko._05.Tests
{
    class SortBubbleTest
    {
        #region Ascending test
        /// <summary>
        /// Tests the jagged array bubble sorting in an ascending order 
        /// </summary>
        [Test]
        public void SortBubble_Ascending()
        {

            int[][] sortArray = new int[][]
            {
                new int[] {345, 365, 43, -8, 0, 546}
            };

            var actualResult = SortBubble.SortAscending(sortArray);

            var expectedResult = new int[][]
            {
                new int[] {-8, 0, 43, 345, 365, 546}
            };

            Assert.AreEqual(expectedResult, actualResult);
        }
        #endregion

        #region Descending test
        /// <summary>
        /// Tests the jagged array bubble sorting in an descending order 
        /// </summary>
        [Test]
        public void SortBubble_Descending()
        {
            int[][] sortArray = new int[][]
            {
                new int[] { 345, 365, 43, -8, 0, 546 }
            };

            var actualResult = SortBubble.SortDescending(sortArray);

            var expectedResult = new int[][]
            {
                new int[] {546, 365, 345, 43, 0, -8}
            };

            Assert.AreEqual(expectedResult, actualResult);
        }
        #endregion

        #region SortRowsSum tests
        [Test]
        public void SortRowsSum_Ascending()
        {
            int[][] sortArray = new int[][]
            {
                new int[] {2, 8, 33},
                new int[] {21, 4, 42, 0, 28},
                new int[] {46, 2, 5, 8, 1, 0 , 43},
                new int[] {40, 7, 32, 34, 2, 33}
            };

            var actualResult = SortBubble.SortRowsSum(sortArray);

            int[] expectedResult = new int[] { 43, 95, 105, 148 };

            Assert.AreEqual(actualResult,expectedResult);
        }
        #endregion
    }
}
