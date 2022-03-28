// <copyright file="SolutionB.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Questions.LeetCode.No4.MedianOfTwoSortedArrays
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The solution B of LeetCode No.4 question: Median of Two Sorted Arrays.
    /// </summary>
    public class SolutionB : Solution
    {
        /// <inheritdoc />
        public override double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (this.TryFindMedian(nums1, nums2, out var medianValue))
            {
                return medianValue;
            }

            var mergedSortedArray = MergeAndSortTwoArrays(nums1, nums2);

            return this.CalculateMedian(mergedSortedArray);
        }

        /// <summary>
        /// Merges and sorts two arrays.
        /// </summary>
        /// <param name="nums1">The first num array.</param>
        /// <param name="nums2">The second num array.</param>
        /// <returns>The merged and sorted array.</returns>
        private static int[] MergeAndSortTwoArrays(IReadOnlyList<int> nums1, IReadOnlyList<int> nums2)
        {
            var mergedNums = new List<int>();
            var firstIndex = 0;
            var secondIndex = 0;

            while (mergedNums.Count < nums1.Count + nums2.Count)
            {
                if (firstIndex == nums1.Count && secondIndex < nums2.Count)
                {
                    mergedNums.AddRange(nums2.Skip(secondIndex));

                    break;
                }

                if (secondIndex == nums2.Count && firstIndex < nums1.Count)
                {
                    mergedNums.AddRange(nums1.Skip(firstIndex));

                    break;
                }

                if (nums1[firstIndex] < nums2[secondIndex])
                {
                    mergedNums.Add(nums1[firstIndex]);
                    firstIndex++;
                }
                else
                {
                    mergedNums.Add(nums2[secondIndex]);
                    secondIndex++;
                }
            }

            return mergedNums.ToArray();
        }
    }
}
