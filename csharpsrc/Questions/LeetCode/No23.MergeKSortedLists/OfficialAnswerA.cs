// <copyright file="OfficialAnswerA.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No23.MergeKSortedLists
{
    using System.Linq;

    /// <summary>
    /// The official answer A of LeetCode No.23 question: Merge K Sorted Lists.
    /// </summary>
    public class OfficialAnswerA : OfficialAnswer
    {
        /// <inheritdoc />
        public override ListNode MergeKLists(ListNode[] lists)
        {
            return lists.Aggregate<ListNode, ListNode>(null, MergeTwoSortedLists);
        }
    }
}
