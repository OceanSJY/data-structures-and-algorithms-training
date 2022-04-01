// <copyright file="OfficialAnswerC.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No5.LongestPalindromicSubstring
{
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

                }
            }

            return s;
        }

        /// <summary>
        /// Expands the length.
        /// </summary>
        /// <param name="s">The string.</param>
        /// <param name="leftIndex">The left index.</param>
        /// <param name="rightIndex">The right index.</param>
        /// <returns></returns>
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
