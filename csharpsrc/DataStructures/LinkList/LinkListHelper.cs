// <copyright file="LinkListHelper.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace DataStructures.LinkList;

using System;
using System.Collections.Generic;

/// <summary>
/// The link list helper.
/// </summary>
public static class LinkListHelper
{
    /// <summary>
    /// Reverses the link list by new head.
    /// </summary>
    /// <typeparam name="T">The type of data property in each list node.</typeparam>
    /// <param name="node">The first list node.</param>
    /// <returns>The reversed link list.</returns>
    public static ListNode<T> ReverseByNewHead<T>(this ListNode<T> node)
    {
        if (TryPreReverse(node, out var reversedResult))
        {
            return reversedResult;
        }

        var currentNode = new ListNode<T>(node);
        var headNode = new ListNode<T>();

        while (currentNode != null)
        {
            var tempNode = currentNode.Next;
            currentNode.Next = headNode.Next;
            headNode.Next = currentNode;
            currentNode = tempNode;
        }

        return headNode.Next;
    }

    /// <summary>
    /// Reverses the link list by stack.
    /// </summary>
    /// <typeparam name="T">The type of data property in each list node.</typeparam>
    /// <param name="node">The first list node.</param>
    /// <returns>The reversed link list.</returns>
    public static ListNode<T> ReverseByStack<T>(this ListNode<T> node)
    {
        if (TryPreReverse(node, out var reversedResult))
        {
            return reversedResult;
        }

        var stack = new Stack<T>();
        var currentNode = new ListNode<T>(node.Data, node.Next);

        while (currentNode != null)
        {
            stack.Push(currentNode.Data);
            currentNode = currentNode.Next;
        }

        return new ListNode<T>(stack);
    }

    /// <summary>
    /// Tries to pre reverse the link list.
    /// </summary>
    /// <typeparam name="T">The type of data in each list node.</typeparam>
    /// <param name="node">The original list node.</param>
    /// <param name="reversedResult">The reversed list node.</param>
    /// <returns>True or false to indicate whether the pre reverse has succeed.</returns>
    /// <exception cref="ArgumentNullException">Throws the argument null exception once the node is null.</exception>
    private static bool TryPreReverse<T>(ListNode<T> node, out ListNode<T> reversedResult)
    {
        reversedResult = null;

        if (node is null)
        {
            throw new ArgumentNullException($"The {nameof(node)} is null which is invalid.");
        }

        if (node.Next is not null)
        {
            return false;
        }

        reversedResult = node;

        return true;
    }
}