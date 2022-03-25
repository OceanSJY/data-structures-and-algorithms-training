// <copyright file="OfficialAnswer.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No1.TwoSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The official answer of LeetCode No.1 question: Two Sum.
    /// </summary>
    public class OfficialAnswer : IQuestion
    {
        /// <inheritdoc />
        public int[] TwoSum(int[] nums, int target)
        {
            // Step 0: Handles invalid or special cases.
            if (nums == null || !nums.Any())
            {
                return Array.Empty<int>();
            }

            // Step 1: Handles normal cases.
            var numDictionary = new Dictionary<int, int>();

            for (var index = 0; index < nums.Length; index++)
            {
                var currentNumber = nums[index];
                var currentGap = target - currentNumber;

                if (numDictionary.ContainsKey(currentGap))
                {
                    return new[] { index, numDictionary[currentGap] };
                }

                numDictionary.TryAdd(currentNumber, index);
            }

            return Array.Empty<int>();
        }
    }
}
