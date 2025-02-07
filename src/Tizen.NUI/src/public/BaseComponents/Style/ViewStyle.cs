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
using System.Collections.Generic;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// The base class of style attributes for a view.
    /// This class provides a base for defining styles that can be applied to views.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public partial class ViewStyle : BindableObject, IDisposable
    {
        private bool disposed = false;
        private bool? focusable;
        private bool? focusableChildren;
        private bool? focusableInTouch;
        private bool? positionUsesPivotPoint;
        private Position parentOrigin;
        private Position pivotPoint;
        private Position position;
        private Rotation orientation;
        private DrawModeType? drawMode;
        private Vector3 sizeModeFactor;
        private ResizePolicyType? widthResizePolicy;
        private ResizePolicyType? heightResizePolicy;
        private bool? widthForHeight;
        private bool? heightForWidth;
        private Extents padding;
        private Size2D minimumSize;
        private Size2D maximumSize;
        private ClippingModeType? clippingMode;
        private Size size;
        private Extents margin;
        private bool? themeChangeSensitive;
        private Vector4 cornerRadius;
        private float? borderlineWidth;
        private Color borderlineColor;
        private float? borderlineOffset;
        private bool? isEnabled;

        private Selector<ImageShadow> imageShadow;
        private Selector<Shadow> boxShadow;
        private Selector<string> backgroundImageSelector;
        private Selector<float?> opacitySelector;
        private Selector<Color> backgroundColorSelector;
        private Selector<Rectangle> backgroundImageBorderSelector;
        private Selector<Color> colorSelector;
        private VisualTransformPolicyType? cornerRadiusPolicy;
        private Selector<Color> borderlineColorSelector;

        static ViewStyle()
        {
            if (NUIApplication.IsUsingXaml)
            {
                BackgroundImageProperty = BindableProperty.Create(nameof(BackgroundImage), typeof(Selector<string>), typeof(ViewStyle), null,
                    propertyChanged: SetInternalBackgroundImageProperty, defaultValueCreator: GetInternalBackgroundImageProperty);
                FocusableProperty = BindableProperty.Create(nameof(Focusable), typeof(bool?), typeof(ViewStyle), null,
                    propertyChanged: SetInternalFocusableProperty, defaultValueCreator: GetInternalFocusableProperty);
                FocusableChildrenProperty = BindableProperty.Create(nameof(FocusableChildren), typeof(bool?), typeof(ViewStyle), true,
                    propertyChanged: SetInternalFocusableChildrenProperty, defaultValueCreator: GetInternalFocusableChildrenProperty);
                FocusableInTouchProperty = BindableProperty.Create(nameof(FocusableInTouch), typeof(bool?), typeof(ViewStyle), null,
                    propertyChanged: SetInternalFocusableInTouchProperty, defaultValueCreator: GetInternalFocusableInTouchProperty);
                Size2DProperty = BindableProperty.Create(nameof(Size2D), typeof(Size2D), typeof(ViewStyle), null,
                    propertyChanged: SetInternalSize2DProperty, defaultValueCreator: GetInternalSize2DProperty);
                OpacityProperty = BindableProperty.Create(nameof(Opacity), typeof(Selector<float?>), typeof(ViewStyle), null,
                    propertyChanged: SetInternalOpacityProperty, defaultValueCreator: GetInternalOpacityProperty);
                Position2DProperty = BindableProperty.Create(nameof(Position2D), typeof(Position2D), typeof(ViewStyle), null, 
                    propertyChanged: SetInternalPosition2DProperty, defaultValueCreator: GetInternalPosition2DProperty);
                PositionUsesPivotPointProperty = BindableProperty.Create(nameof(PositionUsesPivotPoint), typeof(bool?), typeof(ViewStyle), null,
                    propertyChanged: SetInternalPositionUsesPivotPointProperty, defaultValueCreator: GetInternalPositionUsesPivotPointProperty);
                ParentOriginProperty = BindableProperty.Create(nameof(ParentOrigin), typeof(Position), typeof(ViewStyle), null,
                    propertyChanged: SetInternalParentOriginProperty, defaultValueCreator: GetInternalParentOriginProperty);
                PivotPointProperty = BindableProperty.Create(nameof(PivotPoint), typeof(Position), typeof(ViewStyle), null,
                    propertyChanged: SetInternalPivotPointProperty, defaultValueCreator: GetInternalPivotPointProperty);
                SizeWidthProperty = BindableProperty.Create(nameof(SizeWidth), typeof(float?), typeof(ViewStyle), null,
                    propertyChanged: SetInternalSizeWidthProperty, defaultValueCreator: GetInternalSizeWidthProperty);
                SizeHeightProperty = BindableProperty.Create(nameof(SizeHeight), typeof(float?), typeof(ViewStyle), null,
                    propertyChanged: SetInternalSizeHeightProperty, defaultValueCreator: GetInternalSizeHeightProperty);
                PositionProperty = BindableProperty.Create(nameof(Position), typeof(Position), typeof(ViewStyle), null,
                    propertyChanged: SetInternalPositionProperty, defaultValueCreator: GetInternalPositionProperty);
                PositionXProperty = BindableProperty.Create(nameof(PositionX), typeof(float?), typeof(ViewStyle), null,
                    propertyChanged: SetInternalPositionXProperty, defaultValueCreator: GetInternalPositionXProperty);
                PositionYProperty = BindableProperty.Create(nameof(PositionY), typeof(float?), typeof(ViewStyle), null,
                    propertyChanged: SetInternalPositionYProperty, defaultValueCreator: GetInternalPositionYProperty);
                OrientationProperty = BindableProperty.Create(nameof(Orientation), typeof(Rotation), typeof(ViewStyle), null,
                    propertyChanged: SetInternalOrientationProperty, defaultValueCreator: GetInternalOrientationProperty);
                DrawModeProperty = BindableProperty.Create(nameof(DrawMode), typeof(DrawModeType?), typeof(ViewStyle), null,
                    propertyChanged: SetInternalDrawModeProperty, defaultValueCreator: GetInternalDrawModeProperty);
                SizeModeFactorProperty = BindableProperty.Create(nameof(SizeModeFactor), typeof(Vector3), typeof(ViewStyle), null,
                    propertyChanged: SetInternalSizeModeFactorProperty, defaultValueCreator: GetInternalSizeModeFactorProperty);
                WidthResizePolicyProperty = BindableProperty.Create(nameof(WidthResizePolicy), typeof(ResizePolicyType?), typeof(ViewStyle), null,
                    propertyChanged: SetInternalWidthResizePolicyProperty, defaultValueCreator: GetInternalWidthResizePolicyProperty);
                HeightResizePolicyProperty = BindableProperty.Create(nameof(HeightResizePolicy), typeof(ResizePolicyType?), typeof(ViewStyle), null,
                    propertyChanged: SetInternalHeightResizePolicyProperty, defaultValueCreator: GetInternalHeightResizePolicyProperty);
                WidthForHeightProperty = BindableProperty.Create(nameof(WidthForHeight), typeof(bool?), typeof(ViewStyle), null,
                    propertyChanged: SetInternalWidthForHeightProperty, defaultValueCreator: GetInternalWidthForHeightProperty);
                HeightForWidthProperty = BindableProperty.Create(nameof(HeightForWidth), typeof(bool?), typeof(ViewStyle), null,
                    propertyChanged: SetInternalHeightForWidthProperty, defaultValueCreator: GetInternalHeightForWidthProperty);
                PaddingProperty = BindableProperty.Create(nameof(Padding), typeof(Extents), typeof(ViewStyle), null,
                    propertyChanged: SetInternalPaddingProperty, defaultValueCreator: GetInternalPaddingProperty);
                MinimumSizeProperty = BindableProperty.Create(nameof(MinimumSize), typeof(Size2D), typeof(ViewStyle), null,
                    propertyChanged: SetInternalMinimumSizeProperty, defaultValueCreator: GetInternalMinimumSizeProperty);
                MaximumSizeProperty = BindableProperty.Create(nameof(MaximumSize), typeof(Size2D), typeof(ViewStyle), null,
                    propertyChanged: SetInternalMaximumSizeProperty, defaultValueCreator: GetInternalMaximumSizeProperty);
                ClippingModeProperty = BindableProperty.Create(nameof(ClippingMode), typeof(ClippingModeType?), typeof(ViewStyle), null,
                    propertyChanged: SetInternalClippingModeProperty, defaultValueCreator: GetInternalClippingModeProperty);
                SizeProperty = BindableProperty.Create(nameof(Size), typeof(Size), typeof(ViewStyle), null,
                    propertyChanged: SetInternalSizeProperty, defaultValueCreator: GetInternalSizeProperty);
                MarginProperty = BindableProperty.Create(nameof(Margin), typeof(Extents), typeof(ViewStyle), null,
                    propertyChanged: SetInternalMarginProperty, defaultValueCreator: GetInternalMarginProperty);
                BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Selector<Color>), typeof(ViewStyle), null,
                    propertyChanged: SetInternalBackgroundColorProperty, defaultValueCreator: GetInternalBackgroundColorProperty);
                ColorProperty = BindableProperty.Create(nameof(Color), typeof(Selector<Color>), typeof(ViewStyle), null,
                    propertyChanged: SetInternalColorProperty, defaultValueCreator: GetInternalColorProperty);
                BackgroundImageBorderProperty = BindableProperty.Create(nameof(BackgroundImageBorder), typeof(Selector<Rectangle>), typeof(ViewStyle), null,
                    propertyChanged: SetInternalBackgroundImageBorderProperty, defaultValueCreator: GetInternalBackgroundImageBorderProperty);
                ImageShadowProperty = BindableProperty.Create(nameof(ImageShadow), typeof(Selector<ImageShadow>), typeof(ViewStyle), null,
                    propertyChanged: SetInternalImageShadowProperty, defaultValueCreator: GetInternalImageShadowProperty);
                BoxShadowProperty = BindableProperty.Create(nameof(BoxShadow), typeof(Selector<Shadow>), typeof(ViewStyle), null,
                    propertyChanged: SetInternalBoxShadowProperty, defaultValueCreator: GetInternalBoxShadowProperty);
                CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(Vector4), typeof(ViewStyle), null,
                    propertyChanged: SetInternalCornerRadiusProperty, defaultValueCreator: GetInternalCornerRadiusProperty);
                CornerRadiusPolicyProperty = BindableProperty.Create(nameof(CornerRadiusPolicy), typeof(VisualTransformPolicyType?), typeof(ViewStyle), null,
                    propertyChanged: SetInternalCornerRadiusPolicyProperty, defaultValueCreator: GetInternalCornerRadiusPolicyProperty);
                BorderlineWidthProperty = BindableProperty.Create(nameof(BorderlineWidth), typeof(float?), typeof(ViewStyle), null,
                    propertyChanged: SetInternalBorderlineWidthProperty, defaultValueCreator: GetInternalBorderlineWidthProperty);
                BorderlineColorProperty = BindableProperty.Create(nameof(BorderlineColor), typeof(Color), typeof(ViewStyle), null,
                    propertyChanged: SetInternalBorderlineColorProperty, defaultValueCreator: GetInternalBorderlineColorProperty);
                BorderlineColorSelectorProperty = BindableProperty.Create(nameof(BorderlineColorSelector), typeof(Selector<Color>), typeof(ViewStyle), null,
                    propertyChanged: SetInternalBorderlineColorSelectorProperty, defaultValueCreator: GetInternalBorderlineColorSelectorProperty);
                BorderlineOffsetProperty = BindableProperty.Create(nameof(BorderlineOffset), typeof(float?), typeof(ViewStyle), null,
                    propertyChanged: SetInternalBorderlineOffsetProperty, defaultValueCreator: GetInternalBorderlineOffsetProperty);
                ThemeChangeSensitiveProperty = BindableProperty.Create(nameof(ThemeChangeSensitive), typeof(bool?), typeof(ViewStyle), null,
                    propertyChanged: SetInternalThemeChangeSensitiveProperty, defaultValueCreator: GetInternalThemeChangeSensitiveProperty);
                IsEnabledProperty = BindableProperty.Create(nameof(IsEnabled), typeof(bool?), typeof(ViewStyle), null,
                    propertyChanged: SetInternalIsEnabledProperty, defaultValueCreator: GetInternalIsEnabledProperty);
            }
        }

        /// <summary>
        /// Create an empty style instance.
        /// This constructor initializes an empty style object for a view.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public ViewStyle() { }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewStyle(ViewStyle viewAttributes)
        {
            CopyFrom(viewAttributes);
        }

        /// <summary>
        /// The flag that is used when creating a component with this style.
        /// If the value is true, it will include default component style defined in the default theme.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IncludeDefaultStyle { get; set; } = false;

        /// <summary>
        /// Gets or sets the image resource url of the background of view.
        /// The mutually exclusive with "BackgroundColor". Setting it overwrites existing "BackgroundColor".
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Selector<string> BackgroundImage
        {
            get
            {
                Selector<string> image = null;
                if (NUIApplication.IsUsingXaml)
                {
                    image = (Selector<string>)GetValue(BackgroundImageProperty);
                }
                else
                {
                    image = (Selector<string>)GetInternalBackgroundImageProperty(this);
                }
                return (null != image) ? image : backgroundImageSelector = new Selector<string>();
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BackgroundImageProperty, value);
                }
                else
                {
                    SetInternalBackgroundImageProperty(this, null, value);
                }
            }
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Focusable
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(FocusableProperty);
                }
                else
                {
                    return (bool?)GetInternalFocusableProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FocusableProperty, value);
                }
                else
                {
                    SetInternalFocusableProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Whether the children of this view can be focusable by keyboard navigation. If user sets this to false, the children of this view will not be focused.
        /// Note : Default value is true.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? FocusableChildren
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(FocusableChildrenProperty);
                }
                else
                {
                    return (bool?)GetInternalFocusableChildrenProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FocusableChildrenProperty, value);
                }
                else
                {
                    SetInternalFocusableChildrenProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Whether this view can focus by touch.
        /// If Focusable is false, FocusableInTouch is disabled.
        /// If you want to have focus on touch, you need to set both Focusable and FocusableInTouch settings to true.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? FocusableInTouch
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(FocusableInTouchProperty);
                }
                else
                {
                    return (bool?)GetInternalFocusableInTouchProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FocusableInTouchProperty, value);
                }
                else
                {
                    SetInternalFocusableInTouchProperty(this, null, value);
                }
            }
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [Obsolete("This has been deprecated. Use Size instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D Size2D
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Size2D)GetValue(Size2DProperty);
                }
                else
                {
                    return (Size2D)GetInternalSize2DProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(Size2DProperty, value);
                }
                else
                {
                    SetInternalSize2DProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Defines view's opacity value.
        /// This property allows you to specify different opacity values for various states of the view,
        /// such as normal, pressed, focused, etc.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Selector<float?> Opacity
        {
            get
            {
                Selector<float?> opacity = null;
                if (NUIApplication.IsUsingXaml)
                {
                    opacity = (Selector<float?>)GetValue(OpacityProperty);
                }
                else
                {
                    opacity = (Selector<float?>)GetInternalOpacityProperty(this);
                }
                return (null != opacity) ? opacity : opacitySelector = new Selector<float?>();
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(OpacityProperty, value);
                }
                else
                {
                    SetInternalOpacityProperty(this, null, value);
                }
            }
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [Obsolete("This has been deprecated. Use Position instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position2D Position2D
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Position2D)GetValue(Position2DProperty);
                }
                else
                {
                    return (Position2D)GetInternalPosition2DProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(Position2DProperty, value);
                }
                else
                {
                    SetInternalPosition2DProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Determines whether the pivot point should be used to determine the position of the view.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public bool? PositionUsesPivotPoint
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(PositionUsesPivotPointProperty);
                }
                else
                {
                    return (bool?)GetInternalPositionUsesPivotPointProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PositionUsesPivotPointProperty, value);
                }
                else
                {
                    SetInternalPositionUsesPivotPointProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the origin of a view within its parent's area.<br />
        /// This is expressed in unit coordinates, such that (0.0, 0.0, 0.5) is the top-left corner of the parent, and (1.0, 1.0, 0.5) is the bottom-right corner.<br />
        /// The default parent-origin is ParentOrigin.TopLeft (0.0, 0.0, 0.5).<br />
        /// A view's position is the distance between this origin and the view's anchor-point.<br />
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Position ParentOrigin
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Position)GetValue(ParentOriginProperty);
                }
                else
                {
                    return (Position)GetInternalParentOriginProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ParentOriginProperty, value);
                }
                else
                {
                    SetInternalParentOriginProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the pivot point of a view.<br />
        /// This is expressed in unit coordinates, such that (0.0, 0.0, 0.5) is the top-left corner of the view, and (1.0, 1.0, 0.5) is the bottom-right corner.<br />
        /// The default pivot point is PivotPoint.Center (0.5, 0.5, 0.5).<br />
        /// A view position is the distance between its parent origin and this pivot point.<br />
        /// A view's orientation is the rotation from its default orientation, the rotation is centered around its pivot point.<br />
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Position PivotPoint
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Position)GetValue(PivotPointProperty);
                }
                else
                {
                    return (Position)GetInternalPivotPointProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PivotPointProperty, value);
                }
                else
                {
                    SetInternalPivotPointProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the width of the view.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public float? SizeWidth
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(SizeWidthProperty);
                }
                else
                {
                    return (float?)GetInternalSizeWidthProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SizeWidthProperty, value);
                }
                else
                {
                    SetInternalSizeWidthProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the height of the view.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public float? SizeHeight
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(SizeHeightProperty);
                }
                else
                {
                    return (float?)GetInternalSizeHeightProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SizeHeightProperty, value);
                }
                else
                {
                    SetInternalSizeHeightProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the position of the view.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Position Position
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Position)GetValue(PositionProperty);
                }
                else
                {
                    return (Position)GetInternalPositionProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PositionProperty, value);
                }
                else
                {
                    SetInternalPositionProperty(this, null, value);
                }
            }
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PositionX
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(PositionXProperty);
                }
                else
                {
                    return (float?)GetInternalPositionXProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PositionXProperty, value);
                }
                else
                {
                    SetInternalPositionXProperty(this, null, value);
                }
            }
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PositionY
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(PositionYProperty);
                }
                else
                {
                    return (float?)GetInternalPositionYProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PositionYProperty, value);
                }
                else
                {
                    SetInternalPositionYProperty(this, null, value);
                }
            }
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rotation Orientation
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Rotation)GetValue(OrientationProperty);
                }
                else
                {
                    return (Rotation)GetInternalOrientationProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(OrientationProperty, value);
                }
                else
                {
                    SetInternalOrientationProperty(this, null, value);
                }
            }
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DrawModeType? DrawMode
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (DrawModeType?)GetValue(DrawModeProperty);
                }
                else
                {
                    return (DrawModeType?)GetInternalDrawModeProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(DrawModeProperty, value);
                }
                else
                {
                    SetInternalDrawModeProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the relative to parent size factor of the view.<br />
        /// This factor is only used when ResizePolicyType is set to either: ResizePolicyType.SizeRelativeToParent or ResizePolicyType.SizeFixedOffsetFromParent.<br />
        /// This view's size is set to the view's size multiplied by or added to this factor, depending on ResizePolicyType.<br />
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Vector3 SizeModeFactor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector3)GetValue(SizeModeFactorProperty);
                }
                else
                {
                    return (Vector3)GetInternalSizeModeFactorProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SizeModeFactorProperty, value);
                }
                else
                {
                    SetInternalSizeModeFactorProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the width resize policy to be used.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public ResizePolicyType? WidthResizePolicy
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (ResizePolicyType?)GetValue(WidthResizePolicyProperty);
                }
                else
                {
                    return (ResizePolicyType?)GetInternalWidthResizePolicyProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(WidthResizePolicyProperty, value);
                }
                else
                {
                    SetInternalWidthResizePolicyProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the height resize policy to be used.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public ResizePolicyType? HeightResizePolicy
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (ResizePolicyType?)GetValue(HeightResizePolicyProperty);
                }
                else
                {
                    return (ResizePolicyType?)GetInternalHeightResizePolicyProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(HeightResizePolicyProperty, value);
                }
                else
                {
                    SetInternalHeightResizePolicyProperty(this, null, value);
                }
            }
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? WidthForHeight
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(WidthForHeightProperty);
                }
                else
                {
                    return (bool?)GetInternalWidthForHeightProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(WidthForHeightProperty, value);
                }
                else
                {
                    SetInternalWidthForHeightProperty(this, null, value);
                }
            }
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? HeightForWidth
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(HeightForWidthProperty);
                }
                else
                {
                    return (bool?)GetInternalHeightForWidthProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(HeightForWidthProperty, value);
                }
                else
                {
                    SetInternalHeightForWidthProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the padding for use in layout.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Extents Padding
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Extents)GetValue(PaddingProperty) ?? (padding = new Extents());
                }
                else
                {
                    return (Extents)GetInternalPaddingProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PaddingProperty, value);
                }
                else
                {
                    SetInternalPaddingProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the minimum size the view can be assigned in size negotiation.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Size2D MinimumSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Size2D)GetValue(MinimumSizeProperty);
                }
                else
                {
                    return (Size2D)GetInternalMinimumSizeProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(MinimumSizeProperty, value);
                }
                else
                {
                    SetInternalMinimumSizeProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum size the view can be assigned in size negotiation.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Size2D MaximumSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Size2D)GetValue(MaximumSizeProperty);
                }
                else
                {
                    return (Size2D)GetInternalMaximumSizeProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(MaximumSizeProperty, value);
                }
                else
                {
                    SetInternalMaximumSizeProperty(this, null, value);
                }
            }
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ClippingModeType? ClippingMode
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (ClippingModeType?)GetValue(ClippingModeProperty);
                }
                else
                {
                    return (ClippingModeType?)GetInternalClippingModeProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ClippingModeProperty, value);
                }
                else
                {
                    SetInternalClippingModeProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Sets the size of a view for the width, the height, and the depth.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Size Size
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Size)GetValue(SizeProperty);
                }
                else
                {
                    return (Size)GetInternalSizeProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SizeProperty, value);
                }
                else
                {
                    SetInternalSizeProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the Margin for use in layout.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Extents Margin
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Extents)GetValue(MarginProperty) ?? (margin = new Extents());
                }
                else
                {
                    return (Extents)GetInternalMarginProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(MarginProperty, value);
                }
                else
                {
                    SetInternalMarginProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the background of view.
        /// The mutually exclusive with "BackgroundImage". Setting it overwrites existing "BackgroundImage".
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Selector<Color> BackgroundColor
        {
            get
            {
                Selector<Color> color = null;
                if (NUIApplication.IsUsingXaml)
                {
                    color = (Selector<Color>)GetValue(BackgroundColorProperty);
                }
                else
                {
                    color = (Selector<Color>)GetInternalBackgroundColorProperty(this);
                }
                return (null != color) ? color : backgroundColorSelector = new Selector<Color>();
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BackgroundColorProperty, value);
                }
                else
                {
                    SetInternalBackgroundColorProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Color
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Color> Color
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Selector<Color>)GetValue(ColorProperty) ?? (colorSelector = new Selector<Color>());
                }
                else
                {
                    return (Selector<Color>)GetInternalColorProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ColorProperty, value);
                }
                else
                {
                    SetInternalColorProperty(this, null, value);
                }
            }
        }

        /// <summary>View BackgroundBorder</summary>
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Rectangle> BackgroundImageBorder
        {
            get
            {
                Selector<Rectangle> border = null;
                if (NUIApplication.IsUsingXaml)
                {
                    border = (Selector<Rectangle>)GetValue(BackgroundImageBorderProperty);
                }
                else
                {
                    border = (Selector<Rectangle>)GetInternalBackgroundImageBorderProperty(this);
                }
                return (null != border) ? border : backgroundImageBorderSelector = new Selector<Rectangle>();
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BackgroundImageBorderProperty, value);
                }
                else
                {
                    SetInternalBackgroundImageBorderProperty(this, null, value);
                }
            }
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
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Selector<ImageShadow>)GetValue(ImageShadowProperty);
                }
                else
                {
                    return (Selector<ImageShadow>)GetInternalImageShadowProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ImageShadowProperty, value);
                }
                else
                {
                    SetInternalImageShadowProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Describes a box shaped shadow drawing for a View.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Selector<Shadow> BoxShadow
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Selector<Shadow>)GetValue(BoxShadowProperty);
                }
                else
                {
                    return (Selector<Shadow>)GetInternalBoxShadowProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BoxShadowProperty, value);
                }
                else
                {
                    SetInternalBoxShadowProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The radius for the rounded corners of the View.
        /// The values in Vector4 are used in clockwise order from top-left to bottom-left : Vector4(top-left-corner, top-right-corner, bottom-right-corner, bottom-left-corner).
        /// Each radius will clamp internally to the half of smaller of the view's width or height.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Vector4 CornerRadius
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector4)GetValue(CornerRadiusProperty);
                }
                else
                {
                    return (Vector4)GetInternalCornerRadiusProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CornerRadiusProperty, value);
                }
                else
                {
                    SetInternalCornerRadiusProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Whether the CornerRadius property value is relative (percentage [0.0f to 0.5f] of the view size) or absolute (in world units).
        /// It is absolute by default.
        /// When the policy is relative, the corner radius is relative to the smaller of the view's width and height.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public VisualTransformPolicyType? CornerRadiusPolicy
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (VisualTransformPolicyType?)GetValue(CornerRadiusPolicyProperty);
                }
                else
                {
                    return (VisualTransformPolicyType?)GetInternalCornerRadiusPolicyProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CornerRadiusPolicyProperty, value);
                }
                else
                {
                    SetInternalCornerRadiusPolicyProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The width for the borderline of the View.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public float? BorderlineWidth
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(BorderlineWidthProperty);
                }
                else
                {
                    return (float?)GetInternalBorderlineWidthProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BorderlineWidthProperty, value);
                }
                else
                {
                    SetInternalBorderlineWidthProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The color for the borderline of the View.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Color BorderlineColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Color)GetValue(BorderlineColorProperty);
                }
                else
                {
                    return (Color)GetInternalBorderlineColorProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BorderlineColorProperty, value);
                }
                else
                {
                    SetInternalBorderlineColorProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The color selector for the borderline of the View.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Color> BorderlineColorSelector
        {
            get
            {
                Selector<Color> color = null;
                if (NUIApplication.IsUsingXaml)
                {
                    color = (Selector<Color>)GetValue(BorderlineColorSelectorProperty);
                }
                else
                {
                    color = (Selector<Color>)GetInternalBorderlineColorSelectorProperty(this);
                }
                return (null != color) ? color : borderlineColorSelector = new Selector<Color>();
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BorderlineColorSelectorProperty, value);
                }
                else
                {
                    SetInternalBorderlineColorSelectorProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The Relative offset for the borderline of the View.
        /// Recommended range : [-1.0f to 1.0f].
        /// If -1.0f, draw borderline inside of the View.
        /// If 1.0f, draw borderline outside of the View.
        /// If 0.0f, draw borderline half inside and half outside.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public float? BorderlineOffset
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(BorderlineOffsetProperty);
                }
                else
                {
                    return (float?)GetInternalBorderlineOffsetProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(BorderlineOffsetProperty, value);
                }
                else
                {
                    SetInternalBorderlineOffsetProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The ThemeChangeSensitive value of the View.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? ThemeChangeSensitive
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(ThemeChangeSensitiveProperty);
                }
                else
                {
                    return (bool?)GetInternalThemeChangeSensitiveProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ThemeChangeSensitiveProperty, value);
                }
                else
                {
                    SetInternalThemeChangeSensitiveProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Flag to decide View can be enabled user interaction or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsEnabled
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(IsEnabledProperty);
                }
                else
                {
                    return (bool?)GetInternalIsEnabledProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IsEnabledProperty, value);
                }
                else
                {
                    SetInternalIsEnabledProperty(this, null, value);
                }
            }
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
        /// HashSet of dirty properties. Internal use only.
        /// </summary>
        internal HashSet<BindableProperty> DirtyProperties { get; private set; }

        /// <summary>Create a cloned ViewStyle.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewStyle Clone()
        {
            var cloned = CreateInstance();
            cloned.CopyFrom(this);

            return cloned;
        }

        /// <summary>
        /// Releases all resources used by the ViewStyle instance.
        /// The Dispose method releases all resources used by the ViewStyle instance.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            global::System.GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void CopyFrom(BindableObject other)
        {
            var source = other as ViewStyle;

            if (source == null || source.DirtyProperties == null || source.DirtyProperties.Count == 0)
            {
                return;
            }

            IncludeDefaultStyle = source.IncludeDefaultStyle;
            SolidNull = source.SolidNull;

            BindableProperty.GetBindablePropertysOfType(GetType(), out var thisBindableProperties);

            if (thisBindableProperties == null)
            {
                return;
            }

            foreach (var sourceProperty in source.DirtyProperties)
            {
                var sourceValue = source.GetValue(sourceProperty);

                if (sourceValue == null)
                {
                    continue;
                }

                thisBindableProperties.TryGetValue(sourceProperty.PropertyName, out var destinationProperty);

                if (destinationProperty != null)
                {
                    InternalSetValue(destinationProperty, sourceValue);
                }
            }
        }

        /// <summary>
        /// Releases unmanaged and optionally managed resources.
        /// </summary>
        /// <param name="disposing"> If it true, the method has been called by a user's code to release both managed and unmanaged resources. Otherwise the method has been called by the finalizer to release only unmanaged resources.</param>
        /// <since_tizen> 9 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                // Dispose managed state (managed objects).
                margin?.Dispose();
                maximumSize?.Dispose();
                minimumSize?.Dispose();
                orientation?.Dispose();
                padding?.Dispose();
                parentOrigin?.Dispose();
                pivotPoint?.Dispose();
                position?.Dispose();
                size?.Dispose();
                sizeModeFactor?.Dispose();
                cornerRadius?.Dispose();
                borderlineColor?.Dispose();
            }

            disposed = true;
        }

        /// <summary>
        /// Method that is called when a bound property is changed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnPropertyChangedWithData(BindableProperty property)
        {
            base.OnPropertyChangedWithData(property);

            if (property != null)
            {
                (DirtyProperties ?? (DirtyProperties = new HashSet<BindableProperty>())).Add(property);
            }
        }

        internal ViewStyle CreateInstance()
        {
            return (ViewStyle)Activator.CreateInstance(GetType());
        }

        /// <summary>Merge other style into the current style without creating new one.</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void MergeDirectly(ViewStyle other)
        {
            CopyFrom(other);
        }
    }

    /// <summary> Extension methods for ViewStyle class.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ViewStyleExtension
    {
        /// <summary>Merge two styles into the new one.</summary>
        /// <exception cref="ArgumentException">Thrown when failed because of an invalid parameter.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TOut Merge<TOut>(this TOut value, TOut other) where TOut : Tizen.NUI.BaseComponents.ViewStyle
        {
            var newStyle = value.Clone() as TOut;

            newStyle?.CopyFrom(other);

            return newStyle;
        }
    }
}
