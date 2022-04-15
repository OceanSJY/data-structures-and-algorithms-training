// <copyright file="Solution.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No17.LetterCombinationsOfAPhoneNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The solution of LeetCode No.17 question: Letter Combinations of A Phone Number.
    /// </summary>
    public class Solution : IQuestion
    {
        /// <summary>
        /// The digit and letters mapping group.
        /// </summary>
        private readonly Dictionary<string, string[]> digitsAndLettersMappingGroup = new ()
        {
            { "2", new[] { "a", "b", "c" } },
            { "3", new[] { "d", "e", "f" } },
            { "4", new[] { "g", "h", "i" } },
            { "5", new[] { "j", "k", "l" } },
            { "6", new[] { "m", "n", "o" } },
            { "7", new[] { "p", "q", "r", "s" } },
            { "8", new[] { "t", "u", "v" } },
            { "9", new[] { "w", "x", "y", "z" } },
        };

        /// <inheritdoc />
        public IList<string> LetterCombinations(string digits)
        {
            // Step 0: Handles the invalid digits.
            if (string.IsNullOrWhiteSpace(digits))
            {
                return new List<string>();
            }

            if (digits.Length is <= 0 or > 4)
            {
                throw new ArgumentOutOfRangeException($"The length of {nameof(digits)} is {digits.Length} which is invalid, the valid length should be 1 ~ 4.");
            }

            if (digits.Any(digit => !this.digitsAndLettersMappingGroup.ContainsKey(digit.ToString())))
            {
                throw new ArgumentException($"The {nameof(digits)} contains invalid character(s).");
            }

            // Step 1: Handles the special digits.
            if (digits.Length == 1)
            {
                return this.digitsAndLettersMappingGroup[digits];
            }

            // Step 2: Combines all letters.
            var result = new List<string>();
            var letterGroups = digits.Select(digit => this.digitsAndLettersMappingGroup[digit.ToString()]).Cast<IList<string>>().ToList();
            result = letterGroups.Aggregate(result, CombineLetters);

            return result.Distinct().ToList();
        }

        /// <summary>
        /// Combines the letters from 2 letter groups.
        /// </summary>
        /// <param name="firstLetterGroup">The first letter group.</param>
        /// <param name="secondLetterGroup">The second letter group</param>
        /// <returns>The combined letter group.</returns>
        private static List<string> CombineLetters(IList<string> firstLetterGroup, IList<string> secondLetterGroup)
        {
            if (!firstLetterGroup.Any() && secondLetterGroup.Any())
            {
                return secondLetterGroup.ToList();
            }

            if (!secondLetterGroup.Any() && firstLetterGroup.Any())
            {
                return firstLetterGroup.ToList();
            }

            var result = new List<string>();

            if (!firstLetterGroup.Any() && !secondLetterGroup.Any())
            {
                return result;
            }

            foreach (var firstCharacter in firstLetterGroup)
            {
                foreach (var secondCharacter in secondLetterGroup)
                {
                    var stringBuilder = new StringBuilder();
                    stringBuilder.Append(firstCharacter);
                    stringBuilder.Append(secondCharacter);

                    result.Add(stringBuilder.ToString());
                }
            }

            return result;
        }
    }
}
