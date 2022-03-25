// <copyright file="OfficialAnswer.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No16.ThreeSumClosest
{
    using System;
    using System.Linq;

    /// <summary>
    /// The official answer of LeetCode No.16 question: Three Sum Closest.
    /// </summary>
    public class OfficialAnswer : IQuestion
    {
        /// <inheritdoc />
        public int ThreeSumClosest(int[] nums, int target)
        {
            // Step 0: Handles invalid cases.
            if (nums == null || nums.Length < 3)
            {
                return 0;
            }

            // Step 1: Handles special cases.
            if (nums.Length == 3)
            {
                return nums.Sum();
            }

            // Step 2: Handles normal cases.
            var closestResult = 10000000;
            Array.Sort(nums);

            for (var index = 0; index < nums.Length; index++)
            {
                if (index > 0 && nums[index] == nums[index - 1])
                {
                    continue;
                }

                var leftPointer = index + 1;
                var rightPointer = nums.Length - 1;

                while (leftPointer < rightPointer)
                {
                    var sum = nums[index] + nums[leftPointer] + nums[rightPointer];

                    if (sum == target)
                    {
                        return sum;
                    }

                    if (Math.Abs(sum - target) < Math.Abs(closestResult - target))
                    {
                        closestResult = sum;
                    }

                    if (sum > target)
                    {
                        var prevRightPointer = rightPointer - 1;

                        while (leftPointer < prevRightPointer && nums[prevRightPointer] == nums[rightPointer])
                        {
                            prevRightPointer--;
                        }

                        rightPointer = prevRightPointer;
                    }
                    else
                    {
                        var nextLeftPointer = leftPointer + 1;

                        while (nextLeftPointer < rightPointer && nums[nextLeftPointer] == nums[leftPointer])
                        {
                            nextLeftPointer++;
                        }

                        leftPointer = nextLeftPointer;
                    }
                }
            }

            return closestResult;
        }
    }
}
