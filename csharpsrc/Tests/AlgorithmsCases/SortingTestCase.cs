// <copyright file="SortingTestCase.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.AlgorithmsCases
{
    using System;
    using System.Linq;
    using Algorithms.SortingHelpers;
    using BenchmarkDotNet.Attributes;
#if RELEASE
    using BenchmarkDotNet.Running;
#endif
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The test class of bubble sort algorithm.
    /// </summary>
    [TestClass]
    public class SortingTestCase
    {
        /// <summary>
        /// The length of test array.
        /// </summary>
        private const int TestArrayLength = 10000;

        /// <summary>
        /// Initializes a new instance of the <see cref="SortingTestCase"/> class.
        /// </summary>
        public SortingTestCase()
        {
            var (testSource, expectedResult) = PrepareTestSourceAndResult();
            this.TestSource = testSource;
            this.ExpectedResult = expectedResult;
        }

        /// <summary>
        /// Gets or sets the test source.
        /// </summary>
        public int[] TestSource { get; set; }

        /// <summary>
        /// Gets or sets the expected result.
        /// </summary>
        public int[] ExpectedResult { get; set; }

        /// <summary>
        /// Verifies the bubble sort algorithm whether it is correct.
        /// </summary>
        [TestMethod]
        public void VerifyResultFromBubbleSortAlgorithm()
        {
            Assert.IsTrue(this.GetResultFromBubbleSortAlgorithm().SequenceEqual(this.ExpectedResult));
        }

        /// <summary>
        /// Verifies the merging sort algorithm whether it is correct.
        /// </summary>
        [TestMethod]
        public void VerifyResultFromMergingSortAlgorithm()
        {
            Assert.IsTrue(this.GetResultFromMergingSortAlgorithm().SequenceEqual(this.ExpectedResult));
        }

        /// <summary>
        /// Verifies the quick sort algorithm whether it is correct.
        /// </summary>
        [TestMethod]
        public void VerifyResultFromQuickSortAlgorithm()
        {
            Assert.IsTrue(this.GetResultFromQuickSortAlgorithm().SequenceEqual(this.ExpectedResult));
        }

        /// <summary>
        /// Verifies the insertion sort algorithm whether it is correct.
        /// </summary>
        [TestMethod]
        public void VerifyResultFromInsertionSortAlgorithm()
        {
            Assert.IsTrue(this.GetResultFromInsertionSortAlgorithm().SequenceEqual(this.ExpectedResult));
        }

        /// <summary>
        /// Verifies the selection sort algorithm whether it is correct.
        /// </summary>
        [TestMethod]
        public void VerifyResultFromSelectionSortAlgorithm()
        {
            Assert.IsTrue(this.GetResultFromSelectionSortAlgorithm().SequenceEqual(this.ExpectedResult));
        }

        /// <summary>
        /// Checks the performance of sorting algorithms.
        /// </summary>
        [TestMethod]
        public void CheckSortingAlgorithmsPerformance()
        {
#if RELEASE
            BenchmarkRunner.Run<SortingTestCase>();
#endif
        }

        /// <summary>
        /// Gets the result from bubble sort algorithm.
        /// </summary>
        /// <returns>The sorted result by bubble sort algorithm.</returns>
        [Benchmark]
        public int[] GetResultFromBubbleSortAlgorithm() =>
            this.TestSource.BubbleSort((element1, element2) => element1 > element2).ToArray();

        /// <summary>
        /// Gets the result from quick sort algorithm.
        /// </summary>
        /// <returns>The sorted result by quick sort algorithm.</returns>
        [Benchmark]
        public int[] GetResultFromQuickSortAlgorithm() =>
            this.TestSource.QuickSort((element1, element2) => element1 > element2).ToArray();

        /// <summary>
        /// Gets the result from merging sort algorithm.
        /// </summary>
        /// <returns>The sorted result by bubble sort algorithm.</returns>
        [Benchmark]
        public int[] GetResultFromMergingSortAlgorithm() =>
            this.TestSource.MergingSort((element1, element2) => element1 > element2).ToArray();

        /// <summary>
        /// Gets the result from insertion sort algorithm.
        /// </summary>
        /// <returns>The sorted result by insertion sort algorithm.</returns>
        [Benchmark]
        public int[] GetResultFromInsertionSortAlgorithm() =>
            this.TestSource.InsertSort((element1, element2) => element1 > element2).ToArray();

        /// <summary>
        /// Gets the result from selection sort algorithm.
        /// </summary>
        /// <returns>The sorted result by selection sort algorithm.</returns>
        [Benchmark]
        public int[] GetResultFromSelectionSortAlgorithm() =>
            this.TestSource.SelectionSort((element1, element2) => element1 > element2).ToArray();

        /// <summary>
        /// Prepares the test source and expected result.
        /// </summary>
        /// <returns>The test source.</returns>
        private static (int[] testSource, int[] expectedResult) PrepareTestSourceAndResult()
        {
            var random = new Random();
            var testSource = new int[TestArrayLength];

            for (var index = 0; index < testSource.Length; index++)
            {
                testSource[index] = random.Next(int.MinValue, int.MaxValue);
            }

            var testResult = (int[])testSource.Clone();
            Array.Sort(testResult);

            return new ValueTuple<int[], int[]>(testSource, testResult);
        }
    }
}
