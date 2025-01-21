/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// Defines a value type of view state.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly struct ViewState
    {
        /// <summary>
        /// The All state is used in a selector class. It represents all states, so if this state is defined in a selector, the other states are ignored.
        /// </summary>
        public static readonly ViewState All = new (ControlStateUtility.FullMask);

        /// <summary>
        /// Normal State.
        /// </summary>
        public static readonly ViewState Normal = new (0UL);

        /// <summary>
        /// Focused State.
        /// </summary>
        public static readonly ViewState Focused =  new (nameof(Focused));

        /// <summary>
        /// Pressed State.
        /// </summary>
        public static readonly ViewState Pressed = new (nameof(Pressed));

        /// <summary>
        /// Disabled State.
        /// </summary>
        public static readonly ViewState Disabled = new (nameof(Disabled));

        /// <summary>
        /// Selected State.
        /// </summary>
        public static readonly ViewState Selected = new (nameof(Selected));

        /// <summary>
        /// Pressed caused by key state.
        /// </summary>
        public static readonly ViewState PressedByKey = Pressed + new ViewState(nameof(PressedByKey));

        /// <summary>
        /// Pressed caused by touch state.
        /// </summary>
        public static readonly ViewState PressedByTouch = Pressed + new ViewState(nameof(PressedByTouch));

        /// <summary>
        /// SelectedPressed State.
        /// </summary>
        public static readonly ViewState SelectedPressed = Selected + Pressed;

        /// <summary>
        /// DisabledSelected State.
        /// </summary>
        public static readonly ViewState DisabledSelected = Disabled + Selected;

        /// <summary>
        /// DisabledFocused State.
        /// </summary>
        public static readonly ViewState DisabledFocused = Disabled + Focused;

        /// <summary>
        /// SelectedFocused State.
        /// </summary>
        public static readonly ViewState SelectedFocused = Selected + Focused;

        /// <summary>
        /// This is used in a selector class. It represents all other states except for states that are already defined in a selector.
        /// </summary>
        public static readonly ViewState Other = new ViewState(nameof(Other));

        private readonly ulong bitFlags;

        private ViewState(ulong bitMask)
        {
            bitFlags = bitMask;
        }

        private ViewState(string name) : this(ControlStateUtility.Register(name))
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether it has combined states.
        /// </summary>
        internal bool IsCombined => (bitFlags != 0UL) && ((bitFlags & (bitFlags - 1UL)) != 0UL);

        /// <summary>
        /// Create an instance of the <see cref="ViewState"/> with state name.
        /// </summary>
        /// <param name="name">The state name.</param>
        /// <returns>The <see cref="ViewState"/> instance which has single state.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the given name is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the given name is invalid.</exception>
        public static ViewState Create(string name)
        {
            return new ViewState(name);
        }

        /// <summary>
        /// Determines whether a state contains a specified state.
        /// </summary>
        /// <param name="state">The state to search for</param>
        /// <returns>true if the state contain a specified state, otherwise, false.</returns>
        public bool Contains(ViewState state) => (bitFlags & state.bitFlags) == state.bitFlags;

        /// <summary>
        /// Checks if there is a intersection part between this and the other.
        /// </summary>
        /// <param name="other">The other state to check.</param>
        /// <returns>True if an intersection exists, otherwise false.</returns>
        public bool HasIntersectionWith(ViewState other) => (bitFlags & other.bitFlags) != 0L;

        ///  <inheritdoc/>
        public override string ToString()
        {
            var sbuilder = new StringBuilder();
            var states = ControlStateUtility.RegisteredStates();

            if (bitFlags == 0UL)
            {
                return nameof(Normal);
            }
            else if (bitFlags == ControlStateUtility.FullMask)
            {
                return nameof(All);
            }

            foreach (var (name, bitMask) in states)
            {
                if ((bitFlags & bitMask) > 0)
                {
                    if (sbuilder.Length != 0) sbuilder.Append(", ");
                    sbuilder.Append(name);
                }
            }

            return sbuilder.ToString();
        }

        /// <summary>
        /// Compares whether the two ControlStates are same or not.
        /// </summary>
        /// <param name="lhs">A <see cref="ViewState"/> on the left hand side.</param>
        /// <param name="rhs">A <see cref="ViewState"/> on the right hand side.</param>
        /// <returns>true if the ControlStates are equal; otherwise, false.</returns>
        public static bool operator ==(ViewState lhs, ViewState rhs) => lhs.Equals(rhs);

        /// <summary>
        /// Compares whether the two ControlStates are different or not.
        /// </summary>
        /// <param name="lhs">A <see cref="ViewState"/> on the left hand side.</param>
        /// <param name="rhs">A <see cref="ViewState"/> on the right hand side.</param>
        /// <returns>true if the ControlStates are not equal; otherwise, false.</returns>
        public static bool operator !=(ViewState lhs, ViewState rhs) => !lhs.Equals(rhs);

        /// <summary>
        /// The addition operator.
        /// </summary>
        /// <param name="lhs">A <see cref="ViewState"/> on the left hand side.</param>
        /// <param name="rhs">A <see cref="ViewState"/> on the right hand side.</param>
        /// <returns>The <see cref="ViewState"/> containing the result of the addition.</returns>
        public static ViewState operator +(ViewState lhs, ViewState rhs) => new ViewState(lhs.bitFlags | rhs.bitFlags);

        /// <summary>
        /// The substraction operator.
        /// </summary>
        /// <param name="lhs">A <see cref="ViewState"/> on the left hand side.</param>
        /// <param name="rhs">A <see cref="ViewState"/> on the right hand side.</param>
        /// <returns>The <see cref="ViewState"/> containing the result of the substraction.</returns>
        public static ViewState operator -(ViewState lhs, ViewState rhs) => new ViewState(lhs.bitFlags & ~(rhs.bitFlags));

        public bool Equals(ViewState other) => bitFlags == other.bitFlags;

        ///  <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is ViewState otherState)
            {
                return Equals(otherState);
            }
            return base.Equals(obj);
        }

        ///  <inheritdoc/>
        public override int GetHashCode() => bitFlags.GetHashCode();

        internal ControlState ToReferenceType() => new ControlState(this);
    }
}
