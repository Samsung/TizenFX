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
using System.Threading.Tasks;

namespace Tizen.Messaging.Push
{
    /// <summary>
    /// The PushClient API provides functions to connect to push service for receiving push messages.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// <remarks>
    /// The PushClient API provides the way to connect with the push service.
    /// It provides APIs to connect/disconnect from the push service.
    /// APIs are provided so that an application can register itself
    /// with the push server along with APIs to request push message.
    /// </remarks>
    public static class PushClient
    {
        /// <summary>
        /// Event Handler for receiving the notifications.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<PushMessageEventArgs> NotificationReceived
        {
            add
            {
                lock (_lock)
                {
                    _notificationReceived += value;
                }
            }
            remove
            {
                lock (_lock)
                {
                    _notificationReceived -= value;
                }
            }
        }

        /// <summary>
        /// Event Handler for receiving changes in States of the connection.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<PushConnectionStateEventArgs> StateChanged
        {
            add
            {
                lock (_lock)
                {
                    _stateChanged += value;
                }
            }
            remove
            {
                lock (_lock)
                {
                    _stateChanged -= value;
                }
            }
        }

        /// <summary>
        /// API to connect with the push service.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/push</privilege>
        /// <exception cref="InvalidOperationException"> In case of privilege not defined. </exception>
        /// <param name="pushAppId"> The Push Application ID Registered with the server.</param>
        public static void PushServiceConnect(string pushAppId)
        {
            PushImpl.PushServiceConnect(pushAppId);
        }

        /// <summary>
        /// API to disconnect from the push service.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static void PushServiceDisconnect()
        {
            PushImpl.PushServiceDisconnect();
            //PushImpl.Reset();
        }


        /// <summary>
        /// API to Register the application with the push server.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// The method returns a task, which on completion will give a ServerResponse Object.
        /// </returns>
        public static Task<ServerResponse> PushServerRegister()
        {
            return PushImpl.PushServerRegister();
        }

        /// <summary>
        /// API to Deregister the application from the push server.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// The method returns a task, which on completion will give a ServerResponse Object.
        /// </returns>
        public static Task<ServerResponse> PushServerUnregister()
        {
            return PushImpl.PushServerUnregister();
        }

        /// <summary>
        /// Gets the unread notifications for the application.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static void GetUnreadNotifications()
        {
            PushImpl.GetUnreadNotifications();
        }

        /// <summary>
        /// registration ID received from server.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// It is the string, which is the ID received from the server.
        /// </returns>
        public static string GetRegistrationId()
        {
            return PushImpl.GetRegistrationId();
        }

        internal static void StateChange(PushConnectionStateEventArgs args)
        {
            if (_stateChanged != null)
                _stateChanged(null, args);
        }

        internal static void Notify(PushMessageEventArgs args)
        {
            if (_notificationReceived != null)
                _notificationReceived(null, args);
        }

        private static object _lock = new object();
        private static event EventHandler<PushMessageEventArgs> _notificationReceived;
        private static event EventHandler<PushConnectionStateEventArgs> _stateChanged;
    }
}
