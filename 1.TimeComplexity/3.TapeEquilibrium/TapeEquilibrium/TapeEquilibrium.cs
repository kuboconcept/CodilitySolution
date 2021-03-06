﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: CLSCompliant(true)]

namespace TapeEquilibriumSolution
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
    /// Section 1 Lesson 2 PermMissing Element.
    /// </summary>
    public static class TapeEquilibrium
    {
        /// <summary>
        /// The min length.
        /// </summary>
        public static readonly int MIN_LENGTH = 2;

        /// <summary>
        /// The max length.
        /// </summary>
        public static readonly int MAX_LENGTH = 100000;

        /// <summary>
        /// The min value.
        /// </summary>
        public static readonly int MIN_VALUE = -1000;

        /// <summary>
        /// The max value.
        /// </summary>
        public static readonly int MAX_VALUE = 1000;

        /// <summary>
        /// Solutions the specified a.
        /// </summary>
        /// <param name="a">The input array.</param>
        /// <returns>The minimum difference.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// N;Length is less than 2 or more than 100000
        /// or
        /// N;Item value is less than -1000 or more than 1000
        /// or
        /// N;Item value is less than -1000 or more than 1000.
        /// </exception>
        public static int Solution(int[] a)
        {
            // validate input
            if (a == null || !a.Any())
            {
                throw new ArgumentException("Input is null or empty");
            }

            var length = a.Length;
            
            // Check length
            if (length < MIN_LENGTH || MAX_LENGTH < length)
            {
                throw new ArgumentOutOfRangeException("a", "N (length of a) is less than 2 or more than 100000");
            }
            
            var result = 0;

            try
            {
                var sum = new int[length];
                var sumDesc = new int[length];

                // Check item value
                if (a[0] < MIN_VALUE || MAX_VALUE < a[0])
                {
                    throw new InvalidOperationException("Item (a[i]) value is less than -1000 or more than 1000");
                }
                
                // Get sum array value
                for (int i = 1; i < length; i++)
                {
                    // Check item value
                    if (a[i] < MIN_VALUE || MAX_VALUE < a[i])
                    {
                        throw new InvalidOperationException("Item (a[i]) value is less than -1000 or more than 1000");
                    }

                    sum[i] = sum[i - 1] + a[i - 1];

                    if (i == 1)
                    {
                        sumDesc[length - i] = a[length - 1];
                    }
                    else
                    {
                        sumDesc[length - i] = sumDesc[length - i + 1] + a[length - i];
                    }
                }

                // Find minimum difference
                var minDiff = int.MaxValue;
                for (int j = 1; j < length; j++)
                {
                    var diff = Math.Abs(sum[j] - sumDesc[j]);
                    if (diff < minDiff)
                    {
                        minDiff = diff;
                    }
                }

                result = minDiff;
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}
