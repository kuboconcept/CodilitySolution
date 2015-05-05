using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: CLSCompliant(true)]

namespace PermCheckSolution
{
    /*
    A non-empty zero-indexed array A consisting of N integers is given.

    A permutation is a sequence containing each element from 1 to N once, and only once.

    For example, array A such that:

        A[0] = 4
        A[1] = 1
        A[2] = 3
        A[3] = 2

    is a permutation, but array A such that:

        A[0] = 4
        A[1] = 1
        A[2] = 3

    is not a permutation, because value 2 is missing.

    The goal is to check whether array A is a permutation.

    Write a function:

        class Solution { public int solution(int[] A); } 

    that, given a zero-indexed array A, returns 1 if array A is a permutation and 0 if it is not.

    For example, given array A such that:

        A[0] = 4
        A[1] = 1
        A[2] = 3
        A[3] = 2

    the function should return 1.

    Given array A such that:

        A[0] = 4
        A[1] = 1
        A[2] = 3

    the function should return 0.

    Assume that:

            N is an integer within the range [1..100,000];
            each element of array A is an integer within the range [1..1,000,000,000].

    Complexity:

            expected worst-case time complexity is O(N);
            expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

    Elements of input arrays can be modified.
    */

    /// <summary>
    /// Section 2 Lesson 1 PermCheck.
    /// </summary>
    public static class PermCheck
    {
        /// <summary>
        /// The max length.
        /// </summary>
        public static readonly int MAX_LENGTH = 100000;

        /// <summary>
        /// The min value.
        /// </summary>
        public static readonly int MIN_VALUE = 1;

        /// <summary>
        /// The max value.
        /// </summary>
        public static readonly int MAX_VALUE = 1000000000;

        /// <summary>
        /// Solutions the specified a.
        /// </summary>
        /// <param name="a">The input.</param>
        /// <returns>Return 1 if permutation and 0 otherwise.</returns>
        public static int Solution(int[] a)
        {
            // Validate input
            if (a == null || !a.Any())
            {
                throw new ArgumentException("Input is null or empty");
            }

            var length = a.Length;
            var permArray = new int[length + 1];

            try
            {
                // check input length
                if (length > MAX_LENGTH)
                {
                    throw new ArgumentOutOfRangeException("a", "N (length of a) greater than 100000");
                }

                for (int i = 0; i < length; i++)
                {
                    // Check item value
                    if (a[i] < MIN_VALUE || MAX_VALUE < a[i])
                    {
                        throw new ArgumentOutOfRangeException("a", "item (a[i]) is less than 1 or greater than 1000000000");
                    }

                    if (a[i] < length + 1)
                    {
                        permArray[a[i]]++;

                        // Return immediately if there are a number that appears more than one times.
                        if (permArray[a[i]] > 1)
                        {
                            return 0;
                        }
                    }
                }

                // Check every item
                for (int j = 1; j < length + 1; j++)
                {
                    if (permArray[j] == 0)
                    {
                        return 0;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return 1;
        }
    }
}
