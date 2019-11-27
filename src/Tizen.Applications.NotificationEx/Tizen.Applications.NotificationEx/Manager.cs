/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.Generic;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        /// <summary>
        /// The Manager class.
        /// Receives notification items related events from Reporter.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        abstract public class Manager
        {
            private const string LogTag = "Tizen.Applications.NotificationEx";
            private IntPtr _handle;
            private Interop.NotificationEx.ManagerEventCallbacks _callbacks;

            /// <summary>
            /// Initializes Style class.
            /// </summary>
            /// <param name="receiverGroup"> A reciver-group of this manager. 
            /// It can be null but if the notification item assign it's reciver-group, 
            /// then only managers which included in the assgined reciver-group can receive the notification item.
            /// </param>            
            /// <since_tizen> 7 </since_tizen>
            public Manager(string receiverGroup)
            {
                _callbacks.OnAdd = new Interop.NotificationEx.ManagerEventsAddCallback(OnAddNative);
                _callbacks.OnUpdate = new Interop.NotificationEx.ManagerEventsUpdateCallback(OnUpdateNative);
                _callbacks.OnDelete = new Interop.NotificationEx.ManagerEventsDeleteCallback(OnDeleteNative);
                _callbacks.OnError = new Interop.NotificationEx.ManagerEventsErrorCallback(OnErrorNative);

                ErrorCode err = Interop.NotificationEx.ManagerCreate(out _handle, receiverGroup, _callbacks, IntPtr.Zero);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
            }

            /// <summary>
            /// Destructor of the Manager class.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            ~Manager()
            {
                ErrorCode err = Interop.NotificationEx.ManagerDestroy(_handle);
                if (err != ErrorCode.None)
                    Log.Error(LogTag, "Fail to destroy manager : " + err);
            }

            private void OnAddNative(IntPtr handle, IntPtr info, IntPtr addedItems, int count, IntPtr userData)
            {
                try
                {
                    IList<AbstractItem> itemList = Util.IntPtrToList(addedItems, count);
                    OnAdd(new EventInfo(info), itemList);
                }
                catch (Exception ex)
                {
                    Log.Error(LogTag, ex.ToString());
                }
            }

            private void OnUpdateNative(IntPtr handle, IntPtr info, IntPtr updatedItem, IntPtr userData)
            {
                try
                {
                    OnUpdate(new EventInfo(handle), updatedItem == IntPtr.Zero ? null : FactoryManager.CreateItem(updatedItem));
                }
                catch (Exception ex)
                {
                    Log.Error(LogTag, ex.ToString());
                }
            }

            private void OnDeleteNative(IntPtr handle, IntPtr info, IntPtr deletedItem, IntPtr userData)
            {
                try
                {
                    OnDelete(new EventInfo(handle), deletedItem == IntPtr.Zero ? null : FactoryManager.CreateItem(deletedItem));
                }
                catch (Exception ex)
                {
                    Log.Error(LogTag, ex.ToString());
                }                
            }

            private void OnErrorNative(IntPtr handle, ErrorCode error, int requestId, IntPtr userData)
            {
                OnError(error, requestId);
            }

            /// <summary>
            /// Overrides this method if you want to receive notification items posted by Reporter class.
            /// </summary>
            /// <param name="info"> A detail information of notification add event. </param>
            /// <param name="addedItems"> Notification items sent by Reporter class. </param>
            /// <since_tizen> 7 </since_tizen>
            protected virtual void OnAdd(EventInfo info, IList<AbstractItem> addedItems)
            {
            }

            /// <summary>
            /// Overrides this method if you want to receive notification items updated by Reporter or other Manager classes.
            /// </summary>
            /// <param name="info"> A detail information of notification update event. </param>
            /// <param name="updatedItem"> Notification items updated by Reporter or other Manager classes. </param>
            /// <since_tizen> 7 </since_tizen>
            protected virtual void OnUpdate(EventInfo info, AbstractItem updatedItem)
            {
            }

            /// <summary>
            /// Overrides this method if you want to receive notification items deleted by Reporter or other Manager classes.
            /// </summary>
            /// <param name="info"> A detail information of notification delete event. </param>
            /// <param name="deletedItem"> Notification items deleted by Reporter or other Manager classes. </param>
            /// <since_tizen> 7 </since_tizen>
            protected virtual void OnDelete(EventInfo info, AbstractItem deletedItem)
            {
            }

            /// <summary>
            /// Overrides this method if you want to handle errors reported by Reporter class.
            /// </summary>
            /// <param name="err"> An error code. </param>
            /// <param name="requestId"> A id of error occurred request. </param>
            /// <remarks>
            /// Every request method such as Update, returns request id as a request result.
            /// You can identify which request is in trouble with request id.
            /// </remarks>
            /// <since_tizen> 7 </since_tizen>
            protected virtual void OnError(ErrorCode err, int requestId)
            {
            }

            /// <summary>
            /// Gets a notification item list.
            /// </summary>
            /// <returns>Notification item list. </returns>
            /// <exception cref="InvalidOperationException">Thrown when fail to get notification list.</exception>
            /// <exception cref="OutOfMemoryException">Thrown when fail to create a list because of the out of memory.</exception>
            /// <since_tizen> 7 </since_tizen>
            public IList<AbstractItem> Get()
            {
                IntPtr ptr;
                int count;

                ErrorCode err = Interop.NotificationEx.ManagerGet(_handle, out ptr, out count);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                IList<AbstractItem> itemList = Util.IntPtrToList(ptr, count);
                Interop.Libc.Free(ptr);

                return itemList;
            }

            /// <summary>
            /// Gets a notification item list by channel.
            /// </summary>
            /// <param name="channel"> A channel name. </param>
            /// <returns>Notification item list. </returns>
            /// <exception cref="InvalidOperationException">Thrown when fail to get notification list.</exception>
            /// <exception cref="OutOfMemoryException">Thrown when fail to create a list because of the out of memory.</exception>
            /// <since_tizen> 7 </since_tizen>
            public IList<AbstractItem> Get(string channel)
            {
                IntPtr ptr;
                int count;

                ErrorCode err = Interop.NotificationEx.ManagerGetByChannel(_handle, channel, out ptr, out count);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                IList<AbstractItem> itemList = Util.IntPtrToList(ptr, count);
                Interop.Libc.Free(ptr);

                return itemList;
            }

            /// <summary>
            /// Updates a notification item.
            /// </summary>
            /// <param name="item"> A notification item to be updated. </param>
            /// <returns>ID of the request. </returns>
            /// <exception cref="InvalidOperationException">Thrown when fail to update notification.</exception>
            /// <exception cref="ArgumentException">Thrown when the item parameter is null. </exception>
            /// <since_tizen> 7 </since_tizen>
            public int Update(AbstractItem item)
            {
                if (item == null)
                    ErrorFactory.ThrowException(ErrorCode.InvalidParameter);
                int reqId;
                item.Serialize();
                ErrorCode err = Interop.NotificationEx.ManagerUpdate(_handle, item.NativeHandle, out reqId);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return reqId;
            }

            /// <summary>
            /// Deletes a notification item.
            /// </summary>
            /// <param name="item"> A notification item to be deleted. </param>
            /// <returns>ID of the request. </returns>
            /// <exception cref="InvalidOperationException">Thrown when fail to delete notification.</exception>
            /// <exception cref="ArgumentException">Thrown when the item parameter is null. </exception>
            /// <since_tizen> 7 </since_tizen>
            public int Delete(AbstractItem item)
            {
                if (item == null)
                    ErrorFactory.ThrowException(ErrorCode.InvalidParameter);
                int reqId;
                ErrorCode err = Interop.NotificationEx.ManagerDelete(_handle, item.NativeHandle, out reqId);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return reqId;
            }

            /// <summary>
            /// Deletes all notification items.
            /// </summary>
            /// <returns>ID of the request. </returns>
            /// <exception cref="InvalidOperationException">Thrown when fail to delete notification.</exception>
            /// <since_tizen> 7 </since_tizen>
            public int DeleteAll()
            {
                int reqId;
                ErrorCode err = Interop.NotificationEx.ManagerDeleteAll(_handle, out reqId);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return reqId;
            }

            /// <summary>
            /// Hides a notification item.
            /// </summary>
            /// <param name="item"> A notification item to be hidden. </param>
            /// <returns>ID of the request. </returns>
            /// <exception cref="InvalidOperationException">Thrown when fail to delete notification.</exception>
            /// <exception cref="ArgumentException">Thrown when the item parameter is null.</exception>
            /// <since_tizen> 7 </since_tizen>
            public int Hide(AbstractItem item)
            {
                if (item == null)
                    ErrorFactory.ThrowException(ErrorCode.InvalidParameter);
                int reqId;
                item.Serialize();
                ErrorCode err = Interop.NotificationEx.ManagerHide(_handle, item.NativeHandle, out reqId);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return reqId;
            }

            /// <summary>
            /// Finds a notification item by root ID.
            /// </summary>
            /// <remarks>
            /// The root ID of notification is an ID of the highest parent item.
            /// </remarks>
            /// <param name="rootId"> A root ID of the notification to be found. </param>
            /// <returns>ID of the request. </returns>
            /// <exception cref="InvalidOperationException">Thrown when fail to delete notification.</exception>
            /// <since_tizen> 7 </since_tizen>
            public AbstractItem FindByRootId(string rootId)
            {
                IntPtr ptr;
                ErrorCode err = Interop.NotificationEx.ManagerFindByRootID(_handle, rootId, out ptr);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                if (ptr == IntPtr.Zero)
                    return null;
                return FactoryManager.CreateItem(ptr);
            }

            /// <summary>
            /// Sends error to the reporter.
            /// </summary>
            /// <param name="info"> A specific event information passed by OnEvent method. </param>
            /// <param name="code"> A error code. </param>
            /// <exception cref="InvalidOperationException">Thrown when fail to send error.</exception>
            /// <since_tizen> 7 </since_tizen>
            public void SendError(EventInfo info, ErrorCode code)
            {
                ErrorCode ret = Interop.NotificationEx.ManagerSendError(_handle, info.NativeHandle, code);
                if (ret != ErrorCode.None)
                    ErrorFactory.ThrowException(ret);
            }

            /// <summary>
            /// Notification count.
            /// </summary>
            /// <exception cref="InvalidOperationException">Thrown when fail to get notification count.</exception>
            /// <since_tizen> 7 </since_tizen>
            public int NotificationCount
            {
                get
                {
                    int count;
                    ErrorCode err = Interop.NotificationEx.ManagerGetNotificationCount(_handle, out count);
                    if (err != ErrorCode.None)
                        ErrorFactory.ThrowException(err);
                    return count;
                }
            }
        }
    }
}
