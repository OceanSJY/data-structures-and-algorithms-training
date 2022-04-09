// <copyright file="TestCase.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCodeCases.No20.ValidParentheses
{
    using System;
    using BenchmarkDotNet.Attributes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.LeetCode.No20.ValidParentheses;

    /// <summary>
    /// The test case of LeetCode No.20 question: Valid Parentheses.
    /// </summary>
    [TestClass]
    public class TestCase : LeetCodeBaseTestCase<bool>
    {
        /// <summary>
        /// The solution of LeetCode No.20 question: Valid Parentheses.
        /// </summary>
        private readonly IQuestion solution;

        /// <summary>
        /// The official answer of LeetCode No.20 question: Valid Parentheses.
        /// </summary>
        private readonly IQuestion officialAnswer;

        /// <summary>
        /// The test string.
        /// </summary>
        private readonly string testStr;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCase"/> class.
        /// </summary>
        public TestCase()
        {
            var random = new Random();
            var parenthesesArray = new char[random.Next(Constraints.MinLength, Constraints.MaxLength)];

            for (var index = 0; index < parenthesesArray.Length; index++)
            {
                parenthesesArray[index] = Constraints.Parentheses[random.Next(0, Constraints.Parentheses.Length - 1)];
            }

            this.testStr = new string(parenthesesArray);
            this.solution = new Solution();
            this.officialAnswer = new OfficialAnswer();
        }

        /// <summary>
        /// Verifies the result from valid parentheses solution.
        /// </summary>
        [TestMethod]
        public void VerifyValidParenthesesSolutionResult()
        {
            var expectedResult = this.GetResultFromOfficialAnswer();
            var actualResult = this.GetResultFromSolution();

            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Checks the performance of valid parentheses  solution.
        /// </summary>
        [TestMethod]
        public void CheckValidParenthesesSolutionPerformance()
        {
#if RELEASE
            BenchmarkDotNet.Running.BenchmarkRunner.Run<TestCase>();
#endif
        }

        /// <inheritdoc />
        [Benchmark]
        public override bool GetResultFromSolution()
        {
            return this.solution.IsValid(this.testStr);
        }

        /// <inheritdoc />
        [Benchmark]
        public override bool GetResultFromOfficialAnswer()
        {
            return this.officialAnswer.IsValid(this.testStr);
        }
    }
}
