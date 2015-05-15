using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistinctSolution
{
    /*
    Write a function

        int solution(int A[], int N); 

    that, given a zero-indexed array A consisting of N integers, returns the number of distinct values in array A.

    Assume that:

            N is an integer within the range [0..100,000];
            each element of array A is an integer within the range [−1,000,000..1,000,000].

    For example, given array A consisting of six elements such that:

        A[0] = 2    A[1] = 1    A[2] = 1
        A[3] = 2    A[4] = 3    A[5] = 1

    the function should return 3, because there are 3 distinct values appearing in array A, namely 1, 2 and 3.

    Complexity:

            expected worst-case time complexity is O(N*log(N));
            expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

    Elements of input arrays can be modified.
    */
    public static class Distinct
    {
        /// <summary>
        /// The max length.
        /// </summary>
        public static readonly int MAX_LENGTH = 100000;

        /// <summary>
        /// The min value.
        /// </summary>
        public static readonly int MIN_VALUE = -1000000;

        /// <summary>
        /// The max value.
        /// </summary>
        public static readonly int MAX_VALUE = 1000000;

        public static int Solution(int[] a)
        {
            // validate input
            if (a == null || !a.Any())
            {
                return 0;
            }

            var length = a.Length;

            // Check length
            if (MAX_LENGTH < length)
            {
                throw new ArgumentOutOfRangeException("a", "N (length of a) is more than 100000");
            }

            var result = 1;

            try
            {
                // Sort array
                Array.Sort(a);

                // Check firt item value
                if (a[0] < MIN_VALUE || MAX_VALUE < a[0])
                {
                    throw new InvalidOperationException("Item (a[i]) value is less than -1000000 or more than 1000000");
                }

                // Count distinct
                for (int i = 1; i < length; i++)
                {
                    // Check item value
                    if (a[i] < MIN_VALUE || MAX_VALUE < a[i])
                    {
                        throw new InvalidOperationException("Item (a[i]) value is less than -1000000 or more than 1000000");
                    }

                    if (a[i] != a[i - 1])
                    {
                        result++;
                    }
                }
            }
            catch (Exception)
            {                
                throw;
            }

            return result;
        }
    }
}
