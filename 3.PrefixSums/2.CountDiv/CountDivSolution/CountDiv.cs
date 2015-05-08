using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountDivSolution
{
    /*
    Write a function:

        class Solution { public int solution(int A, int B, int K); } 

    that, given three integers A, B and K, returns the number of integers within the range [A..B] that are divisible by K, i.e.:

        { i : A ≤ i ≤ B, i mod K = 0 }

    For example, for A = 6, B = 11 and K = 2, your function should return 3, because there are three numbers divisible by 2 within the range [6..11], namely 6, 8 and 10.

    Assume that:

            A and B are integers within the range [0..2,000,000,000];
            K is an integer within the range [1..2,000,000,000];
            A ≤ B.

    Complexity:

            expected worst-case time complexity is O(1);
            expected worst-case space complexity is O(1).

    */

    /// <summary>
    /// Session 3 Lesson 1.
    /// </summary>
    public static class CountDiv
    {
        /// <summary>
        /// The min value for a and b.
        /// </summary>
        public static readonly int MIN_VALUE_ITEM = 0;

        /// <summary>
        /// The min value for k.
        /// </summary>
        public static readonly int MIN_VALUE_DIV = 2;

        /// <summary>
        /// The max value.
        /// </summary>
        public static readonly int MAX_VALUE = 2000000000;

        /// <summary>
        /// Solutions the specified a.
        /// </summary>
        /// <param name="a">The starting point.</param>
        /// <param name="b">The end point.</param>
        /// <param name="k">The devider number.</param>
        /// <returns>Total count number that devisible by K in range [a..b].</returns>
        /// <exception cref="System.InvalidOperationException">A or B or K is out of range.</exception>
        public static int Solution(int a, int b, int k)
        {
            // validate input
            if (a < MIN_VALUE_ITEM || MAX_VALUE < a
                || b < MIN_VALUE_ITEM || MAX_VALUE < b
                || k < MIN_VALUE_DIV || MAX_VALUE < k)
            {
                throw new InvalidOperationException("A or B or K is out of range");
            }

            try
            {
                int closestNumber = (int)(Math.Ceiling((double)a / k) * k);

                if (closestNumber <= b)
                {
                    return ((b - closestNumber) / k) + 1;
                }
            }
            catch (Exception)
            {                
                throw;
            }

            return 0;
        }
    }
}
