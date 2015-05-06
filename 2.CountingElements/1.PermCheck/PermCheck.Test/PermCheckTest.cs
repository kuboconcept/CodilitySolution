using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: CLSCompliant(true)]

namespace PermCheckSolution.Test
{
    /*
    A non-empty zero-indexed array A consisting of N integers is given.

    A permutation is a sequence containing each element from 1 to N once, and only once.

    For example, array A such that:

        A[0] = 4
        A[1] = 1
        A[2] = 3
        A[3] = 2

    is a permutation, but array A such that:

        A[0] = 4
        A[1] = 1
        A[2] = 3

    is not a permutation, because value 2 is missing.

    The goal is to check whether array A is a permutation.

    Write a function:

        class Solution { public int solution(int[] A); } 

    that, given a zero-indexed array A, returns 1 if array A is a permutation and 0 if it is not.

    For example, given array A such that:

        A[0] = 4
        A[1] = 1
        A[2] = 3
        A[3] = 2

    the function should return 1.

    Given array A such that:

        A[0] = 4
        A[1] = 1
        A[2] = 3

    the function should return 0.

    Assume that:

            N is an integer within the range [1..100,000];
            each element of array A is an integer within the range [1..1,000,000,000].

    Complexity:

            expected worst-case time complexity is O(N);
            expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

    Elements of input arrays can be modified.
    */

    /// <summary>
    /// Test class for PermCheck class.
    /// </summary>
    [TestClass]
    public class PermCheckTest
    {
        /// <summary>
        /// Failed to check because N is greater than 100000.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_NGreaterThan100000_ArgumentOutOfRangeException()
        {
            // arrange
            var a = new int[PermCheck.MAX_LENGTH + 1];

            // act
            PermCheck.Solution(a);
        }

        /// <summary>
        /// Failed to check because one of element is less than 1.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_ItemLessThan1_ArgumentOutOfRangeException()
        {
            // arrange
            var a = new int[] { PermCheck.MIN_VALUE - 1, 1 };

            // act
            PermCheck.Solution(a);
        }

        /// <summary>
        /// Failed to check because one of element is greater than 1000000000.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_ItemGreaterThan1000000000_ArgumentOutOfRangeException()
        {
            // arrange
            var a = new int[] { 1, PermCheck.MAX_VALUE + 1 };

            // act
            PermCheck.Solution(a);
        }

        /// <summary>
        /// Success to check permutation data.
        /// </summary>
        [TestMethod]
        public void Success_PermutationData()
        {
            // arrange
            var a = new int[] { 4, 1, 3, 2 };

            // act
            var result = PermCheck.Solution(a);

            // assign
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Success to check not permutation data.
        /// </summary>
        [TestMethod]
        public void Success_NotPermutationData()
        {
            // arrange
            var a = new int[] { 4, 1, 2 };

            // act
            var result = PermCheck.Solution(a);

            // assign
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Success to check not permutation data. Some number appears twice.
        /// </summary>
        [TestMethod]
        public void Success_NotPermutationData_DoubleItem()
        {
            // arrange
            var a = new int[] { 2, 2, 2 };

            // act
            var result = PermCheck.Solution(a);

            // assign
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Success to check not permutation data. Some numbers is outside the permutation range.
        /// </summary>
        [TestMethod]
        public void Success_NotPermutationData_OutsideRange()
        {
            // arrange
            var a = new int[] { 2, 1, 4 };

            // act
            var result = PermCheck.Solution(a);

            // assign
            Assert.AreEqual(0, result);
        }
    }
}
