// <copyright file="SortingTestCase.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.AlgorithmsCases
{
    using System;
    using System.Linq;
    using Algorithms.SortingHelpers;
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
        /// Verifies the bubble sort algorithm whether it is correct.
        /// </summary>
        [TestMethod]
        public void VerifyResultFromBubbleSortAlgorithm()
        {
            var (testSource, expectedResult) = PrepareTestSourceAndResult();
            var actualResult = testSource.BubbleSort((element1, element2) => element1 > element2);

            Assert.IsTrue(actualResult.SequenceEqual(expectedResult));
        }

        /// <summary>
        /// Verifies the merging sort algorithm whether it is correct.
        /// </summary>
        [TestMethod]
        public void VerifyResultFromMergingSortAlgorithm()
        {
            var (testSource, expectedResult) = PrepareTestSourceAndResult();
            var actualResult = testSource.MergingSort((element1, element2) => element1 > element2);

            Assert.IsTrue(actualResult.SequenceEqual(expectedResult));
        }

        /// <summary>
        /// Verifies the quick sort algorithm whether it is correct.
        /// </summary>
        [TestMethod]
        public void VerifyResultFromQuickSortAlgorithm()
        {
            var (testSource, expectedResult) = PrepareTestSourceAndResult();
            var actualResult = testSource.QuickSort((element1, element2) => element1 > element2);

            Assert.IsTrue(actualResult.SequenceEqual(expectedResult));
        }

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
