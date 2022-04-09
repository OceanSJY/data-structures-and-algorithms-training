// <copyright file="TestCase.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCodeCases.No9.PalindromeNumber
{
    using System;
    using BenchmarkDotNet.Attributes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.LeetCode.No9.PalindromeNumber;

    /// <summary>
    /// The test class of LeetCode No.9 question: Palindrome Number.
    /// </summary>
    [TestClass]
    public class TestCase : LeetCodeBaseTestCase<bool>
    {
        /// <summary>
        /// The test number.
        /// </summary>
        private readonly int testNumber;

        /// <summary>
        /// The solution of LeetCode No.9 question.
        /// </summary>
        private readonly IQuestion solution;

        /// <summary>
        /// The official answer of LeetCode No.9 question.
        /// </summary>
        private readonly IQuestion officialAnswer;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCase"/> class.
        /// </summary>
        public TestCase()
        {
            var random = new Random();
            this.testNumber = random.Next(Constraints.MinValue, Constraints.MaxValue);
            this.solution = new Solution();
            this.officialAnswer = new OfficialAnswer();
        }

        /// <summary>
        /// Verifies the result from PalindromeNumber solution whether it is as same as the result from official answer.
        /// </summary>
        [TestMethod]
        public void VerifyPalindromeNumberSolutionResult()
        {
            var expectedResult = this.GetResultFromOfficialAnswer();
            var actualResult = this.GetResultFromSolution();

            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Checks the performance of PalindromeNumber solution.
        /// </summary>
        [TestMethod]
        public void CheckPalindromeNumberSolutionPerformance()
        {
#if RELEASE
            BenchmarkDotNet.Running.BenchmarkRunner.Run<TestCase>();
#endif
        }

        /// <inheritdoc />
        [Benchmark]
        public override bool GetResultFromSolution()
        {
            return this.solution.IsPalindrome(this.testNumber);
        }

        /// <inheritdoc />
        [Benchmark]
        public override bool GetResultFromOfficialAnswer()
        {
            return this.officialAnswer.IsPalindrome(this.testNumber);
        }
    }
}
