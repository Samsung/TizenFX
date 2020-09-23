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
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// Class for describing the states of the view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ControlState : IEquatable<ControlState>
    {
        private static readonly Dictionary<string, ControlState> stateDictionary = new Dictionary<string, ControlState>();
        //Default States
        /// <summary>
        /// All State.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly ControlState All = Create("All");
        /// <summary>
        /// Normal State.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly ControlState Normal = Create("Normal");
        /// <summary>
        /// Focused State.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly ControlState Focused = Create("Focused");
        /// <summary>
        /// Pressed State.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly ControlState Pressed = Create("Pressed");
        /// <summary>
        /// Disabled State.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly ControlState Disabled = Create("Disabled");
        /// <summary>
        /// Selected State.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly ControlState Selected = Create("Selected");
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
        /// Other State.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly ControlState Other = Create("Other");

        private List<ControlState> stateList = new List<ControlState>();
        private readonly string name = "";

        /// <summary>
        /// Gets or sets a value indicating whether it has combined states.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsCombined => stateList.Count > 1;

        /// <summary>
        /// Default Contructor. Please use <see cref="Create(string)"/> or <see cref="Create(ControlState[])"/> instead.
        /// </summary>
        // Do not open this constructor. This is only for xaml support.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ControlState() { }

        private ControlState(string name) : this() => this.name = name;

        /// <summary>
        /// Create an instance of the <see cref="ControlState"/> with state name.
        /// </summary>
        /// <param name="name">The state name.</param>
        /// <returns>The <see cref="ControlState"/> instance which has single state.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ControlState Create(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name cannot be empty string", nameof(name));

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
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => this.Equals(obj as ControlState);

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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(ControlState lhs, ControlState rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Compares whether the two ControlStates are different or not.
        /// </summary>
        /// <param name="lhs">A <see cref="ControlState"/> on the left hand side.</param>
        /// <param name="rhs">A <see cref="ControlState"/> on the right hand side.</param>
        /// <returns>true if the ControlStates are not equal; otherwise, false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(ControlState lhs, ControlState rhs) => !lhs.Equals(rhs);

        /// <summary>
        /// The addition operator.
        /// </summary>
        /// <param name="lhs">A <see cref="ControlState"/> on the left hand side.</param>
        /// <param name="rhs">A <see cref="ControlState"/> on the right hand side.</param>
        /// <returns>The <see cref="ControlState"/> containing the result of the addition.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ControlState operator +(ControlState lhs, ControlState rhs) => Create(lhs, rhs);

        /// <summary>
        /// The substraction operator.
        /// </summary>
        /// <param name="lhs">A <see cref="ControlState"/> on the left hand side.</param>
        /// <param name="rhs">A <see cref="ControlState"/> on the right hand side.</param>
        /// <returns>The <see cref="ControlState"/> containing the result of the substraction.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ControlState operator -(ControlState lhs, ControlState rhs)
        {
            if (!lhs.IsCombined)
            {
                return ReferenceEquals(lhs, rhs) ? Normal : lhs;
            }
            
            var rest = lhs.stateList.Except(rhs.stateList);

            if (rest.Count() == 0)
            {
                return Normal;
            }

            if (rest.Count() == 1)
            {
                return rest.First();
            }

            ControlState newState = new ControlState();
            newState.stateList.AddRange(rest);
            return newState;
        }
    }

    /// <summary>
    /// The Key/Value pair structure. this is mutable to support for xaml.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct StateValuePair<T> : IEquatable<StateValuePair<T>>
    {
        /// <summary>
        /// The constructor with the specified state and value.
        /// </summary>
        /// <param name="state">The state</param>
        /// <param name="value">The value associated with state.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StateValuePair(ControlState state, T value)
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
        public bool Equals(StateValuePair<T> other) => (Value.Equals(other.Value)) && (State == other.State);

        ///  <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            if (!(obj is StateValuePair<T>))
                return false;

            return Equals((StateValuePair<T>)obj);
        }

        ///  <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => (State.GetHashCode() * 397) ^ Value.GetHashCode();


        /// <summary>
        /// Compares whether the two StateValuePair are different or not.
        /// </summary>
        /// <param name="lhs">A <see cref="StateValuePair{T}"/> on the left hand side.</param>
        /// <param name="rhs">A <see cref="StateValuePair{T}"/> on the right hand side.</param>
        /// <returns>true if the StateValuePair are equal; otherwise, false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(StateValuePair<T> lhs, StateValuePair<T> rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Compares whether the two StateValuePair are same or not.
        /// </summary>
        /// <param name="lhs">A <see cref="StateValuePair{T}"/> on the left hand side.</param>
        /// <param name="rhs">A <see cref="StateValuePair{T}"/> on the right hand side.</param>
        /// <returns>true if the StateValuePair are not equal; otherwise, false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(StateValuePair<T> lhs, StateValuePair<T> rhs) => !(lhs == rhs);

        ///  <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => $"[{State}, {Value}]";
    }
}