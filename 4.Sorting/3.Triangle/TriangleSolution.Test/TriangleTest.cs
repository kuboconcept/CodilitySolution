using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriangleSolution.Test
{
    /*
    A zero-indexed array A consisting of N integers is given. A triplet (P, Q, R) is triangular if 0 ≤ P < Q < R < N and:

            A[P] + A[Q] > A[R],
            A[Q] + A[R] > A[P],
            A[R] + A[P] > A[Q].

    For example, consider array A such that:

      A[0] = 10    A[1] = 2    A[2] = 5
      A[3] = 1     A[4] = 8    A[5] = 20

    Triplet (0, 2, 4) is triangular.

    Write a function:

        int solution(int A[], int N); 

    that, given a zero-indexed array A consisting of N integers, returns 1 if there exists a triangular triplet for this array and returns 0 otherwise.

    For example, given array A such that:

      A[0] = 10    A[1] = 2    A[2] = 5
      A[3] = 1     A[4] = 8    A[5] = 20

    the function should return 1, as explained above. Given array A such that:

      A[0] = 10    A[1] = 50    A[2] = 5
      A[3] = 1

    the function should return 0.

    Assume that:

            N is an integer within the range [0..100,000];
            each element of array A is an integer within the range [−2,147,483,648..2,147,483,647].

    Complexity:

            expected worst-case time complexity is O(N*log(N));
            expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

    Elements of input arrays can be modified.
    */

    [TestClass]
    public class TriangleTest
    {
        /// <summary>
        /// Failed_s the n greater than maximum length_ argument out of range exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_NGreaterThanMaxLength_ArgumentOutOfRangeException()
        {
            // arrange
            var a = new int[Triangle.MAX_LENGTH + 1];

            // act
            Triangle.Solution(a);
        }

        /// <summary>
        /// Success_s the empty data.
        /// </summary>
        [TestMethod]
        public void Success_EmptyData()
        {
            // arrange
            var a = new int[0];

            // act
            var result = Triangle.Solution(a);

            // assert
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Success_s the basic data.
        /// </summary>
        [TestMethod]
        public void Success_BasicData()
        {
            // arrange
            var a = new int[] { 10, 2, 5, 8, 1, 8, 20 };

            // act
            var result = Triangle.Solution(a);

            // assert
            Assert.AreEqual(1, result);
        }
    }
}
