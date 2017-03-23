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

namespace Tizen.NUI
{

    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// View is the base class for all views.
    /// </summary>
    public class View : CustomActor
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal View(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.View_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);

            // Register this instance of view in the view registry.
            ViewRegistry.RegisterView(this);

            // By default, we do not want the position to use the anchor point
            //this.PositionUsesAnchorPoint = false;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(View obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        ~View()
        {
            DisposeQueue.Instance.Add(this);

            // Unregister this instance of view from the view registry.
            ViewRegistry.UnregisterView(this);
        }

        public override void Dispose()
        {
            if (!Stage.IsInstalled())
            {
                DisposeQueue.Instance.Add(this);
                return;
            }

            lock (this)
            {
                if (swigCPtr.Handle != global::System.IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        NDalicPINVOKE.delete_View(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }
                global::System.GC.SuppressFinalize(this);
                base.Dispose();
            }
        }



        private EventHandler _keyInputFocusGainedEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void KeyInputFocusGainedCallbackType(IntPtr control);
        private KeyInputFocusGainedCallbackType _keyInputFocusGainedCallback;

        /**
          * @brief Event for KeyInputFocusGained signal which can be used to subscribe/unsubscribe the event handler
          * provided by the user. KeyInputFocusGained signal is emitted when the control gets Key Input Focus.
          */
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

                if (_keyInputFocusGainedEventHandler == null && _keyInputFocusGainedCallback != null)
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

        /**
          * @brief Event for KeyInputFocusLost signal which can be used to subscribe/unsubscribe the event handler
          * provided by the user. KeyInputFocusLost signal is emitted when the control loses Key Input Focus.
          */
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

                if (_keyInputFocusLostEventHandler == null && _keyInputFocusLostCallback != null)
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


        /**
          * @brief Event arguments that passed via KeyEvent signal
          *
          */
        public class KeyEventArgs : EventArgs
        {
            private Key _key;

            /**
              * @brief KeyEvent - is the keyevent sent to the View.
              *
              */
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

        /**
          * @brief Event for KeyPressed signal which can be used to subscribe/unsubscribe the event handler
          * provided by the user. KeyPressed signal is emitted when key event is received.
          */
        public event EventHandlerWithReturnType<object, KeyEventArgs, bool> KeyEvent
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

                if (_keyEventHandler == null && _keyCallback != null)
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

        /**
          * @brief Event for OnRelayout signal which can be used to subscribe/unsubscribe the event handler
          * OnRelayout signal is emitted after the size has been set on the view during relayout.
          */
        public event EventHandler OnRelayoutEvent
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

                if (_onRelayoutEventHandler == null && _onRelayoutEventCallback != null)
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


        /**
          * @brief Event arguments that passed via Touch signal
          *
          */
        public class TouchEventArgs : EventArgs
        {
            private Touch _touch;

            /**
              * @brief TouchData - contains the information of touch points
              *
              */
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

        private EventHandlerWithReturnType<object, TouchEventArgs, bool> _touchDataEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool TouchDataCallbackType(IntPtr view, IntPtr touchData);
        private TouchDataCallbackType _touchDataCallback;

        /**
          * @brief Event for Touched signal which can be used to subscribe/unsubscribe the event handler
          * provided by the user. Touched signal is emitted when touch input is received.
          */
        public event EventHandlerWithReturnType<object, TouchEventArgs, bool> Touched
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

                if (_touchDataEventHandler == null && _touchDataCallback != null)
                {
                    this.TouchSignal().Disconnect(_touchDataCallback);
                }

            }
        }

        // Callback for View TouchSignal
        private bool OnTouch(IntPtr view, IntPtr touchData)
        {
            TouchEventArgs e = new TouchEventArgs();

            e.Touch = Tizen.NUI.Touch.GetTouchFromPtr(touchData);

            if (_touchDataEventHandler != null)
            {
                return _touchDataEventHandler(this, e);
            }
            return false;
        }


        /**
          * @brief Event arguments that passed via Hover signal
          *
          */
        public class HoverEventArgs : EventArgs
        {
            private Hover _hover;
            /**
              * @brief HoverEvent - contains touch points that represent the points
              * that are currently being hovered or the points where a hover has stopped
              *
              */
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

        private EventHandlerWithReturnType<object, HoverEventArgs, bool> _hoverEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool HoverEventCallbackType(IntPtr view, IntPtr hoverEvent);
        private HoverEventCallbackType _hoverEventCallback;

        /**
          * @brief Event for Hovered signal which can be used to subscribe/unsubscribe the event handler
          * provided by the user. Hovered signal is emitted when hover input is received.
          */
        public event EventHandlerWithReturnType<object, HoverEventArgs, bool> Hovered
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

                if (_hoverEventHandler == null && _hoverEventCallback != null)
                {
                    this.HoveredSignal().Disconnect(_hoverEventCallback);
                }

            }
        }

        // Callback for View Hover signal
        private bool OnHoverEvent(IntPtr view, IntPtr hoverEvent)
        {
            HoverEventArgs e = new HoverEventArgs();

            e.Hover = Tizen.NUI.Hover.GetHoverFromPtr(hoverEvent);

            if (_hoverEventHandler != null)
            {
                return _hoverEventHandler(this, e);
            }
            return false;
        }


        /**
          * @brief Event arguments that passed via Wheel signal
          *
          */
        public class WheelEventArgs : EventArgs
        {
            private Wheel _wheel;
            /**
              * @brief WheelEvent - store a wheel rolling type : MOUSE_WHEEL or CUSTOM_WHEEL
              *
              */
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

        private EventHandlerWithReturnType<object, WheelEventArgs, bool> _wheelEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool WheelEventCallbackType(IntPtr view, IntPtr wheelEvent);
        private WheelEventCallbackType _wheelEventCallback;

        /**
          * @brief Event for WheelMoved signal which can be used to subscribe/unsubscribe the event handler
          * provided by the user. WheelMoved signal is emitted when wheel event is received.
          */
        public event EventHandlerWithReturnType<object, WheelEventArgs, bool> WheelMoved
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

                if (_wheelEventHandler == null && _wheelEventCallback != null)
                {
                    this.WheelEventSignal().Disconnect(_wheelEventCallback);
                }

            }
        }

        // Callback for View Wheel signal
        private bool OnWheelEvent(IntPtr view, IntPtr wheelEvent)
        {
            WheelEventArgs e = new WheelEventArgs();

            e.Wheel = Tizen.NUI.Wheel.GetWheelFromPtr(wheelEvent);

            if (_wheelEventHandler != null)
            {
                return _wheelEventHandler(this, e);
            }
            return false;
        }


        private EventHandler _onStageEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void OnStageEventCallbackType(IntPtr control);
        private OnStageEventCallbackType _onStageEventCallback;

        /**
          * @brief Event for OnStage signal which can be used to subscribe/unsubscribe the event handler
          * OnStage signal is emitted after the view has been connected to the stage.
          */
        public event EventHandler OnStageEvent
        {
            add
            {
                if (_onStageEventHandler == null)
                {
                    _onStageEventCallback = OnStage;
                    this.OnStageSignal().Connect(_onStageEventCallback);
                }

                _onStageEventHandler += value;
            }

            remove
            {
                _onStageEventHandler -= value;

                if (_onStageEventHandler == null && _onStageEventCallback != null)
                {
                    this.OnStageSignal().Disconnect(_onStageEventCallback);
                }
            }
        }

        // Callback for View OnStage signal
        private void OnStage(IntPtr data)
        {
            if (_onStageEventHandler != null)
            {
                _onStageEventHandler(this, null);
            }
        }


        private EventHandler _offStageEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void OffStageEventCallbackType(IntPtr control);
        private OffStageEventCallbackType _offStageEventCallback;

        /**
          * @brief Event for OffStage signal which can be used to subscribe/unsubscribe the event handler
          * OffStage signal is emitted after the view has been disconnected from the stage.
          */
        public event EventHandler OffStageEvent
        {
            add
            {
                if (_offStageEventHandler == null)
                {
                    _offStageEventCallback = OffStage;
                    this.OnStageSignal().Connect(_offStageEventCallback);
                }

                _offStageEventHandler += value;
            }

            remove
            {
                _offStageEventHandler -= value;

                if (_offStageEventHandler == null && _offStageEventCallback != null)
                {
                    this.OnStageSignal().Disconnect(_offStageEventCallback);
                }
            }
        }

        // Callback for View OffStage signal
        private void OffStage(IntPtr data)
        {
            if (_offStageEventHandler != null)
            {
                _offStageEventHandler(this, null);
            }
        }






        internal static View GetViewFromPtr(global::System.IntPtr cPtr)
        {
            View ret = new View(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal class Property : global::System.IDisposable
        {
            private global::System.Runtime.InteropServices.HandleRef swigCPtr;
            protected bool swigCMemOwn;

            internal Property(global::System.IntPtr cPtr, bool cMemoryOwn)
            {
                swigCMemOwn = cMemoryOwn;
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            }

            internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Property obj)
            {
                return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
            }

            ~Property()
            {
                Dispose();
            }

            public virtual void Dispose()
            {
                lock (this)
                {
                    if (swigCPtr.Handle != global::System.IntPtr.Zero)
                    {
                        if (swigCMemOwn)
                        {
                            swigCMemOwn = false;
                            NDalicPINVOKE.delete_View_Property(swigCPtr);
                        }
                        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                    }
                    global::System.GC.SuppressFinalize(this);
                }
            }

            internal static readonly int TOOLTIP = NDalicManualPINVOKE.View_Property_TOOLTIP_get();
            internal static readonly int STATE = NDalicManualPINVOKE.View_Property_STATE_get();
            internal static readonly int SUB_STATE = NDalicManualPINVOKE.View_Property_SUB_STATE_get();
            internal static readonly int LEFT_FOCUSABLE_ACTOR_ID = NDalicManualPINVOKE.View_Property_LEFT_FOCUSABLE_ACTOR_ID_get();
            internal static readonly int RIGHT_FOCUSABLE_ACTOR_ID = NDalicManualPINVOKE.View_Property_RIGHT_FOCUSABLE_ACTOR_ID_get();
            internal static readonly int UP_FOCUSABLE_ACTOR_ID = NDalicManualPINVOKE.View_Property_UP_FOCUSABLE_ACTOR_ID_get();
            internal static readonly int DOWN_FOCUSABLE_ACTOR_ID = NDalicManualPINVOKE.View_Property_DOWN_FOCUSABLE_ACTOR_ID_get();

            internal Property() : this(NDalicPINVOKE.new_View_Property(), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            internal static readonly int STYLE_NAME = NDalicPINVOKE.View_Property_STYLE_NAME_get();
            internal static readonly int BACKGROUND_COLOR = NDalicPINVOKE.View_Property_BACKGROUND_COLOR_get();
            internal static readonly int BACKGROUND_IMAGE = NDalicPINVOKE.View_Property_BACKGROUND_IMAGE_get();
            internal static readonly int KEY_INPUT_FOCUS = NDalicPINVOKE.View_Property_KEY_INPUT_FOCUS_get();
            internal static readonly int BACKGROUND = NDalicPINVOKE.View_Property_BACKGROUND_get();

        }


        /// <summary>
        /// Describes the direction to move the keyboard focus towards.
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

        internal View Assign(View handle)
        {
            View ret = new View(NDalicPINVOKE.View_Assign(swigCPtr, View.getCPtr(handle)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Downcasts a handle to View handle.
        /// If handle points to a View, the downcast produces valid handle.
        /// If not, the returned handle is left uninitialized.
        /// </summary>
        /// <param name="handle">Handle to an object</param>
        /// <returns>A handle to a View or an uninitialized handle</returns>
        public new static View DownCast(BaseHandle handle)
        {
            View ret = new View(NDalicPINVOKE.View_DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Downcasts a handle to class which inherit View handle.
        /// </summary>
        /// <typeparam name="T">Class which inherit View</typeparam>
        /// <param name="actor">Actor to an object</param>
        /// <returns>A object which inherit View</returns>
        public static T DownCast<T>(Actor actor) where T : View
        {
            return (T)(ViewRegistry.GetViewFromActor(actor));
        }

        private View ConvertIdToView(uint id)
        {
            Actor actor = null;

            if (Parent)
            {
                actor = Parent.FindChildById(id);
            }

            if (!actor)
            {
                actor = Stage.Instance.GetRootLayer().FindChildById(id);
            }

            return View.DownCast<View>(actor);
        }

        internal void SetKeyInputFocus()
        {
            NDalicPINVOKE.View_SetKeyInputFocus(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Quries whether the view has key input focus.
        /// </summary>
        /// <returns>true if this view has keyboard input focus</returns>
        public bool HasKeyInputFocus()
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
                background.Find(Visual.Property.Type).Get(ref visualType);
                if (visualType == (int)Visual.Type.Color)
                {
                    background.Find(ColorVisualProperty.MixColor).Get(backgroundColor);
                }

                return backgroundColor;
            }
            set
            {
                SetProperty(View.Property.BACKGROUND, new Tizen.NUI.PropertyValue(value));
            }
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
                background.Find(Visual.Property.Type).Get(ref visualType);
                if (visualType == (int)Visual.Type.Image)
                {
                    background.Find(ImageVisualProperty.URL).Get(out backgroundImage);
                }

                return backgroundImage;
            }
            set
            {
                SetProperty(View.Property.BACKGROUND, new Tizen.NUI.PropertyValue(value));
            }
        }

        internal bool KeyInputFocus
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.KEY_INPUT_FOCUS).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.KEY_INPUT_FOCUS, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// mutually exclusive with BACKGROUND_COLOR & BACKGROUND_IMAGE, type Map or string for URL.
        /// </summary>
        public Tizen.NUI.PropertyMap Background
        {
            get
            {
                Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
                GetProperty(View.Property.BACKGROUND).Get(temp);
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
        public string State
        {
            get
            {
                string temp;
                GetProperty(View.Property.STATE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.STATE, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The current sub state of the view.
        /// </summary>
        public string SubState
        {
            get
            {
                string temp;
                GetProperty(View.Property.SUB_STATE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.SUB_STATE, new Tizen.NUI.PropertyValue(value));
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

        private int LeftFocusableActorId
        {
            get
            {
                int temp = 0;
                GetProperty(View.Property.LEFT_FOCUSABLE_ACTOR_ID).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.LEFT_FOCUSABLE_ACTOR_ID, new Tizen.NUI.PropertyValue(value));
            }
        }

        private int RightFocusableActorId
        {
            get
            {
                int temp = 0;
                GetProperty(View.Property.RIGHT_FOCUSABLE_ACTOR_ID).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.RIGHT_FOCUSABLE_ACTOR_ID, new Tizen.NUI.PropertyValue(value));
            }
        }

        private int UpFocusableActorId
        {
            get
            {
                int temp = 0;
                GetProperty(View.Property.UP_FOCUSABLE_ACTOR_ID).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.UP_FOCUSABLE_ACTOR_ID, new Tizen.NUI.PropertyValue(value));
            }
        }

        private int DownFocusableActorId
        {
            get
            {
                int temp = 0;
                GetProperty(View.Property.DOWN_FOCUSABLE_ACTOR_ID).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.DOWN_FOCUSABLE_ACTOR_ID, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Child Property of FlexContainer
        /// The proportion of the free space in the container the flex item will receive. 
        /// If all items in the container set this property, their sizes will be proportional to the specified flex factor
        /// </summary> 
        public float Flex
        {
            get
            {
                float temp = 0.0f;
                GetProperty(FlexContainer.ChildProperty.FLEX).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(FlexContainer.ChildProperty.FLEX, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Child Property of FlexContainer
        /// The alignment of the flex item along the cross axis, which, if set, overides the default alignment for all items in the container
        /// </summary> 
        public int AlignSelf
        {
            get
            {
                int temp = 0;
                GetProperty(FlexContainer.ChildProperty.ALIGN_SELF).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(FlexContainer.ChildProperty.ALIGN_SELF, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Child Property of FlexContainer
        /// The space around the flex item
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
                GetProperty(TableView.ChildProperty.ROW_SPAN).Get(ref temp);
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
                GetProperty(TableView.ChildProperty.COLUMN_SPAN).Get(ref temp);
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
        public string CellHorizontalAlignment
        {
            get
            {
                string temp;
                GetProperty(TableView.ChildProperty.CELL_HORIZONTAL_ALIGNMENT).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TableView.ChildProperty.CELL_HORIZONTAL_ALIGNMENT, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The vertical alignment of this child inside the cells, if not set, default value is 'top'
        /// </summary>
        public string CellVerticalAlignment
        {
            get
            {
                string temp;
                GetProperty(TableView.ChildProperty.CELL_VERTICAL_ALIGNMENT).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TableView.ChildProperty.CELL_VERTICAL_ALIGNMENT, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// The left focusable view.
        /// This will return NULL if not set.
        /// This will also return NULL if the specified left focusable view is not on stage.
        /// </summary>
        public View LeftFocusableView
        {
            // As native side will be only storing IDs so need a logic to convert View to ID and vice-versa.
            get
            {
                if (LeftFocusableActorId >= 0)
                {
                    return ConvertIdToView((uint)LeftFocusableActorId);
                }
                return null;
            }
            set
            {
                LeftFocusableActorId = (int)value.GetId();
            }
        }

        /// <summary>
        /// The right focusable view.
        /// This will return NULL if not set.
        /// This will also return NULL if the specified right focusable view is not on stage.
        /// </summary>
        public View RightFocusableView
        {
            // As native side will be only storing IDs so need a logic to convert View to ID and vice-versa.
            get
            {
                if (RightFocusableActorId >= 0)
                {
                    return ConvertIdToView((uint)RightFocusableActorId);
                }
                return null;
            }
            set
            {
                RightFocusableActorId = (int)value.GetId();
            }
        }

        /// <summary>
        /// The up focusable view.
        /// This will return NULL if not set.
        /// This will also return NULL if the specified up focusable view is not on stage.
        /// </summary>
        public View UpFocusableView
        {
            // As native side will be only storing IDs so need a logic to convert View to ID and vice-versa.
            get
            {
                if (UpFocusableActorId >= 0)
                {
                    return ConvertIdToView((uint)UpFocusableActorId);
                }
                return null;
            }
            set
            {
                UpFocusableActorId = (int)value.GetId();
            }
        }

        /// <summary>
        /// The down focusable view.
        /// This will return NULL if not set.
        /// This will also return NULL if the specified down focusable view is not on stage.
        /// </summary>
        public View DownFocusableView
        {
            // As native side will be only storing IDs so need a logic to convert View to ID and vice-versa.
            get
            {
                if (DownFocusableActorId >= 0)
                {
                    return ConvertIdToView((uint)DownFocusableActorId);
                }
                return null;
            }
            set
            {
                DownFocusableActorId = (int)value.GetId();
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

    }

}
