// <copyright file="OfficialAnswerB.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No5.LongestPalindromicSubstring
{
    using System;
    using System.Linq;

    /// <summary>
    /// The official answer B of LeetCode No.5 question: Longest Palindromic Substring.
    /// </summary>
    public class OfficialAnswerB : OfficialAnswer
    {
        /// <inheritdoc />
        public override string LongestPalindrome(string s)
        {
            if (string.IsNullOrWhiteSpace(s) || !s.Any())
            {
                return string.Empty;
            }

            var startIndex = 0;
            var endIndex = 0;

            for (var index = 0; index < s.Length; index++)
            {
                var firstLength = ExpandAroundCenter(s, index, index);
                var secondLength = ExpandAroundCenter(s, index, index + 1);
                var longestLength = Math.Max(firstLength, secondLength);

                if (longestLength <= endIndex - startIndex)
                {
                    continue;
                }

                startIndex = index - ((longestLength - 1) / 2);
                endIndex = index + (longestLength / 2);
            }

            return s.Substring(startIndex, endIndex - startIndex + 1);
        }

        /// <summary>
        /// Expands around center to check the palindromic substring.
        /// </summary>
        /// <param name="s">The original string.</param>
        /// <param name="leftIndex">The left index.</param>
        /// <param name="rightIndex">The right index.</param>
        /// <returns>The length of palindromic substring.</returns>
        private static int ExpandAroundCenter(string s, int leftIndex, int rightIndex)
        {
            while (leftIndex >= 0 && rightIndex < s.Length && s[leftIndex] == s[rightIndex])
            {
                --leftIndex;
                ++rightIndex;
            }

            return rightIndex - leftIndex - 1;
        }
    }
}
