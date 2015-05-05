using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogRiverOneSolution
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
    /// Section 2 Lesson 2.
    /// </summary>
    public static class FrogRiverOne
    {
        /// <summary>
        /// The min length.
        /// </summary>
        public static readonly int MIN_LENGTH = 1;

        /// <summary>
        /// The max length.
        /// </summary>
        public static readonly int MAX_LENGTH = 100000;

        /// <summary>
        /// The min value.
        /// </summary>
        public static readonly int MIN_VALUE = 1;

        /// <summary>
        /// Solutions the specified x.
        /// </summary>
        /// <param name="x">The deadline time.</param>
        /// <param name="a">The timing array leaves.</param>
        /// <returns>The earliest time for frog to cross the river.</returns>
        /// <exception cref="System.ArgumentException">Input is null or empty.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// a;N (length of a) is less than 1 or more than 100000
        /// or
        /// x;x is less than 1 or more than 100000.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">Item (a[i]) is less than 1 or more than x.</exception>
        public static int Solution(int x, int[] a)
        {
            // validate input
            if (a == null)
            {
                throw new ArgumentException("Input is null or empty");
            }

            var length = a.Length;

            if (length < MIN_LENGTH || MAX_LENGTH < length)
            {
                throw new ArgumentOutOfRangeException("a", "N (length of a) is less than 1 or more than 100000");                
            }

            if (x < MIN_LENGTH || MAX_LENGTH < x)
            {
                throw new ArgumentOutOfRangeException("x", "x is less than 1 or more than 100000");
            }

            try
            {
                var leafArr = new int[x + 1];
                var counter = 0;
                for (int i = 0; i < length; i++)
                {
                    // Check item value
                    if (a[i] > x || a[i] < MIN_VALUE)
                    {
                        throw new InvalidOperationException("Item (a[i]) is less than 1 or more than x");
                    }

                    if (leafArr[a[i]] == 0)
                    {
                        leafArr[a[i]] = 1;
                        counter++;

                        // Check is it cover the river for the frog
                        if (counter == x)
                        {
                            return i;
                        }
                    }
                }
            }
            catch (Exception)
            {                
                throw;
            }

            // The frog never cross the river
            return -1;
        }
    }
}
