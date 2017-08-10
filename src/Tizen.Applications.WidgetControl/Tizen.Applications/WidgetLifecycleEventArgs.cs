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

namespace Tizen.Applications
{
    /// <summary>
    /// The class for event arguments of the widget lifecycle.
    /// </summary>
    public class WidgetLifecycleEventArgs : EventArgs
    {
        internal WidgetLifecycleEventArgs()
        {
        }

        /// <summary>
        /// Enumeration for the event type.
        /// </summary>
        public enum EventType
        {
            /// <summary>
            /// The widget is created.
            /// </summary>
            Created,

            /// <summary>
            /// The widget is destroyed.
            /// </summary>
            Destroyed,

            /// <summary>
            /// The widget is paused.
            /// </summary>
            Paused,

            /// <summary>
            /// The widget is resumed.
            /// </summary>
            Resumed
        }

        /// <summary>
        ///  The widget ID.
        /// </summary>
        public string WidgetId { get; internal set; }

        /// <summary>
        /// The widget instance ID.
        /// </summary>
        public string InstanceId { get; internal set; }

        /// <summary>
        /// The event type.
        /// </summary>
        public EventType Type { get; internal set; }
    }
}
