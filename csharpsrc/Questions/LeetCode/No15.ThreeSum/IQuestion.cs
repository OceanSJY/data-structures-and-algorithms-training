// <copyright file="IQuestion.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No15.ThreeSum
{
    using System.Collections.Generic;
    using Questions.Interfaces;

    /// <summary>
    /// The LeetCode No.15 question: Three Sum.
    /// </summary>
    public interface IQuestion : IBaseQuestion
    {
        /// <summary>
        /// Gets all triplets from number array that the sum of triplets equals to zero.
        /// </summary>
        /// <param name="nums">The number array.</param>
        /// <returns>All unique triples.</returns>
        IList<IList<int>> ThreeSum(int[] nums);
    }
}
