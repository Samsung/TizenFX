/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using System.Diagnostics;
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
        public static readonly BindableProperty TrackThicknessProperty = null;
        internal static void SetInternalTrackThicknessProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((Scrollbar)bindable).UpdateTrackThickness((float?)newValue ?? 0);
        }
        internal static object GetInternalTrackThicknessProperty(BindableObject bindable)
        {
            return ((Scrollbar)bindable).trackThickness;
        }

        /// <summary>Bindable property of ThumbThickness</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbThicknessProperty = null;
        internal static void SetInternalThumbThicknessProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((Scrollbar)bindable).UpdateThumbThickness((float?)newValue ?? 0);
        }
        internal static object GetInternalThumbThicknessProperty(BindableObject bindable)
        {
            return ((Scrollbar)bindable).thumbThickness;
        }

        /// <summary>Bindable property of TrackColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackColorProperty = null;
        internal static void SetInternalTrackColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((Scrollbar)bindable).trackView.BackgroundColor = (Color)newValue;
        }
        internal static object GetInternalTrackColorProperty(BindableObject bindable)
        {
            return ((Scrollbar)bindable).trackView.BackgroundColor;
        }

        /// <summary>Bindable property of ThumbColor</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbColorProperty = null;
        internal static void SetInternalThumbColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((Scrollbar)bindable).UpdateThumbColor((Color)newValue);
        }
        internal static object GetInternalThumbColorProperty(BindableObject bindable)
        {
            return ((Scrollbar)bindable).thumbColor;
        }

        /// <summary>Bindable property of TrackPadding</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TrackPaddingProperty = null;
        internal static void SetInternalTrackPaddingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((Scrollbar)bindable).UpdateTrackPadding((Extents)newValue);
        }
        internal static object GetInternalTrackPaddingProperty(BindableObject bindable)
        {
            //NOTE: the type of trackPadding is not Extents.
            return ((Scrollbar)bindable).trackPadding;
        }

        /// <summary>Bindable property of ThumbVerticalImageUrl</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbVerticalImageUrlProperty = null;
        internal static void SetInternalThumbVerticalImageUrlProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((Scrollbar)bindable).UpdateThumbImage((string)newValue, false);
        }
        internal static object GetInternalThumbVerticalImageUrlProperty(BindableObject bindable)
        {
            return ((Scrollbar)bindable).thumbVerticalImageUrl;
        }

        /// <summary>Bindable property of ThumbHorizontalImageUrl</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThumbHorizontalImageUrlProperty = null;
        internal static void SetInternalThumbHorizontalImageUrlProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((Scrollbar)bindable).UpdateThumbImage((string)newValue, true);
        }
        internal static object GetInternalThumbHorizontalImageUrlProperty(BindableObject bindable)
        {
            return ((Scrollbar)bindable).thumbHorizontalImageUrl;
        }

        private View trackView;
        private ImageView thumbView;
        private Animation thumbPositionAnimation;
        private Animation thumbSizeAnimation;
        private Animation opacityAnimation;
        private Calculator calculator;
        private Size containerSize = new Size(0, 0);
        private float previousPosition;
        private float trackThickness = 6.0f;
        private float thumbThickness = 6.0f;
        private string thumbVerticalImageUrl;
        private string thumbHorizontalImageUrl;
        private Color thumbColor;
        private PaddingType trackPadding = new PaddingType(4, 4, 4, 4);
        private bool isHorizontal;
        private uint fadeOutThreshold = 500;
        private int fadeDuration = 200;
        private Timer fadeOutTimer;

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
            if (NUIApplication.IsUsingXaml)
            {
                TrackThicknessProperty = BindableProperty.Create(nameof(TrackThickness), typeof(float), typeof(Scrollbar), default(float),
                    propertyChanged: SetInternalTrackThicknessProperty, defaultValueCreator: GetInternalTrackThicknessProperty);
                ThumbThicknessProperty = BindableProperty.Create(nameof(ThumbThickness), typeof(float), typeof(Scrollbar), default(float),
                    propertyChanged: SetInternalThumbThicknessProperty, defaultValueCreator: GetInternalThumbThicknessProperty);
                TrackColorProperty = BindableProperty.Create(nameof(TrackColor), typeof(Color), typeof(Scrollbar), null,
                    propertyChanged: SetInternalTrackColorProperty, defaultValueCreator: GetInternalTrackColorProperty);
                ThumbColorProperty = BindableProperty.Create(nameof(ThumbColor), typeof(Color), typeof(Scrollbar), null,
                    propertyChanged: SetInternalThumbColorProperty, defaultValueCreator: GetInternalThumbColorProperty);
                TrackPaddingProperty = BindableProperty.Create(nameof(TrackPadding), typeof(Extents), typeof(Scrollbar), null,
                    propertyChanged: SetInternalTrackPaddingProperty, defaultValueCreator: GetInternalTrackPaddingProperty);
                ThumbVerticalImageUrlProperty = BindableProperty.Create(nameof(ThumbVerticalImageUrl), typeof(string), typeof(Scrollbar), null,
                    propertyChanged: SetInternalThumbVerticalImageUrlProperty, defaultValueCreator: GetInternalThumbVerticalImageUrlProperty);
                ThumbHorizontalImageUrlProperty = BindableProperty.Create(nameof(ThumbHorizontalImageUrl), typeof(string), typeof(Scrollbar), null,
                    propertyChanged: SetInternalThumbHorizontalImageUrlProperty, defaultValueCreator: GetInternalThumbHorizontalImageUrlProperty);
            }
        }

        #endregion Constructors


        #region Properties

        /// <summary>
        /// The thickness of the track.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float TrackThickness
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(TrackThicknessProperty);
                }
                else
                {
                    return trackThickness;
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
                    UpdateTrackThickness(value);
                }
            }
        }

        /// <summary>
        /// The thickness of the thumb.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float ThumbThickness
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(ThumbThicknessProperty);
                }
                else
                {
                    return thumbThickness;
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
                    UpdateThumbThickness(value);
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
                    return trackView.BackgroundColor;
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
                    trackView.BackgroundColor = value;
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
                    return thumbColor;
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
                    UpdateThumbColor(value);
                }
            }
        }

        /// <summary>
        /// The padding value of the track.
        /// Note that when the scrollbar is for vertical direction, Start value is ignored.
        /// In case of horizontal direction, Top value is ignored.
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
                    return new Extents(trackPadding.Item1, trackPadding.Item2, trackPadding.Item3, trackPadding.Item4);
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
                    UpdateTrackPadding(value);
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
                    return thumbVerticalImageUrl;
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
                    UpdateThumbImage(value, false);
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
                    return thumbHorizontalImageUrl;
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
                    UpdateThumbImage(value, true);
                }
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float ScrollPosition
        {
            get
            {
                if (calculator == null)
                {
                    return 0.0f;
                }

                return Math.Min(Math.Max(calculator.currentPosition, 0.0f), calculator.contentLength - calculator.visibleLength);
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override float ScrollCurrentPosition
        {
            get
            {
                if (calculator == null)
                {
                    return 0.0f;
                }

                float length = Math.Min(Math.Max(calculator.currentPosition, 0.0f), calculator.contentLength - calculator.visibleLength);

                if (thumbPositionAnimation != null)
                {
                    float progress = thumbPositionAnimation.CurrentProgress;
                    float previousLength = Math.Min(Math.Max(previousPosition, 0.0f), calculator.contentLength - calculator.visibleLength);

                    length = ((1.0f - progress) * previousLength) + (progress * length);
                }

                return length;
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal override uint FadeOutThreshold
        {
            get => fadeOutThreshold;
            set => fadeOutThreshold = value;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal override int FadeDuration
        {
            get => fadeDuration;
            set => fadeDuration = value;
        }

        #endregion Properties


        #region Methods

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();

            trackView = new View()
            {
                PositionUsesPivotPoint = true,
                AccessibilityHidden = true
            };
            Add(trackView);

            var scrollbarStyle = ViewStyle as ScrollbarStyle;

            thumbView = new ImageView(scrollbarStyle?.Thumb)
            {
                PositionUsesPivotPoint = true,
            };
            Add(thumbView);

            WidthResizePolicy = ResizePolicyType.FillToParent;
            HeightResizePolicy = ResizePolicyType.FillToParent;

            EnableControlState = false;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Initialize(float contentLength, float viewportLength, float currentPosition, bool isHorizontal = false)
        {
            this.isHorizontal = isHorizontal;
            if (isHorizontal)
            {
                if (thumbHorizontalImageUrl != null)
                {
                    thumbView.ResourceUrl = thumbHorizontalImageUrl;
                    thumbView.Color = thumbColor;
                    thumbView.BackgroundColor = Color.Transparent;
                }
                calculator = new HorizontalCalculator(contentLength > 0.0f ? contentLength : 0.0f, viewportLength, currentPosition);
            }
            else
            {
                if (thumbVerticalImageUrl != null)
                {
                    thumbView.ResourceUrl = thumbVerticalImageUrl;
                    thumbView.Color = thumbColor;
                    thumbView.BackgroundColor = Color.Transparent;
                }
                calculator = new VerticalCalculator(contentLength > 0.0f ? contentLength : 0.0f, viewportLength, currentPosition);
            }

            thumbPositionAnimation?.Clear();
            thumbPositionAnimation = null;

            thumbSizeAnimation?.Clear();
            thumbSizeAnimation = null;

            opacityAnimation?.Clear();
            opacityAnimation = null;

            var trackSize = calculator.CalculateTrackSize(TrackThickness, containerSize, trackPadding);
            var trackPosition = calculator.CalculateTrackPosition(trackPadding);
            var thumbSize = calculator.CalculateThumbSize(ThumbThickness, trackSize);
            var thumbPosition = calculator.CalculateThumbPosition(trackSize, thumbSize, trackPadding);

            Debug.Assert(trackView != null);
            trackView.ParentOrigin = calculator.CalculatorTrackAlign();
            trackView.PivotPoint = calculator.CalculatorTrackAlign();
            trackView.Size = trackSize;
            trackView.Position = trackPosition;

            Debug.Assert(thumbView != null);
            thumbView.ParentOrigin = calculator.CalculatorThumbAlign();
            thumbView.PivotPoint = calculator.CalculatorThumbAlign();
            thumbView.Size = thumbSize;
            thumbView.Position = thumbPosition;;

            Opacity = calculator.IsScrollable() ? 1.0f : 0.0f;
        }

        /// <inheritdoc/>
        /// <exception cref="InvalidOperationException">Thrown when the scrollabr not yet initialized.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Update(float contentLength, float viewportLength, float position, uint durationMs = 0, AlphaFunction alphaFunction = null)
        {
            if (calculator == null)
            {
                throw new InvalidOperationException("Scrollbar is not initialized. Please call Initialize() first.");
            }

            calculator.visibleLength = viewportLength;
            Update(contentLength, position, durationMs, alphaFunction);
        }

        /// <inheritdoc/>
        /// <exception cref="InvalidOperationException">Thrown when the scrollabr not yet initialized.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void Update(float contentLength, float position, uint durationMs = 0, AlphaFunction alphaFunction = null)
        {
            if (calculator == null)
            {
                throw new InvalidOperationException("Scrollbar is not initialized. Please call Initialize() first.");
            }

            calculator.contentLength = contentLength > 0.0f ? contentLength : 0.0f;
            calculator.currentPosition = position;

            float newOpacity = calculator.IsScrollable() ? 1.0f : 0.0f;
            bool opacityChanged = (int)Opacity != (int)newOpacity;

            var thumbSize = calculator.CalculateThumbSize(ThumbThickness, trackView.Size);
            var thumbPosition = calculator.CalculateThumbScrollPosition(trackView.Size, thumbView.Position, trackPadding);

            if (durationMs == 0)
            {
                thumbView.Position = thumbPosition;
                thumbView.Size = thumbSize;

                if (opacityChanged)
                {
                    Opacity = newOpacity;
                }
                return;
            }

            EnsureThumbPositionAnimation().AnimateTo(thumbView, "Position", thumbPosition, 0, (int)durationMs, alphaFunction);
            thumbPositionAnimation.Play();

            EnsureThumbSizeAnimation().AnimateTo(thumbView, "Size", thumbSize, 0, (int)durationMs, alphaFunction);
            thumbSizeAnimation.Play();

            if (opacityChanged)
            {
                EnsureOpacityAnimation().AnimateTo(this, "Opacity", newOpacity, 0, (int)durationMs, alphaFunction);
                opacityAnimation.Play();
            }
        }

        /// <inheritdoc/>
        /// <remarks>Please note that, for now, only alpha functions created with BuiltinFunctions are valid when animating. Otherwise, it will be treated as a linear alpha function. </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ScrollTo(float position, uint durationMs = 0, AlphaFunction alphaFunction = null)
        {
            if (ControlState == ControlState.Disabled)
            {
                return;
            }

            if (calculator == null)
            {
                return;
            }

            previousPosition = calculator.currentPosition;
            calculator.currentPosition = position;
            var thumbPosition = calculator.CalculateThumbScrollPosition(trackView.Size, thumbView.Position, trackPadding);

            if (durationMs == 0)
            {
                thumbView.Position = thumbPosition;
                return;
            }

            EnsureThumbPositionAnimation().AnimateTo(thumbView, "position", thumbPosition, 0, (int)durationMs, alphaFunction);
            thumbPositionAnimation.Play();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnRelayout(Vector2 size, RelayoutContainer container)
        {
            base.OnRelayout(size, container);

            if (size == null || size.Width == containerSize.Width && size.Height == containerSize.Height)
            {
                return;
            }

            containerSize = new Size(size.Width, size.Height);

            if (calculator == null)
            {
                return;
            }

            trackView.Size = calculator.CalculateTrackSize(TrackThickness, containerSize, trackPadding);
            trackView.Position = calculator.CalculateTrackPosition(trackPadding);
            thumbView.Size = calculator.CalculateThumbSize(ThumbThickness, trackView.Size);
            thumbView.Position = calculator.CalculateThumbPosition(trackView.Size, thumbView.Size, trackPadding);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal override void FadeOut()
        {
            if (fadeOutTimer == null)
            {
                fadeOutTimer = new Timer(fadeOutThreshold);
                fadeOutTimer.Tick += ((object target, Timer.TickEventArgs args) =>
                {
                    var anim = EnsureOpacityAnimation();

                    if (Opacity != 0.0f)
                    {
                        anim.AnimateTo(this, "Opacity", 0.0f, 0, fadeDuration);
                        anim.Play();
                    }
                    fadeOutTimer = null;
                    return false;
                });
                fadeOutTimer.Start();
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal override void FadeIn()
        {
            if (fadeOutTimer != null)
            {
                fadeOutTimer.Stop();
                fadeOutTimer.Dispose();
                fadeOutTimer = null;
            }

            var anim = EnsureOpacityAnimation();

            if (Opacity != 1.0)
            {
                anim.AnimateTo(this, "Opacity", 1.0f, 0, fadeDuration);
                anim.Play();
            }
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);
            if (viewStyle is ScrollbarStyle scrollbarStyle)
            {
                thumbView?.ApplyStyle(scrollbarStyle.Thumb);
            }
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
        private void UpdateTrackThickness(float thickness)
        {
            trackThickness = thickness;

            if (calculator == null)
            {
                return;
            }

            trackView.Size = calculator.CalculateTrackSize(thickness, containerSize, trackPadding);
        }

        /// <summary>
        /// Update ThumbThickness property of the scrollbar.
        /// </summary>
        /// <param name="thickness">The width of the track.</param>
        private void UpdateThumbThickness(float thickness)
        {
            thumbThickness = thickness;

            if (calculator == null)
            {
                return;
            }

            thumbView.Size = calculator.CalculateThumbSize(thickness, trackView.Size);
        }

        /// <summary>
        /// Update TrackPadding property of the scrollbar.
        /// </summary>
        /// <param name="padding">The padding of the track.</param>
        private void UpdateTrackPadding(Extents padding)
        {
            trackPadding = padding == null ? new PaddingType(0, 0, 0, 0) : new PaddingType(padding.Start, padding.End, padding.Top, padding.Bottom);

            if (calculator == null)
            {
                return;
            }

            trackView.Size = calculator.CalculateTrackSize(TrackThickness, containerSize, trackPadding);
            trackView.Position = calculator.CalculateTrackPosition(trackPadding);
            thumbView.Size = calculator.CalculateThumbSize(ThumbThickness, trackView.Size);
            thumbView.Position = calculator.CalculateThumbPaddingPosition(trackView.Size, thumbView.Size, thumbView.Position, trackPadding);
        }
        private void UpdateThumbColor(Color color)
        {
            thumbColor = color;
            if (!String.IsNullOrEmpty(thumbView.ResourceUrl))
            {
                thumbView.Color = color;
                thumbView.BackgroundColor = Color.Transparent;
            }
            else
            {
                thumbView.BackgroundColor = color;
            }
        }

        private void UpdateThumbImage(string url, bool isHorizontal)
        {
            if (isHorizontal)
            {
                thumbHorizontalImageUrl = url;
                if (this.isHorizontal)
                {
                    thumbView.ResourceUrl = url;
                    thumbView.Color = thumbColor;
                    thumbView.BackgroundColor = Color.Transparent;
                }
            }
            else
            {
                thumbVerticalImageUrl = url;
                if (!this.isHorizontal)
                {
                    thumbView.ResourceUrl = url;
                    thumbView.Color = thumbColor;
                    thumbView.BackgroundColor = Color.Transparent;
                }
            }
        }

        private Animation EnsureThumbPositionAnimation()
        {
            if (thumbPositionAnimation == null)
            {
                thumbPositionAnimation = new Animation();
            }
            else
            {
                thumbPositionAnimation.Stop();
                thumbPositionAnimation.Clear();
            }
            return thumbPositionAnimation;
        }

        private Animation EnsureThumbSizeAnimation()
        {
            if (thumbSizeAnimation == null)
            {
                thumbSizeAnimation = new Animation();
            }
            else
            {
                thumbSizeAnimation.Stop();
                thumbSizeAnimation.Clear();
            }
            return thumbSizeAnimation;
        }

        private Animation EnsureOpacityAnimation()
        {
            if (opacityAnimation == null)
            {
                opacityAnimation = new Animation();
            }
            else
            {
                opacityAnimation.Stop();
                opacityAnimation.Clear();
            }
            return opacityAnimation;
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

            public bool IsScrollable()
            {
                return contentLength > visibleLength;
            }

            public abstract Position CalculatorTrackAlign();
            public abstract Position CalculatorThumbAlign();
            public abstract Size CalculateTrackSize(float thickness, Size containerSize, PaddingType trackPadding);
            public abstract Position CalculateTrackPosition(PaddingType trackPadding);
            public abstract Size CalculateThumbSize(float thickness, Size trackSize);
            public abstract Position CalculateThumbPosition(Size trackSize, Size thumbSize, PaddingType trackPadding);
            public abstract Position CalculateThumbPaddingPosition(Size trackSize, Size thumbSize, Position thumbCurrentPosition, PaddingType trackPadding);
            public abstract Position CalculateThumbScrollPosition(Size trackSize, Position thumbCurrentPosition, PaddingType trackPadding);
        }

        private class HorizontalCalculator : Calculator
        {
            public HorizontalCalculator(float contentLength, float visibleLength, float currentPosition) : base(contentLength, visibleLength, currentPosition)
            {
            }

            public override Position CalculatorTrackAlign()
            {
                return Tizen.NUI.ParentOrigin.BottomLeft;
            }

            public override Position CalculatorThumbAlign()
            {
                return Tizen.NUI.ParentOrigin.BottomLeft;
            }

            public override Size CalculateTrackSize(float thickness, Size containerSize, PaddingType trackPadding)
            {
                return new Size(containerSize.Width - trackPadding.Item1 - trackPadding.Item2, thickness);
            }

            public override Position CalculateTrackPosition(PaddingType trackPadding)
            {
                return new Position(trackPadding.Item1, -trackPadding.Item4);
            }

            public override Size CalculateThumbSize(float thickness, Size trackSize)
            {
                return new Size(trackSize.Width * (IsScrollable() ? (visibleLength / contentLength) : 0.0f), thickness);
            }

            public override Position CalculateThumbPosition(Size trackSize, Size thumbSize, PaddingType trackPadding)
            {
                float padding = ((trackSize.Height - thumbSize.Height) / 2.0f) + trackPadding.Item4;
                return new Position(trackPadding.Item1 + (IsScrollable() ? (trackSize.Width * (Math.Min(Math.Max(currentPosition, 0.0f), contentLength - visibleLength)) / contentLength) : 0.0f), -padding);
            }

            public override Position CalculateThumbPaddingPosition(Size trackSize, Size thumbSize, Position thumbCurrentPosition, PaddingType trackPadding)
            {
                float padding = ((trackSize.Height - thumbSize.Height) / 2.0f) + trackPadding.Item4;
                return new Position(thumbCurrentPosition.X, -padding);
            }

            public override Position CalculateThumbScrollPosition(Size trackSize, Position thumbCurrentPosition, PaddingType trackPadding)
            {
                return new Position(trackPadding.Item1 + (IsScrollable() ? (trackSize.Width * (Math.Min(Math.Max(currentPosition, 0.0f), contentLength - visibleLength)) / contentLength) : 0.0f), thumbCurrentPosition.Y);
            }
        }

        private class VerticalCalculator : Calculator
        {
            public VerticalCalculator(float contentLength, float visibleLength, float currentPosition) : base(contentLength, visibleLength, currentPosition)
            {
            }

            public override Position CalculatorTrackAlign()
            {
                return Tizen.NUI.ParentOrigin.TopRight;
            }

            public override Position CalculatorThumbAlign()
            {
                return Tizen.NUI.ParentOrigin.TopRight;
            }

            public override Size CalculateTrackSize(float thickness, Size containerSize, PaddingType trackPadding)
            {
                return new Size(thickness, containerSize.Height - trackPadding.Item3 - trackPadding.Item4);
            }

            public override Position CalculateTrackPosition(PaddingType trackPadding)
            {
                return new Position(-trackPadding.Item2, trackPadding.Item3);
            }

            public override Size CalculateThumbSize(float thickness, Size trackSize)
            {
                return new Size(thickness, trackSize.Height * (IsScrollable() ? (visibleLength / contentLength) : 0.0f));
            }

            public override Position CalculateThumbPosition(Size trackSize, Size thumbSize, PaddingType trackPadding)
            {
                float padding = ((trackSize.Width - thumbSize.Width) / 2.0f) + trackPadding.Item2;
                return new Position(-padding, trackPadding.Item3 + (IsScrollable() ? (trackSize.Height * Math.Min(Math.Max(currentPosition, 0.0f), contentLength - visibleLength) / contentLength) : 0.0f));
            }

            public override Position CalculateThumbPaddingPosition(Size trackSize, Size thumbSize, Position thumbCurrentPosition, PaddingType trackPadding)
            {
                float padding = ((trackSize.Width - thumbSize.Width) / 2.0f) + trackPadding.Item2;
                return new Position(-padding, thumbCurrentPosition.Y);
            }

            public override Position CalculateThumbScrollPosition(Size trackSize, Position thumbPosition, PaddingType trackPadding)
            {
                return new Position(thumbPosition.X, trackPadding.Item3 + (IsScrollable() ? (trackSize.Height * Math.Min(Math.Max(currentPosition, 0.0f), contentLength - visibleLength) / contentLength) : 0.0f));
            }
        }

        #endregion Classes
    }
}
