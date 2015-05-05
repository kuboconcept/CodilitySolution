using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: CLSCompliant(true)]

namespace FrogJmpSolution
{
    /*
    A small frog wants to get to the other side of the road. The frog is 
    currently located at position X and wants to get to a position greater 
    than or equal to Y. The small frog always jumps a fixed distance, D.

    Count the minimal number of jumps that the small frog must perform 
    to reach its target.

    Write a function:

        int solution(int X, int Y, int D); 

    that, given three integers X, Y and D, returns the minimal number of jumps from position X to a position equal to or greater than Y.

    For example, given:

      X = 10
      Y = 85
      D = 30

    the function should return 3, because the frog will be positioned as follows:

            after the first jump, at position 10 + 30 = 40
            after the second jump, at position 10 + 30 + 30 = 70
            after the third jump, at position 10 + 30 + 30 + 30 = 100

    Assume that:

            X, Y and D are integers within the range [1..1,000,000,000];
            X ≤ Y.

    Complexity:

            expected worst-case time complexity is O(1);
            expected worst-case space complexity is O(1).
    */

    /// <summary>
    /// Section 1 Lesson 1 Frog Jump.
    /// </summary>
    public static class FrogJmp
    {
        /// <summary>
        /// The min value.
        /// </summary>
        public static readonly int MIN_VAL = 1;

        /// <summary>
        /// The max value.
        /// </summary>
        public static readonly int MAX_VAL = 1000000000;

        /// <summary>
        /// Solutions the specified x.
        /// </summary>
        /// <param name="x">The start point.</param>
        /// <param name="y">The end point.</param>
        /// <param name="d">The distance of every step.</param>
        /// <returns>The total step count.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">X or Y or D;X or Y or D is outside range 1-1000000000.</exception>
        /// <exception cref="System.InvalidOperationException">X is greater than Y.</exception>
        public static int Solution(int x, int y, int d)
        {
            int result = 0;

            try
            {
                // Check input range
                if (x < MIN_VAL || y < MIN_VAL || d < MIN_VAL ||
                    x > MAX_VAL || y > MAX_VAL || d > MAX_VAL)
                {
                    throw new ArgumentOutOfRangeException("x", "X or Y or D is outside range 1-1000000000");
                }

                // Check input validity
                if (x > y)
                {
                    throw new InvalidOperationException("X is greater than Y");
                }

                // Solution
                result = (int)Math.Ceiling((decimal)(y - x) / d);
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}