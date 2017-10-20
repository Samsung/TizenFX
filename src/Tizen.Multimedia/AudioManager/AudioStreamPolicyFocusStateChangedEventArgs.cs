/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides data for the <see cref="AudioStreamPolicy.FocusStateChanged"/> event.
    /// </summary>
    public class AudioStreamPolicyFocusStateChangedEventArgs : EventArgs
    {
        internal AudioStreamPolicyFocusStateChangedEventArgs(AudioStreamFocusOptions options,
            AudioStreamFocusState state, AudioStreamFocusChangedReason reason,
            AudioStreamBehaviors behaviors, string extraInfo)
        {
            FocusOptions = options;
            FocusState = state;
            Reason = reason;
            Behaviors = behaviors;
            ExtraInfo = extraInfo;
        }

        /// <summary>
        /// Gets the focus options.
        /// </summary>
        /// <value>The focus options.</value>
        public AudioStreamFocusOptions FocusOptions { get; }

        /// <summary>
        /// Gets the focus state.
        /// </summary>
        /// <value>The focus state.</value>
        public AudioStreamFocusState FocusState { get; }

        /// <summary>
        /// Gets the reason for state change of the focus.
        /// </summary>
        /// <value>The reason for state change of the focus.</value>
        public AudioStreamFocusChangedReason Reason { get; }

        /// <summary>
        /// Gets the requested behaviors that should be followed.
        /// </summary>
        /// <value>The requested behaviors that should be followed.</value>
        public AudioStreamBehaviors Behaviors { get; }

        /// <summary>
        /// Gets the extra information.
        /// </summary>
        /// <value>
        /// The extra information specified in <see cref="AudioStreamPolicy.AcquireFocus(AudioStreamFocusOptions, AudioStreamBehaviors, string)"/> or
        /// <see cref="AudioStreamPolicy.ReleaseFocus(AudioStreamFocusOptions, AudioStreamBehaviors, string)"/>.
        /// </value>
        /// <seealso cref="AudioStreamPolicy.AcquireFocus(AudioStreamFocusOptions, AudioStreamBehaviors, string)"/>
        /// <seealso cref="AudioStreamPolicy.ReleaseFocus(AudioStreamFocusOptions, AudioStreamBehaviors, string)"/>
        public string ExtraInfo { get; }
    }
}
