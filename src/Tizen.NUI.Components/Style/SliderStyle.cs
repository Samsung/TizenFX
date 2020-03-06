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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using static Tizen.NUI.Components.Slider;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// SliderStyle is a class which saves Slider's ux data.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class SliderStyle : ControlStyle
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorTypeProperty = BindableProperty.Create(nameof(IndicatorType), typeof(IndicatorType?), typeof(SliderStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (SliderStyle)bindable;
            if (newValue != null)
            {
                instance.privateIndicatorType = (IndicatorType)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (SliderStyle)bindable;
            return instance.privateIndicatorType;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SpaceBetweenTrackAndIndicatorProperty = BindableProperty.Create(nameof(SpaceBetweenTrackAndIndicator), typeof(uint?), typeof(SliderStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (SliderStyle)bindable;
            if (newValue != null)
            {
                instance.privateSpaceBetweenTrackAndIndicator = (uint?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (SliderStyle)bindable;
            return instance.privateSpaceBetweenTrackAndIndicator;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackThicknessProperty = BindableProperty.Create(nameof(TrackThickness), typeof(uint?), typeof(SliderStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (SliderStyle)bindable;
            if (newValue != null)
            {
                instance.privateTrackThickness = (uint?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (SliderStyle)bindable;
            return instance.privateTrackThickness;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackPaddingProperty = BindableProperty.Create(nameof(TrackPadding), typeof(Extents), typeof(SliderStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (SliderStyle)bindable;
            if (newValue != null)
            {
                if (null == instance.trackPadding) instance.trackPadding = new Extents(instance.OnTrackPaddingChanged, 0, 0, 0, 0);
                instance.trackPadding.CopyFrom(null == newValue ? new Extents() : (Extents)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (SliderStyle)bindable;
            return instance.trackPadding;
        });

        private IndicatorType? privateIndicatorType;
        private uint? privateTrackThickness;
        private uint? privateSpaceBetweenTrackAndIndicator;
        private Extents trackPadding;

        static SliderStyle() { }

        /// <summary>
        /// Creates a new instance of a SliderStyle.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public SliderStyle() : base()
        {
            IndicatorType = Slider.IndicatorType.None;
            InitSubStyle();
        }

        /// <summary>
        /// Creates a new instance of a SliderStyle with style.
        /// </summary>
        /// <param name="style">Create SliderStyle by style customized by user.</param>
        /// <since_tizen> 8 </since_tizen>
        public SliderStyle(SliderStyle style) : base(style)
        {
            if(style == null)
            {
                return;
            }

            InitSubStyle();

            this.CopyFrom(style);

            IndicatorType = style.IndicatorType;
        }

        /// <summary>
        /// Get or set background track.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle Track { get; set; }

        /// <summary>
        /// Get or set slided track.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle Progress { get; set; }

        /// <summary>
        /// Get or set thumb.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle Thumb { get; set; }

        /// <summary>
        /// Get or set low indicator image.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle LowIndicatorImage { get; set; }

        /// <summary>
        /// Get or set high indicator image.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle HighIndicatorImage { get; set; }

        /// <summary>
        /// Get or set low indicator text.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public TextLabelStyle LowIndicator { get; set; }

        /// <summary>
        /// Get or set high indicator text.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public TextLabelStyle HighIndicator { get; set; }

        /// <summary>
        /// Get or set Indicator type
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public IndicatorType? IndicatorType
        {
            get => (IndicatorType?)GetValue(IndicatorTypeProperty);
            set => SetValue(IndicatorTypeProperty, value);
        }

        /// <summary>
        /// Get or set track thickness
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public uint? TrackThickness
        {
            get => (uint?)GetValue(TrackThicknessProperty);
            set => SetValue(TrackThicknessProperty, value);
        }

        /// <summary>
        /// Get or set space between track and indicator
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public uint? SpaceBetweenTrackAndIndicator
        {
            get => (uint?)GetValue(SpaceBetweenTrackAndIndicatorProperty);
            set => SetValue(SpaceBetweenTrackAndIndicatorProperty, value);
        }

        /// <summary>
        /// Get or set space between track and indicator
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Extents TrackPadding
        {
            get
            {
                Extents tmp = (Extents)GetValue(TrackPaddingProperty);
                return (null != tmp) ? tmp : trackPadding = new Extents(OnTrackPaddingChanged, 0, 0, 0, 0);
            }
            set => SetValue(TrackPaddingProperty, value);
        }

        /// <summary>
        /// Style's clone function.
        /// </summary>
        /// <param name="bindableObject">The style that need to copy.</param>
        /// <since_tizen> 8 </since_tizen>
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            SliderStyle sliderStyle = bindableObject as SliderStyle;

            if (null != sliderStyle)
            {
                if (sliderStyle.Track != null)
                {
                    if (null == Track)
                    {
                        Track = new ImageViewStyle();
                    }
                    Track.CopyFrom(sliderStyle.Track);
                }

                if (sliderStyle.Progress != null)
                {
                    if (null == Progress)
                    {
                        Progress = new ImageViewStyle();
                    }
                    Progress.CopyFrom(sliderStyle.Progress);
                }

                if (sliderStyle.Thumb != null)
                {
                    if (null == Thumb)
                    {
                        Thumb = new ImageViewStyle();
                    }
                    Thumb.CopyFrom(sliderStyle.Thumb);
                }

                if (sliderStyle.LowIndicatorImage != null)
                {
                    if (null == LowIndicatorImage)
                    {
                        LowIndicatorImage = new ImageViewStyle();
                    }
                    LowIndicatorImage.CopyFrom(sliderStyle.LowIndicatorImage);
                }

                if (sliderStyle.HighIndicatorImage != null)
                {
                    if (null == HighIndicatorImage)
                    {
                        HighIndicatorImage = new ImageViewStyle();
                    }
                    HighIndicatorImage.CopyFrom(sliderStyle.HighIndicatorImage);
                }

                if (sliderStyle.LowIndicator != null)
                {
                    if (null == LowIndicator)
                    {
                        LowIndicator = new TextLabelStyle();
                    }
                    LowIndicator.CopyFrom(sliderStyle.LowIndicator);
                }

                if (sliderStyle.HighIndicator != null)
                {
                    if (null == HighIndicator)
                    {
                        HighIndicator = new TextLabelStyle();
                    }
                    HighIndicator.CopyFrom(sliderStyle.HighIndicator);
                }

                if (sliderStyle.TrackThickness != null)
                {
                    TrackThickness = sliderStyle.TrackThickness;
                }

                if (sliderStyle.TrackPadding != null)
                {
                    TrackPadding = sliderStyle.TrackPadding;
                }
            }
        }

        private void InitSubStyle()
        {
            Track = new ImageViewStyle();
            Progress = new ImageViewStyle();
            Thumb = new ImageViewStyle();
            LowIndicatorImage = new ImageViewStyle();
            HighIndicatorImage = new ImageViewStyle();
            LowIndicator = new TextLabelStyle();
            HighIndicator = new TextLabelStyle();
        }

        private void OnTrackPaddingChanged(ushort start, ushort end, ushort top, ushort bottom)
        {
            TrackPadding = new Extents(start, end, top, bottom);
        }
    }
}
