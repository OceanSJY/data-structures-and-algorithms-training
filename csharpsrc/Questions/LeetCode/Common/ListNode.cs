// <copyright file="ListNode.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.Common;

using DataStructures.LinkList;

/// <summary>
/// The pre-defined singly-linked list.
/// </summary>
public class ListNode : ListNode<int>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ListNode"/> class.
    /// </summary>
    /// <param name="data">The value.</param>
    /// <param name="next">The Next pointer.</param>
    public ListNode(int data = 0, ListNode next = null)
        : base(data, next)
    {
    }
}