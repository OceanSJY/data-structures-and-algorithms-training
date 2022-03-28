﻿// <copyright file="MedianOfTwoSortedArraysTest.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCode.No4
{
    using System;
    using System.Linq;
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
        /// The expected results from official answers.
        /// </summary>
        private readonly double[] expectedResultsFromOfficialAnswers;

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

            this.expectedResultsFromOfficialAnswers = new[]
            {
                this.officialAnswerA.FindMedianSortedArrays(this.testNums1, this.testNums2),
                this.officialAnswerB.FindMedianSortedArrays(this.testNums1, this.testNums2),
            };
        }

        /// <summary>
        /// The solutions of LeetCode No.4 question: Median of Two Sorted Arrays.
        /// </summary>
        public IQuestion[] Solutions => new[]
        {
            this.solutionA,
            this.solutionB,
        };

        /// <summary>
        /// The official answers of LeetCode No.4 question: Median of Two Sorted Arrays.
        /// </summary>
        public IQuestion[] OfficialAnswers => new[]
        {
            this.officialAnswerA,
            this.officialAnswerB,
        };

        /// <summary>
        /// Gets or sets current solution.
        /// </summary>
        [ParamsSource(nameof(Solutions))]
        public IQuestion CurrentSolution { get; set; }

        /// <summary>
        /// Gets or sets the current official answer.
        /// </summary>
        [ParamsSource(nameof(OfficialAnswers))]
        public IQuestion CurrentOfficialAnswer { get; set; }

        /// <summary>
        /// Verifies the result from MedianOfTwoSortedArrays solution A whether it is as same as the result from official answers.
        /// </summary>
        [TestMethod]
        public void VerifyMedianOfTwoSortedArraysSolutionAResult()
        {
            this.CurrentSolution = this.Solutions.First();
            var actualResultA = this.GetResultFromSolution();

            Assert.AreEqual(this.expectedResultsFromOfficialAnswers.First(), actualResultA);
            Assert.AreEqual(this.expectedResultsFromOfficialAnswers.Last(), actualResultA);
        }

        /// <summary>
        /// Verifies the result from MedianOfTwoSortedArrays solution B whether it is as same as the result from official answers.
        /// </summary>
        [TestMethod]
        public void VerifyMedianOfTwoSortedArraysSolutionBResult()
        {
            this.CurrentSolution = this.Solutions.Last();
            var actualResultB = this.GetResultFromSolution();

            Assert.AreEqual(this.expectedResultsFromOfficialAnswers.First(), actualResultB);
            Assert.AreEqual(this.expectedResultsFromOfficialAnswers.Last(), actualResultB);
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
            return this.CurrentSolution.FindMedianSortedArrays(this.testNums1, this.testNums2);
        }

        /// <inheritdoc />
        [Benchmark]
        public override double GetResultFromOfficialAnswer()
        {
            return this.CurrentOfficialAnswer.FindMedianSortedArrays(this.testNums1, this.testNums2);
        }
    }
}