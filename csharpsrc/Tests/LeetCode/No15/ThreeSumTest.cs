// <copyright file="ThreeSumTest.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCode.No15
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.LeetCode.No15.ThreeSum;

    /// <summary>
    /// The test class of LeetCode No.15 question: Three Sum.
    /// </summary>
    [TestClass]
    public class ThreeSumTest : LeetCodeBaseTestCase<IList<IList<int>>>
    {
        /// <summary>
        /// The test numbers.
        /// </summary>
        private readonly int[] testNums;

        /// <summary>
        /// The solution of LeetCode No.15 question: Three Sum.
        /// </summary>
        private readonly IQuestion solution;

        /// <summary>
        /// The official answer of LeetCode No.15 question: Three Sum.
        /// </summary>
        private readonly IQuestion officialAnswer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThreeSumTest"/> class.
        /// </summary>
        public ThreeSumTest()
        {
            var random = new Random();
            this.testNums = new int[random.Next(Constraints.MinLength, Constraints.MaxLength)];

            for (var index = 0; index < this.testNums.Length; index++)
            {
                this.testNums[index] = random.Next(Constraints.MinValue, Constraints.MaxValue);
            }

            this.solution = new Solution();
            this.officialAnswer = new OfficialAnswer();
        }

        /// <summary>
        /// Verifies the result from ThreeSum solution whether it is as same as the result from official answer.
        /// </summary>
        [TestMethod]
        public void VerifyThreeSumSolutionResult()
        {
            var expectedResult = this.GetResultFromOfficialAnswer();
            var actualResult = this.GetResultFromSolution();

            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            Assert.IsTrue(actualResult.All(combination => combination.Sum() == 0));
        }

        /// <summary>
        /// Checks the performance of ThreeSum solution.
        /// </summary>
        [TestMethod]
        public void CheckThreeSumSolutionPerformance()
        {
#if RELEASE
            BenchmarkRunner.Run<ThreeSumTest>();
#endif
        }

        /// <inheritdoc />
        [Benchmark]
        public override IList<IList<int>> GetResultFromSolution()
        {
            return this.solution.ThreeSum(this.testNums);
        }

        /// <inheritdoc />
        [Benchmark]
        public override IList<IList<int>> GetResultFromOfficialAnswer()
        {
            return this.officialAnswer.ThreeSum(this.testNums);
        }
    }
}
