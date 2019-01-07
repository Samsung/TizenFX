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
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace ElmSharp
{
    /// <summary>
    /// It inherits <see cref="IInvalidatable"/>.
    /// The event with TEventArgs for <see cref="EvasObject"/>.
    /// EvasObject can elect the SmartEvent occurring inside them, to be reported back to their users via delegates.
    /// This way, you can extend EvasObject's own <see cref="EvasObjectEvent"/>.
    /// They are defined by an event string, which identifies them uniquely.
    /// </summary>
    /// <typeparam name="TEventArgs">The parameter for the event.</typeparam>
    /// <since_tizen> preview </since_tizen>
    public class SmartEvent<TEventArgs> : IInvalidatable where TEventArgs : EventArgs
    {
        /// <summary>
        /// The delegate for creating smart event item arguments.
        /// </summary>
        /// <param name="data">The item data.</param>
        /// <param name="obj">The sender object.</param>
        /// <param name="info">The item sender object.</param>
        /// <returns>Return smart event item args.</returns>
        /// <since_tizen> preview </since_tizen>
        public delegate TEventArgs SmartEventInfoParser(IntPtr data, IntPtr obj, IntPtr info);

        private EvasObject _sender;
        private readonly string _eventName;
        private IntPtr _handle;
        private readonly SmartEventInfoParser _parser;
        private readonly List<NativeCallback> _nativeCallbacks = new List<NativeCallback>();

        /// <summary>
        /// Creates and initializes a new instance of the SmartEvent class.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="eventName">The event name.</param>
        /// <param name="parser">The event parameter.</param>
        /// <since_tizen> preview </since_tizen>
        public SmartEvent(EvasObject sender, string eventName, SmartEventInfoParser parser) : this(sender, sender.Handle, eventName, parser)
        {
        }

        /// <summary>
        /// Creates and initializes a new instance of the SmartEvent class.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="handle">Teh event handler.</param>
        /// <param name="eventName">The event name.</param>
        /// <param name="parser">The event parser.</param>
        /// <since_tizen> preview </since_tizen>
        [EditorBrowsableAttribute(EditorBrowsableState.Never)]
        public SmartEvent(EvasObject sender, IntPtr handle, string eventName, SmartEventInfoParser parser)
        {
            _sender = sender;
            _eventName = eventName;
            _handle = handle;
            _parser = parser;
            sender.AddToEventLifeTracker(this);
        }

        /// <summary>
        /// Creates and initializes a new instance of the SmartEvent class.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="eventName">The event name.</param>
        /// <since_tizen> preview </since_tizen>
        public SmartEvent(EvasObject sender, string eventName) : this(sender, eventName, null)
        {
        }

        /// <summary>
        /// Destroys the SmartEvent object.
        /// </summary>
        ~SmartEvent()
        {
            Dispose(false);
        }

        private struct NativeCallback
        {
            public Interop.Evas.SmartCallback callback;
            public EventHandler<TEventArgs> eventHandler;
        }

        /// <summary>
        /// Adds or removes a delegate for the event.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<TEventArgs> On
        {
            add
            {
                if (_handle == IntPtr.Zero)
                {
                    return;
                }
                EventHandler<TEventArgs> handler = value;
                var cb = new Interop.Evas.SmartCallback((d, o, e) =>
                {
                    TEventArgs ea = _parser == null ? (TEventArgs)EventArgs.Empty : _parser(d, o, e);
                    handler(_sender, ea);
                });
                _nativeCallbacks.Add(new NativeCallback { callback = cb, eventHandler = handler });
                int i = _nativeCallbacks.Count - 1;
                Interop.Evas.evas_object_smart_callback_add(_handle, _eventName, _nativeCallbacks[i].callback, IntPtr.Zero);
            }

            remove
            {
                if (_handle == IntPtr.Zero)
                {
                    return;
                }
                EventHandler<TEventArgs> handler = value;
                var callbacks = _nativeCallbacks.Where(cb => cb.eventHandler == handler);
                foreach (var cb in callbacks)
                {
                    Interop.Evas.evas_object_smart_callback_del(_handle, _eventName, cb.callback);
                }
            }
        }

        /// <summary>
        /// Destroys the current object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Makes the current instance invalidate.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void MakeInvalidate()
        {
            _sender = null;
            _handle = IntPtr.Zero;
        }

        /// <summary>
        /// Releases all the resources currently used by this instance.
        /// </summary>
        /// <param name="disposing">
        /// true if the managed resources should be disposed,
        /// otherwise false.
        /// </param>
        /// <since_tizen> preview </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Place holder to dispose managed state (managed objects).
            }
            if (_handle != IntPtr.Zero)
            {
                foreach (var cb in _nativeCallbacks)
                {
                    Interop.Evas.evas_object_smart_callback_del(_handle, _eventName, cb.callback);
                }
            }
            _nativeCallbacks.Clear();
        }
    }

    /// <summary>
    /// It inherits <see cref="IInvalidatable"/>.
    /// EvasObject can elect the SmartEvent occurring inside them, to be reported back to their users via delegates.
    /// This way, you can extend EvasObject's own <see cref="EvasObjectEvent"/>.
    /// They are defined by an event string, which identifies them uniquely.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class SmartEvent : IInvalidatable
    {
        private SmartEvent<EventArgs> _smartEvent;

        private event EventHandler _handlers;

        /// <summary>
        /// Creates and initializes a new instance of the SmartEvent class.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="eventName">The event name.</param>
        /// <since_tizen> preview </since_tizen>
        public SmartEvent(EvasObject sender, string eventName) : this(sender, sender.RealHandle, eventName)
        {
        }

        /// <summary>
        /// Creates and initializes a new instance of the SmartEvent class.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="handle">The event handler.</param>
        /// <param name="eventName">The event name.</param>
        /// <since_tizen> preview </since_tizen>
        [EditorBrowsableAttribute(EditorBrowsableState.Never)]
        public SmartEvent(EvasObject sender, IntPtr handle, string eventName)
        {
            _smartEvent = new SmartEvent<EventArgs>(sender, handle, eventName, null);
        }

        /// <summary>
        /// Destroys the SmartEvent object.
        /// </summary>
        ~SmartEvent()
        {
            Dispose(false);
        }

        /// <summary>
        /// Adds or removes a delegate for the event.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler On
        {
            add
            {
                if (_handlers == null)
                {
                    _smartEvent.On += SendEvent;
                }
                _handlers += value;
            }

            remove
            {
                _handlers -= value;
                if (_handlers == null)
                {
                    _smartEvent.On -= SendEvent;
                }
            }
        }

        private void SendEvent(object sender, EventArgs e)
        {
            _handlers?.Invoke(sender, e);
        }

        /// <summary>
        /// Destroys the current object.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Makes the current instance invalidate.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public void MakeInvalidate()
        {
            _smartEvent.MakeInvalidate();
        }

        /// <summary>
        /// Releases all the resources currently used by this instance.
        /// </summary>
        /// <param name="disposing">
        /// true if the managed resources should be disposed,
        /// otherwise false.
        /// </param>
        /// <since_tizen> preview </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Place holder to dispose managed state (managed objects).
                _smartEvent.Dispose();
            }
        }
    }
}