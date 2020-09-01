/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// Selector class, which is related by Control State, it is base class for other Selector.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Selector<T> : StateValueCollection<T>
    {
        private readonly bool isSelectorItem = typeof(ISelectorItem).IsAssignableFrom(typeof(T));

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
            All = isSelectorItem ? (T)((ISelectorItem)value)?.Clone() : value;
        }

        /// Copy constructor
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector(Selector<T> value) : this()
        {
            Clone(value);
        }

        internal Selector(SelectorChangedCallback<T> cb) : this()
        {
            callback = cb;
        }

        internal Selector(SelectorChangedCallback<T> cb, T value) : this(value)
        {
            callback = cb;
        }

        internal Selector(SelectorChangedCallback<T> cb, Selector<T> value) : this(value)
        {
            callback = cb;
        }

        internal delegate void SelectorChangedCallback<T>(Selector<T> value);
        private SelectorChangedCallback<T> callback = null;

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
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Normal
        {
            get
            {
                return Find(x => x.State == ControlState.Normal).Value;
            }
            set
            {
                Add(ControlState.Normal, value);
                callback?.Invoke(this);
            }
        }
        /// <summary>
        /// Pressed State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Pressed
        {
            get
            {
                return Find(x => x.State == ControlState.Pressed).Value;
            }
            set
            {
                Add(ControlState.Pressed, value);
                callback?.Invoke(this);
            }
        }
        /// <summary>
        /// Focused State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Focused
        {
            get
            {
                return Find(x => x.State == ControlState.Focused).Value;
            }
            set
            {
                Add(ControlState.Focused, value);
                callback?.Invoke(this);
            }
        }
        /// <summary>
        /// Selected State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Selected
        {
            get
            {
                return Find(x => x.State == ControlState.Selected).Value;
            }
            set
            {
                Add(ControlState.Selected, value);
                callback?.Invoke(this);
            }
        }
        /// <summary>
        /// Disabled State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Disabled
        {
            get
            {
                return Find(x => x.State == ControlState.Disabled).Value;
            }
            set
            {
                Add(ControlState.Disabled, value);
                callback?.Invoke(this);
            }
        }
        /// <summary>
        /// DisabledFocused State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T DisabledFocused
        {
            get
            {
                return Find(x => x.State == ControlState.DisabledFocused).Value;
            }
            set
            {
                Add(ControlState.DisabledFocused, value);
                callback?.Invoke(this);
            }
        }
        /// <summary>
        /// SelectedFocused State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        public T SelectedFocused
        {
            get
            {
                return Find(x => x.State == ControlState.SelectedFocused).Value;
            }
            set
            {
                Add(ControlState.SelectedFocused, value);
                callback?.Invoke(this);
            }
        }
        /// <summary>
        /// DisabledSelected State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T DisabledSelected
        {
            get
            {
                return Find(x => x.State == ControlState.DisabledSelected).Value;
            }
            set
            {
                Add(ControlState.DisabledSelected, value);
                callback?.Invoke(this);
            }
        }

        /// <summary>
        /// Other State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public T Other
        {
            get
            {
                return Find(x => x.State == ControlState.Other).Value;
            }
            set
            {
                Add(ControlState.Other, value);
                callback?.Invoke(this);
            }
        }
        /// <summary>
        /// Get value by State.
        /// </summary>
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

            result = default;

            int index = StateValueList.FindIndex(x => x.State == state);
            if (index >= 0)
            {
                result = StateValueList[index].Value;
                return true;
            }

            if (state.IsCombined)
            {
                index = StateValueList.FindIndex(x => state.Contains(x.State));
                if (index >= 0)
                {
                    result = StateValueList[index].Value;
                    return true;
                }
            }

            index = StateValueList.FindIndex(x => x.State == ControlState.Other);
            if (index >= 0)
            {
                result = StateValueList[index].Value;
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Clear()
        {
            All = default;
            base.Clear();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            string result = $"[All, {All}]";

            foreach (var item in StateValueList)
            {
                result += $", {item}";
            }

            return result;
        }

        /// <summary>
        /// Clone itself.
        /// If type T implements ISelectorItem, it calls Clone() method to clone values, otherwise use operator=.
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
        /// Copy values from other selector.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Clone(Selector<T> other)
        {
            Clear();

            if (isSelectorItem)
            {
                All = (T)((ISelectorItem)other.All)?.Clone();
                foreach (var item in other.StateValueList)
                {
                    AddWithoutCheck(new StateValuePair<T>(item.State, (T)((ISelectorItem)item.Value)?.Clone()));
                }
            }
            else
            {
                All = other.All;
                foreach (var item in other.StateValueList)
                {
                    AddWithoutCheck(item);
                }
            }
        }

        internal bool HasMultiValue()
        {
            return StateValueList.Count > 1;
        }
    }

    /// <summary>
    /// This will be attached to a View to detect ControlState change.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TriggerableSelector<T>
    {
        /// <summary>
        /// Create an TriggerableSelector.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate T ValueGetter(View view);

        private readonly BindableProperty targetBindableProperty;
        private readonly ValueGetter propertyGetter;
        private bool dirty = true;
        private Selector<T> selector;

        /// <summary>
        /// Create an TriggerableSelector.
        /// </summary>
        /// <param name="targetBindableProperty">The TriggerableSelector will change this bindable property value when the view's ControlState has changed.</param>
        /// <param name="propertyGetter">It is optional value in case the target bindable property getter is not proper to use.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TriggerableSelector(BindableProperty targetBindableProperty, ValueGetter propertyGetter = null)
        {
            this.targetBindableProperty = targetBindableProperty;
            this.propertyGetter = propertyGetter;
        }

        /// <summary>
        /// Return the containing selector. It can be null.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<T> Get(View view)
        {
            if (!dirty) return selector;

            T value = default;

            if (propertyGetter != null)
            {
                value = propertyGetter(view);
            }
            else
            {
                value = (T)view.GetValue(targetBindableProperty);
            }

            Selector<T> converted = value == null ? null : new Selector<T>(value);
            Update(view, converted);

            return selector;
        }

        /// <summary>
        /// Update containing selector from the other selector.
        /// </summary>
        /// <param name="view">The View that is affected by this TriggerableSelector.</param>
        /// <param name="otherSelector">The copy target.</param>
        /// <param name="updateView">Whether it updates the target view after update the selector or not.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Update(View view, Selector<T> otherSelector, bool updateView = false)
        {
            Reset(view);

            if (otherSelector == null)
            {
                return;   
            }

            selector = otherSelector.Clone();

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
        /// Update containing selector value from a single value.
        /// Note that, it updates lazily if possible.
        /// If you need to udpate directly, please use <seealso cref="Update" />.
        /// </summary>
        /// <param name="view">The View that is affected by this TriggerableSelector.</param>
        /// <param name="value">The copy target.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void UpdateIfNeeds(View view, T value)
        {
            if (selector != null && selector.HasMultiValue())
            {
                Selector<T> converted = value == null ? null : new Selector<T>(value);
                Update(view, converted);
                return;
            }

            dirty = true;
        }

        /// <summary>
        /// Reset selector and listeners.
        /// </summary>
        /// <param name="view">The View that is affected by this TriggerableSelector.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Reset(View view)
        {
            view.ControlStateChangeEventInternal -= OnViewControlState;
            selector?.Clear();
            selector = null;
            dirty = false;
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
}
