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

namespace Tizen.Applications.Notifications
{
    /// <summary>
    /// NotificationManager class to post, update, delete and get Notifications.
    /// </summary>
    public static class NotificationManager
    {
        /// <summary>
        /// Posts a new Notification.
        /// </summary>
        /// <param name="notification">Notification to post</param>
        /// <exception cref="ArgumentNullException">Thrown when argument is null</exception>
        /// <example>
        /// <code>
        /// EventNotification noti = new EventNotification();
        /// noti.Title = "Title";
        /// NotificationManager.Post(noti);
        /// </code>
        /// </example>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        public static void Post(Notification notification)
        {
            if(notification == null)
            {
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid argument to post method");
            }

            int ret = Interop.Notification.Post(notification._handle);
            if(ret != (int)NotificationError.None)
            {
                throw NotificationErrorFactory.GetException((NotificationError)ret, "post notification failed");
            }
        }

        /// <summary>
        /// Updates a posted Notification.
        /// </summary>
        /// <param name="notification">Notification to update</param>
        /// <exception cref="ArgumentNullException">Thrown when argument is null</exception>
        /// <example>
        /// <code>
        /// EventNotification noti = new EventNotification();
        /// noti.Title = "Title";
        /// NotificationManager.Post(noti);
        /// ...
        /// noti.Title = "New Title";
        /// NotificationManager.Update(noti);
        /// </code>
        /// </example>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <pre>
        /// Post method should be called on the Notification object.
        /// </pre>
        public static void Update(Notification notification)
        {
            if(notification == null)
            {
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid argument to post method");
            }

            int ret = Interop.Notification.Update(notification._handle);
            if(ret != (int)NotificationError.None)
            {
                throw NotificationErrorFactory.GetException((NotificationError)ret, "update notification failed");
            }
        }

        /// <summary>
        /// Deletes a posted Notification.
        /// </summary>
        /// <param name="notification">Notification to remove</param>
        /// <exception cref="ArgumentNullException">Thrown when argument is null</exception>
        /// <example>
        /// <code>
        /// EventNotification noti = new EventNotification();
        /// NotificationManager.Post(noti);
        /// ...
        /// NotificationManager.Delete(noti);
        /// </code>
        /// </example>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <pre>
        /// Post method should be called on the Notification object.
        /// </pre>
        public static void Delete(Notification notification)
        {
            if(notification == null)
            {
                throw NotificationErrorFactory.GetException(NotificationError.InvalidParameter, "invalid argument to post method");
            }

            int ret = Interop.Notification.Delete(notification._handle);
            if(ret != (int)NotificationError.None)
            {
                throw NotificationErrorFactory.GetException((NotificationError)ret, "delete notification failed");
            }
        }

        /// <summary>
        /// Removes all posted Notification of NotificationType type of calling application.
        /// </summary>
        /// <param name="type">Type of Notifications to remove</param>
        /// <example>
        /// <code>
        /// EventNotification notiE = new EventNotification();
        /// NotificationManager.Post(notiE);
        /// NotificationManager.DeleteAll(NotificationType.Event);
        /// /// ...
        /// ProgressNotification notiP = new ProgressNotification();
        /// NotificationManager.Post(notiP);
        /// NotificationManager.DeleteAll(NotificationType.Progress);
        /// </code>
        /// </example>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        public static void DeleteAll(NotificationType type)
        {
            int ret = Interop.Notification.DeleteAll((int)type);
            if(ret != (int)NotificationError.None)
            {
                throw NotificationErrorFactory.GetException((NotificationError)ret, "delete all notifications failed of type " + type);
            }
        }

        /// <summary>
        /// Removes all posted Notification of calling application.
        /// </summary>
        /// <example>
        /// <code>
        /// EventNotification notiE = new EventNotification();
        /// NotificationManager.Post(notiE);
        /// ProgressNotification notiP = new ProgressNotification();
        /// NotificationManager.Post(notiP);
        /// NotificationManager.DeleteAll();
        /// </code>
        /// </example>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        public static void DeleteAll()
        {
            DeleteAll(NotificationType.Progress);

            DeleteAll(NotificationType.Event);
        }

        /// <summary>
        /// Searches for a posted notification which has the inputted tag
        /// </summary>
        /// <remarks>
        /// Load method should be called only for notifcations which have been posted using NotificationManager.Post method.
        /// If two or more notifications share the same tag, the notification posted most recently is returned.
        /// </remarks>
        /// <typeparam name="T">Type of notification to be queried</typeparam>
        /// <param name="tag">Tag used to query</param>
        /// <returns>Notification Object with inputted tag</returns>
        /// <exception cref="InvalidOperationException">Thrown when no notification with inputed tag exists</exception>
        /// <example>
        /// <code>
        /// EventNotification noti = new EventNotification();
        /// noti.Title = "Title";
        /// noti.Tag = "Hello";
        /// NotificationManager.Post(noti);
        /// /// ...
        /// EventNotification notiCopy = NotificationManager/<EventNotification/>("Hello");
        /// </code>
        /// </example>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        public static T Load<T>(string tag) where T : Notification
        {
            Notification result = null;
            Interop.Notification.SafeNotificationHandle handle = Interop.Notification.Load(tag);
            if(handle.IsInvalid)
            {
                int ret = Tizen.Internals.Errors.ErrorFacts.GetLastResult();

                throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to load Notification");
            }

            result = CreateNotificationFromTag(handle);

            return (T)result;
        }

        internal static Notification CreateNotificationFromTag(Interop.Notification.SafeNotificationHandle handle)
        {
            Notification result = null;
            NotificationType type;

            int ret = Interop.Notification.GetType(handle, out type);
            if(ret != (int)NotificationError.None)
            {
                throw NotificationErrorFactory.GetException((NotificationError)ret, "unable to get type");
            }

            if(type == NotificationType.Event)
            {
                result = (Notification)new EventNotification(handle);
            }
            else
            {
                result = (Notification)new ProgressNotification(handle);
            }

            return result;
        }
    }
}
