// <copyright file="TestCase.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCodeCases.No1.TwoSum
{
    using System;
    using System.Linq;
    using BenchmarkDotNet.Attributes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.LeetCode.No1.TwoSum;

    /// <summary>
    /// The test class of LeetCode No.1 question: Two Sum.
    /// </summary>
    [TestClass]
    public class TestCase : LeetCodeBaseTestCase<int[]>
    {
        /// <summary>
        /// The test number array.
        /// </summary>
        private readonly int[] testNums;

        /// <summary>
        /// The test target.
        /// </summary>
        private readonly int testTarget;

        /// <summary>
        /// The solution of LeetCode No.1 question.
        /// </summary>
        private readonly IQuestion solution;

        /// <summary>
        /// The official answer of No.1 question.
        /// </summary>
        private readonly IQuestion officialAnswer;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCase"/> class.
        /// </summary>
        public TestCase()
        {
            var random = new Random();
            this.testTarget = random.Next(Constraints.MinValue, Constraints.MaxValue);
            this.testNums = new int[random.Next(Constraints.MinLength, Constraints.MaxLength)];

            for (var index = 0; index < this.testNums.Length; index++)
            {
                this.testNums[index] = random.Next(Constraints.MinValue, Constraints.MaxValue);
            }

            this.solution = new Solution();
            this.officialAnswer = new OfficialAnswer();
        }

        /// <summary>
        /// Verifies the result from TwoSum solution whether it is as same as the result from official answer.
        /// </summary>
        [TestMethod]
        public void VerifyTwoSumSolutionResult()
        {
            var expectedResult = this.GetResultFromOfficialAnswer();
            var actualResult = this.GetResultFromSolution();
            Array.Sort(expectedResult);
            Array.Sort(actualResult);

            Assert.IsTrue(actualResult.SequenceEqual(actualResult));
        }

        /// <summary>
        /// Checks the performance of TwoSum solution.
        /// </summary>
        [TestMethod]
        public void CheckTwoSumSolutionPerformance()
        {
#if RELEASE
            BenchmarkDotNet.Running.BenchmarkRunner.Run<TestCase>();
#endif
        }

        /// <inheritdoc />
        [Benchmark]
        public override int[] GetResultFromSolution()
        {
            return this.solution.TwoSum(this.testNums, this.testTarget);
        }

        /// <inheritdoc />
        [Benchmark]
        public override int[] GetResultFromOfficialAnswer()
        {
            return this.officialAnswer.TwoSum(this.testNums, this.testTarget);
        }
    }
}
