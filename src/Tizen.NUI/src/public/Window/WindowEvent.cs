﻿/*
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
using System.Collections.Generic;

namespace Tizen.NUI
{
    /// <summary>
    /// The window class is used internally for drawing.<br />
    /// The window has an orientation and indicator properties.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class Window
    {
        private WindowFocusChangedEventCallbackType windowFocusChangedEventCallback;
        private RootLayerTouchDataCallbackType rootLayerTouchDataCallback;
        private WheelEventCallbackType wheelEventCallback;
        private EventCallbackDelegateType1 stageKeyCallbackDelegate;
        private InterceptKeyEventDelegateType stageInterceptKeyCallbackDelegate;
        private EventCallbackDelegateType0 stageEventProcessingFinishedEventCallbackDelegate;
        private EventHandler stageContextLostEventHandler;
        private EventCallbackDelegateType0 stageContextLostEventCallbackDelegate;
        private EventHandler stageContextRegainedEventHandler;
        private EventCallbackDelegateType0 stageContextRegainedEventCallbackDelegate;
        private EventHandler stageSceneCreatedEventHandler;
        private EventCallbackDelegateType0 stageSceneCreatedEventCallbackDelegate;
        private WindowResizeEventCallbackType windowResizeEventCallback;
        private WindowFocusChangedEventCallbackType windowFocusChangedEventCallback2;
        private TransitionEffectEventCallbackType transitionEffectEventCallback;
        private WindowTransitionEffectSignal transitionEffectSignal;
        private KeyboardRepeatSettingsChangedEventCallbackType keyboardRepeatSettingsChangedEventCallback;
        private KeyboardRepeatSettingsChangedSignal keyboardRepeatSettingsChangedSignal;
        private KeyEventSignal interceptKeyEventSignal;
        private AuxiliaryMessageEventCallbackType auxiliaryMessageEventCallback;

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
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void AuxiliaryMessageEventCallbackType(IntPtr kData, IntPtr vData, IntPtr optionsArray);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool InterceptKeyEventDelegateType(IntPtr arg1);

        /// <summary>
        /// FocusChanged event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<FocusChangedEventArgs> FocusChanged
        {
            add
            {
                if (windowFocusChangedEventHandler == null)
                {
                    windowFocusChangedEventCallback = OnWindowFocusedChanged;
                    using WindowFocusSignalType windowFocusChangedSignal = WindowFocusChangedSignal();
                    windowFocusChangedSignal?.Connect(windowFocusChangedEventCallback);
                }

                windowFocusChangedEventHandler += value;
            }
            remove
            {
                windowFocusChangedEventHandler -= value;

                using WindowFocusSignalType windowFocusChangedSignal = WindowFocusChangedSignal();
                if (windowFocusChangedEventHandler == null && windowFocusChangedSignal?.Empty() == false && windowFocusChangedEventCallback != null)
                {
                    windowFocusChangedSignal?.Disconnect(windowFocusChangedEventCallback);
                    if(windowFocusChangedSignal?.Empty() == true)
                    {
                        windowFocusChangedEventCallback = null;
                    }
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
                if (rootLayerTouchDataEventHandler == null)
                {
                    rootLayerTouchDataCallback = OnWindowTouch;
                    using TouchDataSignal touchDataSignal = this.TouchDataSignal();
                    touchDataSignal?.Connect(rootLayerTouchDataCallback);
                }
                rootLayerTouchDataEventHandler += value;
            }
            remove
            {
                rootLayerTouchDataEventHandler -= value;
                using TouchDataSignal touchDataSignal = this.TouchDataSignal();
                if (rootLayerTouchDataEventHandler == null && touchDataSignal?.Empty() == false && rootLayerTouchDataCallback != null)
                {
                    touchDataSignal?.Disconnect(rootLayerTouchDataCallback);
                    if(touchDataSignal?.Empty() == true)
                    {
                        rootLayerTouchDataCallback = null;
                    }
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
                if (stageWheelHandler == null)
                {
                    wheelEventCallback = OnStageWheel;
                    using WheelSignal wheelSignal = WheelEventSignal();
                    wheelSignal?.Connect(wheelEventCallback);
                }
                stageWheelHandler += value;

                if (DetentEventHandler == null)
                {
                    DetentEventCallback = OnDetentEvent;
                    using StageWheelSignal stageWheelSignal = StageWheelEventSignal();
                    stageWheelSignal?.Connect(DetentEventCallback);
                }
                DetentEventHandler += value;
            }
            remove
            {
                stageWheelHandler -= value;
                using WheelSignal wheelSignal = WheelEventSignal();
                if (stageWheelHandler == null && wheelSignal?.Empty() == false)
                {
                    wheelSignal?.Disconnect(wheelEventCallback);
                    if(wheelSignal?.Empty() == true)
                    {
                        wheelEventCallback = null;
                    }
                }

                DetentEventHandler -= value;
                using StageWheelSignal stageWheelSignal = StageWheelEventSignal();
                if (DetentEventHandler == null && stageWheelSignal?.Empty() == false)
                {
                    stageWheelSignal?.Disconnect(DetentEventCallback);
                    if(stageWheelSignal?.Empty() == true)
                    {
                        DetentEventCallback = null;
                    }
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
                if (stageKeyHandler == null)
                {
                    stageKeyCallbackDelegate = OnStageKey;
                    using KeyEventSignal keyEventSignal = KeyEventSignal();
                    keyEventSignal?.Connect(stageKeyCallbackDelegate);
                }
                stageKeyHandler += value;
            }
            remove
            {
                stageKeyHandler -= value;
                using KeyEventSignal keyEventSignal = KeyEventSignal();
                if (stageKeyHandler == null && keyEventSignal?.Empty() == false)
                {
                    keyEventSignal?.Disconnect(stageKeyCallbackDelegate);
                    if(keyEventSignal?.Empty() == true)
                    {
                        stageKeyCallbackDelegate = null;
                    }
                }
            }
        }

        /// <summary>
        /// Intercepts KeyEvents in the window before dispatching KeyEvents to the child.<br />
        /// If it returns true(consumed), no KeyEvent is delivered to the child.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event ReturnTypeEventHandler<object, KeyEventArgs, bool> InterceptKeyEvent
        {
            add
            {
                if (stageInterceptKeyHandler == null)
                {
                    stageInterceptKeyCallbackDelegate = OnStageInterceptKey;
                    interceptKeyEventSignal = InterceptKeyEventSignal();
                    interceptKeyEventSignal?.Connect(stageInterceptKeyCallbackDelegate);
                }
                stageInterceptKeyHandler += value;
            }
            remove
            {
                stageInterceptKeyHandler -= value;
                if (stageInterceptKeyHandler == null && interceptKeyEventSignal?.Empty() == false)
                {
                    interceptKeyEventSignal?.Disconnect(stageInterceptKeyCallbackDelegate);
                    if (interceptKeyEventSignal?.Empty() == true)
                    {
                        stageInterceptKeyCallbackDelegate = null;
                    }
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
                if (windowResizeEventHandler == null)
                {
                    windowResizeEventCallback = OnResized;
                    using ResizeSignal resizeSignal = ResizeSignal();
                    resizeSignal?.Connect(windowResizeEventCallback);
                }

                windowResizeEventHandler += value;
            }
            remove
            {
                windowResizeEventHandler -= value;

                using ResizeSignal resizeSignal = ResizeSignal();
                if (windowResizeEventHandler == null && resizeSignal?.Empty() == false && windowResizeEventCallback != null)
                {
                    resizeSignal?.Disconnect(windowResizeEventCallback);
                    if(resizeSignal?.Empty() == true)
                    {
                        windowResizeEventCallback = null;
                    }
                }
            }
        }

        /// <summary>
        /// Do not use this, that will be deprecated. Use 'FocusChanged' event instead.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// Do not use this, that will be deprecated.
        /// Instead Use FocusChanged.
        [Obsolete("Do not use this, that will be deprecated. Use FocusChanged instead. " +
            "Like: " +
            "NUIApplication.GetDefaultWindow().FocusChanged = OnFocusChanged; " +
            "private void OnFocusChanged(object source, Window.FocusChangedEventArgs args) {...}")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<FocusChangedEventArgs> WindowFocusChanged
        {
            add
            {
                if (windowFocusChangedEventHandler2 == null)
                {
                    windowFocusChangedEventCallback2 = OnWindowFocusedChanged2;
                    using WindowFocusSignalType windowFocusChangedSignal2 = WindowFocusChangedSignal();
                    windowFocusChangedSignal2?.Connect(windowFocusChangedEventCallback2);
                }

                windowFocusChangedEventHandler2 += value;
            }
            remove
            {
                windowFocusChangedEventHandler2 -= value;

                using WindowFocusSignalType windowFocusChangedSignal2 = WindowFocusChangedSignal();
                if (windowFocusChangedEventHandler2 == null && windowFocusChangedSignal2?.Empty() == false && windowFocusChangedEventCallback2 != null)
                {
                    windowFocusChangedSignal2?.Disconnect(windowFocusChangedEventCallback2);
                    if(windowFocusChangedSignal2?.Empty() == true)
                    {
                        windowFocusChangedEventCallback2 = null;
                    }
                }
            }
        }

        /// <summary>
        /// EffectStart
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<TransitionEffectEventArgs> TransitionEffect
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
                    if(TransitionEffectEventSignal().Empty() == true)
                    {
                        transitionEffectEventCallback = null;
                    }
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
                    KeyboardRepeatSettingsChangedEventSignal().Connect(keyboardRepeatSettingsChangedEventCallback);
                }
                keyboardRepeatSettingsChangedHandler += value;
            }
            remove
            {
                keyboardRepeatSettingsChangedHandler -= value;
                if (keyboardRepeatSettingsChangedHandler == null && KeyboardRepeatSettingsChangedEventSignal().Empty() == false)
                {
                    KeyboardRepeatSettingsChangedEventSignal().Disconnect(keyboardRepeatSettingsChangedEventCallback);
                    if(KeyboardRepeatSettingsChangedEventSignal().Empty() == true)
                    {
                        keyboardRepeatSettingsChangedEventCallback = null;
                    }
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
        private event EventHandler<FocusChangedEventArgs> windowFocusChangedEventHandler;
        private event EventHandler<TouchEventArgs> rootLayerTouchDataEventHandler;
        private event EventHandler<WheelEventArgs> stageWheelHandler;
        private event EventHandler<KeyEventArgs> stageKeyHandler;
        private ReturnTypeEventHandler<object, KeyEventArgs, bool> stageInterceptKeyHandler;
        private event EventHandler stageEventProcessingFinishedEventHandler;
        private event EventHandler<ResizedEventArgs> windowResizeEventHandler;
        private event EventHandler<FocusChangedEventArgs> windowFocusChangedEventHandler2;
        private event EventHandler<TransitionEffectEventArgs> transitionEffectHandler;
        private event EventHandler keyboardRepeatSettingsChangedHandler;
        private event EventHandler<AuxiliaryMessageEventArgs> auxiliaryMessageEventHandler;

        internal void SendViewAdded(View view)
        {
            ViewAdded?.Invoke(view, EventArgs.Empty);
        }

        internal event EventHandler EventProcessingFinished
        {
            add
            {
                if (stageEventProcessingFinishedEventHandler == null)
                {
                    stageEventProcessingFinishedEventCallbackDelegate = OnEventProcessingFinished;
                    using VoidSignal eventProcessingFinishedSignal = EventProcessingFinishedSignal();
                    eventProcessingFinishedSignal?.Connect(stageEventProcessingFinishedEventCallbackDelegate);
                }
                stageEventProcessingFinishedEventHandler += value;

            }
            remove
            {
                stageEventProcessingFinishedEventHandler -= value;

                using VoidSignal eventProcessingFinishedSignal = EventProcessingFinishedSignal();
                if (stageEventProcessingFinishedEventHandler == null && eventProcessingFinishedSignal?.Empty() == false)
                {
                    eventProcessingFinishedSignal?.Disconnect(stageEventProcessingFinishedEventCallbackDelegate);
                    if(eventProcessingFinishedSignal?.Empty() == true)
                    {
                        stageEventProcessingFinishedEventCallbackDelegate = null;
                    }
                }
            }
        }

        internal event EventHandler ContextLost
        {
            add
            {
                if (stageContextLostEventHandler == null)
                {
                    stageContextLostEventCallbackDelegate = OnContextLost;
                    using VoidSignal contextLostSignal = ContextLostSignal();
                    contextLostSignal?.Connect(stageContextLostEventCallbackDelegate);
                }
                stageContextLostEventHandler += value;
            }
            remove
            {
                stageContextLostEventHandler -= value;

                using VoidSignal contextLostSignal = ContextLostSignal();
                if (stageContextLostEventHandler == null && contextLostSignal?.Empty() == false)
                {
                    contextLostSignal?.Disconnect(stageContextLostEventCallbackDelegate);
                    if(contextLostSignal?.Empty() == true)
                    {
                        stageContextLostEventCallbackDelegate = null;
                    }
                }
            }
        }

        internal event EventHandler ContextRegained
        {
            add
            {
                if (stageContextRegainedEventHandler == null)
                {
                    stageContextRegainedEventCallbackDelegate = OnContextRegained;
                    using VoidSignal contextRegainedSignal = ContextRegainedSignal();
                    contextRegainedSignal?.Connect(stageContextRegainedEventCallbackDelegate);
                }
                stageContextRegainedEventHandler += value;
            }
            remove
            {
                stageContextRegainedEventHandler -= value;

                using VoidSignal contextRegainedSignal = ContextRegainedSignal();
                if (stageContextRegainedEventHandler == null && contextRegainedSignal?.Empty() == false)
                {
                    contextRegainedSignal?.Disconnect(stageContextRegainedEventCallbackDelegate);
                    if(contextRegainedSignal?.Empty() == true)
                    {
                        stageContextRegainedEventCallbackDelegate = null;
                    }
                }
            }
        }

        internal event EventHandler SceneCreated
        {
            add
            {
                if (stageSceneCreatedEventHandler == null)
                {
                    stageSceneCreatedEventCallbackDelegate = OnSceneCreated;
                    using VoidSignal sceneCreatedSignal = SceneCreatedSignal();
                    sceneCreatedSignal?.Connect(stageSceneCreatedEventCallbackDelegate);
                }
                stageSceneCreatedEventHandler += value;
            }
            remove
            {
                stageSceneCreatedEventHandler -= value;

                using VoidSignal sceneCreatedSignal = SceneCreatedSignal();
                if (stageSceneCreatedEventHandler == null && sceneCreatedSignal?.Empty() == false)
                {
                    sceneCreatedSignal?.Disconnect(stageSceneCreatedEventCallbackDelegate);
                    if(sceneCreatedSignal?.Empty() == true)
                    {
                        stageSceneCreatedEventCallbackDelegate = null;
                    }
                }
            }
        }

        internal WindowFocusSignalType WindowFocusChangedSignal()
        {
            WindowFocusSignalType ret = new WindowFocusSignalType(Interop.Window.FocusChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WindowFocusSignalType FocusChangedSignal()
        {
            WindowFocusSignalType ret = new WindowFocusSignalType(Interop.Window.FocusChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal KeyEventSignal KeyEventSignal()
        {
            KeyEventSignal ret = new KeyEventSignal(Interop.Window.KeyEventSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal KeyEventSignal InterceptKeyEventSignal()
        {
            KeyEventSignal ret = new KeyEventSignal(Interop.Window.InterceptKeyEventSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal EventProcessingFinishedSignal()
        {
            VoidSignal ret = new VoidSignal(Interop.StageSignal.EventProcessingFinishedSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TouchSignal TouchSignal()
        {
            TouchSignal ret = new TouchSignal(Interop.Window.TouchSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TouchDataSignal TouchDataSignal()
        {
            TouchDataSignal ret = new TouchDataSignal(Interop.ActorSignal.ActorTouchSignal(Layer.getCPtr(GetRootLayer())), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal ContextLostSignal()
        {
            VoidSignal ret = new VoidSignal(Interop.StageSignal.ContextLostSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal ContextRegainedSignal()
        {
            VoidSignal ret = new VoidSignal(Interop.StageSignal.ContextRegainedSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal SceneCreatedSignal()
        {
            VoidSignal ret = new VoidSignal(Interop.StageSignal.SceneCreatedSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ResizeSignal ResizeSignal()
        {
            ResizeSignal ret = new ResizeSignal(Interop.Window.ResizeSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal System.IntPtr GetNativeWindowHandler()
        {
            System.IntPtr ret = Interop.Window.GetNativeWindowHandler(HandleRef.ToIntPtr(this.SwigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Disconnect all native signals
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        internal void DisconnectNativeSignals()
        {
            if (windowFocusChangedEventCallback != null)
            {
                using WindowFocusSignalType windowFocusChangedSignal = WindowFocusChangedSignal();
                if( windowFocusChangedSignal?.Empty() == false )
                {
                    windowFocusChangedSignal?.Disconnect(windowFocusChangedEventCallback);
                    windowFocusChangedEventCallback = null;
                }
            }

            if (rootLayerTouchDataCallback != null)
            {
                using TouchDataSignal touchDataSignal = TouchDataSignal();
                if( touchDataSignal?.Empty() == false )
                {
                    touchDataSignal?.Disconnect(rootLayerTouchDataCallback);
                    rootLayerTouchDataCallback = null;
                }
            }

            if (wheelEventCallback != null)
            {
                using WheelSignal wheelSignal = WheelEventSignal();
                if( wheelSignal?.Empty() == false )
                {
                    wheelSignal?.Disconnect(wheelEventCallback);
                    wheelEventCallback = null;
                }
            }

            if (DetentEventCallback != null)
            {
                using StageWheelSignal stageWheelSignal = StageWheelEventSignal();
                if( stageWheelSignal?.Empty() == false )
                {
                    stageWheelSignal?.Disconnect(DetentEventCallback);
                    DetentEventCallback = null;
                }
            }

            if (stageKeyCallbackDelegate != null)
            {
                using KeyEventSignal keyEventSignal = KeyEventSignal();
                if( keyEventSignal?.Empty() == false )
                {
                    keyEventSignal?.Disconnect(stageKeyCallbackDelegate);
                    stageKeyCallbackDelegate = null;
                }
            }

            if (stageInterceptKeyCallbackDelegate != null)
            {
                interceptKeyEventSignal?.Disconnect(stageInterceptKeyCallbackDelegate);
                stageInterceptKeyCallbackDelegate = null;
            }

            if (stageEventProcessingFinishedEventCallbackDelegate != null)
            {
                using VoidSignal eventProcessingFinishedSignal = EventProcessingFinishedSignal();
                if( eventProcessingFinishedSignal?.Empty() == false )
                {
                    eventProcessingFinishedSignal?.Disconnect(stageEventProcessingFinishedEventCallbackDelegate);
                    stageEventProcessingFinishedEventCallbackDelegate = null;
                }
            }

            if (stageContextLostEventCallbackDelegate != null)
            {
                using VoidSignal contextLostSignal = ContextLostSignal();
                if( contextLostSignal?.Empty() == false )
                {
                    contextLostSignal?.Disconnect(stageContextLostEventCallbackDelegate);
                    stageContextLostEventCallbackDelegate= null;
                }
            }

            if (stageContextRegainedEventCallbackDelegate != null)
            {
                using VoidSignal contextRegainedSignal = ContextRegainedSignal();
                if( contextRegainedSignal?.Empty() == false )
                {
                    contextRegainedSignal?.Disconnect(stageContextRegainedEventCallbackDelegate);
                    stageContextRegainedEventCallbackDelegate = null;
                }
            }

            if (stageSceneCreatedEventCallbackDelegate != null)
            {
                using VoidSignal sceneCreatedSignal = SceneCreatedSignal();
                if( sceneCreatedSignal?.Empty() == false )
                {
                    sceneCreatedSignal?.Disconnect(stageSceneCreatedEventCallbackDelegate);
                    stageSceneCreatedEventCallbackDelegate = null;
                }
            }

            if (windowResizeEventCallback != null)
            {
                using ResizeSignal resizeSignal = ResizeSignal();
                if( resizeSignal?.Empty() == false )
                {
                    resizeSignal?.Disconnect(windowResizeEventCallback);
                    windowResizeEventCallback = null;
                }
            }

            if (windowFocusChangedEventCallback2 != null)
            {
                using WindowFocusSignalType windowFocusChangedSignal2 = WindowFocusChangedSignal();
                if( windowFocusChangedSignal2?.Empty() == false )
                {
                    windowFocusChangedSignal2?.Disconnect(windowFocusChangedEventCallback2);
                    windowFocusChangedEventCallback2 = null;
                }
            }

            if (transitionEffectSignal != null)
            {
                TransitionEffectEventSignal().Disconnect(transitionEffectEventCallback);
                transitionEffectEventCallback = null;
            }

            if (keyboardRepeatSettingsChangedSignal != null)
            {
                KeyboardRepeatSettingsChangedEventSignal().Disconnect(keyboardRepeatSettingsChangedEventCallback);
                keyboardRepeatSettingsChangedEventCallback = null;
            }

            if (auxiliaryMessageEventCallback != null)
            {
                using var signal = new WindowAuxiliaryMessageSignal(this);
                signal.Disconnect(auxiliaryMessageEventCallback);
                auxiliaryMessageEventHandler = null;
                auxiliaryMessageEventCallback = null;
            }
        }

        private StageWheelSignal StageWheelEventSignal()
        {
            StageWheelSignal ret = new StageWheelSignal(Interop.StageSignal.WheelEventSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private WheelSignal WheelEventSignal()
        {
            WheelSignal ret = new WheelSignal(Interop.ActorSignal.ActorWheelEventSignal(Layer.getCPtr(this.GetRootLayer())), false);
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

            if (windowFocusChangedEventHandler != null)
            {
                FocusChangedEventArgs e = new FocusChangedEventArgs();
                e.FocusGained = focusGained;
                windowFocusChangedEventHandler(this, e);
            }
        }

        private bool OnWindowTouch(IntPtr view, IntPtr touchData)
        {
            if (touchData == global::System.IntPtr.Zero)
            {
                NUILog.Error("touchData should not be null!");
                return false;
            }

            if (rootLayerTouchDataEventHandler != null)
            {
                TouchEventArgs e = new TouchEventArgs();
                e.Touch = Tizen.NUI.Touch.GetTouchFromPtr(touchData);
                rootLayerTouchDataEventHandler(this, e);
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

            if (stageWheelHandler != null)
            {
                WheelEventArgs e = new WheelEventArgs();
                e.Wheel = Tizen.NUI.Wheel.GetWheelFromPtr(wheelEvent);
                stageWheelHandler(this, e);
            }
            return true;
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

        // Callback for Stage InterceptKeyEventsignal
        private bool OnStageInterceptKey(IntPtr data)
        {
            bool consumed = false;
            if (stageInterceptKeyHandler != null)
            {
                KeyEventArgs e = new KeyEventArgs();
                e.Key = Tizen.NUI.Key.GetKeyFromPtr(data);
                //here we send all data to user event handlers
                consumed = stageInterceptKeyHandler(this, e);
            }
            return consumed;
        }

        // Callback for Stage EventProcessingFinishedSignal
        private void OnEventProcessingFinished()
        {
            stageEventProcessingFinishedEventHandler?.Invoke(this, null);
        }

        // Callback for Stage ContextLostSignal
        private void OnContextLost()
        {
            stageContextLostEventHandler?.Invoke(this, null);
        }

        // Callback for Stage ContextRegainedSignal
        private void OnContextRegained()
        {
            stageContextRegainedEventHandler?.Invoke(this, null);
        }

        // Callback for Stage SceneCreatedSignal
        private void OnSceneCreated()
        {
            stageSceneCreatedEventHandler?.Invoke(this, null);
        }

        private void OnResized(IntPtr window, IntPtr windowSize)
        {
            if (window == IntPtr.Zero)
            {
                NUILog.Error("OnResized() Window is null! Do nothing!");
                return;
            }

            if (windowResizeEventHandler != null)
            {
                ResizedEventArgs e = new ResizedEventArgs();
                // var val = new Uint16Pair(windowSize, false);
                // e.WindowSize = new Size2D(val.GetWidth(), val.GetHeight());
                // val.Dispose();

                // Workaround : windowSize should be valid pointer from dali,
                // but currently it is fixed and is not Uint16Pair class.
                // will be fixed later.
                e.WindowSize = this.WindowSize;
                windowResizeEventHandler(this, e);
            }
        }

        private void OnWindowFocusedChanged2(IntPtr window, bool focusGained)
        {
            if (window == IntPtr.Zero)
            {
                NUILog.Error("OnWindowFocusedChanged() Window is null! Do nothing!");
                return;
            }

            if (windowFocusChangedEventHandler2 != null)
            {
                FocusChangedEventArgs e = new FocusChangedEventArgs();
                e.FocusGained = focusGained;
                windowFocusChangedEventHandler2(this, e);
            }
        }

        private void OnTransitionEffect(IntPtr window, int state, int type)
        {
            if (window == global::System.IntPtr.Zero)
            {
                return;
            }

            if (transitionEffectHandler != null)
            {
                TransitionEffectEventArgs e = new TransitionEffectEventArgs();
                e.State = (EffectState)state;
                e.Type = (EffectType)type;
                transitionEffectHandler(this, e);
            }
            return;
        }

        private void OnKeyboardRepeatSettingsChanged()
        {
            keyboardRepeatSettingsChangedHandler?.Invoke(this, null);
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
            private Touch touch;

            /// <summary>
            /// Touch.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
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
        /// Wheel event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class WheelEventArgs : EventArgs
        {
            private Wheel wheel;

            /// <summary>
            /// Wheel.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public Wheel Wheel
            {
                get
                {
                    return wheel;
                }
                set
                {
                    wheel = value;
                }
            }
        }

        /// <summary>
        /// Key event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class KeyEventArgs : EventArgs
        {
            private Key key;

            /// <summary>
            /// Key.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
        public class ResizedEventArgs : EventArgs
        {
            Size2D windowSize;

            /// <summary>
            /// This window size.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
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
        /// Do not use this, that will be deprecated.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Do not use this, that will be deprecated. Use FocusChangedEventArgs instead. " +
            "Like: " +
            "NUIApplication.GetDefaultWindow().FocusChanged = OnFocusChanged; " +
            "private void OnFocusChanged(object source, Window.FocusChangedEventArgs args) {...}")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public class WindowFocusChangedEventArgs : EventArgs
        {
            /// <summary>
            /// Do not use this, that will be deprecated.
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
        [Obsolete("This has been deprecated in API9 and will be removed in API11. Use Window.NativeHandle instead.")]
        public class SafeNativeWindowHandle : SafeHandle
        {
            /// <summary>
            ///Constructor, Native window handle is set to handle.
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
        public class TransitionEffectEventArgs : EventArgs
        {
            private EffectState state;
            private EffectType type;

            /// <summary>
            /// State
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public EffectState State
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
            public EffectType Type
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
            if (VisibilityChangedEventHandler != null)
            {
                VisibilityChangedEventHandler.Invoke(this, e);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void VisibilityChangedEventCallbackType(IntPtr window, bool visibility);
        private VisibilityChangedEventCallbackType VisibilityChangedEventCallback;
        private event EventHandler<VisibilityChangedEventArgs> VisibilityChangedEventHandler;
        private WindowVisibilityChangedEvent VisibilityChangedEventSignal;

        /// <summary>
        /// EffectStart
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<VisibilityChangedEventArgs> VisibilityChanged
        {
            add
            {
                if (VisibilityChangedEventHandler == null)
                {
                    VisibilityChangedEventCallback = OnVisibilityChanged;
                    VisibilityChangedEventSignal = new WindowVisibilityChangedEvent(this);
                    VisibilityChangedEventSignal.Connect(VisibilityChangedEventCallback);
                }
                VisibilityChangedEventHandler += value;
            }
            remove
            {
                VisibilityChangedEventHandler -= value;
                if (VisibilityChangedEventHandler == null)
                {
                    if (VisibilityChangedEventSignal != null)
                    {
                        if (VisibilityChangedEventSignal.Empty() == false)
                        {
                            VisibilityChangedEventSignal.Disconnect(VisibilityChangedEventCallback);
                            if (VisibilityChangedEventSignal.Empty())
                            {
                                VisibilityChangedEventCallback = null;
                            }
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
            if (VisibilityChangedEventSignal == null)
            {
                VisibilityChangedEventSignal = new WindowVisibilityChangedEvent(this);
            }
            VisibilityChangedEventSignal.Emit(this, visibility);
        }

        private void OnAuxiliaryMessage(IntPtr kData, IntPtr vData, IntPtr optionsArray)
        {
            if(kData == IntPtr.Zero || vData == IntPtr.Zero)
            {
                return;
            }

            using var tmp = new PropertyArray(optionsArray, false);
            var size = tmp.Size();

            List<string> tmpList = new List<string>();

            for (int i = 0; i < size; i++)
            {
                string option = "none";
                tmp.GetElementAt((uint)i).Get(out option);
                tmpList.Add(option);
            }

            tmp.Dispose();

            AuxiliaryMessageEventArgs e = new AuxiliaryMessageEventArgs();
            e.Key = StringToVoidSignal.GetResult(kData);
            e.Value = StringToVoidSignal.GetResult(vData);;
            e.Options = tmpList;

            auxiliaryMessageEventHandler?.Invoke(this, e);
        }

        /// <summary>
        /// Auxiliary message is sent by displayer server when window's auxiliary was changed then display server sent the message.
        /// When client application added the window's auxiliary hint and if the auxiliary is changed,
        /// display server send the auxiliary message.
        /// Auxiliary message has the key, value and options.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<AuxiliaryMessageEventArgs> AuxiliaryMessage
        {
            add
            {
                if (auxiliaryMessageEventHandler == null)
                {
                    auxiliaryMessageEventCallback = OnAuxiliaryMessage;
                    using var signal = new WindowAuxiliaryMessageSignal(this);
                    signal.Connect(auxiliaryMessageEventCallback);
                }
                auxiliaryMessageEventHandler += value;
            }
            remove
            {
                auxiliaryMessageEventHandler -= value;
                if (auxiliaryMessageEventHandler == null)
                {
                    if (auxiliaryMessageEventCallback != null)
                    {
                        using var signal = new WindowAuxiliaryMessageSignal(this);
                        signal.Disconnect(auxiliaryMessageEventCallback);

                        if (signal.Empty())
                        {
                            auxiliaryMessageEventCallback = null;
                        }
                    }
                }
            }
        }


    }
}
