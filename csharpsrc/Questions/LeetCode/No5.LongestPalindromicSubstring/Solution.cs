// <copyright file="Solution.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No5.LongestPalindromicSubstring
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The solution of LeetCode No.5 question: Longest Palindrome Substring.
    /// </summary>
    public class Solution : IQuestion
    {
        /// <inheritdoc />
        public string LongestPalindrome(string s)
        {
            // Step 0: Handles invalid or special cases.
            if (string.IsNullOrWhiteSpace(s) ||
                s.Length == 1 ||
                s.Distinct().Count() == 1 ||
                s.Reverse().SequenceEqual(s))
            {
                return s;
            }

            if (s.Length == 2)
            {
                return s.First().Equals(s.Last()) ? s : s.First().ToString();
            }

            if (s.Distinct().Count() == s.Length)
            {
                return s.First().ToString();
            }

            // Step 1: Handles normal cases.
            var longestPalindromeSubstring = string.Empty;

            for (var index = 0; index < s.Length && s.Length - index > longestPalindromeSubstring.Length; index++)
            {
                var currentChar = s[index];
                var currentCharLastIndex = s.LastIndexOf(currentChar);

                if (index == currentCharLastIndex)
                {
                    if (!string.IsNullOrWhiteSpace(longestPalindromeSubstring) ||
                        longestPalindromeSubstring.Length > 1)
                    {
                        continue;
                    }

                    longestPalindromeSubstring = currentChar.ToString();
                }

                var currentCharIndexes = new Stack<int>();

                for (var nextIndex = index + 1; nextIndex <= currentCharLastIndex; nextIndex++)
                {
                    if (s[nextIndex] == currentChar)
                    {
                        currentCharIndexes.Push(nextIndex);
                    }
                }

                while (currentCharIndexes.Any())
                {
                    var relatedIndex = currentCharIndexes.Pop();
                    var possibleStr = s.Substring(index, relatedIndex - index + 1);
                    var reversedPossibleStr = new string(possibleStr.ToCharArray().Reverse().ToArray());

                    if (!possibleStr.Equals(reversedPossibleStr) ||
                        possibleStr.Length < longestPalindromeSubstring.Length ||
                        possibleStr.Equals(longestPalindromeSubstring))
                    {
                        continue;
                    }

                    longestPalindromeSubstring = possibleStr;
                }
            }

            return longestPalindromeSubstring;
        }
    }
}
