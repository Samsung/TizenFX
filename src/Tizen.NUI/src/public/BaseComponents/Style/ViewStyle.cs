/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public partial class ViewStyle : BindableObject, IDisposable
    {
        private bool disposed = false;
        private bool? focusable;
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

        private Selector<ImageShadow> imageShadow;
        private Selector<Shadow> boxShadow;
        private Selector<string> backgroundImageSelector;
        private Selector<float?> opacitySelector;
        private Selector<Color> backgroundColorSelector;
        private Selector<Rectangle> backgroundImageBorderSelector;
        private Selector<Color> colorSelector;
        private VisualTransformPolicyType? cornerRadiusPolicy;

        static ViewStyle() { }

        /// <summary>
        /// Create an empty style instance.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public ViewStyle() { }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewStyle(ViewStyle viewAttributes)
        {
            CopyFrom(viewAttributes);
        }

        /// <summary>
        /// Gets or sets the image resource url of the background of view.
        /// The mutually exclusive with "BackgroundColor". Setting it overwrites existing "BackgroundColor".
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Selector<string> BackgroundImage
        {
            get
            {
                Selector<string> image = (Selector<string>)GetValue(BackgroundImageProperty);
                return (null != image) ? image : backgroundImageSelector = new Selector<string>();
            }
            set => SetValue(BackgroundImageProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Focusable
        {
            get => (bool?)GetValue(FocusableProperty);
            set => SetValue(FocusableProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [Obsolete("Deprecated. Please use Size instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D Size2D
        {
            get => (Size2D)GetValue(Size2DProperty);
            set => SetValue(Size2DProperty, value);
        }

        /// <summary>
        /// Defines view's opacity value.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Selector<float?> Opacity
        {
            get
            {
                Selector<float?> opacity = (Selector<float?>)GetValue(OpacityProperty);
                return (null != opacity) ? opacity : opacitySelector = new Selector<float?>();
            }
            set => SetValue(OpacityProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [Obsolete("Deprecated. Please use Position instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position2D Position2D
        {
            get => (Position2D)GetValue(Position2DProperty);
            set => SetValue(Position2DProperty, value);
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
        public Rotation Orientation
        {
            get => (Rotation)GetValue(OrientationProperty);
            set => SetValue(OrientationProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// <summary>
        /// Gets or sets the padding for use in layout.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Extents Padding
        {
            get => (Extents)GetValue(PaddingProperty) ?? (padding = new Extents());
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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
            get => (Size)GetValue(SizeProperty);
            set => SetValue(SizeProperty, value);
        }

        /// <summary>
        /// Gets or sets the Margin for use in layout.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Extents Margin
        {
            get => (Extents)GetValue(MarginProperty) ?? (margin = new Extents());
            set => SetValue(MarginProperty, value);
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
                Selector<Color> color = (Selector<Color>)GetValue(BackgroundColorProperty);
                return (null != color) ? color : backgroundColorSelector = new Selector<Color>();
            }
            set => SetValue(BackgroundColorProperty, value);
        }

        /// <summary>
        /// Color
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Color> Color
        {
            get => (Selector<Color>)GetValue(ColorProperty) ?? (colorSelector = new Selector<Color>());
            set => SetValue(ColorProperty, value);
        }

        /// <summary>View BackgroundBorder</summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Rectangle> BackgroundImageBorder
        {
            get
            {
                Selector<Rectangle> border = (Selector<Rectangle>)GetValue(BackgroundImageBorderProperty);
                return (null != border) ? border : backgroundImageBorderSelector = new Selector<Rectangle>();
            }
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
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public Vector4 CornerRadius
        {
            get => (Vector4)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        /// <summary>
        /// Whether the CornerRadius property value is relative (percentage [0.0f to 1.0f] of the view size) or absolute (in world units).
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
        /// Release instance.
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
                    SetValue(destinationProperty, sourceValue);
                }
            }
        }

        /// <summary>
        /// Release instance.
        /// </summary>
        /// <param name="disposing"> If it true, the method has been called by a user's code. Otherwise the method has been called by the finalizer. </param>
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

            newStyle.CopyFrom(other);

            return newStyle;
        }
    }
}
