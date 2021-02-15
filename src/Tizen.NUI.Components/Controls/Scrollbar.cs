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
    // Represents padding data : Start, End, Top, Bottom
    using PaddingType = ValueTuple<ushort, ushort, ushort, ushort>;

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

            instance.scrollbarStyle.TrackThickness = thickness;
            instance.UpdateTrackThickness(thickness ?? 0);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((Scrollbar)bindable).scrollbarStyle.TrackThickness ?? 0;
        });

        /// <summary>Bindable property of ThumbThickness</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbThicknessProperty = BindableProperty.Create(nameof(ThumbThickness), typeof(float), typeof(Scrollbar), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = ((Scrollbar)bindable);
            var thickness = (float?)newValue;

            instance.scrollbarStyle.ThumbThickness = thickness;
            instance.UpdateThumbThickness(thickness ?? 0);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((Scrollbar)bindable).scrollbarStyle.ThumbThickness ?? 0;
        });

        /// <summary>Bindable property of TrackColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackColorProperty = BindableProperty.Create(nameof(TrackColor), typeof(Color), typeof(Scrollbar), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = ((Scrollbar)bindable);
            var color = (Color)newValue;

            instance.scrollbarStyle.TrackColor = color;
            instance.UpdateTrackColor(color);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((Scrollbar)bindable).scrollbarStyle.TrackColor;
        });

        /// <summary>Bindable property of ThumbColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbColorProperty = BindableProperty.Create(nameof(ThumbColor), typeof(Color), typeof(Scrollbar), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = ((Scrollbar)bindable);
            var color = (Color)newValue;

            instance.scrollbarStyle.ThumbColor = color;
            instance.UpdateThumbColor(color);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((Scrollbar)bindable).scrollbarStyle.ThumbColor;
        });

        /// <summary>Bindable property of TrackPadding</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackPaddingProperty = BindableProperty.Create(nameof(TrackPadding), typeof(Extents), typeof(Scrollbar), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = ((Scrollbar)bindable);
            var trackPadding = (Extents)newValue;

            instance.scrollbarStyle.TrackPadding = trackPadding;
            instance.UpdateTrackPadding(trackPadding);
        },
        defaultValueCreator: (bindable) =>
        {
            return ((Scrollbar)bindable).scrollbarStyle.TrackPadding;
        });

        private ColorVisual trackVisual;
        private ColorVisual thumbVisual;
        private Animation thumbPositionAnimation;
        private Animation thumbSizeAnimation;
        private Calculator calculator;
        private Size containerSize = new Size(0, 0);
        private ScrollbarStyle scrollbarStyle => ViewStyle as ScrollbarStyle;
        private bool mScrollEnabled = true;
        private float previousPosition;

        #endregion Fields


        #region Constructors

        /// <summary>
        /// Create an empty Scrollbar.
        /// </summary>
        public Scrollbar()
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
        public Scrollbar(float contentLength, float viewportLength, float currentPosition, bool isHorizontal = false) : this()
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
        /// Note that when the scrollbar is for vertical direction, Start value is ignored.
        /// In case of horizontal direction, Top value is ignored.
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

            PaddingType ensuredPadding = EnsurePadding(TrackPadding);
            Size trackSize = calculator.CalculateTrackSize(TrackThickness, containerSize, ensuredPadding);
            Vector2 trackPosition = calculator.CalculateTrackPosition(ensuredPadding);
            Size thumbSize = calculator.CalculateThumbSize(ThumbThickness, trackSize);
            Vector2 thumbPosition = calculator.CalculateThumbPosition(trackSize, thumbSize, ensuredPadding);

            trackVisual = new ColorVisual
            {
                SuppressUpdateVisual = true,
                MixColor = TrackColor,
                SizePolicy = VisualTransformPolicyType.Absolute,
                Origin = calculator.CalculatorTrackAlign(),
                AnchorPoint = calculator.CalculatorTrackAlign(),
                Size = trackSize,
                Position = trackPosition,
            };

            AddVisual("Track", trackVisual);

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
            previousPosition = calculator.currentPosition;
            calculator.currentPosition = position;

            thumbVisual.Size = calculator.CalculateThumbSize(ThumbThickness, trackVisual.Size);
            thumbVisual.Position = calculator.CalculateThumbScrollPosition(trackVisual.Size, thumbVisual.Position, EnsurePadding(TrackPadding));
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
            if (mScrollEnabled == false)
            {
                return;
            }

            if (calculator == null)
            {
                return;
            }

            previousPosition = calculator.currentPosition;
            calculator.currentPosition = position;
            thumbVisual.Position = calculator.CalculateThumbScrollPosition(trackVisual.Size, thumbVisual.Position, EnsurePadding(TrackPadding));

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

            PaddingType ensuredPadding = EnsurePadding(TrackPadding);
            trackVisual.Size = calculator.CalculateTrackSize(TrackThickness, containerSize, ensuredPadding);
            trackVisual.Position = calculator.CalculateTrackPosition(ensuredPadding);
            thumbVisual.Size = calculator.CalculateThumbSize(ThumbThickness, trackVisual.Size);
            thumbVisual.Position = calculator.CalculateThumbPosition(trackVisual.Size, thumbVisual.Size, ensuredPadding);

            trackVisual.UpdateVisual(true);
            thumbVisual.UpdateVisual(true);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            if (viewStyle is ScrollbarStyle scrollbarStyle)
            {
                // Apply essential look.
                if (scrollbarStyle.TrackThickness == null) scrollbarStyle.TrackThickness = 6.0f;
                if (scrollbarStyle.ThumbThickness == null) scrollbarStyle.ThumbThickness = 6.0f;
                if (scrollbarStyle.TrackColor == null) scrollbarStyle.TrackColor = new Color(1.0f, 1.0f, 1.0f, 0.15f);
                if (scrollbarStyle.ThumbColor == null) scrollbarStyle.ThumbColor = new Color(0.6f, 0.6f, 0.6f, 1.0f);
                if (scrollbarStyle.TrackPadding == null) scrollbarStyle.TrackPadding = 4;
                if (scrollbarStyle.WidthResizePolicy == null) scrollbarStyle.WidthResizePolicy = ResizePolicyType.FillToParent;
                if (scrollbarStyle.HeightResizePolicy == null) scrollbarStyle.HeightResizePolicy = ResizePolicyType.FillToParent;
            }

            base.ApplyStyle(viewStyle);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle CreateViewStyle()
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

            trackVisual.Size = calculator.CalculateTrackSize(thickness, containerSize, EnsurePadding(TrackPadding));
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

            PaddingType ensuredPadding = EnsurePadding(trackPadding);
            trackVisual.Size = calculator.CalculateTrackSize(TrackThickness, containerSize, ensuredPadding);
            trackVisual.Position = calculator.CalculateTrackPosition(ensuredPadding);
            thumbVisual.Size = calculator.CalculateThumbSize(ThumbThickness, trackVisual.Size);
            thumbVisual.Position = calculator.CalculateThumbPaddingPosition(trackVisual.Size, thumbVisual.Size, thumbVisual.Position, ensuredPadding);

            trackVisual.UpdateVisual(true);
            thumbVisual.UpdateVisual(true);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool ScrollEnabled
        {
            get
            {
                return mScrollEnabled;
            }
            set
            {
                if (value != mScrollEnabled)
                {
                    mScrollEnabled = value;
                }
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Position ScrollPosition
        {
            get
            {
                if (calculator == null)
                {
                    return new Position(0.0f, 0.0f);
                }

                float length = Math.Min(Math.Max(calculator.currentPosition, 0.0f), calculator.contentLength - calculator.visibleLength);

                if (calculator is HorizontalCalculator)
                {
                    return new Position(length, 0.0f);
                }
                else
                {
                    return new Position(0.0f, length);
                }
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Position ScrollCurrentPosition
        {
            get
            {
                if (calculator == null)
                {
                    return new Position(0.0f, 0.0f);
                }

                float length = Math.Min(Math.Max(calculator.currentPosition, 0.0f), calculator.contentLength - calculator.visibleLength);

                if (thumbPositionAnimation != null)
                {
                    float progress = thumbPositionAnimation.CurrentProgress;
                    float previousLength = Math.Min(Math.Max(previousPosition, 0.0f), calculator.contentLength - calculator.visibleLength);

                    length = ((1.0f - progress) * previousLength) + (progress * length);
                }

                if (calculator is HorizontalCalculator)
                {
                    return new Position(length, 0.0f);
                }
                else
                {
                    return new Position(0.0f, length);
                }
            }
        }

        private PaddingType EnsurePadding(Extents padding) => padding == null ? new PaddingType(0, 0, 0 ,0) : new PaddingType(padding.Start, padding.End, padding.Top, padding.Bottom);

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
            public abstract Size CalculateTrackSize(float thickness, Size containerSize, PaddingType trackPadding);
            public abstract Vector2 CalculateTrackPosition(PaddingType trackPadding);
            public abstract Size CalculateThumbSize(float thickness, Size trackSize);
            public abstract Vector2 CalculateThumbPosition(Size trackSize, Size thumbSize, PaddingType trackPadding);
            public abstract Vector2 CalculateThumbPaddingPosition(Size trackSize, Size thumbSize, Vector2 thumbCurrentPosition, PaddingType trackPadding);
            public abstract Vector2 CalculateThumbScrollPosition(Size trackSize, Vector2 thumbCurrentPosition, PaddingType trackPadding);
        }

        private class HorizontalCalculator : Calculator
        {
            public HorizontalCalculator(float contentLength, float visibleLength, float currentPosition) : base(contentLength, visibleLength, currentPosition)
            {
            }

            public override Visual.AlignType CalculatorTrackAlign()
            {
                return Visual.AlignType.BottomBegin;
            }

            public override Visual.AlignType CalculatorThumbAlign()
            {
                return Visual.AlignType.BottomBegin;
            }

            public override Size CalculateTrackSize(float thickness, Size containerSize, PaddingType trackPadding)
            {
                return new Size(containerSize.Width - trackPadding.Item1 - trackPadding.Item2, thickness);
            }

            public override Vector2 CalculateTrackPosition(PaddingType trackPadding)
            {
                return new Vector2(trackPadding.Item1, -trackPadding.Item4);
            }

            public override Size CalculateThumbSize(float thickness, Size trackSize)
            {
                return new Size(trackSize.Width * visibleLength / contentLength, thickness);
            }

            public override Vector2 CalculateThumbPosition(Size trackSize, Size thumbSize, PaddingType trackPadding)
            {
                float padding = ((trackSize.Height - thumbSize.Height) / 2.0f) + trackPadding.Item4;
                float pos = Math.Min(Math.Max(currentPosition, 0.0f), contentLength - visibleLength);
                return new Vector2(trackPadding.Item1 + trackSize.Width * pos / contentLength, -padding);
            }

            public override Vector2 CalculateThumbPaddingPosition(Size trackSize, Size thumbSize, Vector2 thumbCurrentPosition, PaddingType trackPadding)
            {
                float padding = ((trackSize.Height - thumbSize.Height) / 2.0f) + trackPadding.Item4;
                return new Vector2(thumbCurrentPosition.X, -padding);
            }

            public override Vector2 CalculateThumbScrollPosition(Size trackSize, Vector2 thumbCurrentPosition, PaddingType trackPadding)
            {
                float pos = Math.Min(Math.Max(currentPosition, 0.0f), contentLength - visibleLength);
                return new Vector2(trackPadding.Item1 + trackSize.Width * pos / contentLength, thumbCurrentPosition.Y);
            }
        }

        private class VerticalCalculator : Calculator
        {
            public VerticalCalculator(float contentLength, float visibleLength, float currentPosition) : base(contentLength, visibleLength, currentPosition)
            {
            }

            public override Visual.AlignType CalculatorTrackAlign()
            {
                return Visual.AlignType.TopEnd;
            }

            public override Visual.AlignType CalculatorThumbAlign()
            {
                return Visual.AlignType.TopEnd;
            }

            public override Size CalculateTrackSize(float thickness, Size containerSize, PaddingType trackPadding)
            {
                return new Size(thickness, containerSize.Height - trackPadding.Item3 - trackPadding.Item4);
            }

            public override Vector2 CalculateTrackPosition(PaddingType trackPadding)
            {
                return new Vector2(-trackPadding.Item2, trackPadding.Item3);
            }

            public override Size CalculateThumbSize(float thickness, Size trackSize)
            {
                return new Size(thickness, trackSize.Height * visibleLength / contentLength);
            }

            public override Vector2 CalculateThumbPosition(Size trackSize, Size thumbSize, PaddingType trackPadding)
            {
                float padding = ((trackSize.Width - thumbSize.Width) / 2.0f) + trackPadding.Item2;
                float pos = Math.Min(Math.Max(currentPosition, 0.0f), contentLength - visibleLength);
                return new Vector2(-padding, trackPadding.Item3 + trackSize.Height * pos / contentLength);
            }

            public override Vector2 CalculateThumbPaddingPosition(Size trackSize, Size thumbSize, Vector2 thumbCurrentPosition, PaddingType trackPadding)
            {
                float padding = ((trackSize.Width - thumbSize.Width) / 2.0f) + trackPadding.Item2;
                return new Vector2(-padding, thumbCurrentPosition.Y);
            }

            public override Vector2 CalculateThumbScrollPosition(Size trackSize, Vector2 thumbPosition, PaddingType trackPadding)
            {
                float pos = Math.Min(Math.Max(currentPosition, 0.0f), contentLength - visibleLength);
                return new Vector2(thumbPosition.X, trackPadding.Item3 + trackSize.Height * pos / contentLength);
            }
        }

        #endregion Classes
    }
}
