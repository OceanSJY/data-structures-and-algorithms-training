// <copyright file="OfficialAnswerC.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No23.MergeKSortedLists
{
    using System.Collections.Generic;

    /// <summary>
    /// The official answer C of LeetCode No.23 question: Merge K Sorted Lists.
    /// </summary>
    public class OfficialAnswerC : OfficialAnswer
    {
        /// <inheritdoc />
        public override ListNode MergeKLists(ListNode[] lists)
        {
            var priorityQueue = new PriorityQueue<ListNode, int>();

            foreach (var listNode in lists)
            {
                priorityQueue.Enqueue(listNode, listNode.val);
            }

            return AssembleListNode(priorityQueue);
        }

        /// <summary>
        /// Assembles the list node in order.
        /// </summary>
        /// <param name="sortedListNodes">The sorted list node in priority queue.</param>
        /// <returns>The assembled result.</returns>
        private static ListNode AssembleListNode(PriorityQueue<ListNode, int> sortedListNodes)
        {
            if (sortedListNodes == null || sortedListNodes.Count == 0)
            {
                return null;
            }

            return new ListNode(sortedListNodes.Dequeue().val, AssembleListNode(sortedListNodes));
        }
    }
}
