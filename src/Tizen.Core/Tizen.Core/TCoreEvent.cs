/*
 * Copyright (c) 2024 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace Tizen.Core
{
    /// <summary>
    /// Represents the TCoreEvent class.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    public class TCoreEvent : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;
        private Interop.LibTizenCore.TizenCoreEvent.EventHandlerCallback _callback = null;

        /// <summary>
        /// Constructor for creating a new TCoreEvent instance.
        /// </summary>
        /// <exception cref="OutOfMemoryException">Thrown when out of memory.</exception>
        /// <example>
        /// <code>
        /// 
        /// var coreEvent = new TCoreEvent();
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public TCoreEvent()
        {
            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCoreEvent.Create(out _handle);
            TCoreErrorFactory.CheckAndThrownException(error, "Failed to create event");

            _callback = new Interop.LibTizenCore.TizenCoreEvent.EventHandlerCallback(EventHandlerCallback);
            error = Interop.LibTizenCore.TizenCoreEvent.AddHandler(_handle, _callback, IntPtr.Zero, out IntPtr _);
            TCoreErrorFactory.CheckAndThrownException(error, "Failed to add event handler");
        }

        /// <summary>
        /// Finalizer of the class TCoreEvent.
        /// </summary>
        ~TCoreEvent()
        {
            Dispose(false);
        }

        private bool EventHandlerCallback(IntPtr eventData, IntPtr userData)
        {
            using (var eventObject = new TCoreEventObject(eventData))
            {
                EventReceived?.Invoke(this, new TCoreEventArgs(eventObject));
            }
            return true;
        }

        /// <summary>
        /// Occurrs whenever the event is received in the main loop of the task.
        /// </summary>
        /// <remarks>
        /// The registered event handler will be invoked when the TCoreEvent is added to the specific task.
        /// </remarks>
        /// <example>
        /// <code>
        /// 
        /// var coreEvent = new TCoreEvent();
        /// coreEvent.EventReceived += (s, e) => {
        ///   Console.WriteLine("OnEventReceived. Message = {}", (string)e.Data);
        /// };
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public event EventHandler<TCoreEventArgs> EventReceived;

        /// <summary>
        /// Emits an event object.
        /// </summary>
        /// <param name="eventObject">The event object instance.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument is null.</exception>
        /// <example>
        /// <code>
        /// 
        /// var coreEvent = new TCoreEvent();
        /// coreEvent.EventReceived += (s, e) => {
        ///   Console.WriteLine("OnEventReceived. Message = {}", (string)e.Data);
        /// };
        /// 
        /// var coreTask = TCoreTask.Find("EventTask");
        /// if (coreTask != null)
        /// {
        ///   coreTask.AddEvent(coreEvent);
        ///   string message = "Test Event";
        ///   using (var eventObject = new TCoreEventObject(1, message))
        ///   {
        ///     coreTask.EmitEvent(eventObject);
        ///   }
        /// }
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public void Emit(TCoreEventObject eventObject)
        {
            if (eventObject == null)
            {
                throw new ArgumentNullException(nameof(eventObject));
            }

            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCoreEvent.Emit(_handle, eventObject.Handle);
            TCoreErrorFactory.CheckAndThrownException(error, "Failed to emit event object");
            eventObject.Handle = IntPtr.Zero;
        }

        internal IntPtr Handle { get { return _handle; } set { _handle = value; } }

        /// <summary>
        /// Release any unmanaged resources used by this object.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        /// <since_tizen> 12 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_handle != IntPtr.Zero)
                    {
                        Interop.LibTizenCore.TizenCoreEvent.Destroy(_handle);
                        _handle = IntPtr.Zero;
                    }
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Release any unmanaged resources used by this object.
        /// </summary>
        /// <since_tize> 12 </since_tize>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
