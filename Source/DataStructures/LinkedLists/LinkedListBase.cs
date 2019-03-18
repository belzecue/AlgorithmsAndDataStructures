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
using System.Text;

namespace CSFundamentals.DataStructures.LinkedLists
{
    public abstract class LinkedListBase<T, T1> where T : ILinkedListNode<T, T1> where T1 : IComparable<T1>
    {
        /// <summary>
        /// Is the first node in the list. 
        /// </summary>
        public T Head { get; set; }

        public abstract bool Insert(T1 newValue);
        public abstract bool Delete(T1 alue);
        public abstract T Search(T1 alue);

    }
}
