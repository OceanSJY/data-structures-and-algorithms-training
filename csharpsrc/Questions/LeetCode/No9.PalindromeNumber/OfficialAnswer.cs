// <copyright file="OfficialAnswer.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No9.PalindromeNumber
{
    /// <summary>
    /// The official answer of LeetCode No.9 question: Palindrome Number.
    /// </summary>
    public class OfficialAnswer : IQuestion
    {
        /// <inheritdoc />
        public bool IsPalindrome(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }

            var revertedNumber = 0;
            while (x > revertedNumber)
            {
                revertedNumber = (revertedNumber * 10) + (x % 10);
                x /= 10;
            }

            return x == revertedNumber || x == revertedNumber / 10;
        }
    }
}
