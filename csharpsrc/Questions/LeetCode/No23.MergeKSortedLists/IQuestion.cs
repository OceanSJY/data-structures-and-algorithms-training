// <copyright file="IQuestion.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No23.MergeKSortedLists
{
    using Questions.Interfaces;

    /// <summary>
    /// The LeetCode No.23 question: Merge K Sorted Lists.
    /// </summary>
    public interface IQuestion : IBaseQuestion
    {
        /// <summary>
        /// Merges multi sorted lists to one list.
        /// </summary>
        /// <param name="lists">Multi sorted lists.</param>
        /// <returns>The merged result.</returns>
        ListNode MergeKLists(ListNode[] lists);
    }
}
