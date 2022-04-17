// <copyright file="SolutionB.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No23.MergeKSortedLists
{
    using System.Linq;
    using Questions.LeetCode.Common;

    /// <summary>
    /// The solution B of LeetCode NO.23 question: Merge K Sorted Lists.
    /// </summary>
    public class SolutionB : Solution
    {
        /// <inheritdoc />
        public override ListNode MergeKLists(ListNode[] lists)
        {
            return lists.Aggregate<ListNode, ListNode>(null, MergeTwoSortedLists);
        }

        /// <summary>
        /// Merges two sorted lists.
        /// </summary>
        /// <param name="list1">The first list.</param>
        /// <param name="list2">The second list.</param>
        /// <returns>The merged result.</returns>
        private static ListNode MergeTwoSortedLists(ListNode list1, ListNode list2)
        {
            if (list1 == null && list2 == null)
            {
                return null;
            }

            if (list1 == null)
            {
                return list2;
            }

            if (list2 == null)
            {
                return list1;
            }

            if (list1.val < list2.val)
            {
                list1.next = MergeTwoSortedLists(list1.next, list2);

                return list1;
            }

            list2.next = MergeTwoSortedLists(list1, list2.next);

            return list2;
        }
    }
}
