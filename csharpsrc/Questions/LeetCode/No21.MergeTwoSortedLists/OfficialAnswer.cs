// <copyright file="OfficialAnswer.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No21.MergeTwoSortedLists
{
    /// <summary>
    /// The official answer of LeetCode No.21 question: Merge Two Sorted Lists.
    /// </summary>
    public class OfficialAnswer : IQuestion
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

            if (list1.val < list2.val)
            {
                list1.next = this.MergeTwoLists(list1.next, list2);

                return list1;
            }

            list2.next = this.MergeTwoLists(list1, list2.next);

            return list2;
        }
    }
}
