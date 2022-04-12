// <copyright file="Solution.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No21.MergeTwoSortedLists
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The solution of LeetCode No.21 question: Merge Two Sorted Lists.
    /// </summary>
    public class Solution : IQuestion
    {
        /// <inheritdoc />
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
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

            var values = new List<int>();
            values.AddRange(GetValues(list1));
            values.AddRange(GetValues(list2));

            return GenerateListNodes(values.OrderBy(val => val));
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
        /// <param name="listNode">The list node.</param>
        /// <returns>The values of list node.</returns>
        private static IEnumerable<int> GetValues(ListNode listNode)
        {
            var values = new List<int>();
            var currentNode = listNode;

            while (currentNode != null)
            {
                values.Add(currentNode.val);
                currentNode = currentNode.next;
            }

            return values;
        }
    }
}
