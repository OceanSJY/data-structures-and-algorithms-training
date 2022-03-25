// <copyright file="Constraints.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCode.No15
{
    using System;

    /// <summary>
    /// The constraints of LeetCode No.15 question: Three Sum.
    /// </summary>
    public static class Constraints
    {
        /// <summary>
        /// The min length of test array.
        /// </summary>
        public const int MinLength = 1;

        /// <summary>
        /// The max length of test array.
        /// </summary>
        public const int MaxLength = 1000;

        /// <summary>
        /// The max value of each element in test array.
        /// </summary>
        public static readonly int MinValue = -(int)Math.Pow(10, 5);

        /// <summary>
        /// The min value of each element in test array.
        /// </summary>
        public static readonly int MaxValue = (int)Math.Pow(10, 5);
    }
}
