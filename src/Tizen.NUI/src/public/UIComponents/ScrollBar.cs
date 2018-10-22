/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Binding;

namespace Tizen.NUI.UIComponents
{
    /// <summary>
    /// The ScrollBar is a UI component that can be linked to the scrollable objects
    /// indicating the current scroll position of the scrollable object.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ScrollBar : View
    {
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollDirectionProperty = BindableProperty.Create("ScrollDirection", typeof(Direction), typeof(ScrollBar), Direction.Vertical, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollBar = (ScrollBar)bindable;
            string valueToString = "";
            if (newValue != null)
            {
                switch ((Direction)newValue)
                {
                    case Direction.Vertical: { valueToString = "Vertical"; break; }
                    case Direction.Horizontal: { valueToString = "Horizontal"; break; }
                    default: { valueToString = "Vertical"; break; }
                }
                Tizen.NUI.Object.SetProperty(scrollBar.swigCPtr, ScrollBar.Property.SCROLL_DIRECTION, new Tizen.NUI.PropertyValue(valueToString));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var scrollBar = (ScrollBar)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(scrollBar.swigCPtr, ScrollBar.Property.SCROLL_DIRECTION).Get(out temp) == false)
            {
                NUILog.Error("ScrollDirection get error!");
            }

            switch (temp)
            {
                case "Vertical": return Direction.Vertical;
                case "Horizontal": return Direction.Horizontal;
                default: return Direction.Vertical;
            }
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorHeightPolicyProperty = BindableProperty.Create("IndicatorHeightPolicy", typeof(IndicatorHeightPolicyType), typeof(ScrollBar), IndicatorHeightPolicyType.Variable, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollBar = (ScrollBar)bindable;
            string valueToString = "";
            if (newValue != null)
            {
                switch ((IndicatorHeightPolicyType)newValue)
                {
                    case IndicatorHeightPolicyType.Variable:{ valueToString = "Variable"; break; }
                    case IndicatorHeightPolicyType.Fixed: { valueToString = "Fixed"; break; }
                    default:  { valueToString = "Variable"; break; }
                }
                Tizen.NUI.Object.SetProperty(scrollBar.swigCPtr, ScrollBar.Property.INDICATOR_HEIGHT_POLICY, new Tizen.NUI.PropertyValue(valueToString));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var scrollBar = (ScrollBar)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(scrollBar.swigCPtr, ScrollBar.Property.INDICATOR_HEIGHT_POLICY).Get(out temp) == false)
            {
                NUILog.Error("IndicatorHeightPolicy get error!");
            }

            switch (temp)
            {
                case "Variable": return IndicatorHeightPolicyType.Variable;
                case "Fixed": return IndicatorHeightPolicyType.Fixed;
                default: return IndicatorHeightPolicyType.Variable;
            }
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorFixedHeightProperty = BindableProperty.Create("IndicatorFixedHeight", typeof(float), typeof(ScrollBar), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollBar = (ScrollBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollBar.swigCPtr, ScrollBar.Property.INDICATOR_FIXED_HEIGHT, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var scrollBar = (ScrollBar)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(scrollBar.swigCPtr, ScrollBar.Property.INDICATOR_FIXED_HEIGHT).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorShowDurationProperty = BindableProperty.Create("IndicatorShowDuration", typeof(float), typeof(ScrollBar), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollBar = (ScrollBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollBar.swigCPtr, ScrollBar.Property.INDICATOR_SHOW_DURATION, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var scrollBar = (ScrollBar)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(scrollBar.swigCPtr, ScrollBar.Property.INDICATOR_SHOW_DURATION).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorHideDurationProperty = BindableProperty.Create("IndicatorHideDuration", typeof(float), typeof(ScrollBar), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollBar = (ScrollBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollBar.swigCPtr, ScrollBar.Property.INDICATOR_HIDE_DURATION, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var scrollBar = (ScrollBar)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(scrollBar.swigCPtr, ScrollBar.Property.INDICATOR_HIDE_DURATION).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollPositionIntervalsProperty = BindableProperty.Create("ScrollPositionIntervals", typeof(PropertyArray), typeof(ScrollBar), new PropertyArray(), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollBar = (ScrollBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollBar.swigCPtr, ScrollBar.Property.SCROLL_POSITION_INTERVALS, new Tizen.NUI.PropertyValue((PropertyArray)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var scrollBar = (ScrollBar)bindable;
            Tizen.NUI.PropertyArray temp = new Tizen.NUI.PropertyArray();
            Tizen.NUI.Object.GetProperty(scrollBar.swigCPtr, ScrollBar.Property.SCROLL_POSITION_INTERVALS).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorMinimumHeightProperty = BindableProperty.Create("IndicatorMinimumHeight", typeof(float), typeof(ScrollBar), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollBar = (ScrollBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollBar.swigCPtr, ScrollBar.Property.INDICATOR_MINIMUM_HEIGHT, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var scrollBar = (ScrollBar)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(scrollBar.swigCPtr, ScrollBar.Property.INDICATOR_MINIMUM_HEIGHT).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorStartPaddingProperty = BindableProperty.Create("IndicatorStartPadding", typeof(float), typeof(ScrollBar), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollBar = (ScrollBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollBar.swigCPtr, ScrollBar.Property.INDICATOR_START_PADDING, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var scrollBar = (ScrollBar)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(scrollBar.swigCPtr, ScrollBar.Property.INDICATOR_START_PADDING).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorEndPaddingProperty = BindableProperty.Create("IndicatorEndPadding", typeof(float), typeof(ScrollBar), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollBar = (ScrollBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollBar.swigCPtr, ScrollBar.Property.INDICATOR_END_PADDING, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator:(bindable) =>
        {
            var scrollBar = (ScrollBar)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(scrollBar.swigCPtr, ScrollBar.Property.INDICATOR_END_PADDING).Get(out temp);
            return temp;
        });

        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal ScrollBar(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.ScrollBar_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ScrollBar obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// To dispose the ScrollBar instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
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
            if (this != null)
            {
                if (_scrollBarScrollPositionIntervalReachedEventCallbackDelegate != null)
                {
                    ScrollPositionIntervalReachedSignal().Disconnect(_scrollBarScrollPositionIntervalReachedEventCallbackDelegate);
                }

                if (_scrollBarPanFinishedEventCallbackDelegate != null)
                {
                    PanFinishedSignal().Disconnect(_scrollBarPanFinishedEventCallbackDelegate);
                }
            }

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_ScrollBar(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Event arguments that passed via the PanFinished event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class PanFinishedEventArgs : EventArgs
        {
        }

        /// <summary>
        /// Event arguments that passed via the ScrollPositionIntervalReached event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class ScrollIntervalEventArgs : EventArgs
        {
            private float _currentScrollPosition;

            /// <summary>
            /// The current scroll position of the scrollable content.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public float CurrentScrollPosition
            {
                get
                {
                    return _currentScrollPosition;
                }
                set
                {
                    _currentScrollPosition = value;
                }
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void PanFinishedEventCallbackDelegate();
        private EventHandler<PanFinishedEventArgs> _scrollBarPanFinishedEventHandler;
        private PanFinishedEventCallbackDelegate _scrollBarPanFinishedEventCallbackDelegate;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ScrollPositionIntervalReachedEventCallbackDelegate();
        private EventHandler<ScrollIntervalEventArgs> _scrollBarScrollPositionIntervalReachedEventHandler;
        private ScrollPositionIntervalReachedEventCallbackDelegate _scrollBarScrollPositionIntervalReachedEventCallbackDelegate;

        /// <summary>
        /// The event emitted when panning is finished on the scroll indicator.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<PanFinishedEventArgs> PanFinished
        {
            add
            {
                if (_scrollBarPanFinishedEventHandler == null)
                {
                    _scrollBarPanFinishedEventCallbackDelegate = (OnScrollBarPanFinished);
                    PanFinishedSignal().Connect(_scrollBarPanFinishedEventCallbackDelegate);
                }
                _scrollBarPanFinishedEventHandler += value;
            }
            remove
            {
                _scrollBarPanFinishedEventHandler -= value;
                if (_scrollBarPanFinishedEventHandler == null && PanFinishedSignal().Empty() == false)
                {
                    PanFinishedSignal().Disconnect(_scrollBarPanFinishedEventCallbackDelegate);
                }
            }
        }

        // Callback for ScrollBar PanFinishedSignal
        private void OnScrollBarPanFinished()
        {
            PanFinishedEventArgs e = new PanFinishedEventArgs();

            if (_scrollBarPanFinishedEventHandler != null)
            {
                //here we send all data to user event handlers
                _scrollBarPanFinishedEventHandler(this, e);
            }
        }


        /// <summary>
        /// This is the event emitted when the current scroll position of the scrollable content.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ScrollIntervalEventArgs> ScrollInterval
        {
            add
            {
                if (_scrollBarScrollPositionIntervalReachedEventHandler == null)
                {
                    _scrollBarScrollPositionIntervalReachedEventCallbackDelegate = (OnScrollBarScrollPositionIntervalReached);
                    ScrollPositionIntervalReachedSignal().Connect(_scrollBarScrollPositionIntervalReachedEventCallbackDelegate);
                }
                _scrollBarScrollPositionIntervalReachedEventHandler += value;
            }
            remove
            {
                _scrollBarScrollPositionIntervalReachedEventHandler -= value;
                if (_scrollBarScrollPositionIntervalReachedEventHandler == null && ScrollPositionIntervalReachedSignal().Empty() == false)
                {
                    ScrollPositionIntervalReachedSignal().Disconnect(_scrollBarScrollPositionIntervalReachedEventCallbackDelegate);
                }
            }
        }

        // Callback for ScrollBar ScrollPositionIntervalReachedSignal
        private void OnScrollBarScrollPositionIntervalReached()
        {
            ScrollIntervalEventArgs e = new ScrollIntervalEventArgs();

            if (_scrollBarScrollPositionIntervalReachedEventHandler != null)
            {
                //here we send all data to user event handlers
                _scrollBarScrollPositionIntervalReachedEventHandler(this, e);
            }
        }


        internal new class Property
        {
            internal static readonly int SCROLL_DIRECTION = NDalicPINVOKE.ScrollBar_Property_SCROLL_DIRECTION_get();
            internal static readonly int INDICATOR_HEIGHT_POLICY = NDalicPINVOKE.ScrollBar_Property_INDICATOR_HEIGHT_POLICY_get();
            internal static readonly int INDICATOR_FIXED_HEIGHT = NDalicPINVOKE.ScrollBar_Property_INDICATOR_FIXED_HEIGHT_get();
            internal static readonly int INDICATOR_SHOW_DURATION = NDalicPINVOKE.ScrollBar_Property_INDICATOR_SHOW_DURATION_get();
            internal static readonly int INDICATOR_HIDE_DURATION = NDalicPINVOKE.ScrollBar_Property_INDICATOR_HIDE_DURATION_get();
            internal static readonly int SCROLL_POSITION_INTERVALS = NDalicPINVOKE.ScrollBar_Property_SCROLL_POSITION_INTERVALS_get();
            internal static readonly int INDICATOR_MINIMUM_HEIGHT = NDalicPINVOKE.ScrollBar_Property_INDICATOR_MINIMUM_HEIGHT_get();
            internal static readonly int INDICATOR_START_PADDING = NDalicPINVOKE.ScrollBar_Property_INDICATOR_START_PADDING_get();
            internal static readonly int INDICATOR_END_PADDING = NDalicPINVOKE.ScrollBar_Property_INDICATOR_END_PADDING_get();
        }

        /// <summary>
        /// Creates an initialized scrollbar.
        /// </summary>
        /// <param name="direction">The direction of the scrollbar (either vertically or horizontally).</param>
        /// <since_tizen> 3 </since_tizen>
        public ScrollBar(ScrollBar.Direction direction) : this(NDalicPINVOKE.ScrollBar_New__SWIG_0((int)direction), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates an uninitialized scrollbar.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ScrollBar() : this(NDalicPINVOKE.ScrollBar_New__SWIG_1(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        internal ScrollBar(ScrollBar scrollBar) : this(NDalicPINVOKE.new_ScrollBar__SWIG_1(ScrollBar.getCPtr(scrollBar)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetScrollPropertySource(Animatable handle, int propertyScrollPosition, int propertyMinScrollPosition, int propertyMaxScrollPosition, int propertyScrollContentSize)
        {
            NDalicPINVOKE.ScrollBar_SetScrollPropertySource(swigCPtr, Animatable.getCPtr(handle), propertyScrollPosition, propertyMinScrollPosition, propertyMaxScrollPosition, propertyScrollContentSize);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetScrollIndicator(View indicator)
        {
            NDalicPINVOKE.ScrollBar_SetScrollIndicator(swigCPtr, View.getCPtr(indicator));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal View GetScrollIndicator()
        {
            View ret = new View(NDalicPINVOKE.ScrollBar_GetScrollIndicator(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetScrollDirection(ScrollBar.Direction direction)
        {
            NDalicPINVOKE.ScrollBar_SetScrollDirection(swigCPtr, (int)direction);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ScrollBar.Direction GetScrollDirection()
        {
            ScrollBar.Direction ret = (ScrollBar.Direction)NDalicPINVOKE.ScrollBar_GetScrollDirection(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetIndicatorHeightPolicy(ScrollBar.IndicatorHeightPolicyType policy)
        {
            NDalicPINVOKE.ScrollBar_SetIndicatorHeightPolicy(swigCPtr, (int)policy);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ScrollBar.IndicatorHeightPolicyType GetIndicatorHeightPolicy()
        {
            ScrollBar.IndicatorHeightPolicyType ret = (ScrollBar.IndicatorHeightPolicyType)NDalicPINVOKE.ScrollBar_GetIndicatorHeightPolicy(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetIndicatorFixedHeight(float height)
        {
            NDalicPINVOKE.ScrollBar_SetIndicatorFixedHeight(swigCPtr, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal float GetIndicatorFixedHeight()
        {
            float ret = NDalicPINVOKE.ScrollBar_GetIndicatorFixedHeight(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetIndicatorShowDuration(float durationSeconds)
        {
            NDalicPINVOKE.ScrollBar_SetIndicatorShowDuration(swigCPtr, durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal float GetIndicatorShowDuration()
        {
            float ret = NDalicPINVOKE.ScrollBar_GetIndicatorShowDuration(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetIndicatorHideDuration(float durationSeconds)
        {
            NDalicPINVOKE.ScrollBar_SetIndicatorHideDuration(swigCPtr, durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal float GetIndicatorHideDuration()
        {
            float ret = NDalicPINVOKE.ScrollBar_GetIndicatorHideDuration(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void ShowIndicator()
        {
            NDalicPINVOKE.ScrollBar_ShowIndicator(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void HideIndicator()
        {
            NDalicPINVOKE.ScrollBar_HideIndicator(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal VoidSignal PanFinishedSignal()
        {
            VoidSignal ret = new VoidSignal(NDalicPINVOKE.ScrollBar_PanFinishedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal FloatSignal ScrollPositionIntervalReachedSignal()
        {
            FloatSignal ret = new FloatSignal(NDalicPINVOKE.ScrollBar_ScrollPositionIntervalReachedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// The direction of the scrollbar.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum Direction
        {
            /// <summary>
            /// Scroll in the vertical direction
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Vertical = 0,
            /// <summary>
            /// Scroll in the horizontal direction
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Horizontal
        }

        /// <summary>
        /// The indicator height policy.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum IndicatorHeightPolicyType
        {
            /// <summary>
            /// Variable height changed dynamically according to the length of scroll content
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Variable = 0,
            /// <summary>
            /// Fixed height regardless of the length of scroll content
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Fixed
        }

        /// <summary>
        /// The direction of the scrollbar.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Direction ScrollDirection
        {
            get
            {

                return (Direction)GetValue(ScrollDirectionProperty);
            }
            set
            {
                SetValue(ScrollDirectionProperty, value);
            }
        }

        /// <summary>
        /// The indicator height policy.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public IndicatorHeightPolicyType IndicatorHeightPolicy
        {
            get
            {
                return (IndicatorHeightPolicyType)GetValue(IndicatorHeightPolicyProperty);
            }
            set
            {
                SetValue(IndicatorHeightPolicyProperty, value);
            }
        }

        /// <summary>
        /// The fixed height of the scroll indicator.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float IndicatorFixedHeight
        {
            get
            {
                return (float)GetValue(IndicatorFixedHeightProperty);
            }
            set
            {
                SetValue(IndicatorFixedHeightProperty, value);
            }
        }

        /// <summary>
        /// The duration in seconds for the scroll indicator to become fully visible.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float IndicatorShowDuration
        {
            get
            {
                return (float)GetValue(IndicatorShowDurationProperty);
            }
            set
            {
                SetValue(IndicatorShowDurationProperty, value);
            }
        }

        /// <summary>
        /// The duration in seconds for the scroll indicator to become fully invisible.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float IndicatorHideDuration
        {
            get
            {
                return (float)GetValue(IndicatorHideDurationProperty);
            }
            set
            {
                SetValue(IndicatorHideDurationProperty, value);
            }
        }

        /// <summary>
        /// The list of values to get the notification when the current scroll position of the scrollable object goes above or below any of these values.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.PropertyArray ScrollPositionIntervals
        {
            get
            {
                return (PropertyArray)GetValue(ScrollPositionIntervalsProperty);
            }
            set
            {
                SetValue(ScrollPositionIntervalsProperty, value);
            }
        }

        /// <summary>
        /// The minimum height for a variable size indicator.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float IndicatorMinimumHeight
        {
            get
            {
                return (float)GetValue(IndicatorMinimumHeightProperty);
            }
            set
            {
                SetValue(IndicatorMinimumHeightProperty, value);
            }
        }

        /// <summary>
        /// The padding at the start of the indicator. For example, the top if the scrollDirection is vertical.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float IndicatorStartPadding
        {
            get
            {
                return (float)GetValue(IndicatorStartPaddingProperty);
            }
            set
            {
                SetValue(IndicatorStartPaddingProperty, value);
            }
        }

        /// <summary>
        /// The padding at the end of the indicator. For example, the bottom if the scrollDirection is vertical.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float IndicatorEndPadding
        {
            get
            {
                return (float)GetValue(IndicatorEndPaddingProperty);
            }
            set
            {
                SetValue(IndicatorEndPaddingProperty, value);
            }
        }

    }

}
