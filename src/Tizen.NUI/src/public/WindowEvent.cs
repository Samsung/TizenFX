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
        private WindowResizeEventCallbackType _windowResizeEventCallback;
        private WindowFocusChangedEventCallbackType _windowFocusChangedEventCallback2;
        private TransitionEffectEventCallbackType transitionEffectEventCallback;
        private WindowTransitionEffectSignal transitionEffectSignal;
        private KeyboardRepeatSettingsChangedEventCallbackType keyboardRepeatSettingsChangedEventCallback;
        private KeyboardRepeatSettingsChangedSignal keyboardRepeatSettingsChangedSignal;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WindowFocusChangedEventCallbackType(IntPtr window, bool focusGained);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool RootLayerTouchDataCallbackType(IntPtr view, IntPtr touchData);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool WheelEventCallbackType(IntPtr view, IntPtr wheelEvent);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WindowResizeEventCallbackType(IntPtr window, IntPtr windowSize);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WindowFocusChangedEventCallbackType2(IntPtr window, bool focusGained);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void TransitionEffectEventCallbackType(IntPtr window, int state, int type);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void KeyboardRepeatSettingsChangedEventCallbackType();

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
                    var signal = WindowFocusChangedSignal();
                    signal?.Connect(_windowFocusChangedEventCallback);
                    signal?.Dispose();
                }
                _windowFocusChangedEventHandler += value;
            }
            remove
            {
                _windowFocusChangedEventHandler -= value;
                if (_windowFocusChangedEventHandler == null)
                {
                    var signal = WindowFocusChangedSignal();
                    if (signal?.Empty() == false)
                    {
                        signal?.Disconnect(_windowFocusChangedEventCallback);
                        _windowFocusChangedEventCallback = null;
                    }
                    signal?.Dispose();
                }
            }
        }

        /// <summary>
        /// Emits the event when the screen is touched and when the touch ends.<br />
        /// If there are multiple touch points then it is emitted when the first touch occurs and
        /// when the last finger is lifted too.<br />
        /// Even though incoming events are interrupted, the event occurs.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<TouchEventArgs> TouchEvent
        {
            add
            {
                if (_rootLayerTouchDataEventHandler == null)
                {
                    _rootLayerTouchDataCallback = OnWindowTouch;
                    var signal = TouchDataSignal();
                    signal?.Connect(_rootLayerTouchDataCallback);
                    signal?.Dispose();
                }
                _rootLayerTouchDataEventHandler += value;
            }
            remove
            {
                _rootLayerTouchDataEventHandler -= value;
                if (_rootLayerTouchDataEventHandler == null)
                {
                    var signal = TouchDataSignal();
                    if (signal?.Empty() == false)
                    {
                        signal?.Disconnect(_rootLayerTouchDataCallback);
                        _rootLayerTouchDataCallback = null;
                    }
                    signal?.Dispose();
                }
            }
        }

        /// <summary>
        /// Emits the event when the wheel event is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<WheelEventArgs> WheelEvent
        {
            add
            {
                if (_stageWheelHandler == null)
                {
                    _wheelEventCallback = OnStageWheel;
                    var signal = WheelEventSignal();
                    signal?.Connect(_wheelEventCallback);
                    signal?.Dispose();
                }
                _stageWheelHandler += value;
            }
            remove
            {
                _stageWheelHandler -= value;
                if (_stageWheelHandler == null)
                {
                    var signal = WheelEventSignal();
                    if (signal?.Empty() == false)
                    {
                        signal?.Disconnect(_wheelEventCallback);
                        _wheelEventCallback = null;
                    }
                    signal?.Dispose();
                }
            }
        }

        /// <summary>
        /// Emits the event when the key event is received.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<KeyEventArgs> KeyEvent
        {
            add
            {
                if (_stageKeyHandler == null)
                {
                    _stageKeyCallbackDelegate = OnStageKey;
                    var signal = KeyEventSignal();
                    signal?.Connect(_stageKeyCallbackDelegate);
                    signal?.Dispose();
                }
                _stageKeyHandler += value;
            }
            remove
            {
                _stageKeyHandler -= value;
                if (_stageKeyHandler == null)
                {
                    var signal = KeyEventSignal();
                    if (signal?.Empty() == false)
                    {
                        signal?.Disconnect(_stageKeyCallbackDelegate);
                        _stageKeyCallbackDelegate = null;
                    }
                    signal?.Dispose();
                }
            }
        }

        /// <summary>
        /// Emits the event when the window resized.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<ResizedEventArgs> Resized
        {
            add
            {
                if (_windowResizeEventHandler == null)
                {
                    _windowResizeEventCallback = OnResized;
                    var signal = ResizeSignal();
                    signal?.Connect(_windowResizeEventCallback);
                    signal?.Dispose();
                }
                _windowResizeEventHandler += value;
            }
            remove
            {
                _windowResizeEventHandler -= value;
                if (_windowResizeEventHandler == null)
                {
                    var signal = ResizeSignal();
                    if (signal?.Empty() == false)
                    {
                        signal?.Disconnect(_windowResizeEventCallback);
                        _windowResizeEventCallback = null;
                    }
                    signal?.Dispose();
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
            "NUIApplication.GetDefaultWindow().FocusChanged = OnFocusChanged; " +
            "private void OnFocusChanged(object source, Window.FocusChangedEventArgs args) {...}")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<FocusChangedEventArgs> WindowFocusChanged
        {
            add
            {
                if (_windowFocusChangedEventHandler2 == null)
                {
                    _windowFocusChangedEventCallback2 = OnWindowFocusedChanged2;
                    var signal = WindowFocusChangedSignal();
                    signal?.Connect(_windowFocusChangedEventCallback2);
                    signal?.Dispose();
                }
                _windowFocusChangedEventHandler2 += value;
            }
            remove
            {
                _windowFocusChangedEventHandler2 -= value;
                if (_windowFocusChangedEventHandler2 == null)
                {
                    var signal = WindowFocusChangedSignal();
                    if (signal?.Empty() == false)
                    {
                        signal?.Disconnect(_windowFocusChangedEventCallback2);
                        _windowFocusChangedEventCallback2 = null;
                    }
                    signal?.Dispose();
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
                    var signal = new WindowTransitionEffectSignal(this);
                    signal?.Connect(transitionEffectEventCallback);
                    signal?.Dispose();
                }
                transitionEffectHandler += value;
            }
            remove
            {
                transitionEffectHandler -= value;
                if (transitionEffectHandler == null)
                {
                    var signal = new WindowTransitionEffectSignal(this);
                    if (signal?.Empty() == false)
                    {
                        signal?.Disconnect(transitionEffectEventCallback);
                        transitionEffectEventCallback = null;
                    }
                    signal?.Dispose();
                }
            }
        }

        /// <summary>
        /// Keyboard Repeat Settings Changed
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler KeyboardRepeatSettingsChanged
        {
            add
            {
                if (keyboardRepeatSettingsChangedHandler == null)
                {
                    keyboardRepeatSettingsChangedEventCallback = OnKeyboardRepeatSettingsChanged;
                    var signal = new KeyboardRepeatSettingsChangedSignal(this);
                    signal?.Connect(keyboardRepeatSettingsChangedEventCallback);
                    signal?.Dispose();
                }
                keyboardRepeatSettingsChangedHandler += value;
            }
            remove
            {
                keyboardRepeatSettingsChangedHandler -= value;
                if (keyboardRepeatSettingsChangedHandler == null)
                {
                    var signal = new KeyboardRepeatSettingsChangedSignal(this);
                    if (signal?.Empty() == false)
                    {
                        signal?.Disconnect(keyboardRepeatSettingsChangedEventCallback);
                        keyboardRepeatSettingsChangedEventCallback = null;
                    }
                    signal?.Dispose();
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
        private event EventHandler<ResizedEventArgs> _windowResizeEventHandler;
        private event EventHandler<FocusChangedEventArgs> _windowFocusChangedEventHandler2;
        private event EventHandler<TransitionEffectArgs> transitionEffectHandler;
        private event EventHandler keyboardRepeatSettingsChangedHandler;

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
                    var signal = EventProcessingFinishedSignal();
                    signal?.Connect(_stageEventProcessingFinishedEventCallbackDelegate);
                    signal?.Dispose();
                }
                _stageEventProcessingFinishedEventHandler += value;
            }
            remove
            {
                _stageEventProcessingFinishedEventHandler -= value;
                if (_stageEventProcessingFinishedEventHandler == null)
                {
                    var signal = EventProcessingFinishedSignal();
                    if (signal?.Empty() == false)
                    {
                        signal?.Disconnect(_stageEventProcessingFinishedEventCallbackDelegate);
                        _stageEventProcessingFinishedEventCallbackDelegate = null;
                    }
                    signal?.Dispose();
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
                    var signal = ContextLostSignal();
                    signal?.Connect(_stageContextLostEventCallbackDelegate);
                    signal?.Dispose();
                }
                _stageContextLostEventHandler += value;
            }
            remove
            {
                _stageContextLostEventHandler -= value;
                if (_stageContextLostEventHandler == null)
                {
                    var signal = ContextLostSignal();
                    if (signal?.Empty() == false)
                    {
                        signal?.Disconnect(_stageContextLostEventCallbackDelegate);
                        _stageContextLostEventCallbackDelegate = null;
                    }
                    signal?.Dispose();
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
                    var signal = ContextRegainedSignal();
                    signal?.Connect(_stageContextRegainedEventCallbackDelegate);
                    signal?.Dispose();
                }
                _stageContextRegainedEventHandler += value;
            }
            remove
            {
                _stageContextRegainedEventHandler -= value;
                if (_stageContextRegainedEventHandler == null)
                {
                    var signal = ContextRegainedSignal();
                    if (signal?.Empty() == false)
                    {
                        signal?.Disconnect(_stageContextRegainedEventCallbackDelegate);
                        _stageContextRegainedEventCallbackDelegate = null;
                    }
                    signal?.Dispose();
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
                    var signal = SceneCreatedSignal();
                    signal?.Connect(_stageSceneCreatedEventCallbackDelegate);
                    signal?.Dispose();
                }
                _stageSceneCreatedEventHandler += value;
            }
            remove
            {
                _stageSceneCreatedEventHandler -= value;
                if (_stageSceneCreatedEventHandler == null)
                {
                    var signal = SceneCreatedSignal();
                    if (signal?.Empty() == false)
                    {
                        signal?.Disconnect(_stageSceneCreatedEventCallbackDelegate);
                        _stageSceneCreatedEventCallbackDelegate = null;
                    }
                    signal?.Dispose();
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

        internal ResizeSignal ResizeSignal()
        {
            ResizeSignal ret = new ResizeSignal(Interop.Window.Window_ResizeSignal(swigCPtr), false);
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
            if (HasBody() == false)
            {
                NUILog.Debug($"Window.DisconnectNativeSignals() No native body! No need to Disconnect Signals!");
                return;
            }

            if (_windowFocusChangedEventCallback != null)
            {
                WindowFocusSignalType signal = new WindowFocusSignalType(Interop.Window.FocusChangedSignal(GetBaseHandleCPtrHandleRef), false);
                signal?.Disconnect(_windowFocusChangedEventCallback);
                signal?.Dispose();
                _windowFocusChangedEventCallback = null;
            }

            if (_rootLayerTouchDataCallback != null)
            {
                TouchDataSignal signal = new TouchDataSignal(Interop.ActorSignal.Actor_TouchSignal(Layer.getCPtr(GetRootLayer())), false);
                signal?.Disconnect(_rootLayerTouchDataCallback);
                signal?.Dispose();
                _rootLayerTouchDataCallback = null;
            }

            if (_wheelEventCallback != null)
            {
                WheelSignal signal = new WheelSignal(Interop.ActorSignal.Actor_WheelEventSignal(Layer.getCPtr(this.GetRootLayer())), false);
                signal?.Disconnect(_wheelEventCallback);
                signal?.Dispose();
                _wheelEventCallback = null;
            }

            if (DetentEventCallback != null)
            {
                StageWheelEventSignal().Disconnect(DetentEventCallback);
            }

            if (_stageKeyCallbackDelegate != null)
            {
                KeyEventSignal signal = new KeyEventSignal(Interop.Window.KeyEventSignal(GetBaseHandleCPtrHandleRef), false);
                signal?.Disconnect(_stageKeyCallbackDelegate);
                signal?.Dispose();
                _stageKeyCallbackDelegate = null;
            }

            if (_stageEventProcessingFinishedEventCallbackDelegate != null)
            {
                VoidSignal signal = new VoidSignal(Interop.StageSignal.Stage_EventProcessingFinishedSignal(stageCPtr), false);
                signal?.Disconnect(_stageEventProcessingFinishedEventCallbackDelegate);
                signal?.Dispose();
                _stageEventProcessingFinishedEventCallbackDelegate = null;
            }

            if (_stageContextLostEventCallbackDelegate != null)
            {
                VoidSignal signal = new VoidSignal(Interop.StageSignal.Stage_ContextLostSignal(stageCPtr), false);
                signal?.Disconnect(_stageContextLostEventCallbackDelegate);
                signal?.Dispose();
                _stageContextLostEventCallbackDelegate = null;
            }

            if (_stageContextRegainedEventCallbackDelegate != null)
            {
                VoidSignal signal = new VoidSignal(Interop.StageSignal.Stage_ContextRegainedSignal(stageCPtr), false);
                signal?.Disconnect(_stageContextRegainedEventCallbackDelegate);
                signal?.Dispose();
                _stageContextRegainedEventCallbackDelegate = null;
            }

            if (_stageSceneCreatedEventCallbackDelegate != null)
            {
                VoidSignal signal = new VoidSignal(Interop.StageSignal.Stage_SceneCreatedSignal(stageCPtr), false);
                signal?.Disconnect(_stageSceneCreatedEventCallbackDelegate);
                signal?.Dispose();
                _stageSceneCreatedEventCallbackDelegate = null;
            }

            if (_windowResizeEventCallback != null)
            {
                ResizeSignal signal = new ResizeSignal(Interop.Window.Window_ResizeSignal(GetBaseHandleCPtrHandleRef), false);
                signal?.Disconnect(_windowResizeEventCallback);
                signal?.Dispose();
                _windowResizeEventCallback = null;
            }

            if (_windowFocusChangedEventCallback2 != null)
            {
                WindowFocusSignalType signal = new WindowFocusSignalType(Interop.Window.FocusChangedSignal(GetBaseHandleCPtrHandleRef), false);
                signal?.Disconnect(_windowFocusChangedEventCallback2);
                signal?.Dispose();
                _windowFocusChangedEventCallback2 = null;
            }

            if (transitionEffectEventCallback != null)
            {
                var signal = new WindowTransitionEffectSignal(this);
                signal?.Disconnect(transitionEffectEventCallback);
                signal?.Dispose();
                transitionEffectEventCallback = null;
            }

            if (keyboardRepeatSettingsChangedEventCallback != null)
            {
                var signal = new KeyboardRepeatSettingsChangedSignal(this);
                signal?.Disconnect(keyboardRepeatSettingsChangedEventCallback);
                signal?.Dispose();
                keyboardRepeatSettingsChangedEventCallback = null;
            }

            if (VisibilityChangedEventCallback != null)
            {
                var signal = new WindowVisibilityChangedEvent(Interop.WindowVisibilityChangedSignal.GetSignal(GetBaseHandleCPtrHandleRef), false);
                signal?.Disconnect(VisibilityChangedEventCallback);
                signal?.Dispose();
                VisibilityChangedEventCallback = null;
            }
        }

        private StageWheelSignal StageWheelEventSignal()
        {
            StageWheelSignal ret = new StageWheelSignal(Interop.StageSignal.Stage_WheelEventSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private WheelSignal WheelEventSignal()
        {
            WheelSignal ret = new WheelSignal(Interop.ActorSignal.Actor_WheelEventSignal(Layer.getCPtr(this.GetRootLayer())), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private WindowTransitionEffectSignal TransitionEffectEventSignal()
        {
            if (transitionEffectSignal == null)
            {
                transitionEffectSignal = new WindowTransitionEffectSignal(this);
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return transitionEffectSignal;
        }

        private KeyboardRepeatSettingsChangedSignal KeyboardRepeatSettingsChangedEventSignal()
        {
            if (keyboardRepeatSettingsChangedSignal == null)
            {
                keyboardRepeatSettingsChangedSignal = new KeyboardRepeatSettingsChangedSignal(this);
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return keyboardRepeatSettingsChangedSignal;
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

        private void OnResized(IntPtr window, IntPtr windowSize)
        {
            if (window == IntPtr.Zero)
            {
                NUILog.Error("OnResized() Window is null! Do nothing!");
                return;
            }

            ResizedEventArgs e = new ResizedEventArgs();
            // var val = new Uint16Pair(windowSize, false);
            // e.WindowSize = new Size2D(val.GetWidth(), val.GetHeight());
            // val.Dispose();

            // Workaround : windowSize should be valid pointer from dali, 
            // but currenlty it is fixed and is not Uint16Pair class.
            // will be fixed later.
            e.WindowSize = this.WindowSize;

            if (_windowResizeEventHandler != null)
            {
                _windowResizeEventHandler(this, e);
            }
        }

        private void OnWindowFocusedChanged2(IntPtr window, bool focusGained)
        {
            if (window == IntPtr.Zero)
            {
                NUILog.Error("OnWindowFocusedChanged() Window is null! Do nothing!");
                return;
            }

            FocusChangedEventArgs e = new FocusChangedEventArgs();

            e.FocusGained = focusGained;

            if (_windowFocusChangedEventHandler2 != null)
            {
                _windowFocusChangedEventHandler2(this, e);
            }
        }

        private void OnTransitionEffect(IntPtr window, int state, int type)
        {
            if (window == global::System.IntPtr.Zero)
            {
                return;
            }

            TransitionEffectArgs e = new TransitionEffectArgs();

            e.State = (EffectStates)state;

            e.Type = (EffectTypes)type;

            if (transitionEffectHandler != null)
            {
                transitionEffectHandler(this, e);
            }
            return;
        }

        private void OnKeyboardRepeatSettingsChanged()
        {
            if (keyboardRepeatSettingsChangedHandler != null)
            {
                keyboardRepeatSettingsChangedHandler(this, null);
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
            "NUIApplication.GetDefaultWindow().FocusChanged = OnFocusChanged; " +
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
                SetHandle(NUIApplication.GetDefaultWindow().GetNativeWindowHandler());
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

        private EventHandler<WheelEventArgs> DetentEventHandler;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void DetentEventCallbackType(IntPtr arg1);

        private DetentEventCallbackType DetentEventCallback;

        private void OnDetentEvent(IntPtr wheelEvent)
        {
            WheelEventArgs e = new WheelEventArgs();

            if (wheelEvent != global::System.IntPtr.Zero)
            {
                e.Wheel = Wheel.GetWheelFromPtr(wheelEvent);
            }

            DetentEventHandler?.Invoke(this, e);
        }

        /// <summary>
        /// VisibilityChangedArgs
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class VisibilityChangedArgs : EventArgs
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

            VisibilityChangedArgs e = new VisibilityChangedArgs();
            e.Visibility = visibility;
            if (VisibilityChangedEventHandler != null)
            {
                VisibilityChangedEventHandler.Invoke(this, e);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void VisibilityChangedEventCallbackType(IntPtr window, bool visibility);
        private VisibilityChangedEventCallbackType VisibilityChangedEventCallback;
        private event EventHandler<VisibilityChangedArgs> VisibilityChangedEventHandler;
        private WindowVisibilityChangedEvent VisibilityChangedEventSignal;

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
                    VisibilityChangedEventCallback = OnVisibilityChanged;
                    var signal = new WindowVisibilityChangedEvent(Interop.WindowVisibilityChangedSignal.GetSignal(swigCPtr), false);
                    signal?.Connect(VisibilityChangedEventCallback);
                    signal?.Dispose();
                }
                VisibilityChangedEventHandler += value;
            }
            remove
            {
                VisibilityChangedEventHandler -= value;
                if (VisibilityChangedEventHandler == null)
                {
                    var signal = new WindowVisibilityChangedEvent(Interop.WindowVisibilityChangedSignal.GetSignal(swigCPtr), false);
                    if (signal?.Empty() == false)
                    {
                        signal?.Disconnect(VisibilityChangedEventCallback);
                        VisibilityChangedEventCallback = null;
                    }
                    signal?.Dispose();
                }
            }
        }

        /// <summary>
        /// VisibiltyChangedSignalEmit
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void VisibiltyChangedSignalEmit(bool visibility)
        {
            if (VisibilityChangedEventSignal == null)
            {
                VisibilityChangedEventSignal = new WindowVisibilityChangedEvent(this);
            }
            VisibilityChangedEventSignal.Emit(this, visibility);
        }



    }
}
