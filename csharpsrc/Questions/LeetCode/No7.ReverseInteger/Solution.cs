// <copyright file="Solution.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No7.ReverseInteger
{
    using System.Linq;

    /// <summary>
    /// The solution of LeetCode No.7 question: Reverse Integer.
    /// </summary>
    public class Solution : IQuestion
    {
        /// <inheritdoc />
        public int Reverse(int x)
        {
            if (x == 0)
            {
                return x;
            }

            var reversedNumStr = new string(x.ToString().ToCharArray().Reverse().ToArray()).TrimStart('0').TrimEnd('-');

            if (int.TryParse(reversedNumStr, out var reversedNum))
            {
                return x < 0 ? -reversedNum : reversedNum;
            }

            return 0;
        }
    }
}
