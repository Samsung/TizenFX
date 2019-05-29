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

namespace Tizen.NUI
{
    /// <summary>
    /// ScrollView contains views that can be scrolled manually (via touch).
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ScrollView : Scrollable
    {
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WrapEnabledProperty = BindableProperty.Create("WrapEnabled", typeof(bool), typeof(ScrollView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollView.swigCPtr, ScrollView.Property.WRAP_ENABLED, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(scrollView.swigCPtr, ScrollView.Property.WRAP_ENABLED).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PanningEnabledProperty = BindableProperty.Create("PanningEnabled", typeof(bool), typeof(ScrollView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollView.swigCPtr, ScrollView.Property.PANNING_ENABLED, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(scrollView.swigCPtr, ScrollView.Property.PANNING_ENABLED).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AxisAutoLockEnabledProperty = BindableProperty.Create("AxisAutoLockEnabled", typeof(bool), typeof(ScrollView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollView.swigCPtr, ScrollView.Property.AXIS_AUTO_LOCK_ENABLED, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(scrollView.swigCPtr, ScrollView.Property.AXIS_AUTO_LOCK_ENABLED).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WheelScrollDistanceStepProperty = BindableProperty.Create("WheelScrollDistanceStep", typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollView.swigCPtr, ScrollView.Property.WHEEL_SCROLL_DISTANCE_STEP, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(scrollView.swigCPtr, ScrollView.Property.WHEEL_SCROLL_DISTANCE_STEP).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollPositionProperty = BindableProperty.Create("ScrollPosition", typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollView.swigCPtr, ScrollView.Property.SCROLL_POSITION, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(scrollView.swigCPtr, ScrollView.Property.SCROLL_POSITION).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollPrePositionProperty = BindableProperty.Create("ScrollPrePosition", typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollView.swigCPtr, ScrollView.Property.SCROLL_PRE_POSITION, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(scrollView.swigCPtr, ScrollView.Property.SCROLL_PRE_POSITION).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollPrePositionMaxProperty = BindableProperty.Create("ScrollPrePositionMax", typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollView.swigCPtr, ScrollView.Property.SCROLL_PRE_POSITION_MAX, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(scrollView.swigCPtr, ScrollView.Property.SCROLL_PRE_POSITION_MAX).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OvershootXProperty = BindableProperty.Create("OvershootX", typeof(float), typeof(ScrollView), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollView.swigCPtr, ScrollView.Property.OVERSHOOT_X, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(scrollView.swigCPtr, ScrollView.Property.OVERSHOOT_X).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OvershootYProperty = BindableProperty.Create("OvershootY", typeof(float), typeof(ScrollView), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollView.swigCPtr, ScrollView.Property.OVERSHOOT_Y, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(scrollView.swigCPtr, ScrollView.Property.OVERSHOOT_Y).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollFinalProperty = BindableProperty.Create("ScrollFinal", typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollView.swigCPtr, ScrollView.Property.SCROLL_FINAL, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(scrollView.swigCPtr, ScrollView.Property.SCROLL_FINAL).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WrapProperty = BindableProperty.Create("Wrap", typeof(bool), typeof(ScrollView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollView.swigCPtr, ScrollView.Property.WRAP, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(scrollView.swigCPtr, ScrollView.Property.WRAP).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PanningProperty = BindableProperty.Create("Panning", typeof(bool), typeof(ScrollView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollView.swigCPtr, ScrollView.Property.PANNING, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(scrollView.swigCPtr, ScrollView.Property.PANNING).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollingProperty = BindableProperty.Create("Scrolling", typeof(bool), typeof(ScrollView), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollView.swigCPtr, ScrollView.Property.SCROLLING, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(scrollView.swigCPtr, ScrollView.Property.SCROLLING).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollDomainSizeProperty = BindableProperty.Create("ScrollDomainSize", typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollView.swigCPtr, ScrollView.Property.SCROLL_DOMAIN_SIZE, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(scrollView.swigCPtr, ScrollView.Property.SCROLL_DOMAIN_SIZE).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollDomainOffsetProperty = BindableProperty.Create("ScrollDomainOffset", typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollView.swigCPtr, ScrollView.Property.SCROLL_DOMAIN_OFFSET, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(scrollView.swigCPtr, ScrollView.Property.SCROLL_DOMAIN_OFFSET).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollPositionDeltaProperty = BindableProperty.Create("ScrollPositionDelta", typeof(Vector2), typeof(ScrollView), Vector2.Zero, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollView.swigCPtr, ScrollView.Property.SCROLL_POSITION_DELTA, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(scrollView.swigCPtr, ScrollView.Property.SCROLL_POSITION_DELTA).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StartPagePositionProperty = BindableProperty.Create("StartPagePosition", typeof(Vector3), typeof(ScrollView), Vector3.Zero, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollView.swigCPtr, ScrollView.Property.START_PAGE_POSITION, new Tizen.NUI.PropertyValue((Vector3)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(scrollView.swigCPtr, ScrollView.Property.START_PAGE_POSITION).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollModeProperty = BindableProperty.Create("ScrollMode", typeof(PropertyMap), typeof(ScrollView), new PropertyMap(), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var scrollView = (ScrollView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(scrollView.swigCPtr, ScrollView.Property.SCROLL_MODE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var scrollView = (ScrollView)bindable;
            PropertyValue value = Tizen.NUI.Object.GetProperty(scrollView.swigCPtr, ScrollView.Property.SCROLL_MODE);
            PropertyMap map = new PropertyMap();
            value.Get(map);
            return map;
        });

        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        private DaliEventHandler<object, SnapStartedEventArgs> _scrollViewSnapStartedEventHandler;
        private SnapStartedCallbackDelegate _scrollViewSnapStartedCallbackDelegate;

        /// <summary>
        /// Create an instance of ScrollView.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ScrollView() : this(Interop.ScrollView.ScrollView_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ScrollView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.ScrollView.ScrollView_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void SnapStartedCallbackDelegate(IntPtr data);

        /// <summary>
        /// SnapStarted can be used to subscribe or unsubscribe the event handler
        /// The SnapStarted signal is emitted when the ScrollView has started to snap or flick (it tells the target
        ///  position, scale, rotation for the snap or flick).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event DaliEventHandler<object, SnapStartedEventArgs> SnapStarted
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_scrollViewSnapStartedEventHandler == null)
                    {
                        _scrollViewSnapStartedEventHandler += value;

                        _scrollViewSnapStartedCallbackDelegate = new SnapStartedCallbackDelegate(OnSnapStarted);
                        this.SnapStartedSignal().Connect(_scrollViewSnapStartedCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_scrollViewSnapStartedEventHandler != null)
                    {
                        this.SnapStartedSignal().Disconnect(_scrollViewSnapStartedCallbackDelegate);
                    }

                    _scrollViewSnapStartedEventHandler -= value;
                }
            }
        }

        /// <summary>
        /// Sets and Gets WrapEnabled property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool WrapEnabled
        {
            get
            {
                return (bool)GetValue(WrapEnabledProperty);
            }
            set
            {
                SetValue(WrapEnabledProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets PanningEnabled property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool PanningEnabled
        {
            get
            {
                return (bool)GetValue(PanningEnabledProperty);
            }
            set
            {
                SetValue(PanningEnabledProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets AxisAutoLockEnabled property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool AxisAutoLockEnabled
        {
            get
            {
                return (bool)GetValue(AxisAutoLockEnabledProperty);
            }
            set
            {
                SetValue(AxisAutoLockEnabledProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets WheelScrollDistanceStep property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 WheelScrollDistanceStep
        {
            get
            {
                return (Vector2)GetValue(WheelScrollDistanceStepProperty);
            }
            set
            {
                SetValue(WheelScrollDistanceStepProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets ScrollPosition property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ScrollPosition
        {
            get
            {
                return (Vector2)GetValue(ScrollPositionProperty);
            }
            set
            {
                SetValue(ScrollPositionProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets ScrollPrePosition property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ScrollPrePosition
        {
            get
            {
                return (Vector2)GetValue(ScrollPrePositionProperty);
            }
            set
            {
                SetValue(ScrollPrePositionProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets ScrollPrePositionMax property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ScrollPrePositionMax
        {
            get
            {
                return (Vector2)GetValue(ScrollPrePositionMaxProperty);
            }
            set
            {
                SetValue(ScrollPrePositionMaxProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets OvershootX property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float OvershootX
        {
            get
            {
                return (float)GetValue(OvershootXProperty);
            }
            set
            {
                SetValue(OvershootXProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets OvershootY property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float OvershootY
        {
            get
            {
                return (float)GetValue(OvershootYProperty);
            }
            set
            {
                SetValue(OvershootYProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets ScrollFinal property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ScrollFinal
        {
            get
            {
                return (Vector2)GetValue(ScrollFinalProperty);
            }
            set
            {
                SetValue(ScrollFinalProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets Wrap property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Wrap
        {
            get
            {
                return (bool)GetValue(WrapProperty);
            }
            set
            {
                SetValue(WrapProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets Panning property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Panning
        {
            get
            {
                return (bool)GetValue(PanningProperty);
            }
            set
            {
                SetValue(PanningProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets Scrolling property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Scrolling
        {
            get
            {
                return (bool)GetValue(ScrollingProperty);
            }
            set
            {
                SetValue(ScrollingProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets ScrollDomainSize property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ScrollDomainSize
        {
            get
            {
                return (Vector2)GetValue(ScrollDomainSizeProperty);
            }
            set
            {
                SetValue(ScrollDomainSizeProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets ScrollDomainOffset property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ScrollDomainOffset
        {
            get
            {
                return (Vector2)GetValue(ScrollDomainOffsetProperty);
            }
            set
            {
                SetValue(ScrollDomainOffsetProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets ScrollPositionDelta property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ScrollPositionDelta
        {
            get
            {
                return (Vector2)GetValue(ScrollPositionDeltaProperty);
            }
            set
            {
                SetValue(ScrollPositionDeltaProperty, value);
            }
        }

        /// <summary>
        /// Sets and Gets StartPagePosition property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 StartPagePosition
        {
            get
            {
                return (Vector3)GetValue(StartPagePositionProperty);
            }
            set
            {
                SetValue(StartPagePositionProperty, value);
            }
        }


        /// <summary>
        /// Sets and Gets ScrollMode property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap ScrollMode
        {
            get
            {
                return (PropertyMap)GetValue(ScrollModeProperty);
            }
            set
            {
                SetValue(ScrollModeProperty, value);
            }
        }

        /// <summary>
        /// Gets snap-animation's AlphaFunction.
        /// </summary>
        /// <returns>Current easing alpha function of the snap animation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public AlphaFunction GetScrollSnapAlphaFunction()
        {
            AlphaFunction ret = new AlphaFunction(Interop.ScrollView.ScrollView_GetScrollSnapAlphaFunction(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets snap-animation's AlphaFunction.
        /// </summary>
        /// <param name="alpha">Easing alpha function of the snap animation.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetScrollSnapAlphaFunction(AlphaFunction alpha)
        {
            Interop.ScrollView.ScrollView_SetScrollSnapAlphaFunction(swigCPtr, AlphaFunction.getCPtr(alpha));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets flick-animation's AlphaFunction.
        /// </summary>
        /// <returns>Current easing alpha function of the flick animation.</returns>
        /// <since_tizen> 3 </since_tizen>
        public AlphaFunction GetScrollFlickAlphaFunction()
        {
            AlphaFunction ret = new AlphaFunction(Interop.ScrollView.ScrollView_GetScrollFlickAlphaFunction(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets flick-animation's AlphaFunction.
        /// </summary>
        /// <param name="alpha">Easing alpha function of the flick animation.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetScrollFlickAlphaFunction(AlphaFunction alpha)
        {
            Interop.ScrollView.ScrollView_SetScrollFlickAlphaFunction(swigCPtr, AlphaFunction.getCPtr(alpha));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the time for the scroll snap-animation.
        /// </summary>
        /// <returns>The time in seconds for the animation to take.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetScrollSnapDuration()
        {
            float ret = Interop.ScrollView.ScrollView_GetScrollSnapDuration(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the time for the scroll snap-animation.
        /// </summary>
        /// <param name="time">The time in seconds for the animation to take.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetScrollSnapDuration(float time)
        {
            Interop.ScrollView.ScrollView_SetScrollSnapDuration(swigCPtr, time);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the time for the scroll flick-animation.
        /// </summary>
        /// <returns>The time in seconds for the animation to take.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetScrollFlickDuration()
        {
            float ret = Interop.ScrollView.ScrollView_GetScrollFlickDuration(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the time for the scroll snap-animation.
        /// </summary>
        /// <param name="time">The time in seconds for the animation to take.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetScrollFlickDuration(float time)
        {
            Interop.ScrollView.ScrollView_SetScrollFlickDuration(swigCPtr, time);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets scroll sensibility of pan gesture.
        /// </summary>
        /// <param name="sensitive">True to enable scroll, false to disable scrolling.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetScrollSensitive(bool sensitive)
        {
            Interop.ScrollView.ScrollView_SetScrollSensitive(swigCPtr, sensitive);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets maximum overshoot amount.
        /// </summary>
        /// <param name="overshootX">The maximum number of horizontally scrolled pixels before overshoot X reaches 1.0f.</param>
        /// <param name="overshootY">The maximum number of vertically scrolled pixels before overshoot X reaches 1.0f.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetMaxOvershoot(float overshootX, float overshootY)
        {
            Interop.ScrollView.ScrollView_SetMaxOvershoot(swigCPtr, overshootX, overshootY);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets Snap Overshoot animation's AlphaFunction.
        /// </summary>
        /// <param name="alpha">Easing alpha function of the overshoot snap animation.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetSnapOvershootAlphaFunction(AlphaFunction alpha)
        {
            Interop.ScrollView.ScrollView_SetSnapOvershootAlphaFunction(swigCPtr, AlphaFunction.getCPtr(alpha));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets Snap Overshoot animation's Duration.
        /// </summary>
        /// <param name="duration">duration The duration of the overshoot snap animation.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetSnapOvershootDuration(float duration)
        {
            Interop.ScrollView.ScrollView_SetSnapOvershootDuration(swigCPtr, duration);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Enables or Disables Actor Auto-Snap mode.<br />
        /// When Actor Auto-Snap mode has been enabled, ScrollView will automatically,
        /// snap to the closest actor (The closest actor will appear in the center of the ScrollView).
        /// </summary>
        /// <param name="enable">Enables (true), or disables (false) Actor AutoSnap.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetViewAutoSnap(bool enable)
        {
            Interop.ScrollView.ScrollView_SetActorAutoSnap(swigCPtr, enable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Enables or Disables Wrap mode for ScrollView contents.<br />
        /// When enabled, the ScrollView contents are wrapped over the X/Y Domain.
        /// </summary>
        /// <param name="enable">Enables (true), or disables (false) Wrap Mode.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetWrapMode(bool enable)
        {
            Interop.ScrollView.ScrollView_SetWrapMode(swigCPtr, enable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the current distance needed to scroll for ScrollUpdatedSignal to be emitted.
        /// </summary>
        /// <returns>Current scroll update distance.</returns>
        /// <since_tizen> 3 </since_tizen>
        public int GetScrollUpdateDistance()
        {
            int ret = Interop.ScrollView.ScrollView_GetScrollUpdateDistance(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the distance needed to scroll for ScrollUpdatedSignal to be emitted.<br />
        /// The scroll update distance tells ScrollView how far to move before ScrollUpdatedSignal the informs application.<br />
        /// Each time the ScrollView crosses this distance the signal will be emitted.<br />
        /// </summary>
        /// <param name="distance">The distance for ScrollView to move before emitting update signal.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetScrollUpdateDistance(int distance)
        {
            Interop.ScrollView.ScrollView_SetScrollUpdateDistance(swigCPtr, distance);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns state of Axis Auto Lock mode.
        /// </summary>
        /// <returns>Whether Axis Auto Lock mode has been enabled or not.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool GetAxisAutoLock()
        {
            bool ret = Interop.ScrollView.ScrollView_GetAxisAutoLock(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Enables or Disables Axis Auto Lock mode for panning within the ScrollView.<br />
        /// When enabled, any pan gesture that appears mostly horizontal or mostly
        /// vertical, will be automatically restricted to horizontal only or vertical
        /// only panning, until the pan gesture has completed.
        /// </summary>
        /// <param name="enable">Enables (true), or disables (false) AxisAutoLock mode.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetAxisAutoLock(bool enable)
        {
            Interop.ScrollView.ScrollView_SetAxisAutoLock(swigCPtr, enable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the gradient threshold at which a panning gesture should be locked to the Horizontal or Vertical axis.
        /// </summary>
        /// <returns>The gradient, a value between 0.0 and 1.0f.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetAxisAutoLockGradient()
        {
            float ret = Interop.ScrollView.ScrollView_GetAxisAutoLockGradient(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the gradient threshold at which a panning gesture should be locked to the Horizontal or Vertical axis.<br />
        /// By default, this is 0.36 (0.36:1) which means angles less than 20 degrees to an axis will lock to that axis.<br />
        /// </summary>
        /// <param name="gradient">gradient A value between 0.0 and 1.0 (auto-lock for all angles).</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetAxisAutoLockGradient(float gradient)
        {
            Interop.ScrollView.ScrollView_SetAxisAutoLockGradient(swigCPtr, gradient);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the friction coefficient setting for ScrollView when flicking in free panning mode.
        /// This is a value in stage-diagonals per second^2, stage-diagonal = Length( stage.width, stage.height )
        /// </summary>
        /// <returns>Friction coefficient is returned.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetFrictionCoefficient()
        {
            float ret = Interop.ScrollView.ScrollView_GetFrictionCoefficient(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the friction coefficient for ScrollView when flicking.<br />
        /// </summary>
        /// <param name="friction">Friction coefficient must be greater than 0.0 (default = 1.0).</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetFrictionCoefficient(float friction)
        {
            Interop.ScrollView.ScrollView_SetFrictionCoefficient(swigCPtr, friction);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the flick speed coefficient for ScrollView when flicking in free panning mode.<br />
        /// This is a constant which multiplies the input touch flick velocity to determine the actual velocity at which to move the scrolling area.
        /// </summary>
        /// <returns>The flick speed coefficient is returned.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetFlickSpeedCoefficient()
        {
            float ret = Interop.ScrollView.ScrollView_GetFlickSpeedCoefficient(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the flick speed coefficient for ScrollView when flicking in free panning mode.<br />
        /// This is a constant which multiplies the input touch flick velocity to determine the actual velocity at
        /// which to move the scrolling area.<br />
        /// </summary>
        /// <param name="speed">The flick speed coefficient (default = 1.0).</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetFlickSpeedCoefficient(float speed)
        {
            Interop.ScrollView.ScrollView_SetFlickSpeedCoefficient(swigCPtr, speed);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the minimum pan distance required for a flick gesture in pixels.<br />
        /// </summary>
        /// <returns>Minimum pan distance vector with separate x and y distance.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 GetMinimumDistanceForFlick()
        {
            Vector2 ret = new Vector2(Interop.ScrollView.ScrollView_GetMinimumDistanceForFlick(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the minimum pan distance required for a flick in pixels.<br />
        /// Takes a Vector2 containing separate x and y values. As long as the pan distance exceeds one of these axes, a flick will be allowed.
        /// </summary>
        /// <param name="distance">The flick speed coefficient (default = 1.0).</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetMinimumDistanceForFlick(Vector2 distance)
        {
            Interop.ScrollView.ScrollView_SetMinimumDistanceForFlick(swigCPtr, Vector2.getCPtr(distance));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns the minimum pan speed required for a flick gesture in pixels per second.
        /// </summary>
        /// <returns>Minimum pan speed.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetMinimumSpeedForFlick()
        {
            float ret = Interop.ScrollView.ScrollView_GetMinimumSpeedForFlick(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the minimum pan speed required for a flick in pixels per second.<br />
        /// </summary>
        /// <param name="speed">The minimum pan speed for a flick.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetMinimumSpeedForFlick(float speed)
        {
            Interop.ScrollView.ScrollView_SetMinimumSpeedForFlick(swigCPtr, speed);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the maximum flick speed setting for ScrollView when flicking in free panning mode.<br />
        /// This is a value in stage-diagonals per second.
        /// </summary>
        /// <returns>Maximum flick speed is returned.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetMaxFlickSpeed()
        {
            float ret = Interop.ScrollView.ScrollView_GetMaxFlickSpeed(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the maximum flick speed for the ScrollView when flicking in free panning mode.<br />
        /// This is a value in stage-diagonals per second. stage-diagonal = Length( stage.width, stage.height ).<br />
        /// </summary>
        /// <param name="speed">Maximum flick speed (default = 3.0).</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetMaxFlickSpeed(float speed)
        {
            Interop.ScrollView.ScrollView_SetMaxFlickSpeed(swigCPtr, speed);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the step of scroll distance in actor coordinates for each wheel event received in free panning mode.<br />
        /// </summary>
        /// <returns>The step of scroll distance(pixel) in X and Y axes.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 GetWheelScrollDistanceStep()
        {
            Vector2 ret = new Vector2(Interop.ScrollView.ScrollView_GetWheelScrollDistanceStep(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the step of scroll distance in actor coordinates for each wheel event received in free panning mode.<br />
        /// </summary>
        /// <param name="step">step The step of scroll distance(pixel) in X and Y axes.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetWheelScrollDistanceStep(Vector2 step)
        {
            Interop.ScrollView.ScrollView_SetWheelScrollDistanceStep(swigCPtr, Vector2.getCPtr(step));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves current scroll position.<br />
        /// </summary>
        /// <returns>The current scroll position.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 GetCurrentScrollPosition()
        {
            Vector2 ret = new Vector2(Interop.ScrollView.ScrollView_GetCurrentScrollPosition(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves current scroll page based on ScrollView dimensions being the size of one page, and all pages laid out in<br />
        /// a grid fashion, increasing from left to right until the end of the X-domain.
        /// </summary>
        /// <returns>The current scroll position.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint GetCurrentPage()
        {
            uint ret = Interop.ScrollView.ScrollView_GetCurrentPage(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="position">The position to scroll to.</param>
        /// <since_tizen> 3 </since_tizen>
        public void ScrollTo(Vector2 position)
        {
            Interop.ScrollView.ScrollView_ScrollTo__SWIG_0(swigCPtr, Vector2.getCPtr(position));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="position">The position to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <since_tizen> 3 </since_tizen>
        public void ScrollTo(Vector2 position, float duration)
        {
            Interop.ScrollView.ScrollView_ScrollTo__SWIG_1(swigCPtr, Vector2.getCPtr(position), duration);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="position">The position to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <param name="alpha">The alpha function to use.</param>
        /// <since_tizen> 3 </since_tizen>
        public void ScrollTo(Vector2 position, float duration, AlphaFunction alpha)
        {
            Interop.ScrollView.ScrollView_ScrollTo__SWIG_2(swigCPtr, Vector2.getCPtr(position), duration, AlphaFunction.getCPtr(alpha));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="position">The position to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <param name="horizontalBias">Whether to bias scrolling to left or right.</param>
        /// <param name="verticalBias">Whether to bias scrolling to top or bottom.</param>
        /// <since_tizen> 3 </since_tizen>
        public void ScrollTo(Vector2 position, float duration, DirectionBias horizontalBias, DirectionBias verticalBias)
        {
            Interop.ScrollView.ScrollView_ScrollTo__SWIG_3(swigCPtr, Vector2.getCPtr(position), duration, (int)horizontalBias, (int)verticalBias);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="position">The position to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <param name="alpha">Alpha function to use.</param>
        /// <param name="horizontalBias">Whether to bias scrolling to left or right.</param>
        /// <param name="verticalBias">Whether to bias scrolling to top or bottom.</param>
        /// <since_tizen> 3 </since_tizen>
        public void ScrollTo(Vector2 position, float duration, AlphaFunction alpha, DirectionBias horizontalBias, DirectionBias verticalBias)
        {
            Interop.ScrollView.ScrollView_ScrollTo__SWIG_4(swigCPtr, Vector2.getCPtr(position), duration, AlphaFunction.getCPtr(alpha), (int)horizontalBias, (int)verticalBias);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="page">The page to scroll to.</param>
        /// <since_tizen> 3 </since_tizen>
        public void ScrollTo(uint page)
        {
            Interop.ScrollView.ScrollView_ScrollTo__SWIG_5(swigCPtr, page);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="page">The page to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <since_tizen> 3 </since_tizen>
        public void ScrollTo(uint page, float duration)
        {
            Interop.ScrollView.ScrollView_ScrollTo__SWIG_6(swigCPtr, page, duration);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="page">The page to scroll to.</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <param name="bias">Whether to bias scrolling to left or right.</param>
        /// <since_tizen> 3 </since_tizen>
        public void ScrollTo(uint page, float duration, DirectionBias bias)
        {
            Interop.ScrollView.ScrollView_ScrollTo__SWIG_7(swigCPtr, page, duration, (int)bias);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="view">The view to center in on (via Scrolling).</param>
        /// <since_tizen> 3 </since_tizen>
        public void ScrollTo(View view)
        {
            Interop.ScrollView.ScrollView_ScrollTo__SWIG_8(swigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to position specified (contents will scroll to this position).
        /// </summary>
        /// <param name="view">The view to center in on (via Scrolling).</param>
        /// <param name="duration">The duration of the animation in seconds.</param>
        /// <since_tizen> 3 </since_tizen>
        public void ScrollTo(View view, float duration)
        {
            Interop.ScrollView.ScrollView_ScrollTo__SWIG_9(swigCPtr, View.getCPtr(view), duration);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls View to the nearest snap points as specified by the Rulers.<br />
        /// If already at snap points, then will return false, and not scroll.<br />
        /// </summary>
        /// <returns>True if Snapping necessary.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool ScrollToSnapPoint()
        {
            bool ret = Interop.ScrollView.ScrollView_ScrollToSnapPoint(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Applies Effect to ScrollView.
        /// </summary>
        /// <param name="effect">The effect to apply to scroll view.</param>
        /// <since_tizen> 3 </since_tizen>
        public void ApplyEffect(ScrollViewEffect effect)
        {
            Interop.ScrollView.ScrollView_ApplyEffect(swigCPtr, ScrollViewEffect.getCPtr(effect));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes Effect from ScrollView.
        /// </summary>
        /// <param name="effect">The effect to remove.</param>
        /// <since_tizen> 3 </since_tizen>
        public void RemoveEffect(ScrollViewEffect effect)
        {
            Interop.ScrollView.ScrollView_RemoveEffect(swigCPtr, ScrollViewEffect.getCPtr(effect));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Remove All Effects from ScrollView.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void RemoveAllEffects()
        {
            Interop.ScrollView.ScrollView_RemoveAllEffects(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Binds view to this ScrollView.
        /// Once an actor is bound to a ScrollView, it will be subject to that ScrollView's properties.
        /// </summary>
        /// <param name="child">The view to add to this ScrollView.</param>
        /// <since_tizen> 3 </since_tizen>
        public void BindView(View child)
        {
            Interop.ScrollView.ScrollView_BindActor(swigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Unbinds view to this ScrollView.
        /// Once an actor is bound to a ScrollView, it will be subject to that ScrollView's properties.
        /// </summary>
        /// <param name="child">The view to remove to this ScrollView.</param>
        /// <since_tizen> 3 </since_tizen>
        public void UnbindView(View child)
        {
            Interop.ScrollView.ScrollView_UnbindActor(swigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Allows the user to constrain the scroll view in a particular direction.
        /// </summary>
        /// <param name="direction">The axis to constrain the scroll-view to.</param>
        /// <param name="threshold">The threshold to apply around the axis.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetScrollingDirection(Radian direction, Radian threshold)
        {
            Interop.ScrollView.ScrollView_SetScrollingDirection__SWIG_0(swigCPtr, Radian.getCPtr(direction), Radian.getCPtr(threshold));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Allows the user to constrain the scroll view in a particular direction.
        /// </summary>
        /// <param name="direction">The axis to constrain the scroll-view to.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetScrollingDirection(Radian direction)
        {
            Interop.ScrollView.ScrollView_SetScrollingDirection__SWIG_1(swigCPtr, Radian.getCPtr(direction));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes a direction constraint from the scroll view.
        /// </summary>
        /// <param name="direction">The axis to constrain the scroll-view to.</param>
        /// <since_tizen> 3 </since_tizen>
        public void RemoveScrollingDirection(Radian direction)
        {
            Interop.ScrollView.ScrollView_RemoveScrollingDirection(swigCPtr, Radian.getCPtr(direction));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ScrollView obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal void ApplyConstraintToChildren(SWIGTYPE_p_Dali__Constraint constraint)
        {
            Interop.ScrollView.ScrollView_ApplyConstraintToChildren(swigCPtr, SWIGTYPE_p_Dali__Constraint.getCPtr(constraint));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ScrollViewSnapStartedSignal SnapStartedSignal()
        {
            ScrollViewSnapStartedSignal ret = new ScrollViewSnapStartedSignal(Interop.ScrollView.ScrollView_SnapStartedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="type">the dispose type</param>
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

            if (this != null && _scrollViewSnapStartedCallbackDelegate != null)
            {
                this.SnapStartedSignal().Disconnect(_scrollViewSnapStartedCallbackDelegate);
            }

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.ScrollView.delete_ScrollView(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        // Callback for ScrollView SnapStarted signal
        private void OnSnapStarted(IntPtr data)
        {
            SnapStartedEventArgs e = new SnapStartedEventArgs();

            // Populate all members of "e" (SnapStartedEventArgs) with real data
            e.SnapEventInfo = SnapEvent.GetSnapEventFromPtr(data);

            if (_scrollViewSnapStartedEventHandler != null)
            {
                //here we send all data to user event handlers
                _scrollViewSnapStartedEventHandler(this, e);
            }
        }

        /// <summary>
        /// This should be internal, please do not use.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public new class Property
        {
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int WRAP_ENABLED = Interop.ScrollView.ScrollView_Property_WRAP_ENABLED_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int PANNING_ENABLED = Interop.ScrollView.ScrollView_Property_PANNING_ENABLED_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int AXIS_AUTO_LOCK_ENABLED = Interop.ScrollView.ScrollView_Property_AXIS_AUTO_LOCK_ENABLED_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int WHEEL_SCROLL_DISTANCE_STEP = Interop.ScrollView.ScrollView_Property_WHEEL_SCROLL_DISTANCE_STEP_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_MODE = Interop.ScrollView.ScrollView_Property_SCROLL_MODE_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_POSITION = Interop.ScrollView.ScrollView_Property_SCROLL_POSITION_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_PRE_POSITION = Interop.ScrollView.ScrollView_Property_SCROLL_PRE_POSITION_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_PRE_POSITION_X = Interop.ScrollView.ScrollView_Property_SCROLL_PRE_POSITION_X_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_PRE_POSITION_Y = Interop.ScrollView.ScrollView_Property_SCROLL_PRE_POSITION_Y_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_PRE_POSITION_MAX = Interop.ScrollView.ScrollView_Property_SCROLL_PRE_POSITION_MAX_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_PRE_POSITION_MAX_X = Interop.ScrollView.ScrollView_Property_SCROLL_PRE_POSITION_MAX_X_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_PRE_POSITION_MAX_Y = Interop.ScrollView.ScrollView_Property_SCROLL_PRE_POSITION_MAX_Y_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int OVERSHOOT_X = Interop.ScrollView.ScrollView_Property_OVERSHOOT_X_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int OVERSHOOT_Y = Interop.ScrollView.ScrollView_Property_OVERSHOOT_Y_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_FINAL = Interop.ScrollView.ScrollView_Property_SCROLL_FINAL_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_FINAL_X = Interop.ScrollView.ScrollView_Property_SCROLL_FINAL_X_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_FINAL_Y = Interop.ScrollView.ScrollView_Property_SCROLL_FINAL_Y_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int WRAP = Interop.ScrollView.ScrollView_Property_WRAP_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int PANNING = Interop.ScrollView.ScrollView_Property_PANNING_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLLING = Interop.ScrollView.ScrollView_Property_SCROLLING_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_DOMAIN_SIZE = Interop.ScrollView.ScrollView_Property_SCROLL_DOMAIN_SIZE_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_DOMAIN_SIZE_X = Interop.ScrollView.ScrollView_Property_SCROLL_DOMAIN_SIZE_X_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_DOMAIN_SIZE_Y = Interop.ScrollView.ScrollView_Property_SCROLL_DOMAIN_SIZE_Y_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_DOMAIN_OFFSET = Interop.ScrollView.ScrollView_Property_SCROLL_DOMAIN_OFFSET_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int SCROLL_POSITION_DELTA = Interop.ScrollView.ScrollView_Property_SCROLL_POSITION_DELTA_get();
            /// <summary>
            /// This should be internal, please do not use.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static readonly int START_PAGE_POSITION = Interop.ScrollView.ScrollView_Property_START_PAGE_POSITION_get();
        }

        /// <summary>
        /// Snaps signal event's data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class SnapEvent : global::System.IDisposable
        {
            /// <summary>
            /// swigCMemOwn
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            protected bool swigCMemOwn;

            /// <summary>
            /// A Flat to check if it is already disposed.
            /// </summary>
            /// swigCMemOwn
            /// <since_tizen> 3 </since_tizen>
            protected bool disposed = false;

            private global::System.Runtime.InteropServices.HandleRef swigCPtr;

            //A Flag to check who called Dispose(). (By User or DisposeQueue)
            private bool isDisposeQueued = false;

            /// <summary>
            /// Create an instance of SnapEvent.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public SnapEvent() : this(Interop.ScrollView.new_ScrollView_SnapEvent(), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

            internal SnapEvent(global::System.IntPtr cPtr, bool cMemoryOwn)
            {
                swigCMemOwn = cMemoryOwn;
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            }

            /// <summary>
            /// Dispose
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            ~SnapEvent()
            {
                if (!isDisposeQueued)
                {
                    isDisposeQueued = true;
                    DisposeQueue.Instance.Add(this);
                }
            }

            /// <summary>
            /// Scroll position.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public Vector2 position
            {
                set
                {
                    Interop.ScrollView.ScrollView_SnapEvent_position_set(swigCPtr, Vector2.getCPtr(value));
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    global::System.IntPtr cPtr = Interop.ScrollView.ScrollView_SnapEvent_position_get(swigCPtr);
                    Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <summary>
            /// Scroll duration.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public float duration
            {
                set
                {
                    Interop.ScrollView.ScrollView_SnapEvent_duration_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    float ret = Interop.ScrollView.ScrollView_SnapEvent_duration_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            internal SnapType type
            {
                set
                {
                    Interop.ScrollView.ScrollView_SnapEvent_type_set(swigCPtr, (int)value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    SnapType ret = (SnapType)Interop.ScrollView.ScrollView_SnapEvent_type_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            /// <summary>
            /// Get SnapEvent From Ptr
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public static SnapEvent GetSnapEventFromPtr(global::System.IntPtr cPtr)
            {
                SnapEvent ret = new SnapEvent(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }

            /// <summary>
            /// Dispose.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public void Dispose()
            {
                //Throw excpetion if Dispose() is called in separate thread.
                if (!Window.IsInstalled())
                {
                    throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
                }

                if (isDisposeQueued)
                {
                    Dispose(DisposeTypes.Implicit);
                }
                else
                {
                    Dispose(DisposeTypes.Explicit);
                    System.GC.SuppressFinalize(this);
                }
            }

            internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SnapEvent obj)
            {
                return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
            }

            /// <summary>
            /// Dispose
            /// </summary>
            /// <param name="type">the dispose type</param>
            /// <since_tizen> 3 </since_tizen>
            protected virtual void Dispose(DisposeTypes type)
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

                if (swigCPtr.Handle != global::System.IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        Interop.ScrollView.delete_ScrollView_SnapEvent(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }

                disposed = true;
            }

        }
        /// <summary>
        /// Event arguments that passed via the SnapStarted signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class SnapStartedEventArgs : EventArgs
        {
            private Tizen.NUI.ScrollView.SnapEvent _snapEvent;

            /// <summary>
            /// SnapEventInfo is the SnapEvent information like snap or flick (it tells the target position, scale, rotation for the snap or flick).
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public Tizen.NUI.ScrollView.SnapEvent SnapEventInfo
            {
                get
                {
                    return _snapEvent;
                }
                set
                {
                    _snapEvent = value;
                }
            }
        }
    }
}
