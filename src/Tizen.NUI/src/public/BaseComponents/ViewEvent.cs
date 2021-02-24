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
using Tizen.NUI.Components;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// View is the base class for all views.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class View
    {
        private EventHandler _offWindowEventHandler;
        private OffWindowEventCallbackType _offWindowEventCallback;
        private EventHandlerWithReturnType<object, WheelEventArgs, bool> _wheelEventHandler;
        private WheelEventCallbackType _wheelEventCallback;
        private EventHandlerWithReturnType<object, KeyEventArgs, bool> _keyEventHandler;
        private KeyCallbackType _keyCallback;
        private EventHandlerWithReturnType<object, TouchEventArgs, bool> _interceptTouchDataEventHandler;
        private TouchDataCallbackType _interceptTouchDataCallback;
        private EventHandlerWithReturnType<object, TouchEventArgs, bool> _touchDataEventHandler;
        private TouchDataCallbackType _touchDataCallback;
        private EventHandlerWithReturnType<object, HoverEventArgs, bool> _hoverEventHandler;
        private HoverEventCallbackType _hoverEventCallback;
        private EventHandler<VisibilityChangedEventArgs> _visibilityChangedEventHandler;
        private VisibilityChangedEventCallbackType _visibilityChangedEventCallback;
        private EventHandler _keyInputFocusGainedEventHandler;
        private KeyInputFocusGainedCallbackType _keyInputFocusGainedCallback;
        private EventHandler _keyInputFocusLostEventHandler;
        private KeyInputFocusLostCallbackType _keyInputFocusLostCallback;
        private EventHandler _onRelayoutEventHandler;
        private OnRelayoutEventCallbackType _onRelayoutEventCallback;
        private EventHandler _onWindowEventHandler;
        private OnWindowEventCallbackType _onWindowEventCallback;
        private EventHandler<LayoutDirectionChangedEventArgs> _layoutDirectionChangedEventHandler;
        private LayoutDirectionChangedEventCallbackType _layoutDirectionChangedEventCallback;
        // Resource Ready Signal
        private EventHandler _resourcesLoadedEventHandler;
        private ResourcesLoadedCallbackType _ResourcesLoadedCallback;
        private EventHandler<BackgroundResourceLoadedEventArgs> _backgroundResourceLoadedEventHandler;
        private _backgroundResourceLoadedCallbackType _backgroundResourceLoadedCallback;

        private void SendViewAddedEventToWindow(IntPtr data)
        {
            // Unused parameter
            _ = data;

            NUIApplication.GetDefaultWindow()?.SendViewAdded(this);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void OffWindowEventCallbackType(IntPtr control);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool WheelEventCallbackType(IntPtr view, IntPtr wheelEvent);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool KeyCallbackType(IntPtr control, IntPtr keyEvent);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool TouchDataCallbackType(IntPtr view, IntPtr touchData);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool HoverEventCallbackType(IntPtr view, IntPtr hoverEvent);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void VisibilityChangedEventCallbackType(IntPtr data, bool visibility, VisibilityChangeType type);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ResourcesLoadedCallbackType(IntPtr control);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void _backgroundResourceLoadedCallbackType(IntPtr view);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void KeyInputFocusGainedCallbackType(IntPtr control);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void KeyInputFocusLostCallbackType(IntPtr control);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void OnRelayoutEventCallbackType(IntPtr control);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void OnWindowEventCallbackType(IntPtr control);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void LayoutDirectionChangedEventCallbackType(IntPtr data, ViewLayoutDirectionType type);

        /// <summary>
        /// Event when a child is removed.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public new event EventHandler<ChildRemovedEventArgs> ChildRemoved;
        /// <summary>
        /// Event when a child is added.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public new event EventHandler<ChildAddedEventArgs> ChildAdded;

        /// <summary>
        /// An event for the KeyInputFocusGained signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// The KeyInputFocusGained signal is emitted when the control gets the key input focus.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// An event for the KeyInputFocusLost signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// The KeyInputFocusLost signal is emitted when the control loses the key input focus.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// An event for the KeyPressed signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// The KeyPressed signal is emitted when the key event is received.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

                if (_keyEventHandler == null && KeyEventSignal().Empty() == false)
                {
                    this.KeyEventSignal().Disconnect(_keyCallback);
                }
            }
        }

        /// <summary>
        /// An event for the OnRelayout signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// The OnRelayout signal is emitted after the size has been set on the view during relayout.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
                    _onRelayoutEventCallback = null;
                }

            }
        }

        /// <summary>
        /// An event for the touched signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// The touched signal is emitted when the touch input is received.<br />
        /// This can receive touch events before child. <br />
        /// If it returns false, the child can receive the touch event. If it returns true, the touch event is intercepted. So child cannot receive touch event.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, TouchEventArgs, bool> InterceptTouchEvent
        {
            add
            {
                if (_interceptTouchDataEventHandler == null)
                {
                    _interceptTouchDataCallback = OnInterceptTouch;
                    this.InterceptTouchSignal().Connect(_interceptTouchDataCallback);
                }

                _interceptTouchDataEventHandler += value;
            }

            remove
            {
                _interceptTouchDataEventHandler -= value;

                if (_interceptTouchDataEventHandler == null && InterceptTouchSignal().Empty() == false)
                {
                    this.InterceptTouchSignal().Disconnect(_interceptTouchDataCallback);
                }
            }
        }

        /// <summary>
        /// If child view doesn't want the parent's view to intercept the touch, you can set it to true.
        /// for example :
        ///    parent.Add(child);
        ///    parent.InterceptTouchEvent += OnInterceptTouchEvent;
        ///    View view = child.GetParent() as View;
        ///    view.DisallowInterceptTouchEvent = true;
        ///  This prevents the parent from interceping touch.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DisallowInterceptTouchEvent { get; set; }


        /// <summary>
        /// An event for the touched signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// The touched signal is emitted when the touch input is received.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandlerWithReturnType<object, TouchEventArgs, bool> TouchEvent
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

        /// <summary>
        /// An event for the hovered signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// The hovered signal is emitted when the hover input is received.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandlerWithReturnType<object, HoverEventArgs, bool> HoverEvent
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

        /// <summary>
        /// An event for the WheelMoved signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// The WheelMoved signal is emitted when the wheel event is received.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandlerWithReturnType<object, WheelEventArgs, bool> WheelEvent
        {
            add
            {
                if (_wheelEventHandler == null)
                {
                    _wheelEventCallback = OnWheelEvent;
                    this.WheelEventSignal().Connect(_wheelEventCallback);
                }
                _wheelEventHandler += value;

                if (WindowWheelEventHandler == null)
                {
                    NUIApplication.GetDefaultWindow().WheelEvent += OnWindowWheelEvent;
                }
                WindowWheelEventHandler += value;
            }

            remove
            {
                _wheelEventHandler -= value;
                if (_wheelEventHandler == null && WheelEventSignal().Empty() == false)
                {
                    this.WheelEventSignal().Disconnect(_wheelEventCallback);
                }

                WindowWheelEventHandler -= value;
                if (WindowWheelEventHandler == null)
                {
                    NUIApplication.GetDefaultWindow().WheelEvent -= OnWindowWheelEvent;
                }
            }
        }

        /// <summary>
        /// An event for the OnWindow signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// The OnWindow signal is emitted after the view has been connected to the window.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
                    _onWindowEventCallback = null;
                }
            }
        }

        /// <summary>
        /// An event for the OffWindow signal, which can be used to subscribe or unsubscribe the event handler.<br />
        /// OffWindow signal is emitted after the view has been disconnected from the window.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
                    _offWindowEventCallback = null;
                }
            }
        }

        /// <summary>
        /// An event for visibility change which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when the visible property of this or a parent view is changed.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Event for layout direction change which can be used to subscribe/unsubscribe the event handler.<br />
        /// This signal is emitted when the layout direction property of this or a parent view is changed.<br />
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<LayoutDirectionChangedEventArgs> LayoutDirectionChanged
        {
            add
            {
                if (_layoutDirectionChangedEventHandler == null)
                {
                    _layoutDirectionChangedEventCallback = OnLayoutDirectionChanged;
                    LayoutDirectionChangedSignal(this).Connect(_layoutDirectionChangedEventCallback);
                }

                _layoutDirectionChangedEventHandler += value;
            }

            remove
            {
                _layoutDirectionChangedEventHandler -= value;

                if (_layoutDirectionChangedEventHandler == null && LayoutDirectionChangedSignal(this).Empty() == false)
                {
                    LayoutDirectionChangedSignal(this).Disconnect(_layoutDirectionChangedEventCallback);
                }
            }
        }

        /// <summary>
        /// An event for the ResourcesLoadedSignal signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// This signal is emitted after all resources required by a view are loaded and ready.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
                    _ResourcesLoadedCallback = null;
                }
            }
        }

        private EventHandler _backKeyPressed;

        /// <summary>
        /// An event for getting notice when physical back key is pressed.<br />
        /// This event is emitted BackKey is up.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler BackKeyPressed
        {
            add
            {
                _backKeyPressed += value;
                BackKeyManager.Instance.Subscriber.Add(this);
            }

            remove
            {
                BackKeyManager.Instance.Subscriber.Remove(this);
                _backKeyPressed -= value;
            }
        }

        /// <summary>
        /// Function for emitting BackKeyPressed event outside of View instance
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void EmitBackKeyPressed()
        {
            _backKeyPressed.Invoke(this, null);
        }


        internal event EventHandler<BackgroundResourceLoadedEventArgs> BackgroundResourceLoaded
        {
            add
            {
                if (_backgroundResourceLoadedEventHandler == null)
                {
                    _backgroundResourceLoadedCallback = OnBackgroundResourceLoaded;
                    this.ResourcesLoadedSignal().Connect(_backgroundResourceLoadedCallback);
                }

                _backgroundResourceLoadedEventHandler += value;
            }
            remove
            {
                _backgroundResourceLoadedEventHandler -= value;

                if (_backgroundResourceLoadedEventHandler == null && ResourcesLoadedSignal().Empty() == false)
                {
                    this.ResourcesLoadedSignal().Disconnect(_backgroundResourceLoadedCallback);
                    _backgroundResourceLoadedCallback = null;
                }
            }
        }

        internal TouchDataSignal InterceptTouchSignal()
        {
            TouchDataSignal ret = new TouchDataSignal(Interop.ActorSignal.ActorInterceptTouchSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TouchDataSignal TouchSignal()
        {
            TouchDataSignal ret = new TouchDataSignal(Interop.ActorSignal.ActorTouchSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal HoverSignal HoveredSignal()
        {
            HoverSignal ret = new HoverSignal(Interop.ActorSignal.ActorHoveredSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WheelSignal WheelEventSignal()
        {
            WheelSignal ret = new WheelSignal(Interop.ActorSignal.ActorWheelEventSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ViewSignal OnWindowSignal()
        {
            ViewSignal ret = new ViewSignal(Interop.ActorSignal.ActorOnSceneSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ViewSignal OffWindowSignal()
        {
            ViewSignal ret = new ViewSignal(Interop.ActorSignal.ActorOffSceneSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ViewSignal OnRelayoutSignal()
        {
            ViewSignal ret = new ViewSignal(Interop.ActorSignal.ActorOnRelayoutSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ViewVisibilityChangedSignal VisibilityChangedSignal(View view)
        {
            ViewVisibilityChangedSignal ret = new ViewVisibilityChangedSignal(Interop.NDalic.VisibilityChangedSignal(View.getCPtr(view)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ViewLayoutDirectionChangedSignal LayoutDirectionChangedSignal(View view)
        {
            ViewLayoutDirectionChangedSignal ret = new ViewLayoutDirectionChangedSignal(Interop.Layout.LayoutDirectionChangedSignal(View.getCPtr(view)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ViewSignal ResourcesLoadedSignal()
        {
            ViewSignal ret = new ViewSignal(Interop.View.ResourceReadySignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ControlKeySignal KeyEventSignal()
        {
            ControlKeySignal ret = new ControlKeySignal(Interop.ViewSignal.KeyEventSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal KeyInputFocusSignal KeyInputFocusGainedSignal()
        {
            KeyInputFocusSignal ret = new KeyInputFocusSignal(Interop.ViewSignal.KeyInputFocusGainedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal KeyInputFocusSignal KeyInputFocusLostSignal()
        {
            KeyInputFocusSignal ret = new KeyInputFocusSignal(Interop.ViewSignal.KeyInputFocusLostSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void OnSize2DChanged(int? width, int? height)
        {
            PropertyValue temp;
            if (width != null)
            {
                temp = new Tizen.NUI.PropertyValue((float)width);
                Tizen.NUI.Object.SetProperty(this.SwigCPtr, View.Property.SizeWidth, temp);
                temp.Dispose();
            }
            if (height != null)
            {
                temp = new Tizen.NUI.PropertyValue((float)height);
                Tizen.NUI.Object.SetProperty(this.SwigCPtr, View.Property.SizeHeight, temp);
                temp.Dispose();
            }
        }

        private void OnMinimumSizeChanged(int? width, int? height)
        {
            if (width != null && height != null)
            {
                MinimumSize = new Size2D((int)width, (int)height);
            }
            else if (width != null && height == null)
            {
                MinimumSize = new Size2D((int)width, (int)this.GetMinimumSize().Height);
            }
            else if (width == null && height != null)
            {
                MinimumSize = new Size2D((int)this.GetMinimumSize().Width, (int)height);
            }
            else
            {
                //both are null, do nothing.
            }
        }

        private void OnMaximumSizeChanged(int? width, int? height)
        {
            if (width != null && height != null)
            {
                MaximumSize = new Size2D((int)width, (int)height);
            }
            else if (width != null && height == null)
            {
                MaximumSize = new Size2D((int)width, (int)this.GetMaximumSize().Height);
            }
            else if (width == null && height != null)
            {
                MaximumSize = new Size2D((int)this.GetMaximumSize().Width, (int)height);
            }
            else
            {
                //both are null, do nothing.
            }
        }

        private void OnPosition2DChanged(int x, int y)
        {
            Position2D = new Position2D(x, y);
        }

        private void OnSizeChanged(float? width, float? height, float? depth)
        {
            PropertyValue temp;
            if (width != null)
            {
                temp = new Tizen.NUI.PropertyValue((float)width);
                Tizen.NUI.Object.SetProperty(this.SwigCPtr, View.Property.SizeWidth, temp);
                temp.Dispose();
            }
            if (height != null)
            {
                temp = new Tizen.NUI.PropertyValue((float)height);
                Tizen.NUI.Object.SetProperty(this.SwigCPtr, View.Property.SizeHeight, temp);
                temp.Dispose();
            }
            if (depth != null)
            {
                temp = new Tizen.NUI.PropertyValue((float)depth);
                Tizen.NUI.Object.SetProperty(this.SwigCPtr, View.Property.SizeDepth, temp);
                temp.Dispose();
            }
        }

        private void OnPositionChanged(float x, float y, float z)
        {
            Position = new Position(x, y, z);
        }

        private void OnParentOriginChanged(float x, float y, float z)
        {
            ParentOrigin = new Position(x, y, z);
        }

        private void OnPivotPointChanged(float x, float y, float z)
        {
            PivotPoint = new Position(x, y, z);
        }

        private void OnImageShadowChanged(ShadowBase instance)
        {
            ImageShadow = (ImageShadow)instance;
        }

        private void OnBoxShadowChanged(ShadowBase instance)
        {
            BoxShadow = (Shadow)instance;
        }

        private void OnBackgroundImageBorderChanged(int left, int right, int bottom, int top)
        {
            BackgroundImageBorder = new Rectangle(left, right, bottom, top);
        }

        private void OnKeyInputFocusGained(IntPtr view)
        {
            if (_keyInputFocusGainedEventHandler != null)
            {
                _keyInputFocusGainedEventHandler(this, null);
            }
        }

        private void OnKeyInputFocusLost(IntPtr view)
        {
            if (_keyInputFocusLostEventHandler != null)
            {
                _keyInputFocusLostEventHandler(this, null);
            }
        }

        private bool OnKeyEvent(IntPtr view, IntPtr keyEvent)
        {
            if (keyEvent == global::System.IntPtr.Zero)
            {
                NUILog.Error("keyEvent should not be null!");
                return true;
            }

            KeyEventArgs e = new KeyEventArgs();

            bool result = false;

            e.Key = Tizen.NUI.Key.GetKeyFromPtr(keyEvent);

            if (_keyEventHandler != null)
            {
                Delegate[] delegateList = _keyEventHandler.GetInvocationList();

                // Oring the result of each callback.
                foreach (EventHandlerWithReturnType<object, KeyEventArgs, bool> del in delegateList)
                {
                    result |= del(this, e);
                }
            }

            return result;
        }

        // Callback for View OnRelayout signal
        private void OnRelayout(IntPtr data)
        {
            if (_onRelayoutEventHandler != null)
            {
                _onRelayoutEventHandler(this, null);
            }
        }

        // Callback for View TouchSignal
        private bool OnInterceptTouch(IntPtr view, IntPtr touchData)
        {
            if (touchData == global::System.IntPtr.Zero)
            {
                NUILog.Error("touchData should not be null!");
                return true;
            }

            // DisallowInterceptTouchEvent prevents the parent from intercepting touch.
            if (DisallowInterceptTouchEvent)
            {
                return false;
            }

            TouchEventArgs e = new TouchEventArgs();

            e.Touch = Tizen.NUI.Touch.GetTouchFromPtr(touchData);

            bool consumed = false;

            if (_interceptTouchDataEventHandler != null)
            {
                consumed = _interceptTouchDataEventHandler(this, e);
            }

            return consumed;
        }

        // Callback for View TouchSignal
        private bool OnTouch(IntPtr view, IntPtr touchData)
        {
            if (touchData == global::System.IntPtr.Zero)
            {
                NUILog.Error("touchData should not be null!");
                return true;
            }

            TouchEventArgs e = new TouchEventArgs();

            e.Touch = Tizen.NUI.Touch.GetTouchFromPtr(touchData);

            bool consumed = false;

            if (_touchDataEventHandler != null)
            {
                consumed = _touchDataEventHandler(this, e);
            }

            if (enableControlState && !consumed)
            {
                consumed = HandleControlStateOnTouch(e.Touch);
            }

            return consumed;
        }

        // Callback for View Hover signal
        private bool OnHoverEvent(IntPtr view, IntPtr hoverEvent)
        {
            if (hoverEvent == global::System.IntPtr.Zero)
            {
                NUILog.Error("hoverEvent should not be null!");
                return true;
            }

            HoverEventArgs e = new HoverEventArgs();

            e.Hover = Tizen.NUI.Hover.GetHoverFromPtr(hoverEvent);

            if (_hoverEventHandler != null)
            {
                return _hoverEventHandler(this, e);
            }
            return false;
        }

        // Callback for View Wheel signal
        private bool OnWheelEvent(IntPtr view, IntPtr wheelEvent)
        {
            if (wheelEvent == global::System.IntPtr.Zero)
            {
                NUILog.Error("wheelEvent should not be null!");
                return true;
            }

            WheelEventArgs e = new WheelEventArgs();

            e.Wheel = Tizen.NUI.Wheel.GetWheelFromPtr(wheelEvent);

            if (_wheelEventHandler != null)
            {
                return _wheelEventHandler(this, e);
            }
            return false;
        }

        // Callback for View OnWindow signal
        private void OnWindow(IntPtr data)
        {
            if (_onWindowEventHandler != null)
            {
                _onWindowEventHandler(this, null);
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

        // Callback for View layout direction change signal
        private void OnLayoutDirectionChanged(IntPtr data, ViewLayoutDirectionType type)
        {
            LayoutDirectionChangedEventArgs e = new LayoutDirectionChangedEventArgs();
            if (data != null)
            {
                e.View = Registry.GetManagedBaseHandleFromNativePtr(data) as View;
            }
            e.Type = type;

            if (_layoutDirectionChangedEventHandler != null)
            {
                _layoutDirectionChangedEventHandler(this, e);
            }
        }

        private void OnResourcesLoaded(IntPtr view)
        {
            if (_resourcesLoadedEventHandler != null)
            {
                _resourcesLoadedEventHandler(this, null);
            }
        }

        private void OnBackgroundResourceLoaded(IntPtr view)
        {
            BackgroundResourceLoadedEventArgs e = new BackgroundResourceLoadedEventArgs();
            e.Status = (ResourceLoadingStatusType)Interop.View.GetVisualResourceStatus(this.SwigCPtr, Property.BACKGROUND);

            if (_backgroundResourceLoadedEventHandler != null)
            {
                _backgroundResourceLoadedEventHandler(this, e);
            }
        }

        /// <summary>
        /// Event argument passed through the ChildAdded event.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public class ChildAddedEventArgs : EventArgs
        {
            /// <summary>
            /// Added child view at moment.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public View Added { get; set; }
        }

        /// <summary>
        /// Event argument passed through the ChildRemoved event.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public class ChildRemovedEventArgs : EventArgs
        {
            /// <summary>
            /// Removed child view at moment.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public View Removed { get; set; }
        }

        /// <summary>
        /// Event arguments that passed via the KeyEvent signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class KeyEventArgs : EventArgs
        {
            private Key _key;

            /// <summary>
            /// Key - is the key sent to the view.
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
        /// Event arguments that passed via the touch signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class TouchEventArgs : EventArgs
        {
            private Touch _touch;

            /// <summary>
            /// Touch - contains the information of touch points.
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
        /// Event arguments that passed via the hover signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class HoverEventArgs : EventArgs
        {
            private Hover _hover;

            /// <summary>
            /// Hover - contains touch points that represent the points that are currently being hovered or the points where a hover has stopped.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Event arguments that passed via the wheel signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class WheelEventArgs : EventArgs
        {
            private Wheel _wheel;

            /// <summary>
            /// WheelEvent - store a wheel rolling type: MOUSE_WHEEL or CUSTOM_WHEEL.
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
        /// Event arguments of visibility changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class VisibilityChangedEventArgs : EventArgs
        {
            private View _view;
            private bool _visibility;
            private VisibilityChangeType _type;

            /// <summary>
            /// The view, or child of view, whose visibility has changed.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
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
            /// <since_tizen> 3 </since_tizen>
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
            /// <since_tizen> 3 </since_tizen>
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

        /// <summary>
        /// Event arguments of layout direction changed.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public class LayoutDirectionChangedEventArgs : EventArgs
        {
            private View _view;
            private ViewLayoutDirectionType _type;

            /// <summary>
            /// The view, or child of view, whose layout direction has changed.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
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
            /// Whether the view's layout direction property has changed or a parent's.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public ViewLayoutDirectionType Type
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

        internal class BackgroundResourceLoadedEventArgs : EventArgs
        {
            private ResourceLoadingStatusType status = ResourceLoadingStatusType.Invalid;
            public ResourceLoadingStatusType Status
            {
                get
                {
                    return status;
                }
                set
                {
                    status = value;
                }
            }
        }

        /// <summary>
        /// The class represents the information of the situation where the View's control state changes.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ControlStateChangedEventArgs : EventArgs
        {
            /// <summary>
            /// Create an instance with mandatory fields.
            /// </summary>
            /// <param name="previousState">The previous control state.</param>
            /// <param name="currentState">The current control state.</param>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ControlStateChangedEventArgs(ControlState previousState, ControlState currentState)
            {
                PreviousState = previousState;
                CurrentState = currentState;
            }

            /// <summary>
            /// The previous control state.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ControlState PreviousState { get; }

            /// <summary>
            /// The current control state.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ControlState CurrentState { get; }
        }

        private EventHandlerWithReturnType<object, WheelEventArgs, bool> WindowWheelEventHandler;
        private void OnWindowWheelEvent(object sender, Window.WheelEventArgs e)
        {
            if (e != null)
            {
                if (e.Wheel.Type == Wheel.WheelType.CustomWheel)
                {
                    var arg = new WheelEventArgs()
                    {
                        Wheel = e.Wheel,
                    };
                    WindowWheelEventHandler?.Invoke(this, arg);
                }
            }
        }

    }
}
