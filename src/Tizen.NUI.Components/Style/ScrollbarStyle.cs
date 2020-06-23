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
            ((ScrollbarStyle)bindable).trackColor = (Color)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ScrollbarStyle)bindable).trackColor;
        });

        /// <summary>Bindable property of ThumbColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbColorProperty = BindableProperty.Create(nameof(ThumbColor), typeof(Color), typeof(ScrollbarStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((ScrollbarStyle)bindable).thumbColor = (Color)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ScrollbarStyle)bindable).thumbColor;
        });

        /// <summary>Bindable property of TrackPadding</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackPaddingProperty = BindableProperty.Create(nameof(TrackPadding), typeof(Extents), typeof(ScrollbarStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((ScrollbarStyle)bindable).trackPadding = (Extents)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ScrollbarStyle)bindable).trackPadding;
        });

        private float? trackThickness;
        private float? thumbThickness;
        private Color trackColor;
        private Color thumbColor;
        private Extents trackPadding;

        #endregion Fields


        #region Constructors

        /// <summary>
        /// Creates a new instance of a ScrollbarStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollbarStyle() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="style">Create ScrollbarStyle by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollbarStyle(ScrollbarStyle style) : base(style)
        {
            this.CopyFrom(style);
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

        #endregion Properties


        #region Methods

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            var style = bindableObject as ScrollbarStyle;

            if (null != style)
            {
                TrackThickness = style.TrackThickness;
                ThumbThickness = style.ThumbThickness;
                TrackColor = style.TrackColor;
                ThumbColor = style.ThumbColor;
                TrackPadding = style.TrackPadding;
            }
        }

        private void Initialize()
        {
            TrackThickness = 6.0f;
            ThumbThickness = 6.0f;
            TrackColor = new Color(1.0f, 1.0f, 1.0f, 0.15f);
            ThumbColor = new Color(0.6f, 0.6f, 0.6f, 1.0f);
            TrackPadding = 4;
            WidthResizePolicy = ResizePolicyType.FillToParent;
            HeightResizePolicy = ResizePolicyType.FillToParent;
        }

        #endregion Methods
    }
}
