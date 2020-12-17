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
using System.ComponentModel;
using System.Linq;

namespace ElmSharp
{
    /// <summary>
    /// IInvalidatable is an interface, which can be overrided by its children class.
    /// Inherits IDisposable.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public interface IInvalidatable : IDisposable
    {
        /// <summary>
        /// Makes the current instance invalidate.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        void MakeInvalidate();
    }

    /// <summary>
    /// Enumeration for EvasObjectCallbackType.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public enum EvasObjectCallbackType
    {
        /// <summary>
        /// Mouse In Event CallbackType.
        /// </summary>
        MouseIn,

        /// <summary>
        /// Mouse Out Event CallbackType.
        /// </summary>
        MouseOut,

        /// <summary>
        /// Mouse Button Down Event CallbackType.
        /// </summary>
        MouseDown,

        /// <summary>
        /// Mouse Button Up Event CallbackType.
        /// </summary>
        MouseUp,

        /// <summary>
        /// Mouse Move Event CallbackType.
        /// </summary>
        MouseMove,

        /// <summary>
        /// Mouse Wheel Event CallbackType.
        /// </summary>
        MouseWheel,

        /// <summary>
        /// Multi-touch Down Event CallbackType.
        /// </summary>
        MultiDown,

        /// <summary>
        /// Multi-touch Up Event CallbackType.
        /// </summary>
        MultiUp,

        /// <summary>
        /// Multi-touch Move Event CallbackType.
        /// </summary>
        MultiMove,

        /// <summary>
        /// Object Being Freed (Called after Del).
        /// </summary>
        Free,

        /// <summary>
        /// Key Press Event CallbackType.
        /// </summary>
        KeyDown,

        /// <summary>
        /// Key Release Event CallbackType.
        /// </summary>
        KeyUp,

        /// <summary>
        /// Focus In Event CallbackType.
        /// </summary>
        FocusIn,

        /// <summary>
        /// Focus Out Event CallbackType.
        /// </summary>
        FocusOut,

        /// <summary>
        /// Show Event CallbackType.
        /// </summary>
        Show,

        /// <summary>
        /// Hide Event CallbackType.
        /// </summary>
        Hide,

        /// <summary>
        /// Move Event CallbackType.
        /// </summary>
        Move,

        /// <summary>
        /// Resize Event CallbackType.
        /// </summary>
        Resize,

        /// <summary>
        /// Restack Event CallbackType.
        /// </summary>
        Restack,

        /// <summary>
        /// Object being deleted (called before Free).
        /// </summary>
        Del,

        /// <summary>
        /// Hold Event CallbackType, Informational purpose event to indicate something.
        /// </summary>
        Hold,

        /// <summary>
        /// Size hints changed the CallbackType event.
        /// </summary>
        ChangedSizeHints,

        /// <summary>
        /// Image has been pre-loaded.
        /// </summary>
        ImagePreloaded,

        /// <summary>
        /// Canvas got focus as a whole.
        /// </summary>
        CanvasFocusIn,

        /// <summary>
        /// Canvas lost focus as a whole.
        /// </summary>
        CanvasFocusOut,

        /// <summary>
        /// Called just before rendering is updated on the canvas target.
        /// </summary>
        RenderFlushPre,

        /// <summary>
        /// Called just after rendering is updated on the canvas target.
        /// </summary>
        RenderFlushPost,

        /// <summary>
        /// Canvas object got focus.
        /// </summary>
        CanvasObjectFocusIn,

        /// <summary>
        /// Canvas object lost focus.
        /// </summary>
        CanvasObjectFocusOut,

        /// <summary>
        /// Image data has been unloaded (by some mechanism in Evas that throw out the original image data).
        /// </summary>
        ImageUnloaded,

        /// <summary>
        /// Called just before rendering starts on the canvas target.
        /// </summary>
        RenderPre,

        /// <summary>
        /// Called just after rendering stops on the canvas target.
        /// </summary>
        RenderPost,

        /// <summary>
        /// Image size is changed.
        /// </summary>
        ImageResize,

        /// <summary>
        /// Devices added, removed, or changed on canvas.
        /// </summary>
        DeviceChanged,

        /// <summary>
        /// Axis is changed.
        /// </summary>
        AxisUpdate,

        /// <summary>
        /// Canvas Viewport size is changed.
        /// </summary>
        CanvasViewportResize
    }

    /// <summary>
    /// Event class for EvasObject.
    /// </summary>
    /// <typeparam name="TEventArgs">Kinds of EventArgs.</typeparam>
    /// <since_tizen> preview </since_tizen>
    public class EvasObjectEvent<TEventArgs> : IInvalidatable where TEventArgs : EventArgs
    {
        /// <summary>
        /// SmartEventInfoParser delegate of the EvasObjectEvent class.
        /// </summary>
        /// <param name="data">data</param>
        /// <param name="obj">obj</param>
        /// <param name="info">info</param>
        /// <returns>Delegate handle.</returns>
        /// <since_tizen> preview </since_tizen>
        public delegate TEventArgs SmartEventInfoParser(IntPtr data, IntPtr obj, IntPtr info);

        private bool _disposed = false;
        private EvasObject _sender;
        private IntPtr _handle;
        private readonly EvasObjectCallbackType _type;
        private readonly SmartEventInfoParser _parser;
        private readonly List<NativeCallback> _nativeCallbacks = new List<NativeCallback>();

        /// <summary>
        /// Creates and initializes a new instance of the EvasObjectEvent.
        /// </summary>
        /// <param name="sender">EvasObject class belongs to.</param>
        /// <param name="type">EvasObjectCallbackType</param>
        /// <param name="parser">SmartEventInfoParser</param>
        /// <since_tizen> preview </since_tizen>
        public EvasObjectEvent(EvasObject sender, EvasObjectCallbackType type, SmartEventInfoParser parser) : this(sender, sender.Handle, type, parser)
        {
        }

        /// <summary>
        /// Creates and initializes a new instance of the EvasObjectEvent.
        /// </summary>
        /// <param name="sender">EvasObject class belongs to.</param>
        /// <param name="handle">EvasObject handle.</param>
        /// <param name="type">EvasObjectCallbackType</param>
        /// <param name="parser">SmartEventInfoParser</param>
        /// <since_tizen> preview </since_tizen>
        [EditorBrowsableAttribute(EditorBrowsableState.Never)]
        public EvasObjectEvent(EvasObject sender, IntPtr handle, EvasObjectCallbackType type, SmartEventInfoParser parser)
        {
            _sender = sender;
            _handle = handle;
            _type = type;
            _parser = parser;
            sender.AddToEventLifeTracker(this);
        }

        /// <summary>
        /// Creates and initializes a new instance of the EvasObjectEvent.
        /// </summary>
        /// <param name="sender">EvasObject class belongs to.</param>
        /// <param name="type">SmartEventInfoParser</param>
        /// <since_tizen> preview </since_tizen>
        public EvasObjectEvent(EvasObject sender, EvasObjectCallbackType type) : this(sender, type, null)
        {
        }

        /// <summary>
        /// Destroys the EvasObjectEvent object.
        /// </summary>
        ~EvasObjectEvent()
        {
            Dispose(false);
        }

        private struct NativeCallback
        {
            public Interop.Evas.EventCallback callback;
            public EventHandler<TEventArgs> eventHandler;
        }

        /// <summary>
        /// On Event Handler of the EvasObjectEvent.
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

        /// <summary>
        /// Releases all the resources currently used by this instance.
        /// </summary>
        /// <param name="disposing">
        /// true if the managed resources should be disposed
        /// otherwise, false.
        /// </param>
        /// <since_tizen> preview </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _sender.RemoveFromEventLifeTracker(this);
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
    }

    /// <summary>
    /// Event class for EvasObject.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class EvasObjectEvent : IInvalidatable
    {
        private EvasObjectEvent<EventArgs> _evasObjectEvent;

        private event EventHandler _handlers;

        private bool _disposed = false;

        /// <summary>
        /// Creates and initializes a new instance of the EvasObjectEvent.
        /// </summary>
        /// <param name="sender">EvasObject class belongs to.</param>
        /// <param name="type">EvasObjectCallbackType</param>
        /// <since_tizen> preview </since_tizen>
        public EvasObjectEvent(EvasObject sender, EvasObjectCallbackType type) : this(sender, sender.Handle, type)
        {
        }

        /// <summary>
        /// Creates and initializes a new instance of the EvasObjectEvent.
        /// </summary>
        /// <param name="sender">EvasObject class belongs to.</param>
        /// <param name="handle">EvasObject handle.</param>
        /// <param name="type">EvasObjectCallbackType</param>
        /// <since_tizen> preview </since_tizen>
        [EditorBrowsableAttribute(EditorBrowsableState.Never)]
        public EvasObjectEvent(EvasObject sender, IntPtr handle, EvasObjectCallbackType type)
        {
            _evasObjectEvent = new EvasObjectEvent<EventArgs>(sender, handle, type, null);
        }

        /// <summary>
        /// Destroys the EvasObjectEvent object.
        /// </summary>
        ~EvasObjectEvent()
        {
            Dispose(false);
        }

        /// <summary>
        /// On Event Handler of EvasObjectEvent.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
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

        /// <summary>
        /// Releases all the resources currently used by this instance.
        /// </summary>
        /// <param name="disposing">
        /// true if managed resources should be disposed
        /// otherwise, false.
        /// </param>
        /// <since_tizen> preview </since_tizen>
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
            _evasObjectEvent.MakeInvalidate();
        }
    }
}