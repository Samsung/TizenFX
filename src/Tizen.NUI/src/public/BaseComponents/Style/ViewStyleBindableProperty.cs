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
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    public partial class ViewStyle
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StyleNameProperty = BindableProperty.Create(nameof(StyleName), typeof(string), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.styleName = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.styleName;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageSelectorProperty = BindableProperty.Create("BackgroundImageSelector", typeof(Selector<string>), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;

            if (newValue == null)
            {
                viewStyle.backgroundImageSelector = null;
            }
            else
            {
                viewStyle.backgroundImageSelector = ((Selector<string>)newValue).Clone();
                viewStyle.backgroundColorSelector = null;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.backgroundImageSelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StateProperty = BindableProperty.Create(nameof(State), typeof(View.States?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.state = (View.States?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.state;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SubStateProperty = BindableProperty.Create(nameof(SubState), typeof(View.States?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.subState = (View.States?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.subState;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FlexProperty = BindableProperty.Create(nameof(Flex), typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.flex = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.flex;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AlignSelfProperty = BindableProperty.Create(nameof(AlignSelf), typeof(int?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.alignSelf = (int?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.alignSelf;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FlexMarginProperty = BindableProperty.Create(nameof(FlexMargin), typeof(Vector4), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.flexMargin = (Vector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.flexMargin;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CellIndexProperty = BindableProperty.Create(nameof(CellIndex), typeof(Vector2), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.cellIndex = (Vector2)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.cellIndex;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RowSpanProperty = BindableProperty.Create(nameof(RowSpan), typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.rowSpan = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.rowSpan;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ColumnSpanProperty = BindableProperty.Create(nameof(ColumnSpan), typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.columnSpan = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.columnSpan;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CellHorizontalAlignmentProperty = BindableProperty.Create(nameof(CellHorizontalAlignment), typeof(HorizontalAlignmentType?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.cellHorizontalAlignment = (HorizontalAlignmentType?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.cellHorizontalAlignment;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CellVerticalAlignmentProperty = BindableProperty.Create(nameof(CellVerticalAlignment), typeof(VerticalAlignmentType?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.cellVerticalAlignment = (VerticalAlignmentType?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.cellVerticalAlignment;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LeftFocusableViewProperty = BindableProperty.Create(nameof(LeftFocusableView), typeof(View), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.leftFocusableView = (View)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.leftFocusableView;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RightFocusableViewProperty = BindableProperty.Create(nameof(RightFocusableView), typeof(View), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.rightFocusableView = (View)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.rightFocusableView;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UpFocusableViewProperty = BindableProperty.Create(nameof(UpFocusableView), typeof(View), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.upFocusableView = (View)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.upFocusableView;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DownFocusableViewProperty = BindableProperty.Create(nameof(DownFocusableView), typeof(View), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.downFocusableView = (View)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.downFocusableView;
        });

        /// <summary> Bindable property of FocusableChildren. Please do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FocusableChildrenProperty = BindableProperty.Create(nameof(FocusableChildren), typeof(bool?), typeof(ViewStyle), true,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).focusableChildren = (bool?)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).focusableChildren
        );


        /// <summary> Bindable property of FocusableInTouch. Please do not open it. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FocusableInTouchProperty = BindableProperty.Create(nameof(FocusableInTouch), typeof(bool?), typeof(ViewStyle), null,
            propertyChanged: (bindable, oldValue, newValue) => ((ViewStyle)bindable).focusableInTouch = (bool?)newValue,
            defaultValueCreator: (bindable) => ((ViewStyle)bindable).focusableInTouch
        );
        
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FocusableProperty = BindableProperty.Create(nameof(Focusable), typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.focusable = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.focusable;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OpacitySelectorProperty = BindableProperty.Create("OpacitySelector", typeof(Selector<float?>), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((ViewStyle)bindable).opacitySelector = ((Selector<float?>)newValue)?.Clone();
        },
        defaultValueCreator: (bindable) =>
        {
            var controlStyle = (ViewStyle)bindable;
            return controlStyle.opacitySelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionUsesPivotPointProperty = BindableProperty.Create(nameof(PositionUsesPivotPoint), typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.positionUsesPivotPoint = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.positionUsesPivotPoint;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SiblingOrderProperty = BindableProperty.Create(nameof(SiblingOrder), typeof(int?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.siblingOrder = (int?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.siblingOrder;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ParentOriginProperty = BindableProperty.Create(nameof(ParentOrigin), typeof(Position), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.parentOrigin = (Position)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.parentOrigin;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PivotPointProperty = BindableProperty.Create(nameof(PivotPoint), typeof(Position), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.pivotPoint = (Position)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.pivotPoint;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionZProperty = BindableProperty.Create(nameof(PositionZ), typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            if (newValue != null)
            {
                if (viewStyle.position == null)
                {
                    if ((float)newValue == 0) return;
                }
                viewStyle.position = new Position(viewStyle.Position?.X ?? 0, viewStyle.Position?.Y ?? 0, (float)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ViewStyle)bindable).position?.Z;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OrientationProperty = BindableProperty.Create(nameof(Orientation), typeof(Rotation), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.orientation = (Rotation)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.orientation;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleProperty = BindableProperty.Create(nameof(Scale), typeof(Vector3), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.scale = (Vector3)newValue;
            if (viewStyle.scale != null && viewStyle.scale.X == 1.0f && viewStyle.scale.Y == 1.0f && viewStyle.scale.Z == 1.0f) return;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.scale;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleXProperty = BindableProperty.Create(nameof(ScaleX), typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            if (newValue != null)
            {
                if (viewStyle.scale == null)
                {
                    if ((float)newValue == 1.0f) return;
                }
                viewStyle.scale = new Vector3((float)newValue, viewStyle.scale?.Y ?? 0, viewStyle.scale?.Z ?? 0);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ViewStyle)bindable).scale?.X;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleYProperty = BindableProperty.Create(nameof(ScaleY), typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            if (newValue != null)
            {
                if (viewStyle.scale == null)
                {
                    if ((float)newValue == 1.0f) return;
                }
                viewStyle.scale = new Vector3(viewStyle.scale?.X ?? 0, (float)newValue, viewStyle.scale?.Z ?? 0);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ViewStyle)bindable).scale?.Y;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleZProperty = BindableProperty.Create(nameof(ScaleZ), typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            if (newValue != null)
            {
                if (viewStyle.scale == null)
                {
                    if ((float)newValue == 1.0f) return;
                }
                viewStyle.scale = new Vector3(viewStyle.scale?.X ?? 0, viewStyle.scale?.Y ?? 0, (float)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ViewStyle)bindable).scale?.Z;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.name = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.name;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SensitiveProperty = BindableProperty.Create(nameof(Sensitive), typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.sensitive = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.sensitive;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LeaveRequiredProperty = BindableProperty.Create(nameof(LeaveRequired), typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.leaveRequired = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.leaveRequired;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InheritOrientationProperty = BindableProperty.Create(nameof(InheritOrientation), typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.inheritOrientation = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.inheritOrientation;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InheritScaleProperty = BindableProperty.Create(nameof(InheritScale), typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.inheritScale = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.inheritScale;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DrawModeProperty = BindableProperty.Create(nameof(DrawMode), typeof(DrawModeType?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.drawMode = (DrawModeType?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.drawMode;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeModeFactorProperty = BindableProperty.Create(nameof(SizeModeFactor), typeof(Vector3), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.sizeModeFactor = (Vector3)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.sizeModeFactor;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WidthResizePolicyProperty = BindableProperty.Create(nameof(WidthResizePolicy), typeof(ResizePolicyType?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.widthResizePolicy = (ResizePolicyType?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.widthResizePolicy;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HeightResizePolicyProperty = BindableProperty.Create(nameof(HeightResizePolicy), typeof(ResizePolicyType?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.heightResizePolicy = (ResizePolicyType?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.heightResizePolicy;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeScalePolicyProperty = BindableProperty.Create(nameof(SizeScalePolicy), typeof(SizeScalePolicyType?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.sizeScalePolicy = (SizeScalePolicyType?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.sizeScalePolicy;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WidthForHeightProperty = BindableProperty.Create(nameof(WidthForHeight), typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.widthForHeight = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.widthForHeight;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HeightForWidthProperty = BindableProperty.Create(nameof(HeightForWidth), typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.heightForWidth = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.heightForWidth;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PaddingProperty = BindableProperty.Create(nameof(Padding), typeof(Extents), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            if (null == viewStyle.padding) viewStyle.padding = new Extents(viewStyle.OnPaddingChanged, 0, 0, 0, 0);
            viewStyle.padding.CopyFrom(null == newValue ? new Extents() : (Extents)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.padding;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinimumSizeProperty = BindableProperty.Create(nameof(MinimumSize), typeof(Size2D), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.minimumSize = (Size2D)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.minimumSize;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaximumSizeProperty = BindableProperty.Create(nameof(MaximumSize), typeof(Size2D), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.maximumSize = (Size2D)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.maximumSize;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InheritPositionProperty = BindableProperty.Create(nameof(InheritPosition), typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.inheritPosition = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.inheritPosition;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ClippingModeProperty = BindableProperty.Create(nameof(ClippingMode), typeof(ClippingModeType?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.clippingMode = (ClippingModeType?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.clippingMode;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InheritLayoutDirectionProperty = BindableProperty.Create(nameof(InheritLayoutDirection), typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.inheritLayoutDirection = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.inheritLayoutDirection;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LayoutDirectionProperty = BindableProperty.Create(nameof(LayoutDirection), typeof(ViewLayoutDirectionType?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.layoutDirection = (ViewLayoutDirectionType?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.layoutDirection;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MarginProperty = BindableProperty.Create(nameof(Margin), typeof(Extents), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            if (null == viewStyle.margin) viewStyle.margin = new Extents(viewStyle.OnMarginChanged, 0, 0, 0, 0);
            viewStyle.margin.CopyFrom(null == newValue ? new Extents() : (Extents)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.margin;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WeightProperty = BindableProperty.Create(nameof(Weight), typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.weight = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.weight;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundColorSelectorProperty = BindableProperty.Create("BackgroundColorSelector", typeof(Selector<Color>), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            
            if (newValue == null)
            {
                viewStyle.backgroundColorSelector = null;
            }
            else
            {
                viewStyle.backgroundColorSelector = ((Selector<Color>)newValue).Clone();
                viewStyle.backgroundImageSelector = null;
            }
            
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.backgroundColorSelector;
        });

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ColorSelectorProperty = BindableProperty.Create("ColorSelector", typeof(Selector<Color>), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((ViewStyle)bindable).colorSelector = ((Selector<Color>)newValue)?.Clone();
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.colorSelector;
        });

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageBorderSelectorProperty = BindableProperty.Create("BackgroundImageBorderSelector", typeof(Selector<Rectangle>), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((ViewStyle)bindable).backgroundImageBorderSelector = ((Selector<Rectangle>)newValue)?.Clone();
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.backgroundImageBorderSelector;
        });

        /// A BindableProperty for ImageShadow
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageShadowSelectorProperty = BindableProperty.Create("ImageShadowSelector", typeof(Selector<ImageShadow>), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;

            viewStyle.imageShadow = ((Selector<ImageShadow>)newValue)?.Clone();

            if (viewStyle.imageShadow != null)
            {
                viewStyle.boxShadow = null;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.imageShadow;
        });

        /// A BindableProperty for BoxShadow
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BoxShadowSelectorProperty = BindableProperty.Create("BoxShadowSelector", typeof(Selector<Shadow>), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;

            viewStyle.boxShadow = ((Selector<Shadow>)newValue)?.Clone();

            if (viewStyle.boxShadow != null)
            {
                viewStyle.imageShadow = null;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.boxShadow;
        });

        /// A BindableProperty for CornerRadius
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create("CornerRadiusSelector", typeof(Selector<float?>), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((ViewStyle)bindable).cornerRadius = ((Selector<float?>)(newValue))?.Clone();
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.cornerRadius;
        });

        /// <summary>
        /// EnableControlState property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableControlStateProperty = BindableProperty.Create(nameof(EnableControlState), typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((ViewStyle)bindable).enableControlState = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ViewStyle)bindable).enableControlState;
        });

        /// <summary>
        /// EnableControlState property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThemeChangeSensitiveProperty = BindableProperty.Create("ThemeChangeSensitive", typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((ViewStyle)bindable).themeChangeSensitive = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            return ((ViewStyle)bindable).themeChangeSensitive;
        });
    }
}
