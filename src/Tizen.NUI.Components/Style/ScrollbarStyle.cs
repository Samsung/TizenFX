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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// ScrollbarStyle is a class which saves Scrollbar's style data.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ScrollbarStyle : ControlStyle
    {
        #region Fields

        /// <summary>Bindable property of TrackThickness</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackThicknessProperty = null;
        internal static void SetInternalTrackThicknessProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ScrollbarStyle)bindable).trackThickness = (float?)newValue;
        }
        internal static object GetInternalTrackThicknessProperty(BindableObject bindable)
        {
            return ((ScrollbarStyle)bindable).trackThickness;
        }

        /// <summary>Bindable property of ThumbThickness</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbThicknessProperty = null;
        internal static void SetInternalThumbThicknessProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ScrollbarStyle)bindable).thumbThickness = (float?)newValue;
        }
        internal static object GetInternalThumbThicknessProperty(BindableObject bindable)
        {
            return ((ScrollbarStyle)bindable).thumbThickness;
        }

        /// <summary>Bindable property of TrackColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackColorProperty = null;
        internal static void SetInternalTrackColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ScrollbarStyle)bindable).trackColor = new Color((Color)newValue);
        }
        internal static object GetInternalTrackColorProperty(BindableObject bindable)
        {
            return ((ScrollbarStyle)bindable).trackColor;
        }

        /// <summary>Bindable property of ThumbColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbColorProperty = null;
        internal static void SetInternalThumbColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ScrollbarStyle)bindable).thumbColor = new Color((Color)newValue);
        }
        internal static object GetInternalThumbColorProperty(BindableObject bindable)
        {
            return ((ScrollbarStyle)bindable).thumbColor;
        }

        /// <summary>Bindable property of TrackPadding</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackPaddingProperty = null;
        internal static void SetInternalTrackPaddingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ScrollbarStyle)bindable).trackPadding = new Extents((Extents)newValue);
        }
        internal static object GetInternalTrackPaddingProperty(BindableObject bindable)
        {
            return ((ScrollbarStyle)bindable).trackPadding;
        }

        /// <summary>Bindable property of ThumbBackgroundImageVertical</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbVerticalImageUrlProperty = null;
        internal static void SetInternalThumbVerticalImageUrlProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ScrollbarStyle)bindable).thumbVerticalImageUrl = ((string)newValue);
        }
        internal static object GetInternalThumbVerticalImageUrlProperty(BindableObject bindable)
        {
            return ((ScrollbarStyle)bindable).thumbVerticalImageUrl;
        }

        /// <summary>Bindable property of ThumbBackgroundImageUrl</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbHorizontalImageUrlProperty = null;
        internal static void SetInternalThumbHorizontalImageUrlProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ScrollbarStyle)bindable).thumbHorizontalImageUrl = ((string)newValue);
        }
        internal static object GetInternalThumbHorizontalImageUrlProperty(BindableObject bindable)
        {
            return ((ScrollbarStyle)bindable).thumbHorizontalImageUrl;
        }

        private float? trackThickness;
        private float? thumbThickness;
        private Color trackColor;
        private Color thumbColor;
        private Extents trackPadding;
        private string thumbVerticalImageUrl;
        private string thumbHorizontalImageUrl;

        #endregion Fields


        #region Constructors
        /// <summary>
        /// Creates a new instance of a ScrollbarStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollbarStyle() : base()
        {
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="style">Create ScrollbarStyle by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollbarStyle(ScrollbarStyle style) : base(style)
        {
        }

        /// <summary>
        /// Static constructor to initialize bindable properties when loading.
        /// </summary>
        static ScrollbarStyle()
        {
            if (NUIApplication.IsUsingXaml)
            {
                TrackThicknessProperty = BindableProperty.Create(nameof(TrackThickness), typeof(float?), typeof(ScrollbarStyle), null,
                    propertyChanged: SetInternalTrackThicknessProperty, defaultValueCreator: GetInternalTrackThicknessProperty);
                ThumbThicknessProperty = BindableProperty.Create(nameof(ThumbThickness), typeof(float?), typeof(ScrollbarStyle), null,
                    propertyChanged: SetInternalThumbThicknessProperty, defaultValueCreator: GetInternalThumbThicknessProperty);
                TrackColorProperty = BindableProperty.Create(nameof(TrackColor), typeof(Color), typeof(ScrollbarStyle), null,
                    propertyChanged: SetInternalTrackColorProperty, defaultValueCreator: GetInternalTrackColorProperty);
                ThumbColorProperty = BindableProperty.Create(nameof(ThumbColor), typeof(Color), typeof(ScrollbarStyle), null,
                    propertyChanged: SetInternalThumbColorProperty, defaultValueCreator: GetInternalThumbColorProperty);
                TrackPaddingProperty = BindableProperty.Create(nameof(TrackPadding), typeof(Extents), typeof(ScrollbarStyle), null,
                    propertyChanged: SetInternalTrackPaddingProperty, defaultValueCreator: GetInternalTrackPaddingProperty);
                ThumbVerticalImageUrlProperty = BindableProperty.Create(nameof(ThumbVerticalImageUrl), typeof(string), typeof(ScrollbarStyle), null,
                    propertyChanged: SetInternalThumbVerticalImageUrlProperty, defaultValueCreator: GetInternalThumbVerticalImageUrlProperty);
                ThumbHorizontalImageUrlProperty = BindableProperty.Create(nameof(ThumbHorizontalImageUrl), typeof(string), typeof(ScrollbarStyle), null,
                    propertyChanged: SetInternalThumbHorizontalImageUrlProperty, defaultValueCreator: GetInternalThumbHorizontalImageUrlProperty);
            }
        }

        #endregion Constructors


        #region Properties

        /// <summary>
        /// The thickness of the track.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? TrackThickness
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(TrackThicknessProperty);
                }
                else
                {
                    return (float?)GetInternalTrackThicknessProperty(this);
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
        /// The thickness of the thumb.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ThumbThickness
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(ThumbThicknessProperty);
                }
                else
                {
                    return (float?)GetInternalThumbThicknessProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ThumbThicknessProperty, value);
                }
                else
                {
                    SetInternalThumbThicknessProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The color of the track part.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color TrackColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Color)GetValue(TrackColorProperty);
                }
                else
                {
                    return (Color)GetInternalTrackColorProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TrackColorProperty, value);
                }
                else
                {
                    SetInternalTrackColorProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The color of the thumb part.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color ThumbColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Color)GetValue(ThumbColorProperty);
                }
                else
                {
                    return (Color)GetInternalThumbColorProperty(this);
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
                    SetInternalThumbColorProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The padding value of the track.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents TrackPadding
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Extents)GetValue(TrackPaddingProperty);
                }
                else
                {
                    return (Extents)GetInternalTrackPaddingProperty(this);
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

        /// <summary>
        /// The image url of the vertical thumb.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ThumbVerticalImageUrl
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(ThumbVerticalImageUrlProperty);
                }
                else
                {
                    return (string)GetInternalThumbVerticalImageUrlProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ThumbVerticalImageUrlProperty, value);
                }
                else
                {
                    SetInternalThumbVerticalImageUrlProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The image url of the horizontal thumb.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ThumbHorizontalImageUrl
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(ThumbHorizontalImageUrlProperty);
                }
                else
                {
                    return (string)GetInternalThumbHorizontalImageUrlProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ThumbHorizontalImageUrlProperty, value);
                }
                else
                {
                    SetInternalThumbHorizontalImageUrlProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The ImageViewStyle of Thumb. internal usage only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal ImageViewStyle Thumb
        {
            get; set;
        }

        #endregion Properties
    }
}
