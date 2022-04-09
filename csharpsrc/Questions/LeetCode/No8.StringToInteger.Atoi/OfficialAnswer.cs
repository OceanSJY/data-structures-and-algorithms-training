// <copyright file="OfficialAnswer.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No8.StringToInteger.Atoi
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The official answer of LeetCode No.8 question: String to Integer (atoi).
    /// </summary>
    public class OfficialAnswer : IQuestion
    {
        /// <summary>
        /// The sign.
        /// </summary>
        private int sign = 1;

        /// <summary>
        /// The ans.
        /// </summary>
        private long ans = 0;

        /// <summary>
        /// The state.
        /// </summary>
        private string state = "start";

        /// <summary>
        /// The states dictionary.
        /// </summary>
        private readonly Dictionary<string, string[]> states = new Dictionary<string, string[]>()
        {
            { "start", new[] { "start", "signed", "in_number", "end" } },
            { "signed", new[] { "end", "end", "in_number", "end" } },
            { "in_number", new[] { "end", "end", "in_number", "end" } },
            { "end", new[] { "end", "end", "end", "end" } },
        };

        /// <inheritdoc />
        public int MyAtoi(string s)
        {
            foreach (var t in s)
            {
                this.UpdateSignOrAns(t);
            }

            return (int)(this.sign * this.ans);
        }

        /// <summary>
        /// Gets the column index based on character.
        /// </summary>
        /// <param name="character">Current character.</param>
        /// <returns>The column index.</returns>
        private static int GetColumn(char character)
        {
            switch (character)
            {
                case ' ':
                    return 0;
                case '+':
                case '-':
                    return 1;
            }

            return char.IsDigit(character) ? 2 : 3;
        }

        /// <summary>
        /// Updates the sign or ans based on character.
        /// </summary>
        /// <param name="character">Current character.</param>
        private void UpdateSignOrAns(char character)
        {
            this.state = this.states[this.state][GetColumn(character)];

            switch (this.state)
            {
                case "in_number":
                    this.ans = (this.ans * 10) + character - '0';
                    this.ans = this.sign == 1
                        ? Math.Min(this.ans, int.MaxValue)
                        : Math.Min(this.ans, -(long)int.MinValue);
                    break;
                case "signed":
                    this.sign = '+'.Equals(character) ? 1 : -1;
                    break;
            }
        }
    }
}
