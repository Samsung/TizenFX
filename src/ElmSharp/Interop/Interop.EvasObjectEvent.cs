// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

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
                    foreach (var cb in _nativeCallbacks)
                    {
                        Evas.evas_object_event_callback_del(_handle, _type, cb.callback);
                    }
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
                    foreach (var cb in _nativeCallbacks)
                    {
                        Evas.evas_object_event_callback_del(_handle, _type, cb.callback);
                    }
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
