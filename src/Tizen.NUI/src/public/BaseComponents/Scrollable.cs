/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// Base class for derived Scrollables that contains actors that can be scrolled manually
    /// (via touch) or automatically.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Scrollable : View
    {
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OvershootEffectColorProperty = BindableProperty.Create("OvershootEffectColor", typeof(Vector4), typeof(Scrollable), Vector4.Zero, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollable = (Scrollable)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollable.swigCPtr, Scrollable.Property.OVERSHOOT_EFFECT_COLOR, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var scrollable = (Scrollable)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(scrollable.swigCPtr, Scrollable.Property.OVERSHOOT_EFFECT_COLOR).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OvershootAnimationSpeedProperty = BindableProperty.Create("OvershootAnimationSpeed", typeof(float), typeof(Scrollable), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollable = (Scrollable)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollable.swigCPtr, Scrollable.Property.OVERSHOOT_ANIMATION_SPEED, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var scrollable = (Scrollable)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(scrollable.swigCPtr, Scrollable.Property.OVERSHOOT_ANIMATION_SPEED).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OvershootEnabledProperty = BindableProperty.Create("OvershootEnabled", typeof(bool), typeof(Scrollable), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollable = (Scrollable)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollable.swigCPtr, Scrollable.Property.OVERSHOOT_ENABLED, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var scrollable = (Scrollable)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(scrollable.swigCPtr, Scrollable.Property.OVERSHOOT_ENABLED).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OvershootSizeProperty = BindableProperty.Create("OvershootSize", typeof(Vector2), typeof(Scrollable), Vector2.Zero, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollable = (Scrollable)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollable.swigCPtr, Scrollable.Property.OVERSHOOT_SIZE, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var scrollable = (Scrollable)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(scrollable.swigCPtr, Scrollable.Property.OVERSHOOT_SIZE).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollToAlphaFunctionProperty = BindableProperty.Create("ScrollToAlphaFunction", typeof(int), typeof(Scrollable), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollable = (Scrollable)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollable.swigCPtr, Scrollable.Property.SCROLL_TO_ALPHA_FUNCTION, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var scrollable = (Scrollable)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(scrollable.swigCPtr, Scrollable.Property.SCROLL_TO_ALPHA_FUNCTION).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollRelativePositionProperty = BindableProperty.Create("ScrollRelativePosition", typeof(Vector2), typeof(Scrollable), Vector2.Zero, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollable = (Scrollable)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollable.swigCPtr, Scrollable.Property.SCROLL_RELATIVE_POSITION, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var scrollable = (Scrollable)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(scrollable.swigCPtr, Scrollable.Property.SCROLL_RELATIVE_POSITION).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollPositionMinProperty = BindableProperty.Create("ScrollPositionMin", typeof(Vector2), typeof(Scrollable), Vector2.Zero, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollable = (Scrollable)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollable.swigCPtr, Scrollable.Property.SCROLL_POSITION_MIN, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var scrollable = (Scrollable)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(scrollable.swigCPtr, Scrollable.Property.SCROLL_POSITION_MIN).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollPositionMaxProperty = BindableProperty.Create("ScrollPositionMax", typeof(Vector2), typeof(Scrollable), Vector2.Zero, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollable = (Scrollable)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollable.swigCPtr, Scrollable.Property.SCROLL_POSITION_MAX, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var scrollable = (Scrollable)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(scrollable.swigCPtr, Scrollable.Property.SCROLL_POSITION_MAX).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CanScrollVerticalProperty = BindableProperty.Create("CanScrollVertical", typeof(bool), typeof(Scrollable), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollable = (Scrollable)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollable.swigCPtr, Scrollable.Property.CAN_SCROLL_VERTICAL, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var scrollable = (Scrollable)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(scrollable.swigCPtr, Scrollable.Property.CAN_SCROLL_VERTICAL).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CanScrollHorizontalProperty = BindableProperty.Create("CanScrollHorizontal", typeof(bool), typeof(Scrollable), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollable = (Scrollable)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollable.swigCPtr, Scrollable.Property.CAN_SCROLL_HORIZONTAL, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var scrollable = (Scrollable)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(scrollable.swigCPtr, Scrollable.Property.CAN_SCROLL_HORIZONTAL).Get(out temp);
            return temp;
        });

        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal Scrollable(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.Scrollable_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Scrollable obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// you can override it to clean-up your own resources.
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.

            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            if (this != null)
            {
                DisConnectFromSignals();
            }

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_Scrollable(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        private void DisConnectFromSignals()
        {
            // Save current CPtr.
            global::System.Runtime.InteropServices.HandleRef currentCPtr = swigCPtr;

            // Use BaseHandle CPtr as current might have been deleted already in derived classes.
            swigCPtr = GetBaseHandleCPtrHandleRef;

            if (_scrollableCompletedCallbackDelegate != null)
            {
                this.ScrollCompletedSignal().Disconnect(_scrollableCompletedCallbackDelegate);
            }

            if (_scrollableUpdatedCallbackDelegate != null)
            {
                this.ScrollUpdatedSignal().Disconnect(_scrollableUpdatedCallbackDelegate);
            }

            if (_scrollableStartedCallbackDelegate != null)
            {
                this.ScrollStartedSignal().Disconnect(_scrollableStartedCallbackDelegate);
            }

            // BaseHandle CPtr is used in Registry and there is danger of deletion if we keep using it here.
            // Restore current CPtr.
            swigCPtr = currentCPtr;
        }

        /// <summary>
        /// The scroll animation started event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class StartedEventArgs : EventArgs
        {
            private Vector2 _vector2;

            /// <summary>
            /// Vector2.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public Vector2 Vector2
            {
                get
                {
                    return _vector2;
                }
                set
                {
                    _vector2 = value;
                }
            }
        }

        /// <summary>
        /// The scrollable updated event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class UpdatedEventArgs : EventArgs
        {
            private Vector2 _vector2;

            /// <summary>
            /// Vector2.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public Vector2 Vector2
            {
                get
                {
                    return _vector2;
                }
                set
                {
                    _vector2 = value;
                }
            }
        }

        /// <summary>
        /// The scroll animation completed event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class CompletedEventArgs : EventArgs
        {
            private Vector2 _vector2;

            /// <summary>
            /// Vector2.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public Vector2 Vector2
            {
                get
                {
                    return _vector2;
                }
                set
                {
                    _vector2 = value;
                }
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void StartedCallbackDelegate(IntPtr vector2);
        private DaliEventHandler<object, StartedEventArgs> _scrollableStartedEventHandler;
        private StartedCallbackDelegate _scrollableStartedCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void UpdatedCallbackDelegate(IntPtr vector2);
        private DaliEventHandler<object, UpdatedEventArgs> _scrollableUpdatedEventHandler;
        private UpdatedCallbackDelegate _scrollableUpdatedCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void CompletedCallbackDelegate(IntPtr vector2);
        private DaliEventHandler<object, CompletedEventArgs> _scrollableCompletedEventHandler;
        private CompletedCallbackDelegate _scrollableCompletedCallbackDelegate;

        /// <summary>
        /// The ScrollStarted event emitted when the Scrollable has moved (whether by touch or animation).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event DaliEventHandler<object, StartedEventArgs> ScrollStarted
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_scrollableStartedEventHandler == null)
                    {
                        _scrollableStartedEventHandler += value;

                        _scrollableStartedCallbackDelegate = new StartedCallbackDelegate(OnStarted);
                        this.ScrollStartedSignal().Connect(_scrollableStartedCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_scrollableStartedEventHandler != null)
                    {
                        this.ScrollStartedSignal().Disconnect(_scrollableStartedCallbackDelegate);
                    }

                    _scrollableStartedEventHandler -= value;
                }
            }
        }

        private void OnStarted(IntPtr vector2)
        {
            StartedEventArgs e = new StartedEventArgs();

            // Populate all members of "e" (StartedEventArgs) with real data
            e.Vector2 = Tizen.NUI.Vector2.GetVector2FromPtr(vector2);

            if (_scrollableStartedEventHandler != null)
            {
                //here we send all data to user event handlers
                _scrollableStartedEventHandler(this, e);
            }

        }

        /// <summary>
        /// The ScrollUpdated event emitted when the Scrollable has moved (whether by touch or animation).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event DaliEventHandler<object, UpdatedEventArgs> ScrollUpdated
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_scrollableUpdatedEventHandler == null)
                    {
                        _scrollableUpdatedEventHandler += value;

                        _scrollableUpdatedCallbackDelegate = new UpdatedCallbackDelegate(OnUpdated);
                        this.ScrollUpdatedSignal().Connect(_scrollableUpdatedCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_scrollableUpdatedEventHandler != null)
                    {
                        this.ScrollUpdatedSignal().Disconnect(_scrollableUpdatedCallbackDelegate);
                    }

                    _scrollableUpdatedEventHandler -= value;
                }
            }
        }

        private void OnUpdated(IntPtr vector2)
        {
            UpdatedEventArgs e = new UpdatedEventArgs();

            // Populate all members of "e" (UpdatedEventArgs) with real data
            e.Vector2 = Tizen.NUI.Vector2.GetVector2FromPtr(vector2);

            if (_scrollableUpdatedEventHandler != null)
            {
                //here we send all data to user event handlers
                _scrollableUpdatedEventHandler(this, e);
            }

        }

        /// <summary>
        /// The ScrollCompleted event emitted when the Scrollable has completed movement
        /// (whether by touch or animation).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event DaliEventHandler<object, CompletedEventArgs> ScrollCompleted
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_scrollableCompletedEventHandler == null)
                    {
                        _scrollableCompletedEventHandler += value;

                        _scrollableCompletedCallbackDelegate = new CompletedCallbackDelegate(OnCompleted);
                        this.ScrollCompletedSignal().Connect(_scrollableCompletedCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_scrollableCompletedEventHandler != null)
                    {
                        this.ScrollCompletedSignal().Disconnect(_scrollableCompletedCallbackDelegate);
                    }

                    _scrollableCompletedEventHandler -= value;
                }
            }
        }

        private void OnCompleted(IntPtr vector2)
        {
            CompletedEventArgs e = new CompletedEventArgs();

            // Populate all members of "e" (CompletedEventArgs) with real data
            e.Vector2 = Tizen.NUI.Vector2.GetVector2FromPtr(vector2);

            if (_scrollableCompletedEventHandler != null)
            {
                //here we send all data to user event handlers
                _scrollableCompletedEventHandler(this, e);
            }

        }

        /// <summary>
        /// Enumeration for the instance of properties belonging to the Scrollable class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public new class Property
        {
            /// <summary>
            /// The color of the overshoot effect.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int OVERSHOOT_EFFECT_COLOR = NDalicPINVOKE.Scrollable_Property_OVERSHOOT_EFFECT_COLOR_get();
            /// <summary>
            /// The speed of overshoot animation in pixels per second.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int OVERSHOOT_ANIMATION_SPEED = NDalicPINVOKE.Scrollable_Property_OVERSHOOT_ANIMATION_SPEED_get();
            /// <summary>
            /// Whether to enables or disable scroll overshoot.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int OVERSHOOT_ENABLED = NDalicPINVOKE.Scrollable_Property_OVERSHOOT_ENABLED_get();
            /// <summary>
            /// The size of the overshoot.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int OVERSHOOT_SIZE = NDalicPINVOKE.Scrollable_Property_OVERSHOOT_SIZE_get();
            /// <summary>
            /// scrollToAlphaFunction.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_TO_ALPHA_FUNCTION = NDalicPINVOKE.Scrollable_Property_SCROLL_TO_ALPHA_FUNCTION_get();
            /// <summary>
            /// scrollRelativePosition
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_RELATIVE_POSITION = NDalicPINVOKE.Scrollable_Property_SCROLL_RELATIVE_POSITION_get();
            /// <summary>
            /// scrollPositionMin
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_POSITION_MIN = NDalicPINVOKE.Scrollable_Property_SCROLL_POSITION_MIN_get();
            /// <summary>
            /// scrollPositionMinX.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_POSITION_MIN_X = NDalicPINVOKE.Scrollable_Property_SCROLL_POSITION_MIN_X_get();
            /// <summary>
            /// scrollPositionMinY.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_POSITION_MIN_Y = NDalicPINVOKE.Scrollable_Property_SCROLL_POSITION_MIN_Y_get();
            /// <summary>
            /// scrollPositionMax.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_POSITION_MAX = NDalicPINVOKE.Scrollable_Property_SCROLL_POSITION_MAX_get();
            /// <summary>
            /// scrollPositionMaxX.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_POSITION_MAX_X = NDalicPINVOKE.Scrollable_Property_SCROLL_POSITION_MAX_X_get();
            /// <summary>
            /// scrollPositionMaxY.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_POSITION_MAX_Y = NDalicPINVOKE.Scrollable_Property_SCROLL_POSITION_MAX_Y_get();
            /// <summary>
            /// canScrollVertical
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int CAN_SCROLL_VERTICAL = NDalicPINVOKE.Scrollable_Property_CAN_SCROLL_VERTICAL_get();
            /// <summary>
            /// canScrollHorizontal.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int CAN_SCROLL_HORIZONTAL = NDalicPINVOKE.Scrollable_Property_CAN_SCROLL_HORIZONTAL_get();

        }

        /// <summary>
        /// Create an instance of scrollable.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Scrollable() : this(NDalicPINVOKE.new_Scrollable__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private bool IsOvershootEnabled()
        {
            bool ret = NDalicPINVOKE.Scrollable_IsOvershootEnabled(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void SetOvershootEnabled(bool enable)
        {
            NDalicPINVOKE.Scrollable_SetOvershootEnabled(swigCPtr, enable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void SetOvershootEffectColor(Vector4 color)
        {
            NDalicPINVOKE.Scrollable_SetOvershootEffectColor(swigCPtr, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private Vector4 GetOvershootEffectColor()
        {
            Vector4 ret = new Vector4(NDalicPINVOKE.Scrollable_GetOvershootEffectColor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void SetOvershootAnimationSpeed(float pixelsPerSecond)
        {
            NDalicPINVOKE.Scrollable_SetOvershootAnimationSpeed(swigCPtr, pixelsPerSecond);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private float GetOvershootAnimationSpeed()
        {
            float ret = NDalicPINVOKE.Scrollable_GetOvershootAnimationSpeed(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ScrollableSignal ScrollStartedSignal()
        {
            ScrollableSignal ret = new ScrollableSignal(NDalicPINVOKE.Scrollable_ScrollStartedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ScrollableSignal ScrollUpdatedSignal()
        {
            ScrollableSignal ret = new ScrollableSignal(NDalicPINVOKE.Scrollable_ScrollUpdatedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ScrollableSignal ScrollCompletedSignal()
        {
            ScrollableSignal ret = new ScrollableSignal(NDalicPINVOKE.Scrollable_ScrollCompletedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets and Gets the color of the overshoot effect.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 OvershootEffectColor
        {
            get
            {
                return (Vector4)GetValue(OvershootEffectColorProperty);
            }
            set
            {
                SetValue(OvershootEffectColorProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Sets and Gets the speed of overshoot animation in pixels per second.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float OvershootAnimationSpeed
        {
            get
            {
                return (float)GetValue(OvershootAnimationSpeedProperty);
            }
            set
            {
                SetValue(OvershootAnimationSpeedProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Checks if scroll overshoot has been enabled or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool OvershootEnabled
        {
            get
            {
                return (bool)GetValue(OvershootEnabledProperty);
            }
            set
            {
                SetValue(OvershootEnabledProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and Sets OvershootSize property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 OvershootSize
        {
            get
            {
                return (Vector2)GetValue(OvershootSizeProperty);
            }
            set
            {
                SetValue(OvershootSizeProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and Sets ScrollToAlphaFunction property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int ScrollToAlphaFunction
        {
            get
            {
                return (int)GetValue(ScrollToAlphaFunctionProperty);
            }
            set
            {
                SetValue(ScrollToAlphaFunctionProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and Sets ScrollRelativePosition property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ScrollRelativePosition
        {
            get
            {
                return (Vector2)GetValue(ScrollRelativePositionProperty);
            }
            set
            {
                SetValue(ScrollRelativePositionProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and Sets ScrollPositionMin property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ScrollPositionMin
        {
            get
            {
                return (Vector2)GetValue(ScrollPositionMinProperty);
            }
            set
            {
                SetValue(ScrollPositionMinProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and Sets ScrollPositionMax property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ScrollPositionMax
        {
            get
            {
                return (Vector2)GetValue(ScrollPositionMaxProperty);
            }
            set
            {
                SetValue(ScrollPositionMaxProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and Sets CanScrollVertical property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool CanScrollVertical
        {
            get
            {
                return (bool)GetValue(CanScrollVerticalProperty);
            }
            set
            {
                SetValue(CanScrollVerticalProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets and Sets CanScrollHorizontal property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool CanScrollHorizontal
        {
            get
            {
                return (bool)GetValue(CanScrollHorizontalProperty);
            }
            set
            {
                SetValue(CanScrollHorizontalProperty, value);
                NotifyPropertyChanged();
            }
        }

    }

}