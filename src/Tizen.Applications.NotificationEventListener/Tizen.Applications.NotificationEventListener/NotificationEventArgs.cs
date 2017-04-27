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
    public partial class NotificationEventArgs
    {
        private const string LogTag = "Tizen.Applications.NotificationEventListener";

        internal IDictionary<string, StyleArgs> Style;
        internal IDictionary<string, Bundle> Extender;
        internal Interop.NotificationEventListener.SafeNotificationHandle Handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationEventArgs"/> class.
        /// </summary>
        public NotificationEventArgs()
        {
            Style = new Dictionary<string, StyleArgs>();
            Extender = new Dictionary<string, Bundle>();
        }

        /// <summary>
        /// Gets the unique id of Notification.
        /// </summary>
        /// <example>
        /// <code>
        /// int uniqueNumber = NotificationEventArgs.UniqueNumber;
        /// </code>
        /// </example>
        public int UniqueNumber { get; internal set; }

        /// <summary>
        /// Gets the appId of Notification.
        /// </summary>
        /// <example>
        /// <code>
        /// string appId = NotificationEventArgs.AppID;
        /// </code>
        /// </example>
        public string AppID { get; internal set; }

        /// <summary>
        /// Gets the title of Notification.
        /// </summary>
        /// <example>
        /// <code>
        /// string title = NotificationEventArgs.Title;
        /// </code>
        /// </example>
        public string Title { get; internal set; }

        /// <summary>
        /// Gets the content text of Notification.
        /// </summary>
        /// <example>
        /// <code>
        /// string content = NotificationEventArgs.Content;
        /// </code>
        /// </example>
        public string Content { get; internal set; }

        /// <summary>
        /// Gets the icon's path of Notification.
        /// </summary>
        /// <example>
        /// <code>
        /// string icon = NotificationEventArgs.Icon;
        /// </code>
        /// </example>
        public string Icon { get; internal set; }

        /// <summary>
        /// Gets the sub icon path of Notification.
        /// </summary>
        /// <example>
        /// <code>
        /// string subIcon = NotificationEventArgs.SubIcon;
        /// </code>
        /// </example>
        public string SubIcon { get; internal set; }

        /// <summary>
        /// Gets the Timestamp of notification is visible or not.
        /// </summary>
        public bool IsTimeStampVisible { get; internal set; }

        /// <summary>
        /// Gets time of Notification.
        /// </summary>
        /// <example>
        /// <code>
        /// DateTime timeStamp = NotificationEventArgs.TimeStamp;
        /// </code>
        /// </example>
        public DateTime TimeStamp { get; internal set; }

        /// <summary>
        /// Gets the count which is displayed at the right side of notification.
        /// </summary>
        /// <example>
        /// <code>
        /// int count = NotificationEventArgs.Count;
        /// </code>
        /// </example>
        public int Count { get; internal set; }

        /// <summary>
        /// Gets the Tag of notification.
        /// </summary>
        /// <example>
        /// <code>
        /// string tag = NotificationEventArgs.Tag;
        /// </code>
        /// </example>
        public string Tag { get; internal set; }

        /// <summary>
        /// Gets a value to check if it is an ongoing type.
        /// </summary>
        /// <example>
        /// <code>
        /// bool isongoing = NotificationEventArgs.IsOngoing;
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsOngoing { get; internal set; } = false;

        /// <summary>
        /// Gets a value that determines whether notification is displayed on the default viewer.
        /// If you set false and add style, you can see only style notification.
        /// </summary>
        /// <example>
        /// <code>
        /// bool isDisplay = NotificationEventArgs.IsDisplay;
        /// </code>
        /// </example>
        public bool IsDisplay { get; internal set; } = true;

        /// <summary>
        /// Gets the event flag.
        /// </summary>
        /// <example>
        /// <code>
        /// bool eventFlag = NotificationEventArgs.HasEventFlag;
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool HasEventFlag { get; internal set; } = false;

        /// <summary>
        /// Gets the AppControl which is invoked when notification is clicked.
        /// </summary>
        /// <example>
        /// <code>
        /// AppControl action = NotificationEventArgs.Action;
        /// </code>
        /// </example>
        public AppControl Action { get; internal set; }

        /// <summary>
        /// Gets the object of the progress notification.
        /// </summary>
        /// <example>
        /// <code>
        /// ProgressCategory category = NotificationEventArgs.Progress.Category;
        /// double current = NotificationEventArgs.Progress.Current;
        /// double max = NotificationEventArgs.Progress.Max;
        /// </code>
        /// </example>
        public ProgressArgs Progress { get; internal set; }

        /// <summary>
        /// Gets the AccessoryArgs which has option of Sound, Vibration, LED.
        /// </summary>
        /// <example>
        /// <code>
        /// string soundPath = NotificationEventArgs.Accessory.SountPath;
        /// </code>
        /// </example>
        public AccessoryArgs Accessory { get; internal set; }

        /// <summary>
        /// Gets the key for extender.
        /// </summary>
        /// <example>
        /// <code>
        /// ICollection<string> extenderkey = NotificationEventArgs.ExtenderKey;
        /// foreach (string key in extenderkey)
        /// {
        /// ...
        /// }
        /// </code>
        /// </example>
        public ICollection<string> ExtenderKey
        {
            get
            {
                return Extender.Keys;
            }
        }

        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <example>
        /// <code>
        /// int property = NotificationEventArgs.Property;
        /// </code>
        /// </example>
        public NotificationProperty Property { get; internal set; }

        /// <summary>
        /// Gets the styleArgs of active, lock, indicator, bigpicture.
        /// </summary>
        /// <typeparam name="T">Type of notification style to be queried</typeparam>
        /// <returns>The Notification.Style object associated with the given style</returns>
        /// <exception cref="ArgumentException">Thrown when argument is invalid</exception>
        /// <example>
        /// <code>
        /// NotificationEventArgs.ActiveStyleArgs style = NotificationEventArgs.GetStyle<NotificationEventArgs.ActiveStyleArgs>();
        /// autoremove = style.IsAutoRemove;
        /// </code>
        /// </example>
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
        /// Gets the ExtenderArgs.
        /// </summary>
        /// <param name="key">The key that specifies which extender</param>
        /// <returns>Returns the bundle for key</returns>
        /// <exception cref="ArgumentException">Thrown when argument is invalid</exception>
        /// <example>
        /// <code>
        /// Bundle extender = NotificationEventArgs.GetExtender("key");
        /// </code>
        /// </example>
        public Bundle GetExtender(string key)
        {
            Bundle bundle;

            if (string.IsNullOrEmpty(key))
            {
                throw NotificationEventListenerErrorFactory.GetException(Interop.NotificationEventListener.ErrorCode.InvalidParameter, "invalid parameter entered");
            }

            if (Extender.TryGetValue(key, out bundle) == false)
            {
                throw NotificationEventListenerErrorFactory.GetException(Interop.NotificationEventListener.ErrorCode.InvalidParameter, "invalid parameter entered : " + key);
            }

            return bundle;
        }
    }
}
