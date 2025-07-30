/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications.NotificationEventListener
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// This class provides the methods and properties to get information about the posted or updated notification.
    /// </summary>
    public partial class NotificationEventArgs : EventArgs
    {
        private const string LogTag = "Tizen.Applications.NotificationEventListener";

        internal IDictionary<string, StyleArgs> Style;
        internal IDictionary<string, Bundle> ExtraData;
        internal Interop.NotificationEventListener.NotificationSafeHandle Handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationEventArgs"/> class.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public NotificationEventArgs()
        {
            Style = new Dictionary<string, StyleArgs>();
            ExtraData = new Dictionary<string, Bundle>();
        }

        /// <summary>
        /// Gets the unique ID of the notification.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int UniqueNumber { get; internal set; }

        /// <summary>
        /// Gets the appId of the notification.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string AppID { get; internal set; }

        /// <summary>
        /// Gets the title of the notification.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Title { get; internal set; }

        /// <summary>
        /// Gets the content text of the notification.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Content { get; internal set; }

        /// <summary>
        /// Gets the icon's path of the notification.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Icon { get; internal set; }

        /// <summary>
        /// Gets the sub icon path of the notification.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string SubIcon { get; internal set; }

        /// <summary>
        /// Gets the timestamp if the notification is visible or not.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public bool IsTimeStampVisible { get; internal set; }

        /// <summary>
        /// Gets TimeStamp of notification.
        /// </summary>
        /// <remarks>
        /// If IsTimeStampVisible property is set false, this TimeStamp property is meaningless.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        public DateTime TimeStamp { get; internal set; }

        /// <summary>
        /// Gets the count, which is displayed at the right side of notification.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int Count { get; internal set; }

        /// <summary>
        /// Gets the tag of notification.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Tag { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the notification is Onging or not.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsOngoing { get; internal set; } = false;

        /// <summary>
        /// Gets a value that determines whether notification is displayed on the default viewer.
        /// If IsDisplay property is set as false and add style, you can see only style notification.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public bool IsVisible { get; internal set; } = true;

        /// <summary>
        /// Gets the event flag.
        /// If this flag is true, you can do SendEvent.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool HasEventFlag { get; internal set; } = false;

        /// <summary>
        /// Gets the do not show again flag.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CheckBox { get; internal set; } = false;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CheckedValue { get; internal set; } = false;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GroupTitle { get; internal set; } = string.Empty;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GroupContent { get; internal set; } = string.Empty;

        /// <summary>
        /// Gets the AppControl, which is invoked when notification is clicked.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public AppControl Action { get; internal set; }

        /// <summary>
        /// Gets the object of the progress notification.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public ProgressArgs Progress { get; internal set; }

        /// <summary>
        /// Gets the AccessoryArgs, which has option of sound, vibration, and LED.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public AccessoryArgs Accessory { get; internal set; }

        /// <summary>
        /// Gets the key for extra data.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public ICollection<string> ExtraDataKey
        {
            get
            {
                return ExtraData.Keys;
            }
        }

        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public NotificationProperty Property { get; internal set; }

        /// <summary>
        /// Gets the styleArgs of active, lock, indicator, and bigpicture.
        /// </summary>
        /// <typeparam name="T">Type of notification style to be queried.</typeparam>
        /// <returns>The NotificationEventListener.StyleArgs object associated with the given style.</returns>
        /// <exception cref="ArgumentException">Thrown when an argument is invalid.</exception>
        /// <since_tizen> 4 </since_tizen>
        public T GetStyle<T>() where T : StyleArgs, new()
        {
            T type = new T();
            StyleArgs style = null;

            Style.TryGetValue(type.Key, out style);

            if (style == null)
            {
                Log.Error(LogTag, "Invalid Style");
                throw NotificationEventListenerErrorFactory.GetException(Interop.NotificationEventListener.ErrorCode.InvalidParameter, "invalid parameter entered");
            }
            else
            {
                return style as T;
            }
        }

        /// <summary>
        /// Gets the ExtraDataArgs.
        /// </summary>
        /// <param name="key">The key that specifies which extra data.</param>
        /// <returns>Returns the bundle for key.</returns>
        /// <since_tizen> 4 </since_tizen>
        public Bundle GetExtraData(string key)
        {
            Bundle bundle;

            if (string.IsNullOrEmpty(key))
            {
                throw NotificationEventListenerErrorFactory.GetException(Interop.NotificationEventListener.ErrorCode.InvalidParameter, "invalid parameter entered");
            }

            if (ExtraData.TryGetValue(key, out bundle) == false)
            {
                throw NotificationEventListenerErrorFactory.GetException(Interop.NotificationEventListener.ErrorCode.InvalidParameter, "invalid parameter entered : " + key);
            }

            return bundle;
        }
    }
}
