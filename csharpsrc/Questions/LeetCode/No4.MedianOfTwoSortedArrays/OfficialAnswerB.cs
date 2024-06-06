// <copyright file="OfficialAnswerB.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No4.MedianOfTwoSortedArrays
{
    using System;

    /// <summary>
    /// The official answer B of LeetCode No.4 question: Median of Two Sorted Arrays.
    /// </summary>
    public class OfficialAnswerB : OfficialAnswer
    {
        /// <inheritdoc />
        public override double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                return this.FindMedianSortedArrays(nums2, nums1);
            }

            var leftPointer = 0;
            var rightPointer = Math.Min(nums1.Length, nums2.Length);
            var maxMedianFirstPart = 0;
            var maxMedianLastPart = 0;

            while (leftPointer <= rightPointer)
            {
                var firstIndex = (leftPointer + rightPointer) / 2;
                var secondIndex = ((nums1.Length + nums2.Length + 1) / 2) - firstIndex;

                var firstPrevValue = firstIndex == 0 ? int.MinValue : nums1[firstIndex - 1];
                var firstValue = firstIndex == nums1.Length ? int.MaxValue : nums1[firstIndex];
                var secondPrevValue = secondIndex == 0 ? int.MinValue : nums2[secondIndex - 1];
                var secondValue = secondIndex == nums2.Length ? int.MaxValue : nums2[secondIndex];

                if (firstPrevValue <= secondValue)
                {
                    maxMedianFirstPart = Math.Max(firstPrevValue, secondPrevValue);
                    maxMedianLastPart = Math.Min(firstValue, secondValue);
                    leftPointer = firstIndex + 1;
                }
                else
                {
                    rightPointer = firstIndex - 1;
                }
            }

            return (nums1.Length + nums2.Length) % 2 == 0
                ? (maxMedianFirstPart + maxMedianLastPart) / 2.0
                : maxMedianFirstPart;
        }
    }
}
