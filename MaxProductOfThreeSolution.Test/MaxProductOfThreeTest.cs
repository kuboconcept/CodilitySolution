using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxProductOfThreeSolution.Test
{
    /*
    A non-empty zero-indexed array A consisting of N integers is given. The product of triplet (P, Q, R) equates to A[P] * A[Q] * A[R] (0 ≤ P < Q < R < N).

    For example, array A such that:

        A[0] = -3
        A[1] = 1
        A[2] = 2
        A[3] = -2
        A[4] = 5
        A[5] = 6

    contains the following example triplets:

            (0, 1, 2), product is −3 * 1 * 2 = −6
            (1, 2, 4), product is 1 * 2 * 5 = 10
            (2, 4, 5), product is 2 * 5 * 6 = 60

    Your goal is to find the maximal product of any triplet.

    Write a function:

        class Solution { public int solution(int[] A); } 

    that, given a non-empty zero-indexed array A, returns the value of the maximal product of any triplet.

    For example, given array A such that:

        A[0] = -3
        A[1] = 1
        A[2] = 2
        A[3] = -2
        A[4] = 5
        A[5] = 6

    the function should return 60, as the product of triplet (2, 4, 5) is maximal.

    Assume that:

            N is an integer within the range [3..100,000];
            each element of array A is an integer within the range [−1,000..1,000].

    Complexity:

            expected worst-case time complexity is O(N*log(N));
            expected worst-case space complexity is O(1), beyond input storage (not counting the storage required for input arguments).

    Elements of input arrays can be modified.
    */

    [TestClass]
    public class MaxProductOfThreeTest
    {
        /// <summary>
        /// Failed_s the n less than minimum length_ argument out of range exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_NLessThanMinLength_ArgumentOutOfRangeException()
        {
            // arrange
            var a = new int[MaxProductOfThree.MIN_LENGTH - 1];

            // act
            MaxProductOfThree.Solution(a);
        }

        /// <summary>
        /// Failed_s the n greater than maximum length_ argument out of range exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_NGreaterThanMaxLength_ArgumentOutOfRangeException()
        {
            // arrange
            var a = new int[MaxProductOfThree.MAX_LENGTH + 1];

            // act
            MaxProductOfThree.Solution(a);
        }

        /// <summary>
        /// Success_s the basic data.
        /// </summary>
        [TestMethod]
        public void Success_BasicData()
        {
            // arrange
            var a = new int[] { -3, 1, 2, -2, 5, 6 };

            // act
            var result = MaxProductOfThree.Solution(a);

            // assert
            Assert.AreEqual(60, result);
        }

        /// <summary>
        /// Success_s the exist negative data.
        /// </summary>
        [TestMethod]
        public void Success_ExistNegativeData()
        {
            // arrange
            var a = new int[] { -3, 1, -2, -2, -5, -6 };

            // act
            var result = MaxProductOfThree.Solution(a);

            // assert
            Assert.AreEqual(30, result);
        }

        /// <summary>
        /// Success_s the all negative data.
        /// </summary>
        [TestMethod]
        public void Success_NegativeData()
        {
            // arrange
            var a = new int[] { -3, -1, -2, -2, -5, -6 };

            // act
            var result = MaxProductOfThree.Solution(a);

            // assert
            Assert.AreEqual(-4, result);
        }
    }
}
