/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.BaseComponents
{

    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// View is the base class for all views.
    /// </summary>
    public class View : Animatable //CustomActor => Animatable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal View(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.View_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            PositionUsesPivotPoint = false;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(View obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        // you can override it to clean-up your own resources.
        protected override void Dispose(DisposeTypes type)
        {
            if(disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_View(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        private EventHandler _keyInputFocusGainedEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void KeyInputFocusGainedCallbackType(IntPtr control);
        private KeyInputFocusGainedCallbackType _keyInputFocusGainedCallback;

        /// <summary>
        /// Event for KeyInputFocusGained signal which can be used to subscribe/unsubscribe the event handler provided by the user.<br>
        /// KeyInputFocusGained signal is emitted when the control gets Key Input Focus.<br>
        /// </summary>
        public event EventHandler FocusGained
        {
            add
            {
                if (_keyInputFocusGainedEventHandler == null)
                {
                    _keyInputFocusGainedCallback = OnKeyInputFocusGained;
                    this.KeyInputFocusGainedSignal().Connect(_keyInputFocusGainedCallback);
                }

                _keyInputFocusGainedEventHandler += value;
            }

            remove
            {
                _keyInputFocusGainedEventHandler -= value;

                if (_keyInputFocusGainedEventHandler == null && KeyInputFocusGainedSignal().Empty() == false)
                {
                    this.KeyInputFocusGainedSignal().Disconnect(_keyInputFocusGainedCallback);
                }
            }
        }

        private void OnKeyInputFocusGained(IntPtr view)
        {
            if (_keyInputFocusGainedEventHandler != null)
            {
                _keyInputFocusGainedEventHandler(this, null);
            }
        }


        private EventHandler _keyInputFocusLostEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void KeyInputFocusLostCallbackType(IntPtr control);
        private KeyInputFocusLostCallbackType _keyInputFocusLostCallback;

        /// <summary>
        /// Event for KeyInputFocusLost signal which can be used to subscribe/unsubscribe the event handler provided by the user.<br>
        /// KeyInputFocusLost signal is emitted when the control loses Key Input Focus.<br>
        /// </summary>
        public event EventHandler FocusLost
        {
            add
            {
                if (_keyInputFocusLostEventHandler == null)
                {
                    _keyInputFocusLostCallback = OnKeyInputFocusLost;
                    this.KeyInputFocusLostSignal().Connect(_keyInputFocusLostCallback);
                }

                _keyInputFocusLostEventHandler += value;
            }

            remove
            {
                _keyInputFocusLostEventHandler -= value;

                if (_keyInputFocusLostEventHandler == null && KeyInputFocusLostSignal().Empty() == false)
                {
                    this.KeyInputFocusLostSignal().Disconnect(_keyInputFocusLostCallback);
                }
            }
        }

        private void OnKeyInputFocusLost(IntPtr view)
        {
            if (_keyInputFocusLostEventHandler != null)
            {
                _keyInputFocusLostEventHandler(this, null);
            }
        }

        /// <summary>
        /// Event arguments that passed via KeyEvent signal.
        /// </summary>
        public class KeyEventArgs : EventArgs
        {
            private Key _key;

            /// <summary>
            /// Key - is the key sent to the View.
            /// </summary>
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

        private EventHandlerWithReturnType<object, KeyEventArgs, bool> _keyEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool KeyCallbackType(IntPtr control, IntPtr keyEvent);
        private KeyCallbackType _keyCallback;

        /// <summary>
        /// Event for KeyPressed signal which can be used to subscribe/unsubscribe the event handler provided by the user.<br>
        /// KeyPressed signal is emitted when key event is received.<br>
        /// </summary>
        public event EventHandlerWithReturnType<object, KeyEventArgs, bool> Key
        {
            add
            {
                if (_keyEventHandler == null)
                {
                    _keyCallback = OnKeyEvent;
                    this.KeyEventSignal().Connect(_keyCallback);
                }

                _keyEventHandler += value;
            }

            remove
            {
                _keyEventHandler -= value;

                if (_keyEventHandler == null && KeyEventSignal().Empty() == false)
                {
                    this.KeyEventSignal().Disconnect(_keyCallback);
                }
            }
        }

        private bool OnKeyEvent(IntPtr view, IntPtr keyEvent)
        {
            KeyEventArgs e = new KeyEventArgs();

            e.Key = Tizen.NUI.Key.GetKeyFromPtr(keyEvent);

            if (_keyEventHandler != null)
            {
                return _keyEventHandler(this, e);
            }
            return false;
        }


        private EventHandler _onRelayoutEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void OnRelayoutEventCallbackType(IntPtr control);
        private OnRelayoutEventCallbackType _onRelayoutEventCallback;

        /// <summary>
        /// Event for OnRelayout signal which can be used to subscribe/unsubscribe the event handler.<br>
        /// OnRelayout signal is emitted after the size has been set on the view during relayout.<br>
        /// </summary>
        public event EventHandler Relayout
        {
            add
            {
                if (_onRelayoutEventHandler == null)
                {
                    _onRelayoutEventCallback = OnRelayout;
                    this.OnRelayoutSignal().Connect(_onRelayoutEventCallback);
                }

                _onRelayoutEventHandler += value;
            }

            remove
            {
                _onRelayoutEventHandler -= value;

                if (_onRelayoutEventHandler == null && OnRelayoutSignal().Empty() == false)
                {
                    this.OnRelayoutSignal().Disconnect(_onRelayoutEventCallback);
                }

            }
        }

        // Callback for View OnRelayout signal
        private void OnRelayout(IntPtr data)
        {
            if (_onRelayoutEventHandler != null)
            {
                _onRelayoutEventHandler(this, null);
            }
        }

        /// <summary>
        /// Event arguments that passed via Touch signal.
        /// </summary>
        public class TouchedEventArgs : EventArgs
        {
            private Touch _touch;

            /// <summary>
            /// Touch - contains the information of touch points
            /// </summary>
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

        private EventHandlerWithReturnType<object, TouchedEventArgs, bool> _touchDataEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool TouchDataCallbackType(IntPtr view, IntPtr touchData);
        private TouchDataCallbackType _touchDataCallback;

        /// <summary>
        /// Event for Touched signal which can be used to subscribe/unsubscribe the event handler provided by the user.<br>
        /// Touched signal is emitted when touch input is received.<br>
        /// </summary>
        public event EventHandlerWithReturnType<object, TouchedEventArgs, bool> Touched
        {
            add
            {
                if (_touchDataEventHandler == null)
                {
                    _touchDataCallback = OnTouch;
                    this.TouchSignal().Connect(_touchDataCallback);
                }

                _touchDataEventHandler += value;
            }

            remove
            {
                _touchDataEventHandler -= value;

                if (_touchDataEventHandler == null && TouchSignal().Empty() == false)
                {
                    this.TouchSignal().Disconnect(_touchDataCallback);
                }

            }
        }

        // Callback for View TouchSignal
        private bool OnTouch(IntPtr view, IntPtr touchData)
        {
            TouchedEventArgs e = new TouchedEventArgs();

            e.Touch = Tizen.NUI.Touch.GetTouchFromPtr(touchData);

            if (_touchDataEventHandler != null)
            {
                return _touchDataEventHandler(this, e);
            }
            return false;
        }


        /// <summary>
        /// Event arguments that passed via Hover signal.
        /// </summary>
        public class HoveredEventArgs : EventArgs
        {
            private Hover _hover;

            /// <summary>
            /// Hover - contains touch points that represent the points that are currently being hovered or the points where a hover has stopped.
            /// </summary>
            public Hover Hover
            {
                get
                {
                    return _hover;
                }
                set
                {
                    _hover = value;
                }
            }
        }

        private EventHandlerWithReturnType<object, HoveredEventArgs, bool> _hoverEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool HoverEventCallbackType(IntPtr view, IntPtr hoverEvent);
        private HoverEventCallbackType _hoverEventCallback;

        /// <summary>
        /// Event for Hovered signal which can be used to subscribe/unsubscribe the event handler provided by the user.<br>
        /// Hovered signal is emitted when hover input is received.<br>
        /// </summary>
        public event EventHandlerWithReturnType<object, HoveredEventArgs, bool> Hovered
        {
            add
            {
                if (_hoverEventHandler == null)
                {
                    _hoverEventCallback = OnHoverEvent;
                    this.HoveredSignal().Connect(_hoverEventCallback);
                }

                _hoverEventHandler += value;
            }

            remove
            {
                _hoverEventHandler -= value;

                if (_hoverEventHandler == null && HoveredSignal().Empty() == false)
                {
                    this.HoveredSignal().Disconnect(_hoverEventCallback);
                }

            }
        }

        // Callback for View Hover signal
        private bool OnHoverEvent(IntPtr view, IntPtr hoverEvent)
        {
            HoveredEventArgs e = new HoveredEventArgs();

            e.Hover = Tizen.NUI.Hover.GetHoverFromPtr(hoverEvent);

            if (_hoverEventHandler != null)
            {
                return _hoverEventHandler(this, e);
            }
            return false;
        }


        /// <summary>
        /// Event arguments that passed via Wheel signal.
        /// </summary>
        public class WheelRolledEventArgs : EventArgs
        {
            private Wheel _wheel;

            /// <summary>
            /// WheelEvent - store a wheel rolling type : MOUSE_WHEEL or CUSTOM_WHEEL
            /// </summary>
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

        private EventHandlerWithReturnType<object, WheelRolledEventArgs, bool> _wheelEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool WheelEventCallbackType(IntPtr view, IntPtr wheelEvent);
        private WheelEventCallbackType _wheelEventCallback;

        /// <summary>
        /// Event for WheelMoved signal which can be used to subscribe/unsubscribe the event handler provided by the user.<br>
        /// WheelMoved signal is emitted when wheel event is received.<br>
        /// </summary>
        public event EventHandlerWithReturnType<object, WheelRolledEventArgs, bool> WheelRolled
        {
            add
            {
                if (_wheelEventHandler == null)
                {
                    _wheelEventCallback = OnWheelEvent;
                    this.WheelEventSignal().Connect(_wheelEventCallback);
                }

                _wheelEventHandler += value;
            }

            remove
            {
                _wheelEventHandler -= value;

                if (_wheelEventHandler == null && WheelEventSignal().Empty() == false)
                {
                    this.WheelEventSignal().Disconnect(_wheelEventCallback);
                }

            }
        }

        // Callback for View Wheel signal
        private bool OnWheelEvent(IntPtr view, IntPtr wheelEvent)
        {
            WheelRolledEventArgs e = new WheelRolledEventArgs();

            e.Wheel = Tizen.NUI.Wheel.GetWheelFromPtr(wheelEvent);

            if (_wheelEventHandler != null)
            {
                return _wheelEventHandler(this, e);
            }
            return false;
        }


        private EventHandler _onWindowEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void OnWindowEventCallbackType(IntPtr control);
        private OnWindowEventCallbackType _onWindowEventCallback;

        /// <summary>
        /// Event for OnWindow signal which can be used to subscribe/unsubscribe the event handler.<br>
        /// OnWindow signal is emitted after the view has been connected to the Window.<br>
        /// </summary>
        public event EventHandler AddedToWindow
        {
            add
            {
                if (_onWindowEventHandler == null)
                {
                    _onWindowEventCallback = OnWindow;
                    this.OnWindowSignal().Connect(_onWindowEventCallback);
                }

                _onWindowEventHandler += value;
            }

            remove
            {
                _onWindowEventHandler -= value;

                if (_onWindowEventHandler == null && OnWindowSignal().Empty() == false)
                {
                    this.OnWindowSignal().Disconnect(_onWindowEventCallback);
                }
            }
        }

        // Callback for View OnWindow signal
        private void OnWindow(IntPtr data)
        {
            if (_onWindowEventHandler != null)
            {
                _onWindowEventHandler(this, null);
            }
        }


        private EventHandler _offWindowEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void OffWindowEventCallbackType(IntPtr control);
        private OffWindowEventCallbackType _offWindowEventCallback;

        /// <summary>
        /// Event for OffWindow signal which can be used to subscribe/unsubscribe the event handler.<br>
        /// OffWindow signal is emitted after the view has been disconnected from the Window.<br>
        /// </summary>
        public event EventHandler RemovedFromWindow
        {
            add
            {
                if (_offWindowEventHandler == null)
                {
                    _offWindowEventCallback = OffWindow;
                    this.OffWindowSignal().Connect(_offWindowEventCallback);
                }

                _offWindowEventHandler += value;
            }

            remove
            {
                _offWindowEventHandler -= value;

                if (_offWindowEventHandler == null && OffWindowSignal().Empty() == false)
                {
                    this.OffWindowSignal().Disconnect(_offWindowEventCallback);
                }
            }
        }

        // Callback for View OffWindow signal
        private void OffWindow(IntPtr data)
        {
            if (_offWindowEventHandler != null)
            {
                _offWindowEventHandler(this, null);
            }
        }

        /// <summary>
        /// Event arguments of visibility changed.
        /// </summary>
        public class VisibilityChangedEventArgs : EventArgs
        {
            private View _view;
            private bool _visibility;
            private VisibilityChangeType _type;

            /// <summary>
            /// The view, or child of view, whose visibility has changed.
            /// </summary>
            public View View
            {
                get
                {
                    return _view;
                }
                set
                {
                    _view = value;
                }
            }

            /// <summary>
            /// Whether the view is now visible or not.
            /// </summary>
            public bool Visibility
            {
                get
                {
                    return _visibility;
                }
                set
                {
                    _visibility = value;
                }
            }

            /// <summary>
            /// Whether the view's visible property has changed or a parent's.
            /// </summary>
            public VisibilityChangeType Type
            {
                get
                {
                    return _type;
                }
                set
                {
                    _type = value;
                }
            }
        }

        private EventHandler<VisibilityChangedEventArgs> _visibilityChangedEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void VisibilityChangedEventCallbackType(IntPtr data, bool visibility, VisibilityChangeType type);
        private VisibilityChangedEventCallbackType _visibilityChangedEventCallback;

        /// <summary>
        /// Event for visibility change which can be used to subscribe/unsubscribe the event handler.<br>
        /// This signal is emitted when the visible property of this or a parent view is changed.<br>
        /// </summary>
        public event EventHandler<VisibilityChangedEventArgs> VisibilityChanged
        {
            add
            {
                if (_visibilityChangedEventHandler == null)
                {
                    _visibilityChangedEventCallback = OnVisibilityChanged;
                    VisibilityChangedSignal(this).Connect(_visibilityChangedEventCallback);
                }

                _visibilityChangedEventHandler += value;
            }

            remove
            {
                _visibilityChangedEventHandler -= value;

                if (_visibilityChangedEventHandler == null && VisibilityChangedSignal(this).Empty() == false)
                {
                    VisibilityChangedSignal(this).Disconnect(_visibilityChangedEventCallback);
                }
            }
        }

        // Callback for View visibility change signal
        private void OnVisibilityChanged(IntPtr data, bool visibility, VisibilityChangeType type)
        {
            VisibilityChangedEventArgs e = new VisibilityChangedEventArgs();
            if (data != null)
            {
                e.View = Registry.GetManagedBaseHandleFromNativePtr(data) as View;
            }
            e.Visibility = visibility;
            e.Type = type;

            if (_visibilityChangedEventHandler != null)
            {
                _visibilityChangedEventHandler(this, e);
            }
        }

        // Resource Ready Signal

        private EventHandler _resourcesLoadedEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ResourcesLoadedCallbackType(IntPtr control);
        private ResourcesLoadedCallbackType _ResourcesLoadedCallback;

        /// <summary>
        /// Event for ResourcesLoadedSignal signal which can be used to subscribe/unsubscribe the event handler provided by the user.<br>
        /// This signal is emitted after all resources required by a View are loaded and ready.<br>
        /// </summary>
        public event EventHandler ResourcesLoaded
        {
            add
            {
                if (_resourcesLoadedEventHandler == null)
                {
                    _ResourcesLoadedCallback = OnResourcesLoaded;
                    this.ResourcesLoadedSignal().Connect(_ResourcesLoadedCallback);
                }

                _resourcesLoadedEventHandler += value;
            }

            remove
            {
                _resourcesLoadedEventHandler -= value;

                if (_resourcesLoadedEventHandler == null && ResourcesLoadedSignal().Empty() == false)
                {
                    this.ResourcesLoadedSignal().Disconnect(_ResourcesLoadedCallback);
                }
            }
        }

        private void OnResourcesLoaded(IntPtr view)
        {
            if (_resourcesLoadedEventHandler != null)
            {
                _resourcesLoadedEventHandler(this, null);
            }
        }

        internal IntPtr GetPtrfromView()
        {
            return (IntPtr)swigCPtr;
        }

        internal class Property
        {
            internal static readonly int TOOLTIP = NDalicManualPINVOKE.View_Property_TOOLTIP_get();
            internal static readonly int STATE = NDalicManualPINVOKE.View_Property_STATE_get();
            internal static readonly int SUB_STATE = NDalicManualPINVOKE.View_Property_SUB_STATE_get();
            internal static readonly int LEFT_FOCUSABLE_VIEW_ID = NDalicManualPINVOKE.View_Property_LEFT_FOCUSABLE_ACTOR_ID_get();
            internal static readonly int RIGHT_FOCUSABLE_VIEW_ID = NDalicManualPINVOKE.View_Property_RIGHT_FOCUSABLE_ACTOR_ID_get();
            internal static readonly int UP_FOCUSABLE_VIEW_ID = NDalicManualPINVOKE.View_Property_UP_FOCUSABLE_ACTOR_ID_get();
            internal static readonly int DOWN_FOCUSABLE_VIEW_ID = NDalicManualPINVOKE.View_Property_DOWN_FOCUSABLE_ACTOR_ID_get();
            internal static readonly int STYLE_NAME = NDalicPINVOKE.View_Property_STYLE_NAME_get();
            internal static readonly int BACKGROUND = NDalicPINVOKE.View_Property_BACKGROUND_get();
            internal static readonly int SIBLING_ORDER = NDalicManualPINVOKE.Actor_Property_SIBLING_ORDER_get();
            internal static readonly int OPACITY = NDalicManualPINVOKE.Actor_Property_OPACITY_get();
            internal static readonly int SCREEN_POSITION = NDalicManualPINVOKE.Actor_Property_SCREEN_POSITION_get();
            internal static readonly int POSITION_USES_ANCHOR_POINT = NDalicManualPINVOKE.Actor_Property_POSITION_USES_ANCHOR_POINT_get();
            internal static readonly int PARENT_ORIGIN = NDalicPINVOKE.Actor_Property_PARENT_ORIGIN_get();
            internal static readonly int PARENT_ORIGIN_X = NDalicPINVOKE.Actor_Property_PARENT_ORIGIN_X_get();
            internal static readonly int PARENT_ORIGIN_Y = NDalicPINVOKE.Actor_Property_PARENT_ORIGIN_Y_get();
            internal static readonly int PARENT_ORIGIN_Z = NDalicPINVOKE.Actor_Property_PARENT_ORIGIN_Z_get();
            internal static readonly int ANCHOR_POINT = NDalicPINVOKE.Actor_Property_ANCHOR_POINT_get();
            internal static readonly int ANCHOR_POINT_X = NDalicPINVOKE.Actor_Property_ANCHOR_POINT_X_get();
            internal static readonly int ANCHOR_POINT_Y = NDalicPINVOKE.Actor_Property_ANCHOR_POINT_Y_get();
            internal static readonly int ANCHOR_POINT_Z = NDalicPINVOKE.Actor_Property_ANCHOR_POINT_Z_get();
            internal static readonly int SIZE = NDalicPINVOKE.Actor_Property_SIZE_get();
            internal static readonly int SIZE_WIDTH = NDalicPINVOKE.Actor_Property_SIZE_WIDTH_get();
            internal static readonly int SIZE_HEIGHT = NDalicPINVOKE.Actor_Property_SIZE_HEIGHT_get();
            internal static readonly int SIZE_DEPTH = NDalicPINVOKE.Actor_Property_SIZE_DEPTH_get();
            internal static readonly int POSITION = NDalicPINVOKE.Actor_Property_POSITION_get();
            internal static readonly int POSITION_X = NDalicPINVOKE.Actor_Property_POSITION_X_get();
            internal static readonly int POSITION_Y = NDalicPINVOKE.Actor_Property_POSITION_Y_get();
            internal static readonly int POSITION_Z = NDalicPINVOKE.Actor_Property_POSITION_Z_get();
            internal static readonly int WORLD_POSITION = NDalicPINVOKE.Actor_Property_WORLD_POSITION_get();
            internal static readonly int WORLD_POSITION_X = NDalicPINVOKE.Actor_Property_WORLD_POSITION_X_get();
            internal static readonly int WORLD_POSITION_Y = NDalicPINVOKE.Actor_Property_WORLD_POSITION_Y_get();
            internal static readonly int WORLD_POSITION_Z = NDalicPINVOKE.Actor_Property_WORLD_POSITION_Z_get();
            internal static readonly int ORIENTATION = NDalicPINVOKE.Actor_Property_ORIENTATION_get();
            internal static readonly int WORLD_ORIENTATION = NDalicPINVOKE.Actor_Property_WORLD_ORIENTATION_get();
            internal static readonly int SCALE = NDalicPINVOKE.Actor_Property_SCALE_get();
            internal static readonly int SCALE_X = NDalicPINVOKE.Actor_Property_SCALE_X_get();
            internal static readonly int SCALE_Y = NDalicPINVOKE.Actor_Property_SCALE_Y_get();
            internal static readonly int SCALE_Z = NDalicPINVOKE.Actor_Property_SCALE_Z_get();
            internal static readonly int WORLD_SCALE = NDalicPINVOKE.Actor_Property_WORLD_SCALE_get();
            internal static readonly int VISIBLE = NDalicPINVOKE.Actor_Property_VISIBLE_get();
            internal static readonly int WORLD_COLOR = NDalicPINVOKE.Actor_Property_WORLD_COLOR_get();
            internal static readonly int WORLD_MATRIX = NDalicPINVOKE.Actor_Property_WORLD_MATRIX_get();
            internal static readonly int NAME = NDalicPINVOKE.Actor_Property_NAME_get();
            internal static readonly int SENSITIVE = NDalicPINVOKE.Actor_Property_SENSITIVE_get();
            internal static readonly int LEAVE_REQUIRED = NDalicPINVOKE.Actor_Property_LEAVE_REQUIRED_get();
            internal static readonly int INHERIT_ORIENTATION = NDalicPINVOKE.Actor_Property_INHERIT_ORIENTATION_get();
            internal static readonly int INHERIT_SCALE = NDalicPINVOKE.Actor_Property_INHERIT_SCALE_get();
            internal static readonly int DRAW_MODE = NDalicPINVOKE.Actor_Property_DRAW_MODE_get();
            internal static readonly int SIZE_MODE_FACTOR = NDalicPINVOKE.Actor_Property_SIZE_MODE_FACTOR_get();
            internal static readonly int WIDTH_RESIZE_POLICY = NDalicPINVOKE.Actor_Property_WIDTH_RESIZE_POLICY_get();
            internal static readonly int HEIGHT_RESIZE_POLICY = NDalicPINVOKE.Actor_Property_HEIGHT_RESIZE_POLICY_get();
            internal static readonly int SIZE_SCALE_POLICY = NDalicPINVOKE.Actor_Property_SIZE_SCALE_POLICY_get();
            internal static readonly int WIDTH_FOR_HEIGHT = NDalicPINVOKE.Actor_Property_WIDTH_FOR_HEIGHT_get();
            internal static readonly int HEIGHT_FOR_WIDTH = NDalicPINVOKE.Actor_Property_HEIGHT_FOR_WIDTH_get();
            internal static readonly int PADDING = NDalicPINVOKE.Actor_Property_PADDING_get();
            internal static readonly int MINIMUM_SIZE = NDalicPINVOKE.Actor_Property_MINIMUM_SIZE_get();
            internal static readonly int MAXIMUM_SIZE = NDalicPINVOKE.Actor_Property_MAXIMUM_SIZE_get();
            internal static readonly int INHERIT_POSITION = NDalicPINVOKE.Actor_Property_INHERIT_POSITION_get();
            internal static readonly int CLIPPING_MODE = NDalicPINVOKE.Actor_Property_CLIPPING_MODE_get();
        }

        /// <summary>
        /// Describes the direction to move the focus towards.
        /// </summary>
        public enum FocusDirection
        {
            Left,
            Right,
            Up,
            Down,
            PageUp,
            PageDown
        }

        /// <summary>
        /// Creates a new instance of a View.
        /// </summary>
        public View() : this(NDalicPINVOKE.View_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        internal View(View uiControl) : this(NDalicPINVOKE.new_View__SWIG_1(View.getCPtr(uiControl)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Downcasts a handle to View handle.<br>
        /// If handle points to a View, the downcast produces valid handle.<br>
        /// If not, the returned handle is left uninitialized.<br>
        /// </summary>
        /// <param name="handle">Handle to an object</param>
        /// <returns>A handle to a View or an uninitialized handle</returns>
        public new static View DownCast(BaseHandle handle)
        {
            View ret = new View(NDalicPINVOKE.View_DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private View ConvertIdToView(uint id)
        {
            View view = null;

            if (Parent)
            {
                view = Parent.FindChildById(id);
            }

            if (!view)
            {
                view = Window.Instance.GetRootLayer().FindChildById(id);
            }

            return view;
        }

        internal void SetKeyInputFocus()
        {
            NDalicPINVOKE.View_SetKeyInputFocus(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Quries whether the view has focus.
        /// </summary>
        /// <returns>true if this view has focus</returns>
        public bool HasFocus()
        {
            bool ret = NDalicPINVOKE.View_HasKeyInputFocus(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void ClearKeyInputFocus()
        {
            NDalicPINVOKE.View_ClearKeyInputFocus(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PinchGestureDetector GetPinchGestureDetector()
        {
            PinchGestureDetector ret = new PinchGestureDetector(NDalicPINVOKE.View_GetPinchGestureDetector(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal PanGestureDetector GetPanGestureDetector()
        {
            PanGestureDetector ret = new PanGestureDetector(NDalicPINVOKE.View_GetPanGestureDetector(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TapGestureDetector GetTapGestureDetector()
        {
            TapGestureDetector ret = new TapGestureDetector(NDalicPINVOKE.View_GetTapGestureDetector(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LongPressGestureDetector GetLongPressGestureDetector()
        {
            LongPressGestureDetector ret = new LongPressGestureDetector(NDalicPINVOKE.View_GetLongPressGestureDetector(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the name of the style to be applied to the view.
        /// </summary>
        /// <param name="styleName">A string matching a style described in a stylesheet</param>
        public void SetStyleName(string styleName)
        {
            NDalicPINVOKE.View_SetStyleName(swigCPtr, styleName);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the name of the style to be applied to the view (if any).
        /// </summary>
        /// <returns>A string matching a style, or an empty string</returns>
        public string GetStyleName()
        {
            string ret = NDalicPINVOKE.View_GetStyleName(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetBackgroundColor(Vector4 color)
        {
            NDalicPINVOKE.View_SetBackgroundColor(swigCPtr, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector4 GetBackgroundColor()
        {
            Vector4 ret = new Vector4(NDalicPINVOKE.View_GetBackgroundColor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetBackgroundImage(Image image)
        {
            NDalicPINVOKE.View_SetBackgroundImage(swigCPtr, Image.getCPtr(image));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clears the background.
        /// </summary>
        public void ClearBackground()
        {
            NDalicPINVOKE.View_ClearBackground(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ControlKeySignal KeyEventSignal()
        {
            ControlKeySignal ret = new ControlKeySignal(NDalicPINVOKE.View_KeyEventSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal KeyInputFocusSignal KeyInputFocusGainedSignal()
        {
            KeyInputFocusSignal ret = new KeyInputFocusSignal(NDalicPINVOKE.View_KeyInputFocusGainedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal KeyInputFocusSignal KeyInputFocusLostSignal()
        {
            KeyInputFocusSignal ret = new KeyInputFocusSignal(NDalicPINVOKE.View_KeyInputFocusLostSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal View(ViewImpl implementation) : this(NDalicPINVOKE.new_View__SWIG_2(ViewImpl.getCPtr(implementation)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal enum PropertyRange
        {
            PROPERTY_START_INDEX = PropertyRanges.PROPERTY_REGISTRATION_START_INDEX,
            CONTROL_PROPERTY_START_INDEX = PROPERTY_START_INDEX,
            CONTROL_PROPERTY_END_INDEX = CONTROL_PROPERTY_START_INDEX + 1000
        }

        /// <summary>
        /// styleName, type string.
        /// </summary>
        public string StyleName
        {
            get
            {
                string temp;
                GetProperty(View.Property.STYLE_NAME).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.STYLE_NAME, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// mutually exclusive with BACKGROUND_IMAGE & BACKGROUND,  type Vector4.
        /// </summary>
        public Color BackgroundColor
        {
            get
            {
                Color backgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);

                Tizen.NUI.PropertyMap background = Background;
                int visualType = 0;
                background.Find(Visual.Property.Type)?.Get(out visualType);
                if (visualType == (int)Visual.Type.Color)
                {
                    background.Find(ColorVisualProperty.MixColor)?.Get(backgroundColor);
                }

                return backgroundColor;
            }
            set
            {
                SetProperty(View.Property.BACKGROUND, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Create an Animation to animate the background color visual. If there is no
        /// background visual, creates one with transparent black as it's mixColor.
        /// </summary>
        public Animation AnimateBackgroundColor( object destinationValue,
                                                 int startTime,
                                                 int endTime,
                                                 AlphaFunction.BuiltinFunctions? alphaFunction = null,
                                                 object initialValue = null)
        {
            Tizen.NUI.PropertyMap background = Background;

            if( background.Empty() )
            {
                // If there is no background yet, ensure there is a transparent
                // color visual
                BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                background = Background;
            }
            return AnimateColor( "background", destinationValue, startTime, endTime, alphaFunction, initialValue );
        }

        /// <summary>
        /// Create an Animation to animate the mixColor of the named visual.
        /// </summary>
        public Animation AnimateColor( string targetVisual, object destinationColor, int startTime, int endTime, AlphaFunction.BuiltinFunctions? alphaFunction = null, object initialColor = null )
        {
            Animation animation = null;
            {
                PropertyMap _animator = new PropertyMap();
                if( alphaFunction != null )
                {
                    _animator.Add("alphaFunction", new PropertyValue( AlphaFunction.BuiltinToPropertyKey(alphaFunction) ) );
                }

                PropertyMap _timePeriod = new PropertyMap();
                _timePeriod.Add( "duration", new PropertyValue((endTime-startTime)/1000.0f) );
                _timePeriod.Add( "delay", new PropertyValue( startTime/1000.0f ) );
                _animator.Add( "timePeriod", new PropertyValue( _timePeriod ) );

                PropertyMap _transition = new PropertyMap();
                _transition.Add( "animator", new PropertyValue( _animator ) );
                _transition.Add( "target", new PropertyValue( targetVisual ) );
                _transition.Add( "property", new PropertyValue( "mixColor" ) );

                if( initialColor != null )
                {
                    PropertyValue initValue = PropertyValue.CreateFromObject( initialColor );
                    _transition.Add( "initialValue", initValue );
                }

                PropertyValue destValue = PropertyValue.CreateFromObject( destinationColor );
                _transition.Add( "targetValue", destValue );
                TransitionData _transitionData = new TransitionData( _transition );

                animation = new Animation( NDalicManualPINVOKE.View_CreateTransition(swigCPtr, TransitionData.getCPtr(_transitionData)), true );
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return animation;
        }

        /// <summary>
        /// mutually exclusive with BACKGROUND_COLOR & BACKGROUND,  type Map.
        /// </summary>
        public string BackgroundImage
        {
            get
            {
                string backgroundImage = "";

                Tizen.NUI.PropertyMap background = Background;
                int visualType = 0;
                background.Find(Visual.Property.Type)?.Get(out visualType);
                if (visualType == (int)Visual.Type.Image)
                {
                    background.Find(ImageVisualProperty.URL)?.Get(out backgroundImage);
                }

                return backgroundImage;
            }
            set
            {
                SetProperty(View.Property.BACKGROUND, new Tizen.NUI.PropertyValue(value));
            }
        }

        public Tizen.NUI.PropertyMap Background
        {
            get
            {
                Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
                GetProperty( View.Property.BACKGROUND ).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.BACKGROUND, new Tizen.NUI.PropertyValue(value));
            }
        }


        /// <summary>
        /// The current state of the view.
        /// </summary>
        public States State
        {
            get
            {
                int temp = 0;
                if (GetProperty(View.Property.STATE).Get(out temp) == false)
                {
                    NUILog.Error("State get error!");
                }
                switch (temp)
                {
                    case 0:
                    {
                        return States.Normal;
                    }
                    case 1:
                    {
                        return States.Focused;
                    }
                    case 2:
                    {
                        return States.Disabled;
                    }
                    default:
                    {
                        return States.Normal;
                    }
                }
            }
            set
            {
                SetProperty(View.Property.STATE, new Tizen.NUI.PropertyValue((int)value));
            }
        }

        /// <summary>
        /// The current sub state of the view.
        /// </summary>
        public States SubState
        {
            get
            {
                string temp;
                if (GetProperty(View.Property.SUB_STATE).Get(out temp) == false)
                {
                    NUILog.Error("subState get error!");
                }
                switch (temp)
                {
                    case "NORMAL":
                        return States.Normal;
                    case "FOCUSED":
                        return States.Focused;
                    case "DISABLED":
                        return States.Disabled;
                    default:
                        return States.Normal;
                }
            }
            set
            {
                string valueToString = "";
                switch (value)
                {
                    case States.Normal:
                    {
                        valueToString = "NORMAL";
                        break;
                    }
                    case States.Focused:
                    {
                        valueToString = "FOCUSED";
                        break;
                    }
                    case States.Disabled:
                    {
                        valueToString = "DISABLED";
                        break;
                    }
                    default:
                    {
                        valueToString = "NORMAL";
                        break;
                    }
                }
                SetProperty(View.Property.SUB_STATE, new Tizen.NUI.PropertyValue(valueToString));
            }
        }

        /// <summary>
        /// Displays a tooltip
        /// </summary>
        public Tizen.NUI.PropertyMap Tooltip
        {
            get
            {
                Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
                GetProperty(View.Property.TOOLTIP).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.TOOLTIP, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Displays a tooltip as Text
        /// </summary>
        public string TooltipText
        {
            set
            {
                SetProperty(View.Property.TOOLTIP, new Tizen.NUI.PropertyValue(value));
            }
        }

        private int LeftFocusableViewId
        {
            get
            {
                int temp = 0;
                GetProperty(View.Property.LEFT_FOCUSABLE_VIEW_ID).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.LEFT_FOCUSABLE_VIEW_ID, new Tizen.NUI.PropertyValue(value));
            }
        }

        private int RightFocusableViewId
        {
            get
            {
                int temp = 0;
                GetProperty(View.Property.RIGHT_FOCUSABLE_VIEW_ID).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.RIGHT_FOCUSABLE_VIEW_ID, new Tizen.NUI.PropertyValue(value));
            }
        }

        private int UpFocusableViewId
        {
            get
            {
                int temp = 0;
                GetProperty(View.Property.UP_FOCUSABLE_VIEW_ID).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.UP_FOCUSABLE_VIEW_ID, new Tizen.NUI.PropertyValue(value));
            }
        }

        private int DownFocusableViewId
        {
            get
            {
                int temp = 0;
                GetProperty(View.Property.DOWN_FOCUSABLE_VIEW_ID).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.DOWN_FOCUSABLE_VIEW_ID, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Child Property of FlexContainer.<br>
        /// The proportion of the free space in the container the flex item will receive.<br>
        /// If all items in the container set this property, their sizes will be proportional to the specified flex factor.<br>
        /// </summary>
        public float Flex
        {
            get
            {
                float temp = 0.0f;
                GetProperty(FlexContainer.ChildProperty.FLEX).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(FlexContainer.ChildProperty.FLEX, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Child Property of FlexContainer.<br>
        /// The alignment of the flex item along the cross axis, which, if set, overides the default alignment for all items in the container.<br>
        /// </summary>
        public int AlignSelf
        {
            get
            {
                int temp = 0;
                GetProperty(FlexContainer.ChildProperty.ALIGN_SELF).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(FlexContainer.ChildProperty.ALIGN_SELF, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Child Property of FlexContainer.<br>
        /// The space around the flex item.<br>
        /// </summary>
        public Vector4 FlexMargin
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(FlexContainer.ChildProperty.FLEX_MARGIN).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(FlexContainer.ChildProperty.FLEX_MARGIN, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The top-left cell this child occupies, if not set, the first available cell is used
        /// </summary>
        public Vector2 CellIndex
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(TableView.ChildProperty.CELL_INDEX).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(TableView.ChildProperty.CELL_INDEX, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The number of rows this child occupies, if not set, default value is 1
        /// </summary>
        public float RowSpan
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TableView.ChildProperty.ROW_SPAN).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TableView.ChildProperty.ROW_SPAN, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The number of columns this child occupies, if not set, default value is 1
        /// </summary>
        public float ColumnSpan
        {
            get
            {
                float temp = 0.0f;
                GetProperty(TableView.ChildProperty.COLUMN_SPAN).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TableView.ChildProperty.COLUMN_SPAN, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The horizontal alignment of this child inside the cells, if not set, default value is 'left'
        /// </summary>
        public Tizen.NUI.HorizontalAlignmentType CellHorizontalAlignment
        {
            get
            {
                string temp;
                if (GetProperty(TableView.ChildProperty.CELL_HORIZONTAL_ALIGNMENT).Get(out temp) == false)
                {
                    NUILog.Error("CellHorizontalAlignment get error!");
                }

                switch (temp)
                {
                    case "left":
                        return Tizen.NUI.HorizontalAlignmentType.Left;
                    case "center":
                        return Tizen.NUI.HorizontalAlignmentType.Center;
                    case "right":
                        return Tizen.NUI.HorizontalAlignmentType.Right;
                    default:
                        return Tizen.NUI.HorizontalAlignmentType.Left;
                }
            }
            set
            {
                string valueToString = "";
                switch (value)
                {
                    case Tizen.NUI.HorizontalAlignmentType.Left:
                    {
                        valueToString = "left";
                        break;
                    }
                    case Tizen.NUI.HorizontalAlignmentType.Center:
                    {
                        valueToString = "center";
                        break;
                    }
                    case Tizen.NUI.HorizontalAlignmentType.Right:
                    {
                        valueToString = "right";
                        break;
                    }
                    default:
                    {
                        valueToString = "left";
                        break;
                    }
                }
                SetProperty(TableView.ChildProperty.CELL_HORIZONTAL_ALIGNMENT, new Tizen.NUI.PropertyValue(valueToString));
            }
        }

        /// <summary>
        /// The vertical alignment of this child inside the cells, if not set, default value is 'top'
        /// </summary>
        public Tizen.NUI.VerticalAlignmentType CellVerticalAlignment
        {
            get
            {
                string temp;
                GetProperty(TableView.ChildProperty.CELL_VERTICAL_ALIGNMENT).Get(out temp);
                {
                    NUILog.Error("CellVerticalAlignment get error!");
                }

                switch (temp)
                {
                    case "top":
                        return Tizen.NUI.VerticalAlignmentType.Top;
                    case "center":
                        return Tizen.NUI.VerticalAlignmentType.Center;
                    case "bottom":
                        return Tizen.NUI.VerticalAlignmentType.Bottom;
                    default:
                        return Tizen.NUI.VerticalAlignmentType.Top;
                }
            }
            set
            {
                string valueToString = "";
                switch (value)
                {
                    case Tizen.NUI.VerticalAlignmentType.Top:
                    {
                        valueToString = "top";
                        break;
                    }
                    case Tizen.NUI.VerticalAlignmentType.Center:
                    {
                        valueToString = "center";
                        break;
                    }
                    case Tizen.NUI.VerticalAlignmentType.Bottom:
                    {
                        valueToString = "bottom";
                        break;
                    }
                    default:
                    {
                        valueToString = "top";
                        break;
                    }
                }
                SetProperty(TableView.ChildProperty.CELL_VERTICAL_ALIGNMENT, new Tizen.NUI.PropertyValue(valueToString));
            }
        }

        /// <summary>
        /// The left focusable view.<br>
        /// This will return NULL if not set.<br>
        /// This will also return NULL if the specified left focusable view is not on Window.<br>
        /// </summary>
        public View LeftFocusableView
        {
            // As native side will be only storing IDs so need a logic to convert View to ID and vice-versa.
            get
            {
                if (LeftFocusableViewId >= 0)
                {
                    return ConvertIdToView((uint)LeftFocusableViewId);
                }
                return null;
            }
            set
            {
                LeftFocusableViewId = (int)value.GetId();
            }
        }

        /// <summary>
        /// The right focusable view.<br>
        /// This will return NULL if not set.<br>
        /// This will also return NULL if the specified right focusable view is not on Window.<br>
        /// </summary>
        public View RightFocusableView
        {
            // As native side will be only storing IDs so need a logic to convert View to ID and vice-versa.
            get
            {
                if (RightFocusableViewId >= 0)
                {
                    return ConvertIdToView((uint)RightFocusableViewId);
                }
                return null;
            }
            set
            {
                RightFocusableViewId = (int)value.GetId();
            }
        }

        /// <summary>
        /// The up focusable view.<br>
        /// This will return NULL if not set.<br>
        /// This will also return NULL if the specified up focusable view is not on Window.<br>
        /// </summary>
        public View UpFocusableView
        {
            // As native side will be only storing IDs so need a logic to convert View to ID and vice-versa.
            get
            {
                if (UpFocusableViewId >= 0)
                {
                    return ConvertIdToView((uint)UpFocusableViewId);
                }
                return null;
            }
            set
            {
                UpFocusableViewId = (int)value.GetId();
            }
        }

        /// <summary>
        /// The down focusable view.<br>
        /// This will return NULL if not set.<br>
        /// This will also return NULL if the specified down focusable view is not on Window.<br>
        /// </summary>
        public View DownFocusableView
        {
            // As native side will be only storing IDs so need a logic to convert View to ID and vice-versa.
            get
            {
                if (DownFocusableViewId >= 0)
                {
                    return ConvertIdToView((uint)DownFocusableViewId);
                }
                return null;
            }
            set
            {
                DownFocusableViewId = (int)value.GetId();
            }
        }

        /// <summary>
        /// whether the view should be focusable by keyboard navigation.
        /// </summary>
        public bool Focusable
        {
            set
            {
                SetKeyboardFocusable(value);
            }
            get
            {
                return IsKeyboardFocusable();
            }
        }

        /// <summary>
        /// Enumeration for describing the states of view.
        /// </summary>
        public enum States
        {
            /// <summary>
            /// Normal state
            /// </summary>
            Normal,
            /// <summary>
            /// Focused state
            /// </summary>
            Focused,
            /// <summary>
            /// Disabled state
            /// </summary>
            Disabled
        }

        /// <summary>
        ///  Retrieves the position of the View.<br>
        ///  The coordinates are relative to the View's parent.<br>
        /// </summary>
        public Position CurrentPosition
        {
            get
            {
                return GetCurrentPosition();
            }
        }

        /// <summary>
        /// Sets the size of an view for width and height.<br>
        /// Geometry can be scaled to fit within this area.<br>
        /// This does not interfere with the views scale factor.<br>
        /// The views default depth is the minimum of width & height.<br>
        /// </summary>
        public Size2D Size2D
        {
            get
            {
                Size temp = new Size(0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.SIZE).Get(temp);
                Size2D size = new Size2D((int)temp.Width, (int)temp.Height);
                return size;
            }
            set
            {
                SetProperty(View.Property.SIZE, new Tizen.NUI.PropertyValue(new Size(value)));
            }
        }

        /// <summary>
        ///  Retrieves the size of the View.<br>
        ///  The coordinates are relative to the View's parent.<br>
        /// </summary>
        public Size2D CurrentSize
        {
            get
            {
                return GetCurrentSize();
            }
        }

        /// <summary>
        /// Retrieves the view's parent.<br>
        /// </summary>
        public View Parent
        {
            get
            {
                return GetParent();
            }
        }

        public bool Visibility
        {
            get
            {
                return IsVisible();
            }
        }

        /// <summary>
        /// Retrieves and sets the view's opacity.<br>
        /// </summary>
        public float Opacity
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.OPACITY).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.OPACITY, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Sets the position of the View for X and Y.<br>
        /// By default, sets the position vector between the parent origin and pivot point(default).<br>
        /// If Position inheritance if disabled, sets the world position.<br>
        /// </summary>
        public Position2D Position2D
        {
            get
            {
                Position temp = new Position(0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.POSITION).Get(temp);
                return new Position2D(temp);
            }
            set
            {
                SetProperty(View.Property.POSITION, new Tizen.NUI.PropertyValue(new Position(value)));
            }
        }

        /// <summary>
        /// Retrieves screen postion of view's.<br>
        /// </summary>
        public Vector2 ScreenPosition
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(View.Property.SCREEN_POSITION).Get(temp);
                return temp;
            }
        }

        /// <summary>
        /// Determines whether the pivot point should be used to determine the position of the view.
        /// This is true by default.
        /// </summary>
        /// <remarks>If false, then the top-left of the view is used for the position.
        /// Setting this to false will allow scaling or rotation around the anchor-point without affecting the view's position.
        /// </remarks>
        public bool PositionUsesPivotPoint
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.POSITION_USES_ANCHOR_POINT).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.POSITION_USES_ANCHOR_POINT, new Tizen.NUI.PropertyValue(value));
            }
        }

        internal bool FocusState
        {
            get
            {
                return IsKeyboardFocusable();
            }
            set
            {
                SetKeyboardFocusable(value);
            }
        }

        /// <summary>
        /// Queries whether the view is connected to the Stage.<br>
        /// When an view is connected, it will be directly or indirectly parented to the root View.<br>
        /// </summary>
        public bool IsOnWindow
        {
            get
            {
                return OnWindow();
            }
        }

        /// <summary>
        /// Gets depth in the hierarchy for the view.
        /// </summary>
        public int HierarchyDepth
        {
            get
            {
                return GetHierarchyDepth();
            }
        }

        /// <summary>
        /// Sets the sibling order of the view so depth position can be defined within the same parent.
        /// </summary>
        /// <remarks>
        /// Note The initial value is 0.
        /// Raise, Lower, RaiseToTop, LowerToBottom, RaiseAbove and LowerBelow will override the sibling order.
        /// The values set by this Property will likely change.
        /// </remarks>
        public int SiblingOrder
        {
            get
            {
                int temp = 0;
                GetProperty(View.Property.SIBLING_ORDER).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.SIBLING_ORDER, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets the natural size of the view.<br>
        /// </summary>
        /// <remarks>
        /// Readonly.
        /// </remarks>
        internal Vector3 NaturalSize
        {
            get
            {
                Vector3 ret = new Vector3(NDalicPINVOKE.Actor_GetNaturalSize(swigCPtr), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Shows the View.
        /// </summary>
        /// <remarks>
        /// This is an asynchronous method.
        /// </remarks>
        public void Show()
        {
            SetVisible(true);
        }

        /// <summary>
        /// Hides the View.
        /// </summary>
        /// <remarks>
        /// This is an asynchronous method.
        /// If an view is hidden, then the view and its children will not be rendered.
        /// This is regardless of the individual visibility of the children i.e.an view will only be rendered if all of its parents are shown.
        /// </remarks>
        public void Hide()
        {
            SetVisible(false);
        }

        internal void Raise()
        {
            NDalicPINVOKE.Raise(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void Lower()
        {
            NDalicPINVOKE.Lower(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Raise view above all other views.
        /// </summary>
        /// <remarks>
        /// Sibling order of views within the parent will be updated automatically.
        /// Once a raise or lower API is used that view will then have an exclusive sibling order independent of insertion.
        /// </remarks>
        public void RaiseToTop()
        {
            NDalicPINVOKE.RaiseToTop(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Lower view to the bottom of all views.
        /// </summary>
        /// <remarks>
        /// Sibling order of views within the parent will be updated automatically.
        /// Once a raise or lower API is used that view will then have an exclusive sibling order independent of insertion.
        /// </remarks>
        public void LowerToBottom()
        {
            NDalicPINVOKE.LowerToBottom(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Query if all resources required by a View are loaded and ready.
        /// </summary>
        /// <remarks>Most resources are only loaded when the control is placed on stage
        /// </remarks>
        public bool IsResourceReady()
        {
            bool ret = NDalicPINVOKE.IsResourceReady(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Raise the view to above the target view.
        /// </summary>
        /// <remarks>Sibling order of views within the parent will be updated automatically.
        /// Views on the level above the target view will still be shown above this view.
        /// Raising this view above views with the same sibling order as each other will raise this view above them.
        /// Once a raise or lower API is used that view will then have an exclusive sibling order independent of insertion.
        /// </remarks>
        /// <param name="target">Will be raised above this view</param>
        internal void RaiseAbove(View target)
        {
            NDalicPINVOKE.RaiseAbove(swigCPtr, View.getCPtr(target));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Lower the view to below the target view.
        /// </summary>
        /// <remarks>Sibling order of views within the parent will be updated automatically.
        /// Lowering this view below views with the same sibling order as each other will lower this view above them.
        /// Once a raise or lower API is used that view will then have an exclusive sibling order independent of insertion.
        /// </remarks>
        /// <param name="target">Will be lowered below this view</param>
        internal void LowerBelow(View target)
        {
            NDalicPINVOKE.RaiseAbove(swigCPtr, View.getCPtr(target));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal string GetName()
        {
            string ret = NDalicPINVOKE.Actor_GetName(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetName(string name)
        {
            NDalicPINVOKE.Actor_SetName(swigCPtr, name);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal uint GetId()
        {
            uint ret = NDalicPINVOKE.Actor_GetId(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal bool IsRoot()
        {
            bool ret = NDalicPINVOKE.Actor_IsRoot(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal bool OnWindow()
        {
            bool ret = NDalicPINVOKE.Actor_OnStage(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Layer GetLayer()
        {
            Layer ret = new Layer(NDalicPINVOKE.Actor_GetLayer(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Adds a child view to this View.
        /// </summary>
        /// <pre>This View(the parent) has been initialized. The child view has been initialized. The child view is not the same as the parent view.</pre>
        /// <post>The child will be referenced by its parent. This means that the child will be kept alive, even if the handle passed into this method is reset or destroyed.</post>
        /// <remarks>If the child already has a parent, it will be removed from old parent and reparented to this view. This may change child's position, color, scale etc as it now inherits them from this view.</remarks>
        /// <param name="child">The child</param>
        public void Add(View child)
        {
            NDalicPINVOKE.Actor_Add(swigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes a child View from this View. If the view was not a child of this view, this is a no-op.
        /// </summary>
        /// <pre>This View(the parent) has been initialized. The child view is not the same as the parent view.</pre>
        /// <param name="child">The child</param>
        public void Remove(View child)
        {
            NDalicPINVOKE.Actor_Remove(swigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void Unparent()
        {
            NDalicPINVOKE.Actor_Unparent(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the number of children held by the view.
        /// </summary>
        /// <pre>The View has been initialized.</pre>
        /// <returns>The number of children</returns>
        internal uint GetChildCount()
        {
            uint ret = NDalicPINVOKE.Actor_GetChildCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves child view by index.
        /// </summary>
        /// <pre>The View has been initialized.</pre>
        /// <param name="index">The index of the child to retrieve</param>
        /// <returns>The view for the given index or empty handle if children not initialized</returns>
        public View GetChildAt(uint index)
        {
            IntPtr cPtr = NDalicPINVOKE.Actor_GetChildAt(swigCPtr, index);

            View ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as View;

            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret ?? null;
        }

        /// <summary>
        /// Search through this view's hierarchy for an view with the given name.
        /// The view itself is also considered in the search.
        /// </summary>
        /// <pre>The View has been initialized.</pre>
        /// <param name="viewName">The name of the view to find</param>
        /// <returns>A handle to the view if found, or an empty handle if not</returns>
        public View FindChildByName(string viewName)
        {
            IntPtr cPtr = NDalicPINVOKE.Actor_FindChildByName(swigCPtr, viewName);

            View ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as View;

            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal View FindChildById(uint id)
        {
            IntPtr cPtr = NDalicPINVOKE.Actor_FindChildById(swigCPtr, id);

            View ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as View;

            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal View GetParent()
        {
            IntPtr cPtr = NDalicPINVOKE.Actor_GetParent(swigCPtr);

            View ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as View;

            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetParentOrigin(Vector3 origin)
        {
            NDalicPINVOKE.Actor_SetParentOrigin(swigCPtr, Vector3.getCPtr(origin));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector3 GetCurrentParentOrigin()
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Actor_GetCurrentParentOrigin(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetAnchorPoint(Vector3 anchorPoint)
        {
            NDalicPINVOKE.Actor_SetAnchorPoint(swigCPtr, Vector3.getCPtr(anchorPoint));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector3 GetCurrentAnchorPoint()
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Actor_GetCurrentAnchorPoint(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetSize(float width, float height)
        {
            NDalicPINVOKE.Actor_SetSize__SWIG_0(swigCPtr, width, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetSize(float width, float height, float depth)
        {
            NDalicPINVOKE.Actor_SetSize__SWIG_1(swigCPtr, width, height, depth);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetSize(Vector2 size)
        {
            NDalicPINVOKE.Actor_SetSize__SWIG_2(swigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetSize(Vector3 size)
        {
            NDalicPINVOKE.Actor_SetSize__SWIG_3(swigCPtr, Vector3.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector3 GetTargetSize()
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Actor_GetTargetSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Size2D GetCurrentSize()
        {
            Size ret = new Size(NDalicPINVOKE.Actor_GetCurrentSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            Size2D size = new Size2D((int)ret.Width, (int)ret.Height);
            return size;
        }

        internal Vector3 GetNaturalSize()
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Actor_GetNaturalSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetPosition(float x, float y)
        {
            NDalicPINVOKE.Actor_SetPosition__SWIG_0(swigCPtr, x, y);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetPosition(float x, float y, float z)
        {
            NDalicPINVOKE.Actor_SetPosition__SWIG_1(swigCPtr, x, y, z);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetPosition(Vector3 position)
        {
            NDalicPINVOKE.Actor_SetPosition__SWIG_2(swigCPtr, Vector3.getCPtr(position));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetX(float x)
        {
            NDalicPINVOKE.Actor_SetX(swigCPtr, x);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetY(float y)
        {
            NDalicPINVOKE.Actor_SetY(swigCPtr, y);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetZ(float z)
        {
            NDalicPINVOKE.Actor_SetZ(swigCPtr, z);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void TranslateBy(Vector3 distance)
        {
            NDalicPINVOKE.Actor_TranslateBy(swigCPtr, Vector3.getCPtr(distance));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Position GetCurrentPosition()
        {
            Position ret = new Position(NDalicPINVOKE.Actor_GetCurrentPosition(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector3 GetCurrentWorldPosition()
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Actor_GetCurrentWorldPosition(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetInheritPosition(bool inherit)
        {
            NDalicPINVOKE.Actor_SetInheritPosition(swigCPtr, inherit);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsPositionInherited()
        {
            bool ret = NDalicPINVOKE.Actor_IsPositionInherited(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetOrientation(Degree angle, Vector3 axis)
        {
            NDalicPINVOKE.Actor_SetOrientation__SWIG_0(swigCPtr, Degree.getCPtr(angle), Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetOrientation(Radian angle, Vector3 axis)
        {
            NDalicPINVOKE.Actor_SetOrientation__SWIG_1(swigCPtr, Radian.getCPtr(angle), Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetOrientation(Rotation orientation)
        {
            NDalicPINVOKE.Actor_SetOrientation__SWIG_2(swigCPtr, Rotation.getCPtr(orientation));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void RotateBy(Degree angle, Vector3 axis)
        {
            NDalicPINVOKE.Actor_RotateBy__SWIG_0(swigCPtr, Degree.getCPtr(angle), Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void RotateBy(Radian angle, Vector3 axis)
        {
            NDalicPINVOKE.Actor_RotateBy__SWIG_1(swigCPtr, Radian.getCPtr(angle), Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void RotateBy(Rotation relativeRotation)
        {
            NDalicPINVOKE.Actor_RotateBy__SWIG_2(swigCPtr, Rotation.getCPtr(relativeRotation));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Rotation GetCurrentOrientation()
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Actor_GetCurrentOrientation(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetInheritOrientation(bool inherit)
        {
            NDalicPINVOKE.Actor_SetInheritOrientation(swigCPtr, inherit);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsOrientationInherited()
        {
            bool ret = NDalicPINVOKE.Actor_IsOrientationInherited(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Rotation GetCurrentWorldOrientation()
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Actor_GetCurrentWorldOrientation(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetScale(float scale)
        {
            NDalicPINVOKE.Actor_SetScale__SWIG_0(swigCPtr, scale);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetScale(float scaleX, float scaleY, float scaleZ)
        {
            NDalicPINVOKE.Actor_SetScale__SWIG_1(swigCPtr, scaleX, scaleY, scaleZ);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetScale(Vector3 scale)
        {
            NDalicPINVOKE.Actor_SetScale__SWIG_2(swigCPtr, Vector3.getCPtr(scale));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void ScaleBy(Vector3 relativeScale)
        {
            NDalicPINVOKE.Actor_ScaleBy(swigCPtr, Vector3.getCPtr(relativeScale));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector3 GetCurrentScale()
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Actor_GetCurrentScale(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector3 GetCurrentWorldScale()
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Actor_GetCurrentWorldScale(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetInheritScale(bool inherit)
        {
            NDalicPINVOKE.Actor_SetInheritScale(swigCPtr, inherit);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsScaleInherited()
        {
            bool ret = NDalicPINVOKE.Actor_IsScaleInherited(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Matrix GetCurrentWorldMatrix()
        {
            Matrix ret = new Matrix(NDalicPINVOKE.Actor_GetCurrentWorldMatrix(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetVisible(bool visible)
        {
            NDalicPINVOKE.Actor_SetVisible(swigCPtr, visible);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsVisible()
        {
            bool ret = NDalicPINVOKE.Actor_IsVisible(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetOpacity(float opacity)
        {
            NDalicPINVOKE.Actor_SetOpacity(swigCPtr, opacity);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal float GetCurrentOpacity()
        {
            float ret = NDalicPINVOKE.Actor_GetCurrentOpacity(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetColor(Vector4 color)
        {
            NDalicPINVOKE.Actor_SetColor(swigCPtr, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector4 GetCurrentColor()
        {
            Vector4 ret = new Vector4(NDalicPINVOKE.Actor_GetCurrentColor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetColorMode(ColorMode colorMode)
        {
            NDalicPINVOKE.Actor_SetColorMode(swigCPtr, (int)colorMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ColorMode GetColorMode()
        {
            ColorMode ret = (ColorMode)NDalicPINVOKE.Actor_GetColorMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector4 GetCurrentWorldColor()
        {
            Vector4 ret = new Vector4(NDalicPINVOKE.Actor_GetCurrentWorldColor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetDrawMode(DrawModeType drawMode)
        {
            NDalicPINVOKE.Actor_SetDrawMode(swigCPtr, (int)drawMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal DrawModeType GetDrawMode()
        {
            DrawModeType ret = (DrawModeType)NDalicPINVOKE.Actor_GetDrawMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Converts screen coordinates into the view's coordinate system using the default camera.
        /// </summary>
        /// <pre>The View has been initialized.</pre>
        /// <remarks>The view coordinates are relative to the top-left(0.0, 0.0, 0.5)</remarks>
        /// <param name="localX">On return, the X-coordinate relative to the view</param>
        /// <param name="localY">On return, the Y-coordinate relative to the view</param>
        /// <param name="screenX">The screen X-coordinate</param>
        /// <param name="screenY">The screen Y-coordinate</param>
        /// <returns>True if the conversion succeeded</returns>
        public bool ScreenToLocal(out float localX, out float localY, float screenX, float screenY)
        {
            bool ret = NDalicPINVOKE.Actor_ScreenToLocal(swigCPtr, out localX, out localY, screenX, screenY);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetKeyboardFocusable(bool focusable)
        {
            NDalicPINVOKE.Actor_SetKeyboardFocusable(swigCPtr, focusable);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsKeyboardFocusable()
        {
            bool ret = NDalicPINVOKE.Actor_IsKeyboardFocusable(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetResizePolicy(ResizePolicyType policy, DimensionType dimension)
        {
            NDalicPINVOKE.Actor_SetResizePolicy(swigCPtr, (int)policy, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ResizePolicyType GetResizePolicy(DimensionType dimension)
        {
            ResizePolicyType ret = (ResizePolicyType)NDalicPINVOKE.Actor_GetResizePolicy(swigCPtr, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the relative to parent size factor of the view.<br>
        /// This factor is only used when ResizePolicy is set to either:
        /// ResizePolicy::SIZE_RELATIVE_TO_PARENT or ResizePolicy::SIZE_FIXED_OFFSET_FROM_PARENT.<br>
        /// This view's size is set to the view's size multiplied by or added to this factor, depending on ResizePolicy.<br>
        /// </summary>
        /// <pre>The View has been initialized.</pre>
        /// <param name="factor">A Vector3 representing the relative factor to be applied to each axis</param>
        public void SetSizeModeFactor(Vector3 factor)
        {
            NDalicPINVOKE.Actor_SetSizeModeFactor(swigCPtr, Vector3.getCPtr(factor));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector3 GetSizeModeFactor()
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Actor_GetSizeModeFactor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Calculates the height of the view given a width.<br>
        /// The natural size is used for default calculation. <br>
        /// size 0 is treated as aspect ratio 1:1.<br>
        /// </summary>
        /// <param name="width">Width to use</param>
        /// <returns>The height based on the width</returns>
        public float GetHeightForWidth(float width)
        {
            float ret = NDalicPINVOKE.Actor_GetHeightForWidth(swigCPtr, width);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Calculates the width of the view given a height.<br>
        /// The natural size is used for default calculation.<br>
        /// size 0 is treated as aspect ratio 1:1.<br>
        /// </summary>
        /// <param name="height">Height to use</param>
        /// <returns>The width based on the height</returns>
        public float GetWidthForHeight(float height)
        {
            float ret = NDalicPINVOKE.Actor_GetWidthForHeight(swigCPtr, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public float GetRelayoutSize(DimensionType dimension)
        {
            float ret = NDalicPINVOKE.Actor_GetRelayoutSize(swigCPtr, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetPadding(PaddingType padding)
        {
            NDalicPINVOKE.Actor_SetPadding(swigCPtr, PaddingType.getCPtr(padding));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void GetPadding(PaddingType paddingOut)
        {
            NDalicPINVOKE.Actor_GetPadding(swigCPtr, PaddingType.getCPtr(paddingOut));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetMinimumSize(Vector2 size)
        {
            NDalicPINVOKE.Actor_SetMinimumSize(swigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector2 GetMinimumSize()
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Actor_GetMinimumSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetMaximumSize(Vector2 size)
        {
            NDalicPINVOKE.Actor_SetMaximumSize(swigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector2 GetMaximumSize()
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Actor_GetMaximumSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal int GetHierarchyDepth()
        {
            int ret = NDalicPINVOKE.Actor_GetHierarchyDepth(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint AddRenderer(Renderer renderer)
        {
            uint ret = NDalicPINVOKE.Actor_AddRenderer(swigCPtr, Renderer.getCPtr(renderer));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal uint GetRendererCount()
        {
            uint ret = NDalicPINVOKE.Actor_GetRendererCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Renderer GetRendererAt(uint index)
        {
            Renderer ret = new Renderer(NDalicPINVOKE.Actor_GetRendererAt(swigCPtr, index), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void RemoveRenderer(Renderer renderer)
        {
            NDalicPINVOKE.Actor_RemoveRenderer__SWIG_0(swigCPtr, Renderer.getCPtr(renderer));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void RemoveRenderer(uint index)
        {
            NDalicPINVOKE.Actor_RemoveRenderer__SWIG_1(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TouchDataSignal TouchSignal()
        {
            TouchDataSignal ret = new TouchDataSignal(NDalicPINVOKE.Actor_TouchSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal HoverSignal HoveredSignal()
        {
            HoverSignal ret = new HoverSignal(NDalicPINVOKE.Actor_HoveredSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WheelSignal WheelEventSignal()
        {
            WheelSignal ret = new WheelSignal(NDalicPINVOKE.Actor_WheelEventSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ViewSignal OnWindowSignal()
        {
            ViewSignal ret = new ViewSignal(NDalicPINVOKE.Actor_OnStageSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ViewSignal OffWindowSignal()
        {
            ViewSignal ret = new ViewSignal(NDalicPINVOKE.Actor_OffStageSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ViewSignal OnRelayoutSignal()
        {
            ViewSignal ret = new ViewSignal(NDalicPINVOKE.Actor_OnRelayoutSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ViewVisibilityChangedSignal VisibilityChangedSignal(View view) {
            ViewVisibilityChangedSignal ret = new ViewVisibilityChangedSignal(NDalicPINVOKE.VisibilityChangedSignal(View.getCPtr(view)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ViewSignal ResourcesLoadedSignal()
        {
            ViewSignal ret = new ViewSignal(NDalicPINVOKE.ResourceReadySignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets/Sets the origin of an view, within its parent's area.<br>
        /// This is expressed in unit coordinates, such that (0.0, 0.0, 0.5) is the top-left corner of the parent, and(1.0, 1.0, 0.5) is the bottom-right corner.<br>
        /// The default parent-origin is ParentOrigin.TopLeft (0.0, 0.0, 0.5).<br>
        /// An view's position is the distance between this origin, and the view's anchor-point.<br>
        /// </summary>
        /// <pre>The View has been initialized.</pre>
        public Position ParentOrigin
        {
            get
            {
                Position temp = new Position(0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.PARENT_ORIGIN).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.PARENT_ORIGIN, new Tizen.NUI.PropertyValue(value));
            }
        }

        internal float ParentOriginX
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.PARENT_ORIGIN_X).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.PARENT_ORIGIN_X, new Tizen.NUI.PropertyValue(value));
            }
        }

        internal float ParentOriginY
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.PARENT_ORIGIN_Y).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.PARENT_ORIGIN_Y, new Tizen.NUI.PropertyValue(value));
            }
        }

        internal float ParentOriginZ
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.PARENT_ORIGIN_Z).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.PARENT_ORIGIN_Z, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets/Sets the anchor-point of an view.<br>
        /// This is expressed in unit coordinates, such that (0.0, 0.0, 0.5) is the top-left corner of the view, and (1.0, 1.0, 0.5) is the bottom-right corner.<br>
        /// The default pivot point is PivotPoint.Center (0.5, 0.5, 0.5).<br>
        /// An view position is the distance between its parent-origin and this anchor-point.<br>
        /// An view's orientation is the rotation from its default orientation, the rotation is centered around its anchor-point.<br>
        /// <pre>The View has been initialized.</pre>
        /// </summary>
        public Position PivotPoint
        {
            get
            {
                Position temp = new Position(0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.ANCHOR_POINT).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.ANCHOR_POINT, new Tizen.NUI.PropertyValue(value));
            }
        }

        internal float PivotPointX
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.ANCHOR_POINT_X).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.ANCHOR_POINT_X, new Tizen.NUI.PropertyValue(value));
            }
        }

        internal float PivotPointY
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.ANCHOR_POINT_Y).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.ANCHOR_POINT_Y, new Tizen.NUI.PropertyValue(value));
            }
        }

        internal float PivotPointZ
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.ANCHOR_POINT_Z).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.ANCHOR_POINT_Z, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets/Sets the size width of an view.
        /// </summary>
        public float SizeWidth
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.SIZE_WIDTH).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.SIZE_WIDTH, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets/Sets the size height of an view.
        /// </summary>
        public float SizeHeight
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.SIZE_HEIGHT).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.SIZE_HEIGHT, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets/Sets the position of the View.<br>
        /// By default, sets the position vector between the parent origin and pivot point(default).<br>
        /// If Position inheritance if disabled, sets the world position.<br>
        /// </summary>
        public Position Position
        {
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.POSITION).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.POSITION, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets/Sets the position x of the View.
        /// </summary>
        public float PositionX
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.POSITION_X).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.POSITION_X, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets/Sets the position y of the View.
        /// </summary>
        public float PositionY
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.POSITION_Y).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.POSITION_Y, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets/Sets the position z of the View.
        /// </summary>
        public float PositionZ
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.POSITION_Z).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.POSITION_Z, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets/Sets the world position of the View.
        /// </summary>
        public Vector3 WorldPosition
        {
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.WORLD_POSITION).Get(temp);
                return temp;
            }
        }

        internal float WorldPositionX
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.WORLD_POSITION_X).Get(out temp);
                return temp;
            }
        }

        internal float WorldPositionY
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.WORLD_POSITION_Y).Get(out temp);
                return temp;
            }
        }

        internal float WorldPositionZ
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.WORLD_POSITION_Z).Get(out temp);
                return temp;
            }
        }

        /// <summary>
        /// Gets/Sets the orientation of the View.<br>
        /// An view's orientation is the rotation from its default orientation, and the rotation is centered around its anchor-point.<br>
        /// </summary>
        /// <remarks>This is an asynchronous method.</remarks>
        public Rotation Orientation
        {
            get
            {
                Rotation temp = new Rotation();
                GetProperty(View.Property.ORIENTATION).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.ORIENTATION, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets/Sets the world orientation of the View.<br>
        /// </summary>
        public Rotation WorldOrientation
        {
            get
            {
                Rotation temp = new Rotation();
                GetProperty(View.Property.WORLD_ORIENTATION).Get(temp);
                return temp;
            }
        }

        /// <summary>
        /// Gets/Sets the scale factor applied to an view.<br>
        /// </summary>
        public Vector3 Scale
        {
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.SCALE).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.SCALE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets/Sets the scale x factor applied to an view.
        /// </summary>
        public float ScaleX
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.SCALE_X).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.SCALE_X, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets/Sets the scale y factor applied to an view.
        /// </summary>
        public float ScaleY
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.SCALE_Y).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.SCALE_Y, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets/Sets the scale z factor applied to an view.
        /// </summary>
        public float ScaleZ
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.SCALE_Z).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.SCALE_Z, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets the world scale of View.
        /// </summary>
        public Vector3 WorldScale
        {
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.WORLD_SCALE).Get(temp);
                return temp;
            }
        }

        /// <summary>
        /// Retrieves the visibility flag of an view.
        /// </summary>
        /// <remarks>
        /// If an view is not visible, then the view and its children will not be rendered.
        /// This is regardless of the individual visibility values of the children i.e.an view will only be rendered if all of its parents have visibility set to true.
        /// </remarks>
        public bool Visible
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.VISIBLE).Get(out temp);
                return temp;
            }/* only get is required : removed
            set
            {
                SetProperty(View.Property.VISIBLE, new Tizen.NUI.PropertyValue(value));
            }*/
        }

        /// <summary>
        /// Gets the view's world color.
        /// </summary>
        public Vector4 WorldColor
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.WORLD_COLOR).Get(temp);
                return temp;
            }
        }

        internal Matrix WorldMatrix
        {
            get
            {
                Matrix temp = new Matrix();
                GetProperty(View.Property.WORLD_MATRIX).Get(temp);
                return temp;
            }
        }

        /// <summary>
        /// Gets/Sets the View's name.
        /// </summary>
        public string Name
        {
            get
            {
                string temp;
                GetProperty(View.Property.NAME).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.NAME, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Get the number of children held by the view.
        /// </summary>
        public uint ChildCount
        {
            get
            {
                return GetChildCount();
            }
        }

        /// <summary>
        /// Gets the View's ID.
        /// Readonly
        /// </summary>
        public uint ID
        {
            get
            {
                return GetId();
            }
        }

        /// <summary>
        /// Gets/Sets the status of whether an view should emit touch or hover signals.
        /// </summary>
        public bool Sensitive
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.SENSITIVE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.SENSITIVE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets/Sets the status of whether the view should receive a notification when touch or hover motion events leave the boundary of the view.
        /// </summary>
        public bool LeaveRequired
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.LEAVE_REQUIRED).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.LEAVE_REQUIRED, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets/Sets the status of whether a child view inherits it's parent's orientation.
        /// </summary>
        public bool InheritOrientation
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.INHERIT_ORIENTATION).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.INHERIT_ORIENTATION, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets/Sets the status of whether a child view inherits it's parent's scale.
        /// </summary>
        public bool InheritScale
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.INHERIT_SCALE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.INHERIT_SCALE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets/Sets the status of how the view and its children should be drawn.<br>
        /// Not all views are renderable, but DrawMode can be inherited from any view.<br>
        /// If an object is in a 3D layer, it will be depth-tested against other objects in the world i.e. it may be obscured if other objects are in front.<br>
        /// If DrawMode.Overlay2D is used, the view and its children will be drawn as a 2D overlay.<br>
        /// Overlay views are drawn in a separate pass, after all non-overlay views within the Layer.<br>
        /// For overlay views, the drawing order is with respect to tree levels of Views, and depth-testing will not be used.<br>
        /// </summary>
        public DrawModeType DrawMode
        {
            get
            {
                string temp;
                if (GetProperty(View.Property.DRAW_MODE).Get(out temp) == false)
                {
                    NUILog.Error("DrawMode get error!");
                }
                switch (temp)
                {
                    case "NORMAL":
                    return DrawModeType.Normal;
                    case "OVERLAY_2D":
                    return DrawModeType.Overlay2D;
                    case "STENCIL":
                    return DrawModeType.Stencil;
                    default:
                    return DrawModeType.Normal;
                }
            }
            set
            {
                SetProperty(View.Property.DRAW_MODE, new Tizen.NUI.PropertyValue((int)value));
            }
        }

        /// <summary>
        /// Gets/Sets the relative to parent size factor of the view.<br>
        /// This factor is only used when ResizePolicyType is set to either: ResizePolicyType.SizeRelativeToParent or ResizePolicyType.SizeFixedOffsetFromParent.<br>
        /// This view's size is set to the view's size multiplied by or added to this factor, depending on ResizePolicyType.<br>
        /// </summary>
        public Vector3 SizeModeFactor
        {
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.SIZE_MODE_FACTOR).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.SIZE_MODE_FACTOR, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets/Sets the width resize policy to be used.
        /// </summary>
        public ResizePolicyType WidthResizePolicy
        {
            get
            {
                string temp;
                if (GetProperty(View.Property.WIDTH_RESIZE_POLICY).Get(out temp) == false)
                {
                    NUILog.Error("WidthResizePolicy get error!");
                }
                switch (temp)
                {
                    case "FIXED":
                        return ResizePolicyType.Fixed;
                    case "USE_NATURAL_SIZE":
                        return ResizePolicyType.UseNaturalSize;
                    case "FILL_TO_PARENT":
                        return ResizePolicyType.FillToParent;
                    case "SIZE_RELATIVE_TO_PARENT":
                        return ResizePolicyType.SizeRelativeToParent;
                    case "SIZE_FIXED_OFFSET_FROM_PARENT":
                        return ResizePolicyType.SizeFixedOffsetFromParent;
                    case "FIT_TO_CHILDREN":
                        return ResizePolicyType.FitToChildren;
                    case "DIMENSION_DEPENDENCY":
                        return ResizePolicyType.DimensionDependency;
                    case "USE_ASSIGNED_SIZE":
                        return ResizePolicyType.UseAssignedSize;
                    default:
                        return ResizePolicyType.Fixed;
                }
            }
            set
            {
                SetProperty(View.Property.WIDTH_RESIZE_POLICY, new Tizen.NUI.PropertyValue((int)value));
            }
        }

        /// <summary>
        /// Gets/Sets the height resize policy to be used.
        /// </summary>
        public ResizePolicyType HeightResizePolicy
        {
            get
            {
                string temp;
                if (GetProperty(View.Property.HEIGHT_RESIZE_POLICY).Get(out temp) == false)
                {
                    NUILog.Error("HeightResizePolicy get error!");
                }
                switch (temp)
                {
                    case "FIXED":
                        return ResizePolicyType.Fixed;
                    case "USE_NATURAL_SIZE":
                        return ResizePolicyType.UseNaturalSize;
                    case "FILL_TO_PARENT":
                        return ResizePolicyType.FillToParent;
                    case "SIZE_RELATIVE_TO_PARENT":
                        return ResizePolicyType.SizeRelativeToParent;
                    case "SIZE_FIXED_OFFSET_FROM_PARENT":
                        return ResizePolicyType.SizeFixedOffsetFromParent;
                    case "FIT_TO_CHILDREN":
                        return ResizePolicyType.FitToChildren;
                    case "DIMENSION_DEPENDENCY":
                        return ResizePolicyType.DimensionDependency;
                    case "USE_ASSIGNED_SIZE":
                        return ResizePolicyType.UseAssignedSize;
                    default:
                        return ResizePolicyType.Fixed;
                }
            }
            set
            {
                SetProperty(View.Property.HEIGHT_RESIZE_POLICY, new Tizen.NUI.PropertyValue((int)value));
            }
        }

        /// <summary>
        /// Gets/Sets the policy to use when setting size with size negotiation.<br>
        /// Defaults to  SizeScalePolicyType.UseSizeSet.<br>
        /// </summary>
        public SizeScalePolicyType SizeScalePolicy
        {
            get
            {
                string temp;
                if (GetProperty(View.Property.SIZE_SCALE_POLICY).Get(out temp) == false)
                {
                    NUILog.Error("SizeScalePolicy get error!");
                }
                switch (temp)
                {
                    case "USE_SIZE_SET":
                        return SizeScalePolicyType.UseSizeSet;
                    case "FIT_WITH_ASPECT_RATIO":
                        return SizeScalePolicyType.FitWithAspectRatio;
                    case "FILL_WITH_ASPECT_RATIO":
                        return SizeScalePolicyType.FillWithAspectRatio;
                    default:
                        return SizeScalePolicyType.UseSizeSet;
                }
            }
            set
            {
                string valueToString = "";
                switch (value)
                {
                    case SizeScalePolicyType.UseSizeSet:
                        {
                            valueToString = "USE_SIZE_SET";
                            break;
                        }
                    case SizeScalePolicyType.FitWithAspectRatio:
                        {
                            valueToString = "FIT_WITH_ASPECT_RATIO";
                            break;
                        }
                    case SizeScalePolicyType.FillWithAspectRatio:
                        {
                            valueToString = "FILL_WITH_ASPECT_RATIO";
                            break;
                        }
                    default:
                        {
                            valueToString = "USE_SIZE_SET";
                            break;
                        }
                }
                SetProperty(View.Property.SIZE_SCALE_POLICY, new Tizen.NUI.PropertyValue(valueToString));
            }
        }

        /// <summary>
        ///  Gets/Sets the status of whether the width size is dependent on height size.
        /// </summary>
        public bool WidthForHeight
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.WIDTH_FOR_HEIGHT).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.WIDTH_FOR_HEIGHT, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        ///  Gets/Sets the status of whether the height size is dependent on width size.
        /// </summary>
        public bool HeightForWidth
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.HEIGHT_FOR_WIDTH).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.HEIGHT_FOR_WIDTH, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets/Sets the padding for use in layout.
        /// </summary>
        public Vector4 Padding
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.PADDING).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.PADDING, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets/Sets the minimum size an view can be assigned in size negotiation.
        /// </summary>
        public Size2D MinimumSize
        {
            get
            {
                Size2D temp = new Size2D(0, 0);
                GetProperty(View.Property.MINIMUM_SIZE).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.MINIMUM_SIZE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets/Sets the maximum size an view can be assigned in size negotiation.
        /// </summary>
        public Size2D MaximumSize
        {
            get
            {
                Size2D temp = new Size2D(0, 0);
                GetProperty(View.Property.MAXIMUM_SIZE).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.MAXIMUM_SIZE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets/Sets whether a child view inherits it's parent's position.<br>
        /// Default is to inherit.<br>
        /// Switching this off means that using Position sets the view's world position, i.e. translates from the world origin(0,0,0) to the pivot point of the view.<br>
        /// </summary>
        public bool InheritPosition
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.INHERIT_POSITION).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.INHERIT_POSITION, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Gets/Sets clipping behavior(mode) of it's children.
        /// </summary>
        public ClippingModeType ClippingMode
        {
            get
            {
                string temp;
                if (GetProperty(View.Property.CLIPPING_MODE).Get(out temp) == false)
                {
                    NUILog.Error("ClippingMode get error!");
                }
                switch (temp)
                {
                    case "DISABLED":
                    return ClippingModeType.Disabled;
                    case "CLIP_CHILDREN":
                    return ClippingModeType.ClipChildren;
                    default:
                    return ClippingModeType.Disabled;
                }
            }
            set
            {
                SetProperty(View.Property.CLIPPING_MODE, new Tizen.NUI.PropertyValue((int)value));
            }
        }

        /// <summary>
        /// Get the number of renderers held by the view.
        /// </summary>
        public uint RendererCount
        {
            get
            {
                return GetRendererCount();
            }
        }
    }
}
