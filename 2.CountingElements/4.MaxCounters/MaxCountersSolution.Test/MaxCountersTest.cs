using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxCountersSolution.Test
{
    /*
    You are given N counters, initially set to 0, and you have two possible operations on them:

            increase(X) − counter X is increased by 1,
            max counter − all counters are set to the maximum value of any counter.

    A non-empty zero-indexed array A of M integers is given. This array represents consecutive operations:

            if A[K] = X, such that 1 ≤ X ≤ N, then operation K is increase(X),
            if A[K] = N + 1 then operation K is max counter.

    For example, given integer N = 5 and array A such that:

        A[0] = 3
        A[1] = 4
        A[2] = 4
        A[3] = 6
        A[4] = 1
        A[5] = 4
        A[6] = 4

    the values of the counters after each consecutive operation will be:

        (0, 0, 1, 0, 0)
        (0, 0, 1, 1, 0)
        (0, 0, 1, 2, 0)
        (2, 2, 2, 2, 2)
        (3, 2, 2, 2, 2)
        (3, 2, 2, 3, 2)
        (3, 2, 2, 4, 2)

    The goal is to calculate the value of every counter after all operations.

    Write a function:

        class Solution { public int[] solution(int N, int[] A); } 

    that, given an integer N and a non-empty zero-indexed array A consisting of M integers, returns a sequence of integers representing the values of the counters.

    The sequence should be returned as:

            a structure Results (in C), or
            a vector of integers (in C++), or
            a record Results (in Pascal), or
            an array of integers (in any other programming language).

    For example, given:

        A[0] = 3
        A[1] = 4
        A[2] = 4
        A[3] = 6
        A[4] = 1
        A[5] = 4
        A[6] = 4

    the function should return [3, 2, 2, 4, 2], as explained above.

    Assume that:

            N and M are integers within the range [1..100,000];
            each element of array A is an integer within the range [1..N + 1].

    Complexity:

            expected worst-case time complexity is O(N+M);
            expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

    Elements of input arrays can be modified.
    */

    [TestClass]
    public class MaxCountersTest
    {
        /// <summary>
        /// Failed_s the N less than minimum length_ argument out of range exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_NLessThanMinLength_ArgumentOutOfRangeException()
        {
            // arrange
            var n = MaxCounters.MIN_LENGTH - 1;
            var a = new int[1];

            // act
            MaxCounters.Solution(n, a);
        }

        /// <summary>
        /// Failed_s the n greater than maximum length_ argument out of range exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_NGreaterThanMaxLength_ArgumentOutOfRangeException()
        {
            // arrange
            var n = MaxCounters.MAX_LENGTH + 1;
            var a = new int[1];

            // act
            MaxCounters.Solution(n, a);
        }
        /// <summary>
        /// Failed_s the M greater than maximum length_ argument out of range exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_MGreaterThanMaxLength_ArgumentOutOfRangeException()
        {
            // arrange
            var n = 1;
            var a = new int[MaxCounters.MAX_LENGTH + 1];

            // act
            MaxCounters.Solution(n, a);
        }

        /// <summary>
        /// Failed_s the item less than minimum value_ invalid operation exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Failed_ItemLessThanMinValue_InvalidOperationException()
        {
            // arrange
            var n = 2;
            var a = new int[] { MaxCounters.MIN_VALUE - 1, 1 };

            // act
            MaxCounters.Solution(n, a);
        }

        /// <summary>
        /// Failed_s the item greater than maximum value_ invalid operation exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Failed_ItemGreaterThanMaxValue_InvalidOperationException()
        {
            // arrange
            var n = 2;
            var a = new int[] { n + 2, 1 };

            // act
            MaxCounters.Solution(n, a);
        }

        /// <summary>
        /// Success_s the valid data.
        /// </summary>
        [TestMethod]
        public void Success_ValidData()
        {
            // arrange
            var n = 5;
            var a = new int[] { 3, 4, 4, 6, 1, 4, 4 };

            // act
            var result = MaxCounters.Solution(n,a);

            // assert
            var expectedResult = new int[] { 3, 2, 2, 4, 2 };
            CollectionAssert.AreEqual(expectedResult, result);
        }
    }
}
