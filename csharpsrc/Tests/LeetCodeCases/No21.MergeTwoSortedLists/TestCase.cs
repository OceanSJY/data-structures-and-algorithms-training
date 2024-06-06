// <copyright file="TestCase.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCodeCases.No21.MergeTwoSortedLists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BenchmarkDotNet.Attributes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.LeetCode.Common;
    using Questions.LeetCode.No21.MergeTwoSortedLists;
    using Tests.LeetCodeCases.Common;

    /// <summary>
    /// The test case of LeetCode No.21 question: Merge Two Sorted Lists.
    /// </summary>
    [TestClass]
    public class TestCase : LeetCodeBaseTestCase<ListNode>
    {
        /// <summary>
        /// The solution of LeetCode No.21 question: Merge Two Sorted Lists.
        /// </summary>
        private readonly IQuestion solution;

        /// <summary>
        /// The official answer of LeetCode No.21 question: Merge Two Sorted Lists.
        /// </summary>
        private readonly IQuestion officialAnswer;

        /// <summary>
        /// The test list 1.
        /// </summary>
        private readonly ListNode testList1;

        /// <summary>
        /// The test list 2.
        /// </summary>
        private readonly ListNode testList2;

        /// <summary>
        /// The cloned test list 1.
        /// </summary>
        private readonly ListNode clonedTestList1;

        /// <summary>
        /// The cloned test list2.
        /// </summary>
        private readonly ListNode clonedTestList2;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestCase"/> class.
        /// </summary>
        public TestCase()
        {
            this.testList1 = ListNodeHelper.GenerateListNode(GenerateSortedNumbers());
            this.testList2 = ListNodeHelper.GenerateListNode(GenerateSortedNumbers());
            this.clonedTestList1 = CloneListNode(this.testList1);
            this.clonedTestList2 = CloneListNode(this.testList2);
            this.solution = new Solution();
            this.officialAnswer = new OfficialAnswer();
        }

        /// <summary>
        /// Verifies the result from MergeTwoSortedList solution.
        /// </summary>
        [TestMethod]
        public void VerifyMergeTwoSortedListsSolutionResult()
        {
            var expectedResult = this.GetResultFromOfficialAnswer();
            var actualResult = this.GetResultFromSolution();

            Assert.IsTrue(ListNodeHelper.AreEquals(expectedResult, actualResult));
        }

        /// <summary>
        /// Checks the performance of valid parentheses solution.
        /// </summary>
        [TestMethod]
        public void CheckMergeTwoSortedListsPerformance()
        {
#if RELEASE
            BenchmarkDotNet.Running.BenchmarkRunner.Run<TestCase>();
#endif
        }

        /// <inheritdoc />
        [Benchmark]
        public override ListNode GetResultFromSolution()
        {
            return this.solution.MergeTwoLists(this.testList1, this.testList2);
        }

        /// <inheritdoc />
        [Benchmark]
        public override ListNode GetResultFromOfficialAnswer()
        {
            return this.officialAnswer.MergeTwoLists(this.clonedTestList1, this.clonedTestList2);
        }

        /// <summary>
        /// Generates sorted array.
        /// </summary>
        /// <param name="random">The random instance.</param>
        /// <returns>The sorted array.</returns>
        private static IEnumerable<int> GenerateSortedNumbers()
        {
            var randomNumbers = RandomNumberHelper.GenerateNumbers(
                Constraints.MinLength,
                Constraints.MaxLength,
                Constraints.MinValue,
                Constraints.MaxValue).ToArray();

            Array.Sort(randomNumbers);

            return randomNumbers;
        }

        /// <summary>
        /// Clones list node.
        /// </summary>
        /// <param name="listNode">The original list node.</param>
        /// <returns>The cloned list node.</returns>
        private static ListNode CloneListNode(ListNode listNode)
        {
            return listNode == null ? null : new ListNode(listNode.Data, CloneListNode((ListNode)listNode.Next));
        }
    }
}
