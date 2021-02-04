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
using System.Runtime.InteropServices;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.UIComponents
{
    /// <summary>
    /// The slider is a control to enable sliding an indicator between two values.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// This will be deprecated
    [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Slider : View
    {
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LowerBoundProperty = BindableProperty.Create(nameof(LowerBound), typeof(float), typeof(Slider), 0.0f, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var slider = (Slider)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)slider.SwigCPtr, Slider.Property.LowerBound, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var slider = (Slider)bindable;
             float temp = 0.0f;
             Tizen.NUI.Object.GetProperty((HandleRef)slider.SwigCPtr, Slider.Property.LowerBound).Get(out temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UpperBoundProperty = BindableProperty.Create(nameof(UpperBound), typeof(float), typeof(Slider), 1.0f, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var slider = (Slider)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)slider.SwigCPtr, Slider.Property.UpperBound, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var slider = (Slider)bindable;
             float temp = 0.0f;
             Tizen.NUI.Object.GetProperty((HandleRef)slider.SwigCPtr, Slider.Property.UpperBound).Get(out temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(float), typeof(Slider), default(float), BindingMode.TwoWay, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var slider = (Slider)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)slider.SwigCPtr, Slider.Property.VALUE, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var slider = (Slider)bindable;
             float temp = 0.0f;
             Tizen.NUI.Object.GetProperty((HandleRef)slider.SwigCPtr, Slider.Property.VALUE).Get(out temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackVisualProperty = BindableProperty.Create(nameof(TrackVisual), typeof(PropertyMap), typeof(Slider), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var slider = (Slider)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)slider.SwigCPtr, Slider.Property.TrackVisual, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var slider = (Slider)bindable;
             PropertyMap temp = new PropertyMap();
             Tizen.NUI.Object.GetProperty((HandleRef)slider.SwigCPtr, Slider.Property.TrackVisual).Get(temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HandleVisualProperty = BindableProperty.Create(nameof(HandleVisual), typeof(PropertyMap), typeof(Slider), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var slider = (Slider)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)slider.SwigCPtr, Slider.Property.HandleVisual, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var slider = (Slider)bindable;
             PropertyMap temp = new PropertyMap();
             Tizen.NUI.Object.GetProperty((HandleRef)slider.SwigCPtr, Slider.Property.HandleVisual).Get(temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ProgressVisualProperty = BindableProperty.Create(nameof(ProgressVisual), typeof(PropertyMap), typeof(Slider), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var slider = (Slider)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)slider.SwigCPtr, Slider.Property.ProgressVisual, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var slider = (Slider)bindable;
             PropertyMap temp = new PropertyMap();
             Tizen.NUI.Object.GetProperty((HandleRef)slider.SwigCPtr, Slider.Property.ProgressVisual).Get(temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PopupVisualProperty = BindableProperty.Create(nameof(PopupVisual), typeof(PropertyMap), typeof(Slider), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var slider = (Slider)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)slider.SwigCPtr, Slider.Property.PopupVisual, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var slider = (Slider)bindable;
             PropertyMap temp = new PropertyMap();
             Tizen.NUI.Object.GetProperty((HandleRef)slider.SwigCPtr, Slider.Property.PopupVisual).Get(temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PopupArrowVisualProperty = BindableProperty.Create(nameof(PopupArrowVisual), typeof(PropertyMap), typeof(Slider), new PropertyMap(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var slider = (Slider)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)slider.SwigCPtr, Slider.Property.PopupArrowVisual, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var slider = (Slider)bindable;
             PropertyMap temp = new PropertyMap();
             Tizen.NUI.Object.GetProperty((HandleRef)slider.SwigCPtr, Slider.Property.PopupArrowVisual).Get(temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DisabledColorProperty = BindableProperty.Create(nameof(DisabledColor), typeof(Vector4), typeof(Slider), Vector4.Zero, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var slider = (Slider)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)slider.SwigCPtr, Slider.Property.DisabledColor, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var slider = (Slider)bindable;
             Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
             Tizen.NUI.Object.GetProperty((HandleRef)slider.SwigCPtr, Slider.Property.DisabledColor).Get(temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ValuePrecisionProperty = BindableProperty.Create(nameof(ValuePrecision), typeof(int), typeof(Slider), default(int), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var slider = (Slider)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)slider.SwigCPtr, Slider.Property.ValuePrecision, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var slider = (Slider)bindable;
             int temp = 0;
             Tizen.NUI.Object.GetProperty((HandleRef)slider.SwigCPtr, Slider.Property.ValuePrecision).Get(out temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShowPopupProperty = BindableProperty.Create(nameof(ShowPopup), typeof(bool), typeof(Slider), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var slider = (Slider)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)slider.SwigCPtr, Slider.Property.ShowPopup, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var slider = (Slider)bindable;
             bool temp = false;
             Tizen.NUI.Object.GetProperty((HandleRef)slider.SwigCPtr, Slider.Property.ShowPopup).Get(out temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShowValueProperty = BindableProperty.Create(nameof(ShowValue), typeof(bool), typeof(Slider), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var slider = (Slider)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)slider.SwigCPtr, Slider.Property.ShowValue, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var slider = (Slider)bindable;
             bool temp = false;
             Tizen.NUI.Object.GetProperty((HandleRef)slider.SwigCPtr, Slider.Property.ShowValue).Get(out temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MarksProperty = BindableProperty.Create(nameof(Marks), typeof(PropertyArray), typeof(Slider), new PropertyArray(), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var slider = (Slider)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)slider.SwigCPtr, Slider.Property.MARKS, new Tizen.NUI.PropertyValue((PropertyArray)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var slider = (Slider)bindable;
             Tizen.NUI.PropertyArray temp = new Tizen.NUI.PropertyArray();
             Tizen.NUI.Object.GetProperty((HandleRef)slider.SwigCPtr, Slider.Property.MARKS).Get(temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MarkToleranceProperty = BindableProperty.Create(nameof(MarkTolerance), typeof(float), typeof(Slider), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var slider = (Slider)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)slider.SwigCPtr, Slider.Property.MarkTolerance, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var slider = (Slider)bindable;
             float temp = 0.0f;
             Tizen.NUI.Object.GetProperty((HandleRef)slider.SwigCPtr, Slider.Property.MarkTolerance).Get(out temp);
             return temp;
         }));
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SnapToMarksProperty = BindableProperty.Create(nameof(SnapToMarks), typeof(bool), typeof(Slider), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var slider = (Slider)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)slider.SwigCPtr, Slider.Property.SnapToMarks, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
         {
             var slider = (Slider)bindable;
             bool temp = false;
             Tizen.NUI.Object.GetProperty((HandleRef)slider.SwigCPtr, Slider.Property.SnapToMarks).Get(out temp);
             return temp;
         }));

        private EventHandlerWithReturnType<object, ValueChangedEventArgs, bool> _sliderValueChangedEventHandler;
        private ValueChangedCallbackDelegate _sliderValueChangedCallbackDelegate;
        private EventHandlerWithReturnType<object, SlidingFinishedEventArgs, bool> _sliderSlidingFinishedEventHandler;
        private SlidingFinishedCallbackDelegate _sliderSlidingFinishedCallbackDelegate;
        private EventHandlerWithReturnType<object, MarkReachedEventArgs, bool> _sliderMarkReachedEventHandler;
        private MarkReachedCallbackDelegate _sliderMarkReachedCallbackDelegate;

        /// <summary>
        /// Creates the slider control.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Slider() : this(Interop.Slider.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Slider(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal Slider(Slider handle) : this(Interop.Slider.NewSlider(Slider.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool ValueChangedCallbackDelegate(IntPtr slider, float slideValue);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool SlidingFinishedCallbackDelegate(IntPtr slider, float slideValue);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool MarkReachedCallbackDelegate(IntPtr slider, int slideValue);

        /// <summary>
        /// An event emitted when the slider value changes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1710: Rename EventHandlerWithReturnType to end in 'EventHandler'.")]
        public event EventHandlerWithReturnType<object, ValueChangedEventArgs, bool> ValueChanged
        {
            add
            {
                if (_sliderValueChangedEventHandler == null)
                {
                    _sliderValueChangedCallbackDelegate = (OnValueChanged);
                    SliderValueChangedSignal valueChanged = ValueChangedSignal();
                    valueChanged?.Connect(_sliderValueChangedCallbackDelegate);
                    valueChanged?.Dispose();
                }
                _sliderValueChangedEventHandler += value;
            }
            remove
            {
                _sliderValueChangedEventHandler -= value;
                SliderValueChangedSignal valueChanged = ValueChangedSignal();
                if (_sliderValueChangedEventHandler == null && valueChanged.Empty() == false)
                {
                    valueChanged?.Disconnect(_sliderValueChangedCallbackDelegate);
                }
                valueChanged?.Dispose();
            }
        }

        /// <summary>
        /// An event emitted when the sliding is finished.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1710: Rename EventHandlerWithReturnType to end in 'EventHandler'.")]
        public event EventHandlerWithReturnType<object, SlidingFinishedEventArgs, bool> SlidingFinished
        {
            add
            {
                if (_sliderSlidingFinishedEventHandler == null)
                {
                    _sliderSlidingFinishedCallbackDelegate = (OnSlidingFinished);
                    SliderValueChangedSignal slidingFinished = SlidingFinishedSignal();
                    slidingFinished?.Connect(_sliderSlidingFinishedCallbackDelegate);
                    slidingFinished?.Dispose();
                }
                _sliderSlidingFinishedEventHandler += value;
            }
            remove
            {
                _sliderSlidingFinishedEventHandler -= value;
                SliderValueChangedSignal slidingFinished = SlidingFinishedSignal();
                if (_sliderSlidingFinishedEventHandler == null && slidingFinished.Empty() == false)
                {
                    slidingFinished?.Disconnect(_sliderSlidingFinishedCallbackDelegate);
                }
                slidingFinished?.Dispose();
            }
        }

        /// <summary>
        /// An event emitted when the slider handle reaches a mark.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1710: Rename EventHandlerWithReturnType to end in 'EventHandler'.")]
        public event EventHandlerWithReturnType<object, MarkReachedEventArgs, bool> MarkReached
        {
            add
            {
                if (_sliderMarkReachedEventHandler == null)
                {
                    _sliderMarkReachedCallbackDelegate = (OnMarkReached);
                    SliderMarkReachedSignal markReached = MarkReachedSignal();
                    markReached?.Connect(_sliderMarkReachedCallbackDelegate);
                    markReached?.Dispose();
                }
                _sliderMarkReachedEventHandler += value;
            }
            remove
            {
                _sliderMarkReachedEventHandler -= value;
                SliderMarkReachedSignal markReached = MarkReachedSignal();
                if (_sliderMarkReachedEventHandler == null && markReached.Empty() == false)
                {
                    markReached?.Disconnect(_sliderMarkReachedCallbackDelegate);
                }
                markReached?.Dispose();
            }
        }

        /// <summary>
        /// The lower bound property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float LowerBound
        {
            get
            {
                return (float)GetValue(LowerBoundProperty);
            }
            set
            {
                SetValue(LowerBoundProperty, value);
            }
        }

        /// <summary>
        /// The upper bound property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float UpperBound
        {
            get
            {
                return (float)GetValue(UpperBoundProperty);
            }
            set
            {
                SetValue(UpperBoundProperty, value);
            }
        }

        /// <summary>
        /// The value property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Value
        {
            get
            {
                return (float)GetValue(ValueProperty);
            }
            set
            {
                SetValueAndForceSendChangeSignal(ValueProperty, value);
            }
        }

        /// <summary>
        /// The track visual property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap TrackVisual
        {
            get
            {
                return (PropertyMap)GetValue(TrackVisualProperty);
            }
            set
            {
                SetValue(TrackVisualProperty, value);
            }
        }

        /// <summary>
        /// The handle visual property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap HandleVisual
        {
            get
            {
                return (PropertyMap)GetValue(HandleVisualProperty);
            }
            set
            {
                SetValue(HandleVisualProperty, value);
            }
        }

        /// <summary>
        /// The progress visual property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap ProgressVisual
        {
            get
            {
                return (PropertyMap)GetValue(ProgressVisualProperty);
            }
            set
            {
                SetValue(ProgressVisualProperty, value);
            }
        }

        /// <summary>
        /// The popup visual property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap PopupVisual
        {
            get
            {
                return (PropertyMap)GetValue(PopupVisualProperty);
            }
            set
            {
                SetValue(PopupVisualProperty, value);
            }
        }

        /// <summary>
        /// The popup arrow visual property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap PopupArrowVisual
        {
            get
            {
                return (PropertyMap)GetValue(PopupArrowVisualProperty);
            }
            set
            {
                SetValue(PopupArrowVisualProperty, value);
            }
        }

        /// <summary>
        /// The disable color property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 DisabledColor
        {
            get
            {
                return (Vector4)GetValue(DisabledColorProperty);
            }
            set
            {
                SetValue(DisabledColorProperty, value);
            }
        }

        /// <summary>
        /// The value precision property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int ValuePrecision
        {
            get
            {
                return (int)GetValue(ValuePrecisionProperty);
            }
            set
            {
                SetValue(ValuePrecisionProperty, value);
            }
        }

        /// <summary>
        /// The show popup property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShowPopup
        {
            get
            {
                return (bool)GetValue(ShowPopupProperty);
            }
            set
            {
                SetValue(ShowPopupProperty, value);
            }
        }

        /// <summary>
        /// The show value property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShowValue
        {
            get
            {
                return (bool)GetValue(ShowValueProperty);
            }
            set
            {
                SetValue(ShowValueProperty, value);
            }
        }

        /// <summary>
        /// The marks property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.PropertyArray Marks
        {
            get
            {
                return (PropertyArray)GetValue(MarksProperty);
            }
            set
            {
                SetValue(MarksProperty, value);
            }
        }

        /// <summary>
        /// The snap to marks property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SnapToMarks
        {
            get
            {
                return (bool)GetValue(SnapToMarksProperty);
            }
            set
            {
                SetValue(SnapToMarksProperty, value);
            }
        }

        /// <summary>
        /// The mark tolerance property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float MarkTolerance
        {
            get
            {
                return (float)GetValue(MarkToleranceProperty);
            }
            set
            {
                SetValue(MarkToleranceProperty, value);
            }
        }

        /// Only used by the IL of xaml, will never changed to not hidden.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool IsCreateByXaml
        {
            get
            {
                return base.IsCreateByXaml;
            }
            set
            {
                base.IsCreateByXaml = value;

                if (value == true)
                {
                    this.ValueChanged += (obj, e) =>
                    {
                        this.Value = e.SlideValue;
                        return true;
                    };
                }
            }
        }

        /// <summary>
        /// Downcasts an object handle to the slider.<br />
        /// If the handle points to a slider, then the downcast produces a valid handle.<br />
        /// If not, then the returned handle is left uninitialized.<br />
        /// </summary>
        /// <param name="handle">The handle to an object.</param>
        /// <returns>The handle to a slider or an uninitialized handle.</returns>
        /// <exception cref="ArgumentNullException"> Thrown when handle is null. </exception>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Slider DownCast(BaseHandle handle)
        {
            if (null == handle)
            {
                throw new ArgumentNullException(nameof(handle));
            }
            Slider ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as Slider;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Slider obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        /// <summary>
        /// Gets the slider from the pointer.
        /// </summary>
        /// <param name="cPtr">The pointer of the slider.</param>
        /// <returns>The object of the slider type.</returns>
        internal static Slider GetSliderFromPtr(global::System.IntPtr cPtr)
        {
            Slider ret = Registry.GetManagedBaseHandleFromNativePtr(cPtr) as Slider;
            if (null == ret)
            {
                ret = Registry.GetManagedBaseHandleFromRefObject(cPtr) as Slider;
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Slider Assign(Slider handle)
        {
            Slider ret = new Slider(Interop.Slider.Assign(SwigCPtr, Slider.getCPtr(handle)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SliderValueChangedSignal ValueChangedSignal()
        {
            SliderValueChangedSignal ret = new SliderValueChangedSignal(Interop.Slider.ValueChangedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SliderValueChangedSignal SlidingFinishedSignal()
        {
            SliderValueChangedSignal ret = new SliderValueChangedSignal(Interop.Slider.SlidingFinishedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal SliderMarkReachedSignal MarkReachedSignal()
        {
            SliderMarkReachedSignal ret = new SliderMarkReachedSignal(Interop.Slider.MarkReachedSignal(SwigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Dispose.
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
                if (_sliderValueChangedCallbackDelegate != null)
                {
                    SliderValueChangedSignal valueChanged = ValueChangedSignal();
                    valueChanged?.Disconnect(_sliderValueChangedCallbackDelegate);
                    valueChanged?.Dispose();
                }

                if (_sliderSlidingFinishedCallbackDelegate != null)
                {
                    SliderValueChangedSignal slidingFinished = SlidingFinishedSignal();
                    slidingFinished?.Disconnect(_sliderSlidingFinishedCallbackDelegate);
                    slidingFinished?.Dispose();
                }

                if (_sliderMarkReachedCallbackDelegate != null)
                {
                    SliderMarkReachedSignal markReached = MarkReachedSignal();
                    markReached?.Disconnect(_sliderMarkReachedCallbackDelegate);
                    markReached?.Dispose();
                }
            }

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Slider.DeleteSlider(swigCPtr);
        }

        // Callback for Slider ValueChanged signal
        private bool OnValueChanged(IntPtr slider, float slideValue)
        {
            ValueChangedEventArgs e = new ValueChangedEventArgs();

            // Populate all members of "e" (ValueChangedEventArgs) with real page
            e.Slider = Slider.GetSliderFromPtr(slider);
            e.SlideValue = slideValue;

            if (_sliderValueChangedEventHandler != null)
            {
                //here we send all page to user event handlers
                return _sliderValueChangedEventHandler(this, e);
            }
            return false;
        }

        // Callback for Slider SlidingFinished signal
        private bool OnSlidingFinished(IntPtr slider, float slideValue)
        {
            SlidingFinishedEventArgs e = new SlidingFinishedEventArgs();

            // Populate all members of "e" (SlidingFinishedEventArgs) with real page
            e.Slider = Slider.GetSliderFromPtr(slider);
            e.SlideValue = slideValue;

            if (_sliderSlidingFinishedEventHandler != null)
            {
                //here we send all page to user event handlers
                return _sliderSlidingFinishedEventHandler(this, e);
            }
            return false;
        }

        // Callback for Slider MarkReached signal
        private bool OnMarkReached(IntPtr slider, int slideValue)
        {
            MarkReachedEventArgs e = new MarkReachedEventArgs();

            // Populate all members of "e" (MarkReachedEventArgs) with real page
            e.Slider = Slider.GetSliderFromPtr(slider);
            e.SlideValue = slideValue;

            if (_sliderMarkReachedEventHandler != null)
            {
                //here we send all page to user event handlers
                return _sliderMarkReachedEventHandler(this, e);
            }
            return false;
        }

        /// <summary>
        /// The ValueChanged event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public class ValueChangedEventArgs : EventArgs
        {
            private Slider _slider;
            private float _slideValue;

            /// <summary>
            /// The slider.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Slider Slider
            {
                get
                {
                    return _slider;
                }
                set
                {
                    _slider = value;
                }
            }

            /// <summary>
            /// The slider value.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float SlideValue
            {
                get
                {
                    return _slideValue;
                }
                set
                {
                    _slideValue = value;
                }
            }
        }

        /// <summary>
        /// The SlidingFinished event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public class SlidingFinishedEventArgs : EventArgs
        {
            private Slider _slider;
            private float _slideValue;

            /// <summary>
            /// The slider.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Slider Slider
            {
                get
                {
                    return _slider;
                }
                set
                {
                    _slider = value;
                }
            }

            /// <summary>
            /// The slider value.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public float SlideValue
            {
                get
                {
                    return _slideValue;
                }
                set
                {
                    _slideValue = value;
                }
            }
        }

        /// <summary>
        /// The MarkReached event arguments.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// This will be deprecated
        [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public class MarkReachedEventArgs : EventArgs
        {
            private Slider _slider;
            private int _slideValue;

            /// <summary>
            /// The slider.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Slider Slider
            {
                get
                {
                    return _slider;
                }
                set
                {
                    _slider = value;
                }
            }

            /// <summary>
            /// The slider value.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            /// This will be deprecated
            [Obsolete("Deprecated in API6; Will be removed in API9. Please use Tizen.NUI.Components")]
            [EditorBrowsable(EditorBrowsableState.Never)]
            public int SlideValue
            {
                get
                {
                    return _slideValue;
                }
                set
                {
                    _slideValue = value;
                }
            }
        }

        internal new class Property
        {
            internal static readonly int LowerBound = Interop.Slider.LowerBoundGet();
            internal static readonly int UpperBound = Interop.Slider.UpperBoundGet();
            internal static readonly int VALUE = Interop.Slider.ValueGet();
            internal static readonly int TrackVisual = Interop.Slider.TrackVisualGet();
            internal static readonly int HandleVisual = Interop.Slider.HandleVisualGet();
            internal static readonly int ProgressVisual = Interop.Slider.ProgressVisualGet();
            internal static readonly int PopupVisual = Interop.Slider.PopupVisualGet();
            internal static readonly int PopupArrowVisual = Interop.Slider.PopupArrowVisualGet();
            internal static readonly int DisabledColor = Interop.Slider.DisabledColorGet();
            internal static readonly int ValuePrecision = Interop.Slider.ValuePrecisionGet();
            internal static readonly int ShowPopup = Interop.Slider.ShowPopupGet();
            internal static readonly int ShowValue = Interop.Slider.ShowValueGet();
            internal static readonly int MARKS = Interop.Slider.MarksGet();
            internal static readonly int SnapToMarks = Interop.Slider.SnapToMarksGet();
            internal static readonly int MarkTolerance = Interop.Slider.MarkToleranceGet();
        }
    }
}
