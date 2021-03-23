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
        public static readonly BindableProperty TrackThicknessProperty = BindableProperty.Create(nameof(TrackThickness), typeof(float?), typeof(ScrollbarStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((ScrollbarStyle)bindable).trackThickness = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ScrollbarStyle)bindable).trackThickness;
        });

        /// <summary>Bindable property of ThumbThickness</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbThicknessProperty = BindableProperty.Create(nameof(ThumbThickness), typeof(float?), typeof(ScrollbarStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((ScrollbarStyle)bindable).thumbThickness = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ScrollbarStyle)bindable).thumbThickness;
        });

        /// <summary>Bindable property of TrackColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackColorProperty = BindableProperty.Create(nameof(TrackColor), typeof(Color), typeof(ScrollbarStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((ScrollbarStyle)bindable).trackColor = new Color((Color)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ScrollbarStyle)bindable).trackColor;
        });

        /// <summary>Bindable property of ThumbColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbColorProperty = BindableProperty.Create(nameof(ThumbColor), typeof(Color), typeof(ScrollbarStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((ScrollbarStyle)bindable).thumbColor = new Color((Color)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ScrollbarStyle)bindable).thumbColor;
        });

        /// <summary>Bindable property of TrackPadding</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackPaddingProperty = BindableProperty.Create(nameof(TrackPadding), typeof(Extents), typeof(ScrollbarStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((ScrollbarStyle)bindable).trackPadding = new Extents((Extents)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ScrollbarStyle)bindable).trackPadding;
        });

        /// <summary>Bindable property of ThumbBackgroundImageVertical</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbVerticalImageUrlProperty = BindableProperty.Create(nameof(ThumbVerticalImageUrl), typeof(string), typeof(ScrollbarStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((ScrollbarStyle)bindable).thumbVerticalImageUrl = ((string)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ScrollbarStyle)bindable).thumbVerticalImageUrl;
        });

        /// <summary>Bindable property of ThumbBackgroundImageUrl</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbHorizontalImageUrlProperty = BindableProperty.Create(nameof(ThumbHorizontalImageUrl), typeof(string), typeof(ScrollbarStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((ScrollbarStyle)bindable).thumbHorizontalImageUrl = ((string)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ScrollbarStyle)bindable).thumbHorizontalImageUrl;
        });

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
        }

        #endregion Constructors


        #region Properties

        /// <summary>
        /// The thickness of the track.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? TrackThickness
        {
            get => (float?)GetValue(TrackThicknessProperty);
            set => SetValue(TrackThicknessProperty, value);
        }

        /// <summary>
        /// The thickness of the thumb.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ThumbThickness
        {
            get => (float?)GetValue(ThumbThicknessProperty);
            set => SetValue(ThumbThicknessProperty, value);
        }

        /// <summary>
        /// The color of the track part.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color TrackColor
        {
            get => (Color)GetValue(TrackColorProperty);
            set => SetValue(TrackColorProperty, value);
        }

        /// <summary>
        /// The color of the thumb part.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color ThumbColor
        {
            get => (Color)GetValue(ThumbColorProperty);
            set => SetValue(ThumbColorProperty, value);
        }

        /// <summary>
        /// The padding value of the track.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents TrackPadding
        {
            get => (Extents)GetValue(TrackPaddingProperty);
            set => SetValue(TrackPaddingProperty, value);
        }

        /// <summary>
        /// The image url of the vertical thumb.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ThumbVerticalImageUrl
        {
            get => (string)GetValue(ThumbVerticalImageUrlProperty);
            set => SetValue(ThumbVerticalImageUrlProperty, value);
        }

        /// <summary>
        /// The image url of the horizontal thumb.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ThumbHorizontalImageUrl
        {
            get => (string)GetValue(ThumbHorizontalImageUrlProperty);
            set => SetValue(ThumbHorizontalImageUrlProperty, value);
        }


        #endregion Properties
    }
}
