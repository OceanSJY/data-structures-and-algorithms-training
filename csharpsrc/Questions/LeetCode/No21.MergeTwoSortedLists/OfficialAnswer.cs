// <copyright file="OfficialAnswer.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No21.MergeTwoSortedLists
{
    using Questions.LeetCode.Common;

    /// <summary>
    /// The official answer of LeetCode No.21 question: Merge Two Sorted Lists.
    /// </summary>
    public class OfficialAnswer : IQuestion
    {
        /// <inheritdoc />
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            switch (list1)
            {
                case null when list2 == null:
                    return null;
                case null:
                    return list2;
            }

            if (list2 == null)
            {
                return list1;
            }

            if (list1.Data < list2.Data)
            {
                list1.Next = this.MergeTwoLists((ListNode)list1.Next, list2);

                return list1;
            }

            list2.Next = this.MergeTwoLists(list1, (ListNode)list2.Next);

            return list2;
        }
    }
}
