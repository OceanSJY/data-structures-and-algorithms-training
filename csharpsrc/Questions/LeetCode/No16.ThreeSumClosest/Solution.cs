// <copyright file="Solution.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No16.ThreeSumClosest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The solution of LeetCode No.16 question: Three Sum Closest.
    /// </summary>
    public class Solution : IQuestion
    {
        /// <inheritdoc />
        public int ThreeSumClosest(int[] nums, int target)
        {
            // Step 0: Handles invalid cases.
            if (nums == null || nums.Length < 3)
            {
                return 0;
            }

            // Step 1: Handles special case.
            if (nums.Length == 3)
            {
                return nums.Sum();
            }

            // Step 2: Handles normal cases.
            // Step 2.1: Gets all combinations and their sums.
            var allCombinations = this.GetCombinations(nums);
            var allCombinationSums = allCombinations.Select(combination => combination.Sum());

            // Step 2.2: Returns the closest sum.
            return GetClosestSum(allCombinationSums, target);
        }

        /// <summary>
        /// Gets the closest sum value from all sum values.
        /// </summary>
        /// <param name="sumValues">All sum values.</param>
        /// <param name="target">The target.</param>
        /// <returns>The closest sum to target.</returns>
        private static int GetClosestSum(IEnumerable<int> sumValues, int target)
        {
            var gapAndSumDic = new Dictionary<int, int>();

            foreach (var sumValue in sumValues)
            {
                gapAndSumDic.TryAdd(Math.Abs(target - sumValue), sumValue);
            }

            return gapAndSumDic[gapAndSumDic.Min(item => item.Key)];
        }

        /// <summary>
        /// Gets the combinations from original number array.
        /// </summary>
        /// <param name="nums">The number array.</param>
        /// <param name="size">The size of combination, in current question the default value is 3.</param>
        /// <returns>All combinations.</returns>
        private IEnumerable<IEnumerable<int>> GetCombinations(IReadOnlyList<int> nums, int size = 3)
        {
            var results = new List<IList<int>>();

            if (nums == null || !nums.Any() || nums.Count < size)
            {
                return results;
            }

            if (size == 1)
            {
                results.AddRange(nums.Distinct().Select(num => new[] { num }));

                return results;
            }

            for (var index = 0; index < nums.Count; index++)
            {
                var currentNumArray = new[] { nums[index] };
                var restNumsArray = nums.Skip(index + 1).ToArray();
                var restNumCombinations = this.GetCombinations(restNumsArray, size - 1);

                foreach (var restNumCombination in restNumCombinations)
                {
                    var currentNumCombination = currentNumArray.Concat(restNumCombination).ToArray();

                    if (results.Any(result => result.Sum() == currentNumCombination.Sum()))
                    {
                        continue;
                    }

                    results.Add(currentNumCombination);
                }
            }

            return results;
        }
    }
}
