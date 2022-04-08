// <copyright file="OfficialAnswerC.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No5.LongestPalindromicSubstring
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The official answer C of LeetCode No.5 question: Longest Palindromic Substring.
    /// </summary>
    public class OfficialAnswerC : OfficialAnswer
    {
        /// <inheritdoc />
        public override string LongestPalindrome(string s)
        {
            var startIndex = 0;
            var endIndex = -1;
            var strBuilder = new StringBuilder("#");

            foreach (var character in s)
            {
                strBuilder.Append(character);
                strBuilder.Append('#');
            }

            strBuilder.Append('#');
            s = strBuilder.ToString();
            var palindromeLength = new List<int>();
            var rightIndex = -1;
            var leftIndex = -1;

            for (var index = 0; index < s.Length; index++)
            {
                int currentPalindromeLength;

                if (rightIndex > index)
                {
                    var halfIndex = (leftIndex * 2) - index;
                    var minPalindromeLength = Math.Min(palindromeLength.ToArray()[halfIndex], rightIndex - index);
                    currentPalindromeLength = Expand(s, index - minPalindromeLength, index + minPalindromeLength);
                }
                else
                {
                    currentPalindromeLength = Expand(s, index, index);
                }

                palindromeLength.Add(currentPalindromeLength);

                if (index + currentPalindromeLength > rightIndex)
                {
                    leftIndex = index;
                    rightIndex = index + currentPalindromeLength;
                }

                if ((currentPalindromeLength * 2) + 1 <= endIndex - startIndex)
                {
                    continue;
                }

                startIndex = index - currentPalindromeLength;
                endIndex = index + currentPalindromeLength;
            }

            var longestPalindromeBuilder = new StringBuilder();
            for (var index = startIndex; index <= endIndex; index++)
            {
                var currentChar = s[index];
                if (currentChar.Equals('#'))
                {
                    continue;
                }

                longestPalindromeBuilder.Append(currentChar);
            }

            return longestPalindromeBuilder.ToString();
        }

        /// <summary>
        /// Expands the length.
        /// </summary>
        /// <param name="s">The string.</param>
        /// <param name="leftIndex">The left index.</param>
        /// <param name="rightIndex">The right index.</param>
        /// <returns>The length.</returns>
        private static int Expand(string s, int leftIndex, int rightIndex)
        {
            while (leftIndex >= 0 && rightIndex < s.Length && s[leftIndex].Equals(s[rightIndex]))
            {
                leftIndex--;
                rightIndex++;
            }

            return (rightIndex - leftIndex - 2) / 2;
        }
    }
}
