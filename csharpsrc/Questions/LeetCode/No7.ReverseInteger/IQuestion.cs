// <copyright file="IQuestion.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No7.ReverseInteger
{
    using Questions.Interfaces;

    /// <summary>
    /// The LeetCode question 7: Reverse Integer.
    /// </summary>
    public interface IQuestion : IBaseQuestion
    {
        /// <summary>
        /// Reverses the number.
        /// </summary>
        /// <param name="x">The original number.</param>
        /// <returns>The reversed number.</returns>
        int Reverse(int x);
    }
}
