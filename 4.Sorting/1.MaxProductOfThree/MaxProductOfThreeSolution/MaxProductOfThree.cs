using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxProductOfThreeSolution
{
    /*
    A non-empty zero-indexed array A consisting of N integers is given. The product of triplet (P, Q, R) equates to A[P] * A[Q] * A[R] (0 ≤ P < Q < R < N).

    For example, array A such that:

        A[0] = -3
        A[1] = 1
        A[2] = 2
        A[3] = -2
        A[4] = 5
        A[5] = 6

    contains the following example triplets:

            (0, 1, 2), product is −3 * 1 * 2 = −6
            (1, 2, 4), product is 1 * 2 * 5 = 10
            (2, 4, 5), product is 2 * 5 * 6 = 60

    Your goal is to find the maximal product of any triplet.

    Write a function:

        class Solution { public int solution(int[] A); } 

    that, given a non-empty zero-indexed array A, returns the value of the maximal product of any triplet.

    For example, given array A such that:

        A[0] = -3
        A[1] = 1
        A[2] = 2
        A[3] = -2
        A[4] = 5
        A[5] = 6

    the function should return 60, as the product of triplet (2, 4, 5) is maximal.

    Assume that:

            N is an integer within the range [3..100,000];
            each element of array A is an integer within the range [−1,000..1,000].

    Complexity:

            expected worst-case time complexity is O(N*log(N));
            expected worst-case space complexity is O(1), beyond input storage (not counting the storage required for input arguments).

    Elements of input arrays can be modified.
    */

    public static class MaxProductOfThree
    {
        /// <summary>
        /// The min length.
        /// </summary>
        public static readonly int MIN_LENGTH = 3;

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

        public static int Solution(int[] a)
        {
            // validate input
            if (a == null || !a.Any())
            {
                throw new ArgumentException("Input is null or empty");
            }

            var length = a.Length;
            var result = 0;

            // Check length
            if (length < MIN_LENGTH || MAX_LENGTH < length)
            {
                throw new ArgumentOutOfRangeException("a", "N (length of a) is less than 2 or more than 100000");
            }

            try
            {
                // Sorted input array
                Array.Sort(a);

                result = a[length - 1] * a[length - 2] * a[length - 3];

                if (a[0] < 0 && a[1] < 0)
                {
                    result = Math.Max(result, a[length - 1] * a[0] * a[1]);
                }
            }
            catch (Exception)
            {                
                throw;
            }
            
            // Return the maximal product of any triplet
            return result;
        }
    }
}
