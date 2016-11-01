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

internal static partial class Interop
{
    internal class EvasObjectEvent<TEventArgs> : IDisposable where TEventArgs : EventArgs
    {
        public delegate TEventArgs SmartEventInfoParser(IntPtr data, IntPtr obj, IntPtr info);

        private bool _disposed = false;
        private readonly object _sender;
        private readonly IntPtr _handle;
        private readonly Evas.ObjectCallbackType _type;
        private readonly SmartEventInfoParser _parser;
        private readonly List<NativeCallback> _nativeCallbacks = new List<NativeCallback>();

        public EvasObjectEvent(object sender, IntPtr handle, Evas.ObjectCallbackType type, SmartEventInfoParser parser)
        {
            _sender = sender;
            _handle = handle;
            _type = type;
            _parser = parser;
        }

        public EvasObjectEvent(object sender, IntPtr handle, Evas.ObjectCallbackType type) : this(sender, handle, type, null)
        {
        }

        ~EvasObjectEvent()
        {
            Dispose(false);
        }

        private struct NativeCallback
        {
            public Evas.EventCallback callback;
            public EventHandler<TEventArgs> eventHandler;
        }

        public event EventHandler<TEventArgs> On
        {
            add
            {
                EventHandler<TEventArgs> handler = value;
                var cb = new Evas.EventCallback((data, evas, obj, info) =>
                {
                    TEventArgs ea = _parser == null ? (TEventArgs)EventArgs.Empty : _parser(data, obj, info);
                    handler(_sender, ea);
                });
                _nativeCallbacks.Add(new NativeCallback { callback = cb, eventHandler = handler });
                int i = _nativeCallbacks.Count - 1;
                Evas.evas_object_event_callback_add(_handle, _type, _nativeCallbacks[i].callback, IntPtr.Zero);
            }

            remove
            {
                EventHandler<TEventArgs> handler = value;
                var callbacks = _nativeCallbacks.Where(cb => cb.eventHandler == handler);
                foreach (var cb in callbacks)
                {
                    Evas.evas_object_event_callback_del(_handle, _type, cb.callback);
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
                    Evas.evas_object_event_callback_del(_handle, _type, cb.callback);
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

    internal class EvasObjectEvent : IDisposable
    {
        private bool _disposed = false;
        private readonly object _sender;
        private readonly IntPtr _handle;
        private readonly Evas.ObjectCallbackType _type;
        private readonly List<NativeCallback> _nativeCallbacks = new List<NativeCallback>();

        public EvasObjectEvent(object sender, IntPtr handle, Evas.ObjectCallbackType type)
        {
            _sender = sender;
            _handle = handle;
            _type = type;
        }

        ~EvasObjectEvent()
        {
            Dispose(false);
        }

        private struct NativeCallback
        {
            public Evas.EventCallback callback;
            public EventHandler eventHandler;
        }

        public event EventHandler On
        {
            add
            {
                EventHandler handler = value;
                var cb = new Evas.EventCallback((data, evas, obj, info) =>
                {
                    handler(_sender, EventArgs.Empty);
                });
                _nativeCallbacks.Add(new NativeCallback { callback = cb, eventHandler = handler });
                int i = _nativeCallbacks.Count - 1;
                Evas.evas_object_event_callback_add(_handle, _type, _nativeCallbacks[i].callback, IntPtr.Zero);
            }

            remove
            {
                EventHandler handler = value;
                var callbacks = _nativeCallbacks.Where(cb => cb.eventHandler == handler);
                foreach (var cb in callbacks)
                {
                    Evas.evas_object_event_callback_del(_handle, _type, cb.callback);
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
                    Evas.evas_object_event_callback_del(_handle, _type, cb.callback);
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
}
