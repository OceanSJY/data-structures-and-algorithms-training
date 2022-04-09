// <copyright file="TestCase.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCodeCases.No8.StringToInteger.Atoi
{
    using System;
    using BenchmarkDotNet.Attributes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.LeetCode.No8.StringToInteger.Atoi;

    /// <summary>
    /// The test case of LeetCode No.8 question: String to Integer (atoi).
    /// </summary>
    [TestClass]
    public class TestCase : LeetCodeBaseTestCase<int>
    {
        /// <summary>
        /// The solution of LeetCode No.8 question: String to Integer (atoi).
        /// </summary>
        private readonly IQuestion solution;

        /// <summary>
        /// The official answer of LeetCode No.8 question: String to Integer (atoi).
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
            long? randomNum = random.Next(1) == 1 ? random.Next(int.MinValue, int.MaxValue) * random.Next(int.MinValue, int.MaxValue) : null;
            var charArray = new char[randomNum.HasValue
                ? random.Next(Constraints.MinLength, Constraints.MaxLength) - randomNum.Value.ToString().Length
                : random.Next(Constraints.MinLength, Constraints.MaxLength)];

            for (var index = 0; index < charArray.Length - randomNum?.ToString().Length; index++)
            {
                charArray[index] = (char)random.Next('a', 'z');
            }

            this.testStr = new string(charArray);

            if (randomNum.HasValue)
            {
                var randomIndex = random.Next(0, this.testStr.Length - 1);
                this.testStr = this.testStr.Insert(randomIndex, randomNum.Value.ToString());
            }

            this.solution = new Solution();
            this.officialAnswer = new OfficialAnswer();
        }

        /// <summary>
        /// Verifies the result from MyAtoi solution.
        /// </summary>
        [TestMethod]
        public void VerifyMyAtoiSolutionResult()
        {
            var expectedResult = this.GetResultFromOfficialAnswer();
            var actualResult = this.GetResultFromSolution();

            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Checks the performance of MyAtoi solution.
        /// </summary>
        [TestMethod]
        public void CheckMyAtoiSolutionPerformance()
        {
#if RELEASE
            BenchmarkDotNet.Running.BenchmarkRunner.Run<TestCase>();
#endif
        }

        /// <inheritdoc />
        [Benchmark]
        public override int GetResultFromSolution()
        {
            return this.solution.MyAtoi(this.testStr);
        }

        /// <inheritdoc />
        [Benchmark]
        public override int GetResultFromOfficialAnswer()
        {
            return this.officialAnswer.MyAtoi(this.testStr);
        }
    }
}
