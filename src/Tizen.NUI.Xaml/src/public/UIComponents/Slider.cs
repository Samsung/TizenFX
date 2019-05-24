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
using Tizen.NUI.Xaml.Forms.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI;
using static Tizen.NUI.UIComponents.Slider;

namespace Tizen.NUI.Xaml.UIComponents
{
    /// <summary>
    /// The slider is a control to enable sliding an indicator between two values.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Slider : View
    {
        private Tizen.NUI.UIComponents.Slider _slider;
        internal Tizen.NUI.UIComponents.Slider slider
        {
            get
            {
                if (null == _slider)
                {
                    _slider = handleInstance as Tizen.NUI.UIComponents.Slider;
                }

                return _slider;
            }
        }

        /// <summary>
        /// Creates the slider control.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Slider() : this(new Tizen.NUI.UIComponents.Slider())
        {
        }

        internal Slider(Tizen.NUI.UIComponents.Slider nuiInstance) : base(nuiInstance)
        {
            SetNUIInstance(nuiInstance);

            nuiInstance.ValueChanged += (object source, ValueChangedEventArgs e) =>
            {
                Slider thisSlider = Tizen.NUI.Xaml.Forms.BaseHandle.GetHandle((Tizen.NUI.BaseHandle)source) as Slider;
                thisSlider.ForceNotify(ValueProperty);
                return true;
            };
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty LowerBoundProperty = Binding.BindableProperty.Create("LowerBound", typeof(float), typeof(Slider), 0.0f, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var slider = ((Slider)bindable).slider;
            slider.LowerBound = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var slider = ((Slider)bindable).slider;
            return slider.LowerBound;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty UpperBoundProperty = Binding.BindableProperty.Create("UpperBound", typeof(float), typeof(Slider), 1.0f, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var slider = ((Slider)bindable).slider;
            slider.UpperBound = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var slider = ((Slider)bindable).slider;
            return slider.UpperBound;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ValueProperty = Binding.BindableProperty.Create("Value", typeof(float), typeof(Slider), default(float), BindingMode.TwoWay, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var slider = ((Slider)bindable).slider;
            slider.Value = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var slider = ((Slider)bindable).slider;
            return slider.Value;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty TrackVisualProperty = Binding.BindableProperty.Create("TrackVisual", typeof(PropertyMap), typeof(Slider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var slider = ((Slider)bindable).slider;
            slider.TrackVisual = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var slider = ((Slider)bindable).slider;
            return slider.TrackVisual;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty HandleVisualProperty = Binding.BindableProperty.Create("HandleVisual", typeof(PropertyMap), typeof(Slider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var slider = ((Slider)bindable).slider;
            slider.HandleVisual = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var slider = ((Slider)bindable).slider;
            return slider.HandleVisual;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ProgressVisualProperty = Binding.BindableProperty.Create("ProgressVisual", typeof(PropertyMap), typeof(Slider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var slider = ((Slider)bindable).slider;
            slider.ProgressVisual = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var slider = ((Slider)bindable).slider;
            return slider.ProgressVisual;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PopupVisualProperty = Binding.BindableProperty.Create("PopupVisual", typeof(PropertyMap), typeof(Slider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var slider = ((Slider)bindable).slider;
            slider.PopupVisual = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var slider = ((Slider)bindable).slider;
            return slider.PopupVisual;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PopupArrowVisualProperty = Binding.BindableProperty.Create("PopupArrowVisual", typeof(PropertyMap), typeof(Slider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var slider = ((Slider)bindable).slider;
            slider.PopupArrowVisual = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var slider = ((Slider)bindable).slider;
            return slider.PopupArrowVisual;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty DisabledColorProperty = Binding.BindableProperty.Create("DisabledColor", typeof(Vector4), typeof(Slider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var slider = ((Slider)bindable).slider;
            slider.DisabledColor = (Vector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var slider = ((Slider)bindable).slider;
            return slider.DisabledColor;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ValuePrecisionProperty = Binding.BindableProperty.Create("ValuePrecision", typeof(int), typeof(Slider), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var slider = ((Slider)bindable).slider;
            slider.ValuePrecision = (int)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var slider = ((Slider)bindable).slider;
            return slider.ValuePrecision;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ShowPopupProperty = Binding.BindableProperty.Create("ShowPopup", typeof(bool), typeof(Slider), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var slider = ((Slider)bindable).slider;
            slider.ShowPopup = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var slider = ((Slider)bindable).slider;
            return slider.ShowPopup;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ShowValueProperty = Binding.BindableProperty.Create("ShowValue", typeof(bool), typeof(Slider), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var slider = ((Slider)bindable).slider;
            slider.ShowValue = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var slider = ((Slider)bindable).slider;
            return slider.ShowValue;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty MarksProperty = Binding.BindableProperty.Create("Marks", typeof(PropertyArray), typeof(Slider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var slider = ((Slider)bindable).slider;
            slider.Marks = (PropertyArray)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var slider = ((Slider)bindable).slider;
            return slider.Marks;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty MarkToleranceProperty = Binding.BindableProperty.Create("MarkTolerance", typeof(float), typeof(Slider), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var slider = ((Slider)bindable).slider;
            slider.MarkTolerance = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var slider = ((Slider)bindable).slider;
            return slider.MarkTolerance;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SnapToMarksProperty = Binding.BindableProperty.Create("SnapToMarks", typeof(bool), typeof(Slider), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var slider = ((Slider)bindable).slider;
            slider.SnapToMarks = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var slider = ((Slider)bindable).slider;
            return slider.SnapToMarks;
        });


        /// <summary>
        /// An event emitted when the slider value changes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandlerWithReturnType<object, ValueChangedEventArgs, bool> ValueChanged
        {
            add
            {
                slider.ValueChanged += value;
            }
            remove
            {
                slider.ValueChanged -= value;
            }
        }

        /// <summary>
        /// An event emitted when the sliding is finished.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandlerWithReturnType<object, SlidingFinishedEventArgs, bool> SlidingFinished
        {
            add
            {
                slider.SlidingFinished += value;
            }
            remove
            {
                slider.SlidingFinished -= value;
            }
        }

        /// <summary>
        /// An event emitted when the slider handle reaches a mark.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandlerWithReturnType<object, MarkReachedEventArgs, bool> MarkReached
        {
            add
            {
                slider.MarkReached += value;
            }
            remove
            {
                slider.MarkReached -= value;
            }
        }
 
        /// <summary>
        /// Downcasts an object handle to the slider.<br />
        /// If the handle points to a slider, then the downcast produces a valid handle.<br />
        /// If not, then the returned handle is left uninitialized.<br />
        /// </summary>
        /// <param name="handle">The handle to an object.</param>
        /// <returns>The handle to a slider or an uninitialized handle.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static Slider DownCast(Tizen.NUI.Xaml.Forms.BaseHandle handle)
        {
            return Tizen.NUI.Xaml.Forms.BaseHandle.GetHandle(handle.handleInstance) as Slider;
        }

        /// <summary>
        /// The lower bound property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        public float Value
        {
            get
            {
                return (float)GetValue(ValueProperty);
            }
            set
            {
                SetValue(ValueProperty, value);
                //SetValueAndForceSendChangeSignal(ValueProperty, value);   WaitForDone
            }
        }

        /// <summary>
        /// The track visual property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        public PropertyArray Marks
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
    }
}
