// <copyright file="TestCase.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCodeCases.No7.ReverseInteger
{
    using System;
    using BenchmarkDotNet.Attributes;
#if RELEASE
    using BenchmarkDotNet.Running;
#endif
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.LeetCode.No7.ReverseInteger;

    /// <summary>
    /// The test case of LeetCode No.7 question: Reverse Integer.
    /// </summary>
    [TestClass]
    public class TestCase : LeetCodeBaseTestCase<int>
    {
        /// <summary>
        /// The test number.
        /// </summary>
        private readonly int testNum;

        /// <summary>
        /// The solution of LeetCode No.7 question: Reverse Integer.
        /// </summary>
        private readonly IQuestion solution;

        /// <summary>
        /// The official answer of LeetCode No.7 question: Reverse Integer.
        /// </summary>
        private readonly IQuestion officialAnswer;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCase"/> class.
        /// </summary>
        public TestCase()
        {
            var random = new Random();
            this.testNum = random.Next(int.MinValue, int.MaxValue);
            this.solution = new Solution();
            this.officialAnswer = new OfficialAnswer();
        }

        /// <summary>
        /// Verifies the result from reverse integer solution whether it equals to official answer.
        /// </summary>
        [TestMethod]
        public void VerifyReverseIntegerSolutionResult()
        {
            var expectedResult = this.GetResultFromOfficialAnswer();
            var actualResult = this.GetResultFromSolution();

            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Checks the performance of reverse integer solution.
        /// </summary>
        [TestMethod]
        public void CheckReverseIntegerSolutionPerformance()
        {
#if RELEASE
            BenchmarkRunner.Run<TestCase>();
#endif
        }

        /// <inheritdoc />
        [Benchmark]
        public override int GetResultFromSolution()
        {
            return this.solution.Reverse(this.testNum);
        }

        /// <inheritdoc />
        [Benchmark]
        public override int GetResultFromOfficialAnswer()
        {
            return this.officialAnswer.Reverse(this.testNum);
        }
    }
}
