/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
        private FocusChangedEventCallbackType focusChangedEventCallback;
        private GLWindowTouchDataCallbackType windowTouchDataCallback;
        private EventCallbackDelegateType1 windowKeyCallbackDelegate;
        private WindowResizedEventCallbackType windowResizedEventCallback;

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
                if (focusChangedEventCallback == null)
                {
                    focusChangedEventCallback = OnWindowFocusedChanged;
                    FocusChangedSignal().Connect(focusChangedEventCallback);
                }

                focusChangedEventHandler += value;
            }
            remove
            {
                focusChangedEventHandler -= value;

                if (focusChangedEventHandler == null && FocusChangedSignal().Empty() == false && focusChangedEventCallback != null)
                {
                    FocusChangedSignal().Disconnect(focusChangedEventCallback);
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
                if (windoTouchDataEventHandler == null)
                {
                    windowTouchDataCallback = OnWindowTouch;
                    this.TouchSignal().Connect(windowTouchDataCallback);
                }
                windoTouchDataEventHandler += value;
            }
            remove
            {
                windoTouchDataEventHandler -= value;
                if (windoTouchDataEventHandler == null && TouchSignal().Empty() == false && windowTouchDataCallback != null)
                {
                    this.TouchSignal().Disconnect(windowTouchDataCallback);
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
                if (stageKeyHandler == null)
                {
                    windowKeyCallbackDelegate = OnStageKey;
                    KeyEventSignal().Connect(windowKeyCallbackDelegate);
                }
                stageKeyHandler += value;
            }
            remove
            {
                stageKeyHandler -= value;
                if (stageKeyHandler == null && KeyEventSignal().Empty() == false)
                {
                    KeyEventSignal().Disconnect(windowKeyCallbackDelegate);
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
                if (windowResizedEventHandler == null)
                {
                    windowResizedEventCallback = OnResized;
                    GLWindowResizedSignal().Connect(windowResizedEventCallback);
                }

                windowResizedEventHandler += value;
            }
            remove
            {
                windowResizedEventHandler -= value;

                if (windowResizedEventHandler == null && GLWindowResizedSignal().Empty() == false && windowResizedEventCallback != null)
                {
                    GLWindowResizedSignal().Disconnect(windowResizedEventCallback);
                }
            }
        }

        private event EventHandler<FocusChangedEventArgs> focusChangedEventHandler;
        private event EventHandler<TouchEventArgs> windoTouchDataEventHandler;
        private event EventHandler<KeyEventArgs> stageKeyHandler;
        private event EventHandler<ResizedEventArgs> windowResizedEventHandler;

        internal WindowFocusSignalType FocusChangedSignal()
        {
            WindowFocusSignalType ret = new WindowFocusSignalType(Interop.GLWindow.GlWindowFocusChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal KeyEventSignal KeyEventSignal()
        {
            KeyEventSignal ret = new KeyEventSignal(Interop.GLWindow.GlWindowKeyEventSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TouchSignal TouchSignal()
        {
            TouchSignal ret = new TouchSignal(Interop.GLWindow.GlWindowTouchSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal GLWindowResizedSignal GLWindowResizedSignal()
        {
            GLWindowResizedSignal ret = new GLWindowResizedSignal(Interop.GLWindow.GlWindowResizedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Disconnect all native signals
        /// </summary>
        internal void DisconnectNativeSignals()
        {
            if (focusChangedEventCallback != null)
            {
                FocusChangedSignal().Disconnect(focusChangedEventCallback);
            }

            if (windowTouchDataCallback != null)
            {
                TouchSignal().Disconnect(windowTouchDataCallback);
            }

            if (windowKeyCallbackDelegate != null)
            {
                KeyEventSignal().Disconnect(windowKeyCallbackDelegate);
            }

            if (windowResizedEventCallback != null)
            {
                GLWindowResizedSignal().Disconnect(windowResizedEventCallback);
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

            if (focusChangedEventHandler != null)
            {
                focusChangedEventHandler(this, e);
            }
        }

        private bool OnWindowTouch(IntPtr touchData)
        {
            if (touchData == global::System.IntPtr.Zero)
            {
                NUILog.Error("touchData should not be null!");
                return false;
            }

            if (windoTouchDataEventHandler != null)
            {
                TouchEventArgs e = new TouchEventArgs();
                e.Touch = Tizen.NUI.Touch.GetTouchFromPtr(touchData);
                windoTouchDataEventHandler(this, e);
            }
            return false;
        }

        // Callback for Stage KeyEventsignal
        private void OnStageKey(IntPtr data)
        {
            if (stageKeyHandler != null)
            {
                KeyEventArgs e = new KeyEventArgs();
                e.Key = Tizen.NUI.Key.GetKeyFromPtr(data);
                //here we send all data to user event handlers
                stageKeyHandler(this, e);
            }
        }

        private void OnResized(IntPtr windowSize)
        {
            if (windowResizedEventHandler != null)
            {
                ResizedEventArgs e = new ResizedEventArgs();
                // var val = new Uint16Pair(windowSize, false);
                // e.WindowSize = new Size2D(val.GetWidth(), val.GetHeight());
                // val.Dispose();

                // Workaround : windowSize should be valid pointer from dali, 
                // but currently it is fixed and is not Uint16Pair class.
                // will be fixed later.
                e.WindowSize = this.WindowSize;
                windowResizedEventHandler(this, e);
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
            private Touch touch;

            /// <summary>
            /// Touch.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Touch Touch
            {
                get
                {
                    return touch;
                }
                set
                {
                    touch = value;
                }
            }
        }

        /// <summary>
        /// Key event arguments.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class KeyEventArgs : EventArgs
        {
            private Key key;

            /// <summary>
            /// Key.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Key Key
            {
                get
                {
                    return key;
                }
                set
                {
                    key = value;
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
            Size2D windowSize;

            /// <summary>
            /// This window size.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Size2D WindowSize
            {
                get
                {
                    return windowSize;
                }
                set
                {
                    windowSize = value;
                }
            }
        }

        /// <summary>
        /// VisibilityChangedArgs
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class VisibilityChangedEventArgs : EventArgs
        {
            private bool visibility;
            /// <summary>
            /// Visibility
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool Visibility
            {
                get => visibility;
                set
                {
                    visibility = value;
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

            VisibilityChangedEventArgs e = new VisibilityChangedEventArgs();
            e.Visibility = visibility;
            if (visibilityChangedEventHandler != null)
            {
                visibilityChangedEventHandler.Invoke(this, e);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void GLVisibilityChangedEventCallbackType(IntPtr window, bool visibility);
        private GLVisibilityChangedEventCallbackType glVisibilityChangedEventCallback;
        private event EventHandler<VisibilityChangedEventArgs> visibilityChangedEventHandler;
        private GLWindowVisibilityChangedEvent glVisibilityChangedEventSignal;

        /// <summary>
        /// EffectStart
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<VisibilityChangedEventArgs> VisibilityChanged
        {
            add
            {
                if (visibilityChangedEventHandler == null)
                {
                    glVisibilityChangedEventCallback = OnVisibilityChanged;
                    glVisibilityChangedEventSignal = new GLWindowVisibilityChangedEvent(this);
                    glVisibilityChangedEventSignal.Connect(glVisibilityChangedEventCallback);
                }
                visibilityChangedEventHandler += value;
            }
            remove
            {
                visibilityChangedEventHandler -= value;
                if (visibilityChangedEventHandler == null)
                {
                    if (glVisibilityChangedEventSignal != null)
                    {
                        if (glVisibilityChangedEventSignal.Empty() == false)
                        {
                            glVisibilityChangedEventSignal.Disconnect(glVisibilityChangedEventCallback);
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
            if (glVisibilityChangedEventSignal == null)
            {
                glVisibilityChangedEventSignal = new GLWindowVisibilityChangedEvent(this);
            }
            glVisibilityChangedEventSignal.Emit(this, visibility);
        }
    }
}
