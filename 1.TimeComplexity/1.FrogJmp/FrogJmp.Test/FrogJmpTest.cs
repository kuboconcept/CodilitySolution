using System;
using FrogJmp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FrogJmp.Test
{
    /*
    A small frog wants to get to the other side of the road. The frog is 
    currently located at position X and wants to get to a position greater 
    than or equal to Y. The small frog always jumps a fixed distance, D.

    Count the minimal number of jumps that the small frog must perform 
    to reach its target.

    Write a function:

        int solution(int X, int Y, int D); 

    that, given three integers X, Y and D, returns the minimal number of jumps from position X to a position equal to or greater than Y.

    For example, given:

      X = 10
      Y = 85
      D = 30

    the function should return 3, because the frog will be positioned as follows:

            after the first jump, at position 10 + 30 = 40
            after the second jump, at position 10 + 30 + 30 = 70
            after the third jump, at position 10 + 30 + 30 + 30 = 100

    Assume that:

            X, Y and D are integers within the range [1..1,000,000,000];
            X ≤ Y.

    Complexity:

            expected worst-case time complexity is O(1);
            expected worst-case space complexity is O(1).
    */

    [TestClass]
    public class FrogJmpTest
    {
        Random _rand = new Random();

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_XLessThan1_ArgumentOutOfRangeException()
        {
            // arrange
            // No need arrange data

            // act
            FrogJmp.Solution(_rand.Next(int.MinValue, 1), _rand.Next(FrogJmp.MIN_VAL, FrogJmp.MAX_VAL + 1), _rand.Next(FrogJmp.MIN_VAL, FrogJmp.MAX_VAL + 1));

            // assert
            // No need assert data because expect exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_XBiggerThan1000000000_ArgumentOutOfRangeException()
        {
            // arrange
            // No need arrange data

            // act
            FrogJmp.Solution(_rand.Next(1000000001, int.MaxValue), _rand.Next(FrogJmp.MIN_VAL, FrogJmp.MAX_VAL + 1), _rand.Next(FrogJmp.MIN_VAL, FrogJmp.MAX_VAL + 1));

            // assert
            // No need assert data because expect exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_YLessThan1_ArgumentOutOfRangeException()
        {
            // arrange
            // No need arrange data

            // act
            FrogJmp.Solution(_rand.Next(FrogJmp.MIN_VAL, FrogJmp.MAX_VAL + 1), _rand.Next(int.MinValue, 1), _rand.Next(FrogJmp.MIN_VAL, FrogJmp.MAX_VAL + 1));

            // assert
            // No need assert data because expect exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_YGreaterThan1000000000_ArgumentOutOfRangeException()
        {
            // arrange
            // No need arrange data

            // act
            FrogJmp.Solution(_rand.Next(FrogJmp.MIN_VAL, FrogJmp.MAX_VAL + 1), _rand.Next(FrogJmp.MAX_VAL + 1, int.MaxValue), _rand.Next(FrogJmp.MIN_VAL, FrogJmp.MAX_VAL + 1));

            // assert
            // No need assert data because expect exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_DLessThan1_ArgumentOutOfRangeException()
        {
            // arrange
            // No need arrange data

            // act
            FrogJmp.Solution(_rand.Next(FrogJmp.MIN_VAL, FrogJmp.MAX_VAL + 1), _rand.Next(FrogJmp.MIN_VAL, FrogJmp.MAX_VAL + 1), _rand.Next(int.MinValue, 1));

            // assert
            // No need assert data because expect exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Failed_DGreaterThan1000000000_ArgumentOutOfRangeException()
        {
            // arrange
            // No need arrange data

            // act
            FrogJmp.Solution(_rand.Next(int.MinValue, 1), _rand.Next(FrogJmp.MIN_VAL, FrogJmp.MAX_VAL + 1), _rand.Next(FrogJmp.MAX_VAL + 1, int.MaxValue));

            // assert
            // No need assert data because expect exception
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Failed_XGreaterThanY_InvalidOperationException()
        {
            // arrange
            var x = _rand.Next(FrogJmp.MIN_VAL + 1, FrogJmp.MAX_VAL);
            var y = _rand.Next(FrogJmp.MIN_VAL, x);

            // act
            FrogJmp.Solution(x, y, _rand.Next(FrogJmp.MIN_VAL, FrogJmp.MAX_VAL + 1));

            // assert
            // No need assert data because expect exception
        }

        [TestMethod]
        public void Success_ValidData()
        {
            // arrange
            var x = 10;
            var y = 85;
            var d = 30;

            // act
            var result = FrogJmp.Solution(x, y, d);

            // assert
            Assert.AreEqual(result, 3);
        }
    }
}
