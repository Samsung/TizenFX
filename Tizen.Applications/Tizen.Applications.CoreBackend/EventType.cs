// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

namespace Tizen.Applications.CoreBackend
{
    /// <summary>
    /// Class that represents the type of event for backends. This class can be converted from string type.
    /// </summary>
    public class EventType
    {
        /// <summary>
        /// Pre-defined event type. "PreCreated"
        /// </summary>
        public static readonly EventType PreCreated = "PreCreated";

        /// <summary>
        /// Pre-defined event type. "Created"
        /// </summary>
        public static readonly EventType Created = "Created";

        /// <summary>
        /// Pre-defined event type. "Terminated"
        /// </summary>
        public static readonly EventType Terminated = "Terminated";

        /// <summary>
        /// Pre-defined event type. "AppControlReceived"
        /// </summary>
        public static readonly EventType AppControlReceived = "AppControlReceived";

        /// <summary>
        /// Pre-defined event type. "Resumed"
        /// </summary>
        public static readonly EventType Resumed = "Resumed";

        /// <summary>
        /// Pre-defined event type. "Paused"
        /// </summary>
        public static readonly EventType Paused = "Paused";

        /// <summary>
        /// Pre-defined event type. "LowMemory"
        /// </summary>
        public static readonly EventType LowMemory = "LowMemory";

        /// <summary>
        /// Pre-defined event type. "LowBattery"
        /// </summary>
        public static readonly EventType LowBattery = "LowBattery";

        /// <summary>
        /// Pre-defined event type. "LocaleChanged"
        /// </summary>
        public static readonly EventType LocaleChanged = "LocaleChanged";

        /// <summary>
        /// Pre-defined event type. "RegionFormatChanged"
        /// </summary>
        public static readonly EventType RegionFormatChanged = "RegionFormatChanged";

        private string _typeName;

        /// <summary>
        /// Initializes the EventType class.
        /// </summary>
        /// <param name="name">The name of event type.</param>
        public EventType(string name)
        {
            _typeName = name;
        }

        /// <summary>
        /// Returns the name of event type.
        /// </summary>
        public override string ToString()
        {
            return _typeName;
        }

        /// <summary>
        /// Returns the hash code for event type string.
        /// </summary>
        public override int GetHashCode()
        {
            if (_typeName == null) return 0;
            return _typeName.GetHashCode();
        }

        /// <summary>
        /// Determines whether this instance and a specified object.
        /// </summary>
        public override bool Equals(object obj)
        {
            EventType other = obj as EventType;
            return other != null && other._typeName == this._typeName;
        }

        /// <summary>
        /// Converts a string to EventType instance.
        /// </summary>
        public static implicit operator EventType(string value)
        {
            return new EventType(value);
        }
    }
}
