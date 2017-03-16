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
    public class EcoreEventType
    {
        public static readonly EcoreEventType KeyDown = new EcoreEventType(Interop.Libraries.EcoreInput, "ECORE_EVENT_KEY_DOWN");
        public static readonly EcoreEventType KeyUp = new EcoreEventType(Interop.Libraries.EcoreInput, "ECORE_EVENT_KEY_UP");
        public static readonly EcoreEventType MouseButtonDown = new EcoreEventType(Interop.Libraries.EcoreInput, "ECORE_EVENT_MOUSE_BUTTON_DOWN");
        public static readonly EcoreEventType MouseButtonUp = new EcoreEventType(Interop.Libraries.EcoreInput, "ECORE_EVENT_MOUSE_BUTTON_UP");
        public static readonly EcoreEventType MouseButtonCancel = new EcoreEventType(Interop.Libraries.EcoreInput, "ECORE_EVENT_MOUSE_BUTTON_CANCEL");
        public static readonly EcoreEventType MouseMove = new EcoreEventType(Interop.Libraries.EcoreInput, "ECORE_EVENT_MOUSE_MOVE");
        public static readonly EcoreEventType MouseWheel = new EcoreEventType(Interop.Libraries.EcoreInput, "ECORE_EVENT_MOUSE_WHEEL");
        public static readonly EcoreEventType MouseIn = new EcoreEventType(Interop.Libraries.EcoreInput, "ECORE_EVENT_MOUSE_IN");
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

    public class EcoreEvent<TEventArgs> : IDisposable where TEventArgs : EventArgs
    {
        public delegate TEventArgs EventInfoParser(IntPtr data, EcoreEventType type, IntPtr info);

        private bool _disposed = false;
        private EcoreEventType _eventType;
        private readonly EventInfoParser _parser;
        private readonly List<NativeCallback> _nativeCallbacks = new List<NativeCallback>();

        public EcoreEvent(EcoreEventType type) : this(type, null)
        {
        }

        public EcoreEvent(EcoreEventType type, EventInfoParser parser)
        {
            _eventType = type;
            _parser = parser;
        }

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

        public event EventHandler<TEventArgs> On
        {
            add
            {
                EventHandler<TEventArgs> handler = value;
                var cb = new Interop.Ecore.EcoreEventCallback((data, type, info) =>
                {
                    TEventArgs ea = _parser == null ? (TEventArgs)EventArgs.Empty : _parser(data, _eventType, info);
                    handler(this, ea);
                });
                IntPtr hNative = Interop.Ecore.ecore_event_handler_add(_eventType.GetValue(), cb, IntPtr.Zero);
                _nativeCallbacks.Add(new NativeCallback { callback = cb, eventHandler = handler, nativeHandler = hNative });
            }
            remove
            {
                EventHandler<TEventArgs> handler = value;
                var callbacks = _nativeCallbacks.Where(cb => cb.eventHandler == handler);
                foreach (var cb in callbacks)
                {
                    Interop.Ecore.ecore_event_handler_del(cb.nativeHandler);
                }
            }
        }

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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    public class EcoreEvent : EcoreEvent<EventArgs>
    {
        public EcoreEvent(EcoreEventType type) : base(type)
        {
        }
    }
}

