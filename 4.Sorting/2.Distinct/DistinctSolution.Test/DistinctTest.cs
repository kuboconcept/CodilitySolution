using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DistinctSolution.Test
{
    /*
    Write a function

        int solution(int A[], int N); 

    that, given a zero-indexed array A consisting of N integers, returns the number of distinct values in array A.

    Assume that:

            N is an integer within the range [0..100,000];
            each element of array A is an integer within the range [−1,000,000..1,000,000].

    For example, given array A consisting of six elements such that:

        A[0] = 2    A[1] = 1    A[2] = 1
        A[3] = 2    A[4] = 3    A[5] = 1

    the function should return 3, because there are 3 distinct values appearing in array A, namely 1, 2 and 3.

    Complexity:

            expected worst-case time complexity is O(N*log(N));
            expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

    Elements of input arrays can be modified.
    */

    [TestClass]
    public class DistinctTest
    {

        /// <summary>
        /// Failed_s the n greater than maximum length_ argument out of range exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_NGreaterThanMaxLength_ArgumentOutOfRangeException()
        {
            // arrange
            var a = new int[Distinct.MAX_LENGTH + 1];

            // act
            Distinct.Solution(a);
        }

        /// <summary>
        /// Failed_s the item less than minimum value_ invalid operation exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Failed_ItemLessThanMinValue_InvalidOperationException()
        {
            // arrange
            var a = new int[] { Distinct.MIN_VALUE - 1, 1 };

            // act
            Distinct.Solution(a);
        }

        /// <summary>
        /// Failed_s the item greater than maximum value_ invalid operation exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Failed_ItemGreaterThanMaxValue_InvalidOperationException()
        {
            // arrange
            var a = new int[] { Distinct.MAX_VALUE + 1, 1 };

            // act
            Distinct.Solution(a);
        }

        /// <summary>
        /// Success_s the basic data.
        /// </summary>
        [TestMethod]
        public void Success_BasicData()
        {
            // arrange
            var a = new int[] { 2, 1, 1, 2, 3, 1 };

            // act
            var result = Distinct.Solution(a);

            // assert
            Assert.AreEqual(3, result);
        }
    }
}
