// <copyright file="IQuestion.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No5.LongestPalindromicSubstring
{
    /// <summary>
    /// The LeetCode No.5 question: Longest Palindromic Substring.
    /// </summary>
    public interface IQuestion
    {
        /// <summary>
        /// Gets the longest palindrome from the original string.
        /// </summary>
        /// <param name="s">The original string.</param>
        /// <returns>The longest palindrome substring.</returns>
        string LongestPalindrome(string s);
    }
}
