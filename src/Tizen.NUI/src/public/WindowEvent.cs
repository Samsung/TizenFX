﻿/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
    /// <summary>
    /// The window class is used internally for drawing.<br />
    /// The window has an orientation and indicator properties.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class Window
    {
        private WindowFocusChangedEventCallbackType _windowFocusChangedEventCallback;
        private RootLayerTouchDataCallbackType _rootLayerTouchDataCallback;
        private WheelEventCallbackType _wheelEventCallback;
        private EventCallbackDelegateType1 _stageKeyCallbackDelegate;
        private EventCallbackDelegateType0 _stageEventProcessingFinishedEventCallbackDelegate;
        private EventHandler _stageContextLostEventHandler;
        private EventCallbackDelegateType0 _stageContextLostEventCallbackDelegate;
        private EventHandler _stageContextRegainedEventHandler;
        private EventCallbackDelegateType0 _stageContextRegainedEventCallbackDelegate;
        private EventHandler _stageSceneCreatedEventHandler;
        private EventCallbackDelegateType0 _stageSceneCreatedEventCallbackDelegate;
        private WindowResizedEventCallbackType _windowResizedEventCallback;
        private WindowFocusChangedEventCallbackType _windowFocusChangedEventCallback2;
        private TransitionEffectEventCallbackType transitionEffectEventCallback;
        private WindowTransitionEffectSignal transitionEffectSignal;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WindowFocusChangedEventCallbackType(bool focusGained);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool RootLayerTouchDataCallbackType(IntPtr view, IntPtr touchData);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool WheelEventCallbackType(IntPtr view, IntPtr wheelEvent);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WindowResizedEventCallbackType(IntPtr windowSize);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WindowFocusChangedEventCallbackType2(bool focusGained);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void TransitionEffectEventCallbackType(IntPtr window, int state, int type);

        /// <summary>
        /// FocusChanged event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<FocusChangedEventArgs> FocusChanged
        {
            add
            {
                if (_windowFocusChangedEventHandler == null)
                {
                    _windowFocusChangedEventCallback = OnWindowFocusedChanged;
                    WindowFocusChangedSignal().Connect(_windowFocusChangedEventCallback);
                }

                _windowFocusChangedEventHandler += value;
            }
            remove
            {
                _windowFocusChangedEventHandler -= value;

                if (_windowFocusChangedEventHandler == null && WindowFocusChangedSignal().Empty() == false && _windowFocusChangedEventCallback != null)
                {
                    WindowFocusChangedSignal().Disconnect(_windowFocusChangedEventCallback);
                }
            }
        }

        /// <summary>
        /// This event is emitted when the screen is touched and when the touch ends.<br />
        /// If there are multiple touch points, then this will be emitted when the first touch occurs and
        /// then when the last finger is lifted.<br />
        /// An interrupted event will also be emitted (if it occurs).<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<TouchEventArgs> TouchEvent
        {
            add
            {
                if (_rootLayerTouchDataEventHandler == null)
                {
                    _rootLayerTouchDataCallback = OnWindowTouch;
                    this.TouchDataSignal().Connect(_rootLayerTouchDataCallback);
                }
                _rootLayerTouchDataEventHandler += value;
            }
            remove
            {
                _rootLayerTouchDataEventHandler -= value;
                if (_rootLayerTouchDataEventHandler == null && TouchSignal().Empty() == false)
                {
                    this.TouchDataSignal().Disconnect(_rootLayerTouchDataCallback);
                }
            }
        }

        /// <summary>
        /// This event is emitted when the wheel event is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<WheelEventArgs> WheelEvent
        {
            add
            {
                if (_stageWheelHandler == null)
                {
                    _wheelEventCallback = OnStageWheel;
                    this.StageWheelEventSignal().Connect(_wheelEventCallback);
                }
                _stageWheelHandler += value;
            }
            remove
            {
                _stageWheelHandler -= value;
                if (_stageWheelHandler == null && StageWheelEventSignal().Empty() == false)
                {
                    this.StageWheelEventSignal().Disconnect(_wheelEventCallback);
                }
            }
        }

        /// <summary>
        /// This event is emitted when the key event is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<KeyEventArgs> KeyEvent
        {
            add
            {
                if (_stageKeyHandler == null)
                {
                    _stageKeyCallbackDelegate = OnStageKey;
                    KeyEventSignal().Connect(_stageKeyCallbackDelegate);
                }
                _stageKeyHandler += value;
            }
            remove
            {
                _stageKeyHandler -= value;
                if (_stageKeyHandler == null && KeyEventSignal().Empty() == false)
                {
                    KeyEventSignal().Disconnect(_stageKeyCallbackDelegate);
                }
            }
        }

        /// <summary>
        /// This event is emitted when the window resized.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<ResizedEventArgs> Resized
        {
            add
            {
                if (_windowResizedEventHandler == null)
                {
                    _windowResizedEventCallback = OnResized;
                    ResizedSignal().Connect(_windowResizedEventCallback);
                }

                _windowResizedEventHandler += value;
            }
            remove
            {
                _windowResizedEventHandler -= value;

                if (_windowResizedEventHandler == null && ResizedSignal().Empty() == false && _windowResizedEventCallback != null)
                {
                    ResizedSignal().Disconnect(_windowResizedEventCallback);
                }
            }
        }

        /// <summary>
        /// Please do not use! this will be deprecated. Please use 'FocusChanged' event instead.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// Please do not use! this will be deprecated!
        /// Instead please use FocusChanged.
        [Obsolete("Please do not use! This will be deprecated! Please use FocusChanged instead! " +
            "Like: " +
            "Window.Instance.FocusChanged = OnFocusChanged; " +
            "private void OnFocusChanged(object source, Window.FocusChangedEventArgs args) {...}")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<FocusChangedEventArgs> WindowFocusChanged
        {
            add
            {
                if (_windowFocusChangedEventHandler2 == null)
                {
                    _windowFocusChangedEventCallback2 = OnWindowFocusedChanged2;
                    WindowFocusChangedSignal().Connect(_windowFocusChangedEventCallback2);
                }

                _windowFocusChangedEventHandler2 += value;
            }
            remove
            {
                _windowFocusChangedEventHandler2 -= value;

                if (_windowFocusChangedEventHandler2 == null && WindowFocusChangedSignal().Empty() == false && _windowFocusChangedEventCallback2 != null)
                {
                    WindowFocusChangedSignal().Disconnect(_windowFocusChangedEventCallback2);
                }
            }
        }

        /// <summary>
        /// EffectStart
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<TransitionEffectArgs> TransitionEffect
        {
            add
            {
                if (transitionEffectHandler == null)
                {
                    transitionEffectEventCallback = OnTransitionEffect;
                    TransitionEffectEventSignal().Connect(transitionEffectEventCallback);
                }
                transitionEffectHandler += value;
            }
            remove
            {
                transitionEffectHandler -= value;
                if (transitionEffectHandler == null && TransitionEffectEventSignal().Empty() == false)
                {
                    TransitionEffectEventSignal().Disconnect(transitionEffectEventCallback);
                }
            }
        }

        /// <summary>
        /// ViewAdded will be triggered when the view added on Window
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler ViewAdded;
        private event EventHandler<FocusChangedEventArgs> _windowFocusChangedEventHandler;
        private event EventHandler<TouchEventArgs> _rootLayerTouchDataEventHandler;
        private event EventHandler<WheelEventArgs> _stageWheelHandler;
        private event EventHandler<KeyEventArgs> _stageKeyHandler;
        private event EventHandler _stageEventProcessingFinishedEventHandler;
        private event EventHandler<ResizedEventArgs> _windowResizedEventHandler;
        private event EventHandler<FocusChangedEventArgs> _windowFocusChangedEventHandler2;
        private event EventHandler<TransitionEffectArgs> transitionEffectHandler;

        internal void SendViewAdded(View view)
        {
            ViewAdded?.Invoke(view, EventArgs.Empty);
        }

        internal event EventHandler EventProcessingFinished
        {
            add
            {
                if (_stageEventProcessingFinishedEventHandler == null)
                {
                    _stageEventProcessingFinishedEventCallbackDelegate = OnEventProcessingFinished;
                    EventProcessingFinishedSignal().Connect(_stageEventProcessingFinishedEventCallbackDelegate);
                }
                _stageEventProcessingFinishedEventHandler += value;

            }
            remove
            {
                _stageEventProcessingFinishedEventHandler -= value;
                if (_stageEventProcessingFinishedEventHandler == null && EventProcessingFinishedSignal().Empty() == false)
                {
                    EventProcessingFinishedSignal().Disconnect(_stageEventProcessingFinishedEventCallbackDelegate);
                }
            }
        }

        internal event EventHandler ContextLost
        {
            add
            {
                if (_stageContextLostEventHandler == null)
                {
                    _stageContextLostEventCallbackDelegate = OnContextLost;
                    ContextLostSignal().Connect(_stageContextLostEventCallbackDelegate);
                }
                _stageContextLostEventHandler += value;
            }
            remove
            {
                _stageContextLostEventHandler -= value;
                if (_stageContextLostEventHandler == null && ContextLostSignal().Empty() == false)
                {
                    ContextLostSignal().Disconnect(_stageContextLostEventCallbackDelegate);
                }
            }
        }

        internal event EventHandler ContextRegained
        {
            add
            {
                if (_stageContextRegainedEventHandler == null)
                {
                    _stageContextRegainedEventCallbackDelegate = OnContextRegained;
                    ContextRegainedSignal().Connect(_stageContextRegainedEventCallbackDelegate);
                }
                _stageContextRegainedEventHandler += value;
            }
            remove
            {
                _stageContextRegainedEventHandler -= value;
                if (_stageContextRegainedEventHandler == null && ContextRegainedSignal().Empty() == false)
                {
                    this.ContextRegainedSignal().Disconnect(_stageContextRegainedEventCallbackDelegate);
                }
            }
        }

        internal event EventHandler SceneCreated
        {
            add
            {
                if (_stageSceneCreatedEventHandler == null)
                {
                    _stageSceneCreatedEventCallbackDelegate = OnSceneCreated;
                    SceneCreatedSignal().Connect(_stageSceneCreatedEventCallbackDelegate);
                }
                _stageSceneCreatedEventHandler += value;
            }
            remove
            {
                _stageSceneCreatedEventHandler -= value;
                if (_stageSceneCreatedEventHandler == null && SceneCreatedSignal().Empty() == false)
                {
                    SceneCreatedSignal().Disconnect(_stageSceneCreatedEventCallbackDelegate);
                }
            }
        }

        internal WindowFocusSignalType WindowFocusChangedSignal()
        {
            WindowFocusSignalType ret = new WindowFocusSignalType(Interop.Window.FocusChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WindowFocusSignalType FocusChangedSignal()
        {
            WindowFocusSignalType ret = new WindowFocusSignalType(Interop.Window.FocusChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal KeyEventSignal KeyEventSignal()
        {
            KeyEventSignal ret = new KeyEventSignal(Interop.Window.KeyEventSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal EventProcessingFinishedSignal()
        {
            VoidSignal ret = new VoidSignal(Interop.StageSignal.Stage_EventProcessingFinishedSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TouchSignal TouchSignal()
        {
            TouchSignal ret = new TouchSignal(Interop.Window.TouchSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TouchDataSignal TouchDataSignal()
        {
            TouchDataSignal ret = new TouchDataSignal(Interop.ActorSignal.Actor_TouchSignal(Layer.getCPtr(GetRootLayer())), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal ContextLostSignal()
        {
            VoidSignal ret = new VoidSignal(Interop.StageSignal.Stage_ContextLostSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal ContextRegainedSignal()
        {
            VoidSignal ret = new VoidSignal(Interop.StageSignal.Stage_ContextRegainedSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal SceneCreatedSignal()
        {
            VoidSignal ret = new VoidSignal(Interop.StageSignal.Stage_SceneCreatedSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ResizedSignal ResizedSignal()
        {
            ResizedSignal ret = new ResizedSignal(Interop.Window.Window_ResizedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal System.IntPtr GetNativeWindowHandler()
        {
            System.IntPtr ret = Interop.Window.GetNativeWindowHandler(HandleRef.ToIntPtr(this.swigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Disconnect all native signals
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        internal void DisconnectNativeSignals()
        {
            if (_windowFocusChangedEventCallback != null)
            {
                WindowFocusChangedSignal().Disconnect(_windowFocusChangedEventCallback);
            }

            if (_rootLayerTouchDataCallback != null)
            {
                TouchDataSignal().Disconnect(_rootLayerTouchDataCallback);
            }

            if (_wheelEventCallback != null)
            {
                StageWheelEventSignal().Disconnect(_wheelEventCallback);
            }

            if (_stageKeyCallbackDelegate != null)
            {
                KeyEventSignal().Disconnect(_stageKeyCallbackDelegate);
            }

            if (_stageEventProcessingFinishedEventCallbackDelegate != null)
            {
                EventProcessingFinishedSignal().Disconnect(_stageEventProcessingFinishedEventCallbackDelegate);
            }

            if (_stageContextLostEventCallbackDelegate != null)
            {
                ContextLostSignal().Disconnect(_stageContextLostEventCallbackDelegate);
            }

            if (_stageContextRegainedEventCallbackDelegate != null)
            {
                ContextRegainedSignal().Disconnect(_stageContextRegainedEventCallbackDelegate);
            }

            if (_stageSceneCreatedEventCallbackDelegate != null)
            {
                SceneCreatedSignal().Disconnect(_stageSceneCreatedEventCallbackDelegate);
            }

            if (_windowResizedEventCallback != null)
            {
                ResizedSignal().Disconnect(_windowResizedEventCallback);
            }

            if (_windowFocusChangedEventCallback2 != null)
            {
                WindowFocusChangedSignal().Disconnect(_windowFocusChangedEventCallback2);
            }

            if (transitionEffectSignal != null)
            {
                TransitionEffectEventSignal().Disconnect(transitionEffectEventCallback);
            }
        }

        private StageWheelSignal WheelEventSignal()
        {
            StageWheelSignal ret = new StageWheelSignal(Interop.StageSignal.Stage_WheelEventSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private WheelSignal StageWheelEventSignal()
        {
            WheelSignal ret = new WheelSignal(Interop.ActorSignal.Actor_WheelEventSignal(Layer.getCPtr(this.GetRootLayer())), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private WindowTransitionEffectSignal TransitionEffectEventSignal()
        {
            //Tizen.Log.Fatal("NUITEST", "TransitionEffectEventSignal()!");
            if (transitionEffectSignal == null)
            {
                transitionEffectSignal = new WindowTransitionEffectSignal(this);
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                //Tizen.Log.Fatal("NUITEST", $"transitionEffectSignal is null, new here!");
            }
            return transitionEffectSignal;
        }

        private void OnWindowFocusedChanged(bool focusGained)
        {
            FocusChangedEventArgs e = new FocusChangedEventArgs();

            e.FocusGained = focusGained;

            if (_windowFocusChangedEventHandler != null)
            {
                _windowFocusChangedEventHandler(this, e);
            }
        }

        private bool OnWindowTouch(IntPtr view, IntPtr touchData)
        {
            if (touchData == global::System.IntPtr.Zero)
            {
                NUILog.Error("touchData should not be null!");
                return false;
            }

            TouchEventArgs e = new TouchEventArgs();

            e.Touch = Tizen.NUI.Touch.GetTouchFromPtr(touchData);

            if (_rootLayerTouchDataEventHandler != null)
            {
                _rootLayerTouchDataEventHandler(this, e);
            }
            return false;
        }

        private bool OnStageWheel(IntPtr rootLayer, IntPtr wheelEvent)
        {
            if (wheelEvent == global::System.IntPtr.Zero)
            {
                NUILog.Error("wheelEvent should not be null!");
                return true;
            }

            WheelEventArgs e = new WheelEventArgs();

            e.Wheel = Tizen.NUI.Wheel.GetWheelFromPtr(wheelEvent);

            if (_stageWheelHandler != null)
            {
                _stageWheelHandler(this, e);
            }
            return true;
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

        // Callback for Stage EventProcessingFinishedSignal
        private void OnEventProcessingFinished()
        {
            if (_stageEventProcessingFinishedEventHandler != null)
            {
                _stageEventProcessingFinishedEventHandler(this, null);
            }
        }

        // Callback for Stage ContextLostSignal
        private void OnContextLost()
        {
            if (_stageContextLostEventHandler != null)
            {
                _stageContextLostEventHandler(this, null);
            }
        }

        // Callback for Stage ContextRegainedSignal
        private void OnContextRegained()
        {
            if (_stageContextRegainedEventHandler != null)
            {
                _stageContextRegainedEventHandler(this, null);
            }
        }

        // Callback for Stage SceneCreatedSignal
        private void OnSceneCreated()
        {
            if (_stageSceneCreatedEventHandler != null)
            {
                _stageSceneCreatedEventHandler(this, null);
            }
        }

        private void OnResized(IntPtr windowSize)
        {
            ResizedEventArgs e = new ResizedEventArgs();
            var val = new Uint16Pair(windowSize, false);
            e.WindowSize = new Size2D(val.GetWidth(), val.GetHeight());
            val.Dispose();

            if (_windowResizedEventHandler != null)
            {
                _windowResizedEventHandler(this, e);
            }
        }

        private void OnWindowFocusedChanged2(bool focusGained)
        {
            FocusChangedEventArgs e = new FocusChangedEventArgs();

            e.FocusGained = focusGained;

            if (_windowFocusChangedEventHandler2 != null)
            {
                _windowFocusChangedEventHandler2(this, e);
            }
        }

        private void OnTransitionEffect(IntPtr window, int state, int type)
        {
            //Tizen.Log.Fatal("NUITEST", $"OnTransitionEffect() called");
            if (window == global::System.IntPtr.Zero)
            {
                //Tizen.Log.Error("NUI", $"OnTransitionEffect() IntPtr window is null!");
                return;
            }

            TransitionEffectArgs e = new TransitionEffectArgs();

            e.State = (EffectStates)state;
            //Tizen.Log.Error("NUITEST", $"e.State={e.State}");

            e.Type = (EffectTypes)type;
            //Tizen.Log.Error("NUITEST", $"e.Type={e.Type}");

            if (transitionEffectHandler != null)
            {
                //Tizen.Log.Fatal("NUITEST", $"Execute transitionEffectHandler(this, e)!!!");
                transitionEffectHandler(this, e);
            }
            return;
        }

        /// <summary>
        /// The focus changed event argument.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class FocusChangedEventArgs : EventArgs
        {
            /// <summary>
            /// FocusGained flag.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public bool FocusGained
            {
                get;
                set;
            }
        }

        /// <summary>
        /// The touch event argument.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class TouchEventArgs : EventArgs
        {
            private Touch _touch;

            /// <summary>
            /// Touch.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
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
        /// Wheel event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class WheelEventArgs : EventArgs
        {
            private Wheel _wheel;

            /// <summary>
            /// Wheel.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public Wheel Wheel
            {
                get
                {
                    return _wheel;
                }
                set
                {
                    _wheel = value;
                }
            }
        }

        /// <summary>
        /// Key event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class KeyEventArgs : EventArgs
        {
            private Key _key;

            /// <summary>
            /// Key.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
        public class ResizedEventArgs : EventArgs
        {
            Size2D _windowSize;

            /// <summary>
            /// This window size.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
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
        /// Please do not use! this will be deprecated
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Please do not use! This will be deprecated! Please use FocusChangedEventArgs instead! " +
            "Like: " +
            "Window.Instance.FocusChanged = OnFocusChanged; " +
            "private void OnFocusChanged(object source, Window.FocusChangedEventArgs args) {...}")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class WindowFocusChangedEventArgs : EventArgs
        {
            /// <summary>
            /// Please do not use! this will be deprecated
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public bool FocusGained
            {
                get;
                set;
            }
        }

        /// <summary>
        /// Contains and encapsulates Native Window handle.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public class SafeNativeWindowHandle : SafeHandle
        {
            /// <summary>
            /// Contructor, Native window handle is set to handle.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public SafeNativeWindowHandle() : base(IntPtr.Zero, false)
            {
                SetHandle(Tizen.NUI.Window.Instance.GetNativeWindowHandler());
            }
            /// <summary>
            /// Null check if the handle is valid or not.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public override bool IsInvalid
            {
                get
                {
                    return this.handle == IntPtr.Zero;
                }
            }
            /// <summary>
            /// Release handle itself.
            /// </summary>
            /// <returns>true when released successfully.</returns>
            /// <since_tizen> 4 </since_tizen>
            protected override bool ReleaseHandle()
            {
                return true;
            }
        }

        /// <summary>
        /// TransitionEffectArgs
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class TransitionEffectArgs : EventArgs
        {
            private EffectStates state;
            private EffectTypes type;

            /// <summary>
            /// State
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public EffectStates State
            {
                get
                {
                    return state;
                }
                set
                {
                    state = value;
                }
            }
            /// <summary>
            /// Type
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public EffectTypes Type
            {
                get
                {
                    return type;
                }
                set
                {
                    type = value;
                }
            }
        }
    }
}
