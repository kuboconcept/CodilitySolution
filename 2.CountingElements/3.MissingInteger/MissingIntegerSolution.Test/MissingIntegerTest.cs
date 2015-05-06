using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MissingIntegerSolution.Test
{
    /*
    Write a function:

        class Solution { public int solution(int[] A); } 

    that, given a non-empty zero-indexed array A of N integers, returns the minimal positive integer that does not occur in A.

    For example, given:

      A[0] = 1
      A[1] = 3
      A[2] = 6
      A[3] = 4
      A[4] = 1
      A[5] = 2

    the function should return 5.

    Assume that:

            N is an integer within the range [1..100,000];
            each element of array A is an integer within the range [−2,147,483,648..2,147,483,647].

    Complexity:

            expected worst-case time complexity is O(N);
            expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

    Elements of input arrays can be modified.
    */

    /// <summary>
    /// Test class for MissingInteger class.
    /// </summary>
    [TestClass]
    public class MissingIntegerTest
    {
        /// <summary>
        /// Failed_s the n greater than maximum length_ argument out of range exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_NGreaterThanMaxLength_ArgumentOutOfRangeException()
        {
            // arrange
            var a = new int[MissingInteger.MAX_LENGTH + 1];

            // act
            MissingInteger.Solution(a);
        }

        /// <summary>
        /// Success_s the valid data.
        /// </summary>
        [TestMethod]
        public void Success_ValidData()
        {
            // arrange
            var a = new int[] { 1, 3, 6, 4, 1, 2 };

            // act
            var result = MissingInteger.Solution(a);

            // assert
            Assert.AreEqual(5, result);
        }

        /// <summary>
        /// Success_s the valid data.
        /// </summary>
        [TestMethod]
        public void Success_ValidData_AllNumberIsOccure()
        {
            // arrange
            var a = new int[] { 1, 3, 6, 4, 5, 2 };

            // act
            var result = MissingInteger.Solution(a);

            // assert
            Assert.AreEqual(7, result);
        }

        /// <summary>
        /// Success_s the valid data.
        /// </summary>
        [TestMethod]
        public void Success_ValidData_BigNumber()
        {
            // arrange
            var a = new int[] { 1000, 5000, 7000 };

            // act
            var result = MissingInteger.Solution(a);

            // assert
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Success_s the valid data.
        /// </summary>
        [TestMethod]
        public void Success_ValidData_SingleItem()
        {
            // arrange
            var a = new int[] { 1000 };

            // act
            var result = MissingInteger.Solution(a);

            // assert
            Assert.AreEqual(1, result);
        }
    }
}
