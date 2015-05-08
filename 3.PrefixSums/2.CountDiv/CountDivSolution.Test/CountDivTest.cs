using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountDivSolution.Test
{
    /*
    Write a function:

        class Solution { public int solution(int A, int B, int K); } 

    that, given three integers A, B and K, returns the number of integers within the range [A..B] that are divisible by K, i.e.:

        { i : A ≤ i ≤ B, i mod K = 0 }

    For example, for A = 6, B = 11 and K = 2, your function should return 3, because there are three numbers divisible by 2 within the range [6..11], namely 6, 8 and 10.

    Assume that:

            A and B are integers within the range [0..2,000,000,000];
            K is an integer within the range [1..2,000,000,000];
            A ≤ B.

    Complexity:

            expected worst-case time complexity is O(1);
            expected worst-case space complexity is O(1).
    */

    /// <summary>
    /// Test class for CountDiv class.
    /// </summary>
    [TestClass]
    public class CountDivTest
    {
        /// <summary>
        /// Failed_s a less than minimum value_ invalid operation exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Failed_ALessThanMinValue_InvalidOperationException()
        {
            // arrange
            var a = CountDiv.MIN_VALUE_ITEM - 1;
            var b = a + 100;
            var k = 10;

            // act
            CountDiv.Solution(a, b, k);
        }

        /// <summary>
        /// Failed_s a greater than maximum value_ invalid operation exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Failed_AGreaterThanMaxValue_InvalidOperationException()
        {
            // arrange
            var a = CountDiv.MAX_VALUE + 1;
            var b = a + 100;
            var k = 10;

            // act
            CountDiv.Solution(a, b, k);
        }

        /// <summary>
        /// Failed_s b less than minimum value_ invalid operation exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Failed_BLessThanMinValue_InvalidOperationException()
        {
            // arrange
            var b = CountDiv.MIN_VALUE_ITEM - 1;
            var a = b - 100;
            var k = 10;

            // act
            CountDiv.Solution(a, b, k);
        }

        /// <summary>
        /// Failed_s b greater than maximum value_ invalid operation exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Failed_BGreaterThanMaxValue_InvalidOperationException()
        {
            // arrange
            var a = 10;
            var b = CountDiv.MAX_VALUE + 1;
            var k = 10;

            // act
            CountDiv.Solution(a, b, k);
        }

        /// <summary>
        /// Failed_s k less than minimum value_ invalid operation exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Failed_KLessThanMinValue_InvalidOperationException()
        {
            // arrange
            var a = 10;
            var b = a + 100;
            var k = CountDiv.MIN_VALUE_DIV - 1;

            // act
            CountDiv.Solution(a, b, k);
        }

        /// <summary>
        /// Failed_s k greater than maximum value_ invalid operation exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Failed_KGreaterThanMaxValue_InvalidOperationException()
        {
            // arrange
            var a = 10;
            var b = a + 100;
            var k = CountDiv.MAX_VALUE + 1;

            // act
            CountDiv.Solution(a, b, k);
        }

        /// <summary>
        /// Success_s the valid data.
        /// </summary>
        [TestMethod]
        public void Success_ValidData()
        {
            // arrange
            var a = 6;
            var b = 11;
            var k = 2;

            // act
            var result = CountDiv.Solution(a, b, k);

            // assert
            Assert.AreEqual(3, result);
        }

        /// <summary>
        /// Success_s the valid data.
        /// </summary>
        [TestMethod]
        public void Success_ValidData_Simple()
        {
            // arrange
            var a = 11;
            var b = 345;
            var k = 17;

            // act
            var result = CountDiv.Solution(a, b, k);

            // assert
            Assert.AreEqual(20, result);
        }
    }
}
