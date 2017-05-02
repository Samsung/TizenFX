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

namespace Dali
{
    using System;
    using System.Runtime.InteropServices;

    public class View : Animatable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal View(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.View_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);

            // Register this instance of view in the view registry.
            ViewRegistry.RegisterView(this);

            // By default, we do not want the position to use the anchor point
            this.PositionUsesAnchorPoint = false;
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

        public virtual void Dispose()
        {
            if (!Window.IsInstalled())
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
            }
        }

        /**
         * @brief Event arguments that passed via KeyInputFocusGained signal
         *
         */
        public class KeyInputFocusGainedEventArgs : EventArgs
        {
            private View _view;

            /**
             * @brief View - is the view that gets Key Input Focus
             *
             */
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
        }

        /**
         * @brief Event arguments that passed via KeyInputFocusLost signal
         *
         */
        public class KeyInputFocusLostEventArgs : EventArgs
        {
            private View _view;

            /**
             * @brief View - is the view that loses Key Input Focus
             *
             */
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
        }

        /**
         * @brief Event arguments that passed via Key signal
         *
         */
        public class KeyEventArgs : EventArgs
        {
            private View _view;
            private Key _key;

            /**
             * @brief View - is the view that recieves the key.
             *
             */
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

            /**
             * @brief Key - is the key sent to the View.
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

        /**
         * @brief Event arguments that passed via OnRelayout signal
         *
         */
        public class OnRelayoutEventArgs : EventArgs
        {
            private View _view;

            /**
             * @brief View - is the view that is being resized upon relayout
             *
             */
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
        }


        /**
         * @brief Event arguments that passed via Touch signal
         *
         */
        public class TouchEventArgs : EventArgs
        {
            private View _view;
            private Touch _touch;

            /**
             * @brief View - is the view that is being touched
             *
             */
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

            /**
             * @brief Touch - contains the information of touch points
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

        /**
         * @brief Event arguments that passed via Hover signal
         *
         */
        public class HoverEventArgs : EventArgs
        {
            private View _view;
            private Hover _hover;

            /**
             * @brief View - is the view that is being hovered
             *
             */
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

            /**
             * @brief Hover - contains touch points that represent the points
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

        /**
         * @brief Event arguments that passed via Wheel signal
         *
         */
        public class WheelEventArgs : EventArgs
        {
            private View _view;
            private Wheel _wheel;

            /**
             * @brief View - is the view that is being wheeled
             *
             */
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

            /**
             * @brief Wheel - store a wheel rolling type : MOUSE_WHEEL or CUSTOM_WHEEL
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

        /**
         * @brief Event arguments that passed via OnWindow signal
         *
         */
        public class OnWindowEventArgs : EventArgs
        {
            private View _view;

            /**
             * @brief View - is the view that is being connected to the window
             *
             */
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
        }

        /**
         * @brief Event arguments that passed via OffWindow signal
         *
         */
        public class OffWindowEventArgs : EventArgs
        {
            private View _view;

            /**
             * @brief View - is the view that is being disconnected from the window
             *
             */
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
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void KeyInputFocusGainedCallbackDelegate(IntPtr control);

        private DaliEventHandler<object,KeyInputFocusGainedEventArgs> _KeyInputFocusGainedEventHandler;
        private KeyInputFocusGainedCallbackDelegate _KeyInputFocusGainedCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void KeyInputFocusLostCallbackDelegate(IntPtr control);

        private DaliEventHandler<object,KeyInputFocusLostEventArgs> _KeyInputFocusLostEventHandler;
        private KeyInputFocusLostCallbackDelegate _KeyInputFocusLostCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool KeyCallbackDelegate(IntPtr control, IntPtr key);

        private DaliEventHandlerWithReturnType<object,KeyEventArgs,bool> _KeyHandler;
        private KeyCallbackDelegate _KeyCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void OnRelayoutEventCallbackDelegate(IntPtr control);

        private DaliEventHandler<object,OnRelayoutEventArgs> _viewOnRelayoutEventHandler;
        private OnRelayoutEventCallbackDelegate _viewOnRelayoutEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool TouchCallbackDelegate(IntPtr view, IntPtr touch);

        private DaliEventHandlerWithReturnType<object,TouchEventArgs,bool> _viewTouchHandler;
        private TouchCallbackDelegate _viewTouchCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool HoverCallbackDelegate(IntPtr view, IntPtr hover);

        private DaliEventHandlerWithReturnType<object,HoverEventArgs,bool> _viewHoverHandler;
        private HoverCallbackDelegate _viewHoverCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool WheelCallbackDelegate(IntPtr view, IntPtr wheel);

        private DaliEventHandlerWithReturnType<object,WheelEventArgs,bool> _viewWheelHandler;
        private WheelCallbackDelegate _viewWheelCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void OnWindowEventCallbackDelegate(IntPtr control);

        private DaliEventHandler<object,OnWindowEventArgs> _viewOnWindowEventHandler;
        private OnWindowEventCallbackDelegate _viewOnWindowEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void OffWindowEventCallbackDelegate(IntPtr control);

        private DaliEventHandler<object,OffWindowEventArgs> _viewOffWindowEventHandler;
        private OffWindowEventCallbackDelegate _viewOffWindowEventCallbackDelegate;

        /**
         * @brief Event for KeyInputFocusGained signal which can be used to subscribe/unsubscribe the event handler
         * (in the type of KeyInputFocusGainedEventHandler-DaliEventHandler<object,KeyInputFocusGainedEventArgs>)
         * provided by the user. KeyInputFocusGained signal is emitted when the control gets Key Input Focus.
         */
        public event DaliEventHandler<object,KeyInputFocusGainedEventArgs> KeyInputFocusGained
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_KeyInputFocusGainedEventHandler == null)
                    {
                        _KeyInputFocusGainedEventHandler += value;
                        Console.WriteLine("View Key EVENT Locked....");
                        _KeyInputFocusGainedCallbackDelegate = new KeyInputFocusGainedCallbackDelegate(OnKeyInputFocusGained);
                        this.KeyInputFocusGainedSignal().Connect(_KeyInputFocusGainedCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_KeyInputFocusGainedEventHandler != null)
                    {
                        this.KeyInputFocusGainedSignal().Disconnect(_KeyInputFocusGainedCallbackDelegate);
                    }

                    _KeyInputFocusGainedEventHandler -= value;
                }
            }
        }

        private void OnKeyInputFocusGained(IntPtr view)
        {
            KeyInputFocusGainedEventArgs e = new KeyInputFocusGainedEventArgs();
            Console.WriteLine("View Key ....");
            // Populate all members of "e" (KeyInputFocusGainedEventArgs) with real data
            e.View = Dali.View.GetViewFromPtr(view);

            if (_KeyInputFocusGainedEventHandler != null)
            {
                //here we send all data to user event handlers
                _KeyInputFocusGainedEventHandler(this, e);
            }

        }

        /**
         * @brief Event for KeyInputFocusLost signal which can be used to subscribe/unsubscribe the event handler
         * (in the type of KeyInputFocusLostEventHandler-DaliEventHandler<object,KeyInputFocusLostEventArgs>)
         * provided by the user. KeyInputFocusLost signal is emitted when the control loses Key Input Focus.
         */
        public event DaliEventHandler<object,KeyInputFocusLostEventArgs> KeyInputFocusLost
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_KeyInputFocusLostEventHandler == null)
                    {
                        _KeyInputFocusLostEventHandler += value;

                        _KeyInputFocusLostCallbackDelegate = new KeyInputFocusLostCallbackDelegate(OnKeyInputFocusLost);
                        this.KeyInputFocusLostSignal().Connect(_KeyInputFocusLostCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_KeyInputFocusLostEventHandler != null)
                    {
                        this.KeyInputFocusLostSignal().Disconnect(_KeyInputFocusLostCallbackDelegate);
                    }

                    _KeyInputFocusLostEventHandler -= value;
                }
            }
        }

        private void OnKeyInputFocusLost(IntPtr view)
        {
            KeyInputFocusLostEventArgs e = new KeyInputFocusLostEventArgs();

            // Populate all members of "e" (KeyInputFocusLostEventArgs) with real data
            e.View = Dali.View.GetViewFromPtr(view);

            if (_KeyInputFocusLostEventHandler != null)
            {
                //here we send all data to user event handlers
                _KeyInputFocusLostEventHandler(this, e);
            }
        }

        /**
         * @brief Event for KeyPressed signal which can be used to subscribe/unsubscribe the event handler
         * (in the type of KeyHandler-DaliEventHandlerWithReturnType<object,KeyEventArgs,bool>)
         * provided by the user. KeyPressed signal is emitted when key event is received.
         */
        public event DaliEventHandlerWithReturnType<object,KeyEventArgs,bool> KeyPressed
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_KeyHandler == null)
                    {
                        _KeyHandler += value;

                        _KeyCallbackDelegate = new KeyCallbackDelegate(OnKey);
                        this.KeyEventSignal().Connect(_KeyCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_KeyHandler != null)
                    {
                        this.KeyEventSignal().Disconnect(_KeyCallbackDelegate);
                    }

                    _KeyHandler -= value;
                }
            }
        }

        private bool OnKey(IntPtr view, IntPtr key)
        {
            KeyEventArgs e = new KeyEventArgs();

            // Populate all members of "e" (KeyEventArgs) with real data
            e.View = Dali.View.GetViewFromPtr(view);
            e.Key = Dali.Key.GetKeyFromPtr(key);

            if (_KeyHandler != null)
            {
                //here we send all data to user event handlers
                return _KeyHandler(this, e);
            }
            return false;

        }

        /**
         * @brief Event for OnRelayout signal which can be used to subscribe/unsubscribe the event handler
         * (in the type of OnRelayoutEventHandler) provided by the user.
         * OnRelayout signal is emitted after the size has been set on the view during relayout.
         */
        public event DaliEventHandler<object,OnRelayoutEventArgs> OnRelayoutEvent
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_viewOnRelayoutEventHandler == null)
                    {
                        _viewOnRelayoutEventHandler += value;
                        Console.WriteLine("View OnRelayoutEventArgs Locked....");
                        _viewOnRelayoutEventCallbackDelegate = new OnRelayoutEventCallbackDelegate(OnRelayout);
                        this.OnRelayoutSignal().Connect(_viewOnRelayoutEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_viewOnRelayoutEventHandler != null)
                    {
                        this.OnRelayoutSignal().Disconnect(_viewOnRelayoutEventCallbackDelegate);
                    }

                    _viewOnRelayoutEventHandler -= value;
                }
            }
        }

        // Callback for View OnRelayout signal
        private void OnRelayout(IntPtr data)
        {
            OnRelayoutEventArgs e = new OnRelayoutEventArgs();
            Console.WriteLine("View OnRelayoutEventArgs....");
            // Populate all members of "e" (OnRelayoutEventArgs) with real data
            e.View = View.GetViewFromPtr(data);

            if (_viewOnRelayoutEventHandler != null)
            {
                //here we send all data to user event handlers
                _viewOnRelayoutEventHandler(this, e);
            }
        }

        /**
         * @brief Event for Touched signal which can be used to subscribe/unsubscribe the event handler
         * (in the type of TouchHandler-DaliEventHandlerWithReturnType<object,TouchEventArgs,bool>)
         * provided by the user. Touched signal is emitted when touch input is received.
         */
        public event DaliEventHandlerWithReturnType<object,TouchEventArgs,bool> Touched
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_viewTouchHandler == null)
                    {
                        _viewTouchHandler += value;
                        Console.WriteLine("View Touch EVENT LOCKED....");
                        _viewTouchCallbackDelegate = new TouchCallbackDelegate(OnTouch);
                        this.TouchSignal().Connect(_viewTouchCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_viewTouchHandler != null)
                    {
                        this.TouchSignal().Disconnect(_viewTouchCallbackDelegate);
                    }

                    _viewTouchHandler -= value;
                }
            }
        }

        // Callback for View TouchSignal
        private bool OnTouch(IntPtr view, IntPtr touch)
        {
            TouchEventArgs e = new TouchEventArgs();
            Console.WriteLine("View Touch EVENT....");
            // Populate all members of "e" (TouchEventArgs) with real data
            e.View = View.GetViewFromPtr(view);
            e.Touch = Dali.Touch.GetTouchFromPtr(touch);

            if (_viewTouchHandler != null)
            {
                //here we send all data to user event handlers
                return _viewTouchHandler(this, e);
            }

            return false;
        }

        /**
         * @brief Event for Hovered signal which can be used to subscribe/unsubscribe the event handler
         * (in the type of HoverHandler-DaliEventHandlerWithReturnType<object,HoverEventArgs,bool>)
         * provided by the user. Hovered signal is emitted when hover input is received.
         */
        public event DaliEventHandlerWithReturnType<object,HoverEventArgs,bool> Hovered
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_viewHoverHandler == null)
                    {
                        _viewHoverHandler += value;

                        _viewHoverCallbackDelegate = new HoverCallbackDelegate(OnHover);
                        this.HoveredSignal().Connect(_viewHoverCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_viewHoverHandler != null)
                    {
                        this.HoveredSignal().Disconnect(_viewHoverCallbackDelegate);
                    }

                    _viewHoverHandler -= value;
                }
            }
        }

        // Callback for View Hover signal
        private bool OnHover(IntPtr view, IntPtr hover)
        {
            HoverEventArgs e = new HoverEventArgs();

            // Populate all members of "e" (HoverEventArgs) with real data
            e.View = View.GetViewFromPtr(view);
            e.Hover = Dali.Hover.GetHoverFromPtr(hover);

            if (_viewHoverHandler != null)
            {
                //here we send all data to user event handlers
                return _viewHoverHandler(this, e);
            }

            return false;
        }

        /**
         * @brief Event for WheelMoved signal which can be used to subscribe/unsubscribe the event handler
         * (in the type of WheelHandler-DaliEventHandlerWithReturnType<object,WheelEventArgs,bool>)
         * provided by the user. WheelMoved signal is emitted when wheel event is received.
         */
        public event DaliEventHandlerWithReturnType<object,WheelEventArgs,bool> WheelMoved
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_viewWheelHandler == null)
                    {
                        _viewWheelHandler += value;
                        Console.WriteLine("View Wheel EVENT LOCKED....");
                        _viewWheelCallbackDelegate = new WheelCallbackDelegate(OnWheel);
                        this.WheelEventSignal().Connect(_viewWheelCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_viewWheelHandler != null)
                    {
                        this.WheelEventSignal().Disconnect(_viewWheelCallbackDelegate);
                    }

                    _viewWheelHandler -= value;
                }
            }
        }

        // Callback for View Wheel signal
        private bool OnWheel(IntPtr view, IntPtr wheel)
        {
            WheelEventArgs e = new WheelEventArgs();
            Console.WriteLine("View Wheel EVENT ....");
            // Populate all members of "e" (WheelEventArgs) with real data
            e.View = View.GetViewFromPtr(view);
            e.Wheel = Dali.Wheel.GetWheelFromPtr(wheel);

            if (_viewWheelHandler != null)
            {
                //here we send all data to user event handlers
                return _viewWheelHandler(this, e);
            }

            return false;
        }

        /**
         * @brief Event for OnWindow signal which can be used to subscribe/unsubscribe the event handler
         * (in the type of OnWindowEventHandler) provided by the user.
         * OnWindow signal is emitted after the view has been connected to the window.
         */
        public event DaliEventHandler<object,OnWindowEventArgs> OnWindowEvent
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_viewOnWindowEventHandler == null)
                    {
                        _viewOnWindowEventHandler += value;

                        _viewOnWindowEventCallbackDelegate = new OnWindowEventCallbackDelegate(OnWindow);
                        this.OnWindowSignal().Connect(_viewOnWindowEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_viewOnWindowEventHandler != null)
                    {
                        this.OnWindowSignal().Disconnect(_viewOnWindowEventCallbackDelegate);
                    }

                    _viewOnWindowEventHandler -= value;
                }
            }
        }

        // Callback for View OnWindow signal
        private void OnWindow(IntPtr data)
        {
            OnWindowEventArgs e = new OnWindowEventArgs();

            // Populate all members of "e" (OnWindowEventArgs) with real data
            e.View = View.GetViewFromPtr(data);

            //Console.WriteLine("############# OnWindow()! e.View.Name=" + e.View.Name);

            if (_viewOnWindowEventHandler != null)
            {
                //here we send all data to user event handlers
                _viewOnWindowEventHandler(this, e);
            }
        }

        /**
         * @brief Event for OffWindow signal which can be used to subscribe/unsubscribe the event handler
         * (in the type of OffWindowEventHandler) provided by the user.
         * OffWindow signal is emitted after the view has been disconnected from the window.
         */
        public event DaliEventHandler<object,OffWindowEventArgs> OffWindowEvent
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_viewOffWindowEventHandler == null)
                    {
                        _viewOffWindowEventHandler += value;

                        _viewOffWindowEventCallbackDelegate = new OffWindowEventCallbackDelegate(OffWindow);
                        this.OnWindowSignal().Connect(_viewOffWindowEventCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_viewOffWindowEventHandler != null)
                    {
                        this.OnWindowSignal().Disconnect(_viewOffWindowEventCallbackDelegate);
                    }

                    _viewOffWindowEventHandler -= value;
                }
            }
        }

        // Callback for View OffWindow signal
        private void OffWindow(IntPtr data)
        {
            OffWindowEventArgs e = new OffWindowEventArgs();

            // Populate all members of "e" (OffWindowEventArgs) with real data
            e.View = View.GetViewFromPtr(data);

            if (_viewOffWindowEventHandler != null)
            {
                //here we send all data to user event handlers
                _viewOffWindowEventHandler(this, e);
            }
        }

        public static View GetViewFromPtr(global::System.IntPtr cPtr)
        {
            View ret = new View(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public IntPtr GetPtrfromView()
        {
            return (IntPtr)swigCPtr;
        }

        public class Property : global::System.IDisposable
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

            public static readonly int TOOLTIP = NDalicManualPINVOKE.View_Property_TOOLTIP_get();
            public static readonly int STATE = NDalicManualPINVOKE.View_Property_STATE_get();
            public static readonly int SUB_STATE = NDalicManualPINVOKE.View_Property_SUB_STATE_get();
            public static readonly int LEFT_FOCUSABLE_VIEW_ID = NDalicManualPINVOKE.View_Property_LEFT_FOCUSABLE_ACTOR_ID_get();
            public static readonly int RIGHT_FOCUSABLE_VIEW_ID = NDalicManualPINVOKE.View_Property_RIGHT_FOCUSABLE_ACTOR_ID_get();
            public static readonly int UP_FOCUSABLE_VIEW_ID = NDalicManualPINVOKE.View_Property_UP_FOCUSABLE_ACTOR_ID_get();
            public static readonly int DOWN_FOCUSABLE_VIEW_ID = NDalicManualPINVOKE.View_Property_DOWN_FOCUSABLE_ACTOR_ID_get();

            public Property() : this(NDalicPINVOKE.new_View_Property(), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            public static readonly int STYLE_NAME = NDalicPINVOKE.View_Property_STYLE_NAME_get();
            public static readonly int BACKGROUND_COLOR = NDalicPINVOKE.View_Property_BACKGROUND_COLOR_get();
            public static readonly int BACKGROUND_IMAGE = NDalicPINVOKE.View_Property_BACKGROUND_IMAGE_get();
            public static readonly int KEY_INPUT_FOCUS = NDalicPINVOKE.View_Property_KEY_INPUT_FOCUS_get();
            public static readonly int BACKGROUND = NDalicPINVOKE.View_Property_BACKGROUND_get();


            public static readonly int SIBLING_ORDER = NDalicManualPINVOKE.Actor_Property_SIBLING_ORDER_get();
            public static readonly int OPACITY = NDalicManualPINVOKE.Actor_Property_OPACITY_get();
            public static readonly int SCREEN_POSITION = NDalicManualPINVOKE.Actor_Property_SCREEN_POSITION_get();
            public static readonly int POSITION_USES_ANCHOR_POINT = NDalicManualPINVOKE.Actor_Property_POSITION_USES_ANCHOR_POINT_get();
            public static readonly int PARENT_ORIGIN = NDalicPINVOKE.Actor_Property_PARENT_ORIGIN_get();
            public static readonly int PARENT_ORIGIN_X = NDalicPINVOKE.Actor_Property_PARENT_ORIGIN_X_get();
            public static readonly int PARENT_ORIGIN_Y = NDalicPINVOKE.Actor_Property_PARENT_ORIGIN_Y_get();
            public static readonly int PARENT_ORIGIN_Z = NDalicPINVOKE.Actor_Property_PARENT_ORIGIN_Z_get();
            public static readonly int ANCHOR_POINT = NDalicPINVOKE.Actor_Property_ANCHOR_POINT_get();
            public static readonly int ANCHOR_POINT_X = NDalicPINVOKE.Actor_Property_ANCHOR_POINT_X_get();
            public static readonly int ANCHOR_POINT_Y = NDalicPINVOKE.Actor_Property_ANCHOR_POINT_Y_get();
            public static readonly int ANCHOR_POINT_Z = NDalicPINVOKE.Actor_Property_ANCHOR_POINT_Z_get();
            public static readonly int SIZE = NDalicPINVOKE.Actor_Property_SIZE_get();
            public static readonly int SIZE_WIDTH = NDalicPINVOKE.Actor_Property_SIZE_WIDTH_get();
            public static readonly int SIZE_HEIGHT = NDalicPINVOKE.Actor_Property_SIZE_HEIGHT_get();
            public static readonly int SIZE_DEPTH = NDalicPINVOKE.Actor_Property_SIZE_DEPTH_get();
            public static readonly int POSITION = NDalicPINVOKE.Actor_Property_POSITION_get();
            public static readonly int POSITION_X = NDalicPINVOKE.Actor_Property_POSITION_X_get();
            public static readonly int POSITION_Y = NDalicPINVOKE.Actor_Property_POSITION_Y_get();
            public static readonly int POSITION_Z = NDalicPINVOKE.Actor_Property_POSITION_Z_get();
            public static readonly int WORLD_POSITION = NDalicPINVOKE.Actor_Property_WORLD_POSITION_get();
            public static readonly int WORLD_POSITION_X = NDalicPINVOKE.Actor_Property_WORLD_POSITION_X_get();
            public static readonly int WORLD_POSITION_Y = NDalicPINVOKE.Actor_Property_WORLD_POSITION_Y_get();
            public static readonly int WORLD_POSITION_Z = NDalicPINVOKE.Actor_Property_WORLD_POSITION_Z_get();
            public static readonly int ORIENTATION = NDalicPINVOKE.Actor_Property_ORIENTATION_get();
            public static readonly int WORLD_ORIENTATION = NDalicPINVOKE.Actor_Property_WORLD_ORIENTATION_get();
            public static readonly int SCALE = NDalicPINVOKE.Actor_Property_SCALE_get();
            public static readonly int SCALE_X = NDalicPINVOKE.Actor_Property_SCALE_X_get();
            public static readonly int SCALE_Y = NDalicPINVOKE.Actor_Property_SCALE_Y_get();
            public static readonly int SCALE_Z = NDalicPINVOKE.Actor_Property_SCALE_Z_get();
            public static readonly int WORLD_SCALE = NDalicPINVOKE.Actor_Property_WORLD_SCALE_get();
            public static readonly int VISIBLE = NDalicPINVOKE.Actor_Property_VISIBLE_get();
            public static readonly int COLOR = NDalicPINVOKE.Actor_Property_COLOR_get();
            public static readonly int COLOR_RED = NDalicPINVOKE.Actor_Property_COLOR_RED_get();
            public static readonly int COLOR_GREEN = NDalicPINVOKE.Actor_Property_COLOR_GREEN_get();
            public static readonly int COLOR_BLUE = NDalicPINVOKE.Actor_Property_COLOR_BLUE_get();
            public static readonly int COLOR_ALPHA = NDalicPINVOKE.Actor_Property_COLOR_ALPHA_get();
            public static readonly int WORLD_COLOR = NDalicPINVOKE.Actor_Property_WORLD_COLOR_get();
            public static readonly int WORLD_MATRIX = NDalicPINVOKE.Actor_Property_WORLD_MATRIX_get();
            public static readonly int NAME = NDalicPINVOKE.Actor_Property_NAME_get();
            public static readonly int SENSITIVE = NDalicPINVOKE.Actor_Property_SENSITIVE_get();
            public static readonly int LEAVE_REQUIRED = NDalicPINVOKE.Actor_Property_LEAVE_REQUIRED_get();
            public static readonly int INHERIT_ORIENTATION = NDalicPINVOKE.Actor_Property_INHERIT_ORIENTATION_get();
            public static readonly int INHERIT_SCALE = NDalicPINVOKE.Actor_Property_INHERIT_SCALE_get();
            public static readonly int COLOR_MODE = NDalicPINVOKE.Actor_Property_COLOR_MODE_get();
            public static readonly int POSITION_INHERITANCE = NDalicPINVOKE.Actor_Property_POSITION_INHERITANCE_get();
            public static readonly int DRAW_MODE = NDalicPINVOKE.Actor_Property_DRAW_MODE_get();
            public static readonly int SIZE_MODE_FACTOR = NDalicPINVOKE.Actor_Property_SIZE_MODE_FACTOR_get();
            public static readonly int WIDTH_RESIZE_POLICY = NDalicPINVOKE.Actor_Property_WIDTH_RESIZE_POLICY_get();
            public static readonly int HEIGHT_RESIZE_POLICY = NDalicPINVOKE.Actor_Property_HEIGHT_RESIZE_POLICY_get();
            public static readonly int SIZE_SCALE_POLICY = NDalicPINVOKE.Actor_Property_SIZE_SCALE_POLICY_get();
            public static readonly int WIDTH_FOR_HEIGHT = NDalicPINVOKE.Actor_Property_WIDTH_FOR_HEIGHT_get();
            public static readonly int HEIGHT_FOR_WIDTH = NDalicPINVOKE.Actor_Property_HEIGHT_FOR_WIDTH_get();
            public static readonly int PADDING = NDalicPINVOKE.Actor_Property_PADDING_get();
            public static readonly int MINIMUM_SIZE = NDalicPINVOKE.Actor_Property_MINIMUM_SIZE_get();
            public static readonly int MAXIMUM_SIZE = NDalicPINVOKE.Actor_Property_MAXIMUM_SIZE_get();
            public static readonly int INHERIT_POSITION = NDalicPINVOKE.Actor_Property_INHERIT_POSITION_get();
            public static readonly int CLIPPING_MODE = NDalicPINVOKE.Actor_Property_CLIPPING_MODE_get();

        }

        public class KeyboardFocus : global::System.IDisposable
        {
            private global::System.Runtime.InteropServices.HandleRef swigCPtr;
            protected bool swigCMemOwn;

            internal KeyboardFocus(global::System.IntPtr cPtr, bool cMemoryOwn)
            {
                swigCMemOwn = cMemoryOwn;
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            }

            internal static global::System.Runtime.InteropServices.HandleRef getCPtr(KeyboardFocus obj)
            {
                return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
            }

            ~KeyboardFocus()
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
                            NDalicPINVOKE.delete_View_KeyboardFocus(swigCPtr);
                        }
                        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                    }
                    global::System.GC.SuppressFinalize(this);
                }
            }

            public KeyboardFocus() : this(NDalicPINVOKE.new_View_KeyboardFocus(), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            public enum Direction
            {
                LEFT,
                RIGHT,
                UP,
                DOWN,
                PAGE_UP,
                PAGE_DOWN
            }
        }

        public View() : this(NDalicPINVOKE.View_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        public View(View uiControl) : this(NDalicPINVOKE.new_View__SWIG_1(View.getCPtr(uiControl)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public View Assign(View handle)
        {
            View ret = new View(NDalicPINVOKE.View_Assign(swigCPtr, View.getCPtr(handle)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private new static View DownCast(BaseHandle handle)
        {
            View ret = new View(NDalicPINVOKE.View_DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static T DownCast<T>(View view) where T : View
        {
            return (T)(ViewRegistry.GetViewFromActor(view));
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

        public void SetKeyInputFocus()
        {
            NDalicPINVOKE.View_SetKeyInputFocus(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool HasKeyInputFocus()
        {
            bool ret = NDalicPINVOKE.View_HasKeyInputFocus(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void ClearKeyInputFocus()
        {
            NDalicPINVOKE.View_ClearKeyInputFocus(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public PinchGestureDetector GetPinchGestureDetector()
        {
            PinchGestureDetector ret = new PinchGestureDetector(NDalicPINVOKE.View_GetPinchGestureDetector(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public PanGestureDetector GetPanGestureDetector()
        {
            PanGestureDetector ret = new PanGestureDetector(NDalicPINVOKE.View_GetPanGestureDetector(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public TapGestureDetector GetTapGestureDetector()
        {
            TapGestureDetector ret = new TapGestureDetector(NDalicPINVOKE.View_GetTapGestureDetector(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public LongPressGestureDetector GetLongPressGestureDetector()
        {
            LongPressGestureDetector ret = new LongPressGestureDetector(NDalicPINVOKE.View_GetLongPressGestureDetector(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetStyleName(string styleName)
        {
            NDalicPINVOKE.View_SetStyleName(swigCPtr, styleName);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public string GetStyleName()
        {
            string ret = NDalicPINVOKE.View_GetStyleName(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetBackgroundColor(Vector4 color)
        {
            NDalicPINVOKE.View_SetBackgroundColor(swigCPtr, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector4 GetBackgroundColor()
        {
            Vector4 ret = new Vector4(NDalicPINVOKE.View_GetBackgroundColor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetBackgroundImage(Image image)
        {
            NDalicPINVOKE.View_SetBackgroundImage(swigCPtr, Image.getCPtr(image));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void ClearBackground()
        {
            NDalicPINVOKE.View_ClearBackground(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public ControlKeySignal KeyEventSignal()
        {
            ControlKeySignal ret = new ControlKeySignal(NDalicPINVOKE.View_KeyEventSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public KeyInputFocusSignal KeyInputFocusGainedSignal()
        {
            KeyInputFocusSignal ret = new KeyInputFocusSignal(NDalicPINVOKE.View_KeyInputFocusGainedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public KeyInputFocusSignal KeyInputFocusLostSignal()
        {
            KeyInputFocusSignal ret = new KeyInputFocusSignal(NDalicPINVOKE.View_KeyInputFocusLostSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public View(ViewImpl implementation) : this(NDalicPINVOKE.new_View__SWIG_2(ViewImpl.getCPtr(implementation)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public enum PropertyRange
        {
            PROPERTY_START_INDEX = PropertyRanges.PROPERTY_REGISTRATION_START_INDEX,
            CONTROL_PROPERTY_START_INDEX = PROPERTY_START_INDEX,
            CONTROL_PROPERTY_END_INDEX = CONTROL_PROPERTY_START_INDEX + 1000
        }

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
                SetProperty(View.Property.STYLE_NAME, new Dali.Property.Value(value));
            }
        }

        public Vector4 BackgroundColor
        {
            get
            {
                Vector4 backgroundColor = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);

                Dali.Property.Map background = Background;
                int visualType = 0;
                background.Find(Dali.Constants.Visual.Property.Type).Get(ref visualType);
                if (visualType == (int)Dali.Constants.Visual.Type.Color)
                {
                    background.Find(Dali.Constants.ColorVisualProperty.MixColor).Get(backgroundColor);
                }

                return backgroundColor;
            }
            set
            {
                SetProperty(View.Property.BACKGROUND, new Dali.Property.Value(value));
            }
        }

        public string BackgroundImage
        {
            get
            {
                string backgroundImage = "";

                Dali.Property.Map background = Background;
                int visualType = 0;
                background.Find(Dali.Constants.Visual.Property.Type).Get(ref visualType);
                if (visualType == (int)Dali.Constants.Visual.Type.Image)
                {
                    background.Find(Dali.Constants.ImageVisualProperty.URL).Get(out backgroundImage);
                }

                return backgroundImage;
            }
            set
            {
                SetProperty(View.Property.BACKGROUND, new Dali.Property.Value(value));
            }
        }

        public bool KeyInputFocus
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.KEY_INPUT_FOCUS).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.KEY_INPUT_FOCUS, new Dali.Property.Value(value));
            }
        }

        public Dali.Property.Map Background
        {
            get
            {
                Dali.Property.Map temp = new Dali.Property.Map();
                GetProperty(View.Property.BACKGROUND).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.BACKGROUND, new Dali.Property.Value(value));
            }
        }

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
                SetProperty(View.Property.STATE, new Dali.Property.Value(value));
            }
        }

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
                SetProperty(View.Property.SUB_STATE, new Dali.Property.Value(value));
            }
        }

        public Dali.Property.Map Tooltip
        {
            get
            {
                Dali.Property.Map temp = new Dali.Property.Map();
                GetProperty(View.Property.TOOLTIP).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.TOOLTIP, new Dali.Property.Value(value));
            }
        }

        public string TooltipText
        {
            set
            {
                SetProperty(View.Property.TOOLTIP, new Dali.Property.Value(value));
            }
        }

        private int LeftFocusableViewId
        {
            get
            {
                int temp = 0;
                GetProperty(View.Property.LEFT_FOCUSABLE_VIEW_ID).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.LEFT_FOCUSABLE_VIEW_ID, new Dali.Property.Value(value));
            }
        }

        private int RightFocusableViewId
        {
            get
            {
                int temp = 0;
                GetProperty(View.Property.RIGHT_FOCUSABLE_VIEW_ID).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.RIGHT_FOCUSABLE_VIEW_ID, new Dali.Property.Value(value));
            }
        }

        private int UpFocusableViewId
        {
            get
            {
                int temp = 0;
                GetProperty(View.Property.UP_FOCUSABLE_VIEW_ID).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.UP_FOCUSABLE_VIEW_ID, new Dali.Property.Value(value));
            }
        }

        private int DownFocusableViewId
        {
            get
            {
                int temp = 0;
                GetProperty(View.Property.DOWN_FOCUSABLE_VIEW_ID).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.DOWN_FOCUSABLE_VIEW_ID, new Dali.Property.Value(value));
            }
        }

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
                SetProperty(FlexContainer.ChildProperty.FLEX, new Dali.Property.Value(value));
            }
        }

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
                SetProperty(FlexContainer.ChildProperty.ALIGN_SELF, new Dali.Property.Value(value));
            }
        }

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
                SetProperty(FlexContainer.ChildProperty.FLEX_MARGIN, new Dali.Property.Value(value));
            }
        }

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
                SetProperty(TableView.ChildProperty.CELL_INDEX, new Dali.Property.Value(value));
            }
        }

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
                SetProperty(TableView.ChildProperty.ROW_SPAN, new Dali.Property.Value(value));
            }
        }

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
                SetProperty(TableView.ChildProperty.COLUMN_SPAN, new Dali.Property.Value(value));
            }
        }

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
                SetProperty(TableView.ChildProperty.CELL_HORIZONTAL_ALIGNMENT, new Dali.Property.Value(value));
            }
        }

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
                SetProperty(TableView.ChildProperty.CELL_VERTICAL_ALIGNMENT, new Dali.Property.Value(value));
            }
        }

        /**
         * @brief The left focusable view.
         * @note This will return NULL if not set.
         * This will also return NULL if the specified left focusable view is not on window.
         *
         */
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

        /**
         * @brief The right focusable view.
         * @note This will return NULL if not set.
         * This will also return NULL if the specified right focusable view is not on window.
         *
         */
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

        /**
         * @brief The up focusable view.
         * @note This will return NULL if not set.
         * This will also return NULL if the specified up focusable view is not on window.
         *
         */
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

        /**
         * @brief The down focusable view.
         * @note This will return NULL if not set.
         * This will also return NULL if the specified down focusable view is not on window.
         *
         */
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

        public Position CurrentPosition
        {
            get
            {
                return GetCurrentPosition();
            }
        }

        public Size2D Size2D
        {
            get
            {
                Size temp = new Size(0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.SIZE).Get(temp);
                return new Size2D(temp);
            }
            set
            {
                SetProperty(View.Property.SIZE, new Dali.Property.Value(new Size(value)));
            }
        }

        public Size CurrentSize
        {
            get
            {
                return GetCurrentSize();
            }
        }

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

        public float Opacity
        {
            get
            {
                float temp = 0;
                GetProperty(View.Property.OPACITY).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.OPACITY, new Dali.Property.Value(value));
            }
        }

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
                SetProperty(View.Property.POSITION, new Dali.Property.Value(new Position(value)));
            }
        }

        public Vector2 ScreenPosition
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(View.Property.SCREEN_POSITION).Get(temp);
                return temp;
            }
        }

        protected bool PositionUsesAnchorPoint
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.POSITION_USES_ANCHOR_POINT).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.POSITION_USES_ANCHOR_POINT, new Dali.Property.Value(value));
            }
        }

        public bool StateFocusEnable
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

        public bool IsOnWindow
        {
            get
            {
                return OnWindow();
            }
        }

        public int SiblingOrder
        {
            get
            {
                int temp = 0;
                GetProperty(View.Property.SIBLING_ORDER).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.SIBLING_ORDER, new Dali.Property.Value(value));
            }
        }

        public void Show()
        {
            SetVisible(true);
        }

        public void Hide()
        {
            SetVisible(false);
        }

        public void Raise()
        {
            NDalicPINVOKE.Raise(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Lower()
        {
            NDalicPINVOKE.Lower(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void RaiseToTop()
        {
            NDalicPINVOKE.RaiseToTop(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void LowerToBottom()
        {
            NDalicPINVOKE.LowerToBottom(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void RaiseAbove(View target)
        {
            NDalicPINVOKE.RaiseAbove(swigCPtr, View.getCPtr(target));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void LowerBelow(View target)
        {
            NDalicPINVOKE.RaiseAbove(swigCPtr, View.getCPtr(target));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public string GetName()
        {
            string ret = NDalicPINVOKE.Actor_GetName(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetName(string name)
        {
            NDalicPINVOKE.Actor_SetName(swigCPtr, name);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public uint GetId()
        {
            uint ret = NDalicPINVOKE.Actor_GetId(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool OnWindow()
        {
            bool ret = NDalicPINVOKE.Actor_OnStage(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Layer GetLayer()
        {
            Layer ret = new Layer(NDalicPINVOKE.Actor_GetLayer(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Add(View child)
        {
            NDalicPINVOKE.Actor_Add(swigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Remove(View child)
        {
            NDalicPINVOKE.Actor_Remove(swigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Unparent()
        {
            NDalicPINVOKE.Actor_Unparent(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public uint GetChildCount()
        {
            uint ret = NDalicPINVOKE.Actor_GetChildCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public View GetChildAt(uint index)
        {
            View ret = new View(NDalicPINVOKE.Actor_GetChildAt(swigCPtr, index), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public View FindChildByName(string actorName)
        {
            View ret = new View(NDalicPINVOKE.Actor_FindChildByName(swigCPtr, actorName), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public View FindChildById(uint id)
        {
            View ret = new View(NDalicPINVOKE.Actor_FindChildById(swigCPtr, id), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public View GetParent()
        {
            View ret = new View(NDalicPINVOKE.Actor_GetParent(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetParentOrigin(Vector3 origin)
        {
            NDalicPINVOKE.Actor_SetParentOrigin(swigCPtr, Vector3.getCPtr(origin));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector3 GetCurrentParentOrigin()
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Actor_GetCurrentParentOrigin(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetAnchorPoint(Vector3 anchorPoint)
        {
            NDalicPINVOKE.Actor_SetAnchorPoint(swigCPtr, Vector3.getCPtr(anchorPoint));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector3 GetCurrentAnchorPoint()
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Actor_GetCurrentAnchorPoint(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetSize(float width, float height)
        {
            NDalicPINVOKE.Actor_SetSize__SWIG_0(swigCPtr, width, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetSize(float width, float height, float depth)
        {
            NDalicPINVOKE.Actor_SetSize__SWIG_1(swigCPtr, width, height, depth);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetSize(Vector2 size)
        {
            NDalicPINVOKE.Actor_SetSize__SWIG_2(swigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetSize(Vector3 size)
        {
            NDalicPINVOKE.Actor_SetSize__SWIG_3(swigCPtr, Vector3.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector3 GetTargetSize()
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Actor_GetTargetSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Vector3 GetCurrentSize()
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Actor_GetCurrentSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Vector3 GetNaturalSize()
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Actor_GetNaturalSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetPosition(float x, float y)
        {
            NDalicPINVOKE.Actor_SetPosition__SWIG_0(swigCPtr, x, y);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetPosition(float x, float y, float z)
        {
            NDalicPINVOKE.Actor_SetPosition__SWIG_1(swigCPtr, x, y, z);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetPosition(Vector3 position)
        {
            NDalicPINVOKE.Actor_SetPosition__SWIG_2(swigCPtr, Vector3.getCPtr(position));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetX(float x)
        {
            NDalicPINVOKE.Actor_SetX(swigCPtr, x);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetY(float y)
        {
            NDalicPINVOKE.Actor_SetY(swigCPtr, y);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetZ(float z)
        {
            NDalicPINVOKE.Actor_SetZ(swigCPtr, z);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void TranslateBy(Vector3 distance)
        {
            NDalicPINVOKE.Actor_TranslateBy(swigCPtr, Vector3.getCPtr(distance));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector3 GetCurrentPosition()
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Actor_GetCurrentPosition(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Vector3 GetCurrentWorldPosition()
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Actor_GetCurrentWorldPosition(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetInheritPosition(bool inherit)
        {
            NDalicPINVOKE.Actor_SetInheritPosition(swigCPtr, inherit);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public PositionInheritanceMode GetPositionInheritanceMode()
        {
            PositionInheritanceMode ret = (PositionInheritanceMode)NDalicPINVOKE.Actor_GetPositionInheritanceMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool IsPositionInherited()
        {
            bool ret = NDalicPINVOKE.Actor_IsPositionInherited(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetOrientation(Degree angle, Vector3 axis)
        {
            NDalicPINVOKE.Actor_SetOrientation__SWIG_0(swigCPtr, Degree.getCPtr(angle), Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetOrientation(Radian angle, Vector3 axis)
        {
            NDalicPINVOKE.Actor_SetOrientation__SWIG_1(swigCPtr, Radian.getCPtr(angle), Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetOrientation(Rotation orientation)
        {
            NDalicPINVOKE.Actor_SetOrientation__SWIG_2(swigCPtr, Rotation.getCPtr(orientation));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void RotateBy(Degree angle, Vector3 axis)
        {
            NDalicPINVOKE.Actor_RotateBy__SWIG_0(swigCPtr, Degree.getCPtr(angle), Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void RotateBy(Radian angle, Vector3 axis)
        {
            NDalicPINVOKE.Actor_RotateBy__SWIG_1(swigCPtr, Radian.getCPtr(angle), Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void RotateBy(Rotation relativeRotation)
        {
            NDalicPINVOKE.Actor_RotateBy__SWIG_2(swigCPtr, Rotation.getCPtr(relativeRotation));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Rotation GetCurrentOrientation()
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Actor_GetCurrentOrientation(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetInheritOrientation(bool inherit)
        {
            NDalicPINVOKE.Actor_SetInheritOrientation(swigCPtr, inherit);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool IsOrientationInherited()
        {
            bool ret = NDalicPINVOKE.Actor_IsOrientationInherited(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Rotation GetCurrentWorldOrientation()
        {
            Rotation ret = new Rotation(NDalicPINVOKE.Actor_GetCurrentWorldOrientation(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetScale(float scale)
        {
            NDalicPINVOKE.Actor_SetScale__SWIG_0(swigCPtr, scale);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetScale(float scaleX, float scaleY, float scaleZ)
        {
            NDalicPINVOKE.Actor_SetScale__SWIG_1(swigCPtr, scaleX, scaleY, scaleZ);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetScale(Vector3 scale)
        {
            NDalicPINVOKE.Actor_SetScale__SWIG_2(swigCPtr, Vector3.getCPtr(scale));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void ScaleBy(Vector3 relativeScale)
        {
            NDalicPINVOKE.Actor_ScaleBy(swigCPtr, Vector3.getCPtr(relativeScale));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector3 GetCurrentScale()
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Actor_GetCurrentScale(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Vector3 GetCurrentWorldScale()
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Actor_GetCurrentWorldScale(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetInheritScale(bool inherit)
        {
            NDalicPINVOKE.Actor_SetInheritScale(swigCPtr, inherit);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool IsScaleInherited()
        {
            bool ret = NDalicPINVOKE.Actor_IsScaleInherited(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Matrix GetCurrentWorldMatrix()
        {
            Matrix ret = new Matrix(NDalicPINVOKE.Actor_GetCurrentWorldMatrix(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetVisible(bool visible)
        {
            NDalicPINVOKE.Actor_SetVisible(swigCPtr, visible);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool IsVisible()
        {
            bool ret = NDalicPINVOKE.Actor_IsVisible(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetOpacity(float opacity)
        {
            NDalicPINVOKE.Actor_SetOpacity(swigCPtr, opacity);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float GetCurrentOpacity()
        {
            float ret = NDalicPINVOKE.Actor_GetCurrentOpacity(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetColor(Vector4 color)
        {
            NDalicPINVOKE.Actor_SetColor(swigCPtr, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector4 GetCurrentColor()
        {
            Vector4 ret = new Vector4(NDalicPINVOKE.Actor_GetCurrentColor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetColorMode(ColorMode colorMode)
        {
            NDalicPINVOKE.Actor_SetColorMode(swigCPtr, (int)colorMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public ColorMode GetColorMode()
        {
            ColorMode ret = (ColorMode)NDalicPINVOKE.Actor_GetColorMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Vector4 GetCurrentWorldColor()
        {
            Vector4 ret = new Vector4(NDalicPINVOKE.Actor_GetCurrentWorldColor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetDrawMode(DrawModeType drawMode)
        {
            NDalicPINVOKE.Actor_SetDrawMode(swigCPtr, (int)drawMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public DrawModeType GetDrawMode()
        {
            DrawModeType ret = (DrawModeType)NDalicPINVOKE.Actor_GetDrawMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetSensitive(bool sensitive)
        {
            NDalicPINVOKE.Actor_SetSensitive(swigCPtr, sensitive);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool IsSensitive()
        {
            bool ret = NDalicPINVOKE.Actor_IsSensitive(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool ScreenToLocal(out float localX, out float localY, float screenX, float screenY)
        {
            bool ret = NDalicPINVOKE.Actor_ScreenToLocal(swigCPtr, out localX, out localY, screenX, screenY);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetLeaveRequired(bool required)
        {
            NDalicPINVOKE.Actor_SetLeaveRequired(swigCPtr, required);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool GetLeaveRequired()
        {
            bool ret = NDalicPINVOKE.Actor_GetLeaveRequired(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetKeyboardFocusable(bool focusable)
        {
            NDalicPINVOKE.Actor_SetKeyboardFocusable(swigCPtr, focusable);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool IsKeyboardFocusable()
        {
            bool ret = NDalicPINVOKE.Actor_IsKeyboardFocusable(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetResizePolicy(ResizePolicyType policy, DimensionType dimension)
        {
            NDalicPINVOKE.Actor_SetResizePolicy(swigCPtr, (int)policy, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public ResizePolicyType GetResizePolicy(DimensionType dimension)
        {
            ResizePolicyType ret = (ResizePolicyType)NDalicPINVOKE.Actor_GetResizePolicy(swigCPtr, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetSizeScalePolicy(SizeScalePolicyType policy)
        {
            NDalicPINVOKE.Actor_SetSizeScalePolicy(swigCPtr, (int)policy);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public SizeScalePolicyType GetSizeScalePolicy()
        {
            SizeScalePolicyType ret = (SizeScalePolicyType)NDalicPINVOKE.Actor_GetSizeScalePolicy(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetSizeModeFactor(Vector3 factor)
        {
            NDalicPINVOKE.Actor_SetSizeModeFactor(swigCPtr, Vector3.getCPtr(factor));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector3 GetSizeModeFactor()
        {
            Vector3 ret = new Vector3(NDalicPINVOKE.Actor_GetSizeModeFactor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public float GetHeightForWidth(float width)
        {
            float ret = NDalicPINVOKE.Actor_GetHeightForWidth(swigCPtr, width);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

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

        public void SetMinimumSize(Vector2 size)
        {
            NDalicPINVOKE.Actor_SetMinimumSize(swigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector2 GetMinimumSize()
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Actor_GetMinimumSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetMaximumSize(Vector2 size)
        {
            NDalicPINVOKE.Actor_SetMaximumSize(swigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector2 GetMaximumSize()
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Actor_GetMaximumSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public int GetHierarchyDepth()
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

        public uint GetRendererCount()
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

        public ViewSignal OnWindowSignal()
        {
            ViewSignal ret = new ViewSignal(NDalicPINVOKE.Actor_OnStageSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public ViewSignal OffStageSignal()
        {
            ViewSignal ret = new ViewSignal(NDalicPINVOKE.Actor_OffStageSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public ViewSignal OnRelayoutSignal()
        {
            ViewSignal ret = new ViewSignal(NDalicPINVOKE.Actor_OnRelayoutSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Vector3 ParentOrigin
        {
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.PARENT_ORIGIN).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.PARENT_ORIGIN, new Dali.Property.Value(value));
            }
        }

        public float ParentOriginX
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.PARENT_ORIGIN_X).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.PARENT_ORIGIN_X, new Dali.Property.Value(value));
            }
        }

        public float ParentOriginY
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.PARENT_ORIGIN_Y).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.PARENT_ORIGIN_Y, new Dali.Property.Value(value));
            }
        }

        public float ParentOriginZ
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.PARENT_ORIGIN_Z).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.PARENT_ORIGIN_Z, new Dali.Property.Value(value));
            }
        }

        public Vector3 AnchorPoint
        {
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.ANCHOR_POINT).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.ANCHOR_POINT, new Dali.Property.Value(value));
            }
        }

        public float AnchorPointX
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.ANCHOR_POINT_X).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.ANCHOR_POINT_X, new Dali.Property.Value(value));
            }
        }

        public float AnchorPointY
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.ANCHOR_POINT_Y).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.ANCHOR_POINT_Y, new Dali.Property.Value(value));
            }
        }

        public float AnchorPointZ
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.ANCHOR_POINT_Z).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.ANCHOR_POINT_Z, new Dali.Property.Value(value));
            }
        }

        public Vector3 Size
        {
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.SIZE).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.SIZE, new Dali.Property.Value(value));
            }
        }

        public float SizeWidth
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.SIZE_WIDTH).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.SIZE_WIDTH, new Dali.Property.Value(value));
            }
        }

        public float SizeHeight
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.SIZE_HEIGHT).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.SIZE_HEIGHT, new Dali.Property.Value(value));
            }
        }

        public float SizeDepth
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.SIZE_DEPTH).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.SIZE_DEPTH, new Dali.Property.Value(value));
            }
        }

        public Vector3 Position
        {
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.POSITION).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.POSITION, new Dali.Property.Value(value));
            }
        }

        public float PositionX
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.POSITION_X).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.POSITION_X, new Dali.Property.Value(value));
            }
        }

        public float PositionY
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.POSITION_Y).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.POSITION_Y, new Dali.Property.Value(value));
            }
        }

        public float PositionZ
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.POSITION_Z).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.POSITION_Z, new Dali.Property.Value(value));
            }
        }

        public Vector3 WorldPosition
        {
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.WORLD_POSITION).Get(temp);
                return temp;
            }
        }

        public float WorldPositionX
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.WORLD_POSITION_X).Get(ref temp);
                return temp;
            }
        }

        public float WorldPositionY
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.WORLD_POSITION_Y).Get(ref temp);
                return temp;
            }
        }

        public float WorldPositionZ
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.WORLD_POSITION_Z).Get(ref temp);
                return temp;
            }
        }

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
                SetProperty(View.Property.ORIENTATION, new Dali.Property.Value(value));
            }
        }

        public Rotation WorldOrientation
        {
            get
            {
                Rotation temp = new Rotation();
                GetProperty(View.Property.WORLD_ORIENTATION).Get(temp);
                return temp;
            }
        }

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
                SetProperty(View.Property.SCALE, new Dali.Property.Value(value));
            }
        }

        public float ScaleX
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.SCALE_X).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.SCALE_X, new Dali.Property.Value(value));
            }
        }

        public float ScaleY
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.SCALE_Y).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.SCALE_Y, new Dali.Property.Value(value));
            }
        }

        public float ScaleZ
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.SCALE_Z).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.SCALE_Z, new Dali.Property.Value(value));
            }
        }

        public Vector3 WorldScale
        {
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.WORLD_SCALE).Get(temp);
                return temp;
            }
        }

        public bool Visible
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.VISIBLE).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.VISIBLE, new Dali.Property.Value(value));
            }
        }

        public float ColorRed
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.COLOR_RED).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.COLOR_RED, new Dali.Property.Value(value));
            }
        }

        public float ColorGreen
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.COLOR_GREEN).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.COLOR_GREEN, new Dali.Property.Value(value));
            }
        }

        public float ColorBlue
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.COLOR_BLUE).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.COLOR_BLUE, new Dali.Property.Value(value));
            }
        }

        public float ColorAlpha
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.COLOR_ALPHA).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.COLOR_ALPHA, new Dali.Property.Value(value));
            }
        }

        public Vector4 WorldColor
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.WORLD_COLOR).Get(temp);
                return temp;
            }
        }

        public Matrix WorldMatrix
        {
            get
            {
                Matrix temp = new Matrix();
                GetProperty(View.Property.WORLD_MATRIX).Get(temp);
                return temp;
            }
        }

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
                SetProperty(View.Property.NAME, new Dali.Property.Value(value));
            }
        }

        public bool Sensitive
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.SENSITIVE).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.SENSITIVE, new Dali.Property.Value(value));
            }
        }

        public bool LeaveRequired
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.LEAVE_REQUIRED).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.LEAVE_REQUIRED, new Dali.Property.Value(value));
            }
        }

        public bool InheritOrientation
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.INHERIT_ORIENTATION).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.INHERIT_ORIENTATION, new Dali.Property.Value(value));
            }
        }

        public bool InheritScale
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.INHERIT_SCALE).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.INHERIT_SCALE, new Dali.Property.Value(value));
            }
        }

        public string ColorMode
        {
            get
            {
                string temp;
                GetProperty(View.Property.COLOR_MODE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.COLOR_MODE, new Dali.Property.Value(value));
            }
        }

        public string PositionInheritance
        {
            get
            {
                string temp;
                GetProperty(View.Property.POSITION_INHERITANCE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.POSITION_INHERITANCE, new Dali.Property.Value(value));
            }
        }

        public string DrawMode
        {
            get
            {
                string temp;
                GetProperty(View.Property.DRAW_MODE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.DRAW_MODE, new Dali.Property.Value(value));
            }
        }

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
                SetProperty(View.Property.SIZE_MODE_FACTOR, new Dali.Property.Value(value));
            }
        }

        public string WidthResizePolicy
        {
            get
            {
                string temp;
                GetProperty(View.Property.WIDTH_RESIZE_POLICY).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.WIDTH_RESIZE_POLICY, new Dali.Property.Value(value));
            }
        }

        public string HeightResizePolicy
        {
            get
            {
                string temp;
                GetProperty(View.Property.HEIGHT_RESIZE_POLICY).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.HEIGHT_RESIZE_POLICY, new Dali.Property.Value(value));
            }
        }

        public string SizeScalePolicy
        {
            get
            {
                string temp;
                GetProperty(View.Property.SIZE_SCALE_POLICY).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.SIZE_SCALE_POLICY, new Dali.Property.Value(value));
            }
        }

        public bool WidthForHeight
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.WIDTH_FOR_HEIGHT).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.WIDTH_FOR_HEIGHT, new Dali.Property.Value(value));
            }
        }

        public bool HeightForWidth
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.HEIGHT_FOR_WIDTH).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.HEIGHT_FOR_WIDTH, new Dali.Property.Value(value));
            }
        }

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
                SetProperty(View.Property.PADDING, new Dali.Property.Value(value));
            }
        }

        public Vector2 MinimumSize
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(View.Property.MINIMUM_SIZE).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.MINIMUM_SIZE, new Dali.Property.Value(value));
            }
        }

        public Vector2 MaximumSize
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(View.Property.MAXIMUM_SIZE).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.MAXIMUM_SIZE, new Dali.Property.Value(value));
            }
        }

        public bool InheritPosition
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.INHERIT_POSITION).Get(ref temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.INHERIT_POSITION, new Dali.Property.Value(value));
            }
        }

        public string ClippingMode
        {
            get
            {
                string temp;
                GetProperty(View.Property.CLIPPING_MODE).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.CLIPPING_MODE, new Dali.Property.Value(value));
            }
        }
    }
}
