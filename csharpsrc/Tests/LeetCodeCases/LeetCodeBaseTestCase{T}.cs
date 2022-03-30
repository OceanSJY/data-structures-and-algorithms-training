// <copyright file="LeetCodeBaseTestCase{T}.cs" company="Ocean">
// Copyright (c) Ocean. All rights reserved.
// </copyright>

namespace Tests.LeetCodeCases
{
    /// <summary>
    /// The base test class which required generic output value.
    /// </summary>
    /// <typeparam name="T">The data type of return result.</typeparam>
    public abstract class LeetCodeBaseTestCase<T>
    {
        /// <summary>
        /// Gets the result from solution.
        /// </summary>
        /// <returns>The result from solution.</returns>
        public abstract T GetResultFromSolution();

        /// <summary>
        /// Gets the result from official answer.
        /// </summary>
        /// <returns>The result from official answer.</returns>
        public abstract T GetResultFromOfficialAnswer();
    }
}
