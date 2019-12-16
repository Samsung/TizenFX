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
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SliderStyle : ControlStyle
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorTypeProperty = BindableProperty.Create("IndicatorType", typeof(IndicatorType?), typeof(SliderStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Components.SliderStyle)bindable;
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
        public static readonly BindableProperty SpaceBetweenTrackAndIndicatorProperty = BindableProperty.Create("SpaceBetweenTrackAndIndicator", typeof(uint?), typeof(SliderStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty TrackThicknessProperty = BindableProperty.Create("TrackThickness", typeof(uint?), typeof(SliderStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty TrackPaddingProperty = BindableProperty.Create("TrackPadding", typeof(Extents), typeof(SliderStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (SliderStyle)bindable;
            if (newValue != null)
            {
                instance.trackPadding.CopyFrom((Extents)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (SliderStyle)bindable;
            return instance.trackPadding;
        });
        /// <summary>
        /// Creates a new instance of a SliderStyle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SliderStyle() : base()
        {
            IndicatorType = Slider.IndicatorType.None;
            InitSubStyle();
        }

        /// <summary>
        /// Creates a new instance of a SliderStyle with style.
        /// </summary>
        /// <param name="style">Create SliderStyle by style customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle Track { get; set; }

        /// <summary>
        /// Get or set slided track.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle Progress { get; set; }

        /// <summary>
        /// Get or set thumb.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle Thumb { get; set; }

        /// <summary>
        /// Get or set low indicator image.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle LowIndicatorImage { get; set; }

        /// <summary>
        /// Get or set high indicator image.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle HighIndicatorImage { get; set; }

        /// <summary>
        /// Get or set low indicator text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabelStyle LowIndicator { get; set; }

        /// <summary>
        /// Get or set high indicator text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabelStyle HighIndicator { get; set; }

        /// <summary>
        /// Get or set Indicator type
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IndicatorType? IndicatorType
        {
            get => (IndicatorType?)GetValue(IndicatorTypeProperty);
            set => SetValue(IndicatorTypeProperty, value);
        }

        private IndicatorType? privateIndicatorType { get; set; }

        /// <summary>
        /// Get or set track thickness
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint? TrackThickness
        {
            get => (uint?)GetValue(TrackThicknessProperty);
            set => SetValue(TrackThicknessProperty, value);
        }
        private uint? privateTrackThickness { get; set; }

        /// <summary>
        /// Get or set space between track and indicator
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint? SpaceBetweenTrackAndIndicator
        {
            get => (uint?)GetValue(SpaceBetweenTrackAndIndicatorProperty);
            set => SetValue(SpaceBetweenTrackAndIndicatorProperty, value);
        }
        private uint? privateSpaceBetweenTrackAndIndicator { get; set; }

        /// <summary>
        /// Get or set space between track and indicator
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents TrackPadding
        {
            get => (Extents)GetValue(TrackPaddingProperty);
            set => SetValue(TrackPaddingProperty, value);
        }
        private Extents _trackPadding;
        private Extents trackPadding
        {
            get
            {
                if (null == _trackPadding)
                {
                    _trackPadding = new Extents((ushort start, ushort end, ushort top, ushort bottom)=>
                                        {
                                            Extents extents = new Extents(start, end, top, bottom);
                                            _trackPadding.CopyFrom(extents);
                                        }, 0, 0, 0, 0);
                }
                return _trackPadding;
            }
        }

        /// <summary>
        /// Attributes's clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            SliderStyle sliderAttributes = bindableObject as SliderStyle;

            if (null != sliderAttributes)
            {
                if (sliderAttributes.Track != null)
                {
                    if (null == Track)
                    {
                        Track = new ImageViewStyle();
                    }
                    Track.CopyFrom(sliderAttributes.Track);
                }

                if (sliderAttributes.Progress != null)
                {
                    if (null == Progress)
                    {
                        Progress = new ImageViewStyle();
                    }
                    Progress.CopyFrom(sliderAttributes.Progress);
                }

                if (sliderAttributes.Thumb != null)
                {
                    if (null == Thumb)
                    {
                        Thumb = new ImageViewStyle();
                    }
                    Thumb.CopyFrom(sliderAttributes.Thumb);
                }

                if (sliderAttributes.LowIndicatorImage != null)
                {
                    if (null == LowIndicatorImage)
                    {
                        LowIndicatorImage = new ImageViewStyle();
                    }
                    LowIndicatorImage.CopyFrom(sliderAttributes.LowIndicatorImage);
                }

                if (sliderAttributes.HighIndicatorImage != null)
                {
                    if (null == HighIndicatorImage)
                    {
                        HighIndicatorImage = new ImageViewStyle();
                    }
                    HighIndicatorImage.CopyFrom(sliderAttributes.HighIndicatorImage);
                }

                if (sliderAttributes.LowIndicator != null)
                {
                    if (null == LowIndicator)
                    {
                        LowIndicator = new TextLabelStyle();
                    }
                    LowIndicator.CopyFrom(sliderAttributes.LowIndicator);
                }

                if (sliderAttributes.HighIndicator != null)
                {
                    if (null == HighIndicator)
                    {
                        HighIndicator = new TextLabelStyle();
                    }
                    HighIndicator.CopyFrom(sliderAttributes.HighIndicator);
                }

                if (sliderAttributes.TrackThickness != null)
                {
                    TrackThickness = sliderAttributes.TrackThickness;
                }

                if (sliderAttributes.TrackPadding != null)
                {
                    TrackPadding = sliderAttributes.TrackPadding;
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
    }
}
