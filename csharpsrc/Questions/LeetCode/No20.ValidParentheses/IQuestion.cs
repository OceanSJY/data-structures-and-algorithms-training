// <copyright file="IQuestion.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No20.ValidParentheses
{
    /// <summary>
    /// The LeetCode No.20 question: Valid Parentheses.
    /// </summary>
    public interface IQuestion
    {
        /// <summary>
        /// Checks the string whether the parentheses in it are valid.
        /// </summary>
        /// <param name="s">The original string.</param>
        /// <returns>True means valid.</returns>
        bool IsValid(string s);
    }
}
