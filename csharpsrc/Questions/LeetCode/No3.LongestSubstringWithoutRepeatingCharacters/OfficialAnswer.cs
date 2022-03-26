// <copyright file="OfficialAnswer.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No3.LongestSubstringWithoutRepeatingCharacters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The official answer of LeetCode No.3 question: Longest Substring without Repeating characters.
    /// </summary>
    public class OfficialAnswer : IQuestion
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

            // Step 2: Handles normal cases.
            var longestLength = 0;
            var charSet = new HashSet<char>();
            var rightPointer = -1;

            for (var index = 0; index < s.Length; index++)
            {
                if (index != 0)
                {
                    charSet.Remove(s[index - 1]);
                }

                while (rightPointer + 1 < s.Length && !charSet.Contains(s[rightPointer + 1]))
                {
                    charSet.Add(s[rightPointer + 1]);
                    rightPointer++;
                }

                longestLength = Math.Max(longestLength, rightPointer - index + 1);
            }

            return longestLength;
        }
    }
}
