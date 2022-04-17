// <copyright file="Solution.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No2.AddTwoNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Questions.LeetCode.Common;

    /// <summary>
    /// The solution of LeetCode No.2 question: Add Two Numbers.
    /// </summary>
    public class Solution : IQuestion
    {
        /// <inheritdoc />
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var firstNumber = GetNumber(l1);
            var secondNumber = GetNumber(l2);
            var sumResultReversedCharArray = (firstNumber + secondNumber).ToString(CultureInfo.InvariantCulture).Reverse().ToArray();

            return GenerateResultNode(sumResultReversedCharArray);
        }

        /// <summary>
        /// Gets the number from list node.
        /// </summary>
        /// <param name="listNode">The list node.</param>
        /// <returns>The number.</returns>
        private static double GetNumber(ListNode listNode)
        {
            var numberStack = new Stack<int>();
            var currentNode = listNode;

            while (currentNode != null)
            {
                numberStack.Push(currentNode.val);
                currentNode = currentNode.next;
            }

            double result = 0;

            while (numberStack.Any())
            {
                var currentNum = numberStack.Pop();
                var currentCount = numberStack.Count;
                result = (Math.Pow(10, currentCount) * currentNum) + result;
            }

            return result;
        }

        /// <summary>
        /// Generates result node.
        /// </summary>
        /// <param name="sumResultCharArray">The sum result char array.</param>
        /// <returns>The list node.</returns>
        private static ListNode GenerateResultNode(IEnumerable<char> sumResultCharArray)
        {
            var resultCharArray = sumResultCharArray as char[] ?? sumResultCharArray.ToArray();

            if (!resultCharArray.Any())
            {
                return null;
            }

            return new ListNode(
                int.Parse(resultCharArray.First().ToString()),
                GenerateResultNode(resultCharArray.Skip(1)));
        }
    }
}
