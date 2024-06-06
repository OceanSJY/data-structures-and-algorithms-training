// <copyright file="ListNode.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace DataStructures.LinkList;

using System.Collections.Generic;
using System.Linq;

/// <summary>
/// The list node.
/// </summary>
/// <typeparam name="T">The type of Data property in list node.</typeparam>
public class ListNode<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ListNode{T}"/> class.
    /// </summary>
    /// <param name="node">The node.</param>
    public ListNode(ListNode<T> node = null)
    {
        if (node is null)
        {
            return;
        }

        this.Data = node.Data;
        this.Next = node.Next;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ListNode{T}"/> class.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <param name="next">The next node.</param>
    public ListNode(T data, ListNode<T> next = null)
    {
        this.Data = data;
        this.Next = next;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ListNode{T}"/> class.
    /// </summary>
    /// <param name="source">The data source.</param>
    public ListNode(IEnumerable<T> source)
    {
        if (source is null || !source.Any())
        {
            return;
        }

        if (source.Count() == 1)
        {
            this.Data = source.Single();

            return;
        }

        this.Data = source.First();
        this.Next = new ListNode<T>(source.Skip(1));
    }

    /// <summary>
    /// Gets or sets the data.
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    /// Gets or sets the next node.
    /// </summary>
    public ListNode<T> Next { get; set; }
}