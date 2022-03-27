// <copyright file="MedianOfTwoSortedArraysTest.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCode.No4
{
    using System;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.LeetCode.No4.MedianOfTwoSortedArrays;

    /// <summary>
    /// The test class of LeetCode No.4 question: Median of Two Sorted Arrays.
    /// </summary>
    [TestClass]
    public class MedianOfTwoSortedArraysTest : BaseTest<double>
    {
        /// <summary>
        /// The first test nums array.
        /// </summary>
        private readonly int[] testNums1;

        /// <summary>
        /// The second test nums array.
        /// </summary>
        private readonly int[] testNums2;

        /// <summary>
        /// The solution A of LeetCode No.4 question: Median of Two Sorted Arrays.
        /// </summary>
        private readonly IQuestion solutionA;

        /// <summary>
        /// The solution B of LeetCode No.4 question: Median of Two Sorted Arrays.
        /// </summary>
        private readonly IQuestion solutionB;

        /// <summary>
        /// The official answer A of LeetCode No.4 question: Median of Two Sorted Arrays.
        /// </summary>
        private readonly IQuestion officialAnswerA;

        /// <summary>
        /// The official answer B of LeetCode No.4 question: Median of Two Sorted Arrays.
        /// </summary>
        private readonly IQuestion officialAnswerB;

        /// <summary>
        /// Initializes a new instance of the <see cref="MedianOfTwoSortedArraysTest"/> class.
        /// </summary>
        public MedianOfTwoSortedArraysTest()
        {
            this.solutionA = new SolutionA();
            this.solutionB = new SolutionB();
            this.officialAnswerA = new OfficialAnswerA();
            this.officialAnswerB = new OfficialAnswerB();

            var random = new Random();

            do
            {
                this.testNums1 = new int[random.Next(Constraints.MinLength, Constraints.MaxLength)];
                this.testNums2 = new int[random.Next(Constraints.MinLength, Constraints.MaxLength)];
            }
            while (this.testNums1.Length + this.testNums2.Length > 2000);

            for (var index = 0; index < this.testNums1.Length; index++)
            {
                this.testNums1[index] = random.Next(Constraints.MinValue, Constraints.MaxValue);
                Array.Sort(this.testNums1);
            }

            for (var index = 0; index < this.testNums2.Length; index++)
            {
                this.testNums2[index] = random.Next(Constraints.MinValue, Constraints.MaxValue);
                Array.Sort(this.testNums2);
            }
        }

        /// <summary>
        /// Verifies the result from MedianOfTwoSortedArrays solution A whether it is as same as the result from official answers.
        /// </summary>
        [TestMethod]
        public void VerifyMedianOfTwoSortedArraysSolutionAResult()
        {
            var expectedResultA = this.GetResultFromOfficialAnswer();
            var expectedResultB = this.GetResultFromOfficialAnswerB();
            var actualResultA = this.GetResultFromSolution();

            Assert.AreEqual(expectedResultA, actualResultA);
            Assert.AreEqual(expectedResultB, actualResultA);
        }

        /// <summary>
        /// Verifies the result from MedianOfTwoSortedArrays solution B whether it is as same as the result from official answers.
        /// </summary>
        [TestMethod]
        public void VerifyMedianOfTwoSortedArraysSolutionBResult()
        {
            var expectedResultA = this.GetResultFromOfficialAnswer();
            var expectedResultB = this.GetResultFromOfficialAnswerB();
            var actualResultB = this.GetResultFromSolutionB();

            Assert.AreEqual(expectedResultA, actualResultB);
            Assert.AreEqual(expectedResultB, actualResultB);
        }

        /// <summary>
        /// Checks the performance of MedianOfTwoSortedArrays A and B.
        /// </summary>
        [TestMethod]
        public void CheckMedianOfTwoSortedArraysSolutionsPerformance()
        {
#if RELEASE
            BenchmarkRunner.Run<MedianOfTwoSortedArraysTest>();
#endif
        }

        /// <inheritdoc />
        [Benchmark]
        public override double GetResultFromSolution()
        {
            return this.solutionA.FindMedianSortedArrays(this.testNums1, this.testNums2);
        }

        /// <summary>
        /// Gets the result from solution B.
        /// </summary>
        /// <returns>The result from solution B.</returns>

        [Benchmark]
        public double GetResultFromSolutionB()
        {
            return this.solutionB.FindMedianSortedArrays(this.testNums1, this.testNums2);
        }

        /// <inheritdoc />
        [Benchmark]
        public override double GetResultFromOfficialAnswer()
        {
            return this.officialAnswerA.FindMedianSortedArrays(this.testNums1, this.testNums2);
        }

        /// <summary>
        /// Gets the result from official answer B.
        /// </summary>
        /// <returns>The result from official answer B.</returns>
        [Benchmark]
        public double GetResultFromOfficialAnswerB()
        {
            return this.officialAnswerB.FindMedianSortedArrays(this.testNums1, this.testNums2);
        }
    }
}
