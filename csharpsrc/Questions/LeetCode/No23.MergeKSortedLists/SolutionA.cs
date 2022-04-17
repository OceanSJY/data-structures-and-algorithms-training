// <copyright file="SolutionA.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No23.MergeKSortedLists
{
    using System.Collections.Generic;
    using System.Linq;
    using Questions.LeetCode.Common;

    /// <summary>
    /// The solution A of LeetCode No.23 question: Merge K Sorted Lists.
    /// </summary>
    public class SolutionA : Solution
    {
        /// <inheritdoc />
        public override ListNode MergeKLists(ListNode[] lists)
        {
            return GenerateListNodes(GetValues(lists).OrderBy(value => value));
        }

        /// <summary>
        /// Generates list nodes by sorted list.
        /// </summary>
        /// <param name="sortedList">The sorted list.</param>
        /// <returns>The generated list nodes.</returns>
        private static ListNode GenerateListNodes(IEnumerable<int> sortedList)
        {
            return sortedList == null || !sortedList.Any()
                ? null
                : new ListNode(sortedList.First(), GenerateListNodes(sortedList.Skip(1).ToList()));
        }

        /// <summary>
        /// Gets the values of list node.
        /// </summary>
        /// <param name="listNodes">The list nodes.</param>
        /// <returns>The values of list node.</returns>
        private static IEnumerable<int> GetValues(IEnumerable<ListNode> listNodes)
        {
            var values = new List<int>();

            foreach (var listNode in listNodes)
            {
                if (listNode == null)
                {
                    continue;
                }

                var currentNode = listNode;

                while (currentNode != null)
                {
                    values.Add(currentNode.val);
                    currentNode = currentNode.next;
                }
            }

            return values;
        }
    }
}
