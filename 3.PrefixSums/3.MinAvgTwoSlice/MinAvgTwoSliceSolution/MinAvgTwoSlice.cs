using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinAvgTwoSliceSolution
{
    /*
    A non-empty zero-indexed array A consisting of N integers is given. A pair of integers (P, Q), such that 0 ≤ P < Q < N, is called a slice of array A (notice that the slice contains at least two elements). The average of a slice (P, Q) is the sum of A[P] + A[P + 1] + ... + A[Q] divided by the length of the slice. To be precise, the average equals (A[P] + A[P + 1] + ... + A[Q]) / (Q − P + 1).

    For example, array A such that:

        A[0] = 4
        A[1] = 2
        A[2] = 2
        A[3] = 5
        A[4] = 1
        A[5] = 5
        A[6] = 8

    contains the following example slices:

            slice (1, 2), whose average is (2 + 2) / 2 = 2;
            slice (3, 4), whose average is (5 + 1) / 2 = 3;
            slice (1, 4), whose average is (2 + 2 + 5 + 1) / 4 = 2.5.

    The goal is to find the starting position of a slice whose average is minimal.

    Write a function:

        class Solution { public int solution(int[] A); } 

    that, given a non-empty zero-indexed array A consisting of N integers, returns the starting position of the slice with the minimal average. If there is more than one slice with a minimal average, you should return the smallest starting position of such a slice.

    For example, given array A such that:

        A[0] = 4
        A[1] = 2
        A[2] = 2
        A[3] = 5
        A[4] = 1
        A[5] = 5
        A[6] = 8

    the function should return 1, as explained above.

    Assume that:

            N is an integer within the range [2..100,000];
            each element of array A is an integer within the range [−10,000..10,000].

    Complexity:

            expected worst-case time complexity is O(N);
            expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

    Elements of input arrays can be modified.
    */

    /// <summary>
    /// Session 3 Lesson 3.
    /// </summary>
    public static class MinAvgTwoSlice
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
        public static readonly int MIN_VALUE = -10000;

        /// <summary>
        /// The max value.
        /// </summary>
        public static readonly int MAX_VALUE = 10000;

        /// <summary>
        /// Solutions the specified a.
        /// </summary>
        /// <param name="a">The input array.</param>
        /// <returns>Started point that have minimum average.</returns>
        /// <exception cref="System.ArgumentException">Input is null or empty.</exception>
        /// <exception cref="System.InvalidOperationException">
        /// N (length of a) is less than 2 or more than 100000
        /// or
        /// Item (a[i]) value is less than -1000 or more than 1000
        /// or
        /// Item (a[i]) value is less than -1000 or more than 1000.
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
                throw new InvalidOperationException("N (length of a) is less than 2 or more than 100000");
            }
            
            double minAvg = double.MaxValue;
            var minIndex = 0;

            try
            {
                double avg;

                for (int i = 0; i < length - 2; i++)
                {
                    // Check item value
                    if (a[i] < MIN_VALUE || MAX_VALUE < a[i])
                    {
                        throw new InvalidOperationException("Item (a[i]) value is less than -1000 or more than 1000");
                    }

                    avg = Math.Min((double)(a[i] + a[i + 1]) / 2, (double)(a[i] + a[i + 1] + a[i + 2]) / 3);

                    if (avg < minAvg)
                    {
                        minAvg = avg;
                        minIndex = i;
                    }
                }

                // Check last two item value
                for (int j = length - 2; j < length; j++)
                {
                    // Check item value
                    if (a[j] < MIN_VALUE || MAX_VALUE < a[j])
                    {
                        throw new InvalidOperationException("Item (a[i]) value is less than -1000 or more than 1000");
                    }                    
                }

                // last slice with 2 item
                avg = (double)(a[length - 2] + a[length - 1]) / 2;

                if (avg < minAvg)
                {
                    minAvg = avg;
                    minIndex = length - 2;
                }
            }
            catch (Exception)
            {                
                throw;
            }

            return minIndex;
        }
    }
}
