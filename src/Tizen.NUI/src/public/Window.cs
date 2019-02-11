/*
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
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;
using System.Collections.Generic;

namespace Tizen.NUI
{
    /// <summary>
    /// The window class is used internally for drawing.<br />
    /// The window has an orientation and indicator properties.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Window : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        private global::System.Runtime.InteropServices.HandleRef stageCPtr;
        private readonly global::System.Runtime.InteropServices.HandleRef rootLayoutCPtr;
        private Layer _rootLayer;
        private string _windowTitle;
        private readonly LayoutItem rootLayoutItem;

        private List<Layer> _childLayers = new List<Layer>();
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

        private static readonly Window instance = Application.Instance?.GetWindow();

        private LayoutController localController;

        internal Window(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.Window_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            if (NDalicPINVOKE.Stage_IsInstalled())
            {
                stageCPtr = new global::System.Runtime.InteropServices.HandleRef(this, NDalicPINVOKE.Stage_GetCurrent());

                localController = new LayoutController();
                NUILog.Debug("layoutController id:" + localController.GetId() );

                // Create a root layout (AbsoluteLayout) that is invisible to the user but enables layouts added to the Window
                // Enables layouts added to the Window to have a parent layout.  As parent layout is needed to store measure spec properties.
                // Currently without these measure specs the new layout added will always be the size of the window.
                global::System.IntPtr rootLayoutIntPtr = NDalicManualPINVOKE.Window_NewRootLayout();
                // Store HandleRef used by Add()
                rootLayoutCPtr = new global::System.Runtime.InteropServices.HandleRef(this, rootLayoutIntPtr);
                Layer rootLayer = GetRootLayer();
                // Add the root layout created above to the root layer.
                NDalicPINVOKE.Actor_Add(  Layer.getCPtr(rootLayer), rootLayoutCPtr );
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                global::System.IntPtr rootControlLayoutIntPtr = Tizen.NUI.NDalicManualPINVOKE.GetLayout__SWIG_1(rootLayoutCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                rootLayoutItem = new LayoutItem(rootControlLayoutIntPtr, true);
            }
        }

        internal Window(Rectangle windowPosition, string name, bool isTransparent) : this(NDalicPINVOKE.Window_New__SWIG_0(Rectangle.getCPtr(windowPosition), name, isTransparent), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Window(Rectangle windowPosition, string name) : this(NDalicPINVOKE.Window_New__SWIG_1(Rectangle.getCPtr(windowPosition), name), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Window(Rectangle windowPosition, string name, string className, bool isTransparent) : this(NDalicPINVOKE.Window_New__SWIG_2(Rectangle.getCPtr(windowPosition), name, className, isTransparent), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Window(Rectangle windowPosition, string name, string className) : this(NDalicPINVOKE.Window_New__SWIG_3(Rectangle.getCPtr(windowPosition), name, className), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

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

        private event EventHandler<FocusChangedEventArgs> _windowFocusChangedEventHandler;
        private event EventHandler<TouchEventArgs> _rootLayerTouchDataEventHandler;
        private event EventHandler<WheelEventArgs> _stageWheelHandler;
        private event EventHandler<KeyEventArgs> _stageKeyHandler;
        private event EventHandler _stageEventProcessingFinishedEventHandler;
        private event EventHandler<ResizedEventArgs> _windowResizedEventHandler;
        private event EventHandler<FocusChangedEventArgs> _windowFocusChangedEventHandler2;

        /// <summary>
        /// Enumeration for orientation of the window is the way in which a rectangular page is oriented for normal viewing.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum WindowOrientation
        {
            /// <summary>
            /// Portrait orientation. The height of the display area is greater than the width.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Portrait = 0,
            /// <summary>
            /// Landscape orientation. A wide view area is needed.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Landscape = 90,
            /// <summary>
            /// Portrait inverse orientation.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            PortraitInverse = 180,
            /// <summary>
            /// Landscape inverse orientation.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            LandscapeInverse = 270
        }

        /// <summary>
        /// Enumeration for the key grab mode for platform-level APIs.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum KeyGrabMode
        {
            /// <summary>
            /// Grabs a key only when on the top of the grabbing-window stack mode.
            /// </summary>
            Topmost = 0,
            /// <summary>
            /// Grabs a key together with the other client window(s) mode.
            /// </summary>
            Shared,
            /// <summary>
            /// Grabs a key exclusively regardless of the grabbing-window's position on the window stack with the possibility of overriding the grab by the other client window mode.
            /// </summary>
            OverrideExclusive,
            /// <summary>
            /// Grabs a key exclusively regardless of the grabbing-window's position on the window stack mode.
            /// </summary>
            Exclusive
        };

        /// <summary>
        /// Enumeration for opacity of the indicator.
        /// </summary>
        internal enum IndicatorBackgroundOpacity
        {
            Opaque = 100,
            Translucent = 50,
            Transparent = 0
        }

        /// <summary>
        /// Enumeration for visible mode of the indicator.
        /// </summary>
        internal enum IndicatorVisibleMode
        {
            Invisible = 0,
            Visible = 1,
            Auto = 2
        }

        /// <summary>
        /// The stage instance property (read-only).<br />
        /// Gets the current window.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static Window Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Gets or sets a window type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WindowType Type
        {
            get
            {
                WindowType ret = (WindowType)NDalicPINVOKE.GetType(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            set
            {
                NDalicPINVOKE.SetType(swigCPtr, (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Gets/Sets a window title.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Title
        {
            get
            {
                return _windowTitle;
            }
            set
            {
                _windowTitle = value;
                SetClass(_windowTitle, "");
            }
        }

        /// <summary>
        /// The rendering behavior of a Window.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public RenderingBehaviorType RenderingBehavior
        {
            get
            {
                return GetRenderingBehavior();
            }
            set
            {
                SetRenderingBehavior(value);
            }
        }

        /// <summary>
        /// The window size property (read-only).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Size2D Size
        {
            get
            {
                Size2D ret = GetSize();
                return ret;
            }
        }

        /// <summary>
        /// The background color property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Color BackgroundColor
        {
            set
            {
                SetBackgroundColor(value);
            }
            get
            {
                Color ret = GetBackgroundColor();
                return ret;
            }
        }

        /// <summary>
        /// The DPI property (read-only).<br />
        /// Retrieves the DPI of the display device to which the Window is connected.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 Dpi
        {
            get
            {
                return GetDpi();
            }
        }

        /// <summary>
        /// The layer count property (read-only).<br />
        /// Queries the number of on-Window layers.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint LayerCount
        {
            get
            {
                return GetLayerCount();
            }
        }

        /// <summary>
        /// Gets or sets a size of the window.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public Size2D WindowSize
        {
            get
            {
                return GetWindowSize();
            }
            set
            {
                SetWindowSize(value);
            }
        }

        /// <summary>
        /// Gets or sets a position of the window.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public Position2D WindowPosition
        {
            get
            {
                return GetPosition();
            }
            set
            {
                SetPosition(value);
            }
        }
        internal static Vector4 DEFAULT_BACKGROUND_COLOR
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Stage_DEFAULT_BACKGROUND_COLOR_get();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static Vector4 DEBUG_BACKGROUND_COLOR
        {
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.Stage_DEBUG_BACKGROUND_COLOR_get();
                Vector4 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector4(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal List<Layer> LayersChildren
        {
            get
            {
                return _childLayers;
            }
        }

        /// <summary>
        /// Feed a key-event into the window.
        /// </summary>
        /// <param name="keyEvent">The key event to feed.</param>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! This will be deprecated! Please use FeedKey(Key keyEvent) instead!")]
        public static void FeedKeyEvent(Key keyEvent)
        {
            NDalicManualPINVOKE.Window_FeedKeyEvent(Key.getCPtr(keyEvent));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets whether the window accepts a focus or not.
        /// </summary>
        /// <param name="accept">If a focus is accepted or not. The default is true.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetAcceptFocus(bool accept)
        {
            NDalicPINVOKE.SetAcceptFocus(swigCPtr, accept);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns whether the window accepts a focus or not.
        /// </summary>
        /// <returns>True if the window accepts a focus, false otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool IsFocusAcceptable()
        {
            bool ret = NDalicPINVOKE.IsFocusAcceptable(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            return ret;
        }

        /// <summary>
        /// Shows the window if it is hidden.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Show()
        {
            NDalicPINVOKE.Show(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Hides the window if it is showing.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Hide()
        {
            NDalicPINVOKE.Hide(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves whether the window is visible or not.
        /// </summary>
        /// <returns>True if the window is visible.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool IsVisible()
        {
            bool temp = NDalicPINVOKE.IsVisible(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return temp;
        }

        /// <summary>
        /// Gets the count of supported auxiliary hints of the window.
        /// </summary>
        /// <returns>The number of supported auxiliary hints.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint GetSupportedAuxiliaryHintCount()
        {
            uint ret = NDalicPINVOKE.GetSupportedAuxiliaryHintCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the supported auxiliary hint string of the window.
        /// </summary>
        /// <param name="index">The index of the supported auxiliary hint lists.</param>
        /// <returns>The auxiliary hint string of the index.</returns>
        /// <since_tizen> 3 </since_tizen>
        public string GetSupportedAuxiliaryHint(uint index)
        {
            string ret = NDalicPINVOKE.GetSupportedAuxiliaryHint(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Creates an auxiliary hint of the window.
        /// </summary>
        /// <param name="hint">The auxiliary hint string.</param>
        /// <param name="value">The value string.</param>
        /// <returns>The ID of created auxiliary hint, or 0 on failure.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint AddAuxiliaryHint(string hint, string value)
        {
            uint ret = NDalicPINVOKE.AddAuxiliaryHint(swigCPtr, hint, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Removes an auxiliary hint of the window.
        /// </summary>
        /// <param name="id">The ID of the auxiliary hint.</param>
        /// <returns>True if no error occurred, false otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool RemoveAuxiliaryHint(uint id)
        {
            bool ret = NDalicPINVOKE.RemoveAuxiliaryHint(swigCPtr, id);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Changes a value of the auxiliary hint.
        /// </summary>
        /// <param name="id">The auxiliary hint ID.</param>
        /// <param name="value">The value string to be set.</param>
        /// <returns>True if no error occurred, false otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool SetAuxiliaryHintValue(uint id, string value)
        {
            bool ret = NDalicPINVOKE.SetAuxiliaryHintValue(swigCPtr, id, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets a value of the auxiliary hint.
        /// </summary>
        /// <param name="id">The auxiliary hint ID.</param>
        /// <returns>The string value of the auxiliary hint ID, or an empty string if none exists.</returns>
        /// <since_tizen> 3 </since_tizen>
        public string GetAuxiliaryHintValue(uint id)
        {
            string ret = NDalicPINVOKE.GetAuxiliaryHintValue(swigCPtr, id);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets an ID of the auxiliary hint string.
        /// </summary>
        /// <param name="hint">The auxiliary hint string.</param>
        /// <returns>The ID of auxiliary hint string, or 0 on failure.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint GetAuxiliaryHintId(string hint)
        {
            uint ret = NDalicPINVOKE.GetAuxiliaryHintId(swigCPtr, hint);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets a region to accept input events.
        /// </summary>
        /// <param name="inputRegion">The region to accept input events.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetInputRegion(Rectangle inputRegion)
        {
            NDalicPINVOKE.SetInputRegion(swigCPtr, Rectangle.getCPtr(inputRegion));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets a priority level for the specified notification window.
        /// </summary>
        /// <param name="level">The notification window level.</param>
        /// <returns>True if no error occurred, false otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool SetNotificationLevel(NotificationLevel level)
        {
            bool ret = NDalicPINVOKE.SetNotificationLevel(swigCPtr, (int)level);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets a priority level for the specified notification window.
        /// </summary>
        /// <returns>The notification window level.</returns>
        /// <since_tizen> 3 </since_tizen>
        public NotificationLevel GetNotificationLevel()
        {
            NotificationLevel ret = (NotificationLevel)NDalicPINVOKE.GetNotificationLevel(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets a transparent window's visual state to opaque. <br />
        /// If a visual state of a transparent window is opaque, <br />
        /// then the window manager could handle it as an opaque window when calculating visibility.
        /// </summary>
        /// <param name="opaque">Whether the window's visual state is opaque.</param>
        /// <remarks>This will have no effect on an opaque window. <br />
        /// It doesn't change transparent window to opaque window but lets the window manager know the visual state of the window.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public void SetOpaqueState(bool opaque)
        {
            NDalicPINVOKE.SetOpaqueState(swigCPtr, opaque);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns whether a transparent window's visual state is opaque or not.
        /// </summary>
        /// <returns>True if the window's visual state is opaque, false otherwise.</returns>
        /// <remarks> The return value has no meaning on an opaque window. </remarks>
        /// <since_tizen> 3 </since_tizen>
        public bool IsOpaqueState()
        {
            bool ret = NDalicPINVOKE.IsOpaqueState(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets a window's screen off mode.
        /// </summary>
        /// <param name="screenOffMode">The screen mode.</param>
        /// <returns>True if no error occurred, false otherwise.</returns>
        /// <since_tizen> 4 </since_tizen>
        public bool SetScreenOffMode(ScreenOffMode screenOffMode)
        {
            bool ret = NDalicPINVOKE.SetScreenOffMode(swigCPtr, (int)screenOffMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the screen mode of the window.
        /// </summary>
        /// <returns>The screen off mode.</returns>
        /// <since_tizen> 4 </since_tizen>
        public ScreenOffMode GetScreenOffMode()
        {
            ScreenOffMode ret = (ScreenOffMode)NDalicPINVOKE.GetScreenOffMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets preferred brightness of the window.
        /// </summary>
        /// <param name="brightness">The preferred brightness (0 to 100).</param>
        /// <returns>True if no error occurred, false otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool SetBrightness(int brightness)
        {
            bool ret = NDalicPINVOKE.SetBrightness(swigCPtr, brightness);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the preferred brightness of the window.
        /// </summary>
        /// <returns>The preferred brightness.</returns>
        /// <since_tizen> 3 </since_tizen>
        public int GetBrightness()
        {
            int ret = NDalicPINVOKE.GetBrightness(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the window name and the class string.
        /// </summary>
        /// <param name="name">The name of the window.</param>
        /// <param name="klass">The class of the window.</param>
        /// <since_tizen> 4 </since_tizen>
        public void SetClass(string name, string klass)
        {
            NDalicPINVOKE.Window_SetClass(swigCPtr, name, klass);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Raises the window to the top of the window stack.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Raise()
        {
            NDalicPINVOKE.Window_Raise(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Lowers the window to the bottom of the window stack.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Lower()
        {
            NDalicPINVOKE.Window_Lower(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Activates the window to the top of the window stack even it is iconified.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Activate()
        {
            NDalicPINVOKE.Window_Activate(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the default ( root ) layer.
        /// </summary>
        /// <returns>The root layer.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Layer GetDefaultLayer()
        {
            return this.GetRootLayer();
        }

        /// <summary>
        /// Add a child view to window.
        /// </summary>
        /// <param name="view">the child should be added to the window.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Add(View view)
        {
            NDalicPINVOKE.Actor_Add(rootLayoutCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            this.GetRootLayer().AddViewToLayerList(view); // Maintain the children list in the Layer
            view.InternalParent = this.GetRootLayer();
        }

        /// <summary>
        /// Remove a child view from window.
        /// </summary>
        /// <param name="view">the child to be removed.</param>
        /// <since_tizen> 3 </since_tizen>
        public void Remove(View view)
        {
            NDalicPINVOKE.Actor_Remove(rootLayoutCPtr, View.getCPtr(view));
            this.GetRootLayer().RemoveViewFromLayerList(view); // Maintain the children list in the Layer
            view.InternalParent = null;
        }

        /// <summary>
        /// Retrieves the layer at a specified depth.
        /// </summary>
        /// <param name="depth">The layer's depth index.</param>
        /// <returns>The layer found at the given depth.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Layer GetLayer(uint depth)
        {
            if (depth < LayersChildren?.Count)
            {
                Layer ret = LayersChildren[Convert.ToInt32(depth)];
                return ret;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Keep rendering for at least the given amount of time.
        /// </summary>
        /// <param name="durationSeconds">Time to keep rendering, 0 means render at least one more frame.</param>
        /// <since_tizen> 3 </since_tizen>
        public void KeepRendering(float durationSeconds)
        {
            NDalicPINVOKE.Stage_KeepRendering(stageCPtr, durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Grabs the key specified by a key for a window only when a window is the topmost window.<br />
        /// This function can be used for following example scenarios: <br />
        /// - Mobile - Using volume up or down as zoom up or down in camera apps.<br />
        /// </summary>
        /// <param name="DaliKey">The key code to grab.</param>
        /// <returns>True if the grab succeeds.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool GrabKeyTopmost(int DaliKey)
        {
            bool ret = NDalicManualPINVOKE.GrabKeyTopmost(HandleRef.ToIntPtr(this.swigCPtr), DaliKey);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Ungrabs the key specified by a key for the window.<br />
        /// Note: If this function is called between key down and up events of a grabbed key, an application doesn't receive the key up event.<br />
        /// </summary>
        /// <param name="DaliKey">The key code to ungrab.</param>
        /// <returns>True if the ungrab succeeds.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool UngrabKeyTopmost(int DaliKey)
        {
            bool ret = NDalicManualPINVOKE.UngrabKeyTopmost(HandleRef.ToIntPtr(this.swigCPtr), DaliKey);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        ///  Grabs the key specified by a key for a window in a GrabMode. <br />
        ///  Details: This function can be used for following example scenarios: <br />
        ///  - TV - A user might want to change the volume or channel of the background TV contents while focusing on the foregrund app. <br />
        ///  - Mobile - When a user presses the Home key, the homescreen appears regardless of the current foreground app. <br />
        ///  - Mobile - Using the volume up or down as zoom up or down in camera apps. <br />
        /// </summary>
        /// <param name="DaliKey">The key code to grab.</param>
        /// <param name="GrabMode">The grab mode for the key.</param>
        /// <returns>True if the grab succeeds.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool GrabKey(int DaliKey, KeyGrabMode GrabMode)
        {
            bool ret = NDalicManualPINVOKE.GrabKey(HandleRef.ToIntPtr(this.swigCPtr), DaliKey, (int)GrabMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Ungrabs the key specified by a key for a window.<br />
        /// Note: If this function is called between key down and up events of a grabbed key, an application doesn't receive the key up event. <br />
        /// </summary>
        /// <param name="DaliKey">The key code to ungrab.</param>
        /// <returns>True if the ungrab succeeds.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool UngrabKey(int DaliKey)
        {
            bool ret = NDalicManualPINVOKE.UngrabKey(HandleRef.ToIntPtr(this.swigCPtr), DaliKey);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the keyboard repeat information.
        /// </summary>
        /// <param name="rate">The key repeat rate value in seconds.</param>
        /// <param name="delay">The key repeat delay value in seconds.</param>
        /// <returns>True if setting the keyboard repeat succeeds.</returns>
        /// <since_tizen> 5 </since_tizen>
        public bool SetKeyboardRepeatInfo(float rate, float delay)
        {
            bool ret = NDalicManualPINVOKE.SetKeyboardRepeatInfo(rate, delay);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the keyboard repeat information.
        /// </summary>
        /// <param name="rate">The key repeat rate value in seconds.</param>
        /// <param name="delay">The key repeat delay value in seconds.</param>
        /// <returns>True if setting the keyboard repeat succeeds.</returns>
        /// <since_tizen> 5 </since_tizen>
        public bool GetKeyboardRepeatInfo(out float rate, out float delay)
        {
            bool ret = NDalicManualPINVOKE.GetKeyboardRepeatInfo(out rate, out delay);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Adds a layer to the stage.
        /// </summary>
        /// <param name="layer">Layer to add.</param>
        /// <since_tizen> 3 </since_tizen>
        public void AddLayer(Layer layer)
        {
            NDalicPINVOKE.Stage_Add(stageCPtr, Layer.getCPtr(layer));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            LayersChildren?.Add(layer);
        }

        /// <summary>
        /// Removes a layer from the stage.
        /// </summary>
        /// <param name="layer">Layer to remove.</param>
        /// <since_tizen> 3 </since_tizen>
        public void RemoveLayer(Layer layer)
        {
            NDalicPINVOKE.Stage_Remove(stageCPtr, Layer.getCPtr(layer));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            LayersChildren?.Remove(layer);
        }

        /// <summary>
        /// Feeds a key event into the window.
        /// </summary>
        /// <param name="keyEvent">The key event to feed.</param>
        /// <since_tizen> 5 </since_tizen>
        public void FeedKey(Key keyEvent)
        {
            NDalicManualPINVOKE.Window_FeedKeyEvent(Key.getCPtr(keyEvent));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Allows at least one more render, even when paused.
        /// The window should be shown, not minimised.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void RenderOnce()
        {
            NDalicManualPINVOKE.Window_RenderOnce(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Window obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal static Window GetCurrent()
        {
            Window ret = new Window(NDalicPINVOKE.Stage_GetCurrent(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static bool IsInstalled()
        {
            bool ret = NDalicPINVOKE.Stage_IsInstalled();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WindowFocusSignalType WindowFocusChangedSignal()
        {
            WindowFocusSignalType ret = new WindowFocusSignalType(NDalicPINVOKE.FocusChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void ShowIndicator(Window.IndicatorVisibleMode visibleMode)
        {
            NDalicPINVOKE.Window_ShowIndicator(swigCPtr, (int)visibleMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetIndicatorBackgroundOpacity(Window.IndicatorBackgroundOpacity opacity)
        {
            NDalicPINVOKE.Window_SetIndicatorBgOpacity(swigCPtr, (int)opacity);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void RotateIndicator(Window.WindowOrientation orientation)
        {
            NDalicPINVOKE.Window_RotateIndicator(swigCPtr, (int)orientation);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void AddAvailableOrientation(Window.WindowOrientation orientation)
        {
            NDalicPINVOKE.Window_AddAvailableOrientation(swigCPtr, (int)orientation);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void RemoveAvailableOrientation(Window.WindowOrientation orientation)
        {
            NDalicPINVOKE.Window_RemoveAvailableOrientation(swigCPtr, (int)orientation);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetPreferredOrientation(Window.WindowOrientation orientation)
        {
            NDalicPINVOKE.Window_SetPreferredOrientation(swigCPtr, (int)orientation);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Window.WindowOrientation GetPreferredOrientation()
        {
            Window.WindowOrientation ret = (Window.WindowOrientation)NDalicPINVOKE.Window_GetPreferredOrientation(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal DragAndDropDetector GetDragAndDropDetector()
        {
            DragAndDropDetector ret = new DragAndDropDetector(NDalicPINVOKE.Window_GetDragAndDropDetector(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Any GetNativeHandle()
        {
            Any ret = new Any(NDalicPINVOKE.Window_GetNativeHandle(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WindowFocusSignalType FocusChangedSignal()
        {
            WindowFocusSignalType ret = new WindowFocusSignalType(NDalicPINVOKE.FocusChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void Add(Layer layer)
        {
            NDalicPINVOKE.Stage_Add(stageCPtr, Layer.getCPtr(layer));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            LayersChildren?.Add(layer);
        }

        internal void Remove(Layer layer)
        {
            NDalicPINVOKE.Stage_Remove(stageCPtr, Layer.getCPtr(layer));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            LayersChildren?.Remove(layer);
        }

        internal Vector2 GetSize()
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Stage_GetSize(stageCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal RenderTaskList GetRenderTaskList()
        {
            RenderTaskList ret = new RenderTaskList(NDalicPINVOKE.Stage_GetRenderTaskList(stageCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Queries the number of on-window layers.
        /// </summary>
        /// <returns>The number of layers.</returns>
        /// <remarks>Note that a default layer is always provided (count >= 1).</remarks>
        internal uint GetLayerCount()
        {
            if (LayersChildren == null || LayersChildren.Count < 0)
                return 0;

            return (uint) LayersChildren.Count;
        }

        internal Layer GetRootLayer()
        {
            // Window.IsInstalled() is actually true only when called from event thread and
            // Core has been initialized, not when Stage is ready.
            if (_rootLayer == null && Window.IsInstalled())
            {
                _rootLayer = new Layer(NDalicPINVOKE.Stage_GetRootLayer(stageCPtr), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                LayersChildren?.Add(_rootLayer);
            }
            return _rootLayer;
        }

        internal void SetBackgroundColor(Vector4 color)
        {
            NDalicPINVOKE.Stage_SetBackgroundColor(stageCPtr, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector4 GetBackgroundColor()
        {
            Vector4 ret = new Vector4(NDalicPINVOKE.Stage_GetBackgroundColor(stageCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector2 GetDpi()
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Stage_GetDpi(stageCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ObjectRegistry GetObjectRegistry()
        {
            ObjectRegistry ret = new ObjectRegistry(NDalicPINVOKE.Stage_GetObjectRegistry(stageCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetRenderingBehavior(RenderingBehaviorType renderingBehavior)
        {
            NDalicPINVOKE.Stage_SetRenderingBehavior(stageCPtr, (int)renderingBehavior);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal RenderingBehaviorType GetRenderingBehavior()
        {
            RenderingBehaviorType ret = (RenderingBehaviorType)NDalicPINVOKE.Stage_GetRenderingBehavior(stageCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal KeyEventSignal KeyEventSignal()
        {
            KeyEventSignal ret = new KeyEventSignal(NDalicPINVOKE.Stage_KeyEventSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal EventProcessingFinishedSignal()
        {
            VoidSignal ret = new VoidSignal(NDalicPINVOKE.Stage_EventProcessingFinishedSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TouchSignal TouchSignal()
        {
            TouchSignal ret = new TouchSignal(NDalicPINVOKE.Stage_TouchSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TouchDataSignal TouchDataSignal()
        {
            TouchDataSignal ret = new TouchDataSignal(NDalicPINVOKE.Actor_TouchSignal(Layer.getCPtr(GetRootLayer())), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal ContextLostSignal()
        {
            VoidSignal ret = new VoidSignal(NDalicPINVOKE.Stage_ContextLostSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal ContextRegainedSignal()
        {
            VoidSignal ret = new VoidSignal(NDalicPINVOKE.Stage_ContextRegainedSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal VoidSignal SceneCreatedSignal()
        {
            VoidSignal ret = new VoidSignal(NDalicPINVOKE.Stage_SceneCreatedSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ResizedSignal ResizedSignal()
        {
            ResizedSignal ret = new ResizedSignal(NDalicManualPINVOKE.Window_ResizedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetWindowSize(Size2D size)
        {
            var val = new Uint16Pair((uint)size.Width, (uint)size.Height);
            NDalicManualPINVOKE.SetSize(swigCPtr, Uint16Pair.getCPtr(val));

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            if(rootLayoutItem != null)
            {
                rootLayoutItem.RequestLayout();
            }
        }

        internal Size2D GetWindowSize()
        {
            var val = new Uint16Pair(NDalicManualPINVOKE.GetSize(swigCPtr), false);
            Size2D ret = new Size2D(val.GetWidth(), val.GetHeight());

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetPosition(Position2D position)
        {
            var val = new Uint16Pair((uint)position.X, (uint)position.Y);
            NDalicManualPINVOKE.SetPosition(swigCPtr, Uint16Pair.getCPtr(val));

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            if(rootLayoutItem != null)
            {
                rootLayoutItem.RequestLayout();
            }
        }

        internal Position2D GetPosition()
        {
            var val = new Uint16Pair(NDalicManualPINVOKE.GetPosition(swigCPtr), true);
            Position2D ret = new Position2D(val.GetX(), val.GetY());

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetPositionSize(Rectangle positionSize)
        {
            NDalicPINVOKE.Window_SetPositionSize(swigCPtr, Rectangle.getCPtr(positionSize));

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            if(rootLayoutItem != null)
            {
                rootLayoutItem.RequestLayout();
            }
        }

        /// <summary>
        /// Sets whether the window is transparent or not.
        /// </summary>
        /// <param name="transparent">Whether the window is transparent or not.</param>
        /// <since_tizen> 5 </since_tizen>
        public void SetTransparency(bool transparent) {
            NDalicManualPINVOKE.SetTransparency(swigCPtr, transparent);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            if(rootLayoutItem != null)
            {
                rootLayoutItem.RequestLayout();
            }
        }

        internal System.IntPtr GetNativeWindowHandler()
        {
            System.IntPtr ret = NDalicManualPINVOKE.GetNativeWindowHandler(HandleRef.ToIntPtr(this.swigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
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

        private StageWheelSignal WheelEventSignal()
        {
            StageWheelSignal ret = new StageWheelSignal(NDalicPINVOKE.Stage_WheelEventSignal(stageCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private WheelSignal StageWheelEventSignal()
        {
            WheelSignal ret = new WheelSignal(NDalicPINVOKE.Actor_WheelEventSignal(Layer.getCPtr(this.GetRootLayer())), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
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
        /// Sets position and size of the window. This API guarantees that
        /// both moving and resizing of window will appear on the screen at once.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle WindowPositionSize
        {
            get
            {
                Position2D position = GetPosition();
                Size2D size = GetSize();
                Rectangle ret = new Rectangle(position.X, position.Y, size.Width, size.Height);
                return ret;
            }
            set
            {
                SetPositionSize(value);
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
        /// Disconnect all native signals
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        internal void DisconnectNativeSignals()
        {
            if( _windowFocusChangedEventCallback != null )
            {
                WindowFocusChangedSignal().Disconnect(_windowFocusChangedEventCallback);
            }

            if( _rootLayerTouchDataCallback != null )
            {
                TouchDataSignal().Disconnect(_rootLayerTouchDataCallback);
            }

            if( _wheelEventCallback != null )
            {
                StageWheelEventSignal().Disconnect(_wheelEventCallback);
            }

            if( _stageKeyCallbackDelegate != null )
            {
                KeyEventSignal().Disconnect(_stageKeyCallbackDelegate);
            }

            if( _stageEventProcessingFinishedEventCallbackDelegate != null )
            {
                EventProcessingFinishedSignal().Disconnect(_stageEventProcessingFinishedEventCallbackDelegate);
            }

            if( _stageContextLostEventCallbackDelegate != null )
            {
                ContextLostSignal().Disconnect(_stageContextLostEventCallbackDelegate);
            }

            if( _stageContextRegainedEventCallbackDelegate != null )
            {
                ContextRegainedSignal().Disconnect(_stageContextRegainedEventCallbackDelegate);
            }

            if( _stageSceneCreatedEventCallbackDelegate != null )
            {
                SceneCreatedSignal().Disconnect(_stageSceneCreatedEventCallbackDelegate);
            }

            if( _windowResizedEventCallback != null )
            {
                ResizedSignal().Disconnect(_windowResizedEventCallback);
            }

            if( _windowFocusChangedEventCallback2 != null )
            {
                WindowFocusChangedSignal().Disconnect(_windowFocusChangedEventCallback2);
            }

        }

    }
}
