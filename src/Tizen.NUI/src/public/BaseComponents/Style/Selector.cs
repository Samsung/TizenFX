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
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// Selector class, which is related by Control State, it is base class for other Selector.
    /// </summary>
    /// <typeparam name="T">The property type of the selector. if it's reference type, it should be of type <see cref="ICloneable"/> that implement deep copy in <see cref="ICloneable.Clone"/>.</typeparam>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Selector<T>
    {
        private readonly bool cloneable = typeof(ICloneable).IsAssignableFrom(typeof(T));

        /// <summary>
        /// The list for adding <see cref="SelectorItem{T}"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        List<SelectorItem<T>> SelectorItems { get; set; } = new List<SelectorItem<T>>();

        /// <summary>
        /// Adds the specified state and value to the <see cref="SelectorItems"/>.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="value">The value associated with state.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Add(ControlState state, T value)
        {
            if (state == ControlState.All)
            {
                All = value;
                return;
            }

            // To prevent a state from having multiple values, remove existing state-value pair.
            int index = SelectorItems.FindIndex(x => x.State == state);
            if (index != -1)
                SelectorItems.RemoveAt(index);

            SelectorItems.Add(new SelectorItem<T>(state, value));
            All = default;
        }

        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        public static implicit operator Selector<T>(T value)
        {
            return new Selector<T>(value);
        }

        /// Default Contructor
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector()
        {
        }

        /// Contructor with T
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector(T value) : this()
        {
            All = cloneable ? (T)((ICloneable)value)?.Clone() : value;
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
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T All
        {
            get;
            set;
        }

        /// <summary>
        /// Normal State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <exception cref="KeyNotFoundException">Thrown when the selector does not contain the this value.</exception>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Normal
        {
            get => GetOrThrowKeyNotFound(x => x.State == ControlState.Normal);
            set => Add(ControlState.Normal, value);
        }
        /// <summary>
        /// Pressed State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <exception cref="KeyNotFoundException">Thrown when the selector does not contain the this value.</exception>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Pressed
        {
            get => GetOrThrowKeyNotFound(x => x.State == ControlState.Pressed);
            set => Add(ControlState.Pressed, value);
        }
        /// <summary>
        /// Focused State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <exception cref="KeyNotFoundException">Thrown when the selector does not contain the this value.</exception>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Focused
        {
            get => GetOrThrowKeyNotFound(x => x.State == ControlState.Focused);
            set => Add(ControlState.Focused, value);
        }
        /// <summary>
        /// Selected State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <exception cref="KeyNotFoundException">Thrown when the selector does not contain the this value.</exception>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Selected
        {
            get => GetOrThrowKeyNotFound(x => x.State == ControlState.Selected);
            set => Add(ControlState.Selected, value);
        }
        /// <summary>
        /// Disabled State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <exception cref="KeyNotFoundException">Thrown when the selector does not contain the this value.</exception>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Disabled
        {
            get => GetOrThrowKeyNotFound(x => x.State == ControlState.Disabled);
            set => Add(ControlState.Disabled, value);
        }
        /// <summary>
        /// DisabledFocused State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <exception cref="KeyNotFoundException">Thrown when the selector does not contain the this value.</exception>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T DisabledFocused
        {
            get => GetOrThrowKeyNotFound(x => x.State == ControlState.DisabledFocused);
            set => Add(ControlState.DisabledFocused, value);
        }
        /// <summary>
        /// SelectedFocused State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <exception cref="KeyNotFoundException">Thrown when the selector does not contain the this value.</exception>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        public T SelectedFocused
        {
            get => GetOrThrowKeyNotFound(x => x.State == ControlState.SelectedFocused);
            set => Add(ControlState.SelectedFocused, value);
        }
        /// <summary>
        /// DisabledSelected State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <exception cref="KeyNotFoundException">Thrown when the selector does not contain the this value.</exception>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T DisabledSelected
        {
            get => GetOrThrowKeyNotFound(x => x.State == ControlState.DisabledSelected);
            set => Add(ControlState.DisabledSelected, value);
        }

        /// <summary>
        /// Other State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <exception cref="KeyNotFoundException">Thrown when the selector does not contain the this value.</exception>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Other
        {
            get => GetOrThrowKeyNotFound(x => x.State == ControlState.Other);
            set => Add(ControlState.Other, value);
        }

        /// <summary>
        /// Gets the number of elements.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Count => SelectorItems.Count;

        /// <summary>
        /// Get value by State.
        /// </summary>
        /// <exception cref="ArgumentNullException"> Thrown when state is null. </exception>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        /// <returns>True if the selector has a given state value, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GetValue(ControlState state, out T result)
        {
            if (All != null)
            {
                result = All;

                return true;
            }

            if (state == null)
                throw new ArgumentNullException(nameof(state));

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
            All = default;
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
            result.All = converter(All);
            result.SelectorItems = SelectorItems.ConvertAll<SelectorItem<TOut>>(m => new SelectorItem<TOut>(m.State, converter(m.Value)));

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
                All = (T)((ICloneable)other.All)?.Clone();
                SelectorItems = other.SelectorItems.ConvertAll(m => new SelectorItem<T>(m.State, (T)((ICloneable)m.Value)?.Clone()));
            }
            else
            {
                All = other.All;
                SelectorItems = other.SelectorItems.ConvertAll(m => m);
            }
        }

        internal bool HasMultiValue()
        {
            return SelectorItems.Count > 1;
        }

        internal void AddWithoutDuplicationCheck(ControlState state, T value)
        {
            if (state == ControlState.All)
            {
                All = value;
                return;
            }
            SelectorItems.Add(new SelectorItem<T>(state, value));
        }

        private T GetOrThrowKeyNotFound(System.Predicate<SelectorItem<T>> match)
        {
            var item = SelectorItems.Find(match);
            if (item == null)
            {
                throw new KeyNotFoundException("The selector does not contain this value.");
            }
            return item.Value;
        }
    }

    /// <summary>
    /// This will be attached to a View to detect ControlState change.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TriggerableSelector<T>
    {
        private readonly BindableProperty targetBindableProperty;
        private Selector<T> selector;

        /// <summary>
        /// Create an TriggerableSelector.
        /// </summary>
        /// <param name="targetBindableProperty">The TriggerableSelector will change this bindable property value when the view's ControlState has changed.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TriggerableSelector(BindableProperty targetBindableProperty)
        {
            this.targetBindableProperty = targetBindableProperty;
        }

        /// <summary>
        /// Return the containing selector. It can be null.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<T> Get() => selector;

        /// <summary>
        /// Update containing selector from the other selector.
        /// </summary>
        /// <param name="view">The View that is affected by this TriggerableSelector.</param>
        /// <param name="otherSelector">The copy target.</param>
        /// <param name="updateView">Whether it updates the target view after update the selector or not.</param>
        /// <exception cref="ArgumentNullException"> Thrown when view is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Update(View view, Selector<T> otherSelector, bool updateView = false)
        {
            Reset(view);

            if (null == view)
            {
                throw new ArgumentNullException(nameof(view));
            }

            if (otherSelector == null)
            {
                return;
            }

            selector = otherSelector;

            if (otherSelector.HasMultiValue())
            {
                view.ControlStateChangeEventInternal += OnViewControlState;
            }

            if (updateView && otherSelector.GetValue(view.ControlState, out var value))
            {
                view.SetValue(targetBindableProperty, value);
            }
        }

        /// <summary>
        /// Reset selector and listeners.
        /// </summary>
        /// <param name="view">The View that is affected by this TriggerableSelector.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Reset(View view)
        {
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
                view.SetValue(targetBindableProperty, value);
            }
        }
    }

    /// <summary>
    /// The selector item class that stores a state-value pair.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SelectorItem(ControlState state, T value)
        {
            State = state;
            Value = value;
        }

        /// <summary>
        /// The state
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ControlState State { get; set; }

        /// <summary>
        /// The value associated with state.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Value { get; set; }

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
