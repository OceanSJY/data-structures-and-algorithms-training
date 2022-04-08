// <copyright file="Constraints.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCodeCases.No20.ValidParentheses
{
    /// <summary>
    /// The constraints of LeetCode No.20 question: Valid Parentheses.
    /// </summary>
    internal class Constraints
    {
        /// <summary>
        /// The min length of test string.
        /// </summary>
        public const int MinLength = 1;

        /// <summary>
        /// The max length of test string.
        /// </summary>
        public const int MaxLength = 10000;

        /// <summary>
        /// The parentheses.
        /// </summary>
        public static readonly char[] Parentheses = new[] { '[', ']', '(', ')', '{', '}' };
    }
}
