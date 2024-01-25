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
        public static readonly BindableProperty BackgroundImageProperty = BindableProperty.Create(nameof(BackgroundImage), typeof(Selector<string>), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ViewStyle)bindable).backgroundImageSelector;
        });

        /// <summary> Bindable property of Focusable. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FocusableProperty = BindableProperty.Create(nameof(Focusable), typeof(bool?), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).focusable = (bool?)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).focusable
        );

        /// <summary> Bindable property of FocusableChildren. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FocusableChildrenProperty = BindableProperty.Create(nameof(FocusableChildren), typeof(bool?), typeof(ViewStyle), true,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).focusableChildren = (bool?)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).focusableChildren
        );


        /// <summary> Bindable property of FocusableInTouch. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FocusableInTouchProperty = BindableProperty.Create(nameof(FocusableInTouch), typeof(bool?), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).focusableInTouch = (bool?)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).focusableInTouch
        );

        /// <summary> Bindable property of Focusable. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty Size2DProperty = BindableProperty.Create(nameof(Size2D), typeof(Size2D), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.size = newValue == null ? null : new Size((Size2D)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.size == null ? null : (Size2D)viewStyle.size;
        });

        /// <summary> Bindable property of Opacity. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OpacityProperty = BindableProperty.Create(nameof(Opacity), typeof(Selector<float?>), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).opacitySelector = (Selector<float?>)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).opacitySelector
        );

        /// <summary> Bindable property of Position2D. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty Position2DProperty = BindableProperty.Create(nameof(Position2D), typeof(Position2D), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.position = newValue == null ? null : new Position((Position2D)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.position == null ? null : new Position2D(viewStyle.position);
        });

        /// <summary> Bindable property of PositionUsesPivotPoint. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionUsesPivotPointProperty = BindableProperty.Create(nameof(PositionUsesPivotPoint), typeof(bool?), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).positionUsesPivotPoint = (bool?)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).positionUsesPivotPoint
        );

        /// <summary> Bindable property of ParentOrigin. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ParentOriginProperty = BindableProperty.Create(nameof(ParentOrigin), typeof(Position), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).parentOrigin = (Position)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).parentOrigin
        );

        /// <summary> Bindable property of PivotPoint. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PivotPointProperty = BindableProperty.Create(nameof(PivotPoint), typeof(Position), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).pivotPoint = (Position)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).pivotPoint
        );

        /// <summary> Bindable property of SizeWidth. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeWidthProperty = BindableProperty.Create(nameof(SizeWidth), typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ViewStyle)bindable).size?.Width;
        });

        /// <summary> Bindable property of SizeHeight. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeHeightProperty = BindableProperty.Create(nameof(SizeHeight), typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ViewStyle)bindable).size?.Height;
        });

        /// <summary> Bindable property of Position. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionProperty = BindableProperty.Create(nameof(Position), typeof(Position), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.position = (Position)newValue;
            if (viewStyle.position != null && viewStyle.position.X == 0 && viewStyle.position.Y == 0)
            {
                viewStyle.position = null;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.position;
        });

        /// <summary> Bindable property of PositionX. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionXProperty = BindableProperty.Create(nameof(PositionX), typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ViewStyle)bindable).position?.X;
        });

        /// <summary> Bindable property of PositionY. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionYProperty = BindableProperty.Create(nameof(PositionY), typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ViewStyle)bindable).position?.Y;
        });

        /// <summary> Bindable property of Orientation. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OrientationProperty = BindableProperty.Create(nameof(Orientation), typeof(Rotation), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).orientation = (Rotation)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).orientation
        );

        /// <summary> Bindable property of DrawMode. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DrawModeProperty = BindableProperty.Create(nameof(DrawMode), typeof(DrawModeType?), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).drawMode = (DrawModeType?)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).drawMode
        );

        /// <summary> Bindable property of SizeModeFactor. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeModeFactorProperty = BindableProperty.Create(nameof(SizeModeFactor), typeof(Vector3), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).sizeModeFactor = (Vector3)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).sizeModeFactor
        );

        /// <summary> Bindable property of WidthResizePolicy. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WidthResizePolicyProperty = BindableProperty.Create(nameof(WidthResizePolicy), typeof(ResizePolicyType?), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).widthResizePolicy = (ResizePolicyType?)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).widthResizePolicy
        );

        /// <summary> Bindable property of HeightResizePolicy. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HeightResizePolicyProperty = BindableProperty.Create(nameof(HeightResizePolicy), typeof(ResizePolicyType?), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).heightResizePolicy = (ResizePolicyType?)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).heightResizePolicy
        );

        /// <summary> Bindable property of WidthForHeight. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WidthForHeightProperty = BindableProperty.Create(nameof(WidthForHeight), typeof(bool?), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).widthForHeight = (bool?)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).widthForHeight
        );

        /// <summary> Bindable property of HeightForWidth. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HeightForWidthProperty = BindableProperty.Create(nameof(HeightForWidth), typeof(bool?), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).heightForWidth = (bool?)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).heightForWidth
        );

        /// <summary> Bindable property of Padding. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PaddingProperty = BindableProperty.Create(nameof(Padding), typeof(Extents), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).padding = (Extents)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).padding
        );

        /// <summary> Bindable property of MinimumSize. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinimumSizeProperty = BindableProperty.Create(nameof(MinimumSize), typeof(Size2D), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).minimumSize = (Size2D)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).minimumSize
        );

        /// <summary> Bindable property of MaximumSize. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaximumSizeProperty = BindableProperty.Create(nameof(MaximumSize), typeof(Size2D), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).maximumSize = (Size2D)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).maximumSize
        );

        /// <summary> Bindable property of ClippingMode. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ClippingModeProperty = BindableProperty.Create(nameof(ClippingMode), typeof(ClippingModeType?), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).clippingMode = (ClippingModeType?)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).clippingMode
        );

        /// <summary> Bindable property of Size. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size), typeof(Size), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.size = (Size)newValue;
            if (viewStyle.size != null && viewStyle.size.Width == 0 && viewStyle.size.Height == 0)
            {
                viewStyle.size = null;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.size;
        });

        /// <summary> Bindable property of Margin. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MarginProperty = BindableProperty.Create(nameof(Margin), typeof(Extents), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).margin = (Extents)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).margin
        );

        /// <summary> Bindable property of BackgroundColor. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Selector<Color>), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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

        },
        defaultValueCreator: (bindable) =>
        {
            return ((ViewStyle)bindable).backgroundColorSelector;
        });

        /// <summary> Bindable property of ColorSelector. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Selector<Color>), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).colorSelector = (Selector<Color>)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).colorSelector
        );

        /// <summary> Bindable property of BackgroundImageBorder. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageBorderProperty = BindableProperty.Create(nameof(BackgroundImageBorder), typeof(Selector<Rectangle>), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).backgroundImageBorderSelector = (Selector<Rectangle>)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).backgroundImageBorderSelector
        );

        /// <summary> Bindable property of ImageShadow. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageShadowProperty = BindableProperty.Create(nameof(ImageShadow), typeof(Selector<ImageShadow>), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;

            viewStyle.imageShadow = (Selector<ImageShadow>)newValue;

            if (viewStyle.imageShadow != null)
            {
                viewStyle.boxShadow = null;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return ((ViewStyle)bindable).imageShadow;
        });

        /// <summary> Bindable property of BoxShadow. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BoxShadowProperty = BindableProperty.Create(nameof(BoxShadow), typeof(Selector<Shadow>), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;

            viewStyle.boxShadow = (Selector<Shadow>)newValue;

            if (viewStyle.boxShadow != null)
            {
                viewStyle.imageShadow = null;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return ((ViewStyle)bindable).boxShadow;
        });

        /// <summary> Bindable property of CornerRadius. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(Vector4), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((ViewStyle)bindable).cornerRadius = (Vector4)newValue;
        }, defaultValueCreator: (bindable) => ((ViewStyle)bindable).cornerRadius);

        /// <summary> Bindable property of CornerRadiusPolicy. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CornerRadiusPolicyProperty = BindableProperty.Create(nameof(CornerRadiusPolicy), typeof(VisualTransformPolicyType?), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).cornerRadiusPolicy = (VisualTransformPolicyType?)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).cornerRadiusPolicy
        );

        /// <summary> Bindable property of BorderlineWidth. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderlineWidthProperty = BindableProperty.Create(nameof(BorderlineWidth), typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((ViewStyle)bindable).borderlineWidth = (float?)newValue;
        }, defaultValueCreator: (bindable) => ((ViewStyle)bindable).borderlineWidth);

        /// <summary> Bindable property of BorderlineColor. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderlineColorProperty = BindableProperty.Create(nameof(BorderlineColor), typeof(Color), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((ViewStyle)bindable).borderlineColor = (Color)newValue;
        }, defaultValueCreator: (bindable) => ((ViewStyle)bindable).borderlineColor ?? Tizen.NUI.Color.Black);

        /// <summary> Bindable property of BorderlineColorSelector. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderlineColorSelectorProperty = BindableProperty.Create(nameof(BorderlineColorSelector), typeof(Selector<Color>), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ViewStyle)bindable).borderlineColorSelector;
        });

        /// <summary> Bindable property of BorderlineOffset. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderlineOffsetProperty = BindableProperty.Create(nameof(BorderlineOffset), typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((ViewStyle)bindable).borderlineOffset = (float?)newValue;
        }, defaultValueCreator: (bindable) => ((ViewStyle)bindable).borderlineOffset);

        /// <summary> Bindable property of ThemeChangeSensitive. Do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThemeChangeSensitiveProperty = BindableProperty.Create(nameof(ThemeChangeSensitive), typeof(bool?), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).themeChangeSensitive = (bool?)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).themeChangeSensitive
        );

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create(nameof(IsEnabled), typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var buttonStyle = (ViewStyle)bindable;
            buttonStyle.isEnabled = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var buttonStyle = (ViewStyle)bindable;
            return buttonStyle.isEnabled;
        });
    }
}
