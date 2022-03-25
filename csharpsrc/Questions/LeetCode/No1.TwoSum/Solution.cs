// <copyright file="Solution.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No1.TwoSum
{
    using System;
    using System.Linq;

    /// <summary>
    /// The solution of LeetCode No.1 question: Two Sum.
    /// </summary>
    public class Solution : IQuestion
    {
        /// <inheritdoc />
        public int[] TwoSum(int[] nums, int target)
        {
            // Step 0: Handles the special or invalid cases.
            if (nums == null || !nums.Any())
            {
                return Array.Empty<int>();
            }

            // Step 1: Handles the normal cases.
            for (var index = 0; index < nums.Length; index++)
            {
                var gap = target - nums[index];

                for (var subIndex = index + 1; subIndex < nums.Length; subIndex++)
                {
                    if (gap != nums[subIndex])
                    {
                        continue;
                    }

                    return new[] { index, subIndex };
                }
            }

            return Array.Empty<int>();
        }
    }
}
