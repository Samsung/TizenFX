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
    /// Represents the event used for broadcasting events.
    /// </summary>
    /// <remarks>
    /// This class provides functionality for managing events that are broadcasted across multiple components in an application.
    /// It enables communication between different parts of the code without resorting to direct references or global variables.
    /// By implementing the IDisposable interface, it ensures proper resource management and prevents memory leaks.
    /// </remarks>
    /// <since_tizen> 12 </since_tizen>
#pragma warning disable CA1716
    public class Event : IDisposable
#pragma warning restore CA1716
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;
        private Interop.LibTizenCore.TizenCoreEvent.EventHandlerCallback _callback = null;

        /// <summary>
        /// Constructor for creating a new event instance.
        /// </summary>
        /// <remarks>
        /// This constructor initializes a new event instance. It may throw exceptions if there are any issues during initialization such as running out of memory or performing an invalid operation.
        /// </remarks>
        /// <exception cref="OutOfMemoryException">Thrown when out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <example>
        /// Here's an example showing how to create a new event instance:
        /// <code>
        /// Create a new event instance
        /// var coreEvent = new Event();
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public Event()
        {
            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCoreEvent.Create(out _handle);
            TCoreErrorFactory.CheckAndThrownException(error, "Failed to create event");

            _callback = new Interop.LibTizenCore.TizenCoreEvent.EventHandlerCallback(EventHandlerCallback);
            error = Interop.LibTizenCore.TizenCoreEvent.AddHandler(_handle, _callback, IntPtr.Zero, out IntPtr _);
            TCoreErrorFactory.CheckAndThrownException(error, "Failed to add event handler");

            Source = IntPtr.Zero;
            Id = 0;
        }

        /// <summary>
        /// Finalizes an instance of the Event class.
        /// </summary>
        ~Event()
        {
            Dispose(false);
        }

        private bool EventHandlerCallback(IntPtr eventData, IntPtr userData)
        {
            using (var eventObject = new EventObject(eventData))
            {
                EventReceived?.Invoke(this, new EventReceivedEventArgs(eventObject));
                eventObject.Handle = IntPtr.Zero;
            }
            return true;
        }

        /// <summary>
        /// Occurrs whenever the event is received in the main loop of the task.
        /// </summary>
        /// <remarks>
        /// The registered event handler will be invoked when the event is added to the specific task.
        /// </remarks>
        /// <example>
        /// <code>
        /// 
        /// var coreEvent = new Event();
        /// coreEvent.EventReceived += (s, e) => {
        ///   Console.WriteLine("OnEventReceived. Message = {}", (string)e.Data);
        /// };
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public event EventHandler<EventReceivedEventArgs> EventReceived;

        /// <summary>
        /// Emits an event object to the event.
        /// The emitted event object is queued and delivered to the registered EventHandlers on the main loop of the task.
        /// </summary>
        /// <param name="eventObject">The event object instance.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <remarks>
        /// If the event is not added to the task, the emitted event object will be pended until the event is added to the task.
        /// </remarks>
        /// <example>
        /// <code>
        /// 
        /// var coreEvent = new Event();
        /// coreEvent.EventReceived += (s, e) => {
        ///   Console.WriteLine("OnEventReceived. Message = {}", (string)e.Data);
        /// };
        /// 
        /// var task = TizenCore.Find("EventTask");
        /// if (task != null)
        /// {
        ///   task.AddEvent(coreEvent);
        ///   string message = "Test Event";
        ///   using (var eventObject = new EventObject(1, message))
        ///   {
        ///     coreEvent.Emit(eventObject);
        ///   }
        /// }
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public void Emit(EventObject eventObject)
        {
            if (eventObject == null)
            {
                throw new ArgumentNullException(nameof(eventObject));
            }

            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCoreEvent.Emit(_handle, eventObject.Handle);
            if (error == Interop.LibTizenCore.ErrorCode.InvalidParameter)
            {
                error = Interop.LibTizenCore.ErrorCode.InvalidContext;
            }
            TCoreErrorFactory.CheckAndThrownException(error, "Failed to emit event object");
            eventObject.Handle = IntPtr.Zero;
        }

        internal IntPtr Handle { get { return _handle; } }
        internal IntPtr Source { get; set; }
        internal int Id { get; set; }

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
