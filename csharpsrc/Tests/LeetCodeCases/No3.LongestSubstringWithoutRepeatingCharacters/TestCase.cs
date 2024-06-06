// <copyright file="TestCase.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCodeCases.No3.LongestSubstringWithoutRepeatingCharacters
{
    using System;
    using BenchmarkDotNet.Attributes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.LeetCode.No3.LongestSubstringWithoutRepeatingCharacters;

    /// <summary>
    /// The test class of LeetCode No.3 question: Longest Substring without Repeating Characters.
    /// </summary>
    [TestClass]
    public class TestCase : LeetCodeBaseTestCase<int>
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
        /// Initializes a new instance of the <see cref="TestCase"/> class.
        /// </summary>
        public TestCase()
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
            BenchmarkDotNet.Running.BenchmarkRunner.Run<TestCase>();
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
