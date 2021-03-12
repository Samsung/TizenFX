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
using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// The base class for Children attributes in Components.
    /// </summary>
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ViewStyle : BindableObject
    {
        private string styleName;
        private View.States? state;
        private View.States? subState;
        private float? flex;
        private int? alignSelf;
        private Vector4 flexMargin;
        private Vector2 cellIndex;
        private float? rowSpan;
        private float? columnSpan;
        private HorizontalAlignmentType? cellHorizontalAlignment;
        private VerticalAlignmentType? cellVerticalAlignment;
        private View leftFocusableView;
        private View rightFocusableView;
        private View upFocusableView;
        private View downFocusableView;
        private bool? focusable;
        private bool? focusableChildren;
        private bool? focusableInTouch;
        private bool? positionUsesPivotPoint;
        private int? siblingOrder;
        private Position parentOrigin;
        private Position pivotPoint;
        private Position position;
        private Rotation orientation;
        private Vector3 scale;
        private string name;
        private bool? sensitive;
        private bool? leaveRequired;
        private bool? inheritOrientation;
        private bool? inheritScale;
        private DrawModeType? drawMode;
        private Vector3 sizeModeFactor;
        private ResizePolicyType? widthResizePolicy;
        private ResizePolicyType? heightResizePolicy;
        private SizeScalePolicyType? sizeScalePolicy;
        private bool? widthForHeight;
        private bool? heightForWidth;
        private Extents padding;
        private Size2D minimumSize;
        private Size2D maximumSize;
        private bool? inheritPosition;
        private ClippingModeType? clippingMode;
        private Size size;
        private bool? inheritLayoutDirection;
        private ViewLayoutDirectionType? layoutDirection;
        private Extents margin;
        private float? weight;
        private bool? enableControlState;
        private bool? themeChangeSensitive;

        private Selector<ImageShadow> imageShadow;
        private Selector<Shadow> boxShadow;
        private Selector<string> backgroundImageSelector;
        private Selector<float?> cornerRadius;
        private Selector<float?> opacitySelector;
        private Selector<Color> backgroundColorSelector;
        private Selector<Rectangle> backgroundImageBorderSelector;
        private Selector<Color> colorSelector;

        static ViewStyle() {}

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewStyle() { }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewStyle(ViewStyle viewAttributes)
        {
            CopyFrom(viewAttributes);
        }

        /// <summary>
        /// Create an instance and set properties from the given view.
        /// </summary>
        /// <param name="view">The View that includes property data.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewStyle(View view)
        {
            CopyPropertiesFromView(view);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string StyleName
        {
            get => (string)GetValue(StyleNameProperty);
            set => SetValue(StyleNameProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> BackgroundImage
        {
            get
            {
                Selector<string> image = (Selector<string>)GetValue(BackgroundImageSelectorProperty);
                return (null != image) ? image : backgroundImageSelector = new Selector<string>();
            }
            set => SetValue(BackgroundImageSelectorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View.States? State
        {
            get => (View.States?)GetValue(StateProperty);
            set => SetValue(StateProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View.States? SubState
        {
            get => (View.States?)GetValue(SubStateProperty);
            set => SetValue(SubStateProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? Flex
        {
            get => (float?)GetValue(FlexProperty);
            set => SetValue(FlexProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? AlignSelf
        {
            get => (int?)GetValue(AlignSelfProperty);
            set => SetValue(AlignSelfProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 FlexMargin
        {
            get => (Vector4)GetValue(FlexMarginProperty);
            set => SetValue(FlexMarginProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 CellIndex
        {
            get => (Vector2)GetValue(CellIndexProperty);
            set => SetValue(CellIndexProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? RowSpan
        {
            get => (float?)GetValue(RowSpanProperty);
            set => SetValue(RowSpanProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ColumnSpan
        {
            get => (float?)GetValue(ColumnSpanProperty);
            set => SetValue(ColumnSpanProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HorizontalAlignmentType? CellHorizontalAlignment
        {
            get => (HorizontalAlignmentType?)GetValue(CellHorizontalAlignmentProperty);
            set => SetValue(CellHorizontalAlignmentProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalAlignmentType? CellVerticalAlignment
        {
            get => (VerticalAlignmentType?)GetValue(CellVerticalAlignmentProperty);
            set => SetValue(CellVerticalAlignmentProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View LeftFocusableView
        {
            get => (View)GetValue(LeftFocusableViewProperty);
            set => SetValue(LeftFocusableViewProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View RightFocusableView
        {
            get => (View)GetValue(RightFocusableViewProperty);
            set => SetValue(RightFocusableViewProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View UpFocusableView
        {
            get => (View)GetValue(UpFocusableViewProperty);
            set => SetValue(UpFocusableViewProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View DownFocusableView
        {
            get => (View)GetValue(DownFocusableViewProperty);
            set => SetValue(DownFocusableViewProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Focusable
        {
            get => (bool?)GetValue(FocusableProperty);
            set => SetValue(FocusableProperty, value);
        }

        /// <summary>
        /// Whether the children of this view can be focusable by keyboard navigation. If user sets this to false, the children of this view will not be focused.
        /// Note : Default value is true.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? FocusableChildren
        {
            get => (bool?)GetValue(FocusableChildrenProperty);
            set => SetValue(FocusableChildrenProperty, value);
        }

        /// <summary>
        /// Whether this view can focus by touch.
        /// If Focusable is false, FocusableInTouch is disabled.
        /// If you want to have focus on touch, you need to set both Focusable and FocusableInTouch settings to true.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? FocusableInTouch
        {
            get => (bool?)GetValue(FocusableInTouchProperty);
            set => SetValue(FocusableInTouchProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D Size2D
        {
            get => (Size2D)GetValue(Size2DProperty);
            set => SetValue(Size2DProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<float?> Opacity
        {
            get
            {
                Selector<float?> opacity = (Selector<float?>)GetValue(OpacitySelectorProperty);
                return (null != opacity) ? opacity : opacitySelector = new Selector<float?>();
            }
            set => SetValue(OpacitySelectorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position2D Position2D
        {
            get => (Position2D)GetValue(Position2DProperty);
            set => SetValue(Position2DProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? PositionUsesPivotPoint
        {
            get => (bool?)GetValue(PositionUsesPivotPointProperty);
            set => SetValue(PositionUsesPivotPointProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? SiblingOrder
        {
            get => (int?)GetValue(SiblingOrderProperty);
            set => SetValue(SiblingOrderProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position ParentOrigin
        {
            get => (Position)GetValue(ParentOriginProperty);
            set => SetValue(ParentOriginProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position PivotPoint
        {
            get => (Position)GetValue(PivotPointProperty);
            set => SetValue(PivotPointProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? SizeWidth
        {
            get => (float?)GetValue(SizeWidthProperty);
            set => SetValue(SizeWidthProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? SizeHeight
        {
            get => (float?)GetValue(SizeHeightProperty);
            set => SetValue(SizeHeightProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position Position
        {
            get => (Position)GetValue(PositionProperty);
            set => SetValue(PositionProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PositionX
        {
            get => (float?)GetValue(PositionXProperty);
            set => SetValue(PositionXProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PositionY
        {
            get => (float?)GetValue(PositionYProperty);
            set => SetValue(PositionYProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PositionZ
        {
            get => (float?)GetValue(PositionZProperty);
            set => SetValue(PositionZProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rotation Orientation
        {
            get => (Rotation)GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 Scale
        {
            get => (Vector3)GetValue(ScaleProperty);
            set => SetValue(ScaleProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScaleX
        {
            get => (float?)GetValue(ScaleXProperty);
            set => SetValue(ScaleXProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScaleY
        {
            get => (float?)GetValue(ScaleYProperty);
            set => SetValue(ScaleYProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScaleZ
        {
            get => (float?)GetValue(ScaleZProperty);
            set => SetValue(ScaleZProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name
        {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Sensitive
        {
            get => (bool?)GetValue(SensitiveProperty);
            set => SetValue(SensitiveProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? LeaveRequired
        {
            get => (bool?)GetValue(LeaveRequiredProperty);
            set => SetValue(LeaveRequiredProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? InheritOrientation
        {
            get => (bool?)GetValue(InheritOrientationProperty);
            set => SetValue(InheritOrientationProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? InheritScale
        {
            get => (bool?)GetValue(InheritScaleProperty);
            set => SetValue(InheritScaleProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DrawModeType? DrawMode
        {
            get => (DrawModeType?)GetValue(DrawModeProperty);
            set => SetValue(DrawModeProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 SizeModeFactor
        {
            get => (Vector3)GetValue(SizeModeFactorProperty);
            set => SetValue(SizeModeFactorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResizePolicyType? WidthResizePolicy
        {
            get => (ResizePolicyType?)GetValue(WidthResizePolicyProperty);
            set => SetValue(WidthResizePolicyProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResizePolicyType? HeightResizePolicy
        {
            get => (ResizePolicyType?)GetValue(HeightResizePolicyProperty);
            set => SetValue(HeightResizePolicyProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SizeScalePolicyType? SizeScalePolicy
        {
            get => (SizeScalePolicyType?)GetValue(SizeScalePolicyProperty);
            set => SetValue(SizeScalePolicyProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? WidthForHeight
        {
            get => (bool?)GetValue(WidthForHeightProperty);
            set => SetValue(WidthForHeightProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? HeightForWidth
        {
            get => (bool?)GetValue(HeightForWidthProperty);
            set => SetValue(HeightForWidthProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents Padding
        {
            get
            {
                Extents tmp = (Extents)GetValue(PaddingProperty);
                return (null != tmp) ? tmp : padding = new Extents(OnPaddingChanged, 0, 0, 0, 0);
            }
            set => SetValue(PaddingProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D MinimumSize
        {
            get => (Size2D)GetValue(MinimumSizeProperty);
            set => SetValue(MinimumSizeProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D MaximumSize
        {
            get => (Size2D)GetValue(MaximumSizeProperty);
            set => SetValue(MaximumSizeProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? InheritPosition
        {
            get => (bool?)GetValue(InheritPositionProperty);
            set => SetValue(InheritPositionProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ClippingModeType? ClippingMode
        {
            get => (ClippingModeType?)GetValue(ClippingModeProperty);
            set => SetValue(ClippingModeProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size Size
        {
            get
            {
                Size tmp = (Size)GetValue(SizeProperty);
                return (null != tmp) ? tmp : size = new Size((float? width, float? height, float? depth) =>
                    {
                        float targetWidth = 0;
                        float targetHeight = 0;
                        float targetDepth = 0;

                        if (size != null)
                        {
                            targetWidth = size.Width;
                            targetHeight = size.Height;
                            targetDepth = size.Depth;
                        }
                        if (width != null) { targetWidth = (float)width; }
                        if (height != null) { targetHeight = (float)height; }
                        if (depth != null) { targetDepth = (float)depth; }

                        Size = new Size(targetWidth, targetHeight, targetDepth);
                    }, 0, 0, 0);
            }
            set => SetValue(SizeProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? InheritLayoutDirection
        {
            get => (bool?)GetValue(InheritLayoutDirectionProperty);
            set => SetValue(InheritLayoutDirectionProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewLayoutDirectionType? LayoutDirection
        {
            get => (ViewLayoutDirectionType?)GetValue(LayoutDirectionProperty);
            set => SetValue(LayoutDirectionProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents Margin
        {
            get
            {
                Extents tmp = (Extents)GetValue(MarginProperty);
                return (null != tmp) ? tmp : margin = new Extents(OnMarginChanged, 0, 0, 0, 0);
            }
            set => SetValue(MarginProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? Weight
        {
            get => (float?)GetValue(WeightProperty);
            set => SetValue(WeightProperty, value);
        }

        /// <summary> View BackgroundColor </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Color> BackgroundColor
        {
            get
            {
                Selector<Color> color = (Selector<Color>)GetValue(BackgroundColorSelectorProperty);
                return (null != color) ? color : backgroundColorSelector = new Selector<Color>();
            }
            set => SetValue(BackgroundColorSelectorProperty, value);
        }

        /// <summary>
        /// Color
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Color> Color
        {
            get
            {
                Selector<Color> color = (Selector<Color>)GetValue(ColorSelectorProperty);
                return (null != color) ? color : colorSelector = new Selector<Color>();
            }
            set => SetValue(ColorSelectorProperty, value);
        }

        /// <summary>View BackgroundBorder</summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Rectangle> BackgroundImageBorder
        {
            get
            {
                Selector<Rectangle> border = (Selector<Rectangle>)GetValue(BackgroundImageBorderSelectorProperty);
                return (null != border) ? border : backgroundImageBorderSelector = new Selector<Rectangle>();
            }
            set => SetValue(BackgroundImageBorderSelectorProperty, value);
        }

        /// <summary>
        /// Describes a shadow as an image for a View.
        /// It is null by default.
        /// </summary>
        /// <remarks>
        /// If BoxShadow is not null, the ImageShadow value will be ignored.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<ImageShadow> ImageShadow
        {
            get => (Selector<ImageShadow>)GetValue(ImageShadowSelectorProperty);
            set => SetValue(ImageShadowSelectorProperty, value);
        }

        /// <summary>
        /// Describes a box shaped shadow drawing for a View.
        /// It is null by default.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Shadow> BoxShadow
        {
            get => (Selector<Shadow>)GetValue(BoxShadowSelectorProperty);
            set => SetValue(BoxShadowSelectorProperty, value);
        }

        /// <summary>
        /// The radius for the rounded corners of the View
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<float?> CornerRadius
        {
            get => (Selector<float?>)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        /// <summary>
        /// The EnableControlState value of the View.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableControlState
        {
            get => (bool?)GetValue(EnableControlStateProperty);
            set => SetValue(EnableControlStateProperty, value);
        }

        /// <summary>
        /// The ThemeChangeSensitive value of the View.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? ThemeChangeSensitive
        {
            get => (bool?)GetValue(ThemeChangeSensitiveProperty);
            set => SetValue(ThemeChangeSensitiveProperty, value);
        }


        /// <summary>
        /// Allow null properties when merging it into other Theme.
        /// If the value is true, the null properties reset target properties of the other ViewStyle with same key when merge.
        /// It is used in <seealso cref="Theme.Merge(string)"/>, <seealso cref="Theme.Merge(Theme)"/>.
        /// It is also used in <seealso cref="Theme.GetStyle(string)"/> when the Theme has a parent and needs to merge.
        /// Please note that it is false by default.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SolidNull { get; set; } = false;

        /// <summary>
        /// Set style's bindable properties from the view.
        /// </summary>
        /// <param name="view">The view that includes property data.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void CopyPropertiesFromView(View view)
        {
            if (view == null) return;

            BindableProperty.GetBindablePropertysOfType(GetType(), out var styleProperties);            
            BindableProperty.GetBindablePropertysOfType(view.GetType(), out var viewProperties);
            

            if (styleProperties == null || viewProperties == null) return;

            foreach (var stylePropertyItem in styleProperties)
            {
                viewProperties.TryGetValue(stylePropertyItem.Key, out var viewProperty);

                if (viewProperty == null) continue;

                SetValue(stylePropertyItem.Value, view.GetValue(viewProperty));
            }
        }

        /// <summary>Create a cloned ViewStyle.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewStyle Clone()
        {
            var cloned = CreateInstance();
            cloned.CopyFrom(this);

            return cloned;
        }

        /// <summary>Create a cloned ViewStyle.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Merge(ViewStyle other)
        {
            AllowNullCopy = other?.SolidNull ?? false;
            CopyFrom(other);
            AllowNullCopy = false;
        }

        internal ViewStyle CreateInstance()
        {
            return (ViewStyle)Activator.CreateInstance(GetType());
        }

        private void OnPaddingChanged(ushort start, ushort end, ushort top, ushort bottom)
        {
            Padding = new Extents(start, end, top, bottom);
        }

        private void OnMarginChanged(ushort start, ushort end, ushort top, ushort bottom)
        {
            Margin = new Extents(start, end, top, bottom);
        }
    }
}
