// <copyright file="OfficialAnswer.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No17.LetterCombinationsOfAPhoneNumber
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The official answer of LeetCode No.17 question: Letter Combinations of a Phone Number.
    /// </summary>
    public class OfficialAnswer : IQuestion
    {
        /// <summary>
        /// The digit and letters mapping group.
        /// </summary>
        private readonly Dictionary<char, string[]> digitsAndLettersMappingGroup = new ()
        {
            { '2', ["a", "b", "c"] },
            { '3', ["d", "e", "f"] },
            { '4', ["g", "h", "i"] },
            { '5', ["j", "k", "l"] },
            { '6', ["m", "n", "o"] },
            { '7', ["p", "q", "r", "s"] },
            { '8', ["t", "u", "v"] },
            { '9', ["w", "x", "y", "z"] },
        };

        /// <inheritdoc />
        public IList<string> LetterCombinations(string digits)
        {
            var combinationResults = new List<string>();

            if (string.IsNullOrWhiteSpace(digits))
            {
                return combinationResults;
            }

            this.TrackBack(combinationResults, digits, 0, new StringBuilder());

            return combinationResults;
        }

        /// <summary>
        /// Tracks back to get the combinations.
        /// </summary>
        /// <param name="combinations">The combination results.</param>
        /// <param name="digits">The original digits.</param>
        /// <param name="index">The index.</param>
        /// <param name="resultBuilder">The result builder.</param>
        private void TrackBack(ICollection<string> combinations, string digits, int index, StringBuilder resultBuilder)
        {
            if (index == digits.Length)
            {
                combinations.Add(resultBuilder.ToString());
            }
            else
            {
                var currentDigit = digits[index];
                var letters = this.digitsAndLettersMappingGroup[currentDigit];

                foreach (var letter in letters)
                {
                    resultBuilder.Append(letter);
                    this.TrackBack(combinations, digits, index + 1, resultBuilder);
                    resultBuilder.Remove(index, 1);
                }
            }
        }
    }
}
