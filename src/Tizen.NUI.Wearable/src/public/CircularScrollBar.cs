/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace Tizen.NUI.Wearable
{
    /// <summary>
    /// The CircualrScrollBar is a wearable NUI component that can be linked to the scrollable objects
    /// indicating the current scroll position of the scrollable object.<br />
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CircularScrollBar : Control, IScrollBar
    {
        #region Fields

        /// <summary>Bindable property of Thickness</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThicknessProperty = BindableProperty.Create(nameof(Thickness), typeof(float), typeof(CircularScrollBar), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = ((CircularScrollBar)bindable);

            // TODO Set viewStyle.Thickness after style refactoring done.

            instance.UpdateVisualThickness((float?)newValue ?? 0);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularScrollBarStyle)((CircularScrollBar)bindable).viewStyle)?.Thickness ?? 0;
        });

        /// <summary>Bindable property of TrackSweepAngle</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackSweepAngleProperty = BindableProperty.Create(nameof(TrackSweepAngle), typeof(float), typeof(CircularScrollBar), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = ((CircularScrollBar)bindable);

            // TODO Set viewStyle.TrackSweepAngle after style refactoring done.

            instance.UpdateTrackVisualSweepAngle((float?)newValue ?? 0);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularScrollBarStyle)((CircularScrollBar)bindable).viewStyle)?.TrackSweepAngle ?? 0;
        });

        /// <summary>Bindable property of TrackColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackColorProperty = BindableProperty.Create(nameof(TrackColor), typeof(Color), typeof(CircularScrollBar), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = ((CircularScrollBar)bindable);

            // TODO Set viewStyle.TrackColor after style refactoring done.

            instance.UpdateTrackVisualColor((Color)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularScrollBarStyle)((CircularScrollBar)bindable).viewStyle)?.TrackColor;
        });

        /// <summary>Bindable property of ThumbColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbColorProperty = BindableProperty.Create(nameof(ThumbColor), typeof(Color), typeof(CircularScrollBar), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = ((CircularScrollBar)bindable);

            // TODO Set viewStyle.ThumbColor after style refactoring done.

            instance.UpdateThumbVisualColor((Color)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((CircularScrollBarStyle)((CircularScrollBar)bindable).viewStyle)?.ThumbColor;
        });

        private static readonly string TrackVisualName = "Track";
        private static readonly string ThumbVisualName = "Thumb";
        private ArcVisual trackVisual;
        private ArcVisual thumbVisual;
        private float contentLength;
        private float visibleLength;
        private float currentPosition;
        private bool isHorizontal;
        private Animation thumbStartAngleAnimation;
        private Animation thumbSweepAngleAnimation;

        #endregion Fields


        #region Constructors

        /// <summary>
        /// Create an empty CircularScrollBar.
        /// </summary>
        /// <remarks>
        /// Need to call initialize() before using.
        /// See <see cref="IScrollBar.Initialize(float, Size, float, bool)"/> to initialize.
        /// </remarks>
        public CircularScrollBar() : base(new CircularScrollBarStyle())
        {
        }

        /// <summary>
        /// Create a CircularScrollBar and initialize with properties.
        /// </summary>
        /// <param name="contentLength">The total length of the content.</param>
        /// <param name="viewSize">The size of View that contains the content to scroll.</param>
        /// <param name="currentPosition">Scrolled position.</param>
        /// <param name="isHorizontal">Whether the direction of scrolling is horizontal or not. It is vertical if the value is false.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircularScrollBar(float contentLength, Size viewSize, float currentPosition, bool isHorizontal = false) : base(new CircularScrollBarStyle())
        {
            Initialize(contentLength, viewSize, currentPosition, isHorizontal);
        }

        /// <summary>
        /// Create an empty CircularScrollBar with a CircularScrollBarStyle instance to set style properties.
        /// </summary>
        /// <remarks>
        /// Need to call initialize() before using.
        /// See <see cref="IScrollBar.Initialize(float, Size, float, bool)"/> to initialize.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CircularScrollBar(CircularScrollBarStyle style) : base(style)
        {
        }

        /// <summary>
        /// Static constructor to initialize bindable properties when loading.
        /// </summary>
        static CircularScrollBar()
        {
        }

        #endregion Constructors


        #region Properties

        /// <summary>
        /// The thickness of the scrollbar and track.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Thickness
        {
            get => (float)GetValue(ThicknessProperty);
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
        public float TrackSweepAngle
        {
            get => (float)GetValue(TrackSweepAngleProperty);
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
        public View Initialize(float contentLength, Size viewSize, float currentPosition, bool isHorizontal = false)
        {
            this.contentLength = contentLength > 0.0f ? contentLength : 0.0f;
            this.visibleLength = isHorizontal ? viewSize.Width : viewSize.Height;
            this.currentPosition = currentPosition;
            this.isHorizontal = isHorizontal;

            Size = viewSize;

            thumbStartAngleAnimation?.Stop();
            thumbStartAngleAnimation = null;

            thumbSweepAngleAnimation?.Stop();
            thumbSweepAngleAnimation = null;

            trackVisual = new ArcVisual
            {
                SupressUpdateVisual = true,
                Thickness = this.Thickness,
                Cap = ArcVisual.CapType.Round,
                MixColor = TrackColor,
                Size = new Size(visibleLength - 2, visibleLength - 2),
                SizePolicy = VisualTransformPolicyType.Absolute,
            };

            thumbVisual = new ArcVisual
            {
                SupressUpdateVisual = true,
                Thickness = trackVisual.Thickness,
                Cap = ArcVisual.CapType.Round,
                MixColor = ThumbColor,
                Size = new Size(visibleLength - 2, visibleLength - 2),
                SizePolicy = VisualTransformPolicyType.Absolute,
            };

            FillTrackVisualAngles(TrackSweepAngle);
            FillThumbVisualAngles();
            HandleThumbVisualVisibility();

            AddVisual(TrackVisualName, trackVisual);
            AddVisual(ThumbVisualName, thumbVisual);

            return this;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Update(float contentLength, float position, uint durationMs = 0, AlphaFunction alphaFunction = null)
        {
            this.currentPosition = position;
            this.contentLength = contentLength > 0.0f ? contentLength : 0.0f;

            if (thumbVisual == null)
            {
                return;
            }

            FillThumbVisualAngles();

            if (!HandleThumbVisualVisibility() || durationMs == 0)
            {
                thumbVisual.UpdateVisual(true);

                return;
            }

            // TODO Support non built-in alpha function for visual trainsition in DALi.
            AlphaFunction.BuiltinFunctions builtinAlphaFunction = alphaFunction?.GetBuiltinFunction() ?? AlphaFunction.BuiltinFunctions.Default;

            thumbStartAngleAnimation?.Stop();
            thumbStartAngleAnimation = AnimateVisual(thumbVisual, "startAngle", thumbVisual.StartAngle, 0, (int)durationMs, builtinAlphaFunction);
            thumbStartAngleAnimation.Play();

            thumbSweepAngleAnimation?.Stop();
            thumbSweepAngleAnimation = AnimateVisual(thumbVisual, "sweepAngle", thumbVisual.SweepAngle, 0, (int)durationMs, builtinAlphaFunction);
            thumbSweepAngleAnimation.Play();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollTo(float position, uint durationMs = 0, AlphaFunction alphaFunction = null)
        {
            currentPosition = position;

            if (thumbVisual == null)
            {
                return;
            }

            var oldThumbStartAngle = thumbVisual.StartAngle;

            thumbVisual.StartAngle = CalculateThumbStartAngle(contentLength, position, trackVisual.StartAngle, trackVisual.SweepAngle, thumbVisual.SweepAngle);

            if (durationMs == 0)
            {
                thumbVisual.UpdateVisual(true);

                return;
            }

            // TODO Support non built-in alpha function for visual trainsition in DALi.
            AlphaFunction.BuiltinFunctions builtinAlphaFunction = alphaFunction?.GetBuiltinFunction() ?? AlphaFunction.BuiltinFunctions.Default;

            thumbStartAngleAnimation?.Stop();
            thumbStartAngleAnimation = AnimateVisual(thumbVisual, "startAngle", thumbVisual.StartAngle, 0, (int)durationMs, builtinAlphaFunction);
            thumbStartAngleAnimation.Play();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle GetViewStyle()
        {
            return new CircularScrollBarStyle();
        }

        private static void CalculateTrackAngles(bool isHorizontal, float inputSweepAngle, out float startAngle, out float sweepAngle)
        {
            sweepAngle = Math.Min(Math.Max(inputSweepAngle, 3), 60);
            startAngle = (180.0f - sweepAngle) / 2.0f;

            if (isHorizontal)
            {
                startAngle += 270.0f;
            }
        }

        private static void CalculateThumbAngles(float contentLength, float visibleLength, float position, float trackStartAngle, float trackSweepAngle, out float thumbStartAngle, out float thumbSweepAngle)
        {
            if (contentLength <= visibleLength)
            {
                thumbStartAngle = thumbSweepAngle = 0;

                return;
            }

            thumbSweepAngle = trackSweepAngle * visibleLength / contentLength;

            thumbStartAngle = CalculateThumbStartAngle(contentLength, position, trackStartAngle, trackSweepAngle, thumbSweepAngle);
        }

        private static float CalculateThumbStartAngle(float contentLength, float position, float trackStartAngle, float trackSweepAngle, float thumbSweepAngle)
        {
            float minAngle = trackStartAngle;
            float maxAngle = trackStartAngle + trackSweepAngle - thumbSweepAngle;
            float resultAngle = trackStartAngle + (trackSweepAngle * (position < 0.0f ? 0.0f : position) / contentLength);

            return Math.Min(Math.Max(resultAngle, minAngle), maxAngle);
        }

        private void FillTrackVisualAngles(float inputTrackSweepAngle)
        {
            float trackStartAngle;
            float trackSweepAngle;

            CalculateTrackAngles(isHorizontal, inputTrackSweepAngle, out trackStartAngle, out trackSweepAngle);

            trackVisual.StartAngle = trackStartAngle;
            trackVisual.SweepAngle = trackSweepAngle;
        }

        private void FillThumbVisualAngles()
        {
            float thumbStartAngle;
            float thumbSweepAngle;

            CalculateThumbAngles(contentLength, visibleLength, currentPosition, trackVisual.StartAngle, trackVisual.SweepAngle, out thumbStartAngle, out thumbSweepAngle);

            thumbVisual.StartAngle = thumbStartAngle;
            thumbVisual.SweepAngle = thumbSweepAngle;
        }

        /// <returns>Return true if thumb is visible</returns>
        private bool HandleThumbVisualVisibility()
        {
            if (contentLength <= visibleLength)
            {
                thumbVisual.Opacity = 0.0f;

                return false;
            }

            thumbVisual.Opacity = 1.0f;

            return true;
        }

        private void UpdateVisualThickness(float thickness)
        {
            if (trackVisual == null)
            {
                return;
            }

            trackVisual.Thickness = thickness;
            thumbVisual.Thickness = thickness;

            trackVisual.UpdateVisual(true);
            thumbVisual.UpdateVisual(true);
        }

        private void UpdateTrackVisualSweepAngle(float trackSweepAngle)
        {
            if (trackVisual == null || thumbVisual == null)
            {
                return;
            }

            FillTrackVisualAngles(trackSweepAngle);
            FillThumbVisualAngles();

            HandleThumbVisualVisibility();

            trackVisual.UpdateVisual(true);
            thumbVisual.UpdateVisual(true);
        }

        private void UpdateTrackVisualColor(Color trackColor)
        {
            if (trackVisual == null)
            {
                return;
            }

            trackVisual.MixColor = trackColor;
            trackVisual.UpdateVisual(true);
        }

        private void UpdateThumbVisualColor(Color thumbColor)
        {
            if (thumbVisual == null)
            {
                return;
            }

            thumbVisual.MixColor = thumbColor;
            thumbVisual.UpdateVisual(true);
        }

        #endregion Methods
    }
}
