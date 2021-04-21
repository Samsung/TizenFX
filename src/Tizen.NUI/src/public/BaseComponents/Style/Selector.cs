/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// The selector class is a collection of a <see cref="ControlState" /> and a T value pair.
    /// </summary>
    /// <typeparam name="T">The property type of the selector. If it's reference type, it is recommended to be a type implementing <see cref="ICloneable"/>.</typeparam>
    /// <since_tizen> 9 </since_tizen>
    [SuppressMessage("Microsoft.Naming",
                     "CA1710:IdentifiersShouldHaveCorrectSuffix",
                     Justification = "The name Selector provides meaningful information about the characteristics.")]
    public class Selector<T> : IEnumerable<SelectorItem<T>>
    {
        private readonly bool cloneable = typeof(ICloneable).IsAssignableFrom(typeof(T));
        private SelectorItem<T> all;

        /// <summary>
        /// The list for adding <see cref="SelectorItem{T}"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        List<SelectorItem<T>> SelectorItems { get; set; } = new List<SelectorItem<T>>();

        /// <summary>
        /// Implicitly convert T type value to selector.
        /// </summary>
        /// <param name="value">The value will be converted to a selector.</param>
        /// <since_tizen> 9 </since_tizen>
        public static implicit operator Selector<T>(T value)
        {
            return new Selector<T>(value);
        }

        /// <summary>
        /// Create an empty selector.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Selector()
        {
        }

        /// Constructor with T
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector(T value) : this()
        {
            All = value;
        }

        /// Copy constructor
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector(Selector<T> value) : this()
        {
            Clone(value);
        }

        /// <summary>
        /// All State.
        /// </summary>
        /// <remark> This is for XAML. Do not ACR this. </remark>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T All
        {
            get => all == null ? default(T) : all.Value;
            set => Add(ControlState.All, value);
        }

        /// <summary>
        /// Normal State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <exception cref="KeyNotFoundException">Thrown when the selector does not contain the this value.</exception>
        /// <remark> This is for XAML. Do not ACR this. </remark>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Normal
        {
            get => GetSafely(x => x.State == ControlState.Normal);
            set => Add(ControlState.Normal, value);
        }
        /// <summary>
        /// Pressed State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <exception cref="KeyNotFoundException">Thrown when the selector does not contain the this value.</exception>
        /// <remark> This is for XAML. Do not ACR this. </remark>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Pressed
        {
            get => GetSafely(x => x.State == ControlState.Pressed);
            set => Add(ControlState.Pressed, value);
        }
        /// <summary>
        /// Focused State.
        /// </summary>
        /// <remark> This is for XAML. Do not ACR this. </remark>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Focused
        {
            get => GetSafely(x => x.State == ControlState.Focused);
            set => Add(ControlState.Focused, value);
        }
        /// <summary>
        /// Selected State.
        /// </summary>
        /// <remark> This is for XAML. Do not ACR this. </remark>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Selected
        {
            get => GetSafely(x => x.State == ControlState.Selected);
            set => Add(ControlState.Selected, value);
        }
        /// <summary>
        /// Disabled State.
        /// </summary>
        /// <remark> This is for XAML. Do not ACR this. </remark>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Disabled
        {
            get => GetSafely(x => x.State == ControlState.Disabled);
            set => Add(ControlState.Disabled, value);
        }
        /// <summary>
        /// DisabledFocused State.
        /// </summary>
        /// <remark> This is for XAML. Do not ACR this. </remark>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T DisabledFocused
        {
            get => GetSafely(x => x.State == ControlState.DisabledFocused);
            set => Add(ControlState.DisabledFocused, value);
        }
        /// <summary>
        /// SelectedFocused State.
        /// </summary>
        /// <remark> This is for XAML. Do not ACR this. </remark>
        public T SelectedFocused
        {
            get => GetSafely(x => x.State == ControlState.SelectedFocused);
            set => Add(ControlState.SelectedFocused, value);
        }
        /// <summary>
        /// DisabledSelected State.
        /// </summary>
        /// <remark> This is for XAML. Do not ACR this. </remark>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T DisabledSelected
        {
            get => GetSafely(x => x.State == ControlState.DisabledSelected);
            set => Add(ControlState.DisabledSelected, value);
        }

        /// <summary>
        /// SelectedPressed State.
        /// </summary>
        /// <remark> This is for XAML. Do not ACR this. </remark>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T SelectedPressed
        {
            get => GetSafely(x => x.State == ControlState.SelectedPressed);
            set => Add(ControlState.SelectedPressed, value);
        }

        /// <summary>
        /// Other State.
        /// </summary>
        /// <remark> This is for XAML. Do not ACR this. </remark>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Other
        {
            get => GetSafely(x => x.State == ControlState.Other);
            set => Add(ControlState.Other, value);
        }

        /// <summary>
        /// Gets the number of elements.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Count => SelectorItems.Count;

        /// <summary>
        /// Gets a value indicating whether the selector is read-only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsReadOnly => false;

        /// <summary>
        /// Adds the specified state and value to the selector.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="value">The value associated with state.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Add(ControlState state, T value)
        {
            // To prevent a state from having multiple values, remove existing state-value pair.
            int index = SelectorItems.FindIndex(x => x.State == state);
            if (index != -1)
            {
                SelectorItems.RemoveAt(index);
            }

            var item = new SelectorItem<T>(state, value);
            SelectorItems.Add(item);

            if (state == ControlState.All)
            {
                all = item;
            }
        }

        /// <summary>
        /// Adds the specified state and value to the selector.
        /// </summary>
        /// <param name="item">The selector item includes state and value.</param>
        /// <exception cref="ArgumentNullException"> Thrown when item is null. </exception>
        /// <since_tizen> 9 </since_tizen>
        public void Add(SelectorItem<T> item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            // To prevent a state from having multiple values, remove existing state-value pair.
            int index = SelectorItems.FindIndex(x => x.State == item.State);
            if (index != -1)
            {
                SelectorItems.RemoveAt(index);
            }

            SelectorItems.Add(item);

            if (item.State == ControlState.All)
            {
                all = item;
            }
        }

        /// <summary>
        /// Remove an item from the selector.
        /// </summary>
        /// <param name="item">The selector item includes state and value.</param>
        /// <exception cref="ArgumentNullException"> Thrown when item is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Remove(SelectorItem<T> item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            int index = SelectorItems.FindIndex(x => x.State == item.State);
            if (index != -1)
            {
                if (EqualsItem(item.Value, SelectorItems[index].Value))
                {
                    SelectorItems.RemoveAt(index);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether the selector contains a specific value.
        /// </summary>
        /// <param name="item">The selector item includes state and value.</param>
        /// <returns>True if item is found in the selector. otherwise, false.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when item is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Contains(SelectorItem<T> item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            int index = SelectorItems.FindIndex(x => x.State == item.State);
            return index != -1 && EqualsItem(item.Value, SelectorItems[index].Value);
        }

        /// <summary>
        /// Copies the elements of the selector to an Array, starting at a particular Array index.
        /// </summary>
        /// <param name="items">The one-dimensional array that is the destination of the elements copied from selector. The Array must have zero-based indexing.</param>
        /// <param name="startIndex">The zero-based index in array at which copying begins.</param>
        /// <exception cref="ArgumentNullException"> Thrown when the items is null. </exception>
        /// <exception cref="ArgumentException"> Thrown when the startIndex is not valid. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void CopyTo(SelectorItem<T>[] items, int startIndex)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            if (startIndex < 0) throw new ArgumentException($"{nameof(startIndex)} can not be negative.");

            for (int i = startIndex, j = 0; i < SelectorItems.Count; i++, j++)
            {
                var item = SelectorItems[i];
                items[j] = new SelectorItem<T>(item.State, item.Value);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <return> An enumerator that can be used to iterate through the collection. </return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IEnumerator<SelectorItem<T>> GetEnumerator()
        {
            return SelectorItems.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <return> An IEnumerator object that can be used to iterate through the collection. </return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Get value by State.
        /// It will traverse from the first item to find proper fit when there is no perfect state match.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when state is null. </exception>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        /// <returns>True if the selector has a given state value, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GetValue(ControlState state, out T result)
        {
            if (state == null) throw new ArgumentNullException(nameof(state));

            if (all != null)
            {
                result = all.Value;
                return true;
            }

            result = default;

            int index = SelectorItems.FindIndex(x => x.State == state);
            if (index >= 0)
            {
                result = SelectorItems[index].Value;
                return true;
            }

            if (null == state)
            {
                throw new ArgumentNullException(nameof(state));
            }
            if (state.IsCombined)
            {
                index = SelectorItems.FindIndex(x => state.Contains(x.State));
                if (index >= 0)
                {
                    result = SelectorItems[index].Value;
                    return true;
                }
            }

            index = SelectorItems.FindIndex(x => x.State == ControlState.Other);
            if (index >= 0)
            {
                result = SelectorItems[index].Value;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes all elements.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Clear()
        {
            all = null;
            SelectorItems.Clear();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            string result = $"[All, {All}]";

            foreach (var item in SelectorItems)
            {
                result += $", {item}";
            }

            return result;
        }

        /// <summary>
        /// Clone itself.
        /// If type T implements ICloneable, it calls Clone() method to clone values, otherwise use operator=.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<T> Clone()
        {
            var cloned = new Selector<T>();
            cloned.Clone(this);
            return cloned;
        }

        /// <summary>
        /// Clone with type converter.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when converter is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<TOut> Clone<TOut>(Converter<T, TOut> converter)
        {
            if (converter == null) throw new ArgumentNullException(nameof(converter));

            Selector<TOut> result = new Selector<TOut>();            
            result.SelectorItems = SelectorItems.ConvertAll<SelectorItem<TOut>>(m => new SelectorItem<TOut>(m.State, converter(m.Value)));
            UpdateAllLink();

            return result;
        }

        /// <summary>
        /// Copy values from other selector.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when other is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Clone(Selector<T> other)
        {
            if (null == other)
            {
                throw new ArgumentNullException(nameof(other));
            }

            if (cloneable)
            {
                SelectorItems = other.SelectorItems.ConvertAll(m => new SelectorItem<T>(m.State, (T)((ICloneable)m.Value)?.Clone()));
            }
            else
            {
                SelectorItems = other.SelectorItems.ConvertAll(m => m);
            }

            UpdateAllLink();
        }

        private bool EqualsItem(T a, T b)
        {
            return Object.ReferenceEquals(a, b) || (a != null && a.Equals(b));
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public override bool Equals(object other)
        {
            var x = other as Selector<T>;

            if (x == null || x.SelectorItems.Count != SelectorItems.Count)
            {
                return false;
            }

            if (!EqualsItem(All, x.All))
            {
                return false;
            }

            foreach (var item in SelectorItems)
            {
                var found = SelectorItems.Find(i => i.State == item.State);

                if (found == null || !EqualsItem(item.Value, found.Value))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            int hash = 17;
            hash = (hash * 23) + (All == null ? 0 : All.GetHashCode());
            hash = (hash * 23) + SelectorItems.Count;
            
            // Order of items should not effect to the result value.
            int itemSum = 0;
            foreach (var item in SelectorItems)
            {
                itemSum += item.State.GetHashCode() + (item.Value == null ? 0 : item.Value.GetHashCode());
            }

            return (hash * 23) + itemSum;
        }

        internal bool HasAll()
        {
            return all != null;
        }

        internal void AddWithoutDuplicationCheck(ControlState state, T value)
        {
            var item = new SelectorItem<T>(state, value);
            SelectorItems.Add(item);

            if (state == ControlState.All)
            {
                all = item;
            }
        }

        private T GetSafely(System.Predicate<SelectorItem<T>> match)
        {
            var item = SelectorItems.Find(match);
            return item == null ? default(T) : item.Value;
        }

        private void UpdateAllLink()
        {
            int index = SelectorItems.FindIndex(x => x.State == ControlState.All);
            if (index >= 0)
            {
                all = SelectorItems[index];   
            }
            else
            {
                all = null;
            }
        }
    }

    /// <summary>
    /// This will be attached to a View to detect ControlState change.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TriggerableSelector<T>
    {
        private readonly Action<T> targetPropertySetter;
        private Selector<T> selector;

        /// <summary>
        /// Create an TriggerableSelector.
        /// </summary>
        /// <param name="view">The View that is affected by this TriggerableSelector.</param>
        /// <param name="selector">The selector value.</param>
        /// <param name="targetPropertySetter">The TriggerableSelector will call this setter when the view's ControlState has changed.</param>
        /// <param name="updateView">Whether it updates the target view after create a instance.</param>
        /// <exception cref="ArgumentNullException"> Thrown when given argument is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TriggerableSelector(View view, Selector<T> selector, Action<T> targetPropertySetter, bool updateView = false)
        {
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }

            this.selector = selector ?? throw new ArgumentNullException(nameof(selector));
            this.targetPropertySetter = targetPropertySetter ?? throw new ArgumentNullException(nameof(targetPropertySetter));

            if (!selector.HasAll())
            {
                view.ControlStateChangeEventInternal += OnViewControlState;
            }

            if (updateView && selector.GetValue(view.ControlState, out var value))
            {
                targetPropertySetter.Invoke(value);
            }
        }

        /// <summary>
        /// Return the containing selector. It can be null.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<T> Get() => selector;

        /// <summary>
        /// Reset selector and listeners.
        /// </summary>
        /// <param name="view">The View that is affected by this TriggerableSelector.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Reset(View view)
        {
            if (selector == null)
            {
                return;
            }

            if (view != null)
            {
                view.ControlStateChangeEventInternal -= OnViewControlState;
            }
            selector = null;
        }

        private void OnViewControlState(object obj, View.ControlStateChangedEventArgs controlStateChangedInfo)
        {
            View view = obj as View;
            if (null != view && selector.GetValue(controlStateChangedInfo.CurrentState, out var value))
            {
                targetPropertySetter.Invoke(value);
            }
        }
    }

    /// <summary>
    /// The selector item class that stores a control state and a T value pair.
    /// </summary>
    /// <typeparam name="T">The property type of the selector.</typeparam>
    /// <since_tizen> 9 </since_tizen>
    public class SelectorItem<T>
    {
        /// <summary>
        /// The default constructor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SelectorItem() { }

        /// <summary>
        /// The constructor with the specified state and value.
        /// </summary>
        /// <param name="state">The state</param>
        /// <param name="value">The value associated with state.</param>
        /// <since_tizen> 9 </since_tizen>
        public SelectorItem(ControlState state, T value)
        {
            State = state;
            Value = value;
        }

        /// <summary>
        /// The control state.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public ControlState State { get; internal set; }

        /// <summary>
        /// The value associated with control state.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public T Value { get; internal set; }

        ///  <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => $"[{State}, {Value}]";
    }

    /// <summary>
    /// Extension class for <see cref="Selector{T}"/>.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class SelectorExtensions
    {
        /// <summary>
        /// Adds the specified state and value to the <see cref="Selector{T}.SelectorItems"/>.
        /// </summary>
        /// <param name="list">The list for adding state-value pair.</param>
        /// <param name="state">The state.</param>
        /// <param name="value">The value associated with state.</param>
        /// <exception cref="ArgumentNullException"> Thrown when given list is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Add<T>(this IList<SelectorItem<T>> list, ControlState state, T value)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));

            list.Add(new SelectorItem<T>(state, value));
        }
    }
}
