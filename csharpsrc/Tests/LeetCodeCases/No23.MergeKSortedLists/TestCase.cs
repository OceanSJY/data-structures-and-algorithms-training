// <copyright file="TestCase.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCodeCases.No23.MergeKSortedLists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BenchmarkDotNet.Attributes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.LeetCode.Common;
    using Questions.LeetCode.No23.MergeKSortedLists;

    /// <summary>
    /// The test case of LeetCode No.23 question: Merge K Sorted Lists.
    /// </summary>
    [TestClass]
    public class TestCase : LeetCodeBaseTestCase<ListNode>
    {
        /// <summary>
        /// The solution A of LeetCode No.23 question: Merge K Sorted Lists.
        /// </summary>
        private readonly IQuestion solutionA;

        /// <summary>
        /// The solution B of LeetCode No.23 question: Merge K Sorted Lists.
        /// </summary>
        private readonly IQuestion solutionB;

        /// <summary>
        /// The official answer A of LeetCode No.23 question: Merge K Sorted Lists.
        /// </summary>
        private readonly IQuestion officialAnswerA;

        /// <summary>
        /// The official answer B of LeetCode No.23 question: Merge K Sorted Lists.
        /// </summary>
        private readonly IQuestion officialAnswerB;

        /// <summary>
        /// The official answer C of LeetCode No.23 question: Merge K Sorted Lists.
        /// </summary>
        private readonly IQuestion officialAnswerC;

        /// <summary>
        /// The test list nodes.
        /// </summary>
        private readonly ListNode[] testListNodes;

        /// <summary>
        /// The expected results from official answer.
        /// </summary>
        private readonly ListNode[] expectedResultsFromOfficialAnswer;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCase"/> class.
        /// </summary>
        public TestCase()
        {
            this.solutionA = new SolutionA();
            this.solutionB = new SolutionB();
            this.officialAnswerA = new OfficialAnswerA();
            this.officialAnswerB = new OfficialAnswerB();
            this.officialAnswerC = new OfficialAnswerC();
            this.expectedResultsFromOfficialAnswer = new ListNode[this.OfficialAnswers.Length];

            var random = new Random();
            this.testListNodes =
                new ListNode[random.Next(Constraints.MinListNodeCount, Constraints.MaxListNodeCount)];

            for (var index = 0; index < this.testListNodes.Length; index++)
            {
                this.testListNodes[index] = GenerateListNode(GenerateSortedNumbers(random));
            }

            for (var index = 0; index < this.expectedResultsFromOfficialAnswer.Length; index++)
            {
                var clonedTestListNodes = (ListNode[])this.testListNodes.Clone();
                this.expectedResultsFromOfficialAnswer[index] =
                    this.OfficialAnswers[index].MergeKLists(clonedTestListNodes);
            }
        }

        /// <summary>
        /// Gets all solutions of LeetCode No.23 question: Merge K Sorted Lists.
        /// </summary>
        public IQuestion[] Solutions => new[]
        {
            this.solutionA,
            this.solutionB,
        };

        /// <summary>
        /// Gets all official answers of LeetCode No.23 question: Merge K Sorted Lists.
        /// </summary>
        public IQuestion[] OfficialAnswers => new[]
        {
            this.officialAnswerA,
            this.officialAnswerB,
            this.officialAnswerC,
        };

        /// <summary>
        /// Gets or sets current solution.
        /// </summary>
        [ParamsSource(nameof(Solutions))]
        public IQuestion CurrentSolution { get; set; }

        /// <summary>
        /// Gets or sets current official answer.
        /// </summary>
        [ParamsSource(nameof(OfficialAnswers))]
        public IQuestion CurrentOfficialAnswer { get; set; }

        /// <summary>
        /// Verifies the result from MergeKSortedLists solution A whether it is as same as the result from official answers.
        /// </summary>
        [TestMethod]
        public void VerifyMergeKSortedListsSolutionAResult()
        {
            this.CurrentSolution = this.Solutions.First();
            var actualResultA = this.GetResultFromSolution();

            foreach (var expectedResult in this.expectedResultsFromOfficialAnswer)
            {
                CompareExpectedResultWithActualResult(expectedResult, actualResultA);
            }
        }

        /// <summary>
        /// Verifies the result from MergeKSortedLists solution B whether it is as same as the result from official answers.
        /// </summary>
        [TestMethod]
        public void VerifyMergeKSortedListsSolutionBResult()
        {
            this.CurrentSolution = this.Solutions.Last();
            var actualResultB = this.GetResultFromSolution();

            foreach (var expectedResult in this.expectedResultsFromOfficialAnswer)
            {
                CompareExpectedResultWithActualResult(expectedResult, actualResultB);
            }
        }

        /// <summary>
        /// Checks the performance of MergeKSortedLists solution A and B.
        /// </summary>
        [TestMethod]
        public void CheckMergeKSortedListsSolutionsPerformance()
        {
#if RELEASE
            BenchmarkDotNet.Running.BenchmarkRunner.Run<TestCase>();
#endif
        }

        /// <inheritdoc />
        [Benchmark]
        public override ListNode GetResultFromSolution()
        {
            return this.CurrentSolution.MergeKLists((ListNode[])this.testListNodes.Clone());
        }

        /// <inheritdoc />
        [Benchmark]
        public override ListNode GetResultFromOfficialAnswer()
        {
            return this.CurrentOfficialAnswer.MergeKLists((ListNode[])this.testListNodes.Clone());
        }

        /// <summary>
        /// Generates sorted array.
        /// </summary>
        /// <param name="random">The random instance.</param>
        /// <returns>The sorted array.</returns>
        private static IEnumerable<int> GenerateSortedNumbers(Random random)
        {
            var testArray = new int[random.Next(Constraints.MinLength, Constraints.MaxLength)];

            for (var index = 0; index < testArray.Length; index++)
            {
                testArray[index] = random.Next(Constraints.MinValue, Constraints.MaxValue);
            }

            Array.Sort(testArray);

            return testArray;
        }

        /// <summary>
        /// Generates list nodes by sorted list.
        /// </summary>
        /// <param name="sortedList">The sorted list.</param>
        /// <returns>The generated list nodes.</returns>
        private static ListNode GenerateListNode(IEnumerable<int> sortedList)
        {
            return sortedList == null || !sortedList.Any()
                ? null
                : new ListNode(sortedList.First(), GenerateListNode(sortedList.Skip(1).ToList()));
        }

        /// <summary>
        /// Compares the expected result with actual result.
        /// </summary>
        /// <param name="expectedResult">The expected result.</param>
        /// <param name="actualResult">The actual result.</param>
        private static void CompareExpectedResultWithActualResult(ListNode expectedResult, ListNode actualResult)
        {
            var currentExpectedNode = expectedResult;
            var currentActualNode = actualResult;

            while (currentExpectedNode != null)
            {
                Assert.AreEqual(currentExpectedNode.val, currentActualNode.val);
                currentExpectedNode = currentExpectedNode.next;
                currentActualNode = currentActualNode.next;
            }
        }
    }
}
