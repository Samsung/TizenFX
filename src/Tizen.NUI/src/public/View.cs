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
         * @brief Event arguments that passed via OnStage signal
         *
         */
        public class OnStageEventArgs : EventArgs
        {
            private View _view;

            /**
             * @brief View - is the view that is being connected to the stage
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
         * @brief Event arguments that passed via OffStage signal
         *
         */
        public class OffStageEventArgs : EventArgs
        {
            private View _view;

            /**
             * @brief View - is the view that is being disconnected from the stage
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
        private EventHandler<KeyInputFocusGainedEventArgs> _KeyInputFocusGainedEventHandler;
        private KeyInputFocusGainedCallbackDelegate _KeyInputFocusGainedCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void KeyInputFocusLostCallbackDelegate(IntPtr control);
        private EventHandler<KeyInputFocusLostEventArgs> _KeyInputFocusLostEventHandler;
        private KeyInputFocusLostCallbackDelegate _KeyInputFocusLostCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool KeyCallbackDelegate(IntPtr control, IntPtr key);
        private EventHandlerWithReturnType<object, KeyEventArgs, bool> _KeyHandler;
        private KeyCallbackDelegate _KeyCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void OnRelayoutEventCallbackDelegate(IntPtr control);
        private EventHandler<OnRelayoutEventArgs> _viewOnRelayoutEventHandler;
        private OnRelayoutEventCallbackDelegate _viewOnRelayoutEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool TouchCallbackDelegate(IntPtr view, IntPtr touch);
        private EventHandlerWithReturnType<object, TouchEventArgs, bool> _viewTouchHandler;
        private TouchCallbackDelegate _viewTouchCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool HoverCallbackDelegate(IntPtr view, IntPtr hover);
        private EventHandlerWithReturnType<object, HoverEventArgs, bool> _viewHoverHandler;
        private HoverCallbackDelegate _viewHoverCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool WheelCallbackDelegate(IntPtr view, IntPtr wheel);
        private EventHandlerWithReturnType<object, WheelEventArgs, bool> _viewWheelHandler;
        private WheelCallbackDelegate _viewWheelCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void OnStageEventCallbackDelegate(IntPtr control);
        private EventHandler<OnStageEventArgs> _viewOnStageEventHandler;
        private OnStageEventCallbackDelegate _viewOnStageEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void OffStageEventCallbackDelegate(IntPtr control);
        private EventHandler<OffStageEventArgs> _viewOffStageEventHandler;
        private OffStageEventCallbackDelegate _viewOffStageEventCallbackDelegate;

        /**
         * @brief Event for KeyInputFocusGained signal which can be used to subscribe/unsubscribe the event handler
         * (in the type of KeyInputFocusGainedEventHandler-DaliEventHandler<object,KeyInputFocusGainedEventArgs>)
         * provided by the user. KeyInputFocusGained signal is emitted when the control gets Key Input Focus.
         */
        public event EventHandler<KeyInputFocusGainedEventArgs> KeyInputFocusGained
        {
            add
            {
                if (_KeyInputFocusGainedEventHandler == null)
                {
                    //Console.WriteLine("View Key EVENT Locked....");
                    _KeyInputFocusGainedCallbackDelegate = (OnKeyInputFocusGained);
                    KeyInputFocusGainedSignal().Connect(_KeyInputFocusGainedCallbackDelegate);
                }
                _KeyInputFocusGainedEventHandler += value;
            }

            remove
            {
                _KeyInputFocusGainedEventHandler -= value;

                if (_KeyInputFocusGainedEventHandler == null && _KeyInputFocusGainedCallbackDelegate != null)
                {
                    KeyInputFocusGainedSignal().Disconnect(_KeyInputFocusGainedCallbackDelegate);
                }
            }
        }

        private void OnKeyInputFocusGained(IntPtr view)
        {
            KeyInputFocusGainedEventArgs e = new KeyInputFocusGainedEventArgs();
            Console.WriteLine("View Key ....");
            // Populate all members of "e" (KeyInputFocusGainedEventArgs) with real data
            e.View = Tizen.NUI.View.GetViewFromPtr(view);

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
        public event EventHandler<KeyInputFocusLostEventArgs> KeyInputFocusLost
        {
            add
            {
                if (_KeyInputFocusLostEventHandler == null)
                {
                    _KeyInputFocusLostCallbackDelegate = (OnKeyInputFocusLost);
                    KeyInputFocusLostSignal().Connect(_KeyInputFocusLostCallbackDelegate);
                }
                _KeyInputFocusLostEventHandler += value;
            }

            remove
            {
                _KeyInputFocusLostEventHandler -= value;

                if (_KeyInputFocusLostEventHandler == null && _KeyInputFocusLostCallbackDelegate != null)
                {
                    KeyInputFocusLostSignal().Disconnect(_KeyInputFocusLostCallbackDelegate);
                }
            }
        }

        private void OnKeyInputFocusLost(IntPtr view)
        {
            KeyInputFocusLostEventArgs e = new KeyInputFocusLostEventArgs();

            // Populate all members of "e" (KeyInputFocusLostEventArgs) with real data
            e.View = Tizen.NUI.View.GetViewFromPtr(view);

            if (_KeyInputFocusLostEventHandler != null)
            {
                //here we send all data to user event handlers
                _KeyInputFocusLostEventHandler(this, e);
            }
        }

        /**
         * @brief Event for KeyPressed signal which can be used to subscribe/unsubscribe the event handler
         * (in the type of KeyHandler-EventHandlerWithReturnType<object,KeyEventArgs,bool>)
         * provided by the user. KeyPressed signal is emitted when key event is received.
         */
        public event EventHandlerWithReturnType<object, KeyEventArgs, bool> KeyPressed
        {
            add
            {
                if (_KeyHandler == null)
                {
                    _KeyCallbackDelegate = (OnKey);
                    KeyEventSignal().Connect(_KeyCallbackDelegate);
                }
                _KeyHandler += value;
            }

            remove
            {
                _KeyHandler -= value;
                if (_KeyHandler == null && _KeyCallbackDelegate != null)
                {
                    KeyEventSignal().Disconnect(_KeyCallbackDelegate);
                }
            }
        }

        private bool OnKey(IntPtr view, IntPtr key)
        {
            KeyEventArgs e = new KeyEventArgs();

            // Populate all members of "e" (KeyEventArgs) with real data
            e.View = Tizen.NUI.View.GetViewFromPtr(view);
            e.Key = Tizen.NUI.Key.GetKeyFromPtr(key);

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
        public event EventHandler<OnRelayoutEventArgs> OnRelayoutEvent
        {
            add
            {
                if (_viewOnRelayoutEventHandler == null)
                {
                    //Console.WriteLine("View OnRelayoutEventArgs Locked....");
                    _viewOnRelayoutEventCallbackDelegate = (OnRelayout);
                    OnRelayoutSignal().Connect(_viewOnRelayoutEventCallbackDelegate);
                }
                _viewOnRelayoutEventHandler += value;
            }

            remove
            {
                _viewOnRelayoutEventHandler -= value;
                if (_viewOnRelayoutEventHandler == null && _viewOnRelayoutEventCallbackDelegate != null)
                {
                    OnRelayoutSignal().Disconnect(_viewOnRelayoutEventCallbackDelegate);
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
         * (in the type of TouchHandler-EventHandlerWithReturnType<object,TouchEventArgs,bool>)
         * provided by the user. Touched signal is emitted when touch input is received.
         */
        public event EventHandlerWithReturnType<object, TouchEventArgs, bool> Touched
        {
            add
            {
                if (_viewTouchHandler == null)
                {
                    //Console.WriteLine("View Touch EVENT LOCKED....");
                    _viewTouchCallbackDelegate = (OnTouch);
                    TouchSignal().Connect(_viewTouchCallbackDelegate);
                }
                _viewTouchHandler += value;
            }

            remove
            {
                _viewTouchHandler -= value;
                if (_viewTouchHandler == null && _viewTouchCallbackDelegate != null)
                {
                    TouchSignal().Disconnect(_viewTouchCallbackDelegate);
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
            e.Touch = Tizen.NUI.Touch.GetTouchFromPtr(touch);

            if (_viewTouchHandler != null)
            {
                //here we send all data to user event handlers
                return _viewTouchHandler(this, e);
            }

            return false;
        }

        /**
         * @brief Event for Hovered signal which can be used to subscribe/unsubscribe the event handler
         * (in the type of HoverHandler-EventHandlerWithReturnType<object,HoverEventArgs,bool>)
         * provided by the user. Hovered signal is emitted when hover input is received.
         */
        public event EventHandlerWithReturnType<object, HoverEventArgs, bool> Hovered
        {
            add
            {
                if (_viewHoverHandler == null)
                {
                    _viewHoverCallbackDelegate = (OnHover);
                    HoveredSignal().Connect(_viewHoverCallbackDelegate);
                }
                _viewHoverHandler += value;
            }

            remove
            {
                _viewHoverHandler -= value;
                if (_viewHoverHandler == null && _viewHoverCallbackDelegate != null)
                {
                    HoveredSignal().Disconnect(_viewHoverCallbackDelegate);
                }
            }
        }

        // Callback for View Hover signal
        private bool OnHover(IntPtr view, IntPtr hover)
        {
            HoverEventArgs e = new HoverEventArgs();

            // Populate all members of "e" (HoverEventArgs) with real data
            e.View = View.GetViewFromPtr(view);
            e.Hover = Tizen.NUI.Hover.GetHoverFromPtr(hover);

            if (_viewHoverHandler != null)
            {
                //here we send all data to user event handlers
                return _viewHoverHandler(this, e);
            }

            return false;
        }

        /**
         * @brief Event for WheelMoved signal which can be used to subscribe/unsubscribe the event handler
         * (in the type of WheelHandler-EventHandlerWithReturnType<object,WheelEventArgs,bool>)
         * provided by the user. WheelMoved signal is emitted when wheel event is received.
         */
        public event EventHandlerWithReturnType<object, WheelEventArgs, bool> WheelMoved
        {
            add
            {
                if (_viewWheelHandler == null)
                {
                    //Console.WriteLine("View Wheel EVENT LOCKED....");
                    _viewWheelCallbackDelegate = (OnWheel);
                    WheelEventSignal().Connect(_viewWheelCallbackDelegate);
                }
                _viewWheelHandler += value;
            }

            remove
            {
                _viewWheelHandler -= value;
                if (_viewWheelHandler == null && _viewWheelCallbackDelegate != null)
                {
                    WheelEventSignal().Disconnect(_viewWheelCallbackDelegate);
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
            e.Wheel = Tizen.NUI.Wheel.GetWheelFromPtr(wheel);

            if (_viewWheelHandler != null)
            {
                //here we send all data to user event handlers
                return _viewWheelHandler(this, e);
            }

            return false;
        }

        /**
         * @brief Event for OnStage signal which can be used to subscribe/unsubscribe the event handler
         * (in the type of OnStageEventHandler) provided by the user.
         * OnStage signal is emitted after the view has been connected to the stage.
         */
        public event EventHandler<OnStageEventArgs> OnStageEvent
        {
            add
            {
                if (_viewOnStageEventHandler == null)
                {
                    _viewOnStageEventCallbackDelegate = (OnStage);
                    OnStageSignal().Connect(_viewOnStageEventCallbackDelegate);
                }
                _viewOnStageEventHandler += value;
            }

            remove
            {
                _viewOnStageEventHandler -= value;
                if (_viewOnStageEventHandler == null && _viewOnStageEventCallbackDelegate != null)
                {
                    OnStageSignal().Disconnect(_viewOnStageEventCallbackDelegate);
                }
            }
        }

        // Callback for View OnStage signal
        private void OnStage(IntPtr data)
        {
            OnStageEventArgs e = new OnStageEventArgs();

            // Populate all members of "e" (OnStageEventArgs) with real data
            e.View = View.GetViewFromPtr(data);

            //Console.WriteLine("############# OnStage()! e.View.Name=" + e.View.Name);

            if (_viewOnStageEventHandler != null)
            {
                //here we send all data to user event handlers
                _viewOnStageEventHandler(this, e);
            }
        }

        /**
         * @brief Event for OffStage signal which can be used to subscribe/unsubscribe the event handler
         * (in the type of OffStageEventHandler) provided by the user.
         * OffStage signal is emitted after the view has been disconnected from the stage.
         */
        public event EventHandler<OffStageEventArgs> OffStageEvent
        {
            add
            {
                if (_viewOffStageEventHandler == null)
                {
                    _viewOffStageEventCallbackDelegate = (OffStage);
                    OnStageSignal().Connect(_viewOffStageEventCallbackDelegate);
                }
                _viewOffStageEventHandler += value;
            }

            remove
            {
                _viewOffStageEventHandler -= value;
                if (_viewOffStageEventHandler == null && _viewOffStageEventCallbackDelegate != null)
                {
                    OnStageSignal().Disconnect(_viewOffStageEventCallbackDelegate);
                }
            }
        }

        // Callback for View OffStage signal
        private void OffStage(IntPtr data)
        {
            OffStageEventArgs e = new OffStageEventArgs();

            // Populate all members of "e" (OffStageEventArgs) with real data
            e.View = View.GetViewFromPtr(data);

            if (_viewOffStageEventHandler != null)
            {
                //here we send all data to user event handlers
                _viewOffStageEventHandler(this, e);
            }
        }

        public static View GetViewFromPtr(global::System.IntPtr cPtr)
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


        public enum FocusDirection
        {
            Left,
            Right,
            Up,
            Down,
            PageUp,
            PageDown
        }


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

        public new static View DownCast(BaseHandle handle)
        {
            View ret = new View(NDalicPINVOKE.View_DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

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

        public void SetStyleName(string styleName)
        {
            NDalicPINVOKE.View_SetStyleName(swigCPtr, styleName);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

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

        public Color BackgroundColor
        {
            get
            {
                Color backgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);

                Tizen.NUI.PropertyMap background = Background;
                int visualType = 0;
                background.Find(Tizen.NUI.Constants.Visual.Property.Type).Get(ref visualType);
                if (visualType == (int)Tizen.NUI.Constants.Visual.Type.Color)
                {
                    background.Find(Tizen.NUI.Constants.ColorVisualProperty.MixColor).Get(backgroundColor);
                }

                return backgroundColor;
            }
            set
            {
                SetProperty(View.Property.BACKGROUND, new Tizen.NUI.PropertyValue(value));
            }
        }

        public string BackgroundImage
        {
            get
            {
                string backgroundImage = "";

                Tizen.NUI.PropertyMap background = Background;
                int visualType = 0;
                background.Find(Tizen.NUI.Constants.Visual.Property.Type).Get(ref visualType);
                if (visualType == (int)Tizen.NUI.Constants.Visual.Type.Image)
                {
                    background.Find(Tizen.NUI.Constants.ImageVisualProperty.URL).Get(out backgroundImage);
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

        /**
         * @brief The left focusable view.
         * @note This will return NULL if not set.
         * This will also return NULL if the specified left focusable view is not on stage.
         *
         */
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

        /**
         * @brief The right focusable view.
         * @note This will return NULL if not set.
         * This will also return NULL if the specified right focusable view is not on stage.
         *
         */
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

        /**
         * @brief The up focusable view.
         * @note This will return NULL if not set.
         * This will also return NULL if the specified up focusable view is not on stage.
         *
         */
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

        /**
         * @brief The down focusable view.
         * @note This will return NULL if not set.
         * This will also return NULL if the specified down focusable view is not on stage.
         *
         */
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
