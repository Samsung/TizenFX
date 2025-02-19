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
using static Tizen.Applications.ApplicationInfoFilter;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// The base class of style attributes for a view.
    /// This class provides a base for defining styles that can be applied to views.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public partial class ViewStyle : BindableObject, IDisposable
    {
        static readonly IStyleProperty BackgroundImageProperty = new StyleProperty<View, Selector<string>>((v, o) => View.SetInternalBackgroundImageProperty(v, null, o));
        static readonly IStyleProperty FocusableProperty = new StyleProperty<View, bool>((v, o) => v.Focusable = o);
        static readonly IStyleProperty FocusableChildrenProperty = new StyleProperty<View, bool>((v, o) => v.FocusableChildren = o);
        static readonly IStyleProperty FocusableInTouchProperty = new StyleProperty<View, bool>((v, o) => v.FocusableInTouch = o);
        static readonly IStyleProperty OpacityProperty = new StyleProperty<View, Selector<float?>>((v, o) => View.SetInternalOpacityProperty(v, null, o));
        static readonly IStyleProperty PositionUsesPivotPointProperty = new StyleProperty<View, bool>((v, o) => v.PositionUsesPivotPoint = o);
        static readonly IStyleProperty ParentOriginProperty = new StyleProperty<View, Position>((v, o) => v.ParentOrigin = o);
        static readonly IStyleProperty PivotPointProperty = new StyleProperty<View, Position>((v, o) => v.PivotPoint = o);
        static readonly IStyleProperty SizeWidthProperty = new StyleProperty<View, float>((v, o) => v.SizeWidth = o);
        static readonly IStyleProperty SizeHeightProperty = new StyleProperty<View, float>((v, o) => v.SizeHeight = o);
        static readonly IStyleProperty SizeDepthProperty = new StyleProperty<View, float>((v, o) => v.Size = new Size(v.SizeWidth, v.SizeHeight, o));
        static readonly IStyleProperty PositionXProperty = new StyleProperty<View, float>((v, o) => v.PositionX = o);
        static readonly IStyleProperty PositionYProperty = new StyleProperty<View, float>((v, o) => v.PositionY = o);
        static readonly IStyleProperty PositionZProperty = new StyleProperty<View, float>((v, o) => v.PositionZ = o);
        static readonly IStyleProperty OrientationProperty = new StyleProperty<View, Rotation>((v, o) => v.Orientation = o);
        static readonly IStyleProperty DrawModeProperty = new StyleProperty<View, DrawModeType>((v, o) => v.DrawMode = o);
        static readonly IStyleProperty SizeModeFactorProperty = new StyleProperty<View, Vector3>((v, o) => v.SizeModeFactor = o);
        static readonly IStyleProperty WidthResizePolicyProperty = new StyleProperty<View, ResizePolicyType>((v, o) => v.WidthResizePolicy = o);
        static readonly IStyleProperty HeightResizePolicyProperty = new StyleProperty<View, ResizePolicyType>((v, o) => v.HeightResizePolicy = o);
        static readonly IStyleProperty WidthForHeightProperty = new StyleProperty<View, bool>((v, o) => v.WidthForHeight = o);
        static readonly IStyleProperty HeightForWidthProperty = new StyleProperty<View, bool>((v, o) => v.HeightForWidth = o);
        static readonly IStyleProperty PaddingProperty = new StyleProperty<View, Extents>((v, o) => v.Padding = o);
        static readonly IStyleProperty MinimumSizeProperty = new StyleProperty<View, Size2D>((v, o) => v.MinimumSize = o);
        static readonly IStyleProperty MaximumSizeProperty = new StyleProperty<View, Size2D>((v, o) => v.MaximumSize = o);
        static readonly IStyleProperty ClippingModeProperty = new StyleProperty<View, ClippingModeType>((v, o) => v.ClippingMode = o);
        static readonly IStyleProperty MarginProperty = new StyleProperty<View, Extents>((v, o) => v.Margin = o);
        static readonly IStyleProperty BackgroundColorProperty = new StyleProperty<View, Selector<Color>>((v, o) => View.SetInternalBackgroundColorProperty(v, null, o));
        static readonly IStyleProperty ColorProperty = new StyleProperty<View, Selector<Color>>((v, o) => View.SetInternalColorProperty(v, null, o));
        static readonly IStyleProperty BackgroundImageBorderProperty = new StyleProperty<View, Selector<Rectangle>>((v, o) => View.SetInternalBackgroundImageBorderProperty(v, null, o));
        static readonly IStyleProperty ImageShadowProperty = new StyleProperty<View, Selector<ImageShadow>>((v, o) => View.SetInternalImageShadowProperty(v, null, o));
        static readonly IStyleProperty BoxShadowProperty = new StyleProperty<View, Selector<Shadow>>((v, o) => View.SetInternalBoxShadowProperty(v, null, o));
        static readonly IStyleProperty CornerRadiusProperty = new StyleProperty<View, Vector4>((v, o) => v.CornerRadius = o);
        static readonly IStyleProperty CornerRadiusPolicyProperty = new StyleProperty<View, VisualTransformPolicyType>((v, o) => v.CornerRadiusPolicy = o);
        static readonly IStyleProperty BorderlineWidthProperty = new StyleProperty<View, float>((v, o) => v.BorderlineWidth = o);
        static readonly IStyleProperty BorderlineColorProperty = new StyleProperty<View, Color>((v, o) => v.BorderlineColor = o);
        static readonly IStyleProperty BorderlineColorSelectorProperty = new StyleProperty<View, Selector<Color>>((v, o) => View.SetInternalBorderlineColorSelectorProperty(v, null, o));
        static readonly IStyleProperty BorderlineOffsetProperty = new StyleProperty<View, float>((v, o) => v.BorderlineOffset = o);
        static readonly IStyleProperty ThemeChangeSensitiveProperty = new StyleProperty<View, bool>((v, o) => v.ThemeChangeSensitive = o);
        static readonly IStyleProperty IsEnabledProperty = new StyleProperty<View, bool>((v, o) => v.IsEnabled = o);

        private Dictionary<IStyleProperty, object> values = new Dictionary<IStyleProperty, object>();
        private bool disposed = false;

        static ViewStyle() { }

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
            get => GetOrCreateValue<Selector<string>>(BackgroundImageProperty);
            set => SetValue(BackgroundImageProperty, value);
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [Obsolete("This has been deprecated. Use Size instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D Size2D
        {
            get
            {
                var width = (float?)GetValue(SizeWidthProperty);
                var height = (float?)GetValue(SizeHeightProperty);

                if (null == width && null == height)
                {
                    return null;
                }
                else
                {
                    var realWidth = null == width ? 0 : width.Value;
                    var realHeight = null == height ? 0 : height.Value;

                    return new Size2D((int)realWidth, (int)realHeight);
                }
            }
            set
            {
                float? width = null;
                float? height = null;

                if (value is Size2D size)
                {
                    width = size.Width;
                    height = size.Height;
                }

                SetValue(SizeWidthProperty, width);
                SetValue(SizeHeightProperty, height);
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
            get => GetOrCreateValue<Selector<float?>>(OpacityProperty);
            set => SetValue(OpacityProperty, value);
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [Obsolete("This has been deprecated. Use Position instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position2D Position2D
        {
            get
            {
                var x = (float?)GetValue(PositionXProperty);
                var y = (float?)GetValue(PositionYProperty);

                if (null == x && null == y)
                {
                    return null;
                }
                else
                {
                    var realX = null == x ? 0 : x.Value;
                    var realY = null == y ? 0 : y.Value;

                    return new Position2D((int)realX, (int)realY);
                }
            }
            set
            {
                float? x = null;
                float? y = null;

                if (value is Position2D position)
                {
                    x = position.X;
                    y = position.Y;
                }

                SetValue(PositionXProperty, x);
                SetValue(PositionYProperty, y);
            }
        }

        /// <summary>
        /// Determines whether the pivot point should be used to determine the position of the view.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public bool? PositionUsesPivotPoint
        {
            get => (bool?)GetValue(PositionUsesPivotPointProperty);
            set => SetValue(PositionUsesPivotPointProperty, value);
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
            get => (Position)GetValue(ParentOriginProperty);
            set => SetValue(ParentOriginProperty, value);
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
            get => (Position)GetValue(PivotPointProperty);
            set => SetValue(PivotPointProperty, value);
        }

        /// <summary>
        /// Gets or sets the width of the view.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public float? SizeWidth
        {
            get => (float?)GetValue(SizeWidthProperty);
            set => SetValue(SizeWidthProperty, value);
        }

        /// <summary>
        /// Gets or sets the height of the view.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public float? SizeHeight
        {
            get => (float?)GetValue(SizeHeightProperty);
            set => SetValue(SizeHeightProperty, value);
        }

        /// <summary>
        /// Gets or sets the position of the view.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Position Position
        {
            get
            {
                var x = (float?)GetValue(PositionXProperty);
                var y = (float?)GetValue(PositionYProperty);
                var z = (float?)GetValue(PositionZProperty);

                if (null == x && null == y && null == z)
                {
                    return null;
                }
                else
                {
                    var realX = null == x ? 0 : x.Value;
                    var realY = null == y ? 0 : y.Value;
                    var realZ = null == z ? 0 : z.Value;

                    return new Position(realX, realY, realZ);
                }
            }
            set
            {
                float? x = null;
                float? y = null;
                float? z = null;

                if (value is Position position)
                {
                    x = position.X;
                    y = position.Y;

                    var positionZ = position.Z;
                    if (0 != positionZ)
                    {
                        z = position.Z;
                    }
                }

                SetValue(PositionXProperty, x);
                SetValue(PositionYProperty, y);

                if (null != z)
                {
                    SetValue(PositionZProperty, z);
                }
            }
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PositionX
        {
            get => (float?)GetValue(PositionXProperty);
            set => SetValue(PositionXProperty, value);
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PositionY
        {
            get => (float?)GetValue(PositionYProperty);
            set => SetValue(PositionYProperty, value);
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rotation Orientation
        {
            get => (Rotation)GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DrawModeType? DrawMode
        {
            get => (DrawModeType?)GetValue(DrawModeProperty);
            set => SetValue(DrawModeProperty, value);
        }

        /// <summary>
        /// Gets or sets the relative to parent size factor of the view.<br />
        /// This factor is only used when ResizePolicyType is set to either: ResizePolicyType.SizeRelativeToParent or ResizePolicyType.SizeFixedOffsetFromParent.<br />
        /// This view's size is set to the view's size multiplied by or added to this factor, depending on ResizePolicyType.<br />
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Vector3 SizeModeFactor
        {
            get => (Vector3)GetValue(SizeModeFactorProperty);
            set => SetValue(SizeModeFactorProperty, value);
        }

        /// <summary>
        /// Gets or sets the width resize policy to be used.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public ResizePolicyType? WidthResizePolicy
        {
            get => (ResizePolicyType?)GetValue(WidthResizePolicyProperty);
            set => SetValue(WidthResizePolicyProperty, value);
        }

        /// <summary>
        /// Gets or sets the height resize policy to be used.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public ResizePolicyType? HeightResizePolicy
        {
            get => (ResizePolicyType?)GetValue(HeightResizePolicyProperty);
            set => SetValue(HeightResizePolicyProperty, value);
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? WidthForHeight
        {
            get => (bool?)GetValue(WidthForHeightProperty);
            set => SetValue(WidthForHeightProperty, value);
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? HeightForWidth
        {
            get => (bool?)GetValue(HeightForWidthProperty);
            set => SetValue(HeightForWidthProperty, value);
        }

        /// <summary>
        /// Gets or sets the padding for use in layout.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Extents Padding
        {
            get => GetOrCreateValue<Extents>(PaddingProperty);
            set => SetValue(PaddingProperty, value);
        }

        /// <summary>
        /// Gets or sets the minimum size the view can be assigned in size negotiation.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Size2D MinimumSize
        {
            get => (Size2D)GetValue(MinimumSizeProperty);
            set => SetValue(MinimumSizeProperty, value);
        }

        /// <summary>
        /// Gets or sets the maximum size the view can be assigned in size negotiation.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Size2D MaximumSize
        {
            get => (Size2D)GetValue(MaximumSizeProperty);
            set => SetValue(MaximumSizeProperty, value);
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ClippingModeType? ClippingMode
        {
            get => (ClippingModeType?)GetValue(ClippingModeProperty);
            set => SetValue(ClippingModeProperty, value);
        }

        /// <summary>
        /// Sets the size of a view for the width, the height, and the depth.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Size Size
        {
            get
            {
                var width = (float?)GetValue(SizeWidthProperty);
                var height = (float?)GetValue(SizeHeightProperty);
                var depth = (float?)GetValue(SizeDepthProperty);

                if (null == width && null == height && null == depth)
                {
                    return null;
                }
                else
                {
                    var realWidth = null == width ? 0 : width.Value;
                    var realHeight = null == height ? 0 : height.Value;
                    var realDepth = null == depth ? 0 : depth.Value;

                    return new Size(realWidth, realHeight, realDepth);
                }
            }
            set
            {
                float? width = null;
                float? height = null;
                float? depth = null;

                if (value is Size size)
                {
                    width = size.Width;
                    height = size.Height;

                    var sizeDepth = size.Depth;

                    if (0 != sizeDepth)
                    {
                        depth = sizeDepth;
                    }
                }

                SetValue(SizeWidthProperty, width);
                SetValue(SizeHeightProperty, height);

                if (null != depth)
                {
                    SetValue(SizeDepthProperty, depth);
                }
            }
        }

        /// <summary>
        /// Gets or sets the Margin for use in layout.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Extents Margin
        {
            get => GetOrCreateValue<Extents>(MarginProperty);
            set => SetValue(MarginProperty, value);
        }

        /// <summary>
        /// Gets or sets the color of the background of view.
        /// The mutually exclusive with "BackgroundImage". Setting it overwrites existing "BackgroundImage".
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Selector<Color> BackgroundColor
        {
            get => GetOrCreateValue<Selector<Color>>(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        /// <summary>
        /// Color
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Color> Color
        {
            get => GetOrCreateValue<Selector<Color>>(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        /// <summary>View BackgroundBorder</summary>
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Rectangle> BackgroundImageBorder
        {
            get => GetOrCreateValue<Selector<Rectangle>>(BackgroundImageBorderProperty);
            set => SetValue(BackgroundImageBorderProperty, value);
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
            get => (Selector<ImageShadow>)GetValue(ImageShadowProperty);
            set => SetValue(ImageShadowProperty, value);
        }

        /// <summary>
        /// Describes a box shaped shadow drawing for a View.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Selector<Shadow> BoxShadow
        {
            get => (Selector<Shadow>)GetValue(BoxShadowProperty);
            set => SetValue(BoxShadowProperty, value);
        }

        /// <summary>
        /// The radius for the rounded corners of the View.
        /// The values in Vector4 are used in clockwise order from top-left to bottom-left : Vector4(top-left-corner, top-right-corner, bottom-right-corner, bottom-left-corner).
        /// Each radius will clamp internally to the half of smaller of the view's width or height.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Vector4 CornerRadius
        {
            get => (Vector4)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        /// <summary>
        /// Whether the CornerRadius property value is relative (percentage [0.0f to 0.5f] of the view size) or absolute (in world units).
        /// It is absolute by default.
        /// When the policy is relative, the corner radius is relative to the smaller of the view's width and height.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public VisualTransformPolicyType? CornerRadiusPolicy
        {
            get => (VisualTransformPolicyType?)GetValue(CornerRadiusPolicyProperty);
            set => SetValue(CornerRadiusPolicyProperty, value);
        }

        /// <summary>
        /// The width for the borderline of the View.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public float? BorderlineWidth
        {
            get => (float?)GetValue(BorderlineWidthProperty);
            set => SetValue(BorderlineWidthProperty, value);
        }

        /// <summary>
        /// The color for the borderline of the View.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Color BorderlineColor
        {
            get => (Color)GetValue(BorderlineColorProperty);
            set => SetValue(BorderlineColorProperty, value);
        }

        /// <summary>
        /// The color selector for the borderline of the View.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Color> BorderlineColorSelector
        {
            get => GetOrCreateValue<Selector<Color>>(BorderlineColorSelectorProperty);
            set => SetValue(BorderlineColorSelectorProperty, value);
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
            get => (float?)GetValue(BorderlineOffsetProperty);
            set => SetValue(BorderlineOffsetProperty, value);
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
        /// Flag to decide View can be enabled user interaction or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsEnabled
        {
            get => (bool?)GetValue(IsEnabledProperty);
            set => SetValue(IsEnabledProperty, value);
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
            if (!(other is ViewStyle source))
            {
                return;
            }

            IncludeDefaultStyle = source.IncludeDefaultStyle;
            SolidNull = source.SolidNull;

            foreach (var (property, value) in source.values)
            {
                if (value != null)
                {
                    values[property] = value;
                }
            }

            // NOTE Support backward compatibility.
            CopyBindablePropertyValues(source);
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
                values = null;
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

        internal IEnumerable<(IStyleProperty, object)> GetProperties()
        {
            foreach (var (key, value) in values)
            {
                if (value != null)
                {
                    yield return (key, value);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual object GetValue(IStyleProperty styleProperty)
        {
            if (values.TryGetValue(styleProperty, out var value))
            {
                return value;
            }
            return default;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual T GetOrCreateValue<T>(IStyleProperty styleProperty)
        {
            T newValue = (T)Activator.CreateInstance(typeof(T));
            values[styleProperty] = newValue;
            return newValue;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void SetValue(IStyleProperty styleProperty, object value)
        {
            // NOTE Allow null value. It is used when merging styles with solid null option
            values[styleProperty] = value;
        }

        private void CopyBindablePropertyValues(ViewStyle source)
        {
            // NOTE This is to support legacy way of copying styles using bindable properties.
            // Please do not spend time to keep this code
            // This is just to make sure we don't break backward compatibility
            if (source.DirtyProperties == null || source.DirtyProperties.Count == 0)
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
