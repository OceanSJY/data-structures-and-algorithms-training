// <copyright file="OfficialAnswerA.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No4.MedianOfTwoSortedArrays
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The official answer A of LeetCode No.4 question: Median of Two Sorted Arrays.
    /// </summary>
    public class OfficialAnswerA : OfficialAnswer
    {
        /// <inheritdoc />
        public override double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var totalLength = nums1.Length + nums2.Length;
            var middleIndex = totalLength / 2;

            if (totalLength % 2 != 0)
            {
                return GetKthElement(nums1, nums2, middleIndex + 1);
            }

            var medianSum =
                GetKthElement(nums1, nums2, middleIndex) +
                GetKthElement(nums1, nums2, middleIndex + 1);

            return Math.Round(medianSum / 2.0, 2);
        }

        /// <summary>
        /// Gets the Kth element.
        /// </summary>
        /// <param name="nums1">The first sorted array.</param>
        /// <param name="nums2">The second sorted array.</param>
        /// <param name="kth">The kth index.</param>
        /// <returns>The kth element.</returns>
        private static int GetKthElement(IReadOnlyList<int> nums1, IReadOnlyList<int> nums2, int kth)
        {
            var firstIndex = 0;
            var secondIndex = 0;

            while (true)
            {
                if (firstIndex == nums1.Count)
                {
                    return nums2[secondIndex + kth - 1];
                }

                if (secondIndex == nums2.Count)
                {
                    return nums1[firstIndex + kth - 1];
                }

                if (kth == 1)
                {
                    return Math.Min(nums1[firstIndex], nums2[secondIndex]);
                }

                var half = kth / 2;
                var newFirstIndex = Math.Min(firstIndex + half, nums1.Count) - 1;
                var newSecondIndex = Math.Min(secondIndex + half, nums2.Count) - 1;
                var firstPivot = nums1[newFirstIndex];
                var secondPivot = nums2[newSecondIndex];

                if (firstPivot <= secondPivot)
                {
                    kth -= newFirstIndex - firstIndex + 1;
                    firstIndex = newFirstIndex + 1;
                }
                else
                {
                    kth -= newSecondIndex - secondIndex + 1;
                    secondIndex = newSecondIndex + 1;
                }
            }
        }
    }
}
