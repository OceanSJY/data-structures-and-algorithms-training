// <copyright file="RandomNumberHelper.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCodeCases.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The random number helper.
    /// </summary>
    internal static class RandomNumberHelper
    {
        /// <summary>
        /// Generate random numbers.
        /// </summary>
        /// <param name="minLength">The min length of random numbers.</param>
        /// <param name="maxLength">The mac length of random numbers.</param>
        /// <param name="minValue">The min value.</param>
        /// <param name="maxValue">The max value.</param>
        /// <param name="random">The random instance.</param>
        /// <returns>The random numbers.</returns>
        public static IEnumerable<int> GenerateNumbers(int minLength, int maxLength, int minValue, int maxValue, Random random = null)
        {
            random ??= new Random();
            var testArray = new int[random.Next(minLength, maxLength)];

            for (var index = 0; index < testArray.Length; index++)
            {
                testArray[index] = random.Next(minValue, maxValue);
            }

            return testArray;
        }
    }
}
