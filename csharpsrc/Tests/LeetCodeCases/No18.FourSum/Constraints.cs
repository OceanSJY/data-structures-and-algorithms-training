// <copyright file="Constraints.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCodeCases.No18.FourSum
{
    using System;

    /// <summary>
    /// The constraints of LeetCode No.18 question: Four Sum.
    /// </summary>
    internal static class Constraints
    {
        /// <summary>
        /// The min length of test numbers array.
        /// </summary>
        public const int MinLength = 1;

        /// <summary>
        /// The max length of test numbers array.
        /// </summary>
        public const int MaxLength = 200;

        /// <summary>
        /// The min value of each element in test array or target.
        /// </summary>
        public static readonly int MinValue = -(int)Math.Pow(10, 9);

        /// <summary>
        /// The max value of each element in test array or target.
        /// </summary>
        public static readonly int MaxValue = (int)Math.Pow(10, 9);
    }
}
