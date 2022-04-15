// <copyright file="TestCase.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCodeCases.No17.LetterCombinationsOfAPhoneNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BenchmarkDotNet.Attributes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.LeetCode.No17.LetterCombinationsOfAPhoneNumber;

    /// <summary>
    /// The test case of LeetCode No.17 question: Letter Combinations of a Phone Number.
    /// </summary>
    [TestClass]
    public class TestCase : LeetCodeBaseTestCase<IList<string>>
    {
        /// <summary>
        /// The solution of LeetCode No.17 question: Letter Combinations of a Phone Number.
        /// </summary>
        private readonly IQuestion solution;

        /// <summary>
        /// The official answer of LeetCode No.17 question: Letter Combinations of a Phone Number.
        /// </summary>
        private readonly IQuestion officialAnswer;

        /// <summary>
        /// The test digits.
        /// </summary>
        private readonly string testDigits;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCase"/> class.
        /// </summary>
        public TestCase()
        {
            var random = new Random();
            var testDigitsArray = new char[random.Next(Constraints.MinLength, Constraints.MaxLength)];

            for (var index = 0; index < testDigitsArray.Length; index++)
            {
                testDigitsArray[index] =
                    Constraints.validPhoneNumbers[random.Next(0, Constraints.validPhoneNumbers.Length - 1)];
            }

            this.testDigits = new string(testDigitsArray);
            this.solution = new Solution();
            this.officialAnswer = new OfficialAnswer();
        }

        /// <summary>
        /// Verifies the result from LetterCombination solution whether it is as same as the result from official answer.
        /// </summary>
        [TestMethod]
        public void VerifyLetterCombinationSolutionResult()
        {
            var expectedResult = this.GetResultFromOfficialAnswer();
            var actualResult = this.GetResultFromSolution();

            Assert.IsTrue(
                expectedResult.OrderBy(result => result).SequenceEqual(actualResult.OrderBy(result => result)));
        }

        /// <summary>
        /// Checks the performance of LetterCombination solution.
        /// </summary>
        [TestMethod]
        public void CheckLetterCombinationSolutionPerformance()
        {
#if RELEASE
            BenchmarkDotNet.Running.BenchmarkRunner.Run<TestCase>();
#endif
        }

        /// <inheritdoc />
        [Benchmark]
        public override IList<string> GetResultFromSolution()
        {
            return this.solution.LetterCombinations(this.testDigits);
        }

        /// <inheritdoc />
        [Benchmark]
        public override IList<string> GetResultFromOfficialAnswer()
        {
            return this.officialAnswer.LetterCombinations(this.testDigits);
        }
    }
}
