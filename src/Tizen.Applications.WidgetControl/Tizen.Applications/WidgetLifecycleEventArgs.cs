// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace Tizen.Applications
{
    /// <summary>
    /// Class for event arguments of the widget lifecycle.
    /// </summary>
    public class WidgetLifecycleEventArgs : EventArgs
    {
        /// <summary>
        /// Enumeration for event type.
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
        /// Widget ID.
        /// </summary>
        public string WidgetId { get; internal set; }

        /// <summary>
        /// Widget instnace ID.
        /// </summary>
        public string InstanceId { get; internal set; }

        /// <summary>
        /// Event type.
        /// </summary>
        public EventType Type { get; internal set; }
    }
}
