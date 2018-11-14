/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Text;
using static Interop.Event;

namespace Tizen.Applications
{
    /// <summary>
    /// The Event API provides functions to receive events.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class Event : IDisposable
    {
        internal IntPtr _handler;
        private readonly string _eventName = null;
        private Interop.Event.EventCallback _eventCallBack;

        /// <summary>
        /// Initializes the instance of the Event class.
        /// </summary>
        /// <param name="eventName">The name of the event.</param>
        /// <exception cref="System.ArgumentException">Thrown when eventName is null or empty.</exception>
        /// <example>
        /// <code>
        /// Event ev = new Event("tizen.system.event.usb_status");
        /// ev += EventReceivedCallback;
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public Event(string eventName)
        {
            if (String.IsNullOrEmpty(eventName))
            {
                throw new InvalidOperationException("null event name");
            }
            _eventName = eventName;
            _eventCallBack = (string name, IntPtr eventData, IntPtr userData) =>
            {
                ApplicationEventArgs args = new ApplicationEventArgs()
                {
                    EventData = new Bundle(new SafeBundleHandle(eventData, false))
                };
                EventReceived?.Invoke(this, args);
            };

            Interop.Event.AddEventHandler(_eventName, _eventCallBack, IntPtr.Zero, out _handler);
        }

        /// <summary>
        /// Destructor of the Event class.
        /// </summary>
        ~Event()
        {
            Dispose(false);
        }

        /// <summary>
        /// Called when a event is received.
        /// </summary>
        /// <example>
        /// <code>
        /// Event ev = new Event("tizen.system.event.screen_autorotate_state");
        /// ev.EventReceived += EventReceivedCallback;
        /// static void EventReceivedCallback(EventArgs e)
        /// {
        ///     Console.WriteLine("Event Received ");
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<ApplicationEventArgs> EventReceived;

        /// <summary>
        /// The name of the event.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string EventName
        {
            get
            {
                return _eventName;
            }
        }


        /// <summary>
        /// Releases the unmanaged resources used by the Event class specifying whether to perform a normal dispose operation.
        /// </summary>
        /// <param name="disposing">true for a normal dispose operation; false to finalize the handle.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (_handler != null)
            {
                try
                {
                    ErrorCode ret = Interop.Event.RemoveEventHandler(_handler);
                    if (ret != ErrorCode.None)
                        throw new InvalidOperationException("fail to remove event handler");
                }
                catch (Exception e)
                {
                    Log.Warn(GetType().Namespace, "Exception in Dispose :" + e);
                }
            }
        }

        /// <summary>
        /// Releases all resources used by the Event class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
