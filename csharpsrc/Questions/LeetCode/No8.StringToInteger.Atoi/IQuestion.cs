// <copyright file="IQuestion.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No8.StringToInteger.Atoi
{
    using Questions.Interfaces;

    /// <summary>
    /// The LeetCode No.8 question: String to Integer (atoi).
    /// </summary>
    public interface IQuestion : IBaseQuestion
    {
        /// <summary>
        /// Converts the string to integer.
        /// </summary>
        /// <param name="s">The original string.</param>
        /// <returns>The converted integer.</returns>
        int MyAtoi(string s);
    }
}
