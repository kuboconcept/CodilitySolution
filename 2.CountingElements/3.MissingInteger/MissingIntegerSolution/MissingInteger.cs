using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissingIntegerSolution
{
    /*
    Write a function:

        class Solution { public int solution(int[] A); } 

    that, given a non-empty zero-indexed array A of N integers, returns the minimal positive integer that does not occur in A.

    For example, given:

      A[0] = 1
      A[1] = 3
      A[2] = 6
      A[3] = 4
      A[4] = 1
      A[5] = 2

    the function should return 5.

    Assume that:

            N is an integer within the range [1..100,000];
            each element of array A is an integer within the range [−2,147,483,648..2,147,483,647].

    Complexity:

            expected worst-case time complexity is O(N);
            expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

    Elements of input arrays can be modified.
    */

    /// <summary>
    /// Session 2 Lesson 3.
    /// </summary>
    public static class MissingInteger
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
        public static readonly int MIN_VALUE = -2147483648;

        /// <summary>
        /// The max value.
        /// </summary>
        public static readonly int MAX_VALUE = 2147483647;

        /// <summary>
        /// Solutions the specified a.
        /// </summary>
        /// <param name="a">The input.</param>
        /// <returns>The minimal positive integer that not occur in input array.</returns>
        /// <exception cref="System.ArgumentException">Input is null or empty.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// a;N (length of a) is more than 100000
        /// or
        /// a;Item (a[i]) value is less than -2147483648 or more than 2147483647.
        /// </exception>
        public static int Solution(int[] a)
        {
            // Validate input
            if (a == null || !a.Any())
            {
                throw new ArgumentException("Input is null or empty");
            }

            var length = a.Length;

            if (length > MAX_LENGTH)
            {
                throw new ArgumentOutOfRangeException("a", "N (length of a) is more than 100000");
            }

            try
            {
                var permArray = new int[length + 1];

                for (int i = 0; i < length; i++)
                {
                    // Check item value
                    if (a[i] < MIN_VALUE || MAX_VALUE < a[i])
                    {
                        throw new ArgumentOutOfRangeException("a", "Item (a[i]) value is less than -2147483648 or more than 2147483647");
                    }

                    if (a[i] > 0 && a[i] < length + 1 && permArray[a[i]] == 0)
                    {
                        permArray[a[i]] = 1;
                    }
                }

                for (int j = 1; j < length + 1; j++)
                {
                    if (permArray[j] == 0)
                    {
                        return j;
                    }
                }
            }
            catch (Exception)
            {                
                throw;
            }

            // If all of the number is occur
            return length + 1;
        }
    }
}
