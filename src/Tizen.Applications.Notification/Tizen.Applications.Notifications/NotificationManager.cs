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
    using System.ComponentModel;

    /// <summary>
    /// NotificationManager class to post, update, delete, and get notification.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public static class NotificationManager
    {
        private static event EventHandler<NotificationResponseEventArgs> ResponseEventHandler;

        private static Interop.Notification.ResponseEventCallback responseEventCallback;

        private static void ResponseEventCallback(IntPtr ptr, int type, IntPtr userData)
        {
            IntPtr cloned;
            NotificationError ret = Interop.Notification.Clone(ptr, out cloned);
            if (ret != NotificationError.None)
            {
                Log.Error(Notification.LogTag, "Fail to clone notification : " + ret.ToString());
                return;
            }

            NotificationResponseEventArgs eventArgs = new NotificationResponseEventArgs();
            eventArgs.EventType = (NotificationResponseEventType)type;
            eventArgs.Notification = new Notification
            {
                Handle = new NotificationSafeHandle(cloned, true)
            }.Build();
            ResponseEventHandler?.Invoke(null, eventArgs);
        }

        /// <summary> 
        /// The event handler for receiving a response event from the notification viewers
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<NotificationResponseEventArgs> ResponseReceived
        {
            add
            {
                if (responseEventCallback == null)
                {
                    responseEventCallback = new Interop.Notification.ResponseEventCallback(ResponseEventCallback);
                }
                
                ResponseEventHandler += value;
            }

            remove
            {
                if (ResponseEventHandler != null && ResponseEventHandler.GetInvocationList().Length > 0)
                {
                    ResponseEventHandler -= value;
                }
            }
        }

        /// <summary>
        /// Posts a new notification.
        /// </summary>
        /// <param name="notification">Notification to post.</param>
        /// <exception cref="ArgumentException">Thrown when an argument is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of a permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <example>
        /// <code>
        /// Notification notification = new Notification
        /// {
        ///     Title = "title",
        ///     Content = "content",
        ///     Icon = "absolute icon path",
        ///     Tag = "first notification"
        /// };
        ///
        /// Notification.AccessorySet accessory = new Notification.AccessorySet
        /// {
        ///     SoundOption = AccessoryOption.On,
        ///     CanVibrate = true
        /// };
        /// notification.Accessory = accessory;
        ///
        ///     // do something
        ///
        /// NotificationManager.Post(notification);
        /// </code>
        /// </example>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <since_tizen> 3 </since_tizen>
        public static void Post(Notification notification)
        {
            if (notification == null)
            {
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid argument to post method");
            }

            notification.Make();

            if (ResponseEventHandler != null && ResponseEventHandler.GetInvocationList().Length > 0)
            {
                NotificationError ret = Interop.Notification.PostWithEventCallback(notification.Handle, responseEventCallback, IntPtr.Zero);
                if (ret != NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException(ret, "post notification with event callback failed");
                }
            }
            else
            {
                NotificationError ret = Interop.Notification.Post(notification.Handle);
                if (ret != NotificationError.None)
                {
                    throw NotificationErrorFactory.GetException(ret, "post notification failed");
                }
            }   

            int priv_id, group_id;
            Interop.Notification.GetID(notification.Handle, out group_id, out priv_id);
            notification.PrivID = priv_id;
        }

        /// <summary>
        /// Updates a posted notification.
        /// </summary>
        /// <param name="notification">Notification to update.</param>
        /// <exception cref="ArgumentException">Thrown when an argument is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of a permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <example>
        /// <code>
        /// string tag = "first tag";
        ///
        /// Notification notification = new Notification
        /// {
        ///     Title = "title",
        ///     Content = "content",
        ///     Icon = "absolute icon path",
        ///     Tag = tag
        /// };
        ///
        /// Notification.AccessorySet accessory = new Notification.AccessorySet
        /// {
        ///     LedOption = AccessoryOption.On,
        ///     VibrationOption = AccessoryOption.Custom,
        ///     VibrationPath = "vibration absolute path"
        /// }
        /// notification.Accessory = accessory;
        ///
        /// NotificationManager.Post(notification);
        ///
        ///     // do something
        ///
        /// Notification loadNotification = NotificationManager.Load(tag);
        ///
        /// loadNotification.Progress = new ProgressType(ProgressCategory.Percent, 0.0. 100.0);
        ///
        /// Thread thread = new Thread(new ParameterizedThreadStart(UpdateProgress));
        /// thread.IsBackground = true;
        /// thread.Start(notification);
        ///
        ///   ...
        ///
        /// static void UpdateProgress(Object obj)
        /// {
        ///     Notification notification = (Notification)obj;
        ///
        ///     for (double current = 1.0; current &lt;= 100.0; current = current + 1.0)
        ///     {
        ///         notification.Progress.ProgressCurrent = current;
        ///         NotificationManager.Update(notification);
        ///         Thread.Sleep(300);
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <pre>
        /// Post method should be called on the notification object.
        /// </pre>
        /// <since_tizen> 3 </since_tizen>
        public static void Update(Notification notification)
        {
            if (notification == null || notification.Handle == null || notification.Handle.IsInvalid)
            {
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid argument to post method");
            }

            notification.Make();
            NotificationError ret = Interop.Notification.Update(notification.Handle);
            if (ret != NotificationError.None)
            {
                throw NotificationErrorFactory.GetException(ret, "update notification failed");
            }
        }

        /// <summary>
        /// Deletes a posted notification.
        /// </summary>
        /// <param name="notification">Notification to remove.</param>
        /// <exception cref="ArgumentException">Thrown when an argument is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of a permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <example>
        /// <code>
        /// Notification notification = new Notification
        /// {
        ///     Title = "title",
        ///     Content = "content",
        ///     Icon = "absolute icon path",
        ///     Tag = "first notification"
        /// };
        /// NotificationManager.Post(notification);
        ///
        ///     // do something
        ///
        /// NotificationManager.Delete(notification);
        /// </code>
        /// </example>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <pre>
        /// Post method should be called on the notification object.
        /// </pre>
        /// <since_tizen> 3 </since_tizen>
        public static void Delete(Notification notification)
        {
            if (notification == null || notification.Handle == null || notification.Handle.IsInvalid)
            {
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid argument to post method");
            }

            NotificationError ret = Interop.Notification.Delete(notification.Handle);
            if (ret != NotificationError.None)
            {
                throw NotificationErrorFactory.GetException(ret, "delete notification failed");
            }
        }

        /// <summary>
        /// Removes all posted notifications of calling application.
        /// </summary>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of a permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <example>
        /// <code>
        /// Notification firstNotification = new Notification
        /// {
        ///     Title = "title",
        ///     Content = "content",
        ///     Icon = "absolute icon path",
        ///     Tag = "first notification"
        /// };
        /// NotificationManager.Post(firstNotification);
        ///
        /// Notification secondNotification = new Notification
        /// {
        ///     Title = "title",
        ///     Content = "content",
        ///     Icon = "absolute icon path",
        ///     Tag = "second notification"
        /// };
        /// NotificationManager.Post(secondNotification);
        /// NotificationManager.DeleteAll();
        /// </code>
        /// </example>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <since_tizen> 3 </since_tizen>
        public static void DeleteAll()
        {
            NotificationError ret;

            ret = Interop.Notification.DeleteAll((int)NotificationType.Basic);
            if (ret != NotificationError.None)
            {
                throw NotificationErrorFactory.GetException(ret, "delete all notifications failed of Noti type");
            }

            ret = Interop.Notification.DeleteAll((int)NotificationType.Ongoing);
            if (ret != NotificationError.None)
            {
                throw NotificationErrorFactory.GetException(ret, "delete all notifications failed of Ongoing type");
            }
        }

        /// <summary>
        /// Searches for a posted notification which has the specified tag and has not been deleted yet.
        /// </summary>
        /// <remarks>
        /// Load method should be called only for notifications, which have been posted using the NotificationManager.Post method.
        /// If two or more notifications share the same tag, the notification posted most recently is returned.
        /// </remarks>
        /// <param name="tag">Tag used to query.</param>
        /// <returns>Notification Object with specified tag.</returns>
        /// <exception cref="ArgumentException">Throwing the same exception when argument is invalid and when the tag does not exist is misleading.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of permission denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <example>
        /// <code>
        /// Notification notification = new Notification
        /// {
        ///     Title = "title",
        ///     Content = "content",
        ///     Icon = "absolute icon path",
        ///     Tag = "first notification"
        /// };
        /// NotificationManager.Post(notification);
        ///
        ///     // do someting
        ///
        /// Notification loadNotification = NotificationManager.Load("first notification");
        /// </code>
        /// </example>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <since_tizen> 3 </since_tizen>
        public static Notification Load(string tag)
        {
            IntPtr ptr = IntPtr.Zero;

            if (string.IsNullOrEmpty(tag))
            {
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid parameter entered");
            }

            ptr = Interop.Notification.Load(tag);

            if (ptr == IntPtr.Zero)
            {
                NotificationError ret = (NotificationError)Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                Log.Error(Notification.LogTag, "unable to load Notification : " + ret.ToString());
                if (ret == NotificationError.DbError)
                {
                    throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "the tag does not exist");
                }
                else
                {
                    throw NotificationErrorFactory.GetException(ret, "unable to load Notification");
                }
            }

            Notification notification = new Notification
            {
                Handle = new NotificationSafeHandle(ptr, true)
            }.Build();

            return notification;
        }

        /// <summary>
        /// Saves a notification template to the notification database.
        /// </summary>
        /// <param name="notification">Notification to save as template.</param>
        /// <param name="name">Template name.</param>
        /// <exception cref="ArgumentException">Thrown when an argument is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of a permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it can't be saved as a template.</exception>
        /// <example>
        /// <code>
        /// Notification notification = new Notification
        /// {
        ///     Title = "title",
        ///     Content = "content",
        ///     Icon = "absolute icon path",
        ///     Tag = "first notification"
        /// };
        ///
        /// Notification.Accessory accessory = new Notification.Accessory
        /// {
        ///     LedOption = AccessoryOption.On,
        ///     VibrationOption = AccessoryOption.Custom,
        ///     VibrationPath = "vibration absolute path"
        /// }
        /// notification.setAccessory(accessory);
        ///
        ///     // do something
        ///
        /// NotificationManager.Post(notification);
        ///
        /// Notification.LockStyle style = new Notification.LockStyle
        /// {
        ///     IconPath = "icon path",
        ///     ThumbnailPath = "Thumbnail path"
        /// }
        /// notification.AddStyle(style);
        /// NotificationManager.SaveTemplate(notification, "firstTemplate");
        /// </code>
        /// </example>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <since_tizen> 3 </since_tizen>
        public static void SaveTemplate(Notification notification, string name)
        {
            if (notification == null || string.IsNullOrEmpty(name))
            {
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid argument to save template");
            }

            notification.Make();

            NotificationError ret = Interop.Notification.SaveTemplate(notification.Handle, name);
            if (ret != NotificationError.None)
            {
                throw NotificationErrorFactory.GetException(ret, "save as template failed");
            }
        }

        /// <summary>
        /// Loads a notification template from the notification database.
        /// </summary>
        /// <param name="name">Template name.</param>
        /// <returns>Notification Object with inputted template name.</returns>
        /// <exception cref="ArgumentException">Throwing the same exception when argument is invalid and when the template does not exist is misleading.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of permission denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <example>
        /// <code>
        /// Notification notification = new Notification
        /// {
        ///     Title = "title",
        ///     Content = "content",
        ///     Icon = "absolute icon path",
        ///     Tag = "first notification"
        /// };
        ///
        /// Notification.Accessory accessory = new Notification.Accessory
        /// {
        ///     LedOption = AccessoryOption.On,
        ///     VibrationOption = AccessoryOption.Custom,
        ///     VibrationPath = "vibration absolute path"
        /// }
        /// notification.setAccessory(accessory);
        ///
        ///     // do something
        ///
        /// NotificationManager.Post(notification);
        ///
        /// Notification.LockStyle style = new Notification.LockStyle
        /// {
        ///     IconPath = "icon path",
        ///     ThumbnailPath = "Thumbnail path"
        /// }
        /// notification.AddStyle(style);
        /// NotificationManager.SaveTemplate(notification, "firstTemplate");
        /// Notification notificationTemplate = NotificationManager.LoadTemplate("firstTemplate");
        /// </code>
        /// </example>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <since_tizen> 3 </since_tizen>
        public static Notification LoadTemplate(string name)
        {
            IntPtr handle = IntPtr.Zero;

            if (string.IsNullOrEmpty(name))
            {
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid argument to load template");
            }

            handle = Interop.Notification.LoadTemplate(name);
            if (handle == IntPtr.Zero)
            {
                NotificationError ret = (NotificationError)Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                if (ret == NotificationError.DbError)
                {
                    throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "the name does not exist");
                }
                else
                {
                    throw NotificationErrorFactory.GetException(ret, "unable to create Notification from template");
                }
            }

            Notification notification = new Notification
            {
                Handle = new NotificationSafeHandle(handle, true)
            }.Build();

            return notification;
        }

        /// <summary>
        /// Gets notification block state.
        /// </summary>
        /// <remarks>
        /// The user can set the notification block state in settings.
        /// The block state indicates whether or not notifications can be posted.
        /// Additionally, only notifications to the notification panel are allowed in "Do not disturb mode".
        /// Sound, vibrate, and active notifications are blocked.
        /// </remarks>
        /// <returns>NotificationBlockState is a state if notification is posted.</returns>
        /// <exception cref="UnauthorizedAccessException">Thrown in case of a permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <since_tizen> 3 </since_tizen>
        public static NotificationBlockState GetBlockState()
        {
            NotificationBlockState state;
            NotificationError ret;

            ret = Interop.Notification.GetBlockState(out state);
            if (ret != NotificationError.None)
            {
                throw NotificationErrorFactory.GetException(ret, "GetBlockState failed");
            }

            Log.Info(Notification.LogTag, "Current block state is " + state.ToString());
            return state;
        }

        /// <summary>
        /// Make a NotificationSafeHandle from Notification.
        /// </summary>
        /// <param name="notification">The Notification class.</param>
        /// <returns>The NotificationSafeHandle class.</returns>
        /// <exception cref="ArgumentException">Thrown when an argument is invalid.</exception>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NotificationSafeHandle MakeNotificationSafeHandle(Notification notification)
        {
            if (notification == null)
            {
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid notification object");
            }

            notification.Make();

            return notification.Handle;
        }

        /// <summary>
        /// Make a Notification from NotificationSafeHandle.
        /// </summary>
        /// <param name="handle">The NotificationSafeHandle class.</param>
        /// <returns>The Notification class.</returns>
        /// <exception cref="ArgumentException">Thrown when an argument is invalid.</exception>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Notification MakeNotification(NotificationSafeHandle handle)
        {
            if (handle == null || handle.IsInvalid == true)
            {
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "handle is invalid or null");
            }

            Notification notification = new Notification { Handle = handle }.Build();

            return notification;
        }
    }
}
