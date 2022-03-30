// <copyright file="Solution.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No4.MedianOfTwoSortedArrays
{
    using System;
    using System.Linq;

    /// <summary>
    /// The base solution of LeetCode No.4 question: Media of Two Sorted Arrays.
    /// </summary>
    public abstract class Solution : IQuestion
    {
        /// <inheritdoc />
        public abstract double FindMedianSortedArrays(int[] nums1, int[] nums2);

        /// <summary>
        /// Tries to find median of 2 sorted arrays..
        /// </summary>
        /// <param name="nums1">The first sorted array.</param>
        /// <param name="nums2">The second sorted array.</param>
        /// <param name="medianValue">The median value.</param>
        /// <returns>True means succeed to find the median.</returns>
        protected static bool TryFindMedian(int[] nums1, int[] nums2, out double medianValue)
        {
            medianValue = default;

            if (nums1 == null && nums2 != null)
            {
                medianValue = CalculateMedian(nums2);

                return true;
            }

            if (nums2 == null && nums1 != null)
            {
                medianValue = CalculateMedian(nums1);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Calculates the median of a sorted array.
        /// </summary>
        /// <param name="sortedArray">The sorted array.</param>
        /// <returns>The media of a sorted array.</returns>
        protected static double CalculateMedian(int[] sortedArray)
        {
            if (sortedArray.Length == 1)
            {
                return sortedArray.Single();
            }

            var middleIndex = sortedArray.Length / 2;

            if (sortedArray.Length % 2 != 0)
            {
                return sortedArray[middleIndex];
            }

            var sumOfMediaNums = sortedArray[middleIndex] + sortedArray[middleIndex - 1];

            return Math.Round(sumOfMediaNums / 2.0, 2);
        }
    }
}
