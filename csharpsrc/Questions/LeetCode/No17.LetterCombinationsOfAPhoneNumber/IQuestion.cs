// <copyright file="IQuestion.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No17.LetterCombinationsOfAPhoneNumber
{
    using System.Collections.Generic;
    using Questions.Interfaces;

    /// <summary>
    /// The LeetCode No.17 question: Letter Combinations of a Phone Number.
    /// </summary>
    public interface IQuestion : IBaseQuestion
    {
        /// <summary>
        /// Gets all possible letter combinations that the number could represent.
        /// </summary>
        /// <param name="digits">The num in string.</param>
        /// <returns>All possible letter combinations.</returns>
        IList<string> LetterCombinations(string digits);
    }
}
