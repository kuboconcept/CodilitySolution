using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PassingCarsSolution.Test
{
    /*
    A non-empty zero-indexed array A consisting of N integers is given. The consecutive elements of array A represent consecutive cars on a road.

    Array A contains only 0s and/or 1s:

            0 represents a car traveling east,
            1 represents a car traveling west.

    The goal is to count passing cars. We say that a pair of cars (P, Q), where 0 ≤ P < Q < N, is passing when P is traveling to the east and Q is traveling to the west.

    For example, consider array A such that:

      A[0] = 0
      A[1] = 1
      A[2] = 0
      A[3] = 1
      A[4] = 1

    We have five pairs of passing cars: (0, 1), (0, 3), (0, 4), (2, 3), (2, 4).

    Write a function:

        int solution(int A[], int N); 

    that, given a non-empty zero-indexed array A of N integers, returns the number of pairs of passing cars.

    The function should return −1 if the number of pairs of passing cars exceeds 1,000,000,000.

    For example, given:

      A[0] = 0
      A[1] = 1
      A[2] = 0
      A[3] = 1
      A[4] = 1

    the function should return 5, as explained above.

    Assume that:

            N is an integer within the range [1..100,000];
            each element of array A is an integer that can have one of the following values: 0, 1.

    Complexity:

            expected worst-case time complexity is O(N);
            expected worst-case space complexity is O(1), beyond input storage (not counting the storage required for input arguments).

    Elements of input arrays can be modified.
    */

    /// <summary>
    /// Test class for PassingCars class.
    /// </summary>
    [TestClass]
    public class PassingCarsTest
    {
        /// <summary>
        /// Failed_s the n greater than maximum length_ argument out of range exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_NGreaterThanMaxLength_ArgumentOutOfRangeException()
        {
            // arrange
            var a = new int[PassingCars.MAX_LENGTH + 1];

            // act
            PassingCars.Solution(a);
        }

        /// <summary>
        /// Failed_s the item less than minimum value_ invalid operation exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Failed_ItemLessThanMinValue_InvalidOperationException()
        {
            // arrange
            var a = new int[] { 0, -1 };

            // act
            PassingCars.Solution(a);
        }

        /// <summary>
        /// Failed_s the item greater than maximum value_ invalid operation exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Failed_ItemGreaterThanMaxValue_InvalidOperationException()
        {
            // arrange
            var a = new int[] { 2, 1 };

            // act
            PassingCars.Solution(a);
        }

        /// <summary>
        /// Success_s the valid data.
        /// </summary>
        [TestMethod]
        public void Success_ValidData()
        {
            // arrange
            var a = new int[] { 0, 1, 0, 1, 1 };

            // act
            var result = PassingCars.Solution(a);

            // assert
            Assert.AreEqual(5, result);
        }

        /// <summary>
        /// Success_s the valid data_ no passing cars.
        /// </summary>
        [TestMethod]
        public void Success_ValidData_NoPassingCars()
        {
            // arrange
            var a = new int[] { 1, 1, 1, 0, 0, 0 };

            // act
            var result = PassingCars.Solution(a);

            // assert
            Assert.AreEqual(0, result);
        }

        /// <summary>
        /// Success_s the valid data_ more than maximum passing cars.
        /// </summary>
        [TestMethod]
        public void Success_ValidData_MoreThanMaxPassingCars()
        {
            // arrange
            var a = new int[100000];
            for (int i = 0; i < a.Length; i++)
            {
                if (i % 2 == 0)
                {
                    a[i] = 0;
                }
                else
                {
                    a[i] = 1;
                }
            }

            // act
            var result = PassingCars.Solution(a);

            // assert
            Assert.AreEqual(-1, result);
        }
    }
}
