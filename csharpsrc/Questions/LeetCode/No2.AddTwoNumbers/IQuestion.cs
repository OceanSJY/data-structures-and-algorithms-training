// <copyright file="IQuestion.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No2.AddTwoNumbers
{
    using Questions.Interfaces;
    using Questions.LeetCode.Common;

    /// <summary>
    /// The LeetCode No.2 question: Add Two Numbers.
    /// </summary>
    public interface IQuestion : IBaseQuestion
    {
        /// <summary>
        /// Adds 2 numbers which are in list node.
        /// </summary>
        /// <param name="l1">The number in list node 1.</param>
        /// <param name="l2">The number in list node 2.</param>
        /// <returns>The added result.</returns>
        ListNode AddTwoNumbers(ListNode l1, ListNode l2);
    }
}
