// <copyright file="Solution.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No3.LongestSubstringWithoutRepeatingCharacters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The solution of LeetCode No.3 question: Longest Substring without Repeating Characters.
    /// </summary>
    public class Solution : IQuestion
    {
        /// <inheritdoc />
        public int LengthOfLongestSubstring(string s)
        {
            // Step 0: Handles invalid case.
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            // Step 1: Handles special cases.
            if (s.Length == 1 || s.Distinct().Count() == 1)
            {
                return 1;
            }

            if (s.Distinct().Count() == s.Length)
            {
                return s.Length;
            }

            // Step 2: Handles normal case.
            var longestLength = 0;

            for (var index = 0; index < s.Length; index++)
            {
                var uniqueCharList = new List<char>() { s[index] };

                for (var nextIndex = index + 1; nextIndex < s.Length; nextIndex++)
                {
                    if (uniqueCharList.Contains(s[nextIndex]))
                    {
                        break;
                    }

                    uniqueCharList.Add(s[nextIndex]);
                }

                longestLength = Math.Max(uniqueCharList.Count, longestLength);
            }

            return longestLength;
        }
    }
}
