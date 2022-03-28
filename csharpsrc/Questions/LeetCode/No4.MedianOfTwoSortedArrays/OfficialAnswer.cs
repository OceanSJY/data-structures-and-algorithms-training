// <copyright file="OfficialAnswer.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No4.MedianOfTwoSortedArrays
{
    /// <summary>
    /// The official answer of LeetCode No.4 question: Median of Two Sorted Arrays.
    /// </summary>
    public abstract class OfficialAnswer : IQuestion
    {
        /// <inheritdoc />
        public abstract double FindMedianSortedArrays(int[] nums1, int[] nums2);
    }
}
