// <copyright file="Solution.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No15.ThreeSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The solution of LeetCode No.15 question: Three Sum.
    /// </summary>
    public class Solution : IQuestion
    {
        /// <inheritdoc />
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            // Step 0: Handles invalid cases:
            if (nums == null || nums.Length < 3)
            {
                return new List<IList<int>>();
            }

            // Step 1: Handles normal cases or special cases:
            return nums.Any(num => num != 0) ? this.GetCombinations(nums) : new List<IList<int>> { new[] { 0, 0, 0 } };
        }

        /// <summary>
        /// Gets all combinations which meet the requirements.
        /// </summary>
        /// <param name="nums">The number array.</param>
        /// <param name="size">The size of each combination, the default value is 3.</param>
        /// <returns>All combinations.</returns>
        private IList<IList<int>> GetCombinations(IReadOnlyList<int> nums, int size = 3)
        {
            var results = new List<IList<int>>();

            if (nums == null || !nums.Any() || nums.Count < size)
            {
                return results;
            }

            if (size == 1)
            {
                results.AddRange(nums.Select(num => new[] { num }));

                return results;
            }

            for (var index = 0; index < nums.Count; index++)
            {
                var currentNumArray = new[] { nums[index] };
                var restNumsArray = nums.Skip(index + 1).ToArray();
                var restNumCombinations = this.GetCombinations(restNumsArray, size - 1);

                foreach (var restNumCombination in restNumCombinations)
                {
                    var currentNumberCombination = currentNumArray.Concat(restNumCombination).ToArray();

                    if (currentNumberCombination.Length == 3)
                    {
                        if (currentNumberCombination.Sum() != 0)
                        {
                            continue;
                        }

                        Array.Sort(currentNumberCombination);

                        if (results.Any(combination => combination.SequenceEqual(currentNumberCombination)))
                        {
                            continue;
                        }
                    }

                    results.Add(currentNumberCombination);
                }
            }

            return results;
        }
    }
}
