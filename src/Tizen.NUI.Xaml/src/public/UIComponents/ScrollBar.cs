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
using Tizen.NUI;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml.Forms.BaseComponents;
using static Tizen.NUI.UIComponents.ScrollBar;

namespace Tizen.NUI.Xaml.UIComponents
{
    /// <summary>
    /// The ScrollBar is a UI component that can be linked to the scrollable objects
    /// indicating the current scroll position of the scrollable object.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ScrollBar : View
    {
        private Tizen.NUI.UIComponents.ScrollBar _scrollBar;
        internal Tizen.NUI.UIComponents.ScrollBar scrollBar
        {
            get
            {
                if (null == _scrollBar)
                {
                    _scrollBar = handleInstance as Tizen.NUI.UIComponents.ScrollBar;
                }

                return _scrollBar;
            }
        }

        /// <summary>
        /// Creates an uninitialized scrollbar.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ScrollBar() : this(new Tizen.NUI.UIComponents.ScrollBar())
        {
        }

        internal ScrollBar(Tizen.NUI.UIComponents.ScrollBar nuiInstance) : base(nuiInstance)
        {
            SetNUIInstance(nuiInstance);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScrollDirectionProperty = Binding.BindableProperty.Create("ScrollDirection", typeof(Direction), typeof(ScrollBar), Direction.Vertical, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollBar = ((ScrollBar)bindable).scrollBar;
            scrollBar.ScrollDirection = (Direction)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollBar = ((ScrollBar)bindable).scrollBar;
            return scrollBar.ScrollDirection;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty IndicatorHeightPolicyProperty = Binding.BindableProperty.Create("IndicatorHeightPolicy", typeof(IndicatorHeightPolicyType), typeof(ScrollBar), IndicatorHeightPolicyType.Variable, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollBar = ((ScrollBar)bindable).scrollBar;
            scrollBar.IndicatorHeightPolicy = (IndicatorHeightPolicyType)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollBar = ((ScrollBar)bindable).scrollBar;
            return scrollBar.IndicatorHeightPolicy;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty IndicatorFixedHeightProperty = Binding.BindableProperty.Create("IndicatorFixedHeight", typeof(float), typeof(ScrollBar), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollBar = ((ScrollBar)bindable).scrollBar;
            scrollBar.IndicatorFixedHeight = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollBar = ((ScrollBar)bindable).scrollBar;
            return scrollBar.IndicatorFixedHeight;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty IndicatorShowDurationProperty = Binding.BindableProperty.Create("IndicatorShowDuration", typeof(float), typeof(ScrollBar), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollBar = ((ScrollBar)bindable).scrollBar;
            scrollBar.IndicatorShowDuration = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollBar = ((ScrollBar)bindable).scrollBar;
            return scrollBar.IndicatorShowDuration;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty IndicatorHideDurationProperty = Binding.BindableProperty.Create("IndicatorHideDuration", typeof(float), typeof(ScrollBar), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollBar = ((ScrollBar)bindable).scrollBar;
            scrollBar.IndicatorHideDuration = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollBar = ((ScrollBar)bindable).scrollBar;
            return scrollBar.IndicatorHideDuration;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScrollPositionIntervalsProperty = Binding.BindableProperty.Create("ScrollPositionIntervals", typeof(PropertyArray), typeof(ScrollBar), new PropertyArray(), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollBar = ((ScrollBar)bindable).scrollBar;
            scrollBar.ScrollPositionIntervals = (PropertyArray)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollBar = ((ScrollBar)bindable).scrollBar;
            return scrollBar.ScrollPositionIntervals;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty IndicatorMinimumHeightProperty = Binding.BindableProperty.Create("IndicatorMinimumHeight", typeof(float), typeof(ScrollBar), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollBar = ((ScrollBar)bindable).scrollBar;
            scrollBar.IndicatorMinimumHeight = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollBar = ((ScrollBar)bindable).scrollBar;
            return scrollBar.IndicatorMinimumHeight;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty IndicatorStartPaddingProperty = Binding.BindableProperty.Create("IndicatorStartPadding", typeof(float), typeof(ScrollBar), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollBar = ((ScrollBar)bindable).scrollBar;
            scrollBar.IndicatorStartPadding = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollBar = ((ScrollBar)bindable).scrollBar;
            return scrollBar.IndicatorStartPadding;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty IndicatorEndPaddingProperty = Binding.BindableProperty.Create("IndicatorEndPadding", typeof(float), typeof(ScrollBar), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollBar = ((ScrollBar)bindable).scrollBar;
            scrollBar.IndicatorEndPadding = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollBar = ((ScrollBar)bindable).scrollBar;
            return scrollBar.IndicatorEndPadding;
        });

        /// <summary>
        /// The event emitted when panning is finished on the scroll indicator.
        /// </summary>
        /// <remarks>Event only emitted when the source of the scroll position properties are set.</remarks>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<PanFinishedEventArgs> PanFinished
        {
            add
            {
                scrollBar.PanFinished += value;
            }
            remove
            {
                scrollBar.PanFinished -= value;
            }
        }

        /// <summary>
        /// This is the event emitted when the current scroll position of the scrollable content goes above or below the values specified by ScrollPositionIntervals property.
        /// </summary>
        /// <remarks>Event only emitted when the source of the scroll position properties are set.</remarks>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<ScrollIntervalEventArgs> ScrollInterval
        {
            add
            {
                scrollBar.ScrollInterval += value;
            }
            remove
            {
                scrollBar.ScrollInterval -= value;
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
            scrollBar.SetScrollPropertySource(handle, propertyScrollPosition, propertyMinScrollPosition, propertyMaxScrollPosition, propertyScrollContentSize);
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
        public PropertyArray ScrollPositionIntervals
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
