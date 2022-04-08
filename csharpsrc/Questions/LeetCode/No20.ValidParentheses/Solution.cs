// <copyright file="Solution.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No20.ValidParentheses
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The solution of LeetCode No.20 question: Valid Parentheses.
    /// </summary>
    public class Solution : IQuestion
    {
        /// <summary>
        /// The pre-defined parenthesis groups.
        /// </summary>
        private readonly Dictionary<char, char> parenthesisGroups = new()
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' },
        };

        /// <inheritdoc />
        public bool IsValid(string s)
        {
            // Step 0: Handles invalid input
            if (string.IsNullOrWhiteSpace(s) ||
                s.Length == 1 ||
                s.Length % 2 != 0 ||
                this.parenthesisGroups.Values.Contains(s.First()) ||
                this.parenthesisGroups.Keys.Contains(s.Last()))
            {
                return false;
            }

            // Step 1: Handles normal case
            var parenthesisStack = new Stack<char>();

            foreach (var currentParenthesis in s)
            {
                if (!parenthesisStack.Any())
                {
                    parenthesisStack.Push(currentParenthesis);

                    continue;
                }

                var prevParenthesis = parenthesisStack.Pop();

                if (!this.parenthesisGroups.ContainsKey(prevParenthesis))
                {
                    return false;
                }

                var pairParenthesis = this.parenthesisGroups[prevParenthesis];

                if (pairParenthesis.Equals(currentParenthesis))
                {
                    continue;
                }

                parenthesisStack.Push(prevParenthesis);
                parenthesisStack.Push(currentParenthesis);
            }

            return !parenthesisStack.Any();
        }
    }
}
