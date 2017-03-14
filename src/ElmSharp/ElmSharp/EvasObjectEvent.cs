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

namespace ElmSharp
{
    public interface IInvalidatable : IDisposable
    {
        void MakeInvalidate();
    }

    public enum EvasObjectCallbackType
    {
        MouseIn,
        MouseOut,
        MouseDown,
        MouseUp,
        MouseMove,
        MouseWheel,
        MultiDown,
        MultiUp,
        MultiMove,
        Free,
        KeyDown,
        KeyUp,
        FocusIn,
        FocusOut,
        Show,
        Hide,
        Move,
        Resize,
        Restack,
        Del,
        Hold,
        ChangedSizeHints,
        ImagePreloaded,
        CanvasFocusIn,
        CanvasFocusOut,
        RenderFlushPre,
        RenderFlushPost,
        CanvasObjectFocusIn,
        CanvasObjectFocusOut,
        ImageUnloaded,
        RenderPre,
        RenderPost,
        ImageResize,
        DeviceChanged,
        AxisUpdate,
        CanvasViewportResize
    }

    public class EvasObjectEvent<TEventArgs> : IInvalidatable where TEventArgs : EventArgs
    {
        public delegate TEventArgs SmartEventInfoParser(IntPtr data, IntPtr obj, IntPtr info);

        private bool _disposed = false;
        private EvasObject _sender;
        private IntPtr _handle;
        private readonly EvasObjectCallbackType _type;
        private readonly SmartEventInfoParser _parser;
        private readonly List<NativeCallback> _nativeCallbacks = new List<NativeCallback>();

        public EvasObjectEvent(EvasObject sender, EvasObjectCallbackType type, SmartEventInfoParser parser) : this(sender, sender.Handle, type, parser)
        {
        }

        internal EvasObjectEvent(EvasObject sender, IntPtr handle, EvasObjectCallbackType type, SmartEventInfoParser parser)
        {
            _sender = sender;
            _handle = handle;
            _type = type;
            _parser = parser;
            sender.AddToEventLifeTracker(this);
        }

        public EvasObjectEvent(EvasObject sender, EvasObjectCallbackType type) : this(sender, type, null)
        {
        }

        ~EvasObjectEvent()
        {
            Dispose(false);
        }

        private struct NativeCallback
        {
            public Interop.Evas.EventCallback callback;
            public EventHandler<TEventArgs> eventHandler;
        }

        public event EventHandler<TEventArgs> On
        {
            add
            {
                if (_handle == IntPtr.Zero)
                {
                    return;
                }
                EventHandler<TEventArgs> handler = value;
                var cb = new Interop.Evas.EventCallback((data, evas, obj, info) =>
                {
                    TEventArgs ea = _parser == null ? (TEventArgs)EventArgs.Empty : _parser(data, obj, info);
                    handler(_sender, ea);
                });
                _nativeCallbacks.Add(new NativeCallback { callback = cb, eventHandler = handler });
                int i = _nativeCallbacks.Count - 1;
                Interop.Evas.evas_object_event_callback_add(_handle, (Interop.Evas.ObjectCallbackType)_type, _nativeCallbacks[i].callback, IntPtr.Zero);
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
                    Interop.Evas.evas_object_event_callback_del(_handle, (Interop.Evas.ObjectCallbackType)_type, cb.callback);
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
                if (_handle != IntPtr.Zero)
                {
                    foreach (var cb in _nativeCallbacks)
                    {
                        Interop.Evas.evas_object_event_callback_del(_handle, (Interop.Evas.ObjectCallbackType)_type, cb.callback);
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

        public void MakeInvalidate()
        {
            _sender = null;
            _handle = IntPtr.Zero;
        }
    }

    public class EvasObjectEvent : IInvalidatable
    {
        private EvasObjectEvent<EventArgs> _evasObjectEvent;
        private event EventHandler _handlers;
        private bool _disposed = false;

        public EvasObjectEvent(EvasObject sender, EvasObjectCallbackType type) : this(sender, sender.Handle, type)
        {
        }

        internal EvasObjectEvent(EvasObject sender, IntPtr handle, EvasObjectCallbackType type)
        {
            _evasObjectEvent = new EvasObjectEvent<EventArgs>(sender, handle, type, null);
        }

        ~EvasObjectEvent()
        {
            Dispose(false);
        }

        public event EventHandler On
        {
            add
            {
                if (_handlers == null)
                {
                    _evasObjectEvent.On += SendEvent;
                }
                _handlers += value;
            }

            remove
            {
                _handlers -= value;
                if (_handlers == null)
                {
                    _evasObjectEvent.On -= SendEvent;
                }
            }
        }

        private void SendEvent(object sender, EventArgs e)
        {
            _handlers?.Invoke(sender, e);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _evasObjectEvent.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void MakeInvalidate()
        {
            _evasObjectEvent.MakeInvalidate();
        }
    }
}
