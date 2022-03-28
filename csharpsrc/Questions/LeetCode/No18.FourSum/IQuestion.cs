// <copyright file="IQuestion.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No18.FourSum
{
    using System.Collections.Generic;
    using Questions.Interfaces;

    /// <summary>
    /// The LeetCode No.18 question: Four Sum.
    /// </summary>
    public interface IQuestion : IBaseQuestion
    {
        /// <summary>
        /// Gets all unique quadruplets from numbers array and their sum need to equals to target.
        /// </summary>
        /// <param name="nums">The numbers array.</param>
        /// <param name="target">The target.</param>
        /// <returns>All unique quadruples.</returns>
        IList<IList<int>> FourSum(int[] nums, int target);
    }
}
