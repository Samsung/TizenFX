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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StyleNameProperty = BindableProperty.Create("StyleName", typeof(string), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty BackgroundImageProperty = BindableProperty.Create("BackgroundImage", typeof(string), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.backgroundImage = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.backgroundImage;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StateProperty = BindableProperty.Create("State", typeof(View.States?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty SubStateProperty = BindableProperty.Create("SubState", typeof(View.States?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty FlexProperty = BindableProperty.Create("Flex", typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty AlignSelfProperty = BindableProperty.Create("AlignSelf", typeof(int?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty FlexMarginProperty = BindableProperty.Create("FlexMargin", typeof(Vector4), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty CellIndexProperty = BindableProperty.Create("CellIndex", typeof(Vector2), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty RowSpanProperty = BindableProperty.Create("RowSpan", typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty ColumnSpanProperty = BindableProperty.Create("ColumnSpan", typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty CellHorizontalAlignmentProperty = BindableProperty.Create("CellHorizontalAlignment", typeof(HorizontalAlignmentType?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty CellVerticalAlignmentProperty = BindableProperty.Create("CellVerticalAlignment", typeof(VerticalAlignmentType?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty LeftFocusableViewProperty = BindableProperty.Create("LeftFocusableView", typeof(View), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty RightFocusableViewProperty = BindableProperty.Create("RightFocusableView", typeof(View), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty UpFocusableViewProperty = BindableProperty.Create("UpFocusableView", typeof(View), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty DownFocusableViewProperty = BindableProperty.Create("DownFocusableView", typeof(View), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty FocusableProperty = BindableProperty.Create("Focusable", typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty Size2DProperty = BindableProperty.Create("Size2D", typeof(Size2D), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty OpacitySelectorProperty = BindableProperty.Create("OpacitySelector", typeof(Selector<float?>), typeof(ViewStyle), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.OpacitySelector.Clone((Selector<float?>)newValue);
        }),
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.OpacitySelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty Position2DProperty = BindableProperty.Create("Position2D", typeof(Position2D), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty PositionUsesPivotPointProperty = BindableProperty.Create("PositionUsesPivotPoint", typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty SiblingOrderProperty = BindableProperty.Create("SiblingOrder", typeof(int?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty ParentOriginProperty = BindableProperty.Create("ParentOrigin", typeof(Position), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty PivotPointProperty = BindableProperty.Create("PivotPoint", typeof(Position), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty SizeWidthProperty = BindableProperty.Create("SizeWidth", typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty SizeHeightProperty = BindableProperty.Create("SizeHeight", typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty PositionProperty = BindableProperty.Create("Position", typeof(Position), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty PositionXProperty = BindableProperty.Create("PositionX", typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty PositionYProperty = BindableProperty.Create("PositionY", typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty PositionZProperty = BindableProperty.Create("PositionZ", typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty OrientationProperty = BindableProperty.Create("Orientation", typeof(Rotation), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty ScaleProperty = BindableProperty.Create("Scale", typeof(Vector3), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty ScaleXProperty = BindableProperty.Create("ScaleX", typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty ScaleYProperty = BindableProperty.Create("ScaleY", typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty ScaleZProperty = BindableProperty.Create("ScaleZ", typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty NameProperty = BindableProperty.Create("Name", typeof(string), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty SensitiveProperty = BindableProperty.Create("Sensitive", typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty LeaveRequiredProperty = BindableProperty.Create("LeaveRequired", typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty InheritOrientationProperty = BindableProperty.Create("InheritOrientation", typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty InheritScaleProperty = BindableProperty.Create("InheritScale", typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty DrawModeProperty = BindableProperty.Create("DrawMode", typeof(DrawModeType?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty SizeModeFactorProperty = BindableProperty.Create("SizeModeFactor", typeof(Vector3), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty WidthResizePolicyProperty = BindableProperty.Create("WidthResizePolicy", typeof(ResizePolicyType?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty HeightResizePolicyProperty = BindableProperty.Create("HeightResizePolicy", typeof(ResizePolicyType?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty SizeScalePolicyProperty = BindableProperty.Create("SizeScalePolicy", typeof(SizeScalePolicyType?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty WidthForHeightProperty = BindableProperty.Create("WidthForHeight", typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty HeightForWidthProperty = BindableProperty.Create("HeightForWidth", typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty PaddingProperty = BindableProperty.Create("Padding", typeof(Extents), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            if (null == viewStyle.padding)
            {
                viewStyle.padding = new Extents((ushort start, ushort end, ushort top, ushort bottom) =>
                {
                    Extents extents = new Extents(start, end, top, bottom);
                    viewStyle.padding.CopyFrom(extents);
                    viewStyle.SetValue(PaddingProperty, extents);
                }, 0, 0, 0, 0);
            }
            viewStyle.padding.CopyFrom((Extents)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;

            if (null == viewStyle.padding)
            {
                viewStyle.padding = new Extents((ushort start, ushort end, ushort top, ushort bottom) =>
                {
                    Extents extents = new Extents(start, end, top, bottom);
                    viewStyle.padding.CopyFrom(extents);
                    viewStyle.SetValue(PaddingProperty, extents);
                }, 0, 0, 0, 0);
            }

            return viewStyle.padding;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinimumSizeProperty = BindableProperty.Create("MinimumSize", typeof(Size2D), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty MaximumSizeProperty = BindableProperty.Create("MaximumSize", typeof(Size2D), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty InheritPositionProperty = BindableProperty.Create("InheritPosition", typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty ClippingModeProperty = BindableProperty.Create("ClippingMode", typeof(ClippingModeType?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty SizeProperty = BindableProperty.Create("Size", typeof(Size), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty InheritLayoutDirectionProperty = BindableProperty.Create("InheritLayoutDirection", typeof(bool?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty LayoutDirectionProperty = BindableProperty.Create("LayoutDirection", typeof(ViewLayoutDirectionType?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty MarginProperty = BindableProperty.Create("Margin", typeof(Extents), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (ViewStyle)bindable;
            viewStyle.margin = (Extents)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;

            if (null == viewStyle.padding)
            {
                viewStyle.margin = new Extents((ushort start, ushort end, ushort top, ushort bottom) =>
                {
                    Extents extents = new Extents(start, end, top, bottom);
                    viewStyle.margin.CopyFrom(extents);
                    viewStyle.SetValue(MarginProperty, extents);
                }, 0, 0, 0, 0);
            }

            return viewStyle.margin;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WeightProperty = BindableProperty.Create("Weight", typeof(float?), typeof(ViewStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
            viewStyle.BackgroundColorSelector.Clone((Selector<Color>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (ViewStyle)bindable;
            return viewStyle.BackgroundColorSelector;
        });

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewStyle()
        {
        }

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
            get
            {
                string temp = (string)GetValue(StyleNameProperty);
                return temp;
            }
            set
            {
                SetValue(StyleNameProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BackgroundImage
        {
            get
            {
                string temp = (string)GetValue(BackgroundImageProperty);
                return temp;
            }
            set
            {
                SetValue(BackgroundImageProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View.States? State
        {
            get
            {
                View.States? temp = (View.States?)GetValue(StateProperty);
                return temp;
            }
            set
            {
                SetValue(StateProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View.States? SubState
        {
            get
            {
                View.States? temp = (View.States?)GetValue(SubStateProperty);
                return temp;
            }
            set
            {
                SetValue(SubStateProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? Flex
        {
            get
            {
                float? temp = (float?)GetValue(FlexProperty);
                return temp;
            }
            set
            {
                SetValue(FlexProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? AlignSelf
        {
            get
            {
                int? temp = (int?)GetValue(AlignSelfProperty);
                return temp;
            }
            set
            {
                SetValue(AlignSelfProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 FlexMargin
        {
            get
            {
                Vector4 temp = (Vector4)GetValue(FlexMarginProperty);
                return temp;
            }
            set
            {
                SetValue(FlexMarginProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 CellIndex
        {
            get
            {
                Vector2 temp = (Vector2)GetValue(CellIndexProperty);
                return temp;
            }
            set
            {
                SetValue(CellIndexProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? RowSpan
        {
            get
            {
                float? temp = (float?)GetValue(RowSpanProperty);
                return temp;
            }
            set
            {
                SetValue(RowSpanProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ColumnSpan
        {
            get
            {
                float? temp = (float?)GetValue(ColumnSpanProperty);
                return temp;
            }
            set
            {
                SetValue(ColumnSpanProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HorizontalAlignmentType? CellHorizontalAlignment
        {
            get
            {
                HorizontalAlignmentType? temp = (HorizontalAlignmentType?)GetValue(CellHorizontalAlignmentProperty);
                return temp;
            }
            set
            {
                SetValue(CellHorizontalAlignmentProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalAlignmentType? CellVerticalAlignment
        {
            get
            {
                VerticalAlignmentType? temp = (VerticalAlignmentType?)GetValue(CellVerticalAlignmentProperty);
                return temp;
            }
            set
            {
                SetValue(CellVerticalAlignmentProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View LeftFocusableView
        {
            get
            {
                View temp = (View)GetValue(LeftFocusableViewProperty);
                return temp;
            }
            set
            {
                SetValue(LeftFocusableViewProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View RightFocusableView
        {
            get
            {
                View temp = (View)GetValue(RightFocusableViewProperty);
                return temp;
            }
            set
            {
                SetValue(RightFocusableViewProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View UpFocusableView
        {
            get
            {
                View temp = (View)GetValue(UpFocusableViewProperty);
                return temp;
            }
            set
            {
                SetValue(UpFocusableViewProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View DownFocusableView
        {
            get
            {
                View temp = (View)GetValue(DownFocusableViewProperty);
                return temp;
            }
            set
            {
                SetValue(DownFocusableViewProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Focusable
        {
            get
            {
                bool? temp = (bool?)GetValue(FocusableProperty);
                return temp;
            }
            set
            {
                SetValue(FocusableProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D Size2D
        {
            get
            {
                Size2D temp = (Size2D)GetValue(Size2DProperty);
                return temp;
            }
            set
            {
                SetValue(Size2DProperty, value);
            }
        }

        private Selector<float?> opacitySelector;
        private Selector<float?> OpacitySelector
        {
            get
            {
                if (null == opacitySelector)
                {
                    opacitySelector = new Selector<float?>();
                }
                return opacitySelector;
            }
        }
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<float?> Opacity
        {
            get
            {
                return (Selector<float?>)GetValue(OpacitySelectorProperty);
            }
            set
            {
                SetValue(OpacitySelectorProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position2D Position2D
        {
            get
            {
                Position2D temp = (Position2D)GetValue(Position2DProperty);
                return temp;
            }
            set
            {
                SetValue(Position2DProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? PositionUsesPivotPoint
        {
            get
            {
                bool? temp = (bool?)GetValue(PositionUsesPivotPointProperty);
                return temp;
            }
            set
            {
                SetValue(PositionUsesPivotPointProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? SiblingOrder
        {
            get
            {
                int? temp = (int?)GetValue(SiblingOrderProperty);
                return temp;
            }
            set
            {
                SetValue(SiblingOrderProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position ParentOrigin
        {
            get
            {
                Position temp = (Position)GetValue(ParentOriginProperty);
                return temp;
            }
            set
            {
                SetValue(ParentOriginProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position PivotPoint
        {
            get
            {
                Position temp = (Position)GetValue(PivotPointProperty);
                return temp;
            }
            set
            {
                SetValue(PivotPointProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? SizeWidth
        {
            get
            {
                float? temp = (float?)GetValue(SizeWidthProperty);
                return temp;
            }
            set
            {
                SetValue(SizeWidthProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? SizeHeight
        {
            get
            {
                float? temp = (float?)GetValue(SizeHeightProperty);
                return temp;
            }
            set
            {
                SetValue(SizeHeightProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position Position
        {
            get
            {
                Position temp = (Position)GetValue(PositionProperty);
                return temp;
            }
            set
            {
                SetValue(PositionProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PositionX
        {
            get
            {
                float? temp = (float?)GetValue(PositionXProperty);
                return temp;
            }
            set
            {
                SetValue(PositionXProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PositionY
        {
            get
            {
                float? temp = (float?)GetValue(PositionYProperty);
                return temp;
            }
            set
            {
                SetValue(PositionYProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PositionZ
        {
            get
            {
                float? temp = (float?)GetValue(PositionZProperty);
                return temp;
            }
            set
            {
                SetValue(PositionZProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rotation Orientation
        {
            get
            {
                Rotation temp = (Rotation)GetValue(OrientationProperty);
                return temp;
            }
            set
            {
                SetValue(OrientationProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 Scale
        {
            get
            {
                Vector3 temp = (Vector3)GetValue(ScaleProperty);
                return temp;
            }
            set
            {
                SetValue(ScaleProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScaleX
        {
            get
            {
                float? temp = (float?)GetValue(ScaleXProperty);
                return temp;
            }
            set
            {
                SetValue(ScaleXProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScaleY
        {
            get
            {
                float? temp = (float?)GetValue(ScaleYProperty);
                return temp;
            }
            set
            {
                SetValue(ScaleYProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScaleZ
        {
            get
            {
                float? temp = (float?)GetValue(ScaleZProperty);
                return temp;
            }
            set
            {
                SetValue(ScaleZProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name
        {
            get
            {
                string temp = (string)GetValue(NameProperty);
                return temp;
            }
            set
            {
                SetValue(NameProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Sensitive
        {
            get
            {
                bool? temp = (bool?)GetValue(SensitiveProperty);
                return temp;
            }
            set
            {
                SetValue(SensitiveProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? LeaveRequired
        {
            get
            {
                bool? temp = (bool?)GetValue(LeaveRequiredProperty);
                return temp;
            }
            set
            {
                SetValue(LeaveRequiredProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? InheritOrientation
        {
            get
            {
                bool? temp = (bool?)GetValue(InheritOrientationProperty);
                return temp;
            }
            set
            {
                SetValue(InheritOrientationProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? InheritScale
        {
            get
            {
                bool? temp = (bool?)GetValue(InheritScaleProperty);
                return temp;
            }
            set
            {
                SetValue(InheritScaleProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DrawModeType? DrawMode
        {
            get
            {
                DrawModeType? temp = (DrawModeType?)GetValue(DrawModeProperty);
                return temp;
            }
            set
            {
                SetValue(DrawModeProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector3 SizeModeFactor
        {
            get
            {
                Vector3 temp = (Vector3)GetValue(SizeModeFactorProperty);
                return temp;
            }
            set
            {
                SetValue(SizeModeFactorProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResizePolicyType? WidthResizePolicy
        {
            get
            {
                ResizePolicyType? temp = (ResizePolicyType?)GetValue(WidthResizePolicyProperty);
                return temp;
            }
            set
            {
                SetValue(WidthResizePolicyProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResizePolicyType? HeightResizePolicy
        {
            get
            {
                ResizePolicyType? temp = (ResizePolicyType?)GetValue(HeightResizePolicyProperty);
                return temp;
            }
            set
            {
                SetValue(HeightResizePolicyProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SizeScalePolicyType? SizeScalePolicy
        {
            get
            {
                SizeScalePolicyType? temp = (SizeScalePolicyType?)GetValue(SizeScalePolicyProperty);
                return temp;
            }
            set
            {
                SetValue(SizeScalePolicyProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? WidthForHeight
        {
            get
            {
                bool? temp = (bool?)GetValue(WidthForHeightProperty);
                return temp;
            }
            set
            {
                SetValue(WidthForHeightProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? HeightForWidth
        {
            get
            {
                bool? temp = (bool?)GetValue(HeightForWidthProperty);
                return temp;
            }
            set
            {
                SetValue(HeightForWidthProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents Padding
        {
            get
            {
                Extents temp = (Extents)GetValue(PaddingProperty);
                return temp;
            }
            set
            {
                SetValue(PaddingProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D MinimumSize
        {
            get
            {
                Size2D temp = (Size2D)GetValue(MinimumSizeProperty);
                return temp;
            }
            set
            {
                SetValue(MinimumSizeProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D MaximumSize
        {
            get
            {
                Size2D temp = (Size2D)GetValue(MaximumSizeProperty);
                return temp;
            }
            set
            {
                SetValue(MaximumSizeProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? InheritPosition
        {
            get
            {
                bool? temp = (bool?)GetValue(InheritPositionProperty);
                return temp;
            }
            set
            {
                SetValue(InheritPositionProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ClippingModeType? ClippingMode
        {
            get
            {
                ClippingModeType? temp = (ClippingModeType?)GetValue(ClippingModeProperty);
                return temp;
            }
            set
            {
                SetValue(ClippingModeProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size Size
        {
            get
            {
                Size temp = (Size)GetValue(SizeProperty);
                return temp;
            }
            set
            {
                SetValue(SizeProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? InheritLayoutDirection
        {
            get
            {
                bool? temp = (bool?)GetValue(InheritLayoutDirectionProperty);
                return temp;
            }
            set
            {
                SetValue(InheritLayoutDirectionProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewLayoutDirectionType? LayoutDirection
        {
            get
            {
                ViewLayoutDirectionType? temp = (ViewLayoutDirectionType?)GetValue(LayoutDirectionProperty);
                return temp;
            }
            set
            {
                SetValue(LayoutDirectionProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents Margin
        {
            get
            {
                Extents temp = (Extents)GetValue(MarginProperty);
                return temp;
            }
            set
            {
                SetValue(MarginProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? Weight
        {
            get
            {
                float? temp = (float?)GetValue(WeightProperty);
                return temp;
            }
            set
            {
                SetValue(WeightProperty, value);
            }
        }

        private Selector<Color> backgroundColorSelector;
        private Selector<Color> BackgroundColorSelector
        {
            get
            {
                if (null == backgroundColorSelector)
                {
                    backgroundColorSelector = new Selector<Color>();
                }
                return backgroundColorSelector;
            }
        }
        /// <summary>
        /// View BackgroundColor
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Color> BackgroundColor
        {
            get
            {
                return (Selector<Color>)GetValue(BackgroundColorSelectorProperty);
            }
            set
            {
                SetValue(BackgroundColorSelectorProperty, value);
            }
        }
    }
}
