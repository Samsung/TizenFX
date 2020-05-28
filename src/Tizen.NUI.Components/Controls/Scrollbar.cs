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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The Scrollbar is a component that contains track and thumb to indicate the current scrolled position of a scrollable object.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Scrollbar : ScrollbarBase
    {
        #region Fields

        /// <summary>Bindable property of TrackThickness</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackThicknessProperty = BindableProperty.Create(nameof(TrackThickness), typeof(float), typeof(Scrollbar), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = ((Scrollbar)bindable);
            var thickness = (float?)newValue;

            ((ScrollbarStyle)instance.viewStyle).TrackThickness = thickness;
            instance.UpdateTrackThickness(thickness ?? 0);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ScrollbarStyle)((Scrollbar)bindable).viewStyle)?.TrackThickness ?? 0;
        });

        /// <summary>Bindable property of ThumbThickness</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbThicknessProperty = BindableProperty.Create(nameof(ThumbThickness), typeof(float), typeof(Scrollbar), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = ((Scrollbar)bindable);
            var thickness = (float?)newValue;

            ((ScrollbarStyle)instance.viewStyle).ThumbThickness = thickness;
            instance.UpdateThumbThickness(thickness ?? 0);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ScrollbarStyle)((Scrollbar)bindable).viewStyle)?.ThumbThickness ?? 0;
        });

        /// <summary>Bindable property of TrackColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackColorProperty = BindableProperty.Create(nameof(TrackColor), typeof(Color), typeof(Scrollbar), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = ((Scrollbar)bindable);
            var color = (Color)newValue;

            ((ScrollbarStyle)instance.viewStyle).TrackColor = color;
            instance.UpdateTrackColor(color);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ScrollbarStyle)((Scrollbar)bindable).viewStyle)?.TrackColor;
        });

        /// <summary>Bindable property of ThumbColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbColorProperty = BindableProperty.Create(nameof(ThumbColor), typeof(Color), typeof(Scrollbar), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = ((Scrollbar)bindable);
            var color = (Color)newValue;

            ((ScrollbarStyle)instance.viewStyle).ThumbColor = color;
            instance.UpdateThumbColor(color);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ScrollbarStyle)((Scrollbar)bindable).viewStyle)?.ThumbColor;
        });

        /// <summary>Bindable property of TrackPadding</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackPaddingProperty = BindableProperty.Create(nameof(TrackPadding), typeof(Extents), typeof(Scrollbar), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = ((Scrollbar)bindable);
            var trackPadding = (Extents)newValue;

            ((ScrollbarStyle)instance.viewStyle).TrackPadding = trackPadding;
            instance.UpdateTrackPadding(trackPadding);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ScrollbarStyle)((Scrollbar)bindable).viewStyle)?.TrackPadding;
        });

        private ColorVisual trackVisual;
        private ColorVisual thumbVisual;
        private Animation thumbPositionAnimation;
        private Animation thumbSizeAnimation;
        private Calculator calculator;
        private Size containerSize = new Size(0, 0);
        private float currentPosition;

        #endregion Fields


        #region Constructors

        /// <summary>
        /// Create an empty Scrollbar.
        /// </summary>
        public Scrollbar() : base(new ScrollbarStyle())
        {
        }

        /// <summary>
        /// Create a Scrollbar and initialize with properties.
        /// </summary>
        /// <param name="contentLength">The length of the scrollable content area.</param>
        /// <param name="viewportLength">The length of the viewport representing the amount of visible content.</param>
        /// <param name="currentPosition">The current position of the viewport in scrollable content area. This is the viewport's top position if the scroller is vertical, otherwise, left.</param>
        /// <param name="isHorizontal">Whether the direction of scrolling is horizontal or not. It is vertical by default.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Scrollbar(float contentLength, float viewportLength, float currentPosition, bool isHorizontal = false) : base(new ScrollbarStyle())
        {
            Initialize(contentLength, viewportLength, currentPosition, isHorizontal);
        }

        /// <summary>
        /// Create an empty Scrollbar with a ScrollbarStyle instance to set style properties.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Scrollbar(ScrollbarStyle style) : base(style)
        {
        }

        /// <summary>
        /// Static constructor to initialize bindable properties when loading.
        /// </summary>
        static Scrollbar()
        {
        }

        #endregion Constructors


        #region Properties

        /// <summary>
        /// The thickness of the track.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float TrackThickness
        {
            get => (float)GetValue(TrackThicknessProperty);
            set => SetValue(TrackThicknessProperty, value);
        }

        /// <summary>
        /// The thickness of the thumb.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ThumbThickness
        {
            get => (float)GetValue(ThumbThicknessProperty);
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
        public override void Initialize(float contentLength, float viewportLength, float currentPosition, bool isHorizontal = false)
        {
            if (isHorizontal)
            {
                calculator = new HorizontalCalculator(contentLength > 0.0f ? contentLength : 0.0f, viewportLength, currentPosition);
            }
            else
            {
                calculator = new VerticalCalculator(contentLength > 0.0f ? contentLength : 0.0f, viewportLength, currentPosition);
            }

            thumbPositionAnimation?.Stop();
            thumbPositionAnimation = null;

            thumbSizeAnimation?.Stop();
            thumbSizeAnimation = null;

            Size trackSize = calculator.CalculateTrackSize(TrackThickness, containerSize, TrackPadding);
            Vector2 trackPosition = calculator.CalculateTrackPosition(TrackPadding);
            Size thumbSize = calculator.CalculateThumbSize(ThumbThickness, trackSize);
            Vector2 thumbPosition = calculator.CalculateThumbPosition(trackSize, thumbSize, TrackPadding);

            if (trackVisual == null)
            {
                trackVisual = new ColorVisual
                {
                    SuppressUpdateVisual = true,
                    Color = TrackColor,
                    SizePolicy = VisualTransformPolicyType.Absolute,
                    Origin = calculator.CalculatorTrackAlign(),
                    AnchorPoint = calculator.CalculatorTrackAlign(),
                    Size = trackSize,
                    Position = trackPosition,
                };

                AddVisual("Track", trackVisual);
            }
            else
            {
                trackVisual.Size = trackSize;
                trackVisual.Position = trackPosition;
                trackVisual.UpdateVisual(true);
            }

            if (thumbVisual == null)
            {
                thumbVisual = new ColorVisual
                {
                    SuppressUpdateVisual = true,
                    MixColor = ThumbColor,
                    SizePolicy = VisualTransformPolicyType.Absolute,
                    Origin = calculator.CalculatorThumbAlign(),
                    AnchorPoint = calculator.CalculatorThumbAlign(),
                    Opacity = calculator.CalculateThumbVisibility() ? 1.0f : 0.0f,
                    Size = thumbSize,
                    Position = thumbPosition,
                };

                AddVisual("Thumb", thumbVisual);
            }
            else
            {
                thumbVisual.Size = thumbSize;
                thumbVisual.Position = thumbPosition;
                thumbVisual.UpdateVisual(true);
            }
        }

        /// <inheritdoc/>
        /// <remarks>Please note that, for now, only alpha functions created with BuiltinFunctions are valid when animating. Otherwise, it will be treated as a linear alpha function. </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Update(float contentLength, float position, uint durationMs = 0, AlphaFunction alphaFunction = null)
        {
            if (calculator == null)
            {
                return;
            }

            calculator.contentLength = contentLength > 0.0f ? contentLength : 0.0f;
            calculator.currentPosition = position;

            thumbVisual.Size = calculator.CalculateThumbSize(ThumbThickness, trackVisual.Size);
            thumbVisual.Position = calculator.CalculateThumbScrollPosition(trackVisual.Size, thumbVisual.Position, TrackPadding);
            thumbVisual.Opacity = calculator.CalculateThumbVisibility() ? 1.0f : 0.0f;

            if (durationMs == 0)
            {
                thumbVisual.UpdateVisual(true);

                return;
            }

            // TODO Support non built-in alpha function for visual trainsition in DALi.
            AlphaFunction.BuiltinFunctions builtinAlphaFunction = alphaFunction?.GetBuiltinFunction() ?? AlphaFunction.BuiltinFunctions.Default;

            thumbPositionAnimation?.Stop();
            thumbPositionAnimation = AnimateVisual(thumbVisual, "position", thumbVisual.Position, 0, (int)durationMs, builtinAlphaFunction);
            thumbPositionAnimation.Play();

            thumbSizeAnimation?.Stop();
            thumbSizeAnimation = AnimateVisual(thumbVisual, "size", thumbVisual.Size, 0, (int)durationMs, builtinAlphaFunction);
            thumbSizeAnimation.Play();
        }

        /// <inheritdoc/>
        /// <remarks>Please note that, for now, only alpha functions created with BuiltinFunctions are valid when animating. Otherwise, it will be treated as a linear alpha function. </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ScrollTo(float position, uint durationMs = 0, AlphaFunction alphaFunction = null)
        {
            if (calculator == null)
            {
                return;
            }

            calculator.currentPosition = position;
            thumbVisual.Position = calculator.CalculateThumbScrollPosition(trackVisual.Size, thumbVisual.Position, TrackPadding);

            if (durationMs == 0)
            {
                thumbVisual.UpdateVisual(true);

                return;
            }

            // TODO Support non built-in alpha function for visual trainsition in DALi.
            AlphaFunction.BuiltinFunctions builtinAlphaFunction = alphaFunction?.GetBuiltinFunction() ?? AlphaFunction.BuiltinFunctions.Default;

            thumbPositionAnimation?.Stop();
            thumbPositionAnimation = AnimateVisual(thumbVisual, "position", thumbVisual.Position, 0, (int)durationMs, builtinAlphaFunction);
            thumbPositionAnimation.Play();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            base.OnRelayout(size, container);

            if (size.Width == containerSize.Width && size.Height == containerSize.Height)
            {
                return;
            }

            containerSize = new Size(size.Width, size.Height);

            if (calculator == null)
            {
                return;
            }

            trackVisual.Size = calculator.CalculateTrackSize(TrackThickness, containerSize, TrackPadding);
            trackVisual.Position = calculator.CalculateTrackPosition(TrackPadding);
            thumbVisual.Size = calculator.CalculateThumbSize(ThumbThickness, trackVisual.Size);
            thumbVisual.Position = calculator.CalculateThumbPosition(trackVisual.Size, thumbVisual.Size, TrackPadding);

            trackVisual.UpdateVisual(true);
            thumbVisual.UpdateVisual(true);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle GetViewStyle()
        {
            return new ScrollbarStyle();
        }

        /// <summary>
        /// Update TrackThickness property of the scrollbar.
        /// </summary>
        /// <param name="thickness">The width of the track.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void UpdateTrackThickness(float thickness)
        {
            if (trackVisual == null)
            {
                return;
            }

            trackVisual.Size = calculator.CalculateTrackSize(thickness, containerSize, TrackPadding);
            trackVisual.UpdateVisual(true);
        }

        /// <summary>
        /// Update ThumbThickness property of the scrollbar.
        /// </summary>
        /// <param name="thickness">The width of the track.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void UpdateThumbThickness(float thickness)
        {
            if (thumbVisual == null)
            {
                return;
            }

            thumbVisual.Size = calculator.CalculateThumbSize(thickness, trackVisual.Size);
            thumbVisual.UpdateVisual(true);
        }

        /// <summary>
        /// Update TrackColor property of the scrollbar.
        /// </summary>
        /// <param name="color">The color of the track.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void UpdateTrackColor(Color color)
        {
            if (trackVisual == null)
            {
                return;
            }

            trackVisual.MixColor = color;
            trackVisual.UpdateVisual(true);
        }

        /// <summary>
        /// Update ThumbColor property of the scrollbar.
        /// </summary>
        /// <param name="color">The color of the thumb.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void UpdateThumbColor(Color color)
        {
            if (thumbVisual == null)
            {
                return;
            }

            thumbVisual.MixColor = color;
            thumbVisual.UpdateVisual(true);
        }

        /// <summary>
        /// Update TrackPadding property of the scrollbar.
        /// </summary>
        /// <param name="trackPadding">The padding of the track.</param>
        protected virtual void UpdateTrackPadding(Extents trackPadding)
        {
            if (calculator == null)
            {
                return;
            }

            trackVisual.Size = calculator.CalculateTrackSize(TrackThickness, containerSize, trackPadding); 
            trackVisual.Position = calculator.CalculateTrackPosition(trackPadding);
            thumbVisual.Size = calculator.CalculateThumbSize(ThumbThickness, trackVisual.Size);
            thumbVisual.Position = calculator.CalculateThumbPaddingPosition(trackVisual.Size, thumbVisual.Size, thumbVisual.Position, trackPadding);

            trackVisual.UpdateVisual(true);
            thumbVisual.UpdateVisual(true);
        }

        #endregion Methods


        #region Classes

        private abstract class Calculator
        {
            public float contentLength;
            public float visibleLength;
            public float currentPosition;

            public Calculator(float contentLength, float visibleLength, float currentPosition)
            {
                this.contentLength = contentLength;
                this.visibleLength = visibleLength;
                this.currentPosition = currentPosition;
            }

            public bool CalculateThumbVisibility()
            {
                return contentLength > visibleLength;
            }

            public abstract Visual.AlignType CalculatorTrackAlign();
            public abstract Visual.AlignType CalculatorThumbAlign();
            public abstract Size CalculateTrackSize(float thickness, Size containerSize, Extents trackPadding);
            public abstract Vector2 CalculateTrackPosition(Extents trackPadding);
            public abstract Size CalculateThumbSize(float thickness, Size trackSize);
            public abstract Vector2 CalculateThumbPosition(Size trackSize, Size thumbSize, Extents trackPadding);
            public abstract Vector2 CalculateThumbPaddingPosition(Size trackSize, Size thumbSize, Vector2 thumbCurrentPosition, Extents trackPadding);
            public abstract Vector2 CalculateThumbScrollPosition(Size trackSize, Vector2 thumbCurrentPosition, Extents trackPadding);
        }

        private class HorizontalCalculator : Calculator
        {
            public HorizontalCalculator(float contentLength, float visibleLength, float currentPosition) : base(contentLength, visibleLength, currentPosition)
            {
            }

            public override Visual.AlignType CalculatorTrackAlign()
            {
                return Visual.AlignType.BottomCenter;
            }

            public override Visual.AlignType CalculatorThumbAlign()
            {
                return Visual.AlignType.BottomBegin;
            }

            public override Size CalculateTrackSize(float thickness, Size containerSize, Extents trackPadding)
            {
                return new Size(containerSize.Width - trackPadding.Start - trackPadding.End, thickness);
            }

            public override Vector2 CalculateTrackPosition(Extents trackPadding)
            {
                return new Vector2(0, -trackPadding.Bottom);
            }

            public override Size CalculateThumbSize(float thickness, Size trackSize)
            {
                return new Size(trackSize.Width * visibleLength / contentLength, thickness);
            }

            public override Vector2 CalculateThumbPosition(Size trackSize, Size thumbSize, Extents trackPadding)
            {
                float padding = ((trackSize.Height - thumbSize.Height) / 2.0f) + trackPadding.Bottom;
                float pos = Math.Min(Math.Max(currentPosition, 0.0f), contentLength - visibleLength);
                return new Vector2(trackPadding.Start + trackSize.Width * pos / contentLength, -padding);
            }

            public override Vector2 CalculateThumbPaddingPosition(Size trackSize, Size thumbSize, Vector2 thumbCurrentPosition, Extents trackPadding)
            {
                float padding = ((trackSize.Height - thumbSize.Height) / 2.0f) + trackPadding.Bottom;
                return new Vector2(thumbCurrentPosition.X, -padding);
            }

            public override Vector2 CalculateThumbScrollPosition(Size trackSize, Vector2 thumbCurrentPosition, Extents trackPadding)
            {
                float pos = Math.Min(Math.Max(currentPosition, 0.0f), contentLength - visibleLength);
                return new Vector2(trackPadding.Start + trackSize.Width * pos / contentLength, thumbCurrentPosition.Y);
            }
        }

        private class VerticalCalculator : Calculator
        {
            public VerticalCalculator(float contentLength, float visibleLength, float currentPosition) : base(contentLength, visibleLength, currentPosition)
            {
            }

            public override Visual.AlignType CalculatorTrackAlign()
            {
                return Visual.AlignType.CenterEnd;
            }

            public override Visual.AlignType CalculatorThumbAlign()
            {
                return Visual.AlignType.TopEnd;
            }

            public override Size CalculateTrackSize(float thickness, Size containerSize, Extents trackPadding)
            {
                return new Size(thickness, containerSize.Height - trackPadding.Top - trackPadding.Bottom);
            }

            public override Vector2 CalculateTrackPosition(Extents trackPadding)
            {
                return new Vector2(-trackPadding.End, 0);
            }

            public override Size CalculateThumbSize(float thickness, Size trackSize)
            {
                return new Size(thickness, trackSize.Height * visibleLength / contentLength);
            }

            public override Vector2 CalculateThumbPosition(Size trackSize, Size thumbSize, Extents trackPadding)
            {
                float padding = ((trackSize.Width - thumbSize.Width) / 2.0f) + trackPadding.End;
                float pos = Math.Min(Math.Max(currentPosition, 0.0f), contentLength - visibleLength);
                return new Vector2(-padding, trackPadding.Top + trackSize.Height * pos / contentLength);
            }

            public override Vector2 CalculateThumbPaddingPosition(Size trackSize, Size thumbSize, Vector2 thumbCurrentPosition, Extents trackPadding)
            {
                float padding = ((trackSize.Width - thumbSize.Width) / 2.0f) + trackPadding.End;
                return new Vector2(-padding, thumbCurrentPosition.Y);
            }

            public override Vector2 CalculateThumbScrollPosition(Size trackSize, Vector2 thumbPosition, Extents trackPadding)
            {
                float pos = Math.Min(Math.Max(currentPosition, 0.0f), contentLength - visibleLength);
                return new Vector2(thumbPosition.X, trackPadding.Top + trackSize.Height * pos / contentLength);
            }
        }

        #endregion Classes
    }
}
