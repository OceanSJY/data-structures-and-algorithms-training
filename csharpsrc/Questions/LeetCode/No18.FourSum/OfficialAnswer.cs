// <copyright file="OfficialAnswer.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No18.FourSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The official answer of LeetCode No.18 question: Four Sum.
    /// </summary>
    public class OfficialAnswer : IQuestion
    {
        /// <inheritdoc />
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            var results = new List<IList<int>>();

            if (nums == null || nums.Length < 4)
            {
                return results;
            }

            Array.Sort(nums);

            for (var firstIndex = 0; firstIndex < nums.Length; firstIndex++)
            {
                if (firstIndex > 0 && nums[firstIndex] == nums[firstIndex - 1])
                {
                    continue;
                }

                if ((long)nums[firstIndex] + nums[firstIndex + 1] + nums[firstIndex + 2] + nums[firstIndex + 3] > target)
                {
                    break;
                }

                if ((long)nums[firstIndex] + nums[nums.Length - 3] + nums[nums.Length - 2] + nums.Last() < target)
                {
                    continue;
                }

                for (var secondIndex = firstIndex + 1; secondIndex < nums.Length - 2; secondIndex++)
                {
                    if (secondIndex > firstIndex + 1 && nums[secondIndex] == nums[secondIndex - 1])
                    {
                        continue;
                    }

                    if ((long)nums[firstIndex] + nums[secondIndex] + nums[secondIndex + 1] + nums[secondIndex + 2] >
                        target)
                    {
                        break;
                    }

                    if ((long)nums[firstIndex] + nums[secondIndex] + nums[nums.Length - 2] + nums.Last() < target)
                    {
                        continue;
                    }

                    var leftPointer = secondIndex + 1;
                    var rightPointer = nums.Length - 1;

                    while (leftPointer < rightPointer)
                    {
                        var sum = nums[firstIndex] + nums[secondIndex] + nums[leftPointer] + nums[rightPointer];

                        if (sum == target)
                        {
                            results.Add(new int[]
                            {
                                nums[firstIndex],
                                nums[secondIndex],
                                nums[leftPointer],
                                nums[rightPointer],
                            });

                            while (leftPointer < rightPointer && nums[leftPointer] == nums[leftPointer + 1])
                            {
                                leftPointer++;
                            }

                            leftPointer++;

                            while (leftPointer < rightPointer && nums[rightPointer] == nums[rightPointer - 1])
                            {
                                rightPointer--;
                            }

                            rightPointer--;
                        }
                        else if (sum < target)
                        {
                            leftPointer++;
                        }
                        else
                        {
                            rightPointer--;
                        }
                    }
                }
            }

            return results;
        }
    }
}
