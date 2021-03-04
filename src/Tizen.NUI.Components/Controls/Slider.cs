/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;
using System.ComponentModel;
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
    public partial class Slider : Control
    {
        /// <summary>
        /// IndicatorTypeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorTypeProperty = BindableProperty.Create("IndicatorType", typeof(IndicatorType), typeof(Slider), IndicatorType.None, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.privateIndicatorType = (IndicatorType)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.privateIndicatorType;
        });

        /// <summary>
        /// SpaceBetweenTrackAndIndicatorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SpaceBetweenTrackAndIndicatorProperty = BindableProperty.Create(nameof(SpaceBetweenTrackAndIndicator), typeof(uint), typeof(Slider), (uint)0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.privateSpaceBetweenTrackAndIndicator = (uint)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.privateSpaceBetweenTrackAndIndicator;
        });

        /// <summary>
        /// TrackThicknessProperty
        /// </summary>       
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackThicknessProperty = BindableProperty.Create(nameof(TrackThickness), typeof(uint), typeof(Slider), (uint)0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.privateTrackThickness = (uint)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.privateTrackThickness;
        });

        /// <summary>
        /// IsValueShownProperty
        /// </summary> 
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsValueShownProperty = BindableProperty.Create(nameof(IsValueShown), typeof(bool), typeof(Slider), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                bool newValueShown = (bool)newValue;
                if (instance.isValueShown != newValueShown)
                {
                    instance.isValueShown = newValueShown;
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.isValueShown;
        });

        /// <summary>
        /// ValueIndicatorTextProperty
        /// </summary> 
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ValueIndicatorTextProperty = BindableProperty.Create(nameof(ValueIndicatorText), typeof(string), typeof(Slider), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                string newText = (string)newValue;
                instance.valueIndicatorText.Text = newText;
                if (instance.sliderStyle != null)
                {
                    instance.sliderStyle.ValueIndicatorText.Text = newText;
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.valueIndicatorText.Text;
        });

        static Slider() { }

        /// <summary>
        /// The constructor of the Slider class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Slider()
        {
            Initialize();
        }

        /// <summary>
        /// The constructor of the Slider class with specific style.
        /// </summary>
        /// <param name="style">The string to initialize the Slider</param>
        /// <since_tizen> 8 </since_tizen>
        public Slider(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// The constructor of the Slider class with specific style.
        /// </summary>
        /// <param name="sliderStyle">The style object to initialize the Slider</param>
        /// <since_tizen> 8 </since_tizen>
        public Slider(SliderStyle sliderStyle) : base(sliderStyle)
        {
            Initialize();
        }

        /// <summary>
        /// The value changed event handler.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10. Please use ValueChanged event instead.")]
        public event EventHandler<ValueChangedArgs> ValueChangedEvent
        {
            add
            {
                valueChangedHandler += value;
            }
            remove
            {
                valueChangedHandler -= value;
            }
        }

        /// <summary>
        /// The sliding finished event handler.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10. Please use SlidingFinished event instead.")]
        public event EventHandler<SlidingFinishedArgs> SlidingFinishedEvent
        {
            add
            {
                slidingFinishedHandler += value;
            }
            remove
            {
                slidingFinishedHandler -= value;
            }
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
        /// The state changed event handler.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10. Please use View.ControlStateChangedEvent")]
        public event EventHandler<StateChangedArgs> StateChangedEvent
        {
            add
            {
                stateChangedHandler += value;
            }
            remove
            {
                stateChangedHandler -= value;
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
        /// Return a copied Style instance of Slider
        /// </summary>
        /// <remarks>
        /// It returns copied Style instance and changing it does not effect to the Slider.
        /// Style setting is possible by using constructor or the function of ApplyStyle(ViewStyle viewStyle)
        /// </remarks>
        /// <since_tizen> 8 </since_tizen>
        public new SliderStyle Style
        {
            get
            {
                var result = new SliderStyle(sliderStyle);
                result.CopyPropertiesFromView(this);
                result.Track.CopyPropertiesFromView(bgTrackImage);
                result.Progress.CopyPropertiesFromView(slidedTrackImage);
                result.Thumb.CopyPropertiesFromView(thumbImage);
                result.LowIndicatorImage.CopyPropertiesFromView(lowIndicatorImage);
                result.HighIndicatorImage.CopyPropertiesFromView(highIndicatorImage);
                result.LowIndicator.CopyPropertiesFromView(lowIndicatorText);
                result.HighIndicator.CopyPropertiesFromView(highIndicatorText);
                result.ValueIndicatorText.CopyPropertiesFromView(valueIndicatorText);
                result.ValueIndicatorImage.CopyPropertiesFromView(valueIndicatorImage);
                return result;
            }
        }

        /// <summary>
        /// Return a copied Style instance of Slider
        /// </summary>
        private SliderStyle sliderStyle => ViewStyle as SliderStyle;

        /// <summary>
        /// Gets or sets the direction type of slider.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public DirectionType Direction
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
                return (IndicatorType)GetValue(IndicatorTypeProperty);
            }
            set
            {
                SetValue(IndicatorTypeProperty, value);
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
                return curValue;
            }
            set
            {
                curValue = value;
                if (IsHighlighted)
                {
                    EmitAccessibilityEvent(ObjectPropertyChangeEvent.Value);
                }
                UpdateValue();
            }
        }

        /// <summary>
        /// Gets or sets the size of the thumb image object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Size ThumbSize
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
                    sliderStyle.Thumb.Size = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the resource url of the thumb image object.
        ///
        /// Please use ThumbImageUri property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string ThumbImageURL
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
                    sliderStyle.Thumb.ResourceUrl = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the resource url selector of the thumb image object.
        /// Getter returns copied selector value if exist, null otherwise.
        ///
        /// Please use ThumbImageUri property.
        /// </summary>
        /// <exception cref="NullReferenceException">Thrown when setting null value.</exception>
        /// <since_tizen> 6 </since_tizen>
        public StringSelector ThumbImageURLSelector
        {
            get => thumbImage == null ? null : new StringSelector((Selector<string>)thumbImage.GetValue(ImageView.ResourceUrlSelectorProperty));
            set
            {
                if (value == null || thumbImage == null)
                {
                    throw new NullReferenceException("Slider.ThumbImageURLSelector is null");
                }
                else
                {
                    thumbImage.SetValue(ImageView.ResourceUrlSelectorProperty, value);
                    thumbImageUrlSelector = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the Uri of the thumb image.
        /// </summary>
        /// <exception cref="NullReferenceException">Thrown when setting null value.</exception>
        /// This will be public opened later after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Uri> ThumbImageUri
        {
            get
            {
                if (thumbImage == null)
                {
                    return null;
                }
                else
                {
                    return ((Selector<string>)thumbImage.GetValue(ImageView.ResourceUrlSelectorProperty)).Clone<Uri>(str => { return new Uri(str); });
                }
            }
            set
            {
                if (value == null || thumbImage == null)
                {
                    throw new NullReferenceException("Slider.ThumbImageUri is null");
                }
                else
                {
                    Selector<string> stringValue = value.Clone<string>(m => m?.AbsoluteUri);
                    thumbImage.SetValue(ImageView.ResourceUrlSelectorProperty, stringValue);
                    thumbImageUrlSelector = stringValue;
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
                return thumbImage?.Color;
            }
            set
            {
                if (null != thumbImage)
                {
                    thumbImage.BackgroundColor = value;
                    thumbColor = value;
                    sliderStyle.Thumb.BackgroundColor = value;
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
                return bgTrackImage?.BackgroundColor;
            }
            set
            {
                if (null != bgTrackImage)
                {
                    bgTrackImage.BackgroundColor = value;
                    sliderStyle.Track.BackgroundColor = value;
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
                return slidedTrackImage?.BackgroundColor;
            }
            set
            {
                if (null != slidedTrackImage)
                {
                    slidedTrackImage.BackgroundColor = value;
                    sliderStyle.Progress.BackgroundColor = value;
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
                return (uint)GetValue(TrackThicknessProperty);
            }
            set
            {
                SetValue(TrackThicknessProperty, value);
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
                return warningTrackImage?.BackgroundColor;
            }
            set
            {
                if (null != warningTrackImage)
                {
                    warningTrackImage.BackgroundColor = value;
                    sliderStyle.WarningTrack.BackgroundColor = value;
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
                return warningSlidedTrackImage?.BackgroundColor;
            }
            set
            {
                if (null != warningSlidedTrackImage)
                {
                    warningSlidedTrackImage.BackgroundColor = value;
                    sliderStyle.WarningProgress.BackgroundColor = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the resource url of the warning thumb image object.
        /// </summary>
        /// This will be public opened later after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string WarningThumbImageUrl
        {
            get
            {
                return warningThumbImageUrl;
            }
            set
            {
                warningThumbImageUrl = value;
            }
        }

        /// <summary>
        /// Gets or sets the Uri of the warning thumb image.
        /// </summary>
        /// <exception cref="NullReferenceException">Thrown when setting null value.</exception>
        /// This will be public opened later after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Uri> WarningThumbImageUri
        {
            get
            {
                return warningThumbImageUrlSelector?.Clone<Uri>(str => { return new Uri(str); });
            }
            set
            {
                 if (value == null || thumbImage == null)
                {
                    throw new NullReferenceException("Slider.WarningThumbImageUri is null");
                }
                else
                {
                    warningThumbImageUrlSelector = value.Clone<string>(m => m?.AbsoluteUri);
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
                return lowIndicatorImage?.ResourceUrl;
            }
            set
            {
                if (null == lowIndicatorImage) lowIndicatorImage = new ImageView();
                lowIndicatorImage.ResourceUrl = value;
                sliderStyle.LowIndicatorImage.ResourceUrl = value;
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
                return highIndicatorImage?.ResourceUrl;
            }
            set
            {
                if (null == highIndicatorImage) highIndicatorImage = new ImageView();
                highIndicatorImage.ResourceUrl = value;
                sliderStyle.HighIndicatorImage.ResourceUrl = value;
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
                return lowIndicatorText?.Text;
            }
            set
            {
                if (null != lowIndicatorText)
                {
                    lowIndicatorText.Text = value;
                    sliderStyle.LowIndicator.Text = value;
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
                return highIndicatorText?.Text;
            }
            set
            {
                if (null != highIndicatorText)
                {
                    highIndicatorText.Text = value;
                    sliderStyle.HighIndicator.Text = value;
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
                return highIndicatorText?.Size;
            }
            set
            {
                if (null != highIndicatorText)
                {
                    highIndicatorText.Size = value;
                    sliderStyle.HighIndicator.Size = value;
                }
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
                return (uint)GetValue(SpaceBetweenTrackAndIndicatorProperty);
            }
            set
            {
                SetValue(SpaceBetweenTrackAndIndicatorProperty, value);
            }
        }

        /// <summary>
        /// Flag to decide whether the value indicator is shown
        /// </summary>
        /// This will be public opened later after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsValueShown
        {
            get
            {
                return (bool)GetValue(IsValueShownProperty);
            }
            set
            {
                SetValue(IsValueShownProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the text of value indicator.
        /// </summary>
        /// This will be public opened later after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ValueIndicatorText
        {
            get
            {
                return (string)GetValue(ValueIndicatorTextProperty);
            }
            set
            {
                SetValue(ValueIndicatorTextProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the value indicator image object.
        /// </summary>
        /// This will be public opened later after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size ValueIndicatorSize
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
                    sliderStyle.ValueIndicatorImage.Size = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the resource url of the value indicator image object.
        /// </summary>
        /// This will be public opened later after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ValueIndicatorUrl
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
                    sliderStyle.ValueIndicatorImage.ResourceUrl = value;
                }
            }
        }

        private Extents spaceBetweenTrackAndIndicator
        {
            get
            {
                if (null == _spaceBetweenTrackAndIndicator)
                {
                    _spaceBetweenTrackAndIndicator = new Extents((ushort start, ushort end, ushort top, ushort bottom) =>
                    {
                        Extents extents = new Extents(start, end, top, bottom);
                        _spaceBetweenTrackAndIndicator.CopyFrom(extents);
                    }, 0, 0, 0, 0);
                }

                return _spaceBetweenTrackAndIndicator;
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
                CreateValueIndicator().ApplyStyle(sliderStyle.ValueIndicatorImage);
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
        /// Prevents from showing child widgets in AT-SPI tree.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool AccessibilityShouldReportZeroChildren()
        {
            return true;
        }

        /// <summary>
        /// Minimum value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override double AccessibilityGetMinimum()
        {
            return (double)MinValue;
        }

        /// <summary>
        /// Current value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override double AccessibilityGetCurrent()
        {
            return (double)CurrentValue;
        }

        /// <summary>
        /// Maximum value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override double AccessibilityGetMaximum()
        {
            return (double)MaxValue;
        }

        /// <summary>
        /// Current value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool AccessibilitySetCurrent(double value)
        {
            var f = (float)value;

            if (f >= MinValue && f <= MaxValue)
            {
                CurrentValue = f;
                if (sliderValueChangedHandler != null)
                {
                    sliderValueChangedHandler(this, new SliderValueChangedEventArgs { CurrentValue = f });
                }
                return true;
            }

            return false;
        }

        /// <summary>
        /// Minimum increment.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override double AccessibilityGetMinimumIncrement()
        {
            // FIXME
            return (MaxValue - MinValue) / 20.0;
        }

        /// <summary>
        /// Initliaze AT-SPI object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();
            SetAccessibilityConstructor(Role.Slider, AccessibilityInterface.Value);
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
                if (null != bgTrackImage)
                {
                    bgTrackImage.TouchEvent -= OnTouchEventForBgTrack;
                    Utility.Dispose(bgTrackImage);
                }
                Utility.Dispose(lowIndicatorImage);
                Utility.Dispose(highIndicatorImage);
                Utility.Dispose(lowIndicatorText);
                Utility.Dispose(highIndicatorText);
                Utility.Dispose(valueIndicatorImage);
                Utility.Dispose(valueIndicatorText);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Update Slider by style.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
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
            UpdateValue();
        }

        private void CalculateCurrentValueByGesture(float offset)
        {
            currentSlidedOffset += offset;

            if (currentSlidedOffset <= 0)
            {
                curValue = minValue;
            }
            else if (currentSlidedOffset >= BgTrackLength())
            {
                curValue = maxValue;
            }
            else
            {
                int bgTrackLength = BgTrackLength();
                if (bgTrackLength != 0)
                {
                    curValue = ((currentSlidedOffset / (float)bgTrackLength) * (float)(maxValue - minValue)) + minValue;
                }
            }
            if (valueChangedHandler != null)
            {
                ValueChangedArgs args = new ValueChangedArgs();
                args.CurrentValue = curValue;
                valueChangedHandler(this, args);
            }

            if (sliderValueChangedHandler != null)
            {
                SliderValueChangedEventArgs args = new SliderValueChangedEventArgs();
                args.CurrentValue = curValue;
                sliderValueChangedHandler(this, args);
            }
        }

        private bool OnTouchEventForBgTrack(object source, TouchEventArgs e)
        {
            PointStateType state = e.Touch.GetState(0);
            if (state == PointStateType.Down)
            {
                if (isValueShown)
                {
                    valueIndicatorImage.Show();
                }

                Vector2 pos = e.Touch.GetLocalPosition(0);
                CalculateCurrentValueByTouch(pos);
                UpdateValue();
                if (null != slidingFinishedHandler)
                {
                    SlidingFinishedArgs args = new SlidingFinishedArgs();
                    args.CurrentValue = curValue;
                    slidingFinishedHandler(this, args);
                }

                if (null != sliderSlidingFinishedHandler)
                {
                    SliderSlidingFinishedEventArgs args = new SliderSlidingFinishedEventArgs();
                    args.CurrentValue = curValue;
                    sliderSlidingFinishedHandler(this, args);
                }
            }
            else if (state == PointStateType.Up)
            {
                if (isValueShown)
                {
                    valueIndicatorImage.Hide();
                }
            }
            return false;
        }

        private bool OnTouchEventForThumb(object source, TouchEventArgs e)
        {
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
            int bgTrackLength = BgTrackLength();
            if (direction == DirectionType.Horizontal)
            {
                currentSlidedOffset = pos.X;
            }
            else if (direction == DirectionType.Vertical)
            {
                currentSlidedOffset = bgTrackLength - pos.Y;
            }

            if (bgTrackLength != 0)
            {
                curValue = ((currentSlidedOffset / (float)bgTrackLength) * (maxValue - minValue)) + minValue;
                if (null != valueChangedHandler)
                {
                    ValueChangedArgs args = new ValueChangedArgs();
                    args.CurrentValue = curValue;
                    valueChangedHandler(this, args);
                }

                if (null != sliderValueChangedHandler)
                {
                    SliderValueChangedEventArgs args = new SliderValueChangedEventArgs();
                    args.CurrentValue = curValue;
                    sliderValueChangedHandler(this, args);
                }
            }
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

            if (!isFocused && !isPressed)
            {
                ControlState = ControlState.Normal;
                thumbImage.ResourceUrl = thumbImageUrlSelector?.Normal;

                if (stateChangedHandler != null)
                {
                    StateChangedArgs args = new StateChangedArgs();
                    args.CurrentState = (ControlStates)ControlStates.Normal;
                    stateChangedHandler(this, args);
                }
            }
            else if (isPressed)
            {
                ControlState = ControlState.Pressed;
                thumbImage.ResourceUrl = thumbImageUrlSelector?.Pressed;

                if (stateChangedHandler != null)
                {
                    StateChangedArgs args = new StateChangedArgs();
                    args.CurrentState = (ControlStates)ControlStates.Pressed;
                    stateChangedHandler(this, args);
                }
            }
            else if (!isPressed && isFocused)
            {
                ControlState = ControlState.Focused;
                thumbImage.ResourceUrl = thumbImageUrlSelector?.Focused;

                if (stateChangedHandler != null)
                {
                    StateChangedArgs args = new StateChangedArgs();
                    args.CurrentState = (ControlStates)ControlStates.Focused;
                    stateChangedHandler(this, args);
                }
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

        /// <summary>
        /// Value Changed event data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10. Please use SliderValueChangedEventArgs instead.")]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public class ValueChangedArgs : EventArgs
        {
            /// <summary>
            /// Curren value
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// It will be removed in API10
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:Do not declare visible instance fields")]
            [Obsolete("Deprecated in API8; Will be removed in API10. Please use SliderValueChangedEventArgs.CurrentValue instead.")]
            public float CurrentValue;
        }

        /// <summary>
        /// Value Changed event data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10. Please use SliderSlidingFinishedEventArgs instead.")]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public class SlidingFinishedArgs : EventArgs
        {
            /// <summary>
            /// Curren value
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// It will be removed in API10
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:Do not declare visible instance fields")]
            [Obsolete("Deprecated in API8; Will be removed in API10. Please use SliderSlidingFinishedEventArgs.CurrentValue instead.")]
            public float CurrentValue;
        }

        /// <summary>
        /// State Changed event data.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10. Please use View.ControlStateChangedEventArgs")]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public class StateChangedArgs : EventArgs
        {
            /// <summary>
            /// Curent state
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// It will be removed in API10
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:Do not declare visible instance fields")]
            [Obsolete("Deprecated in API8; Will be removed in API10")]
            public ControlStates CurrentState;
        }
    }
}
