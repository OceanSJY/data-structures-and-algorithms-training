// <copyright file="Solution.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No9.PalindromeNumber
{
    using System.Linq;

    /// <summary>
    /// The solution of LeetCode No.9 question: Palindrome Number.
    /// </summary>
    public class Solution : IQuestion
    {
        /// <inheritdoc />
        public bool IsPalindrome(int x)
        {
            // Step 1: Handles special cases.
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }

            // Step 2: Handles normal cases.
            var numStr = x.ToString();

            return numStr.SequenceEqual(numStr.Reverse());
        }
    }
}
