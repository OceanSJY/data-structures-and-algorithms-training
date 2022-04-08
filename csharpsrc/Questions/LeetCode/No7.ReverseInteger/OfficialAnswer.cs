// <copyright file="OfficialAnswer.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No7.ReverseInteger
{
    /// <summary>
    /// The official answer of LeetCode No.7 question: Reverse Integer.
    /// </summary>
    public class OfficialAnswer : IQuestion
    {
        /// <inheritdoc/>
        public int Reverse(int x)
        {
            var rev = 0;

            while (x != 0)
            {
                if (rev is < int.MinValue / 10 or > int.MaxValue / 10)
                {
                    return 0;
                }

                var digit = x % 10;
                x /= 10;
                rev = (rev * 10) + digit;
            }

            return rev;
        }
    }
}
