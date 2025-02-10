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
        /// <summary>
        /// IndicatorTypeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IndicatorTypeProperty = null;
        internal static void SetInternalIndicatorTypeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (SliderStyle)bindable;
            if (newValue != null)
            {
                instance.privateIndicatorType = (IndicatorType)newValue;
            }
        }
        internal static object GetInternalIndicatorTypeProperty(BindableObject bindable)
        {
            var instance = (SliderStyle)bindable;
            return instance.privateIndicatorType;
        }

        /// <summary>
        /// SpaceBetweenTrackAndIndicatorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SpaceBetweenTrackAndIndicatorProperty = null;
        internal static void SetInternalSpaceBetweenTrackAndIndicatorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (SliderStyle)bindable;
            if (newValue != null)
            {
                instance.privateSpaceBetweenTrackAndIndicator = (uint?)newValue;
            }
        }
        internal static object GetInternalSpaceBetweenTrackAndIndicatorProperty(BindableObject bindable)
        {
            var instance = (SliderStyle)bindable;
            return instance.privateSpaceBetweenTrackAndIndicator;
        }

        /// <summary>
        /// TrackThicknessProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackThicknessProperty = null;
        internal static void SetInternalTrackThicknessProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (SliderStyle)bindable;
            if (newValue != null)
            {
                instance.privateTrackThickness = (uint?)newValue;
            }
        }
        internal static object GetInternalTrackThicknessProperty(BindableObject bindable)
        {
            var instance = (SliderStyle)bindable;
            return instance.privateTrackThickness;
        }

        /// <summary>
        /// TrackPaddingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackPaddingProperty = null;
        internal static void SetInternalTrackPaddingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((SliderStyle)bindable).trackPadding = newValue == null ? null : new Extents((Extents)newValue);
        }
        internal static object GetInternalTrackPaddingProperty(BindableObject bindable)
        {
            var instance = (SliderStyle)bindable;
            return instance.trackPadding;
        }

        private IndicatorType? privateIndicatorType = Slider.IndicatorType.None;
        private uint? privateTrackThickness;
        private uint? privateSpaceBetweenTrackAndIndicator;
        private Extents trackPadding;

        static SliderStyle()
        {
            if (NUIApplication.IsUsingXaml)
            {
                IndicatorTypeProperty = BindableProperty.Create(nameof(IndicatorType), typeof(IndicatorType?), typeof(SliderStyle), null,
                    propertyChanged: SetInternalIndicatorTypeProperty, defaultValueCreator: GetInternalIndicatorTypeProperty);
                SpaceBetweenTrackAndIndicatorProperty = BindableProperty.Create(nameof(SpaceBetweenTrackAndIndicator), typeof(uint?), typeof(SliderStyle), null,
                    propertyChanged: SetInternalSpaceBetweenTrackAndIndicatorProperty, defaultValueCreator: GetInternalSpaceBetweenTrackAndIndicatorProperty);
                TrackThicknessProperty = BindableProperty.Create(nameof(TrackThickness), typeof(uint?), typeof(SliderStyle), null,
                    propertyChanged: SetInternalTrackThicknessProperty, defaultValueCreator: GetInternalTrackThicknessProperty);
                TrackPaddingProperty = BindableProperty.Create(nameof(TrackPadding), typeof(Extents), typeof(SliderStyle), null,
                    propertyChanged: SetInternalTrackPaddingProperty, defaultValueCreator: GetInternalTrackPaddingProperty);
            }
        }

        /// <summary>
        /// Creates a new instance of a SliderStyle.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public SliderStyle() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of a SliderStyle with style.
        /// </summary>
        /// <param name="style">Create SliderStyle by style customized by user.</param>
        /// <since_tizen> 8 </since_tizen>
        public SliderStyle(SliderStyle style) : base(style)
        {
        }

        /// <summary>
        /// Get or set background track.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle Track { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Get or set slided track.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle Progress { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Get or set thumb.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle Thumb { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Get or set background warning track.
        /// </summary>
        /// This will be public opened later after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle WarningTrack { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Get or set slided warning track.
        /// </summary>
        /// This will be public opened later after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageViewStyle WarningProgress { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Get or set low indicator image.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle LowIndicatorImage { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Get or set high indicator image.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle HighIndicatorImage { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Get or set low indicator text.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public TextLabelStyle LowIndicator { get; set; } = new TextLabelStyle();

        /// <summary>
        /// Get or set high indicator text.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public TextLabelStyle HighIndicator { get; set; } = new TextLabelStyle();

        /// <summary>
        /// Get or set the value indicator text.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public TextLabelStyle ValueIndicatorText { get; set; } = new TextLabelStyle();

        /// <summary>
        /// Get or set the value indicator image.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public ImageViewStyle ValueIndicatorImage { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Get or set Indicator type
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public IndicatorType? IndicatorType
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (IndicatorType?)GetValue(IndicatorTypeProperty);
                }
                else
                {
                    return (IndicatorType)GetInternalIndicatorTypeProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IndicatorTypeProperty, value);
                }
                else
                {
                    SetInternalIndicatorTypeProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Get or set track thickness
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public uint? TrackThickness
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (uint?)GetValue(TrackThicknessProperty);
                }
                else
                {
                    return (uint?)GetInternalTrackThicknessProperty(this);
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
                    SetInternalTrackThicknessProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Get or set space between track and indicator
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public uint? SpaceBetweenTrackAndIndicator
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (uint?)GetValue(SpaceBetweenTrackAndIndicatorProperty);
                }
                else
                {
                    return (uint?)GetInternalSpaceBetweenTrackAndIndicatorProperty(this);
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
                    SetInternalSpaceBetweenTrackAndIndicatorProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Get or set space between track and indicator
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Extents TrackPadding
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return ((Extents)GetValue(TrackPaddingProperty)) ?? (trackPadding = new Extents(0, 0, 0, 0));
                }
                else
                {
                    return (Extents)GetInternalTrackPaddingProperty(this) ?? (trackPadding = new Extents(0, 0, 0, 0));
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TrackPaddingProperty, value);
                }
                else
                {
                    SetInternalTrackPaddingProperty(this, null, value);
                }
            }
        }

        /// <inheritdoc/>
        /// <since_tizen> 8 </since_tizen>
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            if (bindableObject is SliderStyle sliderStyle)
            {
                Track.CopyFrom(sliderStyle.Track);
                Progress.CopyFrom(sliderStyle.Progress);
                Thumb.CopyFrom(sliderStyle.Thumb);
                WarningTrack.CopyFrom(sliderStyle.WarningTrack);
                WarningProgress.CopyFrom(sliderStyle.WarningProgress);
                LowIndicatorImage.CopyFrom(sliderStyle.LowIndicatorImage);
                HighIndicatorImage.CopyFrom(sliderStyle.HighIndicatorImage);
                LowIndicator.CopyFrom(sliderStyle.LowIndicator);
                HighIndicator.CopyFrom(sliderStyle.HighIndicator);
                ValueIndicatorText.CopyFrom(sliderStyle.ValueIndicatorText);
                ValueIndicatorImage.CopyFrom(sliderStyle.ValueIndicatorImage);
            }
        }

        /// <summary>
        /// Dispose SliderStyle and all children on it.
        /// </summary>
        /// <param name="disposing">true in order to free managed objects</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                trackPadding?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
