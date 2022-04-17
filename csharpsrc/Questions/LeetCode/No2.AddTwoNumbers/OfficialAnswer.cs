// <copyright file="OfficialAnswer.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No2.AddTwoNumbers
{
    using Questions.LeetCode.Common;

    /// <summary>
    /// The official answer of LeetCode No.2 question: Add Two Numbers.
    /// </summary>
    public class OfficialAnswer : IQuestion
    {
        /// <inheritdoc />
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
            {
                return null;
            }

            ListNode headNode = null;
            ListNode tailNode = null;
            var carry = 0;

            while (l1 != null || l2 != null)
            {
                var firstNum = l1?.val ?? 0;
                var secondNum = l2?.val ?? 0;
                var sum = firstNum + secondNum + carry;

                if (headNode == null)
                {
                    headNode = new ListNode(sum % 10);
                    tailNode = headNode;
                }
                else
                {
                    tailNode.next = new ListNode(sum % 10);
                    tailNode = tailNode.next;
                }

                carry = sum / 10;

                l1 = l1?.next;
                l2 = l2?.next;
            }

            if (carry > 0)
            {
                tailNode.next = new ListNode(carry);
            }

            return headNode;
        }
    }
}
