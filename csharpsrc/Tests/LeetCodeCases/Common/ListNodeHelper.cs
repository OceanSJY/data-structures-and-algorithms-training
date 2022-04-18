// <copyright file="ListNodeHelper.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCodeCases.Common
{
    using System.Collections.Generic;
    using System.Linq;
    using Questions.LeetCode.Common;

    /// <summary>
    /// The list node helper.
    /// </summary>
    public static class ListNodeHelper
    {
        /// <summary>
        /// Generates the list node by numbers.
        /// </summary>
        /// <param name="numbers">The numbers.</param>
        /// <returns>The generated list node.</returns>
        public static ListNode GenerateListNode(IEnumerable<int> numbers)
        {
            return numbers == null || !numbers.Any()
                ? null
                : new ListNode(numbers.First(), GenerateListNode(numbers.Skip(1)));
        }

        /// <summary>
        /// Compares two list nodes to ensure whether they are same.
        /// </summary>
        /// <param name="list1">The first list.</param>
        /// <param name="list2">The second list.</param>
        /// <returns>The compared result.</returns>
        public static bool AreEquals(ListNode list1, ListNode list2)
        {
            var currentList1 = list1;
            var currentList2 = list2;

            while (currentList1 != null)
            {
                if (currentList1.val != currentList2.val)
                {
                    return false;
                }

                currentList1 = currentList1.next;
                currentList2 = currentList2.next;
            }

            return currentList2 == null;
        }
    }
}
