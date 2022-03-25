// <copyright file="OfficialAnswer.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No15.ThreeSum
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The official answer of LeetCode No.15 question: Three Sum.
    /// </summary>
    public class OfficialAnswer : IQuestion
    {
        /// <inheritdoc />
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var results = new List<IList<int>>();

            // Sorts the array first.
            Array.Sort(nums);

            for (var firstIndex = 0; firstIndex < nums.Length; firstIndex++)
            {
                if (firstIndex > 0 && nums[firstIndex] == nums[firstIndex - 1])
                {
                    continue;
                }

                var thirdIndex = nums.Length - 1;
                var target = -nums[firstIndex];

                for (var secondIndex = firstIndex + 1; secondIndex < nums.Length; secondIndex++)
                {
                    if (secondIndex > firstIndex + 1 && nums[secondIndex] == nums[secondIndex - 1])
                    {
                        continue;
                    }

                    while (secondIndex < thirdIndex && nums[secondIndex] + nums[thirdIndex] > target)
                    {
                        thirdIndex--;
                    }

                    if (secondIndex == thirdIndex)
                    {
                        break;
                    }

                    if (nums[secondIndex] + nums[thirdIndex] != target)
                    {
                        continue;
                    }

                    var result = new List<int>()
                    {
                        nums[firstIndex],
                        nums[secondIndex],
                        nums[thirdIndex],
                    };

                    results.Add(result);
                }
            }

            return results;
        }
    }
}
