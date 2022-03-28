// <copyright file="LongestSubstringWithoutRepeatingCharactersTest.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCode.No3
{
    using System;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.LeetCode.No3.LongestSubstringWithoutRepeatingCharacters;

    /// <summary>
    /// The test class of LeetCode No.3 question: Longest Substring without Repeating Characters.
    /// </summary>
    [TestClass]
    public class LongestSubstringWithoutRepeatingCharactersTest : LeetCodeBaseTestCase<int>
    {
        /// <summary>
        /// The test string.
        /// </summary>
        private readonly string testStr;

        /// <summary>
        /// The solution of LeetCode No.3 question.
        /// </summary>
        private readonly IQuestion solution;

        /// <summary>
        /// The official answer of LeetCode No.3 question.
        /// </summary>
        private readonly IQuestion officialAnswer;

        /// <summary>
        /// Initializes a new instance of the <see cref="LongestSubstringWithoutRepeatingCharactersTest"/> class.
        /// </summary>
        public LongestSubstringWithoutRepeatingCharactersTest()
        {
            var random = new Random();
            var charArray = new char[random.Next(Constraints.MinLength, Constraints.MaxLength)];

            for (var index = 0; index < charArray.Length; index++)
            {
                charArray[index] = (char)random.Next(Constraints.MinCharacterValue, Constraints.MaxCharacterValue);
            }

            this.testStr = new string(charArray);
            this.solution = new Solution();
            this.officialAnswer = new OfficialAnswer();
        }

        /// <summary>
        /// Verifies the result from LongestSubstringWithoutRepeatingCharacters solution whether it is as same as the result from official answer. 
        /// </summary>
        [TestMethod]
        public void VerifyLongestSubstringWithoutRepeatingCharactersSolutionResult()
        {
            var expectedResult = this.GetResultFromOfficialAnswer();
            var actualResult = this.GetResultFromSolution();

            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Checks the performance of LongestSubstringWithoutRepeatingCharacters solution.
        /// </summary>
        [TestMethod]
        public void CheckLongestSubstringWithoutRepeatingCharactersSolutionPerformance()
        {
#if RELEASE
            BenchmarkRunner.Run<LongestSubstringWithoutRepeatingCharactersTest>();
#endif
        }

        /// <inheritdoc />
        [Benchmark]
        public override int GetResultFromSolution()
        {
            return this.solution.LengthOfLongestSubstring(this.testStr);
        }

        /// <inheritdoc />
        [Benchmark]
        public override int GetResultFromOfficialAnswer()
        {
            return this.officialAnswer.LengthOfLongestSubstring(this.testStr);
        }
    }
}
