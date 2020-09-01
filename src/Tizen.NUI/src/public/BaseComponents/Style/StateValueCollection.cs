/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// The StateValueCollection class, which is related by <see cref="ControlState"/>, it is abstract class for <see cref="Selector{T}"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract class StateValueCollection<T> : ICollection<StateValuePair<T>>
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal List<StateValuePair<T>> StateValueList { get; } = new List<StateValuePair<T>>();

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Count => StateValueList.Count;

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsReadOnly => ((ICollection<StateValuePair<T>>)StateValueList).IsReadOnly;

        /// <summary>
        /// Add a <see cref="StateValuePair{T}"/> with state and value.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="value">The value associated with state.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Add(ControlState state, T value) => Add(new StateValuePair<T>(state, value));

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Add(StateValuePair<T> item)
        {
            // To prevent a state from having multiple values, remove existing state-value pair.
            int index = StateValueList.FindIndex(x => x.State == item.State);
            if (index != -1)
                StateValueList.RemoveAt(index);

            StateValueList.Add(item);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void Clear() => StateValueList.Clear();

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Contains(StateValuePair<T> item) => StateValueList.Contains(item);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CopyTo(StateValuePair<T>[] array, int arrayIndex) => StateValueList.CopyTo(array, arrayIndex);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Remove(StateValuePair<T> item) => StateValueList.Remove(item);

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IEnumerator<StateValuePair<T>> GetEnumerator() => StateValueList.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => StateValueList.GetEnumerator();

        /// <summary>
        /// Searches for a StateValuePair that matches the conditions defined by the specified
        /// predicate, and returns the first occurrence within the entire <see cref="StateValueList"/>
        /// </summary>
        /// <param name="match">The <see cref="Predicate{T}"/> delegate that defines the conditions of the element to search for.</param>
        /// <returns>The first element that matches the conditions defined by the specified predicate,
        /// if found; otherwise, the default value for type <see cref="StateValuePair{T}"/>.</returns>
        public StateValuePair<T> Find(Predicate<StateValuePair<T>> match) => StateValueList.Find(match);

        /// <summary>
        /// Add a <see cref="StateValuePair{T}"/> without duplication check.
        /// </summary>
        /// <param name="item">The StateValuePair item to add.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void AddWithoutCheck(StateValuePair<T> item) => StateValueList.Add(item);
    }
}