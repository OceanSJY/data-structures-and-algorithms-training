// <copyright file="BubbleSortHelper.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Algorithms.SortingHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The bubble sort helper.
    /// </summary>
    public static class BubbleSortHelper
    {
        /// <summary>
        /// Sorts the elements in source collection by bubble algorithm.
        /// </summary>
        /// <typeparam name="T">The data type of each element in source.</typeparam>
        /// <param name="source">The source collection.</param>
        /// <param name="comparator">The comparator to determine how to sort.</param>
        /// <returns>The sorted result.</returns>
        public static IEnumerable<T> BubbleSort<T>(this IEnumerable<T> source, Func<T, T, bool> comparator)
        {
            if (BaseSortHelper.TrySort(source, comparator, out var sortedResult))
            {
                return sortedResult;
            }

            var sourceArray = source.ToArray();

            for (var index = 0; index < sourceArray.Length; index++)
            {
                var hasElementSwitched = false;

                for (var subIndex = 0; subIndex < sourceArray.Length - index - 1; subIndex++)
                {
                    if (!comparator(sourceArray[subIndex], sourceArray[subIndex + 1]))
                    {
                        continue;
                    }

                    (sourceArray[subIndex], sourceArray[subIndex + 1]) = (sourceArray[subIndex + 1], sourceArray[subIndex]);
                    hasElementSwitched = true;
                }

                if (!hasElementSwitched)
                {
                    break;
                }
            }

            return sourceArray;
        }
    }
}
