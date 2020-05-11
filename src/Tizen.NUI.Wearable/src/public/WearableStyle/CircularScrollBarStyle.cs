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
using Tizen.NUI.Components;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Wearable
{
    /// <summary>
    /// CircularScrollBarStyle is a class which saves CircularScrollBar's ux data.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CircularScrollBarStyle : ControlStyle
    {
        #region Fields

        /// <summary>Bindable property of Thickness</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThicknessProperty = BindableProperty.Create(nameof(Thickness), typeof(float?), typeof(CircularScrollBarStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((CircularScrollBarStyle)bindable).thickness = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularScrollBarStyle)bindable).thickness;
        });

        /// <summary>Bindable property of TrackSweepAngle</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackSweepAngleProperty = BindableProperty.Create(nameof(TrackSweepAngle), typeof(float?), typeof(CircularScrollBarStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((CircularScrollBarStyle)bindable).trackSweepAngle = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularScrollBarStyle)bindable).trackSweepAngle;
        });

        /// <summary>Bindable property of TrackColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackColorProperty = BindableProperty.Create(nameof(TrackColor), typeof(Color), typeof(CircularScrollBarStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((CircularScrollBarStyle)bindable).trackColor = (Color)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularScrollBarStyle)bindable).trackColor;
        });

        /// <summary>Bindable property of ThumbColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbColorProperty = BindableProperty.Create(nameof(ThumbColor), typeof(Color), typeof(CircularScrollBarStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((CircularScrollBarStyle)bindable).thumbColor = (Color)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularScrollBarStyle)bindable).thumbColor;
        });

        private float? thickness;
        private float? trackSweepAngle;
        private Color trackColor;
        private Color thumbColor;

        #endregion Fields


        #region Constructors

        /// <summary>
        /// Creates a new instance of a CircularScrollBarStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircularScrollBarStyle() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="style">Create ScrollBarStyle by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircularScrollBarStyle(CircularScrollBarStyle style) : base(style)
        {
            this.CopyFrom(style);
        }

        /// <summary>
        /// Static constructor to initialize bindable properties when loading.
        /// </summary>
        static CircularScrollBarStyle()
        {
        }

        #endregion Constructors


        #region Properties

        /// <summary>
        /// The thickness of the scrollbar and track.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? Thickness
        {
            get => (float?)GetValue(ThicknessProperty);
            set => SetValue(ThicknessProperty, value);
        }

        /// <summary>
        /// The sweep angle of track area in degrees.
        /// </summary>
        /// <remarks>
        /// Values below 6 degrees are treated as 6 degrees.
        /// Values exceeding 180 degrees are treated as 180 degrees.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? TrackSweepAngle
        {
            get => (float?)GetValue(TrackSweepAngleProperty);
            set => SetValue(TrackSweepAngleProperty, value);
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

        #endregion Properties


        #region Methods

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            var style = bindableObject as CircularScrollBarStyle;

            if (null != style)
            {
                Thickness = style.Thickness;
                TrackSweepAngle = style.TrackSweepAngle;
                TrackColor = style.TrackColor;
                ThumbColor = style.ThumbColor;
            }
        }

        private void Initialize()
        {
            Thickness = 10.0f;
            TrackSweepAngle = 60.0f;
            TrackColor = new Color(1.0f, 1.0f, 1.0f, 0.15f);
            ThumbColor = new Color(0.6f, 0.6f, 0.6f, 1.0f);
        }

        #endregion Methods
    }
}
