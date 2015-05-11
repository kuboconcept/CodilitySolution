using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenomicRangeQuerySolution
{
    /*
    A DNA sequence can be represented as a string consisting of the letters A, C, G and T, which correspond to the types of successive nucleotides in the sequence. Each nucleotide has an impact factor, which is an integer. Nucleotides of types A, C, G and T have impact factors of 1, 2, 3 and 4, respectively. You are going to answer several queries of the form: What is the minimal impact factor of nucleotides contained in a particular part of the given DNA sequence?

    The DNA sequence is given as a non-empty string S = S[0]S[1]...S[N-1] consisting of N characters. There are M queries, which are given in non-empty arrays P and Q, each consisting of M integers. The K-th query (0 ≤ K < M) requires you to find the minimal impact factor of nucleotides contained in the DNA sequence between positions P[K] and Q[K] (inclusive).

    For example, consider string S = CAGCCTA and arrays P, Q such that:

        P[0] = 2    Q[0] = 4
        P[1] = 5    Q[1] = 5
        P[2] = 0    Q[2] = 6

    The answers to these M = 3 queries are as follows:

            The part of the DNA between positions 2 and 4 contains nucleotides G and C (twice), whose impact factors are 3 and 2 respectively, so the answer is 2.
            The part between positions 5 and 5 contains a single nucleotide T, whose impact factor is 4, so the answer is 4.
            The part between positions 0 and 6 (the whole string) contains all nucleotides, in particular nucleotide A whose impact factor is 1, so the answer is 1.

    Write a function:

        class Solution { public int[] solution(string S, int[] P, int[] Q); } 

    that, given a non-empty zero-indexed string S consisting of N characters and two non-empty zero-indexed arrays P and Q consisting of M integers, returns an array consisting of M integers specifying the consecutive answers to all queries.

    The sequence should be returned as:

            a Results structure (in C), or
            a vector of integers (in C++), or
            a Results record (in Pascal), or
            an array of integers (in any other programming language).

    For example, given the string S = CAGCCTA and arrays P, Q such that:

        P[0] = 2    Q[0] = 4
        P[1] = 5    Q[1] = 5
        P[2] = 0    Q[2] = 6

    the function should return the values [2, 4, 1], as explained above.

    Assume that:

            N is an integer within the range [1..100,000];
            M is an integer within the range [1..50,000];
            each element of arrays P, Q is an integer within the range [0..N − 1];
            P[K] ≤ Q[K], where 0 ≤ K < M;
            string S consists only of upper-case English letters A, C, G, T.

    Complexity:

            expected worst-case time complexity is O(N+M);
            expected worst-case space complexity is O(N), beyond input storage (not counting the storage required for input arguments).

    Elements of input arrays can be modified.
    */

    /// <summary>
    /// Session 3 Lesson 4.
    /// </summary>
    public class GenomicRangeQuery
    {
        /// <summary>
        /// The max length.
        /// </summary>
        public static readonly int MAX_N_LENGTH = 100000;

        /// <summary>
        /// The max length.
        /// </summary>
        public static readonly int MAX_M_LENGTH = 50000;

        /// <summary>
        /// The min value.
        /// </summary>
        public static readonly int MIN_VALUE = 0;

        /// <summary>
        /// The nucleotid constant.
        /// </summary>
        public static readonly string NUCLEOTID = "ACGT";

        /// <summary>
        /// Solutions the specified s.
        /// </summary>
        /// <param name="s">The string input.</param>
        /// <param name="p">The starting point array.</param>
        /// <param name="q">The end point array.</param>
        /// <returns>Array of result.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Input is invalid.</exception>
        /// <exception cref="System.InvalidOperationException">One of string value is not A, C, G, or T.
        /// or
        /// Item value is less than 0 or more than N.</exception>
        public static int[] Solution(string s, int[] p, int[] q)
        {
            var n = s.Length;
            var m = p.Length;

            // Check input
            if (n < 1 || n > MAX_N_LENGTH
                || p.Length < 1 || p.Length > MAX_M_LENGTH
                || q.Length < 1 || q.Length > MAX_M_LENGTH
                || p.Length != q.Length)
            {
                throw new ArgumentOutOfRangeException("Input is invalid");
            }

            var prefixSum = new int[n + 1, 4];

            for (var i = 0; i < n; i++)
            {
                // Check s item
                if (!NUCLEOTID.Contains(s[i]))
                {
                    throw new InvalidOperationException("One of string value is not A, C, G, or T.");                    
                }

                // Prefix Sums should start at 0 index = 0 and length + 1 with the total values
                if (i > 0)
                {
                    // Skip adding the first row at index 0 which contains only zeros
                    for (var index = 0; index < 4; index++)
                    {
                        prefixSum[i + 1, index] += prefixSum[i, index];
                    }
                }

                switch (s[i])
                {
                    case 'A':
                        prefixSum[i + 1, 0]++;
                        break;
                    case 'C':
                        prefixSum[i + 1, 1]++;
                        break;
                    case 'G':
                        prefixSum[i + 1, 2]++;
                        break;
                    case 'T':
                        prefixSum[i + 1, 3]++;
                        break;
                }
            }

            var result = new int[p.Length];
            for (var j = 0; j < p.Length; j++)
            {
                // Check item value
                if (p[j] < MIN_VALUE || n < p[j]
                    || q[j] < MIN_VALUE || n < q[j]
                    || p[j] > q[j])
                {
                    throw new InvalidOperationException("Item value is less than 0 or more than N");
                }

                if (p[j] == q[j])
                {
                    switch (s[p[j]])
                    {
                        case 'A':
                            result[j] = 1;
                            break;
                        case 'C':
                            result[j] = 2;
                            break;
                        case 'G':
                            result[j] = 3;
                            break;
                        case 'T':
                            result[j] = 4;
                            break;
                    }
                }
                else
                {
                    for (var index = 0; index < 4; index++)
                    {
                        if ((prefixSum[q[j] + 1, index] - prefixSum[p[j], index]) > 0)
                        {
                            result[j] = index + 1;
                            break;
                        }
                    }
                }
            }

            return result;
        }
    }
}
