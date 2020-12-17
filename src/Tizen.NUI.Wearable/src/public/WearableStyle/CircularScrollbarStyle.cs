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
    /// CircularScrollbarStyle is a class which saves CircularScrollbar's ux data.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CircularScrollbarStyle : ControlStyle
    {
        #region Fields

        /// <summary>Bindable property of Thickness</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThicknessProperty = BindableProperty.Create(nameof(Thickness), typeof(float?), typeof(CircularScrollbarStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((CircularScrollbarStyle)bindable).thickness = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularScrollbarStyle)bindable).thickness;
        });

        /// <summary>Bindable property of TrackSweepAngle</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackSweepAngleProperty = BindableProperty.Create(nameof(TrackSweepAngle), typeof(float?), typeof(CircularScrollbarStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((CircularScrollbarStyle)bindable).trackSweepAngle = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularScrollbarStyle)bindable).trackSweepAngle;
        });

        /// <summary>Bindable property of TrackColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackColorProperty = BindableProperty.Create(nameof(TrackColor), typeof(Color), typeof(CircularScrollbarStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((CircularScrollbarStyle)bindable).trackColor = newValue == null ? null : new Color((Color)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularScrollbarStyle)bindable).trackColor;
        });

        /// <summary>Bindable property of ThumbColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbColorProperty = BindableProperty.Create(nameof(ThumbColor), typeof(Color), typeof(CircularScrollbarStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((CircularScrollbarStyle)bindable).thumbColor = newValue == null ? null : new Color((Color)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularScrollbarStyle)bindable).thumbColor;
        });

        private float? thickness;
        private float? trackSweepAngle;
        private Color trackColor;
        private Color thumbColor;

        #endregion Fields


        #region Constructors

        /// <summary>
        /// Creates a new instance of a CircularScrollbarStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircularScrollbarStyle() : base()
        {
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="style">Create ScrollbarStyle by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircularScrollbarStyle(CircularScrollbarStyle style) : base(style)
        {
        }

        /// <summary>
        /// Static constructor to initialize bindable properties when loading.
        /// </summary>
        static CircularScrollbarStyle()
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
    }
}
