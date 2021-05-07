/*
 * Copyright(c) 2020-2021 Samsung Electronics Co., Ltd.
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
using System.Linq;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// Class for describing the states of control.
    /// If a non-control view class would want to get the control state, please refer <see cref="View.EnableControlState"/>.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    [Binding.TypeConverter(typeof(ControlStateTypeConverter))]
    public class ControlState : IEquatable<ControlState>
    {
        private static readonly Dictionary<string, ControlState> stateDictionary = new Dictionary<string, ControlState>();
        //Default States
        /// <summary>
        /// The All state is used in a selector class. It represents all states, so if this state is defined in a selector, the other states are ignored.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static readonly ControlState All = Create("All");
        /// <summary>
        /// Normal State.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static readonly ControlState Normal = Create("Normal");
        /// <summary>
        /// Focused State.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static readonly ControlState Focused = Create("Focused");
        /// <summary>
        /// Pressed State.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static readonly ControlState Pressed = Create("Pressed");
        /// <summary>
        /// Disabled State.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static readonly ControlState Disabled = Create("Disabled");
        /// <summary>
        /// Selected State.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static readonly ControlState Selected = Create("Selected");
        /// <summary>
        /// SelectedPressed State.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly ControlState SelectedPressed = Selected + Pressed;
        /// <summary>
        /// DisabledSelected State.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly ControlState DisabledSelected = Disabled + Selected;
        /// <summary>
        /// DisabledFocused State.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly ControlState DisabledFocused = Disabled + Focused;
        /// <summary>
        /// SelectedFocused State.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly ControlState SelectedFocused = Selected + Focused;
        /// <summary>
        /// This is used in a selector class. It represents all other states except for states that are already defined in a selector.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static readonly ControlState Other = Create("Other");

        private List<ControlState> stateList = new List<ControlState>();
        private readonly string name = "";

        /// <summary>
        /// Gets or sets a value indicating whether it has combined states.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsCombined => stateList.Count > 1;

        private ControlState() { }

        private ControlState(string name) : this() => this.name = name;

        /// <summary>
        /// Create an instance of the <see cref="ControlState"/> with state name.
        /// </summary>
        /// <param name="name">The state name.</param>
        /// <returns>The <see cref="ControlState"/> instance which has single state.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given name is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the given name is invalid.</exception>
        /// <since_tizen> 9 </since_tizen>
        public static ControlState Create(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name cannot be empty string", nameof(name));

            name = name.Trim();

            if (stateDictionary.TryGetValue(name, out ControlState state))
                return state;

            state = new ControlState(name);
            state.stateList.Add(state);
            stateDictionary.Add(name, state);
            return state;
        }

        /// <summary>
        /// Create an instance of the <see cref="ControlState"/> with combined states.
        /// </summary>
        /// <param name="states">The control state array.</param>
        /// <returns>The <see cref="ControlState"/> instance which has combined state.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ControlState Create(params ControlState[] states)
        {
            if (states.Length == 1)
                return states[0];

            ControlState newState = new ControlState();
            for (int i = 0; i < states.Length; i++)
            {
                if (states[i] == Normal)
                    continue;

                if (states[i] == All)
                    return All;

                newState.stateList.AddRange(states[i].stateList);
            }

            if (newState.stateList.Count == 0)
                return Normal;

            newState.stateList = newState.stateList.Distinct().ToList();

            if (newState.stateList.Count == 1)
            {
                return newState.stateList[0];
            }

            return newState;
        }

        /// <summary>
        /// Determines whether a state contains a specified state.
        /// </summary>
        /// <param name="state">The state to search for</param>
        /// <returns>true if the state contain a specified state, otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given state is null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public bool Contains(ControlState state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state));

            if (!IsCombined)
                return ReferenceEquals(this, state);

            bool found;
            for (int i = 0; i < state.stateList.Count; i++)
            {
                found = false;
                for (int j = 0; j < stateList.Count; j++)
                {
                    if (ReferenceEquals(state.stateList[i], stateList[j]))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found) return false;
            }

            return true;
        }

        ///  <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(ControlState other)
        {
            if (other is null || stateList.Count != other.stateList.Count)
                return false;

            return Contains(other);
        }

        ///  <inheritdoc/>
        /// <since_tizen> 9 </since_tizen>
        public override bool Equals(object other) => this.Equals(other as ControlState);

        ///  <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => (name.GetHashCode() * 397) ^ IsCombined.GetHashCode();

        ///  <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            string name = "";
            for (int i = 0; i < stateList.Count; i++)
            {
                name += ((i == 0) ? "" : ", ") + stateList[i].name;
            }
            return name;
        }

        /// <summary>
        /// Compares whether the two ControlStates are same or not.
        /// </summary>
        /// <param name="lhs">A <see cref="ControlState"/> on the left hand side.</param>
        /// <param name="rhs">A <see cref="ControlState"/> on the right hand side.</param>
        /// <returns>true if the ControlStates are equal; otherwise, false.</returns>
        /// <since_tizen> 9 </since_tizen>
        public static bool operator ==(ControlState lhs, ControlState rhs)
        {
            // Check for null on left side.
            if (lhs is null)
            {
                if (rhs is null)
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Compares whether the two ControlStates are different or not.
        /// </summary>
        /// <param name="lhs">A <see cref="ControlState"/> on the left hand side.</param>
        /// <param name="rhs">A <see cref="ControlState"/> on the right hand side.</param>
        /// <returns>true if the ControlStates are not equal; otherwise, false.</returns>
        /// <since_tizen> 9 </since_tizen>
        public static bool operator !=(ControlState lhs, ControlState rhs) => !(lhs == rhs);

        /// <summary>
        /// The addition operator.
        /// </summary>
        /// <param name="lhs">A <see cref="ControlState"/> on the left hand side.</param>
        /// <param name="rhs">A <see cref="ControlState"/> on the right hand side.</param>
        /// <returns>The <see cref="ControlState"/> containing the result of the addition.</returns>
        /// <since_tizen> 9 </since_tizen>
        public static ControlState operator +(ControlState lhs, ControlState rhs) => Create(lhs, rhs);

        /// <summary>
        /// The substraction operator.
        /// </summary>
        /// <param name="lhs">A <see cref="ControlState"/> on the left hand side.</param>
        /// <param name="rhs">A <see cref="ControlState"/> on the right hand side.</param>
        /// <returns>The <see cref="ControlState"/> containing the result of the substraction.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when lhs or rhs is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ControlState operator -(ControlState lhs, ControlState rhs)
        {
            if (null == lhs)
            {
                throw new ArgumentNullException(nameof(lhs));
            }
            else if (null == rhs)
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            if (!lhs.IsCombined)
            {
                return ReferenceEquals(lhs, rhs) ? Normal : lhs;
            }

            var rest = lhs.stateList.Except(rhs.stateList);
            var count = rest.Count();

            if (count == 0)
            {
                return Normal;
            }

            if (count == 1)
            {
                return rest.First();
            }

            ControlState newState = new ControlState();
            newState.stateList.AddRange(rest);
            return newState;
        }

        class ControlStateTypeConverter : Binding.TypeConverter
        {
            public override object ConvertFromInvariantString(string value)
            {
                if (value != null)
                {
                    value = value.Trim();

                    ControlState convertedState = new ControlState();
                    string[] parts = value.Split(',');
                    foreach (string part in parts)
                    {
                        convertedState += Create(part);
                    }
                    return convertedState;
                }

                throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(ControlState)}");
            }
        }
    }
}
