// <copyright file="OfficialAnswer.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No2.AddTwoNumbers;

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
            var firstNum = l1?.Data ?? 0;
            var secondNum = l2?.Data ?? 0;
            var sum = firstNum + secondNum + carry;

            if (headNode == null)
            {
                headNode = tailNode = new ListNode(sum % 10);
            }
            else
            {
                tailNode.Next = new ListNode(sum % 10);
                tailNode = (ListNode)tailNode.Next;
            }

            carry = sum / 10;

            l1 = (ListNode)l1?.Next;
            l2 = (ListNode)l2?.Next;
        }

        if (carry > 0)
        {
            tailNode.Next = new ListNode(carry);
        }

        return headNode;
    }
}