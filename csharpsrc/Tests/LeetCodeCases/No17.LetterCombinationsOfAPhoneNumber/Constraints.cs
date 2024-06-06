// <copyright file="Constraints.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCodeCases.No17.LetterCombinationsOfAPhoneNumber
{
    /// <summary>
    /// The constrains of LeetCode No.17 question: Letter Combinations of a Phone Number.
    /// </summary>
    internal class Constraints
    {
        /// <summary>
        /// The min length of digits string.
        /// </summary>
        public const int MinLength = 0;

        /// <summary>
        /// The max length of digits string.
        /// </summary>
        public const int MaxLength = 4;

        /// <summary>
        /// The valid phone numbers.
        /// </summary>
        public static readonly char[] ValidPhoneNumbers =
        [
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        ];
    }
}
