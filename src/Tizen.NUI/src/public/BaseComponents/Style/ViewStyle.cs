/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
    public class ViewStyle : BindableObject
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
            if (null == viewStyle.backgroundImageSelector) viewStyle.backgroundImageSelector = new Selector<string>();
            viewStyle.backgroundImageSelector.Clone(null == newValue ? new Selector<string>() : (Selector<string>)newValue);
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
            viewStyle.size2D = (Size2D)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.size2D;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OpacitySelectorProperty = BindableProperty.Create("OpacitySelector", typeof(Selector<float?>), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            if (null == viewStyle.opacitySelector) viewStyle.opacitySelector = new Selector<float?>();
            viewStyle.opacitySelector.Clone(null == newValue ? new Selector<float?>() : (Selector<float?>)newValue);
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
            viewStyle.position2D = (Position2D)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.position2D;
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
            viewStyle.sizeWidth = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.sizeWidth;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeHeightProperty = BindableProperty.Create(nameof(SizeHeight), typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.sizeHeight = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.sizeHeight;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionProperty = BindableProperty.Create(nameof(Position), typeof(Position), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.position = (Position)newValue;
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
            viewStyle.positionX = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.positionX;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionYProperty = BindableProperty.Create(nameof(PositionY), typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.positionY = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.positionY;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionZProperty = BindableProperty.Create(nameof(PositionZ), typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.positionZ = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.positionZ;
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
            viewStyle.scaleX = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.scaleX;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleYProperty = BindableProperty.Create(nameof(ScaleY), typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.scaleY = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.scaleY;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleZProperty = BindableProperty.Create(nameof(ScaleZ), typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.scaleZ = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.scaleZ;
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
            if (null == viewStyle.backgroundColorSelector) viewStyle.backgroundColorSelector = new Selector<Color>();
            viewStyle.backgroundColorSelector.Clone(null == newValue ? new Selector<Color>() : (Selector<Color>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.backgroundColorSelector;
        });

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ColorSelectorProperty = BindableProperty.Create("ColorSelector", typeof(Selector<Color>), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            if (null == viewStyle.colorSelector) viewStyle.colorSelector = new Selector<Color>();
            viewStyle.colorSelector.Clone(null == newValue ? new Selector<Color>() : (Selector<Color>)newValue);
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
            var viewStyle = (ViewStyle)bindable;
            if (null == viewStyle.backgroundImageBorderSelector) viewStyle.backgroundImageBorderSelector = new Selector<Rectangle>();

            viewStyle.backgroundImageBorderSelector.Clone(newValue == null ? new Selector<Rectangle>() : (Selector<Rectangle>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.backgroundImageBorderSelector;
        });

        /// A BindableProperty for ImageShadow
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageShadowProperty = BindableProperty.Create(nameof(ImageShadow), typeof(Selector<ImageShadow>), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.imageShadow = SelectorHelper.CopyCloneable<ImageShadow>(newValue);

            if (viewStyle.imageShadow != null) viewStyle.boxShadow = null;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.imageShadow;
        });

        /// A BindableProperty for BoxShadow
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BoxShadowProperty = BindableProperty.Create(nameof(BoxShadow), typeof(Selector<ImageShadow>), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.boxShadow = SelectorHelper.CopyCloneable<Shadow>(newValue);

            if (viewStyle.boxShadow != null) viewStyle.imageShadow = null;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.boxShadow;
        });

        /// A BindableProperty for CornerRadius
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(Selector<float?>), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.cornerRadius = SelectorHelper.CopyValue<float?>(newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.cornerRadius;
        });

        private string styleName;
        private string backgroundImage;
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
        private Size2D size2D;
        private Position2D position2D;
        private bool? positionUsesPivotPoint;
        private int? siblingOrder;
        private Position parentOrigin;
        private Position pivotPoint;
        private float? sizeWidth;
        private float? sizeHeight;
        private Position position;
        private float? positionX;
        private float? positionY;
        private float? positionZ;
        private Rotation orientation;
        private Vector3 scale;
        private float? scaleX;
        private float? scaleY;
        private float? scaleZ;
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
            if (null != viewAttributes)
            {
                this.CopyFrom(viewAttributes);
            }
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
                return (null != tmp) ? tmp : size = new Size((float width, float height, float depth) => { Size = new Size(width, height, depth); }, 0, 0, 0);
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
        /// The mutually exclusive with "BoxShadow".
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<ImageShadow> ImageShadow
        {
            get => (Selector<ImageShadow>)GetValue(ImageShadowProperty);
            set => SetValue(ImageShadowProperty, value);
        }

        /// <summary>
        /// Describes a box shaped shadow drawing for a View.
        /// It is null by default.
        /// </summary>
        /// <remarks>
        /// The mutually exclusive with "ImageShadow".
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Shadow> BoxShadow
        {
            get => (Selector<Shadow>)GetValue(BoxShadowProperty);
            set => SetValue(BoxShadowProperty, value);
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

        internal ViewStyle CreateInstance()
        {
            return (ViewStyle)Activator.CreateInstance(GetType());;
        }

        internal ViewStyle Clone()
        {
            var cloned = CreateInstance();
            cloned.CopyFrom(this);

            return cloned;
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
