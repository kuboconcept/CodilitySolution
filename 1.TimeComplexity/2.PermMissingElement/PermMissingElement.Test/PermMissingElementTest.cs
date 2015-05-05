using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: CLSCompliant(true)]

namespace PermMissingElementSolution.Test
{
    /* 
    A zero-indexed array A consisting of N different integers is given. The array contains integers in the range [1..(N + 1)], which means that exactly one element is missing.

    Your goal is to find that missing element.

    Write a function:

        class Solution { public int solution(int[] A); } 

    that, given a zero-indexed array A, returns the value of the missing element.

    For example, given array A such that:

      A[0] = 2
      A[1] = 3
      A[2] = 1
      A[3] = 5

    the function should return 4, as it is the missing element.

    Assume that:

            N is an integer within the range [0..100,000];
            the elements of A are all distinct;
            each element of array A is an integer within the range [1..(N + 1)].

    Complexity:

            expected worst-case time complexity is O(N);
            expected worst-case space complexity is O(1), beyond input storage (not counting the storage required for input arguments).

    Elements of input arrays can be modified.
    */

    /// <summary>
    /// Test class for PermMissingElement class.
    /// </summary>
    [TestClass]
    public class PermMissingElementTest
    {
        /// <summary>
        /// Failed_s the n greater than100000_ argument out of range exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_NGreaterThan100000_ArgumentOutOfRangeException()
        {
            // arrange
            var a = new int[100001];

            // act
            PermMissingElement.Solution(a);
        }

        /// <summary>
        /// Failed_s the item greater than n_ argument out of range exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_ItemGreaterThanN_ArgumentOutOfRangeException()
        {
            // arrange
            var a = new int[] { 2, 4, 7, 5 };

            // act
            PermMissingElement.Solution(a);
        }

        /// <summary>
        /// Success_s the valid data.
        /// </summary>
        [TestMethod]
        public void Success_ValidData()
        {
            // arrange
            var a = new int[] { 2, 3, 1, 5 };

            // act
            var result = PermMissingElement.Solution(a);

            // assert
            Assert.AreEqual(result, 4);
        }
    }
}
