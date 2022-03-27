﻿// <copyright file="PalindromeNumberTest.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Tests.LeetCode.No9
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.LeetCode.No9.PalindromeNumber;

    /// <summary>
    /// The test class of LeetCode No.9 question: Palindrome Number.
    /// </summary>
    [TestClass]
    public class PalindromeNumberTest : BaseTest<bool>
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
        /// Initializes a new instance of the <see cref="PalindromeNumberTest"/> class.
        /// </summary>
        public PalindromeNumberTest()
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
            BenchmarkRunner.Run<PalindromeNumberTest>();
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
