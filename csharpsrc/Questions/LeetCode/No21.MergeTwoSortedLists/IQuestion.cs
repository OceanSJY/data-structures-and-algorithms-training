// <copyright file="IQuestion.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No21.MergeTwoSortedLists
{
    using Questions.Interfaces;

    /// <summary>
    /// The LeetCode No.21 question: Merge Two Sorted Lists.
    /// </summary>
    public interface IQuestion : IBaseQuestion
    {
        /// <summary>
        /// Merges 2 sorted lists.
        /// </summary>
        /// <param name="list1">The first sorted list.</param>
        /// <param name="list2">The second sorted list.</param>
        /// <returns>The merged result.</returns>
        ListNode MergeTwoLists(ListNode list1, ListNode list2);
    }
}
