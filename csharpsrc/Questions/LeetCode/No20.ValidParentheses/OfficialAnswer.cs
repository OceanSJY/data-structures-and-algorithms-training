// <copyright file="OfficialAnswer.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No20.ValidParentheses
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The official answer of LeetCode No.20 question: Valid Parentheses.
    /// </summary>
    public class OfficialAnswer : IQuestion
    {
        /// <summary>
        /// The pre-defined parenthesis groups.
        /// </summary>
        private readonly Dictionary<char, char> parenthesisGroups = new ()
        {
            { ')', '(' },
            { ']', '[' },
            { '}', '{' },
        };

        /// <inheritdoc />
        public bool IsValid(string s)
        {
            if (s.Length % 2 == 1)
            {
                return false;
            }

            var parenthesisStack = new Stack<char>();

            foreach (var currentParenthesis in s)
            {
                if (!this.parenthesisGroups.ContainsKey(currentParenthesis))
                {
                    parenthesisStack.Push(currentParenthesis);

                    continue;
                }

                if (!parenthesisStack.Any() ||
                    !parenthesisStack.Peek().Equals(this.parenthesisGroups[currentParenthesis]))
                {
                    return false;
                }

                parenthesisStack.Pop();
            }

            return !parenthesisStack.Any();
        }
    }
}
