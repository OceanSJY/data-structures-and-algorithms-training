// <copyright file="Solution.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No23.MergeKSortedLists
{
    /// <summary>
    /// The base solution class of LeetCode No.23 question: Merge Sorted K Lists.
    /// </summary>
    public abstract class Solution : IQuestion
    {
        /// <inheritdoc />
        public abstract ListNode MergeKLists(ListNode[] lists);
    }
}
