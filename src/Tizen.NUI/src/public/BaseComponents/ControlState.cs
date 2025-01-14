/*
 * Copyright(c) 2020-2025 Samsung Electronics Co., Ltd.
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
using System.Text;
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
        //Default States
        /// <summary>
        /// The All state is used in a selector class. It represents all states, so if this state is defined in a selector, the other states are ignored.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static readonly ControlState All = new ControlState(ViewState.All);
        /// <summary>
        /// Normal State.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static readonly ControlState Normal = new ControlState(ViewState.Normal);
        /// <summary>
        /// Focused State.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static readonly ControlState Focused =  new ControlState(ViewState.Focused);
        /// <summary>
        /// Pressed State.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static readonly ControlState Pressed = new ControlState(ViewState.Pressed);
        /// <summary>
        /// Disabled State.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static readonly ControlState Disabled = new ControlState(ViewState.Disabled);
        /// <summary>
        /// Selected State.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static readonly ControlState Selected = new ControlState(ViewState.Selected);
        /// <summary>
        /// SelectedPressed State.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly ControlState SelectedPressed = new ControlState(ViewState.SelectedPressed);
        /// <summary>
        /// DisabledSelected State.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly ControlState DisabledSelected = new ControlState(ViewState.DisabledSelected);
        /// <summary>
        /// DisabledFocused State.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly ControlState DisabledFocused = new ControlState(ViewState.DisabledFocused);
        /// <summary>
        /// SelectedFocused State.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly ControlState SelectedFocused = new ControlState(ViewState.SelectedFocused);
        /// <summary>
        /// This is used in a selector class. It represents all other states except for states that are already defined in a selector.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public static readonly ControlState Other = new ControlState(ViewState.Other);

        readonly ViewState value;


        /// <summary>
        /// Gets or sets a value indicating whether it has combined states.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsCombined => value.IsCombined;

        internal ControlState(ViewState value)
        {
            this.value = value;
        }

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
            return new ControlState(ViewState.Create(name));
        }

        /// <summary>
        /// Create an instance of the <see cref="ControlState"/> with combined states.
        /// </summary>
        /// <param name="states">The control state array.</param>
        /// <returns>The <see cref="ControlState"/> instance which has combined state.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ControlState Create(params ControlState[] states)
        {
            ViewState result = ViewState.Normal;

            for (int i = 0; i < states.Length; i++)
            {
                result += states[i].value;
            }

            return new ControlState(result);
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
            if (state is null)
                throw new ArgumentNullException(nameof(state));

            return value.Contains(state.value);
        }

        ///  <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(ControlState other)
        {
            if (other is null)
                return false;

            return value.Equals(other.value);
        }

        ///  <inheritdoc/>
        /// <since_tizen> 9 </since_tizen>
        public override bool Equals(object other) => this.Equals(other as ControlState);

        ///  <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => value.GetHashCode();

        ///  <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => value.ToString();

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
        public static ControlState operator +(ControlState lhs, ControlState rhs) => Add(lhs, rhs);

        /// <summary>
        /// The substraction operator.
        /// </summary>
        /// <param name="lhs">A <see cref="ControlState"/> on the left hand side.</param>
        /// <param name="rhs">A <see cref="ControlState"/> on the right hand side.</param>
        /// <returns>The <see cref="ControlState"/> containing the result of the substraction.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when lhs or rhs is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ControlState operator -(ControlState lhs, ControlState rhs) => Remove(lhs, rhs);

        static ControlState Add(ControlState operand1, ControlState operand2)
        {
            if (operand1 is null)
            {
                throw new ArgumentNullException(nameof(operand1));
            }
            if (operand2 is null)
            {
                throw new ArgumentNullException(nameof(operand2));
            }

            return new ControlState(operand1.value + operand2.value);
        }

        static ControlState Remove(ControlState operand1, ControlState operand2)
        {
            if (operand1 is null)
            {
                throw new ArgumentNullException(nameof(operand1));
            }
            if (operand2 is null)
            {
                throw new ArgumentNullException(nameof(operand2));
            }

            return new ControlState(operand1.value - operand2.value);
        }

        class ControlStateTypeConverter : Binding.TypeConverter
        {
            public override object ConvertFromInvariantString(string value)
            {
                if (value != null)
                {
                    value = value.Trim();

                    ControlState convertedState = Normal;
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
