using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassingCarsSolution
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
    /// Session 3 Lesson 1.
    /// </summary>
    public static class PassingCars
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
        /// The max passing cars.
        /// </summary>
        public static readonly int MAX_PASSING_CAR = 1000000000;

        /// <summary>
        /// Solutions the specified a.
        /// </summary>
        /// <param name="a">The input array.</param>
        /// <returns>Total passing cars.</returns>
        /// <exception cref="System.ArgumentException">Input is null or empty.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">a;N (length of a) is less than 1 or more than 100000.</exception>
        /// <exception cref="System.InvalidOperationException">Item (a[i]) value is less than 0 or more than 1.</exception>
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
                throw new ArgumentOutOfRangeException("a", "N (length of a) is less than 1 or more than 100000");
            }
            
            var result = 0;

            try
            {
                var suffixSums = SuffixSums(a);

                for (int i = 0; i < length; i++)
                {
                    // Check item value
                    if (a[i] < 0 || 1 < a[i])
                    {
                        throw new InvalidOperationException("Item (a[i]) value is less than 0 or more than 1");
                    }

                    if (a[i] == 0)
                    {
                        result += suffixSums[i + 1];

                        // Return -1 if passing cars is exceed 1000000000
                        if (result > MAX_PASSING_CAR)
                        {
                            return -1;
                        }
                    }
                }
            }
            catch (Exception)
            {                
                throw;
            }

            return result;
        }

        /// <summary>
        /// Suffixes the sums.
        /// </summary>
        /// <param name="arr">The input array.</param>
        /// <returns>Array of suffix sum.</returns>
        private static int[] SuffixSums(int[] arr)
        {
            var n = arr.Length;
            var result = new int[n + 2];
            for (int i = n; i > 0; i--)
            {
                result[i] = result[i + 1] + arr[i - 1];
            }

            return result;
        }        
    }
}
