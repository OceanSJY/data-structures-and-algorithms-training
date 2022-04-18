// <copyright file="OfficialAnswer.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No23.MergeKSortedLists
{
    using Questions.LeetCode.Common;

    /// <summary>
    /// The base official answer of LeetCode No.23 question: Merge K Sorted Lists.
    /// </summary>
    public abstract class OfficialAnswer : IQuestion
    {
        /// <inheritdoc />
        public abstract ListNode MergeKLists(ListNode[] lists);

        /// <summary>
        /// Merges 2 sorted lists.
        /// </summary>
        /// <param name="list1">The first sorted list.</param>
        /// <param name="list2">The second sorted list.</param>
        /// <returns>The merged result.</returns>
        protected static ListNode MergeTwoSortedLists(ListNode list1, ListNode list2)
        {
            if (list1 == null || list2 == null)
            {
                return list1 ?? list2;
            }

            var headNode = new ListNode();
            var tailNode = headNode;
            var currentFirstNode = list1;
            var currentSecondNode = list2;

            while (currentFirstNode != null && currentSecondNode != null)
            {
                if (currentFirstNode.val < currentSecondNode.val)
                {
                    tailNode.next = currentFirstNode;
                    currentFirstNode = currentFirstNode.next;
                }
                else
                {
                    tailNode.next = currentSecondNode;
                    currentSecondNode = currentSecondNode.next;
                }

                tailNode = tailNode.next;
            }

            tailNode.next = currentFirstNode ?? currentSecondNode;

            return headNode.next;
        }
    }
}
