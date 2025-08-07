/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Accessibility;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Slider value changed event data.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class SliderValueChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Current Slider value
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public float CurrentValue { get; set; }
    }

    /// <summary>
    /// Slider sliding started event data.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class SliderSlidingStartedEventArgs : EventArgs
    {
        /// <summary>
        /// Current Slider value
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public float CurrentValue { get; set; }
    }

    /// <summary>
    /// Slider sliding finished event data.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class SliderSlidingFinishedEventArgs : EventArgs
    {
        /// <summary>
        /// Current Slider value
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public float CurrentValue { get; set; }
    }

    /// <summary>
    /// A slider lets users select a value from a continuous or discrete range of values by moving the slider thumb.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public partial class Slider : Control, IAtspiValue
    {
        static Slider()
        {
            if (NUIApplication.IsUsingXaml)
            {
                IndicatorProperty = BindableProperty.Create(nameof(Indicator), typeof(IndicatorType), typeof(Slider), IndicatorType.None,
                    propertyChanged: SetInternalIndicatorProperty, defaultValueCreator: GetInternalIndicatorProperty);
                SpaceBetweenTrackAndIndicatorProperty = BindableProperty.Create(nameof(SpaceBetweenTrackAndIndicator), typeof(uint), typeof(Slider), (uint)0,
                    propertyChanged: SetInternalSpaceBetweenTrackAndIndicatorProperty, defaultValueCreator: GetInternalSpaceBetweenTrackAndIndicatorProperty);
                TrackThicknessProperty = BindableProperty.Create(nameof(TrackThickness), typeof(uint), typeof(Slider), (uint)0,
                    propertyChanged: SetInternalTrackThicknessProperty, defaultValueCreator: GetInternalTrackThicknessProperty);
                IsValueShownProperty = BindableProperty.Create(nameof(IsValueShown), typeof(bool), typeof(Slider), true,
                    propertyChanged: SetInternalIsValueShownProperty, defaultValueCreator: GetInternalIsValueShownProperty);
                ValueIndicatorTextProperty = BindableProperty.Create(nameof(ValueIndicatorText), typeof(string), typeof(Slider), string.Empty,
                    propertyChanged: SetInternalValueIndicatorTextProperty, defaultValueCreator: GetInternalValueIndicatorTextProperty);
                CurrentValueProperty = BindableProperty.Create(nameof(CurrentValue), typeof(float), typeof(Slider), 0.0f, BindingMode.TwoWay,
                    propertyChanged: SetInternalCurrentValueProperty, defaultValueCreator: GetInternalCurrentValueProperty);
                DirectionProperty = BindableProperty.Create(nameof(Direction), typeof(DirectionType), typeof(Slider), default(DirectionType),
                    propertyChanged: SetInternalDirectionProperty, defaultValueCreator: GetInternalDirectionProperty);
                MinValueProperty = BindableProperty.Create(nameof(MinValue), typeof(float), typeof(Slider), default(float),
                    propertyChanged: SetInternalMinValueProperty, defaultValueCreator: GetInternalMinValueProperty);
                MaxValueProperty = BindableProperty.Create(nameof(MaxValue), typeof(float), typeof(Slider), default(float),
                    propertyChanged: SetInternalMaxValueProperty, defaultValueCreator: GetInternalMaxValueProperty);
                ThumbSizeProperty = BindableProperty.Create(nameof(ThumbSize), typeof(Size), typeof(Slider), null,
                    propertyChanged: SetInternalThumbSizeProperty, defaultValueCreator: GetInternalThumbSizeProperty);
                ThumbImageURLProperty = BindableProperty.Create(nameof(ThumbImageURL), typeof(string), typeof(Slider), default(string),
                    propertyChanged: SetInternalThumbImageURLProperty, defaultValueCreator: GetInternalThumbImageURLProperty);
                ThumbImageURLSelectorProperty = BindableProperty.Create(nameof(ThumbImageURLSelector), typeof(StringSelector), typeof(Slider), null,
                    propertyChanged: SetInternalThumbImageURLSelectorProperty, defaultValueCreator: GetInternalThumbImageURLSelectorProperty);
                ThumbImageUrlProperty = BindableProperty.Create(nameof(ThumbImageUrl), typeof(Selector<string>), typeof(Slider), null,
                    propertyChanged: SetInternalThumbImageUrlProperty, defaultValueCreator: GetInternalThumbImageUrlProperty);
                ThumbColorProperty = BindableProperty.Create(nameof(ThumbColor), typeof(Color), typeof(Slider), null,
                    propertyChanged: SetInternalThumbColorProperty, defaultValueCreator: GetInternalThumbColorProperty);
                BgTrackColorProperty = BindableProperty.Create(nameof(BgTrackColor), typeof(Color), typeof(Slider), null,
                    propertyChanged: SetInternalBgTrackColorProperty, defaultValueCreator: GetInternalBgTrackColorProperty);
                SlidedTrackColorProperty = BindableProperty.Create(nameof(SlidedTrackColor), typeof(Color), typeof(Slider), null,
                    propertyChanged: SetInternalSlidedTrackColorProperty, defaultValueCreator: GetInternalSlidedTrackColorProperty);
                WarningStartValueProperty = BindableProperty.Create(nameof(WarningStartValue), typeof(float), typeof(Slider), default(float),
                    propertyChanged: SetInternalWarningStartValueProperty, defaultValueCreator: GetInternalWarningStartValueProperty);
                WarningTrackColorProperty = BindableProperty.Create(nameof(WarningTrackColor), typeof(Color), typeof(Slider), null,
                    propertyChanged: SetInternalWarningTrackColorProperty, defaultValueCreator: GetInternalWarningTrackColorProperty);
                WarningSlidedTrackColorProperty = BindableProperty.Create(nameof(WarningSlidedTrackColor), typeof(Color), typeof(Slider), null,
                    propertyChanged: SetInternalWarningSlidedTrackColorProperty, defaultValueCreator: GetInternalWarningSlidedTrackColorProperty);
                WarningThumbImageUrlProperty = BindableProperty.Create(nameof(WarningThumbImageUrl), typeof(Tizen.NUI.BaseComponents.Selector<string>), typeof(Slider), null,
                    propertyChanged: SetInternalWarningThumbImageUrlProperty, defaultValueCreator: GetInternalWarningThumbImageUrlProperty);
                WarningThumbColorProperty = BindableProperty.Create(nameof(WarningThumbColor), typeof(Color), typeof(Slider), null,
                    propertyChanged: SetInternalWarningThumbColorProperty, defaultValueCreator: GetInternalWarningThumbColorProperty);
                LowIndicatorImageURLProperty = BindableProperty.Create(nameof(LowIndicatorImageURL), typeof(string), typeof(Slider), default(string),
                    propertyChanged: SetInternalLowIndicatorImageURLProperty, defaultValueCreator: GetInternalLowIndicatorImageURLProperty);
                HighIndicatorImageURLProperty = BindableProperty.Create(nameof(HighIndicatorImageURL), typeof(string), typeof(Slider), default(string),
                    propertyChanged: SetInternalHighIndicatorImageURLProperty, defaultValueCreator: GetInternalHighIndicatorImageURLProperty);
                LowIndicatorTextContentProperty = BindableProperty.Create(nameof(LowIndicatorTextContent), typeof(string), typeof(Slider), default(string),
                    propertyChanged: SetInternalLowIndicatorTextContentProperty, defaultValueCreator: GetInternalLowIndicatorTextContentProperty);
                HighIndicatorTextContentProperty = BindableProperty.Create(nameof(HighIndicatorTextContent), typeof(string), typeof(Slider), default(string),
                    propertyChanged: SetInternalHighIndicatorTextContentProperty, defaultValueCreator: GetInternalHighIndicatorTextContentProperty);
                LowIndicatorSizeProperty = BindableProperty.Create(nameof(LowIndicatorSize), typeof(Size), typeof(Slider), null,
                    propertyChanged: SetInternalLowIndicatorSizeProperty, defaultValueCreator: GetInternalLowIndicatorSizeProperty);
                HighIndicatorSizeProperty = BindableProperty.Create(nameof(HighIndicatorSize), typeof(Size), typeof(Slider), null,
                    propertyChanged: SetInternalHighIndicatorSizeProperty, defaultValueCreator: GetInternalHighIndicatorSizeProperty);
                ValueIndicatorSizeProperty = BindableProperty.Create(nameof(ValueIndicatorSize), typeof(Size), typeof(Slider), null,
                    propertyChanged: SetInternalValueIndicatorSizeProperty, defaultValueCreator: GetInternalValueIndicatorSizeProperty);
                ValueIndicatorUrlProperty = BindableProperty.Create(nameof(ValueIndicatorUrl), typeof(string), typeof(Slider), default(string),
                    propertyChanged: SetInternalValueIndicatorUrlProperty, defaultValueCreator: GetInternalValueIndicatorUrlProperty);
                IsDiscreteProperty = BindableProperty.Create(nameof(IsDiscrete), typeof(bool), typeof(Slider), default(bool),
                    propertyChanged: SetInternalIsDiscreteProperty, defaultValueCreator: GetInternalIsDiscreteProperty);
                DiscreteValueProperty = BindableProperty.Create(nameof(DiscreteValue), typeof(float), typeof(Slider), default(float),
                    propertyChanged: SetInternalDiscreteValueProperty, defaultValueCreator: GetInternalDiscreteValueProperty);
            }
        }

        /// <summary>
        /// The constructor of the Slider class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Slider()
        {
            Focusable = true;
            Initialize();
        }

        /// <summary>
        /// The constructor of the Slider class with specific style.
        /// </summary>
        /// <param name="style">The string to initialize the Slider</param>
        /// <since_tizen> 8 </since_tizen>
        public Slider(string style) : base(style)
        {
            Focusable = true;
            Initialize();
        }

        /// <summary>
        /// The constructor of the Slider class with specific style.
        /// </summary>
        /// <param name="sliderStyle">The style object to initialize the Slider</param>
        /// <since_tizen> 8 </since_tizen>
        public Slider(SliderStyle sliderStyle) : base(sliderStyle)
        {
            Focusable = true;
            Initialize();
        }

        /// <summary>
        /// The value changed event handler.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<SliderValueChangedEventArgs> ValueChanged
        {
            add
            {
                sliderValueChangedHandler += value;
            }
            remove
            {
                sliderValueChangedHandler -= value;
            }
        }

        /// <summary>
        /// The sliding started event handler.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<SliderSlidingStartedEventArgs> SlidingStarted
        {
            add
            {
                sliderSlidingStartedHandler += value;
            }
            remove
            {
                sliderSlidingStartedHandler -= value;
            }
        }

        /// <summary>
        /// The sliding finished event handler.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<SliderSlidingFinishedEventArgs> SlidingFinished
        {
            add
            {
                sliderSlidingFinishedHandler += value;
            }
            remove
            {
                sliderSlidingFinishedHandler -= value;
            }
        }

        /// <summary>
        /// The direction type of slider.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public enum DirectionType
        {
            /// <summary>
            /// The Horizontal type.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            Horizontal,

            /// <summary>
            /// The Vertical type.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            Vertical
        }

        /// <summary>
        /// The indicator type of slider.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public enum IndicatorType
        {
            /// <summary> Only contains slider bar.</summary>
            /// <since_tizen> 6 </since_tizen>
            None,

            /// <summary> Contains slider bar, IndicatorImage.</summary>
            /// <since_tizen> 6 </since_tizen>
            Image,

            /// <summary> Contains slider bar, IndicatorText.</summary>
            /// <since_tizen> 6 </since_tizen>
            Text
        }

        /// <summary>
        /// Return currently applied style.
        /// </summary>
        /// <remarks>
        /// Modifying contents in style may cause unexpected behaviour.
        /// </remarks>
        /// <since_tizen> 8 </since_tizen>
        public SliderStyle Style => (SliderStyle)(ViewStyle as SliderStyle)?.Clone();

        /// <summary>
        /// Gets or sets the direction type of slider.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public DirectionType Direction
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (DirectionType)GetValue(DirectionProperty);
                }
                else
                {
                    return InternalDirection;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(DirectionProperty, value);
                }
                else
                {
                    InternalDirection = value;
                }
                NotifyPropertyChanged();
            }
        }
        private DirectionType InternalDirection
        {
            get
            {
                return direction;
            }
            set
            {
                if (direction == value)
                {
                    return;
                }
                direction = value;
                RelayoutBaseComponent(false);
                UpdateBgTrackSize();
                UpdateBgTrackPosition();
                UpdateWarningTrackSize();
                UpdateValue();
            }
        }

        /// <summary>
        /// Gets or sets the indicator type, arrow or sign.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public IndicatorType Indicator
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (IndicatorType)GetValue(IndicatorProperty);
                }
                else
                {
                    return privateIndicatorType;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IndicatorProperty, value);
                }
                else
                {
                    privateIndicatorType = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the minimum value of slider.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float MinValue
        {
            get
            {
                if (!NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(MinValueProperty);
                }
                else
                {
                    return InternalMinValue;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(MinValueProperty, value);
                }
                else
                {
                    InternalMinValue = value;
                }
                NotifyPropertyChanged();
            }
        }
        private float InternalMinValue
        {
            get
            {
                return minValue;
            }
            set
            {
                minValue = value;
                UpdateValue();
            }
        }

        /// <summary>
        /// Gets or sets the maximum value of slider.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float MaxValue
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(MaxValueProperty);
                }
                else
                {
                    return InternalMaxValue;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(MaxValueProperty, value);
                }
                else
                {
                    InternalMaxValue = value;
                }
                NotifyPropertyChanged();
            }
        }
        private float InternalMaxValue
        {
            get
            {
                return maxValue;
            }
            set
            {
                maxValue = value;
                UpdateValue();
            }
        }

        /// <summary>
        /// Gets or sets the current value of slider.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float CurrentValue
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(CurrentValueProperty);
                }
                else
                {
                    return GetInternalCurrentValue();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CurrentValueProperty, value);
                }
                else
                {
                    SetInternalCurrentValue(value);
                }
            }
        }

        private void SetInternalCurrentValue(float newValue)
        {
            float value = (float)newValue;
            if (value < minValue)
            {
                curValue = minValue;
            }
            else if (value > maxValue)
            {
                curValue = maxValue;
            }
            else
            {
                curValue = value;
            }

            sliderValueChangedHandler?.Invoke(this, new SliderValueChangedEventArgs
            {
                CurrentValue = curValue
            });
            if (Accessibility.Accessibility.IsEnabled && IsHighlighted)
            {
                EmitAccessibilityEvent(AccessibilityPropertyChangeEvent.Value);
            }
            UpdateValue();
        }

        private float GetInternalCurrentValue()
        {
            return curValue;
        }

        /// <summary>
        /// Gets or sets the size of the thumb image object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Size ThumbSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(ThumbSizeProperty) as Size;
                }
                else
                {
                    return InternalThumbSize;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ThumbSizeProperty, value);
                }
                else
                {
                    if (value != null)
                    {
                        InternalThumbSize = value;
                    }
                }
                NotifyPropertyChanged();
            }
        }
        private Size InternalThumbSize
        {
            get
            {
                return thumbImage?.Size;
            }
            set
            {
                if (null != thumbImage)
                {
                    thumbImage.Size = value;
                    thumbSize = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the resource url of the thumb image object.
        ///
        /// Please use ThumbImageUrl property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string ThumbImageURL
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(ThumbImageURLProperty) as string;
                }
                else
                {
                    return InternalThumbImageURL;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ThumbImageURLProperty, value);
                }
                else
                {
                    if (value != null)
                    {
                        InternalThumbImageURL = value;
                    }
                }
                NotifyPropertyChanged();
            }
        }
        private string InternalThumbImageURL
        {
            get
            {
                return thumbImage?.ResourceUrl;
            }
            set
            {
                if (null != thumbImage)
                {
                    thumbImage.ResourceUrl = value;
                    thumbImageUrl = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the resource url selector of the thumb image object.
        /// Getter returns copied selector value if exist, null otherwise.
        ///
        /// Please use ThumbImageUrl property.
        /// </summary>
        /// <exception cref="NullReferenceException">Thrown when setting null value.</exception>
        /// <since_tizen> 6 </since_tizen>
        public StringSelector ThumbImageURLSelector
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(ThumbImageURLSelectorProperty) as StringSelector;
                }
                else
                {
                    return InternalThumbImageURLSelector;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ThumbImageURLSelectorProperty, value);
                }
                else
                {
                    //NOTE: null value is allowed here.
                    InternalThumbImageURLSelector = value;
                }
                NotifyPropertyChanged();
            }
        }
        private StringSelector InternalThumbImageURLSelector
        {
            get
            {
                Selector<string> resourceUrlSelector = thumbImage?.ResourceUrlSelector;
                if(resourceUrlSelector != null)
                {
                    return new StringSelector(resourceUrlSelector);
                }
                return null;
            }
            set
            {
                if (value == null || thumbImage == null)
                {
                    throw new NullReferenceException("Slider.ThumbImageURLSelector is null");
                }
                else
                {
                    thumbImage.ResourceUrlSelector = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Url of the thumb image.
        /// </summary>
        /// <exception cref="NullReferenceException">Thrown when setting null value.</exception>
        /// <since_tizen> 9 </since_tizen>
        public Selector<string> ThumbImageUrl
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(ThumbImageUrlProperty) as Selector<string>;
                }
                else
                {
                    return InternalThumbImageUrl;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ThumbImageUrlProperty, value);
                }
                else
                {
                    if (value != null)
                    {
                        InternalThumbImageUrl = value;
                    }
                }
                NotifyPropertyChanged();
            }
        }
        private Selector<string> InternalThumbImageUrl
        {
            get
            {
                if (thumbImage == null)
                {
                    return null;
                }
                else
                {
                    return thumbImage.ResourceUrlSelector;
                }
            }
            set
            {
                if (value == null || thumbImage == null)
                {
                    throw new NullReferenceException("Slider.ThumbImageUrl is null");
                }
                else
                {
                    thumbImage.ResourceUrlSelector = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the thumb image object.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Color ThumbColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(ThumbColorProperty) as Color;
                }
                else
                {
                    return InternalThumbColor;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ThumbColorProperty, value);
                }
                else
                {
                    if (value != null)
                    {
                        InternalThumbColor = value;
                    }
                }
                NotifyPropertyChanged();
            }
        }
        private Color InternalThumbColor
        {
            get
            {
                return thumbColor;
            }
            set
            {
                if (null != thumbImage)
                {
                    thumbColor = value;

                    if (thumbImage.ResourceUrl != null)
                    {
                        thumbImage.ResourceUrl = null;
                    }

                    using (PropertyMap map = new PropertyMap())
                    {
                        // To remove CA2000 warning messages, use `using` statement.
                        using (PropertyValue type = new PropertyValue((int)Visual.Type.Color))
                        {
                            map.Insert((int)Visual.Property.Type, type);
                        }
                        using (PropertyValue color = new PropertyValue(thumbColor))
                        {
                            map.Insert((int)ColorVisualProperty.MixColor, color);
                        }
                        using (PropertyValue radius = new PropertyValue(0.5f))
                        {
                            map.Insert((int)Visual.Property.CornerRadius, radius);
                        }
                        using (PropertyValue policyType = new PropertyValue((int)VisualTransformPolicyType.Relative))
                        {
                            map.Insert((int)Visual.Property.CornerRadiusPolicy, policyType);
                        }
                        thumbImage.Image = map;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the background track image object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Color BgTrackColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(BgTrackColorProperty) as Color;
                }
                else
                {
                    return InternalBgTrackColor;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BgTrackColorProperty, value);
                }
                else
                {
                    if (value != null)
                    {
                        InternalBgTrackColor = value;
                    }
                }
                NotifyPropertyChanged();
            }
        }
        private Color InternalBgTrackColor
        {
            get
            {
                return bgTrackImage?.BackgroundColor;
            }
            set
            {
                if (null != bgTrackImage)
                {
                    bgTrackImage.BackgroundColor = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the slided track image object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Color SlidedTrackColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(SlidedTrackColorProperty) as Color;
                }
                else
                {
                    return InternalSlidedTrackColor;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SlidedTrackColorProperty, value);
                }
                else
                {
                    if (value != null)
                    {
                        InternalSlidedTrackColor = value;
                    }
                }
                NotifyPropertyChanged();
            }
        }
        private Color InternalSlidedTrackColor
        {
            get
            {
                return slidedTrackImage?.BackgroundColor;
            }
            set
            {
                if (null != slidedTrackImage)
                {
                    slidedTrackImage.BackgroundColor = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the thickness value of the track.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public uint TrackThickness
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (uint)GetValue(TrackThicknessProperty);
                }
                else
                {
                    return privateTrackThickness;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TrackThicknessProperty, value);
                }
                else
                {
                    privateTrackThickness = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the warning start value between minimum value and maximum value of slider.
        /// </summary>
        /// This will be public opened later after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float WarningStartValue
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(WarningStartValueProperty);
                }
                else
                {
                    return InternalWarningStartValue;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(WarningStartValueProperty, value);
                }
                else
                {
                    InternalWarningStartValue = value;
                }
                NotifyPropertyChanged();
            }
        }
        private float InternalWarningStartValue
        {
            get
            {
                return warningStartValue;
            }
            set
            {
                warningStartValue = value;
                UpdateValue();
            }
        }

        /// <summary>
        /// Gets or sets the color of the warning track image object.
        /// </summary>
        /// This will be public opened later after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color WarningTrackColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(WarningTrackColorProperty) as Color;
                }
                else
                {
                    return InternalWarningTrackColor;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(WarningTrackColorProperty, value);
                }
                else
                {
                    if (value != null)
                    {
                        InternalWarningTrackColor = value;
                    }
                }
                NotifyPropertyChanged();
            }
        }
        private Color InternalWarningTrackColor
        {
            get
            {
                return warningTrackImage?.BackgroundColor;
            }
            set
            {
                if (null != warningTrackImage)
                {
                    warningTrackImage.BackgroundColor = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the warning slided track image object.
        /// </summary>
        /// This will be public opened later after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color WarningSlidedTrackColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(WarningSlidedTrackColorProperty) as Color;
                }
                else
                {
                    return InternalWarningSlidedTrackColor;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(WarningSlidedTrackColorProperty, value);
                }
                else
                {
                    if (value != null)
                    {
                        InternalWarningSlidedTrackColor = value;
                    }
                }
                NotifyPropertyChanged();
            }
        }
        private Color InternalWarningSlidedTrackColor
        {
            get
            {
                return warningSlidedTrackImage?.BackgroundColor;
            }
            set
            {
                if (null != warningSlidedTrackImage)
                {
                    warningSlidedTrackImage.BackgroundColor = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Url of the warning thumb image.
        /// </summary>
        /// <exception cref="NullReferenceException">Thrown when setting null value.</exception>
        /// This will be public opened later after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> WarningThumbImageUrl
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(WarningThumbImageUrlProperty) as Selector<string>;
                }
                else
                {
                    return InternalWarningThumbImageUrl;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(WarningThumbImageUrlProperty, value);
                }
                else
                {
                    if (value != null)
                    {
                        InternalWarningThumbImageUrl = value;
                    }
                }
                NotifyPropertyChanged();
            }
        }
        private Selector<string> InternalWarningThumbImageUrl
        {
            get
            {
                return warningThumbImageUrlSelector;
            }
            set
            {
                if (value == null || thumbImage == null)
                {
                    throw new NullReferenceException("Slider.WarningThumbImageUrl is null");
                }
                else
                {
                    warningThumbImageUrlSelector = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the warning thumb image object.
        /// </summary>
        /// This will be public opened later after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color WarningThumbColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(WarningThumbColorProperty) as Color;
                }
                else
                {
                    return InternalWarningThumbColor;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(WarningThumbColorProperty, value);
                }
                else
                {
                    if (value != null)
                    {
                        InternalWarningThumbColor = value;
                    }
                }
                NotifyPropertyChanged();
            }
        }
        private Color InternalWarningThumbColor
        {
            get
            {
                return warningThumbColor;
            }
            set
            {
                warningThumbColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the resource url of the low indicator image object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string LowIndicatorImageURL
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(LowIndicatorImageURLProperty) as string;
                }
                else
                {
                    return InternalLowIndicatorImageURL;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LowIndicatorImageURLProperty, value);
                }
                else
                {
                    if (value != null)
                    {
                        InternalLowIndicatorImageURL = value;
                    }
                }
                NotifyPropertyChanged();
            }
        }
        private string InternalLowIndicatorImageURL
        {
            get
            {
                return lowIndicatorImage?.ResourceUrl;
            }
            set
            {
                if (null == lowIndicatorImage)
                {
                    lowIndicatorImage = new ImageView
                    {
                        AccessibilityHidden = true,
                    };
                }

                lowIndicatorImage.ResourceUrl = value;
            }
        }

        /// <summary>
        /// Gets or sets the resource url of the high indicator image object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string HighIndicatorImageURL
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(HighIndicatorImageURLProperty) as string;
                }
                else
                {
                    return InternalHighIndicatorImageURL;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(HighIndicatorImageURLProperty, value);
                }
                else
                {
                    if (value != null)
                    {
                        InternalHighIndicatorImageURL = value;
                    }
                }
                NotifyPropertyChanged();
            }
        }
        private string InternalHighIndicatorImageURL
        {
            get
            {
                return highIndicatorImage?.ResourceUrl;
            }
            set
            {
                if (null == highIndicatorImage)
                {
                    highIndicatorImage = new ImageView
                    {
                        AccessibilityHidden = true,
                    };
                }

                highIndicatorImage.ResourceUrl = value;
            }
        }

        /// <summary>
        /// Gets or sets the text content of the low indicator text object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string LowIndicatorTextContent
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(LowIndicatorTextContentProperty) as string;
                }
                else
                {
                    return InternalLowIndicatorTextContent;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LowIndicatorTextContentProperty, value);
                }
                else
                {
                    if (value != null)
                    {
                        InternalLowIndicatorTextContent = value;
                    }
                }
                NotifyPropertyChanged();
            }
        }
        private string InternalLowIndicatorTextContent
        {
            get
            {
                return lowIndicatorText?.Text;
            }
            set
            {
                if (null != lowIndicatorText)
                {
                    lowIndicatorText.Text = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the text content of the high indicator text object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string HighIndicatorTextContent
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(HighIndicatorTextContentProperty) as string;
                }
                else
                {
                    return InternalHighIndicatorTextContent;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(HighIndicatorTextContentProperty, value);
                }
                else
                {
                    if (value != null)
                    {
                        InternalHighIndicatorTextContent = value;
                    }
                }
                NotifyPropertyChanged();
            }
        }
        private string InternalHighIndicatorTextContent
        {
            get
            {
                return highIndicatorText?.Text;
            }
            set
            {
                if (null != highIndicatorText)
                {
                    highIndicatorText.Text = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the size of the low indicator object(image or text).
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Size LowIndicatorSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(LowIndicatorSizeProperty) as Size;
                }
                else
                {
                    return InternalLowIndicatorSize;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LowIndicatorSizeProperty, value);
                }
                else
                {
                    if (value != null)
                    {
                        InternalLowIndicatorSize = value;
                    }
                }
                NotifyPropertyChanged();
            }
        }
        private Size InternalLowIndicatorSize
        {
            get
            {
                return lowIndicatorSize;
            }
            set
            {
                lowIndicatorSize = value;
                UpdateLowIndicatorSize();
                UpdateBgTrackSize();
                UpdateBgTrackPosition();
                UpdateValue();
            }
        }

        /// <summary>
        /// Gets or sets the size of the high indicator object(image or text).
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Size HighIndicatorSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(HighIndicatorSizeProperty) as Size;
                }
                else
                {
                    return InternalHighIndicatorSize;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(HighIndicatorSizeProperty, value);
                }
                else
                {
                    if (value != null)
                    {
                        InternalHighIndicatorSize = value;
                    }
                }
                NotifyPropertyChanged();
            }
        }
        private Size InternalHighIndicatorSize
        {
            get
            {
                return highIndicatorSize;
            }
            set
            {
                highIndicatorSize = value;
                UpdateHighIndicatorSize();
                UpdateBgTrackSize();
                UpdateBgTrackPosition();
                UpdateValue();
            }
        }

        /// <summary>
        /// Gets or sets the value of the space between track and indicator.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public uint SpaceBetweenTrackAndIndicator
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (uint)GetValue(SpaceBetweenTrackAndIndicatorProperty);
                }
                else
                {
                    return privateSpaceBetweenTrackAndIndicator;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SpaceBetweenTrackAndIndicatorProperty, value);
                }
                else
                {
                    privateSpaceBetweenTrackAndIndicator = value;
                }
            }
        }

        /// <summary>
        /// Flag to decide whether the value indicator is shown
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public bool IsValueShown
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(IsValueShownProperty);
                }
                else
                {
                    return GetInternalIsValueShown();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IsValueShownProperty, value);
                }
                else
                {
                    SetInternalIsValueShown(value);
                }
            }
        }

        private void SetInternalIsValueShown(bool newValue)
        {
            bool newValueShown = newValue;
            if (isValueShown != newValueShown)
            {
                isValueShown = newValueShown;
            }
        }

        private bool GetInternalIsValueShown()
        {
            return isValueShown;
        }

        /// <summary>
        /// Gets or sets the text of value indicator.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string ValueIndicatorText
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(ValueIndicatorTextProperty);
                }
                else
                {
                    return valueIndicatorText.Text;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ValueIndicatorTextProperty, value);
                }
                else
                {
                    if (value != null)
                    {
                        valueIndicatorText.Text = value;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the size of the value indicator image object.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Size ValueIndicatorSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(ValueIndicatorSizeProperty) as Size;
                }
                else
                {
                    return InternalValueIndicatorSize;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ValueIndicatorSizeProperty, value);
                }
                else
                {
                    if (value != null)
                    {
                        InternalValueIndicatorSize = value;
                    }
                }
                NotifyPropertyChanged();
            }
        }
        private Size InternalValueIndicatorSize
        {
            get
            {
                return valueIndicatorImage?.Size;
            }
            set
            {
                if (null != valueIndicatorImage)
                {
                    valueIndicatorImage.Size = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the resource url of the value indicator image object.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string ValueIndicatorUrl
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(ValueIndicatorUrlProperty) as string;
                }
                else
                {
                    return InternalValueIndicatorUrl;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ValueIndicatorUrlProperty, value);
                }
                else
                {
                    if (value != null)
                    {
                        InternalValueIndicatorUrl = value;
                    }
                }
                NotifyPropertyChanged();
            }
        }
        private string InternalValueIndicatorUrl
        {
            get
            {
                return valueIndicatorImage?.ResourceUrl;
            }
            set
            {
                if (null != valueIndicatorImage)
                {
                    valueIndicatorImage.ResourceUrl = value;
                }
            }
        }

        /// <summary>
        /// Flag to decide whether the thumb snaps to the nearest discrete value when the user drags the thumb or taps.
        ///
        /// The default value is false.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public bool IsDiscrete
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(IsDiscreteProperty);
                }
                else
                {
                    return InternalIsDiscrete;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IsDiscreteProperty, value);
                }
                else
                {
                    InternalIsDiscrete = value;
                }
                NotifyPropertyChanged();
            }
        }
        private bool InternalIsDiscrete { get; set; } = false;

        /// <summary>
        /// Gets or sets the discrete value of slider.
        /// </summary>
        /// <remarks>
        /// The discrete value is evenly spaced between MinValue and MaxValue.
        /// For example, MinValue is 0, MaxValue is 100, and DiscreteValue is 20.
        /// Then, the thumb can only go to 0, 20, 40, 60, 80, and 100.
        /// The default is 0.
        /// </remarks>
        /// <since_tizen> 9 </since_tizen>
        public float DiscreteValue
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(DiscreteValueProperty);
                }
                else
                {
                    return InternalDiscreteValue;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(DiscreteValueProperty, value);
                }
                else
                {
                    InternalDiscreteValue = value;
                }
                NotifyPropertyChanged();
            }
        }
        private float InternalDiscreteValue
        {
            get
            {
                return discreteValue;
            }
            set
            {
                discreteValue = value;
                UpdateValue();
            }
        }

        private Extents spaceBetweenTrackAndIndicator
        {
            get
            {
                if (null == spaceTrackIndicator)
                {
                    spaceTrackIndicator = new Extents((ushort start, ushort end, ushort top, ushort bottom) =>
                    {
                        Extents extents = new Extents(start, end, top, bottom);
                        spaceTrackIndicator.CopyFrom(extents);
                    }, 0, 0, 0, 0);
                }

                return spaceTrackIndicator;
            }
        }

        private IndicatorType privateIndicatorType
        {
            get
            {
                return indicatorType;
            }
            set
            {
                if (indicatorType == value)
                {
                    return;
                }
                indicatorType = value;
                RelayoutBaseComponent(false);
                UpdateBgTrackSize();
                UpdateBgTrackPosition();
                UpdateValue();
            }
        }

        private uint privateTrackThickness
        {
            get
            {
                return trackThickness ?? 0;
            }
            set
            {
                trackThickness = value;
                if (bgTrackImage != null)
                {
                    if (direction == DirectionType.Horizontal)
                    {
                        bgTrackImage.SizeHeight = (float)trackThickness.Value;
                    }
                    else if (direction == DirectionType.Vertical)
                    {
                        bgTrackImage.SizeWidth = (float)trackThickness.Value;
                    }
                }
                if (slidedTrackImage != null)
                {
                    if (direction == DirectionType.Horizontal)
                    {
                        slidedTrackImage.SizeHeight = (float)trackThickness.Value;
                    }
                    else if (direction == DirectionType.Vertical)
                    {
                        slidedTrackImage.SizeWidth = (float)trackThickness.Value;
                    }
                }
                if (warningTrackImage != null)
                {
                    if (direction == DirectionType.Horizontal)
                    {
                        warningTrackImage.SizeHeight = (float)trackThickness.Value;
                    }
                    else if (direction == DirectionType.Vertical)
                    {
                        warningTrackImage.SizeWidth = (float)trackThickness.Value;
                    }
                }
                if (warningSlidedTrackImage != null)
                {
                    if (direction == DirectionType.Horizontal)
                    {
                        warningSlidedTrackImage.SizeHeight = (float)trackThickness.Value;
                    }
                    else if (direction == DirectionType.Vertical)
                    {
                        warningSlidedTrackImage.SizeWidth = (float)trackThickness.Value;
                    }
                }
            }
        }

        private uint privateSpaceBetweenTrackAndIndicator
        {
            get
            {
                return privateTrackPadding.Start;
            }
            set
            {
                ushort val = (ushort)value;
                privateTrackPadding = new Extents(val, val, val, val);
            }
        }

        private Extents privateTrackPadding
        {
            get
            {
                return spaceBetweenTrackAndIndicator;
            }
            set
            {
                spaceBetweenTrackAndIndicator.CopyFrom(value);
                UpdateComponentByIndicatorTypeChanged();
                UpdateBgTrackSize();
                UpdateBgTrackPosition();
                UpdateValue();
            }
        }

        /// <summary>
        /// Focus gained callback.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public override void OnFocusGained()
        {
            //State = ControlStates.Focused;
            UpdateState(true, isPressed);
            base.OnFocusGained();
        }

        /// <summary>
        /// Focus Lost callback.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public override void OnFocusLost()
        {
            //State = ControlStates.Normal;
            UpdateState(false, isPressed);
            base.OnFocusLost();
        }

        private bool editMode = false;
        private View recoverIndicator;
        private View editModeIndicator;

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool OnKeyboardEnter()
        {
            if (!IsEnabled)
            {
                return false;
            }
            if (editMode)
            {
                //set editMode false (toggle the mode)
                editMode = false;
                FocusManager.Instance.FocusIndicator = recoverIndicator;
            }
            else
            {
                //set editMode true (toggle the mode)
                editMode = true;
                if (editModeIndicator == null)
                {
                    editModeIndicator = new View()
                    {
                        PositionUsesPivotPoint = true,
                        PivotPoint = new Position(0, 0, 0),
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                        BorderlineColor = Color.Red,
                        BorderlineWidth = 6.0f,
                        BorderlineOffset = -1f,
                        BackgroundColor = new Color(0.2f, 0.2f, 0.2f, 0.4f),
                        AccessibilityHidden = true,
                    };
                }
                recoverIndicator = FocusManager.Instance.FocusIndicator;
                FocusManager.Instance.FocusIndicator = editModeIndicator;
            }
            UpdateState(true, isPressed);
            return true;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool OnKey(Key key)
        {
            if (!IsEnabled || null == key)
            {
                return false;
            }

            if (key.State == Key.StateType.Down)
            {
                float valueDiff;
                if (IsDiscrete)
                {
                    valueDiff = discreteValue;
                }
                else
                {
                    // TODO : Currently we set the velocity of value as 1% hardly.
                    // Can we use AccessibilityGetMinimumIncrement?
                    valueDiff = (maxValue - minValue) * 0.01f;
                }
                if ((direction == DirectionType.Horizontal && key.KeyPressedName == "Left") ||
                    (direction == DirectionType.Vertical && key.KeyPressedName == "Down"))
                {
                    if (editMode)
                    {
                        if (minValue < curValue)
                        {
                            isPressed = true;
                            CurrentValue -= valueDiff;
                        }
                        return true; // Consumed
                    }
                }
                else if ((direction == DirectionType.Horizontal && key.KeyPressedName == "Right") ||
                         (direction == DirectionType.Vertical && key.KeyPressedName == "Up"))
                {
                    if (editMode)
                    {
                        if (maxValue > curValue)
                        {
                            isPressed = true;
                            CurrentValue += valueDiff;
                        }
                        return true; // Consumed
                    }
                }
            }
            else if (key.State == Key.StateType.Up)
            {
                isPressed = false;
            }

            if (key.KeyPressedName == "Up" || key.KeyPressedName == "Right" || key.KeyPressedName == "Down" || key.KeyPressedName == "Left")
            {
                if (editMode)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Apply style to scrollbar.
        /// </summary>
        /// <param name="viewStyle">The style to apply.</param>
        /// <since_tizen> 8 </since_tizen>
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            SliderStyle sliderStyle = viewStyle as SliderStyle;

            if (null != sliderStyle?.Progress)
            {
                CreateSlidedTrack().ApplyStyle(sliderStyle.Progress);
            }

            if (null != sliderStyle?.LowIndicator)
            {
                CreateLowIndicatorText().ApplyStyle(sliderStyle.LowIndicator);
            }

            if (null != sliderStyle?.HighIndicator)
            {
                CreateHighIndicatorText().ApplyStyle(sliderStyle.HighIndicator);
            }

            if (null != sliderStyle?.LowIndicatorImage)
            {
                CreateLowIndicatorImage().ApplyStyle(sliderStyle.LowIndicatorImage);
            }

            if (null != sliderStyle?.HighIndicatorImage)
            {
                CreateHighIndicatorImage().ApplyStyle(sliderStyle.HighIndicatorImage);
            }

            if (null != sliderStyle?.Track)
            {
                CreateBackgroundTrack().ApplyStyle(sliderStyle.Track);
            }

            if (null != sliderStyle?.Thumb)
            {
                CreateThumb().ApplyStyle(sliderStyle.Thumb);
            }

            if (null != sliderStyle?.ValueIndicatorText)
            {
                CreateValueIndicatorText().ApplyStyle(sliderStyle.ValueIndicatorText);
            }

            if (null != sliderStyle?.ValueIndicatorImage)
            {
                CreateValueIndicatorImage().ApplyStyle(sliderStyle.ValueIndicatorImage);
            }

            if (null != sliderStyle?.WarningTrack)
            {
                CreateWarningTrack().ApplyStyle(sliderStyle.WarningTrack);
            }

            if (null != sliderStyle?.WarningProgress)
            {
                CreateWarningSlidedTrack().ApplyStyle(sliderStyle.WarningProgress);
            }

            EnableControlStatePropagation = true;
        }

        /// <summary>
        /// Gets minimum value for Accessibility.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        double IAtspiValue.AccessibilityGetMinimum()
        {
            return (double)MinValue;
        }

        /// <summary>
        /// Gets the current value for Accessibility.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        double IAtspiValue.AccessibilityGetCurrent()
        {
            return (double)CurrentValue;
        }

        /// <summary>
        /// Formatted current value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        string IAtspiValue.AccessibilityGetValueText()
        {
            return $"{CurrentValue}";
        }

        /// <summary>
        /// Gets maximum value for Accessibility.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        double IAtspiValue.AccessibilityGetMaximum()
        {
            return (double)MaxValue;
        }

        /// <summary>
        /// Sets the current value using Accessibility.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool IAtspiValue.AccessibilitySetCurrent(double value)
        {
            var current = (float)value;

            if (current >= MinValue && current <= MaxValue)
            {
                CurrentValue = current;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets minimum increment for Accessibility.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        double IAtspiValue.AccessibilityGetMinimumIncrement()
        {
            // FIXME
            return (MaxValue - MinValue) / 20.0;
        }

        /// <summary>
        /// Initialize AT-SPI object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();
            AccessibilityRole = Role.Slider;
        }

        /// <summary>
        /// Get Slider style.
        /// </summary>
        /// <returns>The default slider style.</returns>
        /// <since_tizen> 8 </since_tizen>
        protected override ViewStyle CreateViewStyle()
        {
            return new SliderStyle();
        }

        /// <summary>
        /// Dispose Slider.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        /// <since_tizen> 6 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (null != panGestureDetector)
                {
                    panGestureDetector.Detach(this);
                    panGestureDetector.Detected -= OnPanGestureDetected;
                    panGestureDetector.Dispose();
                    panGestureDetector = null;
                }

                if (null != thumbImage)
                {
                    thumbImage.TouchEvent -= OnTouchEventForThumb;
                    Utility.Dispose(thumbImage);
                }
                Utility.Dispose(warningSlidedTrackImage);
                Utility.Dispose(warningTrackImage);
                Utility.Dispose(slidedTrackImage);
                Utility.Dispose(bgTrackImage);
                Utility.Dispose(lowIndicatorImage);
                Utility.Dispose(highIndicatorImage);
                Utility.Dispose(lowIndicatorText);
                Utility.Dispose(highIndicatorText);
                Utility.Dispose(valueIndicatorImage);
                Utility.Dispose(valueIndicatorText);

                this.TouchEvent -= OnTouchEventForTrack;

                recoverIndicator = null;
                if (editModeIndicator != null)
                {
                    editModeIndicator.Dispose();
                    editModeIndicator = null;
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Update Slider by style.
        /// </summary>
        /// This will be public opened later after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            RelayoutBaseComponent();

            UpdateComponentByIndicatorTypeChanged();
            UpdateBgTrackSize();
            UpdateBgTrackPosition();
            UpdateWarningTrackSize();
            UpdateLowIndicatorSize();
            UpdateHighIndicatorSize();
            UpdateValue();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnEnabled(bool enabled)
        {
            base.OnEnabled(enabled);
            UpdateValue();
        }

        private void CalculateCurrentValueByGesture(float offset)
        {
            currentSlidedOffset += offset;

            float resultValue = this.CurrentValue;

            int bgTrackLength = GetBgTrackLength();
            if (bgTrackLength != 0)
            {
                resultValue = ((currentSlidedOffset / (float)bgTrackLength) * (float)(maxValue - minValue)) + minValue;
            }

            if (IsDiscrete)
            {
                this.CurrentValue = CalculateDiscreteValue(resultValue);
            }
            else
            {
                this.CurrentValue = resultValue;
            }
        }

        private bool OnTouchEventForTrack(object source, TouchEventArgs e)
        {
            if (!IsEnabled)
            {
                return false;
            }

            if (this.FocusableInTouch == false && editMode == false)
            {
                isFocused = false;
            }

            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                if (isValueShown)
                {
                    valueIndicatorImage.Show();
                }

                UpdateState(isFocused, true);

                sliderSlidingStartedHandler?.Invoke(this, new SliderSlidingStartedEventArgs
                {
                    CurrentValue = curValue
                });

                Vector2 pos = e.Touch.GetLocalPosition(0);
                CalculateCurrentValueByTouch(pos);
                UpdateValue();
            }
            else if (state == PointStateType.Up)
            {
                if (isValueShown)
                {
                    valueIndicatorImage.Hide();
                }

                UpdateState(isFocused, false);

                sliderSlidingFinishedHandler?.Invoke(this, new SliderSlidingFinishedEventArgs
                {
                    CurrentValue = curValue
                });
            }
            return false;
        }

        private bool OnTouchEventForThumb(object source, TouchEventArgs e)
        {
            if (this.FocusableInTouch == false && editMode == false)
            {
                isFocused = false;
            }

            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                UpdateState(isFocused, true);
            }
            else if (state == PointStateType.Up)
            {
                UpdateState(isFocused, false);
            }
            return true;
        }

        private void CalculateCurrentValueByTouch(Vector2 pos)
        {
            int bgTrackLength = GetBgTrackLength();
            if (direction == DirectionType.Horizontal)
            {
                currentSlidedOffset = pos.X - GetBgTrackLowIndicatorOffset();
            }
            else if (direction == DirectionType.Vertical)
            {
                currentSlidedOffset = this.Size2D.Height - pos.Y - GetBgTrackLowIndicatorOffset();
            }

            if (bgTrackLength != 0)
            {
                float resultValue = ((currentSlidedOffset / (float)bgTrackLength) * (maxValue - minValue)) + minValue;

                if (IsDiscrete)
                {
                    this.CurrentValue = CalculateDiscreteValue(resultValue);
                }
                else
                {
                    this.CurrentValue = resultValue;
                }
            }
        }

        private float CalculateDiscreteValue(float value)
        {
            return ((float)Math.Round((value / discreteValue)) * discreteValue);
        }

        private void UpdateState(bool isFocusedNew, bool isPressedNew)
        {
            if (isFocused == isFocusedNew && isPressed == isPressedNew)
            {
                return;
            }
            if (thumbImage == null || Style == null)
            {
                return;
            }
            isFocused = isFocusedNew;
            isPressed = isPressedNew;

            if (!IsEnabled) // Disabled
            {
                ControlState = ControlState.Disabled;
            }
            else if (!isFocused && !isPressed)
            {
                ControlState = ControlState.Normal;
            }
            else if (isPressed)
            {
                ControlState = ControlState.Pressed;
            }
            else if (!isPressed && isFocused)
            {
                ControlState = ControlState.Focused;
            }
        }

        private void UpdateComponentByIndicatorTypeChanged()
        {
            IndicatorType type = CurrentIndicatorType();
            if (type == IndicatorType.None)
            {
                if (lowIndicatorImage != null)
                {
                    lowIndicatorImage.Hide();
                }
                if (highIndicatorImage != null)
                {
                    highIndicatorImage.Hide();
                }
                if (lowIndicatorText != null)
                {
                    lowIndicatorText.Hide();
                }
                if (highIndicatorText != null)
                {
                    highIndicatorText.Hide();
                }
            }
            else if (type == IndicatorType.Image)
            {
                if (lowIndicatorImage != null)
                {
                    lowIndicatorImage.Show();
                }
                if (highIndicatorImage != null)
                {
                    highIndicatorImage.Show();
                }
                if (lowIndicatorText != null)
                {
                    lowIndicatorText.Hide();
                }
                if (highIndicatorText != null)
                {
                    highIndicatorText.Hide();
                }
            }
            else if (type == IndicatorType.Text)
            {
                if (lowIndicatorText != null)
                {
                    lowIndicatorText.Show();
                }
                if (highIndicatorText != null)
                {
                    highIndicatorText.Show();
                }
                if (lowIndicatorImage != null)
                {
                    lowIndicatorImage.Hide();
                }
                if (highIndicatorImage != null)
                {
                    highIndicatorImage.Hide();
                }
            }
        }
    }
}
