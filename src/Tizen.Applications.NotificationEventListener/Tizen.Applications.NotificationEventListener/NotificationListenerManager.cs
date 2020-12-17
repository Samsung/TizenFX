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
    using System.Runtime.InteropServices;

    using Tizen.Internals;

    /// <summary>
    /// This class provides a way to register callback function for some notification events.
    /// </summary>
    /// <remarks>
    /// The event listener can use this class to get a list of notifications or to clear notifications.
    /// </remarks>
    /// <since_tizen> 4 </since_tizen>
    public partial class NotificationListenerManager
    {
        private const string LogTag = "Tizen.Applications.NotificationEventListener";

        private static event EventHandler<NotificationEventArgs> AddEventHandler;

        private static event EventHandler<NotificationEventArgs> UpdateEventHandler;

        private static event EventHandler<NotificationDeleteEventArgs> DeleteEventHandler;

        private static Interop.NotificationEventListener.ChangedCallback callback;

        [NativeStruct("notification_op", Include="notification_type.h", PkgConfig="notification")]
        [StructLayout(LayoutKind.Sequential)]
        private struct NotificationOperation
        {
            NotificationOperationType type;
            int uniqueNumber;
            int extraInformation1;
            int extraInformation2;
            IntPtr notification;
        }

        private static int GetEventHandleLength()
        {
            int length = 0;

            length += (DeleteEventHandler == null) ? 0 : DeleteEventHandler.GetInvocationList().Length;
            length += (UpdateEventHandler == null) ? 0 : UpdateEventHandler.GetInvocationList().Length;
            length += (AddEventHandler == null) ? 0 : AddEventHandler.GetInvocationList().Length;

            return length;
        }

        /// <summary>
        /// Event handler for notification insert event.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> Thrown in case of a permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<NotificationEventArgs> Added
        {
            add
            {
                if (callback == null)
                {
                    callback = new Interop.NotificationEventListener.ChangedCallback(ChangedEvent);
                }

                if (GetEventHandleLength() == 0)
                {
                    Interop.NotificationEventListener.ErrorCode err = Interop.NotificationEventListener.SetChangedCallback(callback, IntPtr.Zero);
                    if (err != (int)Interop.NotificationEventListener.ErrorCode.None)
                    {
                        throw NotificationEventListenerErrorFactory.GetException(err, "unable to set changed callback");
                    }
                }

                AddEventHandler += value;
            }

            remove
            {
                if (AddEventHandler != null && AddEventHandler.GetInvocationList().Length > 0)
                {
                    AddEventHandler -= value;

                    if (GetEventHandleLength() == 0)
                    {
                        Interop.NotificationEventListener.ErrorCode err = Interop.NotificationEventListener.UnsetChangedCallback(callback);
                        if (err != (int)Interop.NotificationEventListener.ErrorCode.None)
                        {
                            throw NotificationEventListenerErrorFactory.GetException(err, "unable to unset changed callback");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Event handler for notification update event.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> Thrown in case of a permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<NotificationEventArgs> Updated
        {
            add
            {
                if (callback == null)
                {
                    callback = new Interop.NotificationEventListener.ChangedCallback(ChangedEvent);
                }

                if (GetEventHandleLength() == 0)
                {
                    Interop.NotificationEventListener.ErrorCode err = Interop.NotificationEventListener.SetChangedCallback(callback, IntPtr.Zero);
                    if (err != Interop.NotificationEventListener.ErrorCode.None)
                    {
                        throw NotificationEventListenerErrorFactory.GetException(err, "unable to set changed callback");
                    }
                }

                UpdateEventHandler += value;
            }

            remove
            {
                if (UpdateEventHandler != null && UpdateEventHandler.GetInvocationList().Length > 0)
                {
                    UpdateEventHandler -= value;

                    if (GetEventHandleLength() == 0)
                    {
                        Interop.NotificationEventListener.ErrorCode err = Interop.NotificationEventListener.UnsetChangedCallback(callback);
                        if (err != Interop.NotificationEventListener.ErrorCode.None)
                        {
                            throw NotificationEventListenerErrorFactory.GetException(err, "unable to unset changed callback");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Event handler for notification delete event.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> Thrown in case of a permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <since_tizen> 4 </since_tizen>
        public static event EventHandler<NotificationDeleteEventArgs> Deleted
        {
            add
            {
                if (callback == null)
                {
                    callback = new Interop.NotificationEventListener.ChangedCallback(ChangedEvent);
                }

                if (GetEventHandleLength() == 0)
                {
                    Interop.NotificationEventListener.ErrorCode err = Interop.NotificationEventListener.SetChangedCallback(callback, IntPtr.Zero);
                    if (err != Interop.NotificationEventListener.ErrorCode.None)
                    {
                        throw NotificationEventListenerErrorFactory.GetException(err, "unable to set changed callback");
                    }
                }

                DeleteEventHandler += value;
            }

            remove
            {
                if (DeleteEventHandler != null && DeleteEventHandler.GetInvocationList().Length > 0)
                {
                    DeleteEventHandler -= value;

                    if (GetEventHandleLength() == 0)
                    {
                        Interop.NotificationEventListener.ErrorCode err = Interop.NotificationEventListener.UnsetChangedCallback(callback);
                        if (err != Interop.NotificationEventListener.ErrorCode.None)
                        {
                            throw NotificationEventListenerErrorFactory.GetException(err, "unable to unset changed callback");
                        }
                    }
                }
            }
        }

        private static void ChangedEvent(IntPtr userData, NotificationType type, IntPtr operationList, int num)
        {
            IntPtr operationType;
            IntPtr uniqueNumber;
            IntPtr notification;

            NotificationEventArgs eventargs;
            NotificationDeleteEventArgs deleteargs;

            for (int i = 0; i < num; i++)
            {
                uniqueNumber = IntPtr.Zero;
                operationType = IntPtr.Zero;
                notification = IntPtr.Zero;

                Interop.NotificationEventListener.GetOperationData(operationList + (i * Marshal.SizeOf<NotificationOperation>()), NotificationOperationDataType.Type, out operationType);
                Interop.NotificationEventListener.GetOperationData(operationList + (i * Marshal.SizeOf<NotificationOperation>()), NotificationOperationDataType.UniqueNumber, out uniqueNumber);
                Interop.NotificationEventListener.GetOperationData(operationList + (i * Marshal.SizeOf<NotificationOperation>()), NotificationOperationDataType.Notification, out notification);

                if (operationType == IntPtr.Zero)
                {
                    Log.Error(LogTag, "unable to get operationType");
                    continue;
                }

                Log.Info(LogTag, "type : " + ((int)operationType).ToString());
                Log.Info(LogTag, "Add : " + (AddEventHandler == null ? "0" : AddEventHandler.GetInvocationList().Length.ToString()));
                Log.Info(LogTag, "update: " + (UpdateEventHandler == null ? "0" : UpdateEventHandler.GetInvocationList().Length.ToString()));
                Log.Info(LogTag, "delete : " + (DeleteEventHandler == null ? "0" : DeleteEventHandler.GetInvocationList().Length.ToString()));

                switch ((int)operationType)
                {
                    case (int)NotificationOperationType.Insert:
                        if (notification != IntPtr.Zero)
                        {
                            try
                            {
                                eventargs = NotificationEventArgsBinder.BindObject(notification, false);
                                AddEventHandler?.Invoke(null, eventargs);
                            }
                            catch (Exception e)
                            {
                                Log.Error(LogTag, e.Message);
                            }
                        }

                        break;

                    case (int)NotificationOperationType.Update:
                        if (notification != IntPtr.Zero)
                        {
                            try
                            {
                                eventargs = NotificationEventArgsBinder.BindObject(notification, false);
                                UpdateEventHandler?.Invoke(null, eventargs);
                            }
                            catch (Exception e)
                            {
                                Log.Error(LogTag, e.Message);
                            }
                        }

                        break;

                    case (int)NotificationOperationType.Delete:
                        if (uniqueNumber != IntPtr.Zero)
                        {
                            try
                            {
                                deleteargs = NotificationDeleteEventArgsBinder.BindObject((int)uniqueNumber);
                                DeleteEventHandler?.Invoke(null, deleteargs);
                            }
                            catch (Exception e)
                            {
                                Log.Error(LogTag, e.Message);
                            }
                        }

                        break;

                    default:
                        Log.Info(LogTag, "Event : " + (int)operationType);
                        break;
                }
            }
        }

        /// <summary>
        /// Deletes a notification with appId and uniqueNumber.
        /// </summary>
        /// <param name="appId">The name of the application you want to delete.</param>
        /// <param name="uniqueNumber">The unique number of the notification.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> Thrown in case of a permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <since_tizen> 4 </since_tizen>
        public static void Delete(string appId, int uniqueNumber)
        {
            Interop.NotificationEventListener.ErrorCode err;

            if (string.IsNullOrEmpty(appId) || uniqueNumber < 0)
            {
                throw NotificationEventListenerErrorFactory.GetException(Interop.NotificationEventListener.ErrorCode.InvalidParameter, "invalid parameter");
            }

            err = Interop.NotificationEventListener.Delete(appId, 0, uniqueNumber);
            if (err != Interop.NotificationEventListener.ErrorCode.None)
            {
                throw NotificationEventListenerErrorFactory.GetException(err, "unable to delete");
            }
        }

        /// <summary>
        /// Deletes all notifications.
        /// </summary>
        /// <exception cref="UnauthorizedAccessException"> Thrown in case of a permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <since_tizen> 4 </since_tizen>
        public static void DeleteAll()
        {
            Interop.NotificationEventListener.ErrorCode err;

            err = Interop.NotificationEventListener.DeleteAll((int)NotificationType.Notification);
            if (err != Interop.NotificationEventListener.ErrorCode.None)
            {
                throw NotificationEventListenerErrorFactory.GetException(err, "delete all notifications failed of Noti type");
            }

            err = Interop.NotificationEventListener.DeleteAll((int)NotificationType.Ongoing);
            if (err != Interop.NotificationEventListener.ErrorCode.None)
            {
                throw NotificationEventListenerErrorFactory.GetException(err, "delete all notifications failed of Ongoing type");
            }
        }

        /// <summary>
        /// Returns the notification list.
        /// </summary>
        /// <exception cref="UnauthorizedAccessException"> Thrown in case of a permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <since_tizen> 4 </since_tizen>
        public static IList<NotificationEventArgs> GetList()
        {
            Interop.NotificationEventListener.ErrorCode err;
            IntPtr notificationList = IntPtr.Zero;
            IntPtr currentList = IntPtr.Zero;
            IList<NotificationEventArgs> list = new List<NotificationEventArgs>();

            err = Interop.NotificationEventListener.GetList(NotificationType.None, -1, out notificationList);
            if (err != Interop.NotificationEventListener.ErrorCode.None)
            {
                throw NotificationEventListenerErrorFactory.GetException(err, "unable to get notification list");
            }

            if (notificationList != IntPtr.Zero)
            {
                currentList = notificationList;
                while (currentList != IntPtr.Zero)
                {
                    IntPtr notification;
                    NotificationEventArgs eventargs = new NotificationEventArgs();

                    notification = Interop.NotificationEventListener.GetData(currentList);

                    eventargs = NotificationEventArgsBinder.BindObject(notification, false);

                    list.Add(eventargs);

                    currentList = Interop.NotificationEventListener.GetNext(currentList);
                }

                Interop.NotificationEventListener.NotificationListFree(notificationList);
            }

            return list;
        }

        /// <summary>
        /// Sends occured event from viewer application to the notification owner.
        /// </summary>
        /// <param name="uniqueNumber">The unique number of the notification.</param>
        /// <param name="type">Event type on notification.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> Thrown in case of a permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <since_tizen> 4 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SendEvent(int uniqueNumber, UserEventType type)
        {
            Interop.NotificationEventListener.ErrorCode err;

            err = Interop.NotificationEventListener.SendEvent(uniqueNumber, (int)type);
            if (err != Interop.NotificationEventListener.ErrorCode.None)
            {
                throw NotificationEventListenerErrorFactory.GetException(err, "failed to send event");
            }
        }

        /// <summary>
        /// Returns NotificationEventArgs by UniqueNumber.
        /// </summary>
        /// <param name="uniqueNumber">The unique number of the Notification.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        /// <exception cref="UnauthorizedAccessException"> Thrown in case of a permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <since_tizen> 4 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static NotificationEventArgs GetNotificationEventArgs(int uniqueNumber)
        {
            if (uniqueNumber <= 0)
            {
                throw NotificationEventListenerErrorFactory.GetException(Interop.NotificationEventListener.ErrorCode.InvalidParameter, "Invalid parameter");
            }

            IntPtr notificationPtr = Interop.NotificationEventListener.LoadNotification(null, uniqueNumber);
            if (notificationPtr == IntPtr.Zero)
            {
                int err = Tizen.Internals.Errors.ErrorFacts.GetLastResult();
                if (err.Equals((int)Interop.NotificationEventListener.ErrorCode.DbError))
                {
                    throw NotificationEventListenerErrorFactory.GetException(Interop.NotificationEventListener.ErrorCode.InvalidParameter, "Not exist");
                }
                else
                {
                    throw NotificationEventListenerErrorFactory.GetException((Interop.NotificationEventListener.ErrorCode)err, "failed to get NotificationEventArgs");
                }
            }

            NotificationEventArgs eventArgs = new NotificationEventArgs();
            eventArgs = NotificationEventArgsBinder.BindObject(notificationPtr, false);

            return eventArgs;
        }

        /// <summary>
        /// Gets the number of all notifications
        /// </summary>
        /// <returns>The number of all notifications</returns>
        /// <exception cref="UnauthorizedAccessException"> Thrown in case of a permission is denied.</exception>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        /// <privilege>http://tizen.org/privilege/notification</privilege>
        /// <since_tizen> 4 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int GetAllCount()
        {
            int count;
            Interop.NotificationEventListener.ErrorCode error;

            error = Interop.NotificationEventListener.GetAllCount(NotificationType.None, out count);
            if (error != Interop.NotificationEventListener.ErrorCode.None)
            {
                if (error == Interop.NotificationEventListener.ErrorCode.PermissionDenied)
                {
                    throw NotificationEventListenerErrorFactory.GetException(Interop.NotificationEventListener.ErrorCode.PermissionDenied, "failed to get all count");
                }
                else
                {
                    throw NotificationEventListenerErrorFactory.GetException(Interop.NotificationEventListener.ErrorCode.InvalidOperation, "failed to get all count");
                }
            }

            return count;
        }
    }
}
