using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxCountersSolution
{
    /*
    You are given N counters, initially set to 0, and you have two possible operations on them:

            increase(X) − counter X is increased by 1,
            max counter − all counters are set to the maximum value of any counter.

    A non-empty zero-indexed array A of M integers is given. This array represents consecutive operations:

            if A[K] = X, such that 1 ≤ X ≤ N, then operation K is increase(X),
            if A[K] = N + 1 then operation K is max counter.

    For example, given integer N = 5 and array A such that:

        A[0] = 3
        A[1] = 4
        A[2] = 4
        A[3] = 6
        A[4] = 1
        A[5] = 4
        A[6] = 4

    the values of the counters after each consecutive operation will be:

        (0, 0, 1, 0, 0)
        (0, 0, 1, 1, 0)
        (0, 0, 1, 2, 0)
        (2, 2, 2, 2, 2)
        (3, 2, 2, 2, 2)
        (3, 2, 2, 3, 2)
        (3, 2, 2, 4, 2)

    The goal is to calculate the value of every counter after all operations.

    Write a function:

        class Solution { public int[] solution(int N, int[] A); } 

    that, given an integer N and a non-empty zero-indexed array A consisting of M integers, returns a sequence of integers representing the values of the counters.

    The sequence should be returned as:

            a structure Results (in C), or
            a vector of integers (in C++), or
            a record Results (in Pascal), or
            an array of integers (in any other programming language).

    For example, given:

        A[0] = 3
        A[1] = 4
        A[2] = 4
        A[3] = 6
        A[4] = 1
        A[5] = 4
        A[6] = 4

    the function should return [3, 2, 2, 4, 2], as explained above.

    Assume that:

            N and M are integers within the range [1..100,000];
            each element of array A is an integer within the range [1..N + 1].

    Complexity:

            expected worst-case time complexity is O(N+M);
            expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

    Elements of input arrays can be modified.
    */

    /// <summary>
    /// Session 2 Lesson 4.
    /// </summary>
    public static class MaxCounters
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
        /// Solutions the specified n.
        /// </summary>
        /// <param name="n">The length of the counter.</param>
        /// <param name="a">The input array.</param>
        /// <returns>Array of the result.</returns>
        /// <exception cref="System.ArgumentException">Input is null or empty.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// a;M (length of a) is less than 1 or more than 100000
        /// or
        /// n;N is less than 1 or more than 100000.
        /// </exception>
        /// <exception cref="System.InvalidOperationException">Item (a[i]) value is less than 1 or more than n + 1.</exception>
        public static int[] Solution(int n, int[] a)
        {
            // validate input
            if (a == null || !a.Any())
            {
                throw new ArgumentException("Input is null or empty");
            }

            // validate input length
            var length = a.Length;
            if (length < MIN_LENGTH || MAX_LENGTH < length)
            {
                throw new ArgumentOutOfRangeException("a", "M (length of a) is less than 1 or more than 100000");
            }

            // validate n
            if (n < MIN_LENGTH || MAX_LENGTH < n)
            {
                throw new ArgumentOutOfRangeException("n", "N is less than 1 or more than 100000");
            }

            var result = new int[n];
            var hasReset = false;
            var max = 0;
            var resetValue = 0;

            try
            {
                for (int i = 0; i < length; i++)
                {
                    // Check item value
                    if (a[i] < MIN_VALUE || n + 1 < a[i])
                    {
                        throw new InvalidOperationException("Item (a[i]) value is less than 1 or more than n + 1");
                    }

                    if (a[i] < n + 1)
                    {
                        // set to max value if has reset
                        if (hasReset && result[a[i] - 1] < resetValue)
                        {
                            result[a[i] - 1] = resetValue;
                        }

                        result[a[i] - 1]++;

                        // set max
                        if (max < result[a[i] - 1])
                        {
                            max = result[a[i] - 1];
                        }
                    }
                    else if (a[i] == n + 1)
                    {
                        hasReset = true;
                        resetValue = max;
                    }
                }

                if (hasReset)
                {
                    // Set skipped item to reset value
                    for (int j = 0; j < n; j++)
                    {
                        // set to max value if has reset
                        if (result[j] < resetValue)
                        {
                            result[j] = resetValue;
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
    }
}
