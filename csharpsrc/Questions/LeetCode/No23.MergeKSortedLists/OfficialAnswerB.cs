// <copyright file="OfficialAnswerB.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No23.MergeKSortedLists
{
    using System.Collections.Generic;
    using Questions.LeetCode.Common;

    /// <summary>
    /// The official answer B of LeetCode No.23 question: Merge K Sorted Lists.
    /// </summary>
    public class OfficialAnswerB : OfficialAnswer
    {
        /// <inheritdoc />
        public override ListNode MergeKLists(ListNode[] lists)
        {
            return MergeListsInRange(lists, 0, lists.Length - 1);
        }

        /// <summary>
        /// Merges the lists in range.
        /// </summary>
        /// <param name="lists">The lists.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="endIndex">The end index.</param>
        /// <returns>The merged result.</returns>
        private static ListNode MergeListsInRange(IReadOnlyList<ListNode> lists, int startIndex, int endIndex)
        {
            if (startIndex == endIndex)
            {
                return lists[startIndex];
            }

            if (startIndex > endIndex)
            {
                return null;
            }

            var middleIndex = (startIndex + endIndex) >> 1;

            return MergeTwoSortedLists(
                MergeListsInRange(lists, startIndex, middleIndex),
                MergeListsInRange(lists, middleIndex + 1, endIndex));
        }
    }
}
