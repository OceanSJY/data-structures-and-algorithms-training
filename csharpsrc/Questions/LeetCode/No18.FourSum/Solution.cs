// <copyright file="Solution.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No18.FourSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The solution of LeetCode No.18 question: Four Sum.
    /// </summary>
    public class Solution : IQuestion
    {
        /// <inheritdoc />
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            // Step 0: Handles invalid cases.
            if (nums == null || nums.Length < 4)
            {
                return new List<IList<int>>();
            }

            // Step 1: Handles special case.
            if (nums.Length == 4)
            {
                return TrySum(nums, out var sumResult) && sumResult == target
                    ? new List<IList<int>> { nums }
                    : new List<IList<int>>();
            }

            // Step 2: Handles normal cases.
            return this.GetCombinations(nums, 4, target);
        }

        /// <summary>
        /// Tries to calculate the sum value of a number array.
        /// </summary>
        /// <param name="nums">The number array.</param>
        /// <param name="sumResult">The sum result.</param>
        /// <returns>True of false which indicates whether the sum calculation is succeed.</returns>
        private static bool TrySum(IEnumerable<int> nums, out int sumResult)
        {
            sumResult = 0;

            try
            {
                sumResult = nums.Sum();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the combinations which meet the requirements.
        /// </summary>
        /// <param name="nums">The number array.</param>
        /// <param name="size">The size of combination.</param>
        /// <param name="target">The target of the combination.</param>
        /// <returns>All unique combinations which meet the requirement.</returns>
        private IList<IList<int>> GetCombinations(IReadOnlyList<int> nums, int size, int? target = null)
        {
            var results = new List<IList<int>>();

            if (nums == null || !nums.Any() || nums.Count < size)
            {
                return results;
            }

            if (size == 1)
            {
                results.AddRange(target.HasValue
                    ? nums.Where(num => num == target.Value).Select(num => new[] { num })
                    : nums.Select(num => new[] { num }));

                return results;
            }

            for (var index = 0; index < nums.Count; index++)
            {
                var currentNumArray = new int[] { nums[index] };
                var restNumsArray = nums.Skip(index + 1).ToArray();
                var restNumCombinations = this.GetCombinations(restNumsArray, size - 1, target - nums[index]);

                foreach (var restNumCombination in restNumCombinations)
                {
                    var currentNumCombination = currentNumArray.Concat(restNumCombination).ToArray();

                    if (target.HasValue && (!TrySum(currentNumCombination, out var sumResult) || sumResult != target))
                    {
                        continue;
                    }

                    if (currentNumCombination.Length == 4)
                    {
                        Array.Sort(currentNumCombination);

                        if (results.Any(combination => combination.SequenceEqual(currentNumCombination)))
                        {
                            continue;
                        }
                    }

                    results.Add(currentNumCombination);
                }
            }

            return results;
        }
    }
}
