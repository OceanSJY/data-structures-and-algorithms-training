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
            var random = new Random();
            this.testList1 = GenerateListNode(GenerateSortedNumbers(random));
            this.testList2 = GenerateListNode(GenerateSortedNumbers(random));
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
            var currentExpectedNode = expectedResult;
            var currentActualNode = actualResult;

            while (currentExpectedNode != null)
            {
                Assert.AreEqual(currentExpectedNode.val, currentActualNode.val);
                currentExpectedNode = currentExpectedNode.next;
                currentActualNode = currentActualNode.next;
            }
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
        /// Clones list node.
        /// </summary>
        /// <param name="listNode">The original list node.</param>
        /// <returns>The cloned list node.</returns>
        private static ListNode CloneListNode(ListNode listNode)
        {
            return listNode == null ? null : new ListNode(listNode.val, CloneListNode(listNode.next));
        }
    }
}
