/// This File contains the Api's related to the PushManager class
///
/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Threading.Tasks;

namespace Tizen.Messaging.Push
{
    /// <summary>
    /// The PushManager API provides functions to connect to push service for receiving push messages.
    /// </summary>
    /// <remarks>
    /// The PushManager API provides the way to connect with the push service.
    /// It provides api's to connect/disconnect from the push service.
    /// Api's are provided so that an application can register itself
    /// with the push server along with api's to request push message.
    /// </remarks>
    /// <example>
    /// <code>
    /// public class Program
    /// {
    ///     static void Main(string[] args)
    ///     {
    ///         Push.PushServiceConnect("xxxxx");
    ///         Task<ServerResponse> tr = Push.PushServerRegister();
    ///         tr.GetAwaiter().OnCompleted(() => {
    ///             ServerResponse res = tr.Result;
    ///             Push.GetUnreadNotifications();
    ///             Task<ServerResponse> tu = Push.PushServerUnregister();
    ///             tu.GetAwaiter().OnCompleted(() => {
    ///                 Push.PushServiceDisconnect();
    ///             });
    ///         });
    ///         Push.NotificationReceived += EventHandlerNotificationReceived;
    ///         Push.StateChanged += EventHandlerStateChanged;
    ///     }
    /// }
    /// static void EventHandlerNotificationReceived(object sender, PushMessageEventArgs e)
    /// {
    ///     // any user code
    /// }
    /// static void EventHandlerStateChanged(object sender, PushConnectionStateEventArgs e)
    /// {
    ///     // any user code
    /// }
    /// </code>
    /// </example>
    public static class Push
    {
        /// <summary>
        /// Event Handler for receiving the notifications.
        /// </summary>
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
        /// <param name="pushAppId"> The Push Application Id Registered with the server.</param>
        public static void PushServiceConnect(string pushAppId)
        {
            PushImpl.Instance.PushServiceConnect(pushAppId);
        }

        /// <summary>
        /// API to disconnect from the push service.
        /// </summary>
        public static void PushServiceDisconnect()
        {
            PushImpl.Instance.PushServiceDisconnect();
            //PushImpl.Reset();
        }


        /// <summary>
        /// API to Register the application with the push server.
        /// </summary>
        /// <returns>
        /// The method returns a task which on completion with give a ServerResponse Object.
        /// </returns>
        public static Task<ServerResponse> PushServerRegister()
        {
            return PushImpl.Instance.PushServerRegister();
        }

        /// <summary>
        /// API to Deregister the application from the push server.
        /// </summary>
        /// <returns>
        /// The method returns a task which on completion with give a ServerResponse Object.
        /// </returns>
        public static Task<ServerResponse> PushServerUnregister()
        {
            return PushImpl.Instance.PushServerUnregister();
        }

        /// <summary>
        /// Gets the unread notifications for the application.
        /// </summary>
        public static void GetUnreadNotifications()
        {
            PushImpl.Instance.GetUnreadNotifications();
        }

        /// <summary>
        /// registration Id received from server. </summary>
        /// <returns>
        /// It is the string which is the Id received from the server.
        /// </returns>
        public static string GetRegistrationId()
        {
            return PushImpl.Instance.GetRegistrationId();
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
