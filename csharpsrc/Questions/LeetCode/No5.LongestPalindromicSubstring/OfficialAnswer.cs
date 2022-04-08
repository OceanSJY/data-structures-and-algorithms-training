// <copyright file="OfficialAnswer.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No5.LongestPalindromicSubstring
{
    /// <summary>
    /// The official answer of LeetCode No.5 question: Longest Palindromic Substring.
    /// </summary>
    public abstract class OfficialAnswer : IQuestion
    {
        /// <inheritdoc />
        public abstract string LongestPalindrome(string s);
    }
}
