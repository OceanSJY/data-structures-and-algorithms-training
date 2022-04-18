// <copyright file="TestCase.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCodeCases.No2.AddTwoNumbers
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Questions.LeetCode.Common;
    using Questions.LeetCode.No2.AddTwoNumbers;
    using Tests.LeetCodeCases.Common;

    /// <summary>
    /// The test case of LeetCode No.2 question: Add Two Numbers.
    /// </summary>
    [TestClass]
    public class TestCase : LeetCodeBaseTestCase<ListNode>
    {
        /// <summary>
        /// The solution of LeetCode No.2 question: Add Two Numbers.
        /// </summary>
        private readonly IQuestion solution;

        /// <summary>
        /// The official answer of LeetCodeNo.2 question: Add Two Numbers.
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
        /// Initializes a new instance of the <see cref="TestCase"/> class.
        /// </summary>
        public TestCase()
        {
            var random = new Random();
            this.testList1 = ListNodeHelper.GenerateListNode(RandomNumberHelper.GenerateNumbers(
                Constraints.MinLength,
                Constraints.MaxLength,
                Constraints.MinValue,
                Constraints.MaxValue,
                random));
            this.testList2 = ListNodeHelper.GenerateListNode(RandomNumberHelper.GenerateNumbers(
                Constraints.MinLength,
                Constraints.MaxLength,
                Constraints.MinValue,
                Constraints.MaxValue,
                random));
            this.solution = new Solution();
            this.officialAnswer = new OfficialAnswer();
        }

        /// <summary>
        /// Verifies the result from AddTwoNumbers solution whether it is as same as the result from official answer.
        /// </summary>
        [TestMethod]
        public void VerifyAddTwoNumbersSolutionResult()
        {
            var expectedResult = this.GetResultFromOfficialAnswer();
            var actualResult = this.GetResultFromSolution();

            Assert.IsTrue(ListNodeHelper.AreEquals(expectedResult, actualResult));
        }

        /// <inheritdoc />
        public override ListNode GetResultFromSolution()
        {
            return this.solution.AddTwoNumbers(this.testList1, this.testList2);
        }

        /// <inheritdoc />
        public override ListNode GetResultFromOfficialAnswer()
        {
            return this.officialAnswer.AddTwoNumbers(this.testList1, this.testList2);
        }
    }
}
