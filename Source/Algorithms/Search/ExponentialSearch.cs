﻿/* 
 * Copyright (c) 2019 (PiJei) 
 * 
 * This file is part of CSFundamentalAlgorithms project.
 *
 * CSFundamentalAlgorithms is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * CSFundamentalAlgorithms is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with CSFundamentals.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using CSFundamentals.Styling;

namespace CSFundamentals.Algorithms.Search
{
    public class ExponentialSearch
    {
        /// <summary>
        /// Implements exponential search, where the search step is a multiple of 2, hence the naming. 
        /// Notice that only works if the given array is sorted. 
        /// </summary>
        /// <param name="values">A sorted list of any comparable type. </param>
        /// <param name="searchValue">Specifies the value that is being searched for. </param>
        /// <returns>The index of the <paramref name="searchValue"/> in the array, and -1 if it does not exist in the array. </returns>
        [Algorithm(AlgorithmType.Search, "ExponentialSearch", Assumptions = "Array is sorted with an ascending order.")]
        [SpaceComplexity("O(1)", InPlace = true)]
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(log(i)), i is the index of the searchValue in the array.")]
        [TimeComplexity(Case.Average, "O(log(i)), i is the index of the searchValue in the array.")]
        public static int Search<T>(List<T> values, T searchValue) where T : IComparable<T>
        {
            if (searchValue.CompareTo(values[0]) >= 0 &&
                searchValue.CompareTo(values[values.Count - 1]) <= 0) /* Check whether searchValue is in the range. Since the input array is sorted this is feasible. */
            {
                if (values[0].CompareTo(searchValue) == 0)
                {
                    return 0;
                }

                int nextIndex = 1; /* Ideally should start from index 1, however that would make the while loop indexing complex, thus treating index 0 differently, and then continuing with the rest. */
                while (nextIndex < values.Count && values[nextIndex].CompareTo(searchValue) < 0) /* multiple the search step by 2, until encountering an element that is bigger than the searchValue*/
                {
                    nextIndex = nextIndex * 2;
                }

                /* The range at which the searchValue is expected to be is thus [nextIndex/2, nextIndex] - perform a binary search in this range. */
                return BinarySearch.Search(values, nextIndex / 2, Math.Min(nextIndex, values.Count - 1), searchValue);
            }
            return -1;
        }
    }
}
