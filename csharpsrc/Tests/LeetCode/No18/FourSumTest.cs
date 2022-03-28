// <copyright file="FourSumTest.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCode.No18
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.LeetCode.No18.FourSum;

    /// <summary>
    /// The test class of LeetCode No.18 question: Four Sum.
    /// </summary>
    [TestClass]
    public class FourSumTest : LeetCodeBaseTestCase<IList<IList<int>>>
    {
        /// <summary>
        /// The test numbers.
        /// </summary>
        private readonly int[] testNums;

        /// <summary>
        /// The test target.
        /// </summary>
        private readonly int testTarget;

        /// <summary>
        /// The solution of LeetCode No.18.
        /// </summary>
        private readonly IQuestion solution;

        /// <summary>
        /// The official answer of LeetCode No.18.
        /// </summary>
        private readonly IQuestion officialAnswer;

        /// <summary>
        /// Initializes a new instance of the <see cref="FourSumTest"/> class.
        /// </summary>
        public FourSumTest()
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
        /// Verifies the result from FourSum solution whether it is as same as the result from official answer.
        /// </summary>
        [TestMethod]
        public void VerifyFourSumSolutionResult()
        {
            var expectedResult = this.GetResultFromOfficialAnswer();
            var actualResult = this.GetResultFromSolution();

            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            Assert.IsTrue(actualResult.All(combination => combination.Sum() == this.testTarget));
        }

        /// <summary>
        /// Checks the performance of FourSum solution.
        /// </summary>
        [TestMethod]
        public void CheckFourSumSolutionPerformance()
        {
#if RELEASE
            BenchmarkRunner.Run<FourSumTest>();
#endif
        }

        /// <inheritdoc />
        [Benchmark]
        public override IList<IList<int>> GetResultFromSolution()
        {
            return this.solution.FourSum(this.testNums, this.testTarget);
        }

        /// <inheritdoc />
        [Benchmark]
        public override IList<IList<int>> GetResultFromOfficialAnswer()
        {
            return this.officialAnswer.FourSum(this.testNums, this.testTarget);
        }
    }
}
