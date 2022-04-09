// <copyright file="TestCase.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCodeCases.No16.ThreeSumClosest
{
    using System;
    using BenchmarkDotNet.Attributes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.LeetCode.No16.ThreeSumClosest;

    /// <summary>
    /// The test class of LeetCode No.16 question: Three Sum Closest.
    /// </summary>
    [TestClass]
    public class TestCase : LeetCodeBaseTestCase<int>
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
        /// The solution of LeetCode No.16 question.
        /// </summary>
        private readonly IQuestion solution;

        /// <summary>
        /// The official answer of LeetCode No.16 question.
        /// </summary>
        private readonly IQuestion officialAnswer;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCase"/> class.
        /// </summary>
        public TestCase()
        {
            var random = new Random();
            this.testTarget = random.Next(Constraints.MinTargetValue, Constraints.MaxTargetValue);
            this.testNums = new int[random.Next(Constraints.MinLength, Constraints.MaxLength)];

            for (var index = 0; index < this.testNums.Length; index++)
            {
                this.testNums[index] = random.Next(Constraints.MinElementValue, Constraints.MaxElementValue);
            }

            this.solution = new Solution();
            this.officialAnswer = new OfficialAnswer();
        }

        /// <summary>
        /// Verifies the result from ThreeSumClosest solution whether it is as same as the result from official answer.
        /// </summary>
        [TestMethod]
        public void VerifyThreeSumClosestSolutionResult()
        {
            var expectedResult = this.GetResultFromOfficialAnswer();
            var actualResult = this.GetResultFromSolution();

            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Checks the performance of ThreeSumClosest solution.
        /// </summary>
        [TestMethod]
        public void CheckThreeSumClosestPerformance()
        {
#if RELEASE
            BenchmarkDotNet.Running.BenchmarkRunner.Run<TestCase>();
#endif
        }

        /// <inheritdoc />
        [Benchmark]
        public override int GetResultFromSolution()
        {
            return this.solution.ThreeSumClosest(this.testNums, this.testTarget);
        }

        /// <inheritdoc />
        [Benchmark]
        public override int GetResultFromOfficialAnswer()
        {
            return this.officialAnswer.ThreeSumClosest(this.testNums, this.testTarget);
        }
    }
}
