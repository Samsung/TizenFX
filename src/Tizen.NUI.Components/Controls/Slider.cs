/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
    /// A slider lets users select a value from a continuous or discrete range of values by moving the slider thumb.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public partial class Slider : Control
    {
        // the background track image object
        private ImageView bgTrackImage = null;
        // the slided track image object
        private ImageView slidedTrackImage = null;
        // the thumb image object
        private ImageView thumbImage = null;
        // the low indicator image object
        private ImageView lowIndicatorImage = null;
        // the high indicator image object
        private ImageView highIndicatorImage = null;
        // the low indicator text object
        private TextLabel lowIndicatorText = null;
        // the high indicator text object
        private TextLabel highIndicatorText = null;
        // the direction type
        private DirectionType direction = DirectionType.Horizontal;
        // the indicator type
        private IndicatorType indicatorType = IndicatorType.None;
        private const float round = 0.5f;
        // the minimum value
        private float minValue = 0;
        // the maximum value
        private float maxValue = 100;
        // the current value
        private float curValue = 0;
        // the size of the low indicator
        private Size lowIndicatorSize = null;
        // the size of the high indicator
        private Size highIndicatorSize = null;
        // the track thickness value
        private uint? trackThickness = null;
        // the value of the space between track and indicator object
        private Extents _spaceBetweenTrackAndIndicator = null;
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


        private PanGestureDetector panGestureDetector = null;
        private float currentSlidedOffset;
        private EventHandler<ValueChangedArgs> valueChangedHandler;
        private EventHandler<SlidingFinishedArgs> slidingFinishedHandler;
        private EventHandler<StateChangedArgs> stateChangedHandler;

        bool isFocused = false;
        bool isPressed = false;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackPaddingProperty = BindableProperty.Create(nameof(TrackPadding), typeof(Extents), typeof(Slider), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Slider)bindable;
            if (newValue != null)
            {
                instance.privateTrackPadding.CopyFrom((Extents)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Slider)bindable;
            return instance.privateTrackPadding;
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
        /// The state changed event handler.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
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
        /// Get style of slider.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public new SliderStyle Style => ViewStyle as SliderStyle;

        /// <summary>
        /// Get or set low indicator text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel LowIndicatorText
        {
            get
            {
                return CreateLowIndicatorText();
            }
            internal set
            {
                lowIndicatorText = value;
            }
        }

        /// <summary>
        /// Get or set high indicator text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel HighIndicatorText
        {
            get
            {
                return CreateHighIndicatorText();
            }
            internal set
            {
                highIndicatorText = value;
            }
        }

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
                return Style.Thumb?.Size;
            }
            set
            {
                Style.Thumb.Size = value;
            }
        }

        /// <summary>
        /// Gets or sets the resource url of the thumb image object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string ThumbImageURL
        {
            get
            {
                return Style?.Thumb?.ResourceUrl?.All;
            }
            set
            {
                if (null != Style?.Thumb)
                {
                    Style.Thumb.ResourceUrl = value; 
                }
            }
        }

        private StringSelector thumbImageURLSelector = new StringSelector();
        /// <summary>
        /// Gets or sets the resource url selector of the thumb image object.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public StringSelector ThumbImageURLSelector
        {
            get
            {
                return thumbImageURLSelector;
            }
            set
            {
                if (value == null || thumbImageURLSelector == null)
                {
                    Tizen.Log.Fatal("NUI", "[Exception] Slider.ThumbImageURLSelector is null");
                    throw new NullReferenceException("Slider.ThumbImageURLSelector is null");
                }
                else
                {
                    thumbImageURLSelector.Clone(value);
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
                return Style?.Track?.BackgroundColor?.All;
            }
            set
            {
                if (null != Style?.Track)
                {
                    Style.Track.BackgroundColor = value;
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
                return Style?.Progress?.BackgroundColor?.All;
            }
            set
            {
                if (null != Style?.Progress)
                {
                    Style.Progress.BackgroundColor = value;
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
                return Style?.LowIndicatorImage?.ResourceUrl?.All;
            }
            set
            {
                if (null != Style?.LowIndicatorImage)
                {
                    Style.LowIndicatorImage.ResourceUrl = value;
                }
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
                return Style?.HighIndicatorImage?.ResourceUrl?.All;
            }
            set
            {
                if (null != Style?.HighIndicatorImage)
                {
                    Style.HighIndicatorImage.ResourceUrl = value;
                }
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
                return Style?.LowIndicator?.Text?.All;
            }
            set
            {
                if (null != Style?.LowIndicator)
                {
                    Style.LowIndicator.Text= value;
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
                return Style?.HighIndicator?.Text?.All;
            }
            set
            {
                if (null != Style?.HighIndicator)
                {
                    Style.HighIndicator.Text = value;
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
                return Style.HighIndicator.Size;
            }
            set
            {
                Style.HighIndicator.Size = value;
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
        private uint privateSpaceBetweenTrackAndIndicator
        {
            get
            {
                return TrackPadding.Start;
            }
            set
            {
                ushort val = (ushort)value;
                TrackPadding = new Extents(val, val, val, val);
            }
        }

        /// <summary>
        /// Gets or sets the value of the space between track and indicator.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents TrackPadding
        {
            get
            {
                return (Extents)GetValue(TrackPaddingProperty);
            }
            set
            {
                SetValue(TrackPaddingProperty, value);
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
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnFocusGained()
        {
            //State = ControlStates.Focused;
            UpdateState(true, isPressed);
            base.OnFocusGained();
        }

        /// <summary>
        /// Focus Lost callback.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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

            EnableControlStatePropagation = true;
        }
    }
}
