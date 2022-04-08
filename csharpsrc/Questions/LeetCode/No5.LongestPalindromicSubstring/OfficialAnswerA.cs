// <copyright file="OfficialAnswerA.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No5.LongestPalindromicSubstring
{
    /// <summary>
    /// The official answer A of LeetCode No.5 question: Longest Palindromic Substring.
    /// </summary>
    public class OfficialAnswerA : OfficialAnswer
    {
        /// <inheritdoc />
        public override string LongestPalindrome(string s)
        {
            if (s.Length < 2)
            {
                return s;
            }

            var longestLength = 1;
            var startIndex = 0;
            var palindromeCheckedResults = new bool[s.Length, s.Length];

            for (var index = 0; index < s.Length; index++)
            {
                palindromeCheckedResults[index, index] = true;
            }

            for (var index = 2; index <= s.Length; index++)
            {
                for (var subIndex = 0; subIndex < s.Length; subIndex++)
                {
                    var rightBorder = index + subIndex - 1;

                    if (rightBorder >= s.Length)
                    {
                        break;
                    }

                    if (s[subIndex] != s[rightBorder])
                    {
                        palindromeCheckedResults[subIndex, rightBorder] = false;
                    }
                    else
                    {
                        if (rightBorder - subIndex < 3)
                        {
                            palindromeCheckedResults[subIndex, rightBorder] = true;
                        }
                        else
                        {
                            palindromeCheckedResults[subIndex, rightBorder] =
                                palindromeCheckedResults[subIndex + 1, rightBorder - 1];
                        }
                    }

                    if (!palindromeCheckedResults[subIndex, rightBorder] ||
                        rightBorder - subIndex + 1 <= longestLength)
                    {
                        continue;
                    }

                    longestLength = rightBorder - subIndex + 1;
                    startIndex = subIndex;
                }
            }

            return s.Substring(startIndex, longestLength);
        }
    }
}
