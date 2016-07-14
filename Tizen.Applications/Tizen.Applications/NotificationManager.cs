// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

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
        /// Posts a message on a toast popup
        /// </summary>
        /// <param name="text">Text to display on popup</param>
        /// <exception cref="ArgumentNullException">Thrown when argument is null</exception>
        /// <example>
        /// <code>
        /// string msg = "hey there!!";
        /// NotificationManager.PostToastMessage(msg);
        /// </code>
        /// </example>
        public static void PostToastMessage(string text)
        {
            int ret = Interop.Notification.PostMessage(text);
            if(ret != (int)NotificationError.None)
            {
                throw NotificationErrorFactory.GetException((NotificationError)ret, "post toast message failed");
            }
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
