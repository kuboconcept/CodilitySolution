using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: CLSCompliant(true)]

namespace PermMissingElementSolution
{
    /* 
    A zero-indexed array A consisting of N different integers is given. The array contains integers in the range [1..(N + 1)], which means that exactly one element is missing.

    Your goal is to find that missing element.

    Write a function:

        class Solution { public int solution(int[] A); } 

    that, given a zero-indexed array A, returns the value of the missing element.

    For example, given array A such that:

      A[0] = 2
      A[1] = 3
      A[2] = 1
      A[3] = 5

    the function should return 4, as it is the missing element.

    Assume that:

            N is an integer within the range [0..100,000];
            the elements of A are all distinct;
            each element of array A is an integer within the range [1..(N + 1)].

    Complexity:

            expected worst-case time complexity is O(N);
            expected worst-case space complexity is O(1), beyond input storage (not counting the storage required for input arguments).

    Elements of input arrays can be modified.
    */

    /// <summary>
    /// Section 1 Lesson 2 PermMissing Element.
    /// </summary>
    public static class PermMissingElement
    {
        /// <summary>
        /// The max length.
        /// </summary>
        public static readonly int MAX_LENGTH = 100000;

        /// <summary>
        /// Solutions the specified a.
        /// </summary>
        /// <param name="a">The array of input.</param>
        /// <returns>The missing element.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// N;N greater than 100000
        /// or
        /// Item;Item is greater than N + 1.
        /// </exception>
        public static int Solution(int[] a)
        {
            // validate input
            if (a == null || !a.Any())
            {
                throw new ArgumentException("Input is null or empty");
            }

            var result = 0;
            var total = 0;
            var actualTotal = 0;
            var length = a.Length;

            try
            {
                // check input length
                if (length > MAX_LENGTH)
                {
                    throw new ArgumentOutOfRangeException("a", "N (length of a) greater than 100000");
                }

                for (int i = 0; i < length; i++)
                {
                    if (a[i] > length + 1)
                    {
                        throw new ArgumentOutOfRangeException("a", "Item (a[i]) is greater than N + 1");
                    }

                    actualTotal += a[i];
                    total += i + 1;
                }

                total += length + 1;
                result = total - actualTotal;
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}
