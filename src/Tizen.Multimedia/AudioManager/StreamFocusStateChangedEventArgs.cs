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
    /// Provides data for the <see cref="AudioStreamPolicy.StreamFocusStateChanged"/> event.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class StreamFocusStateChangedEventArgs : EventArgs
    {
        internal StreamFocusStateChangedEventArgs(AudioStreamFocusOptions options,
            AudioStreamFocusState focusState, AudioStreamFocusChangedReason reason, string extraInfo)
        {
            FocusOptions = options;
            FocusState = focusState;
            Reason = reason;
            ExtraInfo = extraInfo;
        }

        /// <summary>
        /// Gets the focus options.
        /// </summary>
        /// <value>The focus options.</value>
        /// <since_tizen> 4 </since_tizen>
        public AudioStreamFocusOptions FocusOptions { get; }

        /// <summary>
        /// Gets the changed focus state.
        /// </summary>
        /// <value>The focus state.</value>
        /// <since_tizen> 4 </since_tizen>
        public AudioStreamFocusState FocusState { get; }

        /// <summary>
        /// Gets the reason for state change of the focus.
        /// </summary>
        /// <value>The reason for state change of the focus.</value>
        /// <since_tizen> 4 </since_tizen>
        public AudioStreamFocusChangedReason Reason { get; }

        /// <summary>
        /// Gets the extra information.
        /// </summary>
        /// <value>
        /// The extra information specified in <see cref="AudioStreamPolicy.AcquireFocus(AudioStreamFocusOptions, AudioStreamBehaviors, string)"/> or
        /// <see cref="AudioStreamPolicy.ReleaseFocus(AudioStreamFocusOptions, AudioStreamBehaviors, string)"/>.
        /// </value>
        /// <seealso cref="AudioStreamPolicy.AcquireFocus(AudioStreamFocusOptions, AudioStreamBehaviors, string)"/>
        /// <seealso cref="AudioStreamPolicy.ReleaseFocus(AudioStreamFocusOptions, AudioStreamBehaviors, string)"/>
        /// <since_tizen> 4 </since_tizen>
        public string ExtraInfo { get; }
    }
}
