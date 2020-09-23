/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
 *
 */

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    public partial class GLWindow
    {
        private FocusChangedEventCallbackType _focusChangedEventCallback;
        private GLWindowTouchDataCallbackType _windowTouchDataCallback;
        private EventCallbackDelegateType1 _windowKeyCallbackDelegate;
        private WindowResizedEventCallbackType _windowResizedEventCallback;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void FocusChangedEventCallbackType(IntPtr window, bool focusGained);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool GLWindowTouchDataCallbackType(IntPtr touchData);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WindowResizedEventCallbackType(IntPtr windowSize);

        /// <summary>
        /// FocusChanged event.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<FocusChangedEventArgs> FocusChanged
        {
            add
            {
                if (_focusChangedEventCallback == null)
                {
                    _focusChangedEventCallback = OnWindowFocusedChanged;
                    FocusChangedSignal().Connect(_focusChangedEventCallback);
                }

                _focusChangedEventHandler += value;
            }
            remove
            {
                _focusChangedEventHandler -= value;

                if (_focusChangedEventHandler == null && FocusChangedSignal().Empty() == false && _focusChangedEventCallback != null)
                {
                    FocusChangedSignal().Disconnect(_focusChangedEventCallback);
                }
            }
        }

        /// <summary>
        /// Emits the event when the screen is touched and when the touch ends.<br />
        /// If there are multiple touch points then it is emitted when the first touch occurs and
        /// when the last finger is lifted too.<br />
        /// Even though incoming events are interrupted, the event occurs.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<TouchEventArgs> TouchEvent
        {
            add
            {
                if (_windoTouchDataEventHandler == null)
                {
                    _windowTouchDataCallback = OnWindowTouch;
                    this.TouchSignal().Connect(_windowTouchDataCallback);
                }
                _windoTouchDataEventHandler += value;
            }
            remove
            {
                _windoTouchDataEventHandler -= value;
                if (_windoTouchDataEventHandler == null && TouchSignal().Empty() == false && _windowTouchDataCallback != null)
                {
                    this.TouchSignal().Disconnect(_windowTouchDataCallback);
                }
            }
        }

        /// <summary>
        /// Emits the event when the key event is received.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<KeyEventArgs> KeyEvent
        {
            add
            {
                if (_stageKeyHandler == null)
                {
                    _windowKeyCallbackDelegate = OnStageKey;
                    KeyEventSignal().Connect(_windowKeyCallbackDelegate);
                }
                _stageKeyHandler += value;
            }
            remove
            {
                _stageKeyHandler -= value;
                if (_stageKeyHandler == null && KeyEventSignal().Empty() == false)
                {
                    KeyEventSignal().Disconnect(_windowKeyCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// Emits the event when the window resized.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ResizedEventArgs> Resized
        {
            add
            {
                if (_windowResizedEventHandler == null)
                {
                    _windowResizedEventCallback = OnResized;
                    GLWindowResizedSignal().Connect(_windowResizedEventCallback);
                }

                _windowResizedEventHandler += value;
            }
            remove
            {
                _windowResizedEventHandler -= value;

                if (_windowResizedEventHandler == null && GLWindowResizedSignal().Empty() == false && _windowResizedEventCallback != null)
                {
                    GLWindowResizedSignal().Disconnect(_windowResizedEventCallback);
                }
            }
        }

        private event EventHandler<FocusChangedEventArgs> _focusChangedEventHandler;
        private event EventHandler<TouchEventArgs> _windoTouchDataEventHandler;
        private event EventHandler<KeyEventArgs> _stageKeyHandler;
        private event EventHandler<ResizedEventArgs> _windowResizedEventHandler;

        internal WindowFocusSignalType FocusChangedSignal()
        {
            WindowFocusSignalType ret = new WindowFocusSignalType(Interop.GLWindow.GlWindow_FocusChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal KeyEventSignal KeyEventSignal()
        {
            KeyEventSignal ret = new KeyEventSignal(Interop.GLWindow.GlWindow_KeyEventSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TouchSignal TouchSignal()
        {
            TouchSignal ret = new TouchSignal(Interop.GLWindow.GlWindow_TouchSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal GLWindowResizedSignal GLWindowResizedSignal()
        {
            GLWindowResizedSignal ret = new GLWindowResizedSignal(Interop.GLWindow.GlWindow_ResizedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Disconnect all native signals
        /// </summary>
        internal void DisconnectNativeSignals()
        {
            if (_focusChangedEventCallback != null)
            {
                FocusChangedSignal().Disconnect(_focusChangedEventCallback);
            }

            if (_windowTouchDataCallback != null)
            {
                TouchSignal().Disconnect(_windowTouchDataCallback);
            }

            if (_windowKeyCallbackDelegate != null)
            {
                KeyEventSignal().Disconnect(_windowKeyCallbackDelegate);
            }

            if (_windowResizedEventCallback != null)
            {
                GLWindowResizedSignal().Disconnect(_windowResizedEventCallback);
            }
        }

        private void OnWindowFocusedChanged(IntPtr window, bool focusGained)
        {
            if (window == IntPtr.Zero)
            {
                NUILog.Error("OnWindowFocusedChanged() Window is null! Do nothing!");
                return;
            }

            FocusChangedEventArgs e = new FocusChangedEventArgs();

            e.FocusGained = focusGained;

            if (_focusChangedEventHandler != null)
            {
                _focusChangedEventHandler(this, e);
            }
        }

        private bool OnWindowTouch(IntPtr touchData)
        {
            if (touchData == global::System.IntPtr.Zero)
            {
                NUILog.Error("touchData should not be null!");
                return false;
            }

            TouchEventArgs e = new TouchEventArgs();

            e.Touch = Tizen.NUI.Touch.GetTouchFromPtr(touchData);

            if (_windoTouchDataEventHandler != null)
            {
                _windoTouchDataEventHandler(this, e);
            }
            return false;
        }

        // Callback for Stage KeyEventsignal
        private void OnStageKey(IntPtr data)
        {
            KeyEventArgs e = new KeyEventArgs();
            e.Key = Tizen.NUI.Key.GetKeyFromPtr(data);


            if (_stageKeyHandler != null)
            {
                //here we send all data to user event handlers
                _stageKeyHandler(this, e);
            }
        }

        private void OnResized(IntPtr windowSize)
        {
            ResizedEventArgs e = new ResizedEventArgs();
            // var val = new Uint16Pair(windowSize, false);
            // e.WindowSize = new Size2D(val.GetWidth(), val.GetHeight());
            // val.Dispose();

            // Workaround : windowSize should be valid pointer from dali, 
            // but currenlty it is fixed and is not Uint16Pair class.
            // will be fixed later.
            e.WindowSize = this.WindowSize;

            if (_windowResizedEventHandler != null)
            {
                _windowResizedEventHandler(this, e);
            }
        }

        /// <summary>
        /// The focus changed event argument.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class FocusChangedEventArgs : EventArgs
        {
            /// <summary>
            /// FocusGained flag.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool FocusGained
            {
                get;
                set;
            }
        }

        /// <summary>
        /// The touch event argument.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class TouchEventArgs : EventArgs
        {
            private Touch _touch;

            /// <summary>
            /// Touch.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Touch Touch
            {
                get
                {
                    return _touch;
                }
                set
                {
                    _touch = value;
                }
            }
        }

        /// <summary>
        /// Key event arguments.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class KeyEventArgs : EventArgs
        {
            private Key _key;

            /// <summary>
            /// Key.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Key Key
            {
                get
                {
                    return _key;
                }
                set
                {
                    _key = value;
                }
            }
        }

        /// <summary>
        /// Feeds a key event into the window.
        /// This resized event arguments.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ResizedEventArgs : EventArgs
        {
            Size2D _windowSize;

            /// <summary>
            /// This window size.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Size2D WindowSize
            {
                get
                {
                    return _windowSize;
                }
                set
                {
                    _windowSize = value;
                }
            }
        }

        /// <summary>
        /// VisibilityChangedArgs
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class VisibilityChangedArgs : EventArgs
        {
            private bool _visibility;
            /// <summary>
            /// Visibility
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool Visibility
            {
                get => _visibility;
                set {
                    _visibility = value;
                }
            }
        }

        private void OnVisibilityChanged(IntPtr window, bool visibility)
        {
            if (window == global::System.IntPtr.Zero)
            {
                NUILog.Error("[ERR] OnVisibilityChanged() window is null");
                return;
            }

            VisibilityChangedArgs e = new VisibilityChangedArgs();
            e.Visibility = visibility;
            if (VisibilityChangedEventHandler != null)
            {
                VisibilityChangedEventHandler.Invoke(this, e);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void GLVisibilityChangedEventCallbackType(IntPtr window, bool visibility);
        private GLVisibilityChangedEventCallbackType _GLVisibilityChangedEventCallback;
        private event EventHandler<VisibilityChangedArgs> VisibilityChangedEventHandler;
        private GLWindowVisibilityChangedEvent _GLVisibilityChangedEventSignal;

        /// <summary>
        /// EffectStart
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<VisibilityChangedArgs> VisibilityChanged
        {
            add
            {
                if (VisibilityChangedEventHandler == null)
                {
                    _GLVisibilityChangedEventCallback = OnVisibilityChanged;
                    _GLVisibilityChangedEventSignal = new GLWindowVisibilityChangedEvent(this);
                    _GLVisibilityChangedEventSignal.Connect(_GLVisibilityChangedEventCallback);
                }
                VisibilityChangedEventHandler += value;
            }
            remove
            {
                VisibilityChangedEventHandler -= value;
                if (VisibilityChangedEventHandler == null)
                {
                    if(_GLVisibilityChangedEventSignal != null)
                    {
                        if(_GLVisibilityChangedEventSignal.Empty() == false)
                        {
                            _GLVisibilityChangedEventSignal.Disconnect(_GLVisibilityChangedEventCallback);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// VisibiltyChangedSignalEmit
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void VisibiltyChangedSignalEmit(bool visibility)
        {
            if(_GLVisibilityChangedEventSignal == null)
            {
                _GLVisibilityChangedEventSignal = new GLWindowVisibilityChangedEvent(this);
            }
            _GLVisibilityChangedEventSignal.Emit(this, visibility);
        }
    }
}
