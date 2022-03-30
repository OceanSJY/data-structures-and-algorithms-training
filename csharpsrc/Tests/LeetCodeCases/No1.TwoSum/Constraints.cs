// <copyright file="Constraints.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCodeCases.No1.TwoSum
{
    using System;

    /// <summary>
    /// The constraints of LeetCode No.1 question: Two Sum.
    /// </summary>
    internal static class Constraints
    {
        /// <summary>
        /// The min length of test array.
        /// </summary>
        public const int MinLength = 2;

        /// <summary>
        /// The max length of test array.
        /// </summary>
        public const int MaxLength = 104;

        /// <summary>
        /// The min value of each element in test array or test target.
        /// </summary>
        public static readonly int MinValue = (int)Math.Pow(-10, 9);

        /// <summary>
        /// The max value of each element in test array or test target.
        /// </summary>
        public static readonly int MaxValue = (int)Math.Pow(10, 9);
    }
}
