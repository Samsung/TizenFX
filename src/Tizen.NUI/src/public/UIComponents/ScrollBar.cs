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
    /// This will be deprecated
    [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ScrollBar : View
    {
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollDirectionProperty = BindableProperty.Create(nameof(ScrollDirection), typeof(Direction), typeof(ScrollBar), Direction.Vertical, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
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
                Tizen.NUI.Object.SetProperty((HandleRef)scrollBar.SwigCPtr, ScrollBar.Property.ScrollDirection, new Tizen.NUI.PropertyValue(valueToString));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollBar = (ScrollBar)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty((HandleRef)scrollBar.SwigCPtr, ScrollBar.Property.ScrollDirection).Get(out temp) == false)
            {
                NUILog.Error("ScrollDirection get error!");
            }

            switch (temp)
            {
                case "Vertical": return Direction.Vertical;
                case "Horizontal": return Direction.Horizontal;
                default: return Direction.Vertical;
            }
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorHeightPolicyProperty = BindableProperty.Create(nameof(IndicatorHeightPolicy), typeof(IndicatorHeightPolicyType), typeof(ScrollBar), IndicatorHeightPolicyType.Variable, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollBar = (ScrollBar)bindable;
            string valueToString = "";
            if (newValue != null)
            {
                switch ((IndicatorHeightPolicyType)newValue)
                {
                    case IndicatorHeightPolicyType.Variable: { valueToString = "Variable"; break; }
                    case IndicatorHeightPolicyType.Fixed: { valueToString = "Fixed"; break; }
                    default: { valueToString = "Variable"; break; }
                }
                Tizen.NUI.Object.SetProperty((HandleRef)scrollBar.SwigCPtr, ScrollBar.Property.IndicatorHeightPolicy, new Tizen.NUI.PropertyValue(valueToString));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollBar = (ScrollBar)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty((HandleRef)scrollBar.SwigCPtr, ScrollBar.Property.IndicatorHeightPolicy).Get(out temp) == false)
            {
                NUILog.Error("IndicatorHeightPolicy get error!");
            }

            switch (temp)
            {
                case "Variable": return IndicatorHeightPolicyType.Variable;
                case "Fixed": return IndicatorHeightPolicyType.Fixed;
                default: return IndicatorHeightPolicyType.Variable;
            }
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorFixedHeightProperty = BindableProperty.Create(nameof(IndicatorFixedHeight), typeof(float), typeof(ScrollBar), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollBar = (ScrollBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)scrollBar.SwigCPtr, ScrollBar.Property.IndicatorFixedHeight, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollBar = (ScrollBar)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((HandleRef)scrollBar.SwigCPtr, ScrollBar.Property.IndicatorFixedHeight).Get(out temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorShowDurationProperty = BindableProperty.Create(nameof(IndicatorShowDuration), typeof(float), typeof(ScrollBar), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollBar = (ScrollBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)scrollBar.SwigCPtr, ScrollBar.Property.IndicatorShowDuration, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollBar = (ScrollBar)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((HandleRef)scrollBar.SwigCPtr, ScrollBar.Property.IndicatorShowDuration).Get(out temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorHideDurationProperty = BindableProperty.Create(nameof(IndicatorHideDuration), typeof(float), typeof(ScrollBar), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollBar = (ScrollBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)scrollBar.SwigCPtr, ScrollBar.Property.IndicatorHideDuration, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollBar = (ScrollBar)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((HandleRef)scrollBar.SwigCPtr, ScrollBar.Property.IndicatorHideDuration).Get(out temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollPositionIntervalsProperty = BindableProperty.Create(nameof(ScrollPositionIntervals), typeof(PropertyArray), typeof(ScrollBar), new PropertyArray(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollBar = (ScrollBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)scrollBar.SwigCPtr, ScrollBar.Property.ScrollPositionIntervals, new Tizen.NUI.PropertyValue((PropertyArray)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollBar = (ScrollBar)bindable;
            Tizen.NUI.PropertyArray temp = new Tizen.NUI.PropertyArray();
            Tizen.NUI.Object.GetProperty((HandleRef)scrollBar.SwigCPtr, ScrollBar.Property.ScrollPositionIntervals).Get(temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorMinimumHeightProperty = BindableProperty.Create(nameof(IndicatorMinimumHeight), typeof(float), typeof(ScrollBar), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollBar = (ScrollBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)scrollBar.SwigCPtr, ScrollBar.Property.IndicatorMinimumHeight, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollBar = (ScrollBar)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((HandleRef)scrollBar.SwigCPtr, ScrollBar.Property.IndicatorMinimumHeight).Get(out temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorStartPaddingProperty = BindableProperty.Create(nameof(IndicatorStartPadding), typeof(float), typeof(ScrollBar), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollBar = (ScrollBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)scrollBar.SwigCPtr, ScrollBar.Property.IndicatorStartPadding, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollBar = (ScrollBar)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((HandleRef)scrollBar.SwigCPtr, ScrollBar.Property.IndicatorStartPadding).Get(out temp);
            return temp;
        }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorEndPaddingProperty = BindableProperty.Create(nameof(IndicatorEndPadding), typeof(float), typeof(ScrollBar), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var scrollBar = (ScrollBar)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)scrollBar.SwigCPtr, ScrollBar.Property.IndicatorEndPadding, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var scrollBar = (ScrollBar)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((HandleRef)scrollBar.SwigCPtr, ScrollBar.Property.IndicatorEndPadding).Get(out temp);
            return temp;
        }));


        private EventHandler<PanFinishedEventArgs> _scrollBarPanFinishedEventHandler;
        private PanFinishedEventCallbackDelegate _scrollBarPanFinishedEventCallbackDelegate;

        private EventHandler<ScrollIntervalEventArgs> _scrollBarScrollPositionIntervalReachedEventHandler;
        private ScrollPositionIntervalReachedEventCallbackDelegate _scrollBarScrollPositionIntervalReachedEventCallbackDelegate;

        /// <summary>
        /// Creates an initialized scrollbar.
        /// </summary>
        /// <param name="direction">The direction of the scrollbar (either vertically or horizontally).</param>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollBar(ScrollBar.Direction direction) : this(Interop.ScrollBar.New((int)direction), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates an uninitialized scrollbar.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollBar() : this(Interop.ScrollBar.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ScrollBar(ScrollBar scrollBar) : this(Interop.ScrollBar.NewScrollBar(ScrollBar.getCPtr(scrollBar)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ScrollBar(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void PanFinishedEventCallbackDelegate();

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ScrollPositionIntervalReachedEventCallbackDelegate(float position);

        /// <summary>
        /// The event emitted when panning is finished on the scroll indicator.
        /// </summary>
        /// <remarks>Event only emitted when the source of the scroll position properties are set.</remarks>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<PanFinishedEventArgs> PanFinished
        {
            add
            {
                if (_scrollBarPanFinishedEventHandler == null)
                {
                    _scrollBarPanFinishedEventCallbackDelegate = (OnScrollBarPanFinished);
                    VoidSignal panFinished = PanFinishedSignal();
                    panFinished?.Connect(_scrollBarPanFinishedEventCallbackDelegate);
                    panFinished?.Dispose();
                }
                _scrollBarPanFinishedEventHandler += value;
            }
            remove
            {
                _scrollBarPanFinishedEventHandler -= value;
                VoidSignal panFinished = PanFinishedSignal();
                if (_scrollBarPanFinishedEventHandler == null && panFinished.Empty() == false)
                {
                    panFinished?.Disconnect(_scrollBarPanFinishedEventCallbackDelegate);
                }
                panFinished?.Dispose();
            }
        }

        /// <summary>
        /// This is the event emitted when the current scroll position of the scrollable content goes above or below the values specified by ScrollPositionIntervals property.
        /// </summary>
        /// <remarks>Event only emitted when the source of the scroll position properties are set.</remarks>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ScrollIntervalEventArgs> ScrollInterval
        {
            add
            {
                if (_scrollBarScrollPositionIntervalReachedEventHandler == null)
                {
                    _scrollBarScrollPositionIntervalReachedEventCallbackDelegate = (OnScrollBarScrollPositionIntervalReached);
                    FloatSignal scrollPositionIntervalReached = ScrollPositionIntervalReachedSignal();
                    scrollPositionIntervalReached?.Connect(_scrollBarScrollPositionIntervalReachedEventCallbackDelegate);
                    scrollPositionIntervalReached?.Dispose();
                }
                _scrollBarScrollPositionIntervalReachedEventHandler += value;
            }
            remove
            {
                _scrollBarScrollPositionIntervalReachedEventHandler -= value;
                FloatSignal scrollPositionIntervalReached = ScrollPositionIntervalReachedSignal();
                if (_scrollBarScrollPositionIntervalReachedEventHandler == null && scrollPositionIntervalReached.Empty() == false)
                {
                    scrollPositionIntervalReached?.Disconnect(_scrollBarScrollPositionIntervalReachedEventCallbackDelegate);
                }
                scrollPositionIntervalReached?.Dispose();
            }
        }

        /// <summary>
        /// The direction of the scrollbar.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum Direction
        {
            /// <summary>
            /// Scroll in the vertical direction
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            Vertical = 0,
            /// <summary>
            /// Scroll in the horizontal direction
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            Horizontal
        }

        /// <summary>
        /// The indicator height policy.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum IndicatorHeightPolicyType
        {
            /// <summary>
            /// Variable height changed dynamically according to the length of scroll content
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
			/// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            Variable = 0,
            /// <summary>
            /// Fixed height regardless of the length of scroll content
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
			/// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            Fixed
        }

        /// <summary>
        /// The direction of the scrollbar.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// <summary>
        /// Sets the source of the scroll position properties.
        /// </summary>
        /// <param name="handle">The handle of the object owing the scroll properties.</param>
        /// <param name="propertyScrollPosition">The index of the scroll position property(The scroll position, type float).</param>
        /// <param name="propertyMinScrollPosition">The index of the minimum scroll position property(The minimum scroll position, type float).</param>
        /// <param name="propertyMaxScrollPosition">The index of the maximum scroll position property(The maximum scroll position, type float).</param>
        /// <param name="propertyScrollContentSize">The index of the scroll content size property(The size of the scrollable content in actor coordinates, type float).</param>
        /// <remarks>The handle to the object owing the scroll properties has been initialised and the property index must be valid.</remarks>
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScrollPropertySource(Animatable handle, int propertyScrollPosition, int propertyMinScrollPosition, int propertyMaxScrollPosition, int propertyScrollContentSize)
        {
            Interop.ScrollBar.SetScrollPropertySource(SwigCPtr, Animatable.getCPtr(handle), propertyScrollPosition, propertyMinScrollPosition, propertyMaxScrollPosition, propertyScrollContentSize);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ScrollBar obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal void SetScrollIndicator(View indicator)
        {
            Interop.ScrollBar.SetScrollIndicator(SwigCPtr, View.getCPtr(indicator));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal View GetScrollIndicator()
        {
            View ret = new View(Interop.ScrollBar.GetScrollIndicator(SwigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetScrollDirection(ScrollBar.Direction direction)
        {
            Interop.ScrollBar.SetScrollDirection(SwigCPtr, (int)direction);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ScrollBar.Direction GetScrollDirection()
        {
            ScrollBar.Direction ret = (ScrollBar.Direction)Interop.ScrollBar.GetScrollDirection(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetIndicatorHeightPolicy(ScrollBar.IndicatorHeightPolicyType policy)
        {
            Interop.ScrollBar.SetIndicatorHeightPolicy(SwigCPtr, (int)policy);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ScrollBar.IndicatorHeightPolicyType GetIndicatorHeightPolicy()
        {
            ScrollBar.IndicatorHeightPolicyType ret = (ScrollBar.IndicatorHeightPolicyType)Interop.ScrollBar.GetIndicatorHeightPolicy(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetIndicatorFixedHeight(float height)
        {
            Interop.ScrollBar.SetIndicatorFixedHeight(SwigCPtr, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal float GetIndicatorFixedHeight()
        {
            float ret = Interop.ScrollBar.GetIndicatorFixedHeight(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetIndicatorShowDuration(float durationSeconds)
        {
            Interop.ScrollBar.SetIndicatorShowDuration(SwigCPtr, durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal float GetIndicatorShowDuration()
        {
            float ret = Interop.ScrollBar.GetIndicatorShowDuration(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetIndicatorHideDuration(float durationSeconds)
        {
            Interop.ScrollBar.SetIndicatorHideDuration(SwigCPtr, durationSeconds);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal float GetIndicatorHideDuration()
        {
            float ret = Interop.ScrollBar.GetIndicatorHideDuration(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void ShowIndicator()
        {
            Interop.ScrollBar.ShowIndicator(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void HideIndicator()
        {
            Interop.ScrollBar.HideIndicator(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal VoidSignal PanFinishedSignal()
        {
            VoidSignal ret = new VoidSignal(Interop.ScrollBar.PanFinishedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal FloatSignal ScrollPositionIntervalReachedSignal()
        {
            FloatSignal ret = new FloatSignal(Interop.ScrollBar.ScrollPositionIntervalReachedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// To dispose the ScrollBar instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            if (this != null)
            {
                if (_scrollBarScrollPositionIntervalReachedEventCallbackDelegate != null)
                {
                    FloatSignal scrollPositionIntervalReached = ScrollPositionIntervalReachedSignal();
                    scrollPositionIntervalReached?.Disconnect(_scrollBarScrollPositionIntervalReachedEventCallbackDelegate);
                    scrollPositionIntervalReached?.Dispose();
                }

                if (_scrollBarPanFinishedEventCallbackDelegate != null)
                {
                    VoidSignal panFinished = PanFinishedSignal();
                    panFinished?.Disconnect(_scrollBarPanFinishedEventCallbackDelegate);
                    panFinished?.Dispose();
                }
            }

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ScrollBar.DeleteScrollBar(swigCPtr);
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


        // Callback for ScrollBar ScrollPositionIntervalReachedSignal
        private void OnScrollBarScrollPositionIntervalReached(float position)
        {
            ScrollIntervalEventArgs e = new ScrollIntervalEventArgs();
            e.CurrentScrollPosition = position;

            if (_scrollBarScrollPositionIntervalReachedEventHandler != null)
            {
                //here we send all data to user event handlers
                _scrollBarScrollPositionIntervalReachedEventHandler(this, e);
            }
        }



        /// <summary>
        /// Event arguments that passed via the PanFinished event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public class PanFinishedEventArgs : EventArgs
        {
        }

        /// <summary>
        /// Event arguments that passed via the ScrollPositionIntervalReached event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public class ScrollIntervalEventArgs : EventArgs
        {
            private float _currentScrollPosition;

            /// <summary>
            /// The current scroll position of the scrollable content.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
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

        internal new class Property
        {
            internal static readonly int ScrollDirection = Interop.ScrollBar.ScrollDirectionGet();
            internal static readonly int IndicatorHeightPolicy = Interop.ScrollBar.IndicatorHeightPolicyGet();
            internal static readonly int IndicatorFixedHeight = Interop.ScrollBar.IndicatorFixedHeightGet();
            internal static readonly int IndicatorShowDuration = Interop.ScrollBar.IndicatorShowDurationGet();
            internal static readonly int IndicatorHideDuration = Interop.ScrollBar.IndicatorHideDurationGet();
            internal static readonly int ScrollPositionIntervals = Interop.ScrollBar.ScrollPositionIntervalsGet();
            internal static readonly int IndicatorMinimumHeight = Interop.ScrollBar.IndicatorMinimumHeightGet();
            internal static readonly int IndicatorStartPadding = Interop.ScrollBar.IndicatorStartPaddingGet();
            internal static readonly int IndicatorEndPadding = Interop.ScrollBar.IndicatorEndPaddingGet();
        }
    }
}
