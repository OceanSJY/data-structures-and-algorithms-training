// <copyright file="SolutionA.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No4.MedianOfTwoSortedArrays
{
    using System;
    using System.Linq;

    /// <summary>
    /// The solution A of LeetCode No.4 question: Median of Two Sorted Arrays.
    /// </summary>
    public class SolutionA : Solution
    {
        /// <inheritdoc />
        public override double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (TryFindMedian(nums1, nums2, out var medianValue))
            {
                return medianValue;
            }

            var mergedSortedArray = nums1.Concat(nums2).ToArray();
            Array.Sort(mergedSortedArray);

            return CalculateMedian(mergedSortedArray);
        }
    }
}
