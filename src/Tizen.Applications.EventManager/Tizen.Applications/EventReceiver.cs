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

namespace Tizen.Applications.EventManager
{
    /// <summary>
    /// The ApplicationEventReceiver Class provides functions to add event handler.
    /// </summary>
    /// <example>
    /// <code><![CDATA[
    /// using Tizen.Applications.EventManager.SystemEvents;
    /// void OnReceived(object sender, ApplicationEventArgs e)
    /// {
    ///     if (e.Name == "event.org.tizen.example.AppEventTestApp.Tizen.Mobile.AppEvent")
    ///         LogUtils.Write(LogUtils.DEBUG, LOG_TAG, "On Received : " + e.Name);
    ///
    ///     if (e.Name == EarjackStatus.EventName)
    ///     {
    ///         Bundle eventData = e.Data;
    ///         object aValue = eventData.GetItem(EarjackStatus.StatusKey);
    ///         if (eventData.Is<string>(EarjackStatus.StatusKey))
    ///         {
    ///             string statusValue = (string)aValue;
    ///             LogUtils.Write(LogUtils.DEBUG, LOG_TAG, "EarjackStatus : " + statusValue);
    ///         }
    ///     }
    /// }
    /// public class EventManagerSample
    /// {
    ///    ...
    ///    EventReceiver receiver = new EventReceiver("event.org.tizen.example.helloworld.AppEvent");
    ///    receiver.Received += OnReceived;
    /// }
    /// ]]></code>
    /// </example>
    /// <since_tizen> 6 </since_tizen>
    public class EventReceiver : IDisposable
    {
        private bool disposedValue = false;
        private string _eventName;
        private IntPtr _eventHandle;

        private EventHandler<EventManagerEventArgs> eventHandler;
        private Interop.AppEvent.EventCallback callback;

        /// <summary>
        /// Initializer of class.
        /// </summary>
        /// <param name="eventName">The interested event name.</param>
        /// <since_tizen> 6 </since_tizen>
        public EventReceiver(string eventName)
        {
            _eventName = eventName;
        }

        /// <summary>
        /// Finalizer of class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ~EventReceiver()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the eventname.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string EventName
        {
            get
            {
                return _eventName;
            }
        }

        private void OnEvent(string eventName, IntPtr eventData, IntPtr userData)
        {
            SafeBundleHandle sbh = new SafeBundleHandle(eventData, false);
            eventHandler?.Invoke(null, new EventManagerEventArgs(eventName, new Bundle(sbh)));
        }

        /// <summary>
        /// Occurs when events are received.
        /// </summary>
        /// <remarks> If you want to add the privileged event, you MUST declare right privilege first.
        /// Unless that, throw UnauthorizedAccessException.
        /// The privileged events are commented on remarks of it's definitions. </remarks>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<EventManagerEventArgs> Received
        {
            add
            {
                if (eventHandler == null)
                {
                    if (callback == null)
                    {
                        callback = new Interop.AppEvent.EventCallback(OnEvent);
                    }

                    Interop.AppEvent.ErrorCode err = Interop.AppEvent.EventAddHandler(_eventName, callback, IntPtr.Zero, out _eventHandle);

                    if (err != Interop.AppEvent.ErrorCode.None)
                    {
                        ErrorFactory.ThrowException(err, "Add event handler");
                    }
                }

                eventHandler += value;
            }

            remove
            {
                eventHandler -= value;
                if (eventHandler == null)
                {
                    Interop.AppEvent.ErrorCode err = Interop.AppEvent.EventRemoveHandler(_eventHandle);

                    if (err != Interop.AppEvent.ErrorCode.None)
                    {
                        ErrorFactory.ThrowException(err, "Remove event handler");
                    }

                    callback = null;
                }
            }
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                if (eventHandler != null)
                {
                    Interop.AppEvent.ErrorCode err = Interop.AppEvent.EventRemoveHandler(_eventHandle);
                }

                disposedValue = true;
            }
        }

        /// <summary>
        /// Release all the resources used by the class.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
