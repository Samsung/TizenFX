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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace Tizen.NUI.Wearable
{
    /// <summary>
    /// CircularSliderStyle is a class which saves CircularSlider's ux data.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CircularSliderStyle : ControlStyle
    {
        /// <summary>Bindable property of Thickness</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThicknessProperty = BindableProperty.Create(nameof(Thickness), typeof(float?), typeof(CircularSliderStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((CircularSliderStyle)bindable).thickness = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularSliderStyle)bindable).thickness;
        });

        /// <summary>Bindable property of MaxValue</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxValueProperty = BindableProperty.Create(nameof(MaxValue), typeof(float), typeof(CircularSliderStyle), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((CircularSliderStyle)bindable).maxValue = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularSliderStyle)bindable).maxValue;
        });

        /// <summary>Bindable property of MinValue</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinValueProperty = BindableProperty.Create(nameof(MinValue), typeof(float), typeof(CircularSliderStyle), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((CircularSliderStyle)bindable).minValue = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularSliderStyle)bindable).minValue;
        });

        /// <summary>Bindable property of CurrentValue</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CurrentValueProperty = BindableProperty.Create(nameof(CurrentValue), typeof(float), typeof(CircularSliderStyle), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((CircularSliderStyle)bindable).currentValue = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularSliderStyle)bindable).currentValue;
        });

        /// <summary>Bindable property of TrackColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackColorProperty = BindableProperty.Create(nameof(TrackColor), typeof(Color), typeof(CircularSliderStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((CircularSliderStyle)bindable).trackColor = newValue == null ? null : new Color((Color)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularSliderStyle)bindable).trackColor;
        });

        /// <summary>Bindable property of ProgressColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ProgressColorProperty = BindableProperty.Create(nameof(ProgressColor), typeof(Color), typeof(CircularSliderStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((CircularSliderStyle)bindable).progressColor = newValue == null ? null : new Color((Color)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularSliderStyle)bindable).progressColor;
        });

        /// <summary>Bindable property of ThumbSize</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbSizeProperty = BindableProperty.Create(nameof(ThumbSize), typeof(Size), typeof(CircularSliderStyle), new Size(0,0), propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((CircularSliderStyle)bindable).thumbSize = (Size)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularSliderStyle)bindable).thumbSize;
        });

        /// <summary>Bindable property of ThumbColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbColorProperty = BindableProperty.Create(nameof(ThumbColor), typeof(Color), typeof(CircularSliderStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((CircularSliderStyle)bindable).thumbColor = newValue == null ? null : new Color((Color)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularSliderStyle)bindable).thumbColor;
        });

        /// <summary>Bindable property of IsEnabled</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create(nameof(IsEnabled), typeof(bool?), typeof(CircularSliderStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((CircularSliderStyle)bindable).isEnabled = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularSliderStyle)bindable).isEnabled;
        });

        private float? thickness;
        private float maxValue;
        private float minValue;
        private float currentValue;
        private Color trackColor;
        private Color progressColor;
        private Color thumbColor;
        private Size thumbSize;
        private bool? isEnabled;

        static CircularSliderStyle() { }

        /// <summary>
        /// Creates a new instance of a CircularSliderStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircularSliderStyle() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a CircularSliderStyle with style.
        /// </summary>
        /// <param name="style">Create CircularSliderStyle by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircularSliderStyle(CircularSliderStyle style) : base(style)
        {
        }

        /// <summary>
        /// The thickness of the track and progress.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? Thickness
        {
            get
            {
                return (float?)GetValue(ThicknessProperty);
            }
            set
            {
                SetValue(ThicknessProperty, value);
            }
        }

        /// <summary>
        /// The property to get/set the maximum value of the CircularSlider.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float MaxValue
        {
            get
            {
                return (float)GetValue(MaxValueProperty);
            }
            set
            {
                SetValue(MaxValueProperty, value);
            }
        }

        /// <summary>
        /// The property to get/set the minim value of the CircularSlider.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float MinValue
        {
            get
            {
                return (float)GetValue(MinValueProperty);
            }
            set
            {
                SetValue(MinValueProperty, value);
            }
        }

        /// <summary>
        /// The property to get/set the current value of the CircularSlider.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float CurrentValue
        {
            get
            {
                return (float)GetValue(CurrentValueProperty);
            }
            set
            {
                SetValue(CurrentValueProperty, value);
            }
        }

        /// <summary>
        /// The property to get/set Track object color of the CircularSlider.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color TrackColor
        {
            get
            {
                return (Color)GetValue(TrackColorProperty);
            }
            set
            {
                SetValue(TrackColorProperty, value);
            }
        }

        /// <summary>
        /// The property to get/set Progress object color of the CircularSlider.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color ProgressColor
        {
            get
            {
                return (Color)GetValue(ProgressColorProperty);
            }
            set
            {
                SetValue(ProgressColorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the thumb of Slider.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size ThumbSize
        {
            get
            {
                return (Size)GetValue(ThumbSizeProperty);
            }
            set
            {
                SetValue(ThumbSizeProperty, value);
            }
        }

        /// <summary>
        /// The property to get/set Thumb object color of the CircularSlider.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color ThumbColor
        {
            get
            {
                return (Color)GetValue(ThumbColorProperty);
            }
            set
            {
                SetValue(ThumbColorProperty, value);
            }
        }

        /// <summary>
        /// Flag to be enabled or disabled in CircularSlider.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public bool? IsEnabled
        {
            get
            {
                return (bool?)GetValue(IsEnabledProperty);
            }
            set
            {
                SetValue(IsEnabledProperty, value);
            }
        }

        private void Initialize()
        {
            isEnabled = true;
            thickness = 6.0f;
            maxValue = 100.0f;
            minValue = 0.0f;
            currentValue = 0.0f;
            trackColor = new Color(0.0f, 0.16f, 0.30f, 1.0f); // #002A4D
            progressColor = new Color(0.0f, 0.55f, 1.0f, 1.0f); // #008CFF
            thumbSize = new Size(19, 19);
            thumbColor = new Color(0.0f, 0.55f, 1.0f, 1.0f); // #008CFF
        }
    }
}
