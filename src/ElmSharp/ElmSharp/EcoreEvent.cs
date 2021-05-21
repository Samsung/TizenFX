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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ElmSharp
{
    /// <summary>
    /// The EcoreEventType is a type of EcoreEvent.
    /// It includes some predefined instance.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class EcoreEventType
    {
        /// <summary>
        /// Key down Ecore event type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly EcoreEventType KeyDown = new EcoreEventType(Interop.Libraries.EcoreInput, "ECORE_EVENT_KEY_DOWN");
        /// <summary>
        /// Key Up Ecore event type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly EcoreEventType KeyUp = new EcoreEventType(Interop.Libraries.EcoreInput, "ECORE_EVENT_KEY_UP");
        /// <summary>
        /// Mouse Button Down Ecore event type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly EcoreEventType MouseButtonDown = new EcoreEventType(Interop.Libraries.EcoreInput, "ECORE_EVENT_MOUSE_BUTTON_DOWN");
        /// <summary>
        /// Mouse Button Up Ecore event type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly EcoreEventType MouseButtonUp = new EcoreEventType(Interop.Libraries.EcoreInput, "ECORE_EVENT_MOUSE_BUTTON_UP");
        /// <summary>
        /// Mouse Button Cancel Ecore event type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly EcoreEventType MouseButtonCancel = new EcoreEventType(Interop.Libraries.EcoreInput, "ECORE_EVENT_MOUSE_BUTTON_CANCEL");
        /// <summary>
        /// Mouse Move Ecore event type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly EcoreEventType MouseMove = new EcoreEventType(Interop.Libraries.EcoreInput, "ECORE_EVENT_MOUSE_MOVE");
        /// <summary>
        /// Mouse Wheel Ecore event type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly EcoreEventType MouseWheel = new EcoreEventType(Interop.Libraries.EcoreInput, "ECORE_EVENT_MOUSE_WHEEL");
        /// <summary>
        /// Mouse In Ecore event type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly EcoreEventType MouseIn = new EcoreEventType(Interop.Libraries.EcoreInput, "ECORE_EVENT_MOUSE_IN");
        /// <summary>
        /// Mouse Out Ecore event type.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public static readonly EcoreEventType MouseOut = new EcoreEventType(Interop.Libraries.EcoreInput, "ECORE_EVENT_MOUSE_OUT");

        private string _lib;
        private string _name;
        private int _typeValue;

        private EcoreEventType(string lib, string name)
        {
            _lib = lib;
            _name = name;
            _typeValue = -1;
        }

        /// <summary>
        /// Gets the value associated with the specified type.
        /// </summary>
        /// <returns>The value of type.</returns>
        /// <since_tizen> preview </since_tizen>
        public int GetValue()
        {
            if (_typeValue < 0)
            {
                IntPtr hDll = Interop.Libdl.LoadLibrary(_lib);
                if (hDll != IntPtr.Zero)
                {
                    IntPtr pValue = Interop.Libdl.GetProcAddress(hDll, _name);
                    if (pValue != IntPtr.Zero)
                    {
                        _typeValue = Marshal.ReadInt32(pValue);
                    }
                    Interop.Libdl.FreeLibrary(hDll);
                }
            }
            return _typeValue;
        }
    }

    /// <summary>
    /// The EcoreEvent is a class to help create events that are being notified of events.
    /// </summary>
    /// <typeparam name="TEventArgs">Kinds of EventArgs.</typeparam>
    /// <since_tizen> preview </since_tizen>
    public class EcoreEvent<TEventArgs> : IDisposable where TEventArgs : EventArgs
    {
        /// <summary>
        /// EventInfoParser delegate of the EcoreEvent class.
        /// </summary>
        /// <param name="data">IntPtr</param>
        /// <param name="type">EcoreEventType</param>
        /// <param name="info">IntPtr</param>
        /// <returns></returns>
        /// <since_tizen> preview </since_tizen>
        public delegate TEventArgs EventInfoParser(IntPtr data, EcoreEventType type, IntPtr info);

        private bool _disposed = false;
        private EcoreEventType _eventType;
        private readonly EventInfoParser _parser;
        private readonly List<NativeCallback> _nativeCallbacks = new List<NativeCallback>();

        /// <summary>
        /// Creates and initializes a new instance of the EcoreEvent class.
        /// </summary>
        /// <param name="type">EcoreEventType</param>
        /// <since_tizen> preview </since_tizen>
        public EcoreEvent(EcoreEventType type) : this(type, null)
        {
        }

        /// <summary>
        /// Creates and initializes a new instance of the EcoreEvent class.
        /// </summary>
        /// <param name="type">EcoreEventType</param>
        /// <param name="parser">EventInfoParser</param>
        /// <since_tizen> preview </since_tizen>
        public EcoreEvent(EcoreEventType type, EventInfoParser parser)
        {
            _eventType = type;
            _parser = parser;
        }

        /// <summary>
        /// Destructor for the EcoreEvent class.
        /// </summary>
        ~EcoreEvent()
        {
            Dispose(false);
        }

        private struct NativeCallback
        {
            public Interop.Ecore.EcoreEventCallback callback;
            public IntPtr nativeHandler;
            public EventHandler<TEventArgs> eventHandler;
        }

        /// <summary>
        /// On Event Handler of the EcoreEvent.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public event EventHandler<TEventArgs> On
        {
            add
            {
                EventHandler<TEventArgs> handler = value;
                var cb = new Interop.Ecore.EcoreEventCallback((data, type, info) =>
                {
                    TEventArgs ea = _parser == null ? (TEventArgs)EventArgs.Empty : _parser(data, _eventType, info);
                    handler(this, ea);
                    return true;
                });
                IntPtr hNative = Interop.Ecore.ecore_event_handler_add(_eventType.GetValue(), cb, IntPtr.Zero);
                _nativeCallbacks.Add(new NativeCallback { callback = cb, eventHandler = handler, nativeHandler = hNative });
            }
            remove
            {
                EventHandler<TEventArgs> handler = value;
                var callbacks = _nativeCallbacks.Where(cb => cb.eventHandler == handler).ToList();
                foreach (var cb in callbacks)
                {
                    Interop.Ecore.ecore_event_handler_del(cb.nativeHandler);
                    _nativeCallbacks.Remove(cb);
                }
            }
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
            if (!_disposed)
            {
                if (disposing)
                {
                    // Place holder to dispose managed state (managed objects).
                }
                foreach (var cb in _nativeCallbacks)
                {
                    Interop.Ecore.ecore_event_handler_del(cb.nativeHandler);
                }
                _nativeCallbacks.Clear();
                _disposed = true;
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
    }

    /// <summary>
    /// The event class for EcoreEvent.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class EcoreEvent : EcoreEvent<EventArgs>
    {
        /// <summary>
        /// Creates and initializes a new instance of the EcoreEvent class.
        /// </summary>
        /// <param name="type">EcoreEventType</param>
        /// <since_tizen> preview </since_tizen>
        public EcoreEvent(EcoreEventType type) : base(type)
        {
        }
    }
}

