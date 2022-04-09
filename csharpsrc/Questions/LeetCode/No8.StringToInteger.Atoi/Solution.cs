// <copyright file="Solution.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No8.StringToInteger.Atoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The solution of LeetCode No.8 question: String to Integer (atoi).
    /// </summary>
    public class Solution : IQuestion
    {
        /// <summary>
        /// The valid number characters.
        /// </summary>
        private readonly char[] validNumberCharacters = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

        /// <summary>
        /// The valid symbol characters.
        /// </summary>
        private readonly char[] validSymbolCharacters = new char[] { '+', '-' };

        /// <inheritdoc />
        public int MyAtoi(string s)
        {
            // Step 0: Handles invalid string
            if (string.IsNullOrWhiteSpace(s) ||
                s.IndexOfAny(this.validNumberCharacters) == -1)
            {
                return 0;
            }

            var cleanedUpStr = s.TrimStart();
            var firstSymbolIndex = cleanedUpStr.IndexOfAny(this.validSymbolCharacters);
            var lastSymbolIndex = cleanedUpStr.LastIndexOfAny(this.validSymbolCharacters);
            var firstNumberIndex = cleanedUpStr.IndexOfAny(this.validNumberCharacters);
            var lastNumberIndex = cleanedUpStr.LastIndexOfAny(this.validNumberCharacters);

            if (firstSymbolIndex != 0 && firstNumberIndex != 0)
            {
                return 0;
            }

            var firstIndex = 0;
            var lastIndex = 0;

            if (firstSymbolIndex == -1)
            {
                firstIndex = firstNumberIndex;
                lastIndex = lastNumberIndex;
            }
            else if (firstSymbolIndex > firstNumberIndex)
            {
                firstIndex = firstNumberIndex;
                lastIndex = firstSymbolIndex;
            }
            else if (firstNumberIndex - firstSymbolIndex == 1)
            {
                firstIndex = firstSymbolIndex;
                lastIndex = lastSymbolIndex == firstSymbolIndex
                    ? lastNumberIndex
                    : Math.Min(lastSymbolIndex, lastNumberIndex);
            }
            else
            {
                return 0;
            }

            var possibleStr = cleanedUpStr.Substring(firstIndex, lastIndex - firstIndex + 1);
            var numberCharacters = new List<char>();
            var index = 0;
            char? symbolCharacter = null;

            if (possibleStr.StartsWith('-') || possibleStr.StartsWith('+'))
            {
                symbolCharacter = possibleStr.StartsWith('-') ? '-' : null;
                index = 1;
            }

            for (; index < possibleStr.Length; index++)
            {
                if (!this.validNumberCharacters.Contains(possibleStr[index]))
                {
                    break;
                }

                if ('0'.Equals(possibleStr[index]) && !numberCharacters.Any())
                {
                    continue;
                }

                numberCharacters.Add(possibleStr[index]);
            }

            if (numberCharacters.Count > int.MaxValue.ToString().Length)
            {
                return symbolCharacter.HasValue ? int.MinValue : int.MaxValue;
            }

            var numberStr = new string(numberCharacters.ToArray());
            numberStr = symbolCharacter.HasValue ? $"-{numberStr}" : numberStr;

            if (int.TryParse(numberStr, out var number))
            {
                return number;
            }

            if (long.TryParse(numberStr, out var bigNumber))
            {
                return symbolCharacter.HasValue ? int.MinValue : int.MaxValue;
            }

            return 0;
        }
    }
}
