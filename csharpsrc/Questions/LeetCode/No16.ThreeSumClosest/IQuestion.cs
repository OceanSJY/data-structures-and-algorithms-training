// <copyright file="IQuestion.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No16.ThreeSumClosest
{
    using Questions.Interfaces;

    /// <summary>
    /// The LeetCode No.16 question: Three Sum Closest.
    /// </summary>
    public interface IQuestion : IBaseQuestion
    {
        /// <summary>
        /// Gets the sum of triplets which is closest to target.
        /// </summary>
        /// <param name="nums">The number array.</param>
        /// <param name="target">The target.</param>
        /// <returns>The closest sum of triplet.</returns>
        int ThreeSumClosest(int[] nums, int target);
    }
}
