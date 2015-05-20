using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleSolution
{
    /*
    A zero-indexed array A consisting of N integers is given. A triplet (P, Q, R) is triangular if 0 ≤ P < Q < R < N and:

            A[P] + A[Q] > A[R],
            A[Q] + A[R] > A[P],
            A[R] + A[P] > A[Q].

    For example, consider array A such that:

      A[0] = 10    A[1] = 2    A[2] = 5
      A[3] = 1     A[4] = 8    A[5] = 20

    Triplet (0, 2, 4) is triangular.

    Write a function:

        int solution(int A[], int N); 

    that, given a zero-indexed array A consisting of N integers, returns 1 if there exists a triangular triplet for this array and returns 0 otherwise.

    For example, given array A such that:

      A[0] = 10    A[1] = 2    A[2] = 5
      A[3] = 1     A[4] = 8    A[5] = 20

    the function should return 1, as explained above. Given array A such that:

      A[0] = 10    A[1] = 50    A[2] = 5
      A[3] = 1

    the function should return 0.

    Assume that:

            N is an integer within the range [0..100,000];
            each element of array A is an integer within the range [−2,147,483,648..2,147,483,647].

    Complexity:

            expected worst-case time complexity is O(N*log(N));
            expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

    Elements of input arrays can be modified.
    */


    public class Triangle
    {
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

            try
            {
                // Sort
                Array.Sort(a);

                // Get sum array value
                for (int i = 0; i < length - 2; i++)
                {
                    // Check item value
                    if (a[i] < MIN_VALUE || MAX_VALUE < a[i])
                    {
                        throw new InvalidOperationException("Item (a[i]) value is less than -2147483648 or more than 2147483647");
                    }

                    if (a[i] > a[i + 2] - a[i + 1])
                    {
                        return 1;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            // Return 0 if triangular is not find
            return 0;
        }
    }
}
