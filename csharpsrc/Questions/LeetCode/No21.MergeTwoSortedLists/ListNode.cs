// <copyright file="ListNode.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No21.MergeTwoSortedLists
{
    /// <summary>
    /// The pre-defined list node of LeetCode No.21 question: Merge Two Sorted Lists.
    /// </summary>
    public class ListNode
    {
        /// <summary>
        /// The value.
        /// </summary>
        public int val;

        /// <summary>
        /// The next pointer.
        /// </summary>
        public ListNode next;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListNode"/> class.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="next">The next pointer.</param>
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
