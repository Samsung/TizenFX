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

namespace Tizen.Applications.Notifications
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// Class containing common properties and methods of Notifications
    /// </summary>
    /// <remarks>
    /// A notification is a message that is displayed on the notification area.
    /// It is created to notify information to the user through the application.
    /// This class helps you to provide method and property for creating notification object.
    /// </remarks>
    public sealed partial class Notification : IDisposable
    {
        internal static readonly string LogTag = "Tizen.Applications.Notification";

        private NotificationSafeHandle safeHandle;
        private bool disposed = false;

        private IDictionary<string, StyleBase> styleDictionary;
        private IDictionary<string, Bundle> extenderDictionary;
        private int count = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Notification"/> class.
        /// </summary>
        public Notification()
        {
            styleDictionary = new Dictionary<string, StyleBase>();
            extenderDictionary = new Dictionary<string, Bundle>();
        }

        /// <summary>
        /// Gets or sets Tag of Notification.
        /// </summary>
        public string Tag { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets Title of Notification.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets icon of Notification.
        /// </summary>
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets sub icon of Notification.
        /// This SubIcon is displayed in Icon you set.
        /// </summary>
        public string SubIcon { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets content of Notification.
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether TimeStamp of Notification is Visible or not.
        /// Default to true.
        /// </summary>
        public bool IsTimeStampVisible { get; set; } = true;

        /// <summary>
        /// Gets or sets TimeStamp of Notification.
        /// </summary>
        /// <remarks>
        /// If you don't set TimeStamp, It will be set value that time when the notification is posted.
        /// TimeStamp requires NotificationManager.Post() to be called.
        /// If you set IsVisibleTimeStamp property is false, TimeStamp is not Visible in Notification.
        /// </remarks>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets Action which is invoked when notification is clicked
        /// </summary>
        /// <remarks>
        /// If you set it to null, the already set AppControl will be removed and nothing will happen when you click on notification.
        /// </remarks>
        /// <seealso cref="Tizen.Applications.AppControl"></seealso>
        public AppControl Action { get; set; }

        /// <summary>
        /// Gets or sets Count which is displayed at the right side of notification.
        /// </summary>
        /// <remarks>
        /// You must set only positive number.
        /// If you set count to negative number, This property throw exception.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when argument is invalid</exception>
        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                if (value < 0)
                {
                    Log.Error(LogTag, "Count value is negative");
                    throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "The Count must be a positive integer.");
                }

                count = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsOngoing { get; set; } = false;

        /// <summary>
        /// Gets or sets property
        /// </summary>
        /// <seealso cref="Tizen.Applications.Notifications.NotificationProperty"></seealso>
        public NotificationProperty Property { get; set; } = NotificationProperty.None;

        /// <summary>
        /// Gets or sets <see cref="Notification.ProgressType"/> object for display at notification
        /// </summary>
        /// <seealso cref="Tizen.Applications.Notifications.Notification.ProgressType"></seealso>
        public ProgressType Progress { get; set; }

        /// <summary>
        /// Gets or sets <see cref="Notification.AccessorySet"/> which is included vibration, led and sound option to be applied at Notification.
        /// </summary>
        /// <remarks>
        /// If you set it to null, the already set AccessorySet will be initialized.
        /// </remarks>
        /// <example>
        /// <code>
        /// Notification notification = new Notification
        /// {
        ///     Title = "Notification",
        ///     Content = "Hello Tizen",
        ///     Icon = "Icon path",
        ///     Count = 3
        /// };
        ///
        /// Notification.AccessorySet accessory = new Notification.AccessorySet
        /// {
        ///     SoundOption = AccessoryOption.Custom,
        ///     SoundPath = "Sound File Path",
        ///     IsVibration = true,
        ///     LedOption = AccessoryOption.Custom,
        ///     LedOnMs = 100;
        ///     LedOffMs = 50;
        ///     LedColor = Color.Lime
        /// };
        ///
        /// notification.Accessory = accessory;
        ///
        /// NotificationManager.Post(notification);
        /// </code>
        /// </example>
        public AccessorySet Accessory { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether notification is displayed on default viewer.
        /// If you set false and add style, you can see only style notification.
        /// </summary>
        public bool IsDisplay { get; set; } = true;

        /// <summary>
        /// Gets or sets NotificationSafeHandle
        /// </summary>
        internal NotificationSafeHandle Handle
        {
            get
            {
                return safeHandle;
            }

            set
            {
                if (value == null)
                {
                    Log.Error(LogTag, "Invalid argument NotificationSafeHandle");
                    throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid argument to set NotificationSafeHandle");
                }

                safeHandle = value;
            }
        }

        /// <summary>
        /// Gets or sets Private ID
        /// </summary>
        internal int PrivID { get; set; } = -1;

        /// <summary>
        /// Method to add various style to be applied to notification.
        /// </summary>
        /// <remarks>
        /// The user always see about valid notification style. If you add style which is not supported in platform,
        /// this method has no effect.
        /// </remarks>
        /// <param name="style">The style to be applied to notification</param>
        /// <exception cref="ArgumentException">Thrown when argument is invalid</exception>
        /// <example>
        /// <code>
        /// Notification notification = new Notification
        /// {
        ///     Title = "Notification",
        ///     Content = "Hello Tizen",
        ///     Icon = "Icon path",
        ///     Count = 3
        /// };
        ///
        /// Notification.LockStyle lockStyle = new Notification.LockStyle
        /// {
        ///     IconPath = "Icon path",
        ///     ThumbnailPath = "Thumbnail Path"
        /// };
        ///
        /// notification.AddStyle(lockStyle);
        ///
        /// NotificationManager.Post(notification);
        /// </code>
        /// </example>
        public void AddStyle(StyleBase style)
        {
            if (style == null)
            {
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid parameter entered");
            }

            if (styleDictionary.ContainsKey(style.Key) == true)
            {
                Log.Info(LogTag, "The Style is existed, so extender data is replaced");
                styleDictionary.Remove(style.Key);
                styleDictionary.Add(style.Key, style);
            }
            else
            {
                styleDictionary.Add(style.Key, style);
            }
        }

        /// <summary>
        /// Method to remove style you already added.
        /// </summary>
        /// <typeparam name="T">Type of notification style to be queried</typeparam>
        /// <exception cref="ArgumentException">Thrown when argument is invalid</exception>
        public void RemoveStyle<T>() where T : Notification.StyleBase, new()
        {
            T type = new T();

            if (styleDictionary.ContainsKey(type.Key))
            {
                styleDictionary.Remove(type.Key);
            }
            else
            {
                Log.Error(LogTag, "Sytle Can't be removed, there is no style matched input key");
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid parameter entered");
            }
        }

        /// <summary>
        /// Method to get style you already added.
        /// </summary>
        /// <typeparam name="T">Type of notification style to be queried</typeparam>
        /// <returns>
        /// The Notification.Style object associated with the given style
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when argument is invalid</exception>
        public T GetStyle<T>() where T : Notification.StyleBase, new()
        {
            T type = new T();
            StyleBase style = null;

            styleDictionary.TryGetValue(type.Key, out style);

            if (style == null)
            {
                Log.Error(LogTag, "Invalid Style");
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid parameter entered");
            }
            else
            {
                return style as T;
            }
        }

        /// <summary>
        /// Method to set extender data to add extra data
        /// </summary>
        /// <remarks>
        /// The type of extra data is Bundle.
        /// </remarks>
        /// <param name="key">The key of the extra data you want to add.</param>
        /// <param name="value">The value you want to add.</param>
        /// <exception cref="ArgumentException">Thrown when argument is invalid</exception>
        /// <example>
        /// <code>
        /// Notification notification = new Notification
        /// {
        ///     Title = "Notification",
        ///     Content = "Hello Tizen",
        ///     Icon = "Icon path",
        /// };
        ///
        /// Bundle bundle = new Bundle();
        /// bundle.AddItem("key", "value");
        ///
        /// notification.SetExtender("firstKey", bundle);
        /// </code>
        /// </example>
        public void SetExtender(string key, Bundle value)
        {
            if (value == null || value.SafeBundleHandle.IsInvalid || string.IsNullOrEmpty(key))
            {
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid parameter entered");
            }

            if (extenderDictionary.ContainsKey(key) == true)
            {
                Log.Info(LogTag, "The key is existed, so extender data is replaced");
                extenderDictionary.Remove(key);
                extenderDictionary.Add(key, value);
            }
            else
            {
                extenderDictionary.Add(key, value);
            }
        }

        /// <summary>
        /// Method to remove extender you already added.
        /// </summary>
        /// <remarks>
        /// The type of extra data is Bundle.
        /// </remarks>
        /// <param name="key">The key of the extra data to add.</param>
        /// <exception cref="ArgumentException">Thrown when argument is invalid</exception>
        public void RemoveExtender(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid parameter entered");
            }

            if (extenderDictionary.ContainsKey(key))
            {
                extenderDictionary.Remove(key);
            }
            else
            {
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid parameter entered");
            }
        }

        /// <summary>
        /// Method to get extender data you already set
        /// </summary>
        /// <param name="key">The key of the extra data to get.</param>
        /// <returns>Bundle Object that include extender data</returns>
        /// <exception cref="ArgumentException">Thrown when argument is invalid</exception>
        public Bundle GetExtender(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid parameter entered");
            }

            Bundle bundle;
            if (extenderDictionary.TryGetValue(key, out bundle) == false)
            {
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid parameter entered : " + key);
            }

            return bundle;
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                Handle.Dispose();
            }

            disposed = true;
        }

        internal IDictionary<string, StyleBase> GetStyleDictionary()
        {
            return styleDictionary;
        }

        internal IDictionary<string, Bundle> GetExtenderDictionary()
        {
            return extenderDictionary;
        }

        internal StyleBase GetStyle(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "Key is null or empty");
            }

            StyleBase style = null;
            bool ret = styleDictionary.TryGetValue(key, out style);
            if (ret == false)
            {
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "The Style object matched input key is not existed");
            }

            return style;
        }

        internal void Make()
        {
            NotificationBinder.BindObject(this);

            foreach (string key in GetExtenderDictionary().Keys)
            {
                Log.Info(LogTag, "Start to bind Notification.ExtenderData to SafeHandle");
                Interop.Notification.SetExtentionData(Handle, key, extenderDictionary[key].SafeBundleHandle);
            }

            foreach (Notification.StyleBase style in styleDictionary.Values)
            {
                Log.Info(LogTag, "Start to bind Notification.Style to SafeHandle [" + style.Key + "]");
                style.Make(this);
            }

            if (Accessory != null)
            {
                Log.Info(LogTag, "Start to bind Notification.AccessetSet to SafeHandle");
                Accessory.Make(this);
            }

            if (Progress != null)
            {
                Log.Info(LogTag, "Start to bind Notification.Progress to SafeHandle");
                Progress.Make(this);
            }
        }

        internal Notification Build()
        {
            IntPtr extention = IntPtr.Zero;
            IntPtr extentionBundlePtr = IntPtr.Zero;

            NotificationBinder.BindSafeHandle(this);

            Interop.Notification.GetExtentionBundle(Handle, out extention, out extentionBundlePtr);

            if (extention != IntPtr.Zero)
            {
                Bundle bundle = new Bundle(new SafeBundleHandle(extention, false));
                foreach (string key in bundle.Keys)
                {
                    SafeBundleHandle sbh;
                    Interop.Notification.GetExtentionData(Handle, key, out sbh);
                    extenderDictionary.Add(key, new Bundle(sbh));
                }
            }

            ProgressBinder.BindSafeHandle(this);
            AccessorySetBinder.BindSafeHandle(this);
            IndicatorBinder.BindSafeHandle(this);
            ActiveBinder.BindSafeHandle(this);
            LockBinder.BindSafehandle(this);

            return this;
        }
    }
}
