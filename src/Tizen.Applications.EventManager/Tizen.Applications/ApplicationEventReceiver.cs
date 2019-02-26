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
    /// <code>
    ///void OnReceived(object sender, ApplicationEventArgs e)
    ///{
    ///     if (e.EventName == "event.org.tizen.example.AppEventTestApp.Tizen.Mobile.AppEvent")
    ///     LogUtils.Write(LogUtils.DEBUG, LOG_TAG, "On Received : " + e.EventName);
    ///}
    /// public class EventManagerSample
    /// {
    ///     /// ...
    ///    ApplicationEventReceiver receiver = new ApplicationEventReceiver("event.org.tizen.example.helloworld.AppEvent");
    ///    receiver.Received += OnReceived;
    /// }
    /// </code>
    /// </example>
    /// <since_tizen> 6 </since_tizen>
    public class ApplicationEventReceiver : IDisposable
    {
        private bool disposedValue = false;
        private string _eventName;
        private IntPtr _eventHandle;

        private EventHandler<ApplicationEventArgs> s_eventHandler;
        private Interop.AppEvent.EventCallback s_callback;

        /// <summary>
        /// Initializer of class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public ApplicationEventReceiver(string eventName)
        {
            _eventName = eventName;
        }

        /// <summary>
        /// Finalizer of class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ~ApplicationEventReceiver()
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
            s_eventHandler?.Invoke(null, new ApplicationEventArgs(eventName, new Bundle(sbh)));
        }

        /// <summary>
        /// Occurs when events are received.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<ApplicationEventArgs> Received
        {
            add
            {
                if (s_eventHandler == null)
                {
                    if (s_callback == null)
                    {
                        s_callback = new Interop.AppEvent.EventCallback(OnEvent);
                    }

                    Interop.AppEvent.ErrorCode err = Interop.AppEvent.EventAddHandler(_eventName, s_callback, IntPtr.Zero, out _eventHandle);

                    if (err != Interop.AppEvent.ErrorCode.None)
                    {
                        ErrorFactory.ThrowException(err, "Add event handler");
                    }
                }

                s_eventHandler += value;
            }

            remove
            {
                s_eventHandler -= value;
                if (s_eventHandler == null)
                {
                    Interop.AppEvent.ErrorCode err = Interop.AppEvent.EventRemoveHandler(_eventHandle);

                    if (err != Interop.AppEvent.ErrorCode.None)
                    {
                        ErrorFactory.ThrowException(err, "Remove event handler");
                    }

                    s_callback = null;
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

                if (s_eventHandler != null)
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
