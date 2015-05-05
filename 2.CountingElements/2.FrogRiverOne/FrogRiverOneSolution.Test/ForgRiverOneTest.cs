using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrogRiverOneSolution.Test
{
    /*
    A small frog wants to get to the other side of a river. The frog is currently located at position 0, and wants to get to position X. Leaves fall from a tree onto the surface of the river.

    You are given a non-empty zero-indexed array A consisting of N integers representing the falling leaves. A[K] represents the position where one leaf falls at time K, measured in minutes.

    The goal is to find the earliest time when the frog can jump to the other side of the river. The frog can cross only when leaves appear at every position across the river from 1 to X.

    For example, you are given integer X = 5 and array A such that:

      A[0] = 1
      A[1] = 3
      A[2] = 1
      A[3] = 4
      A[4] = 2
      A[5] = 3
      A[6] = 5
      A[7] = 4

    In minute 6, a leaf falls into position 5. This is the earliest time when leaves appear in every position across the river.

    Write a function:

        class Solution { public int solution(int X, int[] A); } 

    that, given a non-empty zero-indexed array A consisting of N integers and integer X, returns the earliest time when the frog can jump to the other side of the river.

    If the frog is never able to jump to the other side of the river, the function should return −1.

    For example, given X = 5 and array A such that:

      A[0] = 1
      A[1] = 3
      A[2] = 1
      A[3] = 4
      A[4] = 2
      A[5] = 3
      A[6] = 5
      A[7] = 4

    the function should return 6, as explained above.

    Assume that:

            N and X are integers within the range [1..100,000];
            each element of array A is an integer within the range [1..X].

    Complexity:

            expected worst-case time complexity is O(N);
            expected worst-case space complexity is O(X), beyond input storage (not counting the storage required for input arguments).

    Elements of input arrays can be modified.
    */

    /// <summary>
    /// Test class for FrogRiverOne class.
    /// </summary>
    [TestClass]
    public class ForgRiverOneTest
    {
        /// <summary>
        /// Failed_s the n greater than maximum length_ argument out of range exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_NGreaterThanMaxLength_ArgumentOutOfRangeException()
        {
            // Arrange
            var x = 10;
            var a = new int[100001];

            // Act
            FrogRiverOne.Solution(x, a);
        }

        /// <summary>
        /// Failed_s the x less than minimum length_ argument out of range exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_XLessThanMinLength_ArgumentOutOfRangeException()
        {
            // Arrange
            var x = -1;
            var a = new int[10];

            // Act
            FrogRiverOne.Solution(x, a);
        }

        /// <summary>
        /// Failed_s the x greater than minimum length_ argument out of range exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_XGreaterThanMinLength_ArgumentOutOfRangeException()
        {
            // Arrange
            var x = 100001;
            var a = new int[10];

            // Act
            FrogRiverOne.Solution(x, a);
        }

        /// <summary>
        /// Failed_s the item less than minimum value_ argument out of range exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Failed_ItemLessThanMinValue_InvalidOperationException()
        {
            // Arrange
            var x = 5;
            var a = new int[] { -1, 2, 3, 4 };

            // Act
            FrogRiverOne.Solution(x, a);
        }

        /// <summary>
        /// Failed_s the item greater than length_ argument out of range exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Failed_ItemGreaterThanLength_InvalidOperationException()
        {
            // Arrange
            var x = 10;
            var a = new int[] { 1, 2, 3, 11 };

            // Act
            FrogRiverOne.Solution(x, a);
        }

        /// <summary>
        /// Success_s the valid data.
        /// </summary>
        [TestMethod]
        public void Success_ValidData()
        {
            // Arrange
            var x = 5;
            var a = new int[] { 1, 3, 1, 4, 2, 3, 5, 4 };

            // Act
            var result = FrogRiverOne.Solution(x, a);

            // Assert
            Assert.AreEqual(6, result);
        }

        /// <summary>
        /// Success_s the frog never arrive to other side.
        /// </summary>
        [TestMethod]
        public void Success_FrogNeverArriveToOtherSide()
        {
            // Arrange
            var x = 5;
            var a = new int[] { 1, 3, 1, 4, 2, 3, 2, 4 };

            // Act
            var result = FrogRiverOne.Solution(x, a);

            // Assert
            Assert.AreEqual(-1, result);
        }
    }
}
