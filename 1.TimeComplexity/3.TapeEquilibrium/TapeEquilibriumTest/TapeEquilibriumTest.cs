using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: CLSCompliant(true)]

namespace TapeEquilibriumSolution.Test
{
    /*
    A non-empty zero-indexed array A consisting of N integers is given. Array A represents numbers on a tape.

    Any integer P, such that 0 < P < N, splits this tape into two non-empty parts: A[0], A[1], ..., A[P − 1] and A[P], A[P + 1], ..., A[N − 1].

    The difference between the two parts is the value of: |(A[0] + A[1] + ... + A[P − 1]) − (A[P] + A[P + 1] + ... + A[N − 1])|

    In other words, it is the absolute difference between the sum of the first part and the sum of the second part.

    For example, consider array A such that:

      A[0] = 3
      A[1] = 1
      A[2] = 2
      A[3] = 4
      A[4] = 3

    We can split this tape in four places:

            P = 1, difference = |3 − 10| = 7
            P = 2, difference = |4 − 9| = 5
            P = 3, difference = |6 − 7| = 1
            P = 4, difference = |10 − 3| = 7

    Write a function:

        int solution(int A[], int N); 

    that, given a non-empty zero-indexed array A of N integers, returns the minimal difference that can be achieved.

    For example, given:

      A[0] = 3
      A[1] = 1
      A[2] = 2
      A[3] = 4
      A[4] = 3

    the function should return 1, as explained above.

    Assume that:

            N is an integer within the range [2..100,000];
            each element of array A is an integer within the range [−1,000..1,000].

    Complexity:

            expected worst-case time complexity is O(N);
            expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

    Elements of input arrays can be modified.
    */

    /// <summary>
    /// Test class for TapeEquilibrium class.
    /// </summary>
    [TestClass]
    public class TapeEquilibriumTest
    {
        /// <summary>
        /// Failed_s the n less than minimum length_ argument out of range exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_NLessThanMinLength_ArgumentOutOfRangeException()
        {
            // arrange
            var a = new int[TapeEquilibrium.MIN_LENGTH - 1];

            // act
            TapeEquilibrium.Solution(a);
        }

        /// <summary>
        /// Failed_s the n greater than maximum length_ argument out of range exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_NGreaterThanMaxLength_ArgumentOutOfRangeException()
        {
            // arrange
            var a = new int[TapeEquilibrium.MAX_LENGTH + 1];

            // act
            TapeEquilibrium.Solution(a);
        }

        /// <summary>
        /// Failed_s the item less than minimum value_ argument out of range exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Failed_ItemLessThanMinValue_ArgumentOutOfRangeException()
        {
            // arrange
            var a = new int[] { TapeEquilibrium.MIN_VALUE - 1, 1 };

            // act
            TapeEquilibrium.Solution(a);
        }

        /// <summary>
        /// Failed_s the item greater than maximum value_ invalid operation exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Failed_ItemGreaterThanMaxValue_InvalidOperationException()
        {
            // arrange
            var a = new int[] { TapeEquilibrium.MAX_VALUE + 1, 1 };

            // act
            TapeEquilibrium.Solution(a);
        }

        /// <summary>
        /// Success_s the basic data.
        /// </summary>
        [TestMethod]
        public void Success_BasicData()
        {
            // arrange
            var a = new int[] { 3, 1, 2, 4, 3 };

            // act
            var result = TapeEquilibrium.Solution(a);
            
            // assert
            Assert.AreEqual(1, result);
        }
    }
}
