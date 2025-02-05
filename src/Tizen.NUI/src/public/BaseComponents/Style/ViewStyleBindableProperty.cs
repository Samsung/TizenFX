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
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    public partial class ViewStyle
    {
        /// <summary> Bindable property of BackgroundImage. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageProperty = null;
        internal static void SetInternalBackgroundImageProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var viewStyle = (ViewStyle)bindable;
            if (newValue == null)
            {
                viewStyle.backgroundImageSelector = null;
            }
            else
            {
                viewStyle.backgroundImageSelector = (Selector<string>)newValue;
                viewStyle.backgroundColorSelector = null;
            }
        }
        internal static object GetInternalBackgroundImageProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).backgroundImageSelector;
        }

        /// <summary> Bindable property of Focusable. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FocusableProperty = null;
        internal static void SetInternalFocusableProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).focusable = (bool?)newValue;
        }
        internal static object GetInternalFocusableProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).focusable;
        }

        /// <summary> Bindable property of FocusableChildren. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FocusableChildrenProperty = null;
        internal static void SetInternalFocusableChildrenProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).focusableChildren = (bool?)newValue;
        }
        internal static object GetInternalFocusableChildrenProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).focusableChildren;
        }

        /// <summary> Bindable property of FocusableInTouch. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FocusableInTouchProperty = null;
        internal static void SetInternalFocusableInTouchProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).focusableInTouch = (bool?)newValue;
        }
        internal static object GetInternalFocusableInTouchProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).focusableInTouch;
        }

        /// <summary> Bindable property of Focusable. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty Size2DProperty = null;
        internal static void SetInternalSize2DProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.size = newValue == null ? null : new Size((Size2D)newValue);
        }
        internal static object GetInternalSize2DProperty(BindableObject bindable)
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.size == null ? null : (Size2D)viewStyle.size;
        }

        /// <summary> Bindable property of Opacity. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OpacityProperty = null;
        internal static void SetInternalOpacityProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).opacitySelector = (Selector<float?>)newValue;
        }
        internal static object GetInternalOpacityProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).opacitySelector;
        }

        /// <summary> Bindable property of Position2D. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty Position2DProperty = null;
        internal static void SetInternalPosition2DProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.position = newValue == null ? null : new Position((Position2D)newValue);
        }
        internal static object GetInternalPosition2DProperty(BindableObject bindable)
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.position == null ? null : new Position2D(viewStyle.position);
        }

        /// <summary> Bindable property of PositionUsesPivotPoint. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionUsesPivotPointProperty = null;
        internal static void SetInternalPositionUsesPivotPointProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).positionUsesPivotPoint = (bool?)newValue;
        }
        internal static object GetInternalPositionUsesPivotPointProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).positionUsesPivotPoint;
        }

        /// <summary> Bindable property of ParentOrigin. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ParentOriginProperty = null;
        internal static void SetInternalParentOriginProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).parentOrigin = (Position)newValue;
        }
        internal static object GetInternalParentOriginProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).parentOrigin;
        }

        /// <summary> Bindable property of PivotPoint. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PivotPointProperty = null;
        internal static void SetInternalPivotPointProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).pivotPoint = (Position)newValue;
        }
        internal static object GetInternalPivotPointProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).pivotPoint;
        }

        /// <summary> Bindable property of SizeWidth. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeWidthProperty = null;
        internal static void SetInternalSizeWidthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var viewStyle = (ViewStyle)bindable;
            if (newValue != null)
            {
                if (viewStyle.size == null)
                {
                    if ((float)newValue == 0) return;
                }
                viewStyle.size = new Size((float)newValue, viewStyle.size?.Height ?? 0);
            }
        }
        internal static object GetInternalSizeWidthProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).size?.Width;
        }

        /// <summary> Bindable property of SizeHeight. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeHeightProperty = null;
        internal static void SetInternalSizeHeightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var viewStyle = (ViewStyle)bindable;
            if (newValue != null)
            {
                if (viewStyle.size == null)
                {
                    if ((float)newValue == 0) return;
                }
                viewStyle.size = new Size(viewStyle.size?.Width ?? 0, (float)newValue);
            }
        }
        internal static object GetInternalSizeHeightProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).size?.Height;
        }

        /// <summary> Bindable property of Position. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionProperty = null;
        internal static void SetInternalPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.position = (Position)newValue;
            if (viewStyle.position != null && viewStyle.position.X == 0 && viewStyle.position.Y == 0)
            {
                viewStyle.position = null;
            }
        }
        internal static object GetInternalPositionProperty(BindableObject bindable)
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.position;
        }

        /// <summary> Bindable property of PositionX. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionXProperty = null;
        internal static void SetInternalPositionXProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var viewStyle = (ViewStyle)bindable;
            if (newValue != null)
            {
                if (viewStyle.position == null)
                {
                    if ((float)newValue == 0) return;
                }
                viewStyle.position = new Position((float)newValue, viewStyle.position?.Y ?? 0);
            }
        }
        internal static object GetInternalPositionXProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).position?.X;
        }

        /// <summary> Bindable property of PositionY. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionYProperty = null;
        internal static void SetInternalPositionYProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var viewStyle = (ViewStyle)bindable;
            if (newValue != null)
            {
                if (viewStyle.position == null)
                {
                    if ((float)newValue == 0) return;
                }
                viewStyle.position = new Position(viewStyle.position?.X ?? 0, (float)newValue);
            }
        }
        internal static object GetInternalPositionYProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).position?.Y;
        }

        /// <summary> Bindable property of Orientation. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OrientationProperty = null;
        internal static void SetInternalOrientationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).orientation = (Rotation)newValue;
        }
        internal static object GetInternalOrientationProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).orientation;
        }

        /// <summary> Bindable property of DrawMode. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DrawModeProperty = null;
        internal static void SetInternalDrawModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).drawMode = (DrawModeType?)newValue;
        }
        internal static object GetInternalDrawModeProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).drawMode;
        }

        /// <summary> Bindable property of SizeModeFactor. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeModeFactorProperty = null;
        internal static void SetInternalSizeModeFactorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).sizeModeFactor = (Vector3)newValue;
        }
        internal static object GetInternalSizeModeFactorProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).sizeModeFactor;
        }

        /// <summary> Bindable property of WidthResizePolicy. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WidthResizePolicyProperty = null;
        internal static void SetInternalWidthResizePolicyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).widthResizePolicy = (ResizePolicyType?)newValue;
        }
        internal static object GetInternalWidthResizePolicyProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).widthResizePolicy;
        }

        /// <summary> Bindable property of HeightResizePolicy. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HeightResizePolicyProperty = null;
        internal static void SetInternalHeightResizePolicyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).heightResizePolicy = (ResizePolicyType?)newValue;
        }
        internal static object GetInternalHeightResizePolicyProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).heightResizePolicy;
        }

        /// <summary> Bindable property of WidthForHeight. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WidthForHeightProperty = null;
        internal static void SetInternalWidthForHeightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).widthForHeight = (bool?)newValue;
        }
        internal static object GetInternalWidthForHeightProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).widthForHeight;
        }

        /// <summary> Bindable property of HeightForWidth. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HeightForWidthProperty = null;
        internal static void SetInternalHeightForWidthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).heightForWidth = (bool?)newValue;
        }
        internal static object GetInternalHeightForWidthProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).heightForWidth;
        }

        /// <summary> Bindable property of Padding. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PaddingProperty = null;
        internal static void SetInternalPaddingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).padding = (Extents)newValue;
        }
        internal static object GetInternalPaddingProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).padding;
        }

        /// <summary> Bindable property of MinimumSize. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinimumSizeProperty = null;
        internal static void SetInternalMinimumSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).minimumSize = (Size2D)newValue;
        }
        internal static object GetInternalMinimumSizeProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).minimumSize;
        }

        /// <summary> Bindable property of MaximumSize. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaximumSizeProperty = null;
        internal static void SetInternalMaximumSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).maximumSize = (Size2D)newValue;
        }
        internal static object GetInternalMaximumSizeProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).maximumSize;
        }

        /// <summary> Bindable property of ClippingMode. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ClippingModeProperty = null;
        internal static void SetInternalClippingModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).clippingMode = (ClippingModeType?)newValue;
        }
        internal static object GetInternalClippingModeProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).clippingMode;
        }

        /// <summary> Bindable property of Size. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeProperty = null;
        internal static void SetInternalSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.size = (Size)newValue;
            if (viewStyle.size != null && viewStyle.size.Width == 0 && viewStyle.size.Height == 0)
            {
                viewStyle.size = null;
            }
        }
        internal static object GetInternalSizeProperty(BindableObject bindable)
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.size;
        }

        /// <summary> Bindable property of Margin. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MarginProperty = null;
        internal static void SetInternalMarginProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).margin = (Extents)newValue;
        }
        internal static object GetInternalMarginProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).margin;
        }

        /// <summary> Bindable property of BackgroundColor. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundColorProperty = null;
        internal static void SetInternalBackgroundColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var viewStyle = (ViewStyle)bindable;

            if (newValue == null)
            {
                viewStyle.backgroundColorSelector = null;
            }
            else
            {
                viewStyle.backgroundColorSelector = (Selector<Color>)newValue;
                viewStyle.backgroundImageSelector = null;
            }
        }
        internal static object GetInternalBackgroundColorProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).backgroundColorSelector;
        }

        /// <summary> Bindable property of ColorSelector. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ColorProperty = null;
        internal static void SetInternalColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).colorSelector = (Selector<Color>)newValue;
        }
        internal static object GetInternalColorProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).colorSelector;
        }

        /// <summary> Bindable property of BackgroundImageBorder. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageBorderProperty = null;
        internal static void SetInternalBackgroundImageBorderProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).backgroundImageBorderSelector = (Selector<Rectangle>)newValue;
        }
        internal static object GetInternalBackgroundImageBorderProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).backgroundImageBorderSelector;
        }

        /// <summary> Bindable property of ImageShadow. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageShadowProperty = null;
        internal static void SetInternalImageShadowProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var viewStyle = (ViewStyle)bindable;

            viewStyle.imageShadow = (Selector<ImageShadow>)newValue;

            if (viewStyle.imageShadow != null)
            {
                viewStyle.boxShadow = null;
            }
        }
        internal static object GetInternalImageShadowProperty(BindableObject bindable)
        {
            var viewStyle = (ViewStyle)bindable;
            return ((ViewStyle)bindable).imageShadow;
        }

        /// <summary> Bindable property of BoxShadow. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BoxShadowProperty = null;
        internal static void SetInternalBoxShadowProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var viewStyle = (ViewStyle)bindable;

            viewStyle.boxShadow = (Selector<Shadow>)newValue;

            if (viewStyle.boxShadow != null)
            {
                viewStyle.imageShadow = null;
            }
        }
        internal static object GetInternalBoxShadowProperty(BindableObject bindable)
        {
            var viewStyle = (ViewStyle)bindable;
            return ((ViewStyle)bindable).boxShadow;
        }

        /// <summary> Bindable property of CornerRadius. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CornerRadiusProperty = null;
        internal static void SetInternalCornerRadiusProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).cornerRadius = (Vector4)newValue;
        }
        internal static object GetInternalCornerRadiusProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).cornerRadius;
        }

        /// <summary> Bindable property of CornerRadiusPolicy. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CornerRadiusPolicyProperty = null;
        internal static void SetInternalCornerRadiusPolicyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).cornerRadiusPolicy = (VisualTransformPolicyType?)newValue;
        }
        internal static object GetInternalCornerRadiusPolicyProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).cornerRadiusPolicy;
        }

        /// <summary> Bindable property of BorderlineWidth. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderlineWidthProperty = null;
        internal static void SetInternalBorderlineWidthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).borderlineWidth = (float?)newValue;
        }
        internal static object GetInternalBorderlineWidthProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).borderlineWidth;
        }

        /// <summary> Bindable property of BorderlineColor. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderlineColorProperty = null;
        internal static void SetInternalBorderlineColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).borderlineColor = (Color)newValue;
        }
        internal static object GetInternalBorderlineColorProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).borderlineColor ?? Tizen.NUI.Color.Black;
        }

        /// <summary> Bindable property of BorderlineColorSelector. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderlineColorSelectorProperty = null;
        internal static void SetInternalBorderlineColorSelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var viewStyle = (ViewStyle)bindable;

            if (newValue == null)
            {
                viewStyle.borderlineColorSelector = null;
            }
            else
            {
                viewStyle.borderlineColorSelector = (Selector<Color>)newValue;
            }
        }
        internal static object GetInternalBorderlineColorSelectorProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).borderlineColorSelector;
        }

        /// <summary> Bindable property of BorderlineOffset. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderlineOffsetProperty = null;
        internal static void SetInternalBorderlineOffsetProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).borderlineOffset = (float?)newValue;
        }
        internal static object GetInternalBorderlineOffsetProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).borderlineOffset;
        }

        /// <summary> Bindable property of ThemeChangeSensitive. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThemeChangeSensitiveProperty = null;
        internal static void SetInternalThemeChangeSensitiveProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ViewStyle)bindable).themeChangeSensitive = (bool?)newValue;
        }
        internal static object GetInternalThemeChangeSensitiveProperty(BindableObject bindable)
        {
            return ((ViewStyle)bindable).themeChangeSensitive;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsEnabledProperty = null;
        internal static void SetInternalIsEnabledProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var buttonStyle = (ViewStyle)bindable;
            buttonStyle.isEnabled = (bool?)newValue;
        }
        internal static object GetInternalIsEnabledProperty(BindableObject bindable)
        {
            var buttonStyle = (ViewStyle)bindable;
            return buttonStyle.isEnabled;
        }
    }
}
