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

        private static readonly string TrackVisualName = "Track";
        private static readonly string ThumbVisualName = "Thumb";
        private ColorVisual trackVisual;
        private ColorVisual thumbVisual;
        private Animation thumbPositionAnimation;
        private Animation thumbSizeAnimation;
        private Calculator calculator;

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
        /// <param name="contentLength">The total length of the content.</param>
        /// <param name="viewSize">The size of View that contains the content to scroll.</param>
        /// <param name="currentPosition">The start position of the View in content length. This is the View's top position if the scroller is vertical, otherwise, View's left position.</param>
        /// <param name="isHorizontal">Whether the direction of scrolling is horizontal or not. It is vertical if the value is false.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Scrollbar(float contentLength, Size viewSize, float currentPosition, bool isHorizontal = false) : base(new ScrollbarStyle())
        {
            Initialize(contentLength, viewSize, currentPosition, isHorizontal);
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
        public override void Initialize(float contentLength, Size viewSize, float currentPosition, bool isHorizontal = false)
        {
            if (isHorizontal)
            {
                calculator = new HorizontalCalculator(contentLength > 0.0f ? contentLength : 0.0f, viewSize.Width);
            }
            else
            {
                calculator = new VerticalCalculator(contentLength > 0.0f ? contentLength : 0.0f, viewSize.Height);
            }

            Size = viewSize;

            thumbPositionAnimation?.Stop();
            thumbPositionAnimation = null;

            thumbSizeAnimation?.Stop();
            thumbSizeAnimation = null;

            CreateTrackVisual();
            CreateThumbVisual(currentPosition);

            AddVisual(TrackVisualName, trackVisual);
            AddVisual(ThumbVisualName, thumbVisual);
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

            calculator.Update(contentLength > 0.0f ? contentLength : 0.0f);

            thumbVisual.Size = calculator.CalculateThumbSize(ThumbThickness, trackVisual.Size);
            thumbVisual.Position = calculator.CalculateThumbScrollPosition(position, trackVisual.Size, thumbVisual.Position, TrackPadding);
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
            if (thumbVisual == null)
            {
                return;
            }

            thumbVisual.Position = calculator.CalculateThumbScrollPosition(position, trackVisual.Size, thumbVisual.Position, TrackPadding);

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
        protected override ViewStyle GetViewStyle()
        {
            return new ScrollbarStyle();
        }

        /// <summary>
        /// Create a track visual.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void CreateTrackVisual()
        {
            trackVisual = new ColorVisual
            {
                SuppressUpdateVisual = true,
                Color = Color.Black,
                SizePolicy = VisualTransformPolicyType.Absolute,
                Origin = calculator.CalculatorTrackAlign(),
                AnchorPoint = calculator.CalculatorTrackAlign(),
                Size = calculator.CalculateTrackSize(TrackThickness, TrackPadding),
                Position = calculator.CalculateTrackPosition(TrackPadding),
            };
        }

        /// <summary>
        /// Create a thumb visual.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void CreateThumbVisual(float currentPosition)
        {
            Size thumbSize = calculator.CalculateThumbSize(ThumbThickness, trackVisual.Size);

            thumbVisual = new ColorVisual
            {
                SuppressUpdateVisual = true,
                MixColor = ThumbColor,
                SizePolicy = VisualTransformPolicyType.Absolute,
                Origin = calculator.CalculatorThumbAlign(),
                AnchorPoint = calculator.CalculatorThumbAlign(),
                Size = thumbSize,
                Position = calculator.CalculateThumbPosition(currentPosition, trackVisual.Size, thumbSize, TrackPadding),
                Opacity = (calculator.CalculateThumbVisibility() ? 1.0f : 0.0f),
            };
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

            trackVisual.Size = calculator.CalculateTrackSize(thickness, TrackPadding);
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
            if (trackVisual == null || thumbVisual == null)
            {
                return;
            }

            trackVisual.Size = calculator.CalculateTrackSize(TrackThickness, trackPadding); 
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
            protected float contentLength;
            protected float visibleLength;

            public Calculator(float contentLength, float visibleLength)
            {
                this.contentLength = contentLength;
                this.visibleLength = visibleLength;
            }

            public void Update(float contentLength)
            {
                this.contentLength = contentLength;
            }

            public bool CalculateThumbVisibility()
            {
                return contentLength > visibleLength;
            }

            public abstract Visual.AlignType CalculatorTrackAlign();
            public abstract Visual.AlignType CalculatorThumbAlign();
            public abstract Size CalculateTrackSize(float thickness, Extents trackPadding);
            public abstract Vector2 CalculateTrackPosition(Extents trackPadding);
            public abstract Size CalculateThumbSize(float thickness, Size trackSize);
            public abstract Vector2 CalculateThumbPosition(float position, Size trackSize, Size thumbSize, Extents trackPadding);
            public abstract Vector2 CalculateThumbPaddingPosition(Size trackSize, Size thumbSize, Vector2 thumbCurrentPosition, Extents trackPadding);
            public abstract Vector2 CalculateThumbScrollPosition(float position, Size trackSize, Vector2 thumbCurrentPosition, Extents trackPadding);
        }

        private class HorizontalCalculator : Calculator
        {
            public HorizontalCalculator(float contentLength, float visibleLength) : base(contentLength, visibleLength)
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

            public override Size CalculateTrackSize(float thickness, Extents trackPadding)
            {
                return new Size(visibleLength - trackPadding.Start - trackPadding.End, thickness);
            }

            public override Vector2 CalculateTrackPosition(Extents trackPadding)
            {
                return new Vector2(0, -trackPadding.Bottom);
            }

            public override Size CalculateThumbSize(float thickness, Size trackSize)
            {
                return new Size(trackSize.Width * visibleLength / contentLength, thickness);
            }

            public override Vector2 CalculateThumbPosition(float position, Size trackSize, Size thumbSize, Extents trackPadding)
            {
                float padding = ((trackSize.Height - thumbSize.Height) / 2.0f) + trackPadding.Bottom;
                float pos = Math.Min(Math.Max(position, 0.0f), contentLength - visibleLength);
                return new Vector2(trackPadding.Start + trackSize.Width * pos / contentLength, -padding);
            }

            public override Vector2 CalculateThumbPaddingPosition(Size trackSize, Size thumbSize, Vector2 thumbCurrentPosition, Extents trackPadding)
            {
                float padding = ((trackSize.Height - thumbSize.Height) / 2.0f) + trackPadding.Bottom;
                return new Vector2(thumbCurrentPosition.X, -padding);
            }

            public override Vector2 CalculateThumbScrollPosition(float position, Size trackSize, Vector2 thumbCurrentPosition, Extents trackPadding)
            {
                float pos = Math.Min(Math.Max(position, 0.0f), contentLength - visibleLength);
                return new Vector2(trackPadding.Start + trackSize.Width * pos / contentLength, thumbCurrentPosition.Y);
            }
        }

        private class VerticalCalculator : Calculator
        {
            public VerticalCalculator(float contentLength, float visibleLength) : base(contentLength, visibleLength)
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

            public override Size CalculateTrackSize(float thickness, Extents trackPadding)
            {
                return new Size(thickness, visibleLength - trackPadding.Top - trackPadding.Bottom);
            }

            public override Vector2 CalculateTrackPosition(Extents trackPadding)
            {
                return new Vector2(-trackPadding.End, 0);
            }

            public override Size CalculateThumbSize(float thickness, Size trackSize)
            {
                return new Size(thickness, trackSize.Height * visibleLength / contentLength);
            }

            public override Vector2 CalculateThumbPosition(float position, Size trackSize, Size thumbSize, Extents trackPadding)
            {
                float padding = ((trackSize.Width - thumbSize.Width) / 2.0f) + trackPadding.End;
                float pos = Math.Min(Math.Max(position, 0.0f), contentLength - visibleLength);
                return new Vector2(-padding, trackPadding.Top + trackSize.Height * pos / contentLength);
            }

            public override Vector2 CalculateThumbPaddingPosition(Size trackSize, Size thumbSize, Vector2 thumbCurrentPosition, Extents trackPadding)
            {
                float padding = ((trackSize.Width - thumbSize.Width) / 2.0f) + trackPadding.End;
                return new Vector2(-padding, thumbCurrentPosition.Y);
            }

            public override Vector2 CalculateThumbScrollPosition(float position, Size trackSize, Vector2 thumbPosition, Extents trackPadding)
            {
                float pos = Math.Min(Math.Max(position, 0.0f), contentLength - visibleLength);
                return new Vector2(thumbPosition.X, trackPadding.Top + trackSize.Height * pos / contentLength);
            }
        }

        #endregion Classes
    }
}
