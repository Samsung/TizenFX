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
using System.Runtime.InteropServices;

namespace Tizen.Applications.NotificationEx
{
    public partial class NotificationEx
    {
        private const string LogTag = "Tizen.Applications.NotificationEx";

        /// <summary>
        /// The Reporter class.
        /// Sending notification related operations and receiving events triggered by the manager.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        abstract public class Reporter
        {
            private IntPtr _handle;
            private Interop.NotificationEx.ReporterEventCallbacks _callbacks;

            /// <summary>
            /// Initializes Reporter class.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            public Reporter()
            {
                _callbacks.OnEvent = new Interop.NotificationEx.ReporterEventsEventCallback(OnEventNative);
                _callbacks.OnError = new Interop.NotificationEx.ReporterEventsErrorCallback(OnErrorNative);

                ErrorCode err = Interop.NotificationEx.ReporterCreate(out _handle, _callbacks, IntPtr.Zero);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
            }

            /// <summary>
            /// Destructor of the Style class.
            /// </summary>
            /// <since_tizen> 7 </since_tizen>
            ~Reporter()
            {
                ErrorCode err = Interop.NotificationEx.ReporterDestroy(_handle);
                if (err != ErrorCode.None)
                    Log.Error(LogTag, "Fail to destroy reporter");
            }

            private void OnErrorNative(IntPtr handle, ErrorCode error, int requestId, IntPtr userData)
            {
                OnError(error, requestId);
            }

            private void OnEventNative(IntPtr handle, IntPtr eventInfo, IntPtr items, int count, IntPtr userData)
            {
                try
                {
                    IList<AbstractItem> list = Util.IntPtrToList(items, count);
                    OnEvent(new EventInfo(eventInfo), list);
                }
                catch (Exception ex)
                {
                    Log.Error(LogTag, ex.ToString());
                }
            }

            /// <summary>
            /// Overrides this method if you want to handle errors reported by the manager.
            /// </summary>
            /// <param name="err"> An error code. </param>
            /// <param name="requestId"> A id of error occurred request. </param>
            /// <remarks>
            /// Every request method such as Post, returns request id as a request result.
            /// You can identify which request is in trouble with request id.
            /// </remarks>
            /// <since_tizen> 7 </since_tizen>
            protected virtual void OnError(ErrorCode err, int requestId)
            {
            }

            /// <summary>
            /// Overrides this method if you want to handle events triggered by the manager.
            /// </summary>
            /// <param name="info"> A specific event information. </param>
            /// <param name="items"> Items which are related to the event. </param>
            /// <since_tizen> 7 </since_tizen>
            protected virtual void OnEvent(EventInfo info, IList<AbstractItem> items)
            {
            }

            /// <summary>
            /// Sends error to the manager.
            /// </summary>
            /// <param name="info"> A specific event information passed by OnEvent method. </param>
            /// <param name="code"> A error code. </param>
            /// <exception cref="InvalidOperationException">Thrown when fail to send error.</exception>
            /// <exception cref="ArgumentException">Thrown when the info parameter is null. </exception>
            /// <since_tizen> 7 </since_tizen>
            public void SendError(EventInfo info, ErrorCode code)
            {
                if (info == null)
                    ErrorFactory.ThrowException(ErrorCode.InvalidParameter);
                ErrorCode err = Interop.NotificationEx.ReporterSendError(_handle, info.NativeHandle, code);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
            }

            /// <summary>
            /// Sends a notification to the manager.
            /// </summary>
            /// <param name="noti"> A notification to be posted. </param>
            /// <returns>ID of the request.</returns>
            /// <exception cref="InvalidOperationException">Thrown when fail to send notification item.</exception>
            /// <exception cref="ArgumentException">Thrown when the noti parameter is null. </exception>
            /// <since_tizen> 7 </since_tizen>
            public int Post(AbstractItem noti)
            {
                if (noti == null)
                    ErrorFactory.ThrowException(ErrorCode.InvalidParameter);
                int reqId;
                noti.Serialize();
                ErrorCode err = Interop.NotificationEx.ReporterPost(_handle, noti.NativeHandle, out reqId);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return reqId;
            }

            /// <summary>
            /// Sends a notification list to the manager.
            /// </summary>
            /// <param name="list"> A notification list to be posted. </param>
            /// <returns>ID of the request. </returns>
            /// <exception cref="InvalidOperationException">Thrown when fail to send notification item list.</exception>
            /// <exception cref="ArgumentException">Thrown when the list parameter is null. </exception>
            /// <since_tizen> 7 </since_tizen>
            public int PostList(IList<AbstractItem> list)
            {
                if (list == null)
                    ErrorFactory.ThrowException(ErrorCode.InvalidParameter);                

                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Serialize();
                }
                IntPtr nativeList = Util.ListToIntPtr(list);
                int reqId;
                ErrorCode err = Interop.NotificationEx.ReporterPostList(_handle, nativeList, list.Count, out reqId);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                Marshal.FreeHGlobal(nativeList);

                return reqId;
            }

            /// <summary>
            /// Sends a notification update request to the manager.
            /// </summary>
            /// <param name="noti"> A notification to be updated. </param>
            /// <returns>ID of the request. </returns>
            /// <exception cref="InvalidOperationException">Thrown when fail to update notification.</exception>
            /// <exception cref="ArgumentException">Thrown when the noti parameter is null. </exception>
            /// <since_tizen> 7 </since_tizen>
            public int Update(AbstractItem noti)
            {
                if (noti == null)
                    ErrorFactory.ThrowException(ErrorCode.InvalidParameter);
                int reqId;
                noti.Serialize();
                ErrorCode err = Interop.NotificationEx.ReporterUpdate(_handle, noti.NativeHandle, out reqId);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return reqId;
            }

            /// <summary>
            /// Sends a notification delete request to the manager.
            /// </summary>
            /// <param name="noti"> A notification to be deleted. </param>
            /// <returns>ID of the request. </returns>
            /// <exception cref="InvalidOperationException">Thrown when fail to delete notification.</exception>
            /// <exception cref="ArgumentException">Thrown when the noti parameter is null. </exception>
            /// <since_tizen> 7 </since_tizen>
            public int Delete(AbstractItem noti)
            {
                if (noti == null)
                    ErrorFactory.ThrowException(ErrorCode.InvalidParameter);
                int reqId;
                ErrorCode err = Interop.NotificationEx.ReporterDelete(_handle, noti.NativeHandle, out reqId);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return reqId;
            }

            /// <summary>
            /// Sends a notification delete all request to the manager.
            /// </summary>          
            /// <returns>ID of the request. </returns>  
            /// <exception cref="InvalidOperationException">Thrown when fail to delete all notifications.</exception>
            /// <since_tizen> 7 </since_tizen>
            public int DeleteAll()
            {
                int reqId;
                ErrorCode err = Interop.NotificationEx.ReporterDeleteAll(_handle, out reqId);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                return reqId;
            }

            /// <summary>
            /// Finds a notification using notification's root ID.
            /// </summary>
            /// <remarks>
            /// The root ID of notification is an ID of the highest parent item.
            /// </remarks>
            /// <param name="rootId"> A root ID of the notification to be found. </param>
            /// <returns>If this function is working successfully, returns an abstract item otherwise null.</returns>
            /// <exception cref="InvalidOperationException">Thrown when fail to find notification item.</exception>
            /// <since_tizen> 7 </since_tizen>
            public AbstractItem FindByRootId(string rootId)
            {
                IntPtr ptr;
                ErrorCode err = Interop.NotificationEx.ReporterFindByRootId(_handle, rootId, out ptr);
                if (err != ErrorCode.None)
                    ErrorFactory.ThrowException(err);
                if (ptr == IntPtr.Zero)
                    return null;
                return FactoryManager.CreateItem(ptr);
            }
        }
    }
}
