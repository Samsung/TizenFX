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
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// The View layout Direction type.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum ViewLayoutDirectionType
    {
        /// <summary>
        /// Left to right.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        LTR,
        /// <summary>
        /// Right to left.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        RTL
    }

    /// <summary>
    /// [Draft] Available policies for layout parameters
    /// </summary>
    public static class LayoutParamPolicies
    {
        /// <summary>
        /// Constant which indicates child size should match parent size
        /// </summary>
        public const int MatchParent = -1;
        /// <summary>
        /// Constant which indicates parent should take the smallest size possible to wrap it's children with their desired size
        /// </summary>
        public const int WrapContent = -2;
    }

    /// <summary>
    /// [Draft] Replaced by LayoutParamPolicies, will be removed once occurrences replaced.
    /// </summary>
    internal enum ChildLayoutData
    {
        /// <summary>
        /// Constant which indicates child size should match parent size
        /// </summary>
        MatchParent = LayoutParamPolicies.MatchParent,
        /// <summary>
        /// Constant which indicates parent should take the smallest size possible to wrap it's children with their desired size
        /// </summary>
        WrapContent = LayoutParamPolicies.WrapContent,
    }

    internal enum ResourceLoadingStatusType
    {
        Invalid = -1,
        Preparing = 0,
        Ready,
        Failed,
    }

    /// <summary>
    /// View is the base class for all views.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class View : Container, IResourcesProvider
    {
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StyleNameProperty = BindableProperty.Create("StyleName", typeof(string), typeof(View), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.STYLE_NAME, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.STYLE_NAME).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create("BackgroundColor", typeof(Color), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.BACKGROUND, new Tizen.NUI.PropertyValue((Color)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Color backgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);

            Tizen.NUI.PropertyMap background = view.Background;
            int visualType = 0;
            background.Find(Visual.Property.Type)?.Get(out visualType);
            if (visualType == (int)Visual.Type.Color)
            {
                background.Find(ColorVisualProperty.MixColor)?.Get(backgroundColor);
            }

            return backgroundColor;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageProperty = BindableProperty.Create("BackgroundImage", typeof(string), typeof(View), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.BACKGROUND, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            string backgroundImage = "";

            Tizen.NUI.PropertyMap background = view.Background;
            int visualType = 0;
            background.Find(Visual.Property.Type)?.Get(out visualType);
            if (visualType == (int)Visual.Type.Image)
            {
                background.Find(ImageVisualProperty.URL)?.Get(out backgroundImage);
            }

            return backgroundImage;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundProperty = BindableProperty.Create("Background", typeof(PropertyMap), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.BACKGROUND, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.BACKGROUND).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StateProperty = BindableProperty.Create("State", typeof(States), typeof(View), States.Normal, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.STATE, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            int temp = 0;
            if (Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.STATE).Get(out temp) == false)
            {
                NUILog.Error("State get error!");
            }
            switch (temp)
            {
                case 0: return States.Normal;
                case 1: return States.Focused;
                case 2: return States.Disabled;
                default: return States.Normal;
            }
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SubStateProperty = BindableProperty.Create("SubState", typeof(States), typeof(View), States.Normal, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            string valueToString = "";
            if (newValue != null)
            {
                switch ((States)newValue)
                {
                    case States.Normal: { valueToString = "NORMAL"; break; }
                    case States.Focused: { valueToString = "FOCUSED"; break; }
                    case States.Disabled: { valueToString = "DISABLED"; break; }
                    default: { valueToString = "NORMAL"; break; }
                }
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.SUB_STATE, new Tizen.NUI.PropertyValue(valueToString));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.SUB_STATE).Get(out temp) == false)
            {
                NUILog.Error("subState get error!");
            }
            switch (temp)
            {
                case "NORMAL": return States.Normal;
                case "FOCUSED": return States.Focused;
                case "DISABLED": return States.Disabled;
                default: return States.Normal;
            }
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TooltipProperty = BindableProperty.Create("Tooltip", typeof(PropertyMap), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.TOOLTIP, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.TOOLTIP).Get(temp);
            return temp;
        });

        /// Only for XAML property binding. This will be changed as Inhouse API by ACR later.
        public static readonly BindableProperty FlexProperty = BindableProperty.Create("Flex", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, FlexContainer.ChildProperty.FLEX, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, FlexContainer.ChildProperty.FLEX).Get(out temp);
            return temp;
        });

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AlignSelfProperty = BindableProperty.Create("AlignSelf", typeof(int), typeof(View), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, FlexContainer.ChildProperty.ALIGN_SELF, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, FlexContainer.ChildProperty.ALIGN_SELF).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FlexMarginProperty = BindableProperty.Create("FlexMargin", typeof(Vector4), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, FlexContainer.ChildProperty.FLEX_MARGIN, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(view.swigCPtr, FlexContainer.ChildProperty.FLEX_MARGIN).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CellIndexProperty = BindableProperty.Create("CellIndex", typeof(Vector2), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, TableView.ChildProperty.CELL_INDEX, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(view.swigCPtr, TableView.ChildProperty.CELL_INDEX).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RowSpanProperty = BindableProperty.Create("RowSpan", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, TableView.ChildProperty.ROW_SPAN, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, TableView.ChildProperty.ROW_SPAN).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ColumnSpanProperty = BindableProperty.Create("ColumnSpan", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, TableView.ChildProperty.COLUMN_SPAN, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, TableView.ChildProperty.COLUMN_SPAN).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CellHorizontalAlignmentProperty = BindableProperty.Create("CellHorizontalAlignment", typeof(HorizontalAlignmentType), typeof(View), HorizontalAlignmentType.Left, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            string valueToString = "";

            if (newValue != null)
            {
                switch ((HorizontalAlignmentType)newValue)
                {
                    case Tizen.NUI.HorizontalAlignmentType.Left: { valueToString = "left"; break; }
                    case Tizen.NUI.HorizontalAlignmentType.Center: { valueToString = "center"; break; }
                    case Tizen.NUI.HorizontalAlignmentType.Right: { valueToString = "right"; break; }
                    default: { valueToString = "left"; break; }
                }
                Tizen.NUI.Object.SetProperty(view.swigCPtr, TableView.ChildProperty.CELL_HORIZONTAL_ALIGNMENT, new Tizen.NUI.PropertyValue(valueToString));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(view.swigCPtr, TableView.ChildProperty.CELL_HORIZONTAL_ALIGNMENT).Get(out temp) == false)
            {
                NUILog.Error("CellHorizontalAlignment get error!");
            }

            switch (temp)
            {
                case "left": return Tizen.NUI.HorizontalAlignmentType.Left;
                case "center": return Tizen.NUI.HorizontalAlignmentType.Center;
                case "right": return Tizen.NUI.HorizontalAlignmentType.Right;
                default: return Tizen.NUI.HorizontalAlignmentType.Left;
            }
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CellVerticalAlignmentProperty = BindableProperty.Create("CellVerticalAlignment", typeof(VerticalAlignmentType), typeof(View), VerticalAlignmentType.Top, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            string valueToString = "";

            if (newValue != null)
            {
                switch ((VerticalAlignmentType)newValue)
                {
                    case Tizen.NUI.VerticalAlignmentType.Top: { valueToString = "top"; break; }
                    case Tizen.NUI.VerticalAlignmentType.Center: { valueToString = "center"; break; }
                    case Tizen.NUI.VerticalAlignmentType.Bottom: { valueToString = "bottom"; break; }
                    default: { valueToString = "top"; break; }
                }
                Tizen.NUI.Object.SetProperty(view.swigCPtr, TableView.ChildProperty.CELL_VERTICAL_ALIGNMENT, new Tizen.NUI.PropertyValue(valueToString));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, TableView.ChildProperty.CELL_VERTICAL_ALIGNMENT).Get(out temp);
            {
                NUILog.Error("CellVerticalAlignment get error!");
            }

            switch (temp)
            {
                case "top": return Tizen.NUI.VerticalAlignmentType.Top;
                case "center": return Tizen.NUI.VerticalAlignmentType.Center;
                case "bottom": return Tizen.NUI.VerticalAlignmentType.Bottom;
                default: return Tizen.NUI.VerticalAlignmentType.Top;
            }
        });

        /// <summary>
        /// "Please DO NOT use! This will be deprecated! Please use 'View Weight' instead of BindableProperty"
        /// This needs to be hidden as inhouse API until all applications using it have been updated.  Do not make public.
        /// </summary>
        [Obsolete("Please DO NOT use! This will be deprecated! Please use 'View Weight' instead of BindableProperty ")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WeightProperty = BindableProperty.Create("Weight", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.Weight = (float)newValue;
            }
        },

        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            return view.Weight;
        });

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LeftFocusableViewProperty = BindableProperty.Create(nameof(View.LeftFocusableView), typeof(View), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null) { view.LeftFocusableViewId = (int)(newValue as View)?.GetId(); }
            else { view.LeftFocusableViewId = -1; }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            if (view.LeftFocusableViewId >= 0) { return view.ConvertIdToView((uint)view.LeftFocusableViewId); }
            return null;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RightFocusableViewProperty = BindableProperty.Create(nameof(View.RightFocusableView), typeof(View), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null) { view.RightFocusableViewId = (int)(newValue as View)?.GetId(); }
            else { view.RightFocusableViewId = -1; }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            if (view.RightFocusableViewId >= 0) { return view.ConvertIdToView((uint)view.RightFocusableViewId); }
            return null;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UpFocusableViewProperty = BindableProperty.Create(nameof(View.UpFocusableView), typeof(View), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null) { view.UpFocusableViewId = (int)(newValue as View)?.GetId(); }
            else { view.UpFocusableViewId = -1; }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            if (view.UpFocusableViewId >= 0) { return view.ConvertIdToView((uint)view.UpFocusableViewId); }
            return null;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DownFocusableViewProperty = BindableProperty.Create(nameof(View.DownFocusableView), typeof(View), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null) { view.DownFocusableViewId = (int)(newValue as View)?.GetId(); }
            else { view.DownFocusableViewId = -1; }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            if (view.DownFocusableViewId >= 0) { return view.ConvertIdToView((uint)view.DownFocusableViewId); }
            return null;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FocusableProperty = BindableProperty.Create("Focusable", typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null) { view.SetKeyboardFocusable((bool)newValue); }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            return view.IsKeyboardFocusable();
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty Size2DProperty = BindableProperty.Create("Size2D", typeof(Size2D), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.SIZE, new Tizen.NUI.PropertyValue(new Size((Size2D)newValue)));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Size temp = new Size(0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.SIZE).Get(temp);
            Size2D size = new Size2D((int)temp.Width, (int)temp.Height);
            return size;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OpacityProperty = BindableProperty.Create("Opacity", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.OPACITY, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.OPACITY).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty Position2DProperty = BindableProperty.Create("Position2D", typeof(Position2D), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.POSITION, new Tizen.NUI.PropertyValue(new Position((Position2D)newValue)));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Position temp = new Position(0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.POSITION).Get(temp);
            return new Position2D(temp);
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionUsesPivotPointProperty = BindableProperty.Create("PositionUsesPivotPoint", typeof(bool), typeof(View), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.POSITION_USES_ANCHOR_POINT, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.POSITION_USES_ANCHOR_POINT).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SiblingOrderProperty = BindableProperty.Create("SiblingOrder", typeof(int), typeof(View), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            int value;
            if (newValue != null)
            {
                value = (int)newValue;
                if (value < 0)
                {
                    NUILog.Error("SiblingOrder should be bigger than 0 or equal to 0.");
                    return;
                }
                var siblings = view.GetParent()?.Children;
                if (siblings != null)
                {
                    int currentOrder = siblings.IndexOf(view);
                    if (value != currentOrder)
                    {
                        if (value == 0) { view.LowerToBottom(); }
                        else if (value < siblings.Count - 1)
                        {
                            if (value > currentOrder) { view.RaiseAbove(siblings[value]); }
                            else { view.LowerBelow(siblings[value]); }
                        }
                        else { view.RaiseToTop(); }
                    }
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            var parentChildren = view.GetParent()?.Children;
            int currentOrder = 0;
            if (parentChildren != null)
            {
                currentOrder = parentChildren.IndexOf(view);

                if (currentOrder < 0) { return 0; }
                else if (currentOrder < parentChildren.Count) { return currentOrder; }
            }

            return 0;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ParentOriginProperty = BindableProperty.Create("ParentOrigin", typeof(Position), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.PARENT_ORIGIN, new Tizen.NUI.PropertyValue((Position)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Position temp = new Position(0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.PARENT_ORIGIN).Get(temp);
            return temp;
        }
        );
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PivotPointProperty = BindableProperty.Create("PivotPoint", typeof(Position), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.ANCHOR_POINT, new Tizen.NUI.PropertyValue((Position)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Position temp = new Position(0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.ANCHOR_POINT).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeWidthProperty = BindableProperty.Create("SizeWidth", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.SIZE_WIDTH, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.SIZE_WIDTH).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeHeightProperty = BindableProperty.Create("SizeHeight", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.SIZE_HEIGHT, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.SIZE_HEIGHT).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionProperty = BindableProperty.Create("Position", typeof(Position), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.POSITION, new Tizen.NUI.PropertyValue((Position)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Position temp = new Position(0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.POSITION).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionXProperty = BindableProperty.Create("PositionX", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.POSITION_X, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.POSITION_X).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionYProperty = BindableProperty.Create("PositionY", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.POSITION_Y, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.POSITION_Y).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionZProperty = BindableProperty.Create("PositionZ", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.POSITION_Z, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.POSITION_Z).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OrientationProperty = BindableProperty.Create("Orientation", typeof(Rotation), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.ORIENTATION, new Tizen.NUI.PropertyValue((Rotation)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Rotation temp = new Rotation();
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.ORIENTATION).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleProperty = BindableProperty.Create("Scale", typeof(Vector3), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.SCALE, new Tizen.NUI.PropertyValue((Vector3)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.SCALE).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleXProperty = BindableProperty.Create("ScaleX", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.SCALE_X, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.SCALE_X).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleYProperty = BindableProperty.Create("ScaleY", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.SCALE_Y, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.SCALE_Y).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleZProperty = BindableProperty.Create("ScaleZ", typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.SCALE_Z, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.SCALE_Z).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty NameProperty = BindableProperty.Create("Name", typeof(string), typeof(View), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.NAME, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.NAME).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SensitiveProperty = BindableProperty.Create("Sensitive", typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.SENSITIVE, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.SENSITIVE).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LeaveRequiredProperty = BindableProperty.Create("LeaveRequired", typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.LEAVE_REQUIRED, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.LEAVE_REQUIRED).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InheritOrientationProperty = BindableProperty.Create("InheritOrientation", typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.INHERIT_ORIENTATION, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.INHERIT_ORIENTATION).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InheritScaleProperty = BindableProperty.Create("InheritScale", typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.INHERIT_SCALE, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.INHERIT_SCALE).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DrawModeProperty = BindableProperty.Create("DrawMode", typeof(DrawModeType), typeof(View), DrawModeType.Normal, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.DRAW_MODE, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.DRAW_MODE).Get(out temp) == false)
            {
                NUILog.Error("DrawMode get error!");
            }
            switch (temp)
            {
                case "NORMAL": return DrawModeType.Normal;
                case "OVERLAY_2D": return DrawModeType.Overlay2D;
#pragma warning disable CS0618 // Disable deprecated warning as we do need to use the deprecated API here.
                case "STENCIL": return DrawModeType.Stencil;
#pragma warning restore CS0618
                default: return DrawModeType.Normal;
            }
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeModeFactorProperty = BindableProperty.Create("SizeModeFactor", typeof(Vector3), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.SIZE_MODE_FACTOR, new Tizen.NUI.PropertyValue((Vector3)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.SIZE_MODE_FACTOR).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WidthResizePolicyProperty = BindableProperty.Create("WidthResizePolicy", typeof(ResizePolicyType), typeof(View), ResizePolicyType.Fixed, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.WIDTH_RESIZE_POLICY, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.WIDTH_RESIZE_POLICY).Get(out temp) == false)
            {
                NUILog.Error("WidthResizePolicy get error!");
            }
            switch (temp)
            {
                case "FIXED": return ResizePolicyType.Fixed;
                case "USE_NATURAL_SIZE": return ResizePolicyType.UseNaturalSize;
                case "FILL_TO_PARENT": return ResizePolicyType.FillToParent;
                case "SIZE_RELATIVE_TO_PARENT": return ResizePolicyType.SizeRelativeToParent;
                case "SIZE_FIXED_OFFSET_FROM_PARENT": return ResizePolicyType.SizeFixedOffsetFromParent;
                case "FIT_TO_CHILDREN": return ResizePolicyType.FitToChildren;
                case "DIMENSION_DEPENDENCY": return ResizePolicyType.DimensionDependency;
                case "USE_ASSIGNED_SIZE": return ResizePolicyType.UseAssignedSize;
                default: return ResizePolicyType.Fixed;
            }
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HeightResizePolicyProperty = BindableProperty.Create("HeightResizePolicy", typeof(ResizePolicyType), typeof(View), ResizePolicyType.Fixed, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.HEIGHT_RESIZE_POLICY, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.HEIGHT_RESIZE_POLICY).Get(out temp) == false)
            {
                NUILog.Error("HeightResizePolicy get error!");
            }
            switch (temp)
            {
                case "FIXED": return ResizePolicyType.Fixed;
                case "USE_NATURAL_SIZE": return ResizePolicyType.UseNaturalSize;
                case "FILL_TO_PARENT": return ResizePolicyType.FillToParent;
                case "SIZE_RELATIVE_TO_PARENT": return ResizePolicyType.SizeRelativeToParent;
                case "SIZE_FIXED_OFFSET_FROM_PARENT": return ResizePolicyType.SizeFixedOffsetFromParent;
                case "FIT_TO_CHILDREN": return ResizePolicyType.FitToChildren;
                case "DIMENSION_DEPENDENCY": return ResizePolicyType.DimensionDependency;
                case "USE_ASSIGNED_SIZE": return ResizePolicyType.UseAssignedSize;
                default: return ResizePolicyType.Fixed;
            }
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeScalePolicyProperty = BindableProperty.Create("SizeScalePolicy", typeof(SizeScalePolicyType), typeof(View), SizeScalePolicyType.UseSizeSet, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            string valueToString = "";
            if (newValue != null)
            {
                switch ((SizeScalePolicyType)newValue)
                {
                    case SizeScalePolicyType.UseSizeSet: { valueToString = "USE_SIZE_SET"; break; }
                    case SizeScalePolicyType.FitWithAspectRatio: { valueToString = "FIT_WITH_ASPECT_RATIO"; break; }
                    case SizeScalePolicyType.FillWithAspectRatio: { valueToString = "FILL_WITH_ASPECT_RATIO"; break; }
                    default: { valueToString = "USE_SIZE_SET"; break; }
                }
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.SIZE_SCALE_POLICY, new Tizen.NUI.PropertyValue(valueToString));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.SIZE_SCALE_POLICY).Get(out temp) == false)
            {
                NUILog.Error("SizeScalePolicy get error!");
            }
            switch (temp)
            {
                case "USE_SIZE_SET": return SizeScalePolicyType.UseSizeSet;
                case "FIT_WITH_ASPECT_RATIO": return SizeScalePolicyType.FitWithAspectRatio;
                case "FILL_WITH_ASPECT_RATIO": return SizeScalePolicyType.FillWithAspectRatio;
                default: return SizeScalePolicyType.UseSizeSet;
            }
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WidthForHeightProperty = BindableProperty.Create("WidthForHeight", typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.WIDTH_FOR_HEIGHT, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.WIDTH_FOR_HEIGHT).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HeightForWidthProperty = BindableProperty.Create("HeightForWidth", typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.HEIGHT_FOR_WIDTH, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.HEIGHT_FOR_WIDTH).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PaddingProperty = BindableProperty.Create("Padding", typeof(Extents), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.PADDING, new Tizen.NUI.PropertyValue((Extents)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Extents temp = new Extents(0, 0, 0, 0);
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.PADDING).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeProperty = BindableProperty.Create("Size", typeof(Size), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.SIZE, new Tizen.NUI.PropertyValue((Size)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Size temp = new Size(0, 0, 0);
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.SIZE).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinimumSizeProperty = BindableProperty.Create("MinimumSize", typeof(Size2D), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.MINIMUM_SIZE, new Tizen.NUI.PropertyValue((Size2D)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Size2D temp = new Size2D(0, 0);
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.MINIMUM_SIZE).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaximumSizeProperty = BindableProperty.Create("MaximumSize", typeof(Size2D), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.MAXIMUM_SIZE, new Tizen.NUI.PropertyValue((Size2D)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Size2D temp = new Size2D(0, 0);
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.MAXIMUM_SIZE).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InheritPositionProperty = BindableProperty.Create("InheritPosition", typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.INHERIT_POSITION, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.INHERIT_POSITION).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ClippingModeProperty = BindableProperty.Create("ClippingMode", typeof(ClippingModeType), typeof(View), ClippingModeType.Disabled, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.CLIPPING_MODE, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            int temp = 0;
            if (Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.CLIPPING_MODE).Get(out temp) == false)
            {
                NUILog.Error("ClippingMode get error!");
            }
            return (ClippingModeType)temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InheritLayoutDirectionProperty = BindableProperty.Create("InheritLayoutDirection", typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.INHERIT_LAYOUT_DIRECTION, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.INHERIT_LAYOUT_DIRECTION).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LayoutDirectionProperty = BindableProperty.Create("LayoutDirection", typeof(ViewLayoutDirectionType), typeof(View), ViewLayoutDirectionType.LTR, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.LAYOUT_DIRECTION, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            int temp;
            if (false == Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.LAYOUT_DIRECTION).Get(out temp))
            {
                NUILog.Error("LAYOUT_DIRECTION get error!");
            }
            return (ViewLayoutDirectionType)temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MarginProperty = BindableProperty.Create("Margin", typeof(Extents), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.MARGIN, new Tizen.NUI.PropertyValue((Extents)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Extents temp = new Extents(0, 0, 0, 0);
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.MARGIN).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StyleProperty = BindableProperty.Create("Style", typeof(Style), typeof(View), default(Style), propertyChanged: (bindable, oldvalue, newvalue) => ((View)bindable)._mergedStyle.Style = (Style)newvalue);

        /// <summary>
        /// Flag to indicate if layout set explicitly via API call or View was automatically given a Layout.
        /// </summary>
        public bool layoutSet = false;

        /// <summary>
        /// Flag to allow Layouting to be disabled for Views.
        /// Once a View has a Layout set then any children added to Views from then on will receive
        /// automatic Layouts.
        /// </summary>
        public static bool layoutingDisabled{get; set;} = true;

        internal readonly MergedStyle _mergedStyle;
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        private LayoutItem _layout; // Exclusive layout assigned to this View.
        private int _widthPolicy = LayoutParamPolicies.WrapContent; // Layout width policy
        private int _heightPolicy = LayoutParamPolicies.WrapContent; // Layout height policy
        private float _weight = 0.0f; // Weighting of child View in a Layout
        private MeasureSpecification _measureSpecificationWidth; // Layout width and internal Mode
        private MeasureSpecification _measureSpecificationHeight; // Layout height and internal Mode
        private bool _backgroundImageSynchronosLoading = false;
        private EventHandler _offWindowEventHandler;
        private OffWindowEventCallbackType _offWindowEventCallback;
        private EventHandlerWithReturnType<object, WheelEventArgs, bool> _wheelEventHandler;
        private WheelEventCallbackType _wheelEventCallback;
        private EventHandlerWithReturnType<object, KeyEventArgs, bool> _keyEventHandler;
        private KeyCallbackType _keyCallback;
        private EventHandlerWithReturnType<object, TouchEventArgs, bool> _touchDataEventHandler;
        private TouchDataCallbackType _touchDataCallback;
        private EventHandlerWithReturnType<object, HoverEventArgs, bool> _hoverEventHandler;
        private HoverEventCallbackType _hoverEventCallback;
        private EventHandler<VisibilityChangedEventArgs> _visibilityChangedEventHandler;
        private VisibilityChangedEventCallbackType _visibilityChangedEventCallback;
        private EventHandler _keyInputFocusGainedEventHandler;
        private KeyInputFocusGainedCallbackType _keyInputFocusGainedCallback;
        private EventHandler _keyInputFocusLostEventHandler;
        private KeyInputFocusLostCallbackType _keyInputFocusLostCallback;
        private EventHandler _onRelayoutEventHandler;
        private OnRelayoutEventCallbackType _onRelayoutEventCallback;
        private EventHandler _onWindowEventHandler;
        private OnWindowEventCallbackType _onWindowEventCallback;
        private EventHandler<LayoutDirectionChangedEventArgs> _layoutDirectionChangedEventHandler;
        private LayoutDirectionChangedEventCallbackType _layoutDirectionChangedEventCallback;
        // Resource Ready Signal
        private EventHandler _resourcesLoadedEventHandler;
        private ResourcesLoadedCallbackType _ResourcesLoadedCallback;
        private EventHandler<BackgroundResourceLoadedEventArgs> _backgroundResourceLoadedEventHandler;
        private _backgroundResourceLoadedCallbackType _backgroundResourceLoadedCallback;

        private OnWindowEventCallbackType _onWindowSendEventCallback;

        private void SendViewAddedEventToWindow(IntPtr data)
        {
            Window.Instance?.SendViewAdded(this);
        }

        /// <summary>
        /// Creates a new instance of a view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public View() : this(Interop.View.View_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        internal View(View uiControl) : this(Interop.View.new_View__SWIG_1(View.getCPtr(uiControl)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal View(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.View.View_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            if (HasBody())
            {
                PositionUsesPivotPoint = false;
            }
            _mergedStyle = new MergedStyle(GetType(), this);

            _onWindowSendEventCallback = SendViewAddedEventToWindow;
            this.OnWindowSignal().Connect(_onWindowSendEventCallback);
        }

        internal View(ViewImpl implementation) : this(Interop.View.new_View__SWIG_2(ViewImpl.getCPtr(implementation)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void OffWindowEventCallbackType(IntPtr control);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool WheelEventCallbackType(IntPtr view, IntPtr wheelEvent);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool KeyCallbackType(IntPtr control, IntPtr keyEvent);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool TouchDataCallbackType(IntPtr view, IntPtr touchData);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate bool HoverEventCallbackType(IntPtr view, IntPtr hoverEvent);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void VisibilityChangedEventCallbackType(IntPtr data, bool visibility, VisibilityChangeType type);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void ResourcesLoadedCallbackType(IntPtr control);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void _backgroundResourceLoadedCallbackType(IntPtr view);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void KeyInputFocusGainedCallbackType(IntPtr control);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void KeyInputFocusLostCallbackType(IntPtr control);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void OnRelayoutEventCallbackType(IntPtr control);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void OnWindowEventCallbackType(IntPtr control);
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void LayoutDirectionChangedEventCallbackType(IntPtr data, ViewLayoutDirectionType type);

        /// <summary>
        /// Event when a child is removed.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public new event EventHandler<ChildRemovedEventArgs> ChildRemoved;
        /// <summary>
        /// Event when a child is added.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public new event EventHandler<ChildAddedEventArgs> ChildAdded;

        /// <summary>
        /// An event for the KeyInputFocusGained signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// The KeyInputFocusGained signal is emitted when the control gets the key input focus.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler FocusGained
        {
            add
            {
                if (_keyInputFocusGainedEventHandler == null)
                {
                    _keyInputFocusGainedCallback = OnKeyInputFocusGained;
                    this.KeyInputFocusGainedSignal().Connect(_keyInputFocusGainedCallback);
                }

                _keyInputFocusGainedEventHandler += value;
            }

            remove
            {
                _keyInputFocusGainedEventHandler -= value;

                if (_keyInputFocusGainedEventHandler == null && KeyInputFocusGainedSignal().Empty() == false)
                {
                    this.KeyInputFocusGainedSignal().Disconnect(_keyInputFocusGainedCallback);
                }
            }
        }

        /// <summary>
        /// An event for the KeyInputFocusLost signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// The KeyInputFocusLost signal is emitted when the control loses the key input focus.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler FocusLost
        {
            add
            {
                if (_keyInputFocusLostEventHandler == null)
                {
                    _keyInputFocusLostCallback = OnKeyInputFocusLost;
                    this.KeyInputFocusLostSignal().Connect(_keyInputFocusLostCallback);
                }

                _keyInputFocusLostEventHandler += value;
            }

            remove
            {
                _keyInputFocusLostEventHandler -= value;

                if (_keyInputFocusLostEventHandler == null && KeyInputFocusLostSignal().Empty() == false)
                {
                    this.KeyInputFocusLostSignal().Disconnect(_keyInputFocusLostCallback);
                }
            }
        }

        /// <summary>
        /// An event for the KeyPressed signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// The KeyPressed signal is emitted when the key event is received.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandlerWithReturnType<object, KeyEventArgs, bool> KeyEvent
        {
            add
            {
                if (_keyEventHandler == null)
                {
                    _keyCallback = OnKeyEvent;
                    this.KeyEventSignal().Connect(_keyCallback);
                }

                _keyEventHandler += value;
            }

            remove
            {
                _keyEventHandler -= value;

                if (_keyEventHandler == null && KeyEventSignal().Empty() == false)
                {
                    this.KeyEventSignal().Disconnect(_keyCallback);
                }
            }
        }

        /// <summary>
        /// An event for the OnRelayout signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// The OnRelayout signal is emitted after the size has been set on the view during relayout.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler Relayout
        {
            add
            {
                if (_onRelayoutEventHandler == null)
                {
                    _onRelayoutEventCallback = OnRelayout;
                    this.OnRelayoutSignal().Connect(_onRelayoutEventCallback);
                }

                _onRelayoutEventHandler += value;
            }

            remove
            {
                _onRelayoutEventHandler -= value;

                if (_onRelayoutEventHandler == null && OnRelayoutSignal().Empty() == false)
                {
                    this.OnRelayoutSignal().Disconnect(_onRelayoutEventCallback);
                }

            }
        }

        /// <summary>
        /// An event for the touched signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// The touched signal is emitted when the touch input is received.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandlerWithReturnType<object, TouchEventArgs, bool> TouchEvent
        {
            add
            {
                if (_touchDataEventHandler == null)
                {
                    _touchDataCallback = OnTouch;
                    this.TouchSignal().Connect(_touchDataCallback);
                }

                _touchDataEventHandler += value;
            }

            remove
            {
                _touchDataEventHandler -= value;

                if (_touchDataEventHandler == null && TouchSignal().Empty() == false)
                {
                    this.TouchSignal().Disconnect(_touchDataCallback);
                }

            }
        }

        /// <summary>
        /// An event for the hovered signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// The hovered signal is emitted when the hover input is received.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandlerWithReturnType<object, HoverEventArgs, bool> HoverEvent
        {
            add
            {
                if (_hoverEventHandler == null)
                {
                    _hoverEventCallback = OnHoverEvent;
                    this.HoveredSignal().Connect(_hoverEventCallback);
                }

                _hoverEventHandler += value;
            }

            remove
            {
                _hoverEventHandler -= value;

                if (_hoverEventHandler == null && HoveredSignal().Empty() == false)
                {
                    this.HoveredSignal().Disconnect(_hoverEventCallback);
                }

            }
        }

        /// <summary>
        /// An event for the WheelMoved signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// The WheelMoved signal is emitted when the wheel event is received.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandlerWithReturnType<object, WheelEventArgs, bool> WheelEvent
        {
            add
            {
                if (_wheelEventHandler == null)
                {
                    _wheelEventCallback = OnWheelEvent;
                    this.WheelEventSignal().Connect(_wheelEventCallback);
                }

                _wheelEventHandler += value;
            }

            remove
            {
                _wheelEventHandler -= value;

                if (_wheelEventHandler == null && WheelEventSignal().Empty() == false)
                {
                    this.WheelEventSignal().Disconnect(_wheelEventCallback);
                }

            }
        }

        /// <summary>
        /// An event for the OnWindow signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// The OnWindow signal is emitted after the view has been connected to the window.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler AddedToWindow
        {
            add
            {
                if (_onWindowEventHandler == null)
                {
                    _onWindowEventCallback = OnWindow;
                    this.OnWindowSignal().Connect(_onWindowEventCallback);
                }

                _onWindowEventHandler += value;
            }

            remove
            {
                _onWindowEventHandler -= value;

                if (_onWindowEventHandler == null && OnWindowSignal().Empty() == false)
                {
                    this.OnWindowSignal().Disconnect(_onWindowEventCallback);
                }
            }
        }

        /// <summary>
        /// An event for the OffWindow signal, which can be used to subscribe or unsubscribe the event handler.<br />
        /// OffWindow signal is emitted after the view has been disconnected from the window.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler RemovedFromWindow
        {
            add
            {
                if (_offWindowEventHandler == null)
                {
                    _offWindowEventCallback = OffWindow;
                    this.OffWindowSignal().Connect(_offWindowEventCallback);
                }

                _offWindowEventHandler += value;
            }

            remove
            {
                _offWindowEventHandler -= value;

                if (_offWindowEventHandler == null && OffWindowSignal().Empty() == false)
                {
                    this.OffWindowSignal().Disconnect(_offWindowEventCallback);
                }
            }
        }

        /// <summary>
        /// An event for visibility change which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when the visible property of this or a parent view is changed.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<VisibilityChangedEventArgs> VisibilityChanged
        {
            add
            {
                if (_visibilityChangedEventHandler == null)
                {
                    _visibilityChangedEventCallback = OnVisibilityChanged;
                    VisibilityChangedSignal(this).Connect(_visibilityChangedEventCallback);
                }

                _visibilityChangedEventHandler += value;
            }

            remove
            {
                _visibilityChangedEventHandler -= value;

                if (_visibilityChangedEventHandler == null && VisibilityChangedSignal(this).Empty() == false)
                {
                    VisibilityChangedSignal(this).Disconnect(_visibilityChangedEventCallback);
                }
            }
        }

        /// <summary>
        /// Event for layout direction change which can be used to subscribe/unsubscribe the event handler.<br />
        /// This signal is emitted when the layout direction property of this or a parent view is changed.<br />
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<LayoutDirectionChangedEventArgs> LayoutDirectionChanged
        {
            add
            {
                if (_layoutDirectionChangedEventHandler == null)
                {
                    _layoutDirectionChangedEventCallback = OnLayoutDirectionChanged;
                    LayoutDirectionChangedSignal(this).Connect(_layoutDirectionChangedEventCallback);
                }

                _layoutDirectionChangedEventHandler += value;
            }

            remove
            {
                _layoutDirectionChangedEventHandler -= value;

                if (_layoutDirectionChangedEventHandler == null && LayoutDirectionChangedSignal(this).Empty() == false)
                {
                    LayoutDirectionChangedSignal(this).Disconnect(_layoutDirectionChangedEventCallback);
                }
            }
        }

        /// <summary>
        /// An event for the ResourcesLoadedSignal signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// This signal is emitted after all resources required by a view are loaded and ready.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler ResourcesLoaded
        {
            add
            {
                if (_resourcesLoadedEventHandler == null)
                {
                    _ResourcesLoadedCallback = OnResourcesLoaded;
                    this.ResourcesLoadedSignal().Connect(_ResourcesLoadedCallback);
                }

                _resourcesLoadedEventHandler += value;
            }

            remove
            {
                _resourcesLoadedEventHandler -= value;

                if (_resourcesLoadedEventHandler == null && ResourcesLoadedSignal().Empty() == false)
                {
                    this.ResourcesLoadedSignal().Disconnect(_ResourcesLoadedCallback);
                }
            }
        }

        internal event EventHandler<BackgroundResourceLoadedEventArgs> BackgroundResourceLoaded
        {
            add
            {
                if (_backgroundResourceLoadedEventHandler == null)
                {
                    _backgroundResourceLoadedCallback = OnBackgroundResourceLoaded;
                    this.ResourcesLoadedSignal().Connect(_backgroundResourceLoadedCallback);
                }

                _backgroundResourceLoadedEventHandler += value;
            }
            remove
            {
                _backgroundResourceLoadedEventHandler -= value;

                if (_backgroundResourceLoadedEventHandler == null && ResourcesLoadedSignal().Empty() == false)
                {
                    this.ResourcesLoadedSignal().Disconnect(_backgroundResourceLoadedCallback);
                }
            }
        }

        /// <summary>
        /// Enumeration for describing the states of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum States
        {
            /// <summary>
            /// The normal state.
            /// </summary>
            Normal,
            /// <summary>
            /// The focused state.
            /// </summary>
            Focused,
            /// <summary>
            /// The disabled state.
            /// </summary>
            Disabled
        }

        /// <summary>
        /// Describes the direction to move the focus towards.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public enum FocusDirection
        {
            /// <summary>
            /// Move keyboard focus towards the left direction.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Left,
            /// <summary>
            /// Move keyboard focus towards the right direction.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Right,
            /// <summary>
            /// Move keyboard focus towards the up direction.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Up,
            /// <summary>
            /// Move keyboard focus towards the down direction.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            Down,
            /// <summary>
            /// Move keyboard focus towards the previous page direction.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            PageUp,
            /// <summary>
            /// Move keyboard focus towards the next page direction.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            PageDown
        }

        internal enum PropertyRange
        {
            PROPERTY_START_INDEX = PropertyRanges.PROPERTY_REGISTRATION_START_INDEX,
            CONTROL_PROPERTY_START_INDEX = PROPERTY_START_INDEX,
            CONTROL_PROPERTY_END_INDEX = CONTROL_PROPERTY_START_INDEX + 1000
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsResourcesCreated
        {
            get
            {
                return Application.Current.IsResourcesCreated;
            }
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceDictionary XamlResources
        {
            get
            {
                return Application.Current.XamlResources;
            }
            set
            {
                Application.Current.XamlResources = value;
            }
        }

        /// <summary>
        /// The StyleName, type string.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string StyleName
        {
            get
            {
                return (string)GetValue(StyleNameProperty);
            }
            set
            {
                SetValue(StyleNameProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The mutually exclusive with BACKGROUND_IMAGE and BACKGROUND type Vector4.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Color BackgroundColor
        {
            get
            {
                return (Color)GetValue(BackgroundColorProperty);
            }
            set
            {
                SetValue(BackgroundColorProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The mutually exclusive with BACKGROUND_COLOR and BACKGROUND type Map.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string BackgroundImage
        {
            get
            {
                return (string)GetValue(BackgroundImageProperty);
            }
            set
            {
                SetValue(BackgroundImageProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The background of view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.PropertyMap Background
        {
            get
            {
                return (PropertyMap)GetValue(BackgroundProperty);
            }
            set
            {
                SetValue(BackgroundProperty, value);
                NotifyPropertyChanged();
            }
        }


        /// <summary>
        /// The current state of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public States State
        {
            get
            {
                return (States)GetValue(StateProperty);
            }
            set
            {
                SetValue(StateProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The current sub state of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public States SubState
        {
            get
            {
                return (States)GetValue(SubStateProperty);
            }
            set
            {
                SetValue(SubStateProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Displays a tooltip
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.PropertyMap Tooltip
        {
            get
            {
                return (PropertyMap)GetValue(TooltipProperty);
            }
            set
            {
                SetValue(TooltipProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Displays a tooltip as a text.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string TooltipText
        {
            set
            {
                SetProperty(View.Property.TOOLTIP, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Child property of FlexContainer.<br />
        /// The proportion of the free space in the container, the flex item will receive.<br />
        /// If all items in the container set this property, their sizes will be proportional to the specified flex factor.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Flex
        {
            get
            {
                return (float)GetValue(FlexProperty);
            }
            set
            {
                SetValue(FlexProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Child property of FlexContainer.<br />
        /// The alignment of the flex item along the cross axis, which, if set, overides the default alignment for all items in the container.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int AlignSelf
        {
            get
            {
                return (int)GetValue(AlignSelfProperty);
            }
            set
            {
                SetValue(AlignSelfProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Child property of FlexContainer.<br />
        /// The space around the flex item.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 FlexMargin
        {
            get
            {
                return (Vector4)GetValue(FlexMarginProperty);
            }
            set
            {
                SetValue(FlexMarginProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The top-left cell this child occupies, if not set, the first available cell is used.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 CellIndex
        {
            get
            {
                return (Vector2)GetValue(CellIndexProperty);
            }
            set
            {
                SetValue(CellIndexProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The number of rows this child occupies, if not set, the default value is 1.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float RowSpan
        {
            get
            {
                return (float)GetValue(RowSpanProperty);
            }
            set
            {
                SetValue(RowSpanProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The number of columns this child occupies, if not set, the default value is 1.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ColumnSpan
        {
            get
            {
                return (float)GetValue(ColumnSpanProperty);
            }
            set
            {
                SetValue(ColumnSpanProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The horizontal alignment of this child inside the cells, if not set, the default value is 'left'.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.HorizontalAlignmentType CellHorizontalAlignment
        {
            get
            {
                return (HorizontalAlignmentType)GetValue(CellHorizontalAlignmentProperty);
            }
            set
            {
                SetValue(CellHorizontalAlignmentProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The vertical alignment of this child inside the cells, if not set, the default value is 'top'.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.VerticalAlignmentType CellVerticalAlignment
        {
            get
            {
                return (VerticalAlignmentType)GetValue(CellVerticalAlignmentProperty);
            }
            set
            {
                SetValue(CellVerticalAlignmentProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The left focusable view.<br />
        /// This will return null if not set.<br />
        /// This will also return null if the specified left focusable view is not on a window.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public View LeftFocusableView
        {
            // As native side will be only storing IDs so need a logic to convert View to ID and vice-versa.
            get
            {
                return (View)GetValue(LeftFocusableViewProperty);
            }
            set
            {
                SetValue(LeftFocusableViewProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The right focusable view.<br />
        /// This will return null if not set.<br />
        /// This will also return null if the specified right focusable view is not on a window.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public View RightFocusableView
        {
            // As native side will be only storing IDs so need a logic to convert View to ID and vice-versa.
            get
            {
                return (View)GetValue(RightFocusableViewProperty);
            }
            set
            {
                SetValue(RightFocusableViewProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The up focusable view.<br />
        /// This will return null if not set.<br />
        /// This will also return null if the specified up focusable view is not on a window.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public View UpFocusableView
        {
            // As native side will be only storing IDs so need a logic to convert View to ID and vice-versa.
            get
            {
                return (View)GetValue(UpFocusableViewProperty);
            }
            set
            {
                SetValue(UpFocusableViewProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The down focusable view.<br />
        /// This will return null if not set.<br />
        /// This will also return null if the specified down focusable view is not on a window.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public View DownFocusableView
        {
            // As native side will be only storing IDs so need a logic to convert View to ID and vice-versa.
            get
            {
                return (View)GetValue(DownFocusableViewProperty);
            }
            set
            {
                SetValue(DownFocusableViewProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Whether the view should be focusable by keyboard navigation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Focusable
        {
            set
            {
                SetValue(FocusableProperty, value);
                NotifyPropertyChanged();
            }
            get
            {
                return (bool)GetValue(FocusableProperty);
            }
        }

        /// <summary>
        ///  Retrieves the position of the view.<br />
        ///  The coordinates are relative to the view's parent.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Position CurrentPosition
        {
            get
            {
                return GetCurrentPosition();
            }
        }

        /// <summary>
        /// Sets the size of a view for the width and the height.<br />
        /// Geometry can be scaled to fit within this area.<br />
        /// This does not interfere with the view's scale factor.<br />
        /// The views default depth is the minimum of width and height.<br />
        /// </summary>
        /// <remarks>
        /// This NUI object (Size2D) typed property can be configured by multiple cascade setting. <br />
        /// For example, this code ( view.Size2D.Width = 100; view.Size2D.Height = 100; ) is equivalent to this ( view.Size2D = new Size2D(100, 100); ). <br />
        /// Please note that this multi-cascade setting is especially possible for this NUI object (Size2D). <br />
        /// This means by default others are impossible so it is recommended that NUI object typed properties are configured by their constructor with parameters. <br />
        /// For example, this code is working fine : view.Scale = new Vector3( 2.0f, 1.5f, 0.0f); <br />
        /// but this will not work! : view.Scale.X = 2.0f; view.Scale.Y = 1.5f; <br />
        /// It may not match the current value in some cases, i.e. when the animation is progressing or the maximum or minimu size is set. <br />
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Size2D Size2D
        {
            get
            {
                Size2D temp = (Size2D)GetValue(Size2DProperty);
                return new Size2D(OnSize2DChanged, temp.Width, temp.Height);
            }
            set
            {
                SetValue(Size2DProperty, value);
                // Set Specification so when layouts measure this View it matches the value set here.
                // All Views are currently Layouts.
                MeasureSpecificationWidth = new MeasureSpecification(new LayoutLength(value.Width), MeasureSpecification.ModeType.Exactly);
                MeasureSpecificationHeight = new MeasureSpecification(new LayoutLength(value.Height), MeasureSpecification.ModeType.Exactly);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        ///  Retrieves the size of the view.<br />
        ///  The coordinates are relative to the view's parent.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Size2D CurrentSize
        {
            get
            {
                return GetCurrentSize();
            }
        }

        /// <summary>
        /// Retrieves and sets the view's opacity.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Opacity
        {
            get
            {
                return (float)GetValue(OpacityProperty);
            }
            set
            {
                SetValue(OpacityProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Sets the position of the view for X and Y.<br />
        /// By default, sets the position vector between the parent origin and the pivot point (default).<br />
        /// If the position inheritance is disabled, sets the world position.<br />
        /// </summary>
        /// <remarks>
        /// This NUI object (Position2D) typed property can be configured by multiple cascade setting. <br />
        /// For example, this code ( view.Position2D.X = 100; view.Position2D.Y = 100; ) is equivalent to this ( view.Position2D = new Position2D(100, 100); ). <br />
        /// Please note that this multi-cascade setting is especially possible for this NUI object (Position2D). <br />
        /// This means by default others are impossible so it is recommended that NUI object typed properties are configured by their constructor with parameters. <br />
        /// For example, this code is working fine : view.Scale = new Vector3( 2.0f, 1.5f, 0.0f); <br />
        /// but this will not work! : view.Scale.X = 2.0f; view.Scale.Y = 1.5f; <br />
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Position2D Position2D
        {
            get
            {
                Position2D temp = (Position2D)GetValue(Position2DProperty);
                return new Position2D(OnPosition2DChanged, temp.X, temp.Y);
            }
            set
            {
                SetValue(Position2DProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Retrieves the screen postion of the view.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ScreenPosition
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(View.Property.SCREEN_POSITION).Get(temp);
                return temp;
            }
        }

        /// <summary>
        /// Determines whether the pivot point should be used to determine the position of the view.
        /// This is true by default.
        /// </summary>
        /// <remarks>If false, then the top-left of the view is used for the position.
        /// Setting this to false will allow scaling or rotation around the pivot point without affecting the view's position.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public bool PositionUsesPivotPoint
        {
            get
            {
                return (bool)GetValue(PositionUsesPivotPointProperty);
            }
            set
            {
                SetValue(PositionUsesPivotPointProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Please do not use! this will be deprecated.
        /// </summary>
        /// Please do not use! this will be deprecated!
        /// Instead please use PositionUsesPivotPoint.
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Please do not use! This will be deprecated! Please use PositionUsesPivotPoint instead! " +
            "Like: " +
            "View view = new View(); " +
            "view.PivotPoint = PivotPoint.Center; " +
            "view.PositionUsesPivotPoint = true;")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PositionUsesAnchorPoint
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.POSITION_USES_ANCHOR_POINT).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.POSITION_USES_ANCHOR_POINT, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Queries whether the view is connected to the stage.<br />
        /// When a view is connected, it will be directly or indirectly parented to the root view.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsOnWindow
        {
            get
            {
                return OnWindow();
            }
        }

        /// <summary>
        /// Gets the depth in the hierarchy for the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int HierarchyDepth
        {
            get
            {
                return GetHierarchyDepth();
            }
        }

        /// <summary>
        /// Sets the sibling order of the view so the depth position can be defined within the same parent.
        /// </summary>
        /// <remarks>
        /// Note the initial value is 0. SiblingOrder should be bigger than 0 or equal to 0.
        /// Raise, Lower, RaiseToTop, LowerToBottom, RaiseAbove, and LowerBelow will override the sibling order.
        /// The values set by this property will likely change.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public int SiblingOrder
        {
            get
            {
                return (int)GetValue(SiblingOrderProperty);
            }
            set
            {
                SetValue(SiblingOrderProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Returns the natural size of the view.
        /// </summary>
        /// <remarks>
        /// Deriving classes stipulate the natural size and by default a view has a zero natural size.
        /// </remarks>
        /// <since_tizen> 5 </since_tizen>
        public Vector3 NaturalSize
        {
            get
            {
                Vector3 ret = new Vector3(Interop.Actor.Actor_GetNaturalSize(swigCPtr), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Returns the natural size (Size2D) of the view.
        /// </summary>
        /// <remarks>
        /// Deriving classes stipulate the natural size and by default a view has a zero natural size.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        public Size2D NaturalSize2D
        {
            get
            {
                Vector3 temp = new Vector3(Interop.Actor.Actor_GetNaturalSize(swigCPtr), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();

                return new Size2D((int)temp.Width, (int)temp.Height);
            }
        }

        /// <summary>
        /// Gets or sets the origin of a view within its parent's area.<br />
        /// This is expressed in unit coordinates, such that (0.0, 0.0, 0.5) is the top-left corner of the parent, and (1.0, 1.0, 0.5) is the bottom-right corner.<br />
        /// The default parent-origin is ParentOrigin.TopLeft (0.0, 0.0, 0.5).<br />
        /// A view's position is the distance between this origin and the view's anchor-point.<br />
        /// </summary>
        /// <pre>The view has been initialized.</pre>
        /// <since_tizen> 3 </since_tizen>
        public Position ParentOrigin
        {
            get
            {
                return (Position)GetValue(ParentOriginProperty);
            }
            set
            {
                SetValue(ParentOriginProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the anchor-point of a view.<br />
        /// This is expressed in unit coordinates, such that (0.0, 0.0, 0.5) is the top-left corner of the view, and (1.0, 1.0, 0.5) is the bottom-right corner.<br />
        /// The default pivot point is PivotPoint.Center (0.5, 0.5, 0.5).<br />
        /// A view position is the distance between its parent-origin and this anchor-point.<br />
        /// A view's orientation is the rotation from its default orientation, the rotation is centered around its anchor-point.<br />
        /// <pre>The view has been initialized.</pre>
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Position PivotPoint
        {
            get
            {
                return (Position)GetValue(PivotPointProperty);
            }
            set
            {
                SetValue(PivotPointProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the size width of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float SizeWidth
        {
            get
            {
                return (float)GetValue(SizeWidthProperty);
            }
            set
            {
                SetValue(SizeWidthProperty, value);
                WidthSpecification = (int)Math.Ceiling(value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the size height of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float SizeHeight
        {
            get
            {
                return (float)GetValue(SizeHeightProperty);
            }
            set
            {
                SetValue(SizeHeightProperty, value);
                HeightSpecification = (int)Math.Ceiling(value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the position of the view.<br />
        /// By default, sets the position vector between the parent origin and pivot point (default).<br />
        /// If the position inheritance is disabled, sets the world position.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Position Position
        {
            get
            {
                return (Position)GetValue(PositionProperty);
            }
            set
            {
                SetValue(PositionProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the position X of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float PositionX
        {
            get
            {
                return (float)GetValue(PositionXProperty);
            }
            set
            {
                SetValue(PositionXProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the position Y of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float PositionY
        {
            get
            {
                return (float)GetValue(PositionYProperty);
            }
            set
            {
                SetValue(PositionYProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the position Z of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float PositionZ
        {
            get
            {
                return (float)GetValue(PositionZProperty);
            }
            set
            {
                SetValue(PositionZProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the world position of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 WorldPosition
        {
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.WORLD_POSITION).Get(temp);
                return temp;
            }
        }

        /// <summary>
        /// Gets or sets the orientation of the view.<br />
        /// The view's orientation is the rotation from its default orientation, and the rotation is centered around its anchor-point.<br />
        /// </summary>
        /// <remarks>This is an asynchronous method.</remarks>
        /// <since_tizen> 3 </since_tizen>
        public Rotation Orientation
        {
            get
            {
                return (Rotation)GetValue(OrientationProperty);
            }
            set
            {
                SetValue(OrientationProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the world orientation of the view.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Rotation WorldOrientation
        {
            get
            {
                Rotation temp = new Rotation();
                GetProperty(View.Property.WORLD_ORIENTATION).Get(temp);
                return temp;
            }
        }

        /// <summary>
        /// Gets or sets the scale factor applied to the view.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 Scale
        {
            get
            {
                return (Vector3)GetValue(ScaleProperty);
            }
            set
            {
                SetValue(ScaleProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the scale X factor applied to the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ScaleX
        {
            get
            {
                return (float)GetValue(ScaleXProperty);
            }
            set
            {
                SetValue(ScaleXProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the scale Y factor applied to the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ScaleY
        {
            get
            {
                return (float)GetValue(ScaleYProperty);
            }
            set
            {
                SetValue(ScaleYProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the scale Z factor applied to the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ScaleZ
        {
            get
            {
                return (float)GetValue(ScaleZProperty);
            }
            set
            {
                SetValue(ScaleZProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the world scale of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 WorldScale
        {
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.WORLD_SCALE).Get(temp);
                return temp;
            }
        }

        /// <summary>
        /// Retrieves the visibility flag of the view.
        /// </summary>
        /// <remarks>
        /// If the view is not visible, then the view and its children will not be rendered.
        /// This is regardless of the individual visibility values of the children, i.e., the view will only be rendered if all of its parents have visibility set to true.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public bool Visibility
        {
            get
            {
                bool temp = false;
                GetProperty(View.Property.VISIBLE).Get(out temp);
                return temp;
            }
        }

        /// <summary>
        /// Gets the view's world color.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 WorldColor
        {
            get
            {
                Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.WORLD_COLOR).Get(temp);
                return temp;
            }
        }

        /// <summary>
        /// Gets or sets the view's name.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Name
        {
            get
            {
                return (string)GetValue(NameProperty);
            }
            set
            {
                SetValue(NameProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Get the number of children held by the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public new uint ChildCount
        {
            get
            {
                return GetChildCount();
            }
        }

        /// <summary>
        /// Gets the view's ID.
        /// Readonly
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint ID
        {
            get
            {
                return GetId();
            }
        }

        /// <summary>
        /// Gets or sets the status of whether the view should emit touch or hover signals.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Sensitive
        {
            get
            {
                return (bool)GetValue(SensitiveProperty);
            }
            set
            {
                SetValue(SensitiveProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the status of whether the view should receive a notification when touch or hover motion events leave the boundary of the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool LeaveRequired
        {
            get
            {
                return (bool)GetValue(LeaveRequiredProperty);
            }
            set
            {
                SetValue(LeaveRequiredProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the status of whether a child view inherits it's parent's orientation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool InheritOrientation
        {
            get
            {
                return (bool)GetValue(InheritOrientationProperty);
            }
            set
            {
                SetValue(InheritOrientationProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the status of whether a child view inherits it's parent's scale.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool InheritScale
        {
            get
            {
                return (bool)GetValue(InheritScaleProperty);
            }
            set
            {
                SetValue(InheritScaleProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the status of how the view and its children should be drawn.<br />
        /// Not all views are renderable, but DrawMode can be inherited from any view.<br />
        /// If an object is in a 3D layer, it will be depth-tested against other objects in the world, i.e., it may be obscured if other objects are in front.<br />
        /// If DrawMode.Overlay2D is used, the view and its children will be drawn as a 2D overlay.<br />
        /// Overlay views are drawn in a separate pass, after all non-overlay views within the layer.<br />
        /// For overlay views, the drawing order is with respect to tree levels of views, and depth-testing will not be used.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public DrawModeType DrawMode
        {
            get
            {
                return (DrawModeType)GetValue(DrawModeProperty);
            }
            set
            {
                SetValue(DrawModeProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the relative to parent size factor of the view.<br />
        /// This factor is only used when ResizePolicyType is set to either: ResizePolicyType.SizeRelativeToParent or ResizePolicyType.SizeFixedOffsetFromParent.<br />
        /// This view's size is set to the view's size multiplied by or added to this factor, depending on ResizePolicyType.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector3 SizeModeFactor
        {
            get
            {
                return (Vector3)GetValue(SizeModeFactorProperty);
            }
            set
            {
                SetValue(SizeModeFactorProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the width resize policy to be used.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ResizePolicyType WidthResizePolicy
        {
            get
            {
                return (ResizePolicyType)GetValue(WidthResizePolicyProperty);
            }
            set
            {
                SetValue(WidthResizePolicyProperty, value);
                // Match ResizePolicy to new Layouting.
                // Parent relative policies can not be mapped at this point as parent size unknown.
                switch (value)
                {
                    case ResizePolicyType.UseNaturalSize:
                    {
                        WidthSpecification = LayoutParamPolicies.WrapContent;
                        break;
                    }
                    case ResizePolicyType.FillToParent:
                    {
                        WidthSpecification = LayoutParamPolicies.MatchParent;
                        break;
                    }
                    case ResizePolicyType.FitToChildren:
                    {
                        WidthSpecification = LayoutParamPolicies.WrapContent;
                        break;
                    }
                    default:
                        break;
                }
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the height resize policy to be used.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ResizePolicyType HeightResizePolicy
        {
            get
            {
                return (ResizePolicyType)GetValue(HeightResizePolicyProperty);
            }
            set
            {
                SetValue(HeightResizePolicyProperty, value);
                // Match ResizePolicy to new Layouting.
                // Parent relative policies can not be mapped at this point as parent size unknown.
                switch (value)
                {
                    case ResizePolicyType.UseNaturalSize:
                    {
                        HeightSpecification = LayoutParamPolicies.WrapContent;
                        break;
                    }
                    case ResizePolicyType.FillToParent:
                    {
                        HeightSpecification = LayoutParamPolicies.MatchParent;
                        break;
                    }
                    case ResizePolicyType.FitToChildren:
                    {
                        HeightSpecification = LayoutParamPolicies.WrapContent;
                        break;
                    }
                    default:
                        break;
                }
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the policy to use when setting size with size negotiation.<br />
        /// Defaults to SizeScalePolicyType.UseSizeSet.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public SizeScalePolicyType SizeScalePolicy
        {
            get
            {
                return (SizeScalePolicyType)GetValue(SizeScalePolicyProperty);
            }
            set
            {
                SetValue(SizeScalePolicyProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        ///  Gets or sets the status of whether the width size is dependent on the height size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool WidthForHeight
        {
            get
            {
                return (bool)GetValue(WidthForHeightProperty);
            }
            set
            {
                SetValue(WidthForHeightProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the status of whether the height size is dependent on the width size.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool HeightForWidth
        {
            get
            {
                return (bool)GetValue(HeightForWidthProperty);
            }
            set
            {
                SetValue(HeightForWidthProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the padding for use in layout.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public Extents Padding
        {
            get
            {
                return (Extents)GetValue(PaddingProperty);
            }
            set
            {
                SetValue(PaddingProperty, value);
                NotifyPropertyChanged();
                _layout?.RequestLayout();
            }
        }

        /// <summary>
        /// Gets or sets the minimum size the view can be assigned in size negotiation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Size2D MinimumSize
        {
            get
            {
                return (Size2D)GetValue(MinimumSizeProperty);
            }
            set
            {
                if (_layout != null)
                {
                    // Note: it only works if minimum size is >= than natural size.
                    // To force the size it should be done through the width&height spec or Size2D.
                    _layout.MinimumWidth = new Tizen.NUI.LayoutLength(value.Width);
                    _layout.MinimumHeight = new Tizen.NUI.LayoutLength(value.Height);
                    _layout.RequestLayout();
                }
                SetValue(MinimumSizeProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the maximum size the view can be assigned in size negotiation.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Size2D MaximumSize
        {
            get
            {
                return (Size2D)GetValue(MaximumSizeProperty);
            }
            set
            {
                // We don't have Layout.Maximum(Width|Height) so we cannot apply it to layout.
                // MATCH_PARENT spec + parent container size can be used to limit
                if (_layout != null)
                {
                    // Note: it only works if minimum size is >= than natural size.
                    // To force the size it should be done through the width&height spec or Size2D.
                    _layout.MinimumHeight = new Tizen.NUI.LayoutLength(value.Width);
                    _layout.MinimumWidth = new Tizen.NUI.LayoutLength(value.Height);
                    _layout.RequestLayout();
                }
                SetValue(MaximumSizeProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets whether a child view inherits it's parent's position.<br />
        /// Default is to inherit.<br />
        /// Switching this off means that using position sets the view's world position, i.e., translates from the world origin (0,0,0) to the pivot point of the view.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool InheritPosition
        {
            get
            {
                return (bool)GetValue(InheritPositionProperty);
            }
            set
            {
                SetValue(InheritPositionProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the clipping behavior (mode) of it's children.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ClippingModeType ClippingMode
        {
            get
            {
                return (ClippingModeType)GetValue(ClippingModeProperty);
            }
            set
            {
                SetValue(ClippingModeProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the number of renderers held by the view.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint RendererCount
        {
            get
            {
                return GetRendererCount();
            }
        }

        /// <summary>
        /// [Obsolete("Please do not use! this will be deprecated")]
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// Please do not use! this will be deprecated!
        /// Instead please use PivotPoint.
        [Obsolete("Please do not use! This will be deprecated! Please use PivotPoint instead! " +
            "Like: " +
            "View view = new View(); " +
            "view.PivotPoint = PivotPoint.Center; " +
            "view.PositionUsesPivotPoint = true;")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position AnchorPoint
        {
            get
            {
                Position temp = new Position(0.0f, 0.0f, 0.0f);
                GetProperty(View.Property.ANCHOR_POINT).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.ANCHOR_POINT, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Sets the size of a view for the width, the height and the depth.<br />
        /// Geometry can be scaled to fit within this area.<br />
        /// This does not interfere with the view's scale factor.<br />
        /// The views default depth is the minimum of width and height.<br />
        /// </summary>
        /// <remarks>
        /// Please note that multi-cascade setting is not possible for this NUI object. <br />
        /// It is recommended that NUI object typed properties are configured by their constructor with parameters. <br />
        /// For example, this code is working fine : view.Size = new Size( 1.0f, 1.0f, 0.0f); <br />
        /// but this will not work! : view.Size.Width = 2.0f; view.Size.Height = 2.0f; <br />
        /// It may not match the current value in some cases, i.e. when the animation is progressing or the maximum or minimu size is set. <br />
        /// </remarks>
        /// <since_tizen> 5 </since_tizen>
        public Size Size
        {
            get
            {
                return (Size)GetValue(SizeProperty);
            }
            set
            {
                SetValue(SizeProperty, value);
                // Set Specification so when layouts measure this View it matches the value set here.
                // All Views are currently Layouts.
                WidthSpecification = (int)Math.Ceiling(value.Width);
                HeightSpecification = (int)Math.Ceiling(value.Height);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// "Please DO NOT use! This will be deprecated! Please use 'Container GetParent() for derived class' instead!"
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Please do not use! This will be deprecated! Please use 'Container GetParent() for derived class' instead! " +
            "Like: " +
            "Container parent =  view.GetParent(); " +
            "View view = parent as View;")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new View Parent
        {
            get
            {
                View ret;
                IntPtr cPtr = Interop.Actor.Actor_GetParent(swigCPtr);
                HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
                BaseHandle basehandle = Registry.GetManagedBaseHandleFromNativePtr(CPtr.Handle);

                if (basehandle is Layer layer)
                {
                    ret = new View(Layer.getCPtr(layer).Handle, false);
                    NUILog.Error("This Parent property is deprecated, shoud do not be used");
                }
                else
                {
                    ret = basehandle as View;
                }

                Interop.BaseHandle.delete_BaseHandle(CPtr);
                CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);

                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Gets/Sets whether inherit parent's the layout Direction.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public bool InheritLayoutDirection
        {
            get
            {
                return (bool)GetValue(InheritLayoutDirectionProperty);
            }
            set
            {
                SetValue(InheritLayoutDirectionProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets/Sets the layout Direction.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public ViewLayoutDirectionType LayoutDirection
        {
            get
            {
                return (ViewLayoutDirectionType)GetValue(LayoutDirectionProperty);
            }
            set
            {
                SetValue(LayoutDirectionProperty, value);
                NotifyPropertyChanged();
                _layout?.RequestLayout();
            }
        }

        /// <summary>
        /// Gets or sets the Margin for use in layout.
        /// </summary>
        /// <remarks>
        /// Margin property is supported by Layout algorithms and containers.
        /// Please Set Layout if you want to use Margin property.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        public Extents Margin
        {
            get
            {
                return (Extents)GetValue(MarginProperty);
            }
            set
            {
                SetValue(MarginProperty, value);
                NotifyPropertyChanged();
                _layout?.RequestLayout();
            }
        }

        ///<summary>
        /// The required policy for this dimension, ChildLayoutData enum or exact value.
        ///</summary>
        public int WidthSpecification
        {
            get
            {
                return _widthPolicy;
            }
            set
            {
                _widthPolicy = value;
                if (_widthPolicy >= 0)
                {
                    _measureSpecificationWidth = new MeasureSpecification( new LayoutLength(value), MeasureSpecification.ModeType.Exactly );
                    Size2D.Width = _widthPolicy;
                }
                _layout?.RequestLayout();
            }
        }

        ///<summary>
        /// The required policy for this dimension, ChildLayoutData enum or exact value.
        ///</summary>
        public int HeightSpecification
        {
            get
            {
                return _heightPolicy;
            }
            set
            {
                _heightPolicy = value;
                if (_heightPolicy >= 0)
                {
                    _measureSpecificationHeight = new MeasureSpecification( new LayoutLength(value), MeasureSpecification.ModeType.Exactly );
                    Size2D.Height = _heightPolicy;
                }
               _layout?.RequestLayout();
            }
        }

        /// <summary>
        /// [Obsolete("Please do not use! this will be deprecated")]
        /// </summary>
        /// Please do not use! this will be deprecated!
        /// Instead please use Padding.
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! this will be deprecated, instead please use Padding.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Extents PaddingEX
        {
            get
            {
                Extents temp = new Extents(0, 0, 0, 0);
                GetProperty(View.Property.PADDING).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.PADDING, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
                _layout?.RequestLayout();
            }
        }

        internal Style Style
        {
            get
            {
                return (Style)GetValue(StyleProperty);
            }
            set
            {
                SetValue(StyleProperty, value);
            }
        }

        /// <summary>
        /// Child property to specify desired width
        /// </summary>
        internal int LayoutWidthSpecificationFixed
        {
            get
            {
                return _widthPolicy;
            }
            set
            {
                _widthPolicy = value;
                _measureSpecificationWidth = new MeasureSpecification(new LayoutLength(value), MeasureSpecification.ModeType.Exactly);
                Size2D.Width = value;
                _layout?.RequestLayout();
            }
        }

        /// <summary>
        /// Child property to specify desired height
        /// </summary>
        internal int LayoutHeightSpecificationFixed
        {
            get
            {
                return _heightPolicy;
            }
            set
            {
                _heightPolicy = value;
                _measureSpecificationHeight = new MeasureSpecification(new LayoutLength(value), MeasureSpecification.ModeType.Exactly);
                Size2D.Height = value;
                _layout?.RequestLayout();
            }
        }

        /// <summary>
        /// Child property to specify desired width, use MatchParent/WrapContent)
        /// </summary>
        internal ChildLayoutData LayoutWidthSpecification
        {
            get
            {
                return (ChildLayoutData)_widthPolicy;
            }
            set
            {
                _widthPolicy = (int)value;
            }
        }

        /// <summary>
        /// Child property to specify desired height, use MatchParent/WrapContent)
        /// </summary>
        internal ChildLayoutData LayoutHeightSpecification
        {
            get
            {
                return (ChildLayoutData)_heightPolicy;
            }
            set
            {
                _heightPolicy = (int)value;
            }
        }

        internal float Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
                _layout.RequestLayout();
            }
        }

        internal bool BackgroundImageSynchronosLoading
        {
            get
            {
                return _backgroundImageSynchronosLoading;
            }
            set
            {
                if (value != _backgroundImageSynchronosLoading)
                {
                    string bgUrl = "";
                    PropertyMap bgMap = this.Background;
                    int visualType = 0;
                    bgMap.Find(Visual.Property.Type)?.Get(out visualType);
                    if (visualType == (int)Visual.Type.Image)
                    {
                        bgMap.Find(ImageVisualProperty.URL)?.Get(out bgUrl);
                    }
                    if (bgUrl.Length != 0)
                    {
                        _backgroundImageSynchronosLoading = value;
                        bgMap.Add("synchronousLoading", new PropertyValue(_backgroundImageSynchronosLoading));
                        this.Background = bgMap;
                    }
                }
            }
        }

        internal float WorldPositionX
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.WORLD_POSITION_X).Get(out temp);
                return temp;
            }
        }

        internal float WorldPositionY
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.WORLD_POSITION_Y).Get(out temp);
                return temp;
            }
        }

        internal float WorldPositionZ
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.WORLD_POSITION_Z).Get(out temp);
                return temp;
            }
        }

        internal bool FocusState
        {
            get
            {
                return IsKeyboardFocusable();
            }
            set
            {
                SetKeyboardFocusable(value);
            }
        }

        /// <summary>
        /// Set the layout on this View. Replaces any existing Layout.
        /// </summary>
        /// <remarks>
        /// </remarks>
        internal LayoutItem Layout
        {
            get
            {
                return _layout;
            }
            set
            {
                // Do nothing if layout provided is already set on this View.
                if (value == _layout)
                {
                    return;
                }

                Log.Info("NUI", "Setting Layout on:" + Name + "\n");
                layoutingDisabled = false;
                layoutSet = true;

                // If new layout being set already has a owner then that owner receives a replacement default layout.
                // First check if the layout to be set already has a owner.
                if ( value.Owner != null )
                {
                    Log.Info("NUI", "Set layout already in use by another View: " + value.Owner.Name + "will get a LayoutGroup\n");
                    // Previous owner of the layout gets a default layout as a replacement.
                    value.Owner.Layout = new LayoutGroup();
                }

                // Remove existing layout from it's parent layout group.
                _layout?.Unparent();

                // Set layout to this view
                SetLayout(value);
            }
        }

        internal void SetLayout(LayoutItem layout)
        {
            _layout = layout;
            _layout.AttachToOwner(this);
            _layout.RequestLayout();
        }

        /// <summary>
        /// Stores the calculated width value and its ModeType. Width component.
        /// </summary>
        internal MeasureSpecification MeasureSpecificationWidth
        {
            set
            {
                _measureSpecificationWidth = value;
                _layout?.RequestLayout();
            }
            get
            {
                return _measureSpecificationWidth;
            }
        }

        /// <summary>
        /// Stores the calculated width value and its ModeType. Height component.
        /// </summary>
        internal MeasureSpecification MeasureSpecificationHeight
        {
            set
            {
                _measureSpecificationHeight = value;
                _layout?.RequestLayout();
            }
            get
            {
                return _measureSpecificationHeight;
            }
        }

        internal float ParentOriginX
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.PARENT_ORIGIN_X).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.PARENT_ORIGIN_X, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        internal float ParentOriginY
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.PARENT_ORIGIN_Y).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.PARENT_ORIGIN_Y, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        internal float ParentOriginZ
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.PARENT_ORIGIN_Z).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.PARENT_ORIGIN_Z, new Tizen.NUI.PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        internal float PivotPointX
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.ANCHOR_POINT_X).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.ANCHOR_POINT_X, new Tizen.NUI.PropertyValue(value));
            }
        }

        internal float PivotPointY
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.ANCHOR_POINT_Y).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.ANCHOR_POINT_Y, new Tizen.NUI.PropertyValue(value));
            }
        }

        internal float PivotPointZ
        {
            get
            {
                float temp = 0.0f;
                GetProperty(View.Property.ANCHOR_POINT_Z).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.ANCHOR_POINT_Z, new Tizen.NUI.PropertyValue(value));
            }
        }

        internal Matrix WorldMatrix
        {
            get
            {
                Matrix temp = new Matrix();
                GetProperty(View.Property.WORLD_MATRIX).Get(temp);
                return temp;
            }
        }

        private int LeftFocusableViewId
        {
            get
            {
                int temp = 0;
                GetProperty(View.Property.LEFT_FOCUSABLE_VIEW_ID).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.LEFT_FOCUSABLE_VIEW_ID, new Tizen.NUI.PropertyValue(value));
            }
        }

        private int RightFocusableViewId
        {
            get
            {
                int temp = 0;
                GetProperty(View.Property.RIGHT_FOCUSABLE_VIEW_ID).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.RIGHT_FOCUSABLE_VIEW_ID, new Tizen.NUI.PropertyValue(value));
            }
        }

        private int UpFocusableViewId
        {
            get
            {
                int temp = 0;
                GetProperty(View.Property.UP_FOCUSABLE_VIEW_ID).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.UP_FOCUSABLE_VIEW_ID, new Tizen.NUI.PropertyValue(value));
            }
        }

        private int DownFocusableViewId
        {
            get
            {
                int temp = 0;
                GetProperty(View.Property.DOWN_FOCUSABLE_VIEW_ID).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(View.Property.DOWN_FOCUSABLE_VIEW_ID, new Tizen.NUI.PropertyValue(value));
            }
        }

        /// <summary>
        /// Perform an action on a visual registered to this view. <br />
        /// Visuals will have actions. This API is used to perform one of these actions with the given attributes.
        /// </summary>
        /// <param name="propertyIndexOfVisual">The Property index of the visual.</param>
        /// <param name="propertyIndexOfActionId">The action to perform. See Visual to find the supported actions.</param>
        /// <param name="attributes">Optional attributes for the action.</param>
        /// <since_tizen> 5 </since_tizen>
        public void DoAction(int propertyIndexOfVisual, int propertyIndexOfActionId, PropertyValue attributes)
        {
            Interop.View.View_DoAction(swigCPtr, propertyIndexOfVisual, propertyIndexOfActionId, PropertyValue.getCPtr(attributes));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates an animation to animate the background color visual. If there is no
        /// background visual, creates one with transparent black as it's mixColor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Animation AnimateBackgroundColor(object destinationValue,
                                                 int startTime,
                                                 int endTime,
                                                 AlphaFunction.BuiltinFunctions? alphaFunction = null,
                                                 object initialValue = null)
        {
            Tizen.NUI.PropertyMap background = Background;

            if (background.Empty())
            {
                // If there is no background yet, ensure there is a transparent
                // color visual
                BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                background = Background;
            }
            return AnimateColor("background", destinationValue, startTime, endTime, alphaFunction, initialValue);
        }

        /// <summary>
        /// Creates an animation to animate the mixColor of the named visual.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Animation AnimateColor(string targetVisual, object destinationColor, int startTime, int endTime, AlphaFunction.BuiltinFunctions? alphaFunction = null, object initialColor = null)
        {
            Animation animation = null;
            {
                PropertyMap _animator = new PropertyMap();
                if (alphaFunction != null)
                {
                    _animator.Add("alphaFunction", new PropertyValue(AlphaFunction.BuiltinToPropertyKey(alphaFunction)));
                }

                PropertyMap _timePeriod = new PropertyMap();
                _timePeriod.Add("duration", new PropertyValue((endTime - startTime) / 1000.0f));
                _timePeriod.Add("delay", new PropertyValue(startTime / 1000.0f));
                _animator.Add("timePeriod", new PropertyValue(_timePeriod));

                PropertyMap _transition = new PropertyMap();
                _transition.Add("animator", new PropertyValue(_animator));
                _transition.Add("target", new PropertyValue(targetVisual));
                _transition.Add("property", new PropertyValue("mixColor"));

                if (initialColor != null)
                {
                    PropertyValue initValue = PropertyValue.CreateFromObject(initialColor);
                    _transition.Add("initialValue", initValue);
                }

                PropertyValue destValue = PropertyValue.CreateFromObject(destinationColor);
                _transition.Add("targetValue", destValue);
                TransitionData _transitionData = new TransitionData(_transition);

                animation = new Animation(Interop.View.View_CreateTransition(swigCPtr, TransitionData.getCPtr(_transitionData)), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return animation;
        }

        // From Container Base class
        /// <summary>
        /// Adds a child view to this view.
        /// </summary>
        /// <seealso cref="Container.Add" />
        /// <since_tizen> 4 </since_tizen>
        public override void Add(View child)
        {
            bool hasLayout = (_layout != null);
            Log.Info("NUI", "Add:" + child.Name + " to View:" + Name + "which has layout[" + hasLayout + "] + \n");

            if (null == child)
            {
                Tizen.Log.Fatal("NUI", "Child is null");
                return;
            }

            Container oldParent = child.GetParent();
            if (oldParent != this)
            {
                // If child already has a parent then re-parent child
                if (oldParent != null)
                {
                    oldParent.Remove(child);
                }
                child.InternalParent = this;

                Interop.Actor.Actor_Add(swigCPtr, View.getCPtr(child));
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                Children.Add(child);

                if (ChildAdded != null)
                {
                    ChildAddedEventArgs e = new ChildAddedEventArgs
                    {
                        Added = child
                    };
                    ChildAdded(this, e);
                }
            }
        }

        /// <summary>
        /// Removes a child view from this View. If the view was not a child of this view, this is a no-op.
        /// </summary>
        /// <seealso cref="Container.Remove" />
        /// <since_tizen> 4 </since_tizen>
        public override void Remove(View child)
        {
            bool hasLayout = (_layout != null);
            Log.Info("NUI","Removing View:" + child.Name + "layout[" + hasLayout.ToString() +"]\n");

            Interop.Actor.Actor_Remove(swigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            Children.Remove(child);
            child.InternalParent = null;

            if (ChildRemoved != null)
            {
                ChildRemovedEventArgs e = new ChildRemovedEventArgs
                {
                    Removed = child
                };
                ChildRemoved(this, e);
            }
        }

        /// <summary>
        /// Retrieves a child view by index.
        /// </summary>
        /// <seealso cref="Container.GetChildAt" />
        /// <since_tizen> 4 </since_tizen>
        public override View GetChildAt(uint index)
        {
            if (index < Children.Count)
            {
                return Children[Convert.ToInt32(index)];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves the number of children held by the view.
        /// </summary>
        /// <seealso cref="Container.GetChildCount" />
        /// <since_tizen> 4 </since_tizen>
        public override uint GetChildCount()
        {
            return Convert.ToUInt32(Children.Count);
        }

        /// <summary>
        /// Gets the views parent.
        /// </summary>
        /// <seealso cref="Container.GetParent()" />
        /// <since_tizen> 4 </since_tizen>
        public override Container GetParent()
        {
            return this.InternalParent as Container;
        }

        /// <summary>
        /// Queries whether the view has a focus.
        /// </summary>
        /// <returns>True if this view has a focus.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool HasFocus()
        {
            bool ret = Interop.View.View_HasKeyInputFocus(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the name of the style to be applied to the view.
        /// </summary>
        /// <param name="styleName">A string matching a style described in a stylesheet.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetStyleName(string styleName)
        {
            Interop.View.View_SetStyleName(swigCPtr, styleName);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the name of the style to be applied to the view (if any).
        /// </summary>
        /// <returns>A string matching a style, or an empty string.</returns>
        /// <since_tizen> 3 </since_tizen>
        public string GetStyleName()
        {
            string ret = Interop.View.View_GetStyleName(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Clears the background.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void ClearBackground()
        {
            Interop.View.View_ClearBackground(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Shows the view.
        /// </summary>
        /// <remarks>
        /// This is an asynchronous method.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public void Show()
        {
            SetVisible(true);
        }

        /// <summary>
        /// Hides the view.
        /// </summary>
        /// <remarks>
        /// This is an asynchronous method.
        /// If the view is hidden, then the view and its children will not be rendered.
        /// This is regardless of the individual visibility of the children, i.e., the view will only be rendered if all of its parents are shown.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public void Hide()
        {
            SetVisible(false);
        }

        /// <summary>
        /// Raises the view above all other views.
        /// </summary>
        /// <remarks>
        /// Sibling order of views within the parent will be updated automatically.
        /// Once a raise or lower API is used, that view will then have an exclusive sibling order independent of insertion.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public void RaiseToTop()
        {
            var parentChildren = GetParent()?.Children;

            if (parentChildren != null)
            {
                parentChildren.Remove(this);
                parentChildren.Add(this);

                Interop.NDalic.RaiseToTop(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

        }

        /// <summary>
        /// Lowers the view to the bottom of all views.
        /// </summary>
        /// <remarks>
        /// The sibling order of views within the parent will be updated automatically.
        /// Once a raise or lower API is used that view will then have an exclusive sibling order independent of insertion.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public void LowerToBottom()
        {
            var parentChildren = GetParent()?.Children;

            if (parentChildren != null)
            {
                parentChildren.Remove(this);
                parentChildren.Insert(0, this);

                Interop.NDalic.LowerToBottom(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Queries if all resources required by a view are loaded and ready.
        /// </summary>
        /// <remarks>Most resources are only loaded when the control is placed on the stage.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public bool IsResourceReady()
        {
            bool ret = Interop.View.IsResourceReady(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Gets the parent layer of this view.If a view has no parent, this method does not do anything.
        /// </summary>
        /// <pre>The view has been initialized. </pre>
        /// <returns>The parent layer of view </returns>
        /// <since_tizen> 5 </since_tizen>
        public Layer GetLayer()
        {
            //to fix memory leak issue, match the handle count with native side.
            IntPtr cPtr = Interop.Actor.Actor_GetLayer(swigCPtr);
            HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            Layer ret = Registry.GetManagedBaseHandleFromNativePtr(CPtr.Handle) as Layer;
            Interop.BaseHandle.delete_BaseHandle(CPtr);
            CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Removes a view from its parent view or layer. If a view has no parent, this method does nothing.
        /// </summary>
        /// <pre>The (child) view has been initialized. </pre>
        /// <since_tizen> 4 </since_tizen>
        public void Unparent()
        {
            GetParent()?.Remove(this);
        }

        /// <summary>
        /// Search through this view's hierarchy for a view with the given name.
        /// The view itself is also considered in the search.
        /// </summary>
        /// <pre>The view has been initialized.</pre>
        /// <param name="viewName">The name of the view to find.</param>
        /// <returns>A handle to the view if found, or an empty handle if not.</returns>
        /// <since_tizen> 3 </since_tizen>
        public View FindChildByName(string viewName)
        {
            //to fix memory leak issue, match the handle count with native side.
            IntPtr cPtr = Interop.Actor.Actor_FindChildByName(swigCPtr, viewName);
            HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            View ret = Registry.GetManagedBaseHandleFromNativePtr(CPtr.Handle) as View;
            Interop.BaseHandle.delete_BaseHandle(CPtr);
            CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Converts screen coordinates into the view's coordinate system using the default camera.
        /// </summary>
        /// <pre>The view has been initialized.</pre>
        /// <remarks>The view coordinates are relative to the top-left(0.0, 0.0, 0.5).</remarks>
        /// <param name="localX">On return, the X-coordinate relative to the view.</param>
        /// <param name="localY">On return, the Y-coordinate relative to the view.</param>
        /// <param name="screenX">The screen X-coordinate.</param>
        /// <param name="screenY">The screen Y-coordinate.</param>
        /// <returns>True if the conversion succeeded.</returns>
        /// <since_tizen> 3 </since_tizen>
        public bool ScreenToLocal(out float localX, out float localY, float screenX, float screenY)
        {
            bool ret = Interop.Actor.Actor_ScreenToLocal(swigCPtr, out localX, out localY, screenX, screenY);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Sets the relative to parent size factor of the view.<br />
        /// This factor is only used when ResizePolicy is set to either:
        /// ResizePolicy::SIZE_RELATIVE_TO_PARENT or ResizePolicy::SIZE_FIXED_OFFSET_FROM_PARENT.<br />
        /// This view's size is set to the view's size multiplied by or added to this factor, depending on ResizePolicy.<br />
        /// </summary>
        /// <pre>The view has been initialized.</pre>
        /// <param name="factor">A Vector3 representing the relative factor to be applied to each axis.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetSizeModeFactor(Vector3 factor)
        {
            Interop.Actor.Actor_SetSizeModeFactor(swigCPtr, Vector3.getCPtr(factor));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
        /// <summary>
        /// Calculates the height of the view given a width.<br />
        /// The natural size is used for default calculation.<br />
        /// Size 0 is treated as aspect ratio 1:1.<br />
        /// </summary>
        /// <param name="width">The width to use.</param>
        /// <returns>The height based on the width.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetHeightForWidth(float width)
        {
            float ret = Interop.Actor.Actor_GetHeightForWidth(swigCPtr, width);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Calculates the width of the view given a height.<br />
        /// The natural size is used for default calculation.<br />
        /// Size 0 is treated as aspect ratio 1:1.<br />
        /// </summary>
        /// <param name="height">The height to use.</param>
        /// <returns>The width based on the height.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetWidthForHeight(float height)
        {
            float ret = Interop.Actor.Actor_GetWidthForHeight(swigCPtr, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Return the amount of size allocated for relayout.
        /// </summary>
        /// <param name="dimension">The dimension to retrieve.</param>
        /// <returns>Return the size.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetRelayoutSize(DimensionType dimension)
        {
            float ret = Interop.Actor.Actor_GetRelayoutSize(swigCPtr, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Set the padding for the view.
        /// </summary>
        /// <param name="padding">Padding for the view.</param>
        /// <since_tizen> 3 </since_tizen>
        public void SetPadding(PaddingType padding)
        {
            Interop.Actor.Actor_SetPadding(swigCPtr, PaddingType.getCPtr(padding));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Return the value of padding for the view.
        /// </summary>
        /// <param name="paddingOut">the value of padding for the view</param>
        /// <since_tizen> 3 </since_tizen>
        public void GetPadding(PaddingType paddingOut)
        {
            Interop.Actor.Actor_GetPadding(swigCPtr, PaddingType.getCPtr(paddingOut));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <since_tizen> 3 </since_tizen>
        public uint AddRenderer(Renderer renderer)
        {
            uint ret = Interop.Actor.Actor_AddRenderer(swigCPtr, Renderer.getCPtr(renderer));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <since_tizen> 3 </since_tizen>
        public Renderer GetRendererAt(uint index)
        {
            //to fix memory leak issue, match the handle count with native side.
            IntPtr cPtr = Interop.Actor.Actor_GetRendererAt(swigCPtr, index);
            HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            Renderer ret = Registry.GetManagedBaseHandleFromNativePtr(CPtr.Handle) as Renderer;
            if (cPtr != null && ret == null)
            {
                ret = new Renderer(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
            Interop.BaseHandle.delete_BaseHandle(CPtr);
            CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <since_tizen> 3 </since_tizen>
        public void RemoveRenderer(Renderer renderer)
        {
            Interop.Actor.Actor_RemoveRenderer__SWIG_0(swigCPtr, Renderer.getCPtr(renderer));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <since_tizen> 3 </since_tizen>
        public void RemoveRenderer(uint index)
        {
            Interop.Actor.Actor_RemoveRenderer__SWIG_1(swigCPtr, index);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void Raise()
        {
            var parentChildren = GetParent()?.Children;

            if (parentChildren != null)
            {
                int currentIndex = parentChildren.IndexOf(this);

                // If the view is not already the last item in the list.
                if (currentIndex >= 0 && currentIndex < parentChildren.Count - 1)
                {
                    View temp = parentChildren[currentIndex + 1];
                    parentChildren[currentIndex + 1] = this;
                    parentChildren[currentIndex] = temp;

                    Interop.NDalic.Raise(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending)
                        throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }
        }

        internal void Lower()
        {
            var parentChildren = GetParent()?.Children;

            if (parentChildren != null)
            {
                int currentIndex = parentChildren.IndexOf(this);

                // If the view is not already the first item in the list.
                if (currentIndex > 0 && currentIndex < parentChildren.Count)
                {
                    View temp = parentChildren[currentIndex - 1];
                    parentChildren[currentIndex - 1] = this;
                    parentChildren[currentIndex] = temp;

                    Interop.NDalic.Lower(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending)
                        throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }
        }

        /// <summary>
        /// Raises the view to above the target view.
        /// </summary>
        /// <remarks>The sibling order of views within the parent will be updated automatically.
        /// Views on the level above the target view will still be shown above this view.
        /// Raising this view above views with the same sibling order as each other will raise this view above them.
        /// Once a raise or lower API is used that view will then have an exclusive sibling order independent of insertion.
        /// </remarks>
        /// <param name="target">Will be raised above this view.</param>
        internal void RaiseAbove(View target)
        {
            var parentChildren = GetParent()?.Children;

            if (parentChildren != null)
            {
                int currentIndex = parentChildren.IndexOf(this);
                int targetIndex = parentChildren.IndexOf(target);

                if (currentIndex < 0 || targetIndex < 0 ||
                    currentIndex >= parentChildren.Count || targetIndex >= parentChildren.Count)
                {
                    NUILog.Error("index should be bigger than 0 and less than children of layer count");
                    return;
                }
                // If the currentIndex is less than the target index and the target has the same parent.
                if (currentIndex < targetIndex)
                {
                    parentChildren.Remove(this);
                    parentChildren.Insert(targetIndex, this);

                    Interop.NDalic.RaiseAbove(swigCPtr, View.getCPtr(target));
                    if (NDalicPINVOKE.SWIGPendingException.Pending)
                        throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }

        }

        /// <summary>
        /// Lowers the view to below the target view.
        /// </summary>
        /// <remarks>The sibling order of views within the parent will be updated automatically.
        /// Lowering this view below views with the same sibling order as each other will lower this view above them.
        /// Once a raise or lower API is used that view will then have an exclusive sibling order independent of insertion.
        /// </remarks>
        /// <param name="target">Will be lowered below this view.</param>
        internal void LowerBelow(View target)
        {
            var parentChildren = GetParent()?.Children;

            if (parentChildren != null)
            {
                int currentIndex = parentChildren.IndexOf(this);
                int targetIndex = parentChildren.IndexOf(target);
                if (currentIndex < 0 || targetIndex < 0 ||
                   currentIndex >= parentChildren.Count || targetIndex >= parentChildren.Count)
                {
                    NUILog.Error("index should be bigger than 0 and less than children of layer count");
                    return;
                }

                // If the currentIndex is not already the 0th index and the target has the same parent.
                if ((currentIndex != 0) && (targetIndex != -1) &&
                    (currentIndex > targetIndex))
                {
                    parentChildren.Remove(this);
                    parentChildren.Insert(targetIndex, this);

                    Interop.NDalic.LowerBelow(swigCPtr, View.getCPtr(target));
                    if (NDalicPINVOKE.SWIGPendingException.Pending)
                        throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }

        }

        internal string GetName()
        {
            string ret = Interop.Actor.Actor_GetName(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetName(string name)
        {
            Interop.Actor.Actor_SetName(swigCPtr, name);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal uint GetId()
        {
            uint ret = Interop.Actor.Actor_GetId(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal bool IsRoot()
        {
            bool ret = Interop.ActorInternal.Actor_IsRoot(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal bool OnWindow()
        {
            bool ret = Interop.Actor.Actor_OnStage(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal View FindChildById(uint id)
        {
            //to fix memory leak issue, match the handle count with native side.
            IntPtr cPtr = Interop.Actor.Actor_FindChildById(swigCPtr, id);
            HandleRef CPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            View ret = Registry.GetManagedBaseHandleFromNativePtr(CPtr.Handle) as View;
            Interop.BaseHandle.delete_BaseHandle(CPtr);
            CPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);

            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetParentOrigin(Vector3 origin)
        {
            Interop.ActorInternal.Actor_SetParentOrigin(swigCPtr, Vector3.getCPtr(origin));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector3 GetCurrentParentOrigin()
        {
            Vector3 ret = new Vector3(Interop.ActorInternal.Actor_GetCurrentParentOrigin(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetAnchorPoint(Vector3 anchorPoint)
        {
            Interop.Actor.Actor_SetAnchorPoint(swigCPtr, Vector3.getCPtr(anchorPoint));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector3 GetCurrentAnchorPoint()
        {
            Vector3 ret = new Vector3(Interop.ActorInternal.Actor_GetCurrentAnchorPoint(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetSize(float width, float height)
        {
            Interop.ActorInternal.Actor_SetSize__SWIG_0(swigCPtr, width, height);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetSize(float width, float height, float depth)
        {
            Interop.ActorInternal.Actor_SetSize__SWIG_1(swigCPtr, width, height, depth);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetSize(Vector2 size)
        {
            Interop.ActorInternal.Actor_SetSize__SWIG_2(swigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetSize(Vector3 size)
        {
            Interop.ActorInternal.Actor_SetSize__SWIG_3(swigCPtr, Vector3.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector3 GetTargetSize()
        {
            Vector3 ret = new Vector3(Interop.ActorInternal.Actor_GetTargetSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Size2D GetCurrentSize()
        {
            Size ret = new Size(Interop.Actor.Actor_GetCurrentSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            Size2D size = new Size2D((int)ret.Width, (int)ret.Height);
            return size;
        }

        internal Vector3 GetNaturalSize()
        {
            Vector3 ret = new Vector3(Interop.Actor.Actor_GetNaturalSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetPosition(float x, float y)
        {
            Interop.ActorInternal.Actor_SetPosition__SWIG_0(swigCPtr, x, y);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetPosition(float x, float y, float z)
        {
            Interop.ActorInternal.Actor_SetPosition__SWIG_1(swigCPtr, x, y, z);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetPosition(Vector3 position)
        {
            Interop.ActorInternal.Actor_SetPosition__SWIG_2(swigCPtr, Vector3.getCPtr(position));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetX(float x)
        {
            Interop.ActorInternal.Actor_SetX(swigCPtr, x);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetY(float y)
        {
            Interop.ActorInternal.Actor_SetY(swigCPtr, y);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetZ(float z)
        {
            Interop.ActorInternal.Actor_SetZ(swigCPtr, z);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void TranslateBy(Vector3 distance)
        {
            Interop.ActorInternal.Actor_TranslateBy(swigCPtr, Vector3.getCPtr(distance));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Position GetCurrentPosition()
        {
            Position ret = new Position(Interop.Actor.Actor_GetCurrentPosition(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector3 GetCurrentWorldPosition()
        {
            Vector3 ret = new Vector3(Interop.ActorInternal.Actor_GetCurrentWorldPosition(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetInheritPosition(bool inherit)
        {
            Interop.ActorInternal.Actor_SetInheritPosition(swigCPtr, inherit);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsPositionInherited()
        {
            bool ret = Interop.ActorInternal.Actor_IsPositionInherited(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetOrientation(Degree angle, Vector3 axis)
        {
            Interop.ActorInternal.Actor_SetOrientation__SWIG_0(swigCPtr, Degree.getCPtr(angle), Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetOrientation(Radian angle, Vector3 axis)
        {
            Interop.ActorInternal.Actor_SetOrientation__SWIG_1(swigCPtr, Radian.getCPtr(angle), Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetOrientation(Rotation orientation)
        {
            Interop.ActorInternal.Actor_SetOrientation__SWIG_2(swigCPtr, Rotation.getCPtr(orientation));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void RotateBy(Degree angle, Vector3 axis)
        {
            Interop.ActorInternal.Actor_RotateBy__SWIG_0(swigCPtr, Degree.getCPtr(angle), Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void RotateBy(Radian angle, Vector3 axis)
        {
            Interop.ActorInternal.Actor_RotateBy__SWIG_1(swigCPtr, Radian.getCPtr(angle), Vector3.getCPtr(axis));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void RotateBy(Rotation relativeRotation)
        {
            Interop.ActorInternal.Actor_RotateBy__SWIG_2(swigCPtr, Rotation.getCPtr(relativeRotation));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Rotation GetCurrentOrientation()
        {
            Rotation ret = new Rotation(Interop.ActorInternal.Actor_GetCurrentOrientation(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetInheritOrientation(bool inherit)
        {
            Interop.ActorInternal.Actor_SetInheritOrientation(swigCPtr, inherit);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsOrientationInherited()
        {
            bool ret = Interop.ActorInternal.Actor_IsOrientationInherited(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Rotation GetCurrentWorldOrientation()
        {
            Rotation ret = new Rotation(Interop.ActorInternal.Actor_GetCurrentWorldOrientation(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetScale(float scale)
        {
            Interop.ActorInternal.Actor_SetScale__SWIG_0(swigCPtr, scale);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetScale(float scaleX, float scaleY, float scaleZ)
        {
            Interop.ActorInternal.Actor_SetScale__SWIG_1(swigCPtr, scaleX, scaleY, scaleZ);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void SetScale(Vector3 scale)
        {
            Interop.ActorInternal.Actor_SetScale__SWIG_2(swigCPtr, Vector3.getCPtr(scale));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void ScaleBy(Vector3 relativeScale)
        {
            Interop.ActorInternal.Actor_ScaleBy(swigCPtr, Vector3.getCPtr(relativeScale));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector3 GetCurrentScale()
        {
            Vector3 ret = new Vector3(Interop.ActorInternal.Actor_GetCurrentScale(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector3 GetCurrentWorldScale()
        {
            Vector3 ret = new Vector3(Interop.ActorInternal.Actor_GetCurrentWorldScale(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetInheritScale(bool inherit)
        {
            Interop.ActorInternal.Actor_SetInheritScale(swigCPtr, inherit);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsScaleInherited()
        {
            bool ret = Interop.ActorInternal.Actor_IsScaleInherited(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Matrix GetCurrentWorldMatrix()
        {
            Matrix ret = new Matrix(Interop.ActorInternal.Actor_GetCurrentWorldMatrix(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetVisible(bool visible)
        {
            Interop.Actor.Actor_SetVisible(swigCPtr, visible);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsVisible()
        {
            bool ret = Interop.ActorInternal.Actor_IsVisible(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetOpacity(float opacity)
        {
            Interop.ActorInternal.Actor_SetOpacity(swigCPtr, opacity);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal float GetCurrentOpacity()
        {
            float ret = Interop.ActorInternal.Actor_GetCurrentOpacity(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetColor(Vector4 color)
        {
            Interop.ActorInternal.Actor_SetColor(swigCPtr, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector4 GetCurrentColor()
        {
            Vector4 ret = new Vector4(Interop.ActorInternal.Actor_GetCurrentColor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetColorMode(ColorMode colorMode)
        {
            Interop.ActorInternal.Actor_SetColorMode(swigCPtr, (int)colorMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ColorMode GetColorMode()
        {
            ColorMode ret = (ColorMode)Interop.ActorInternal.Actor_GetColorMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector4 GetCurrentWorldColor()
        {
            Vector4 ret = new Vector4(Interop.ActorInternal.Actor_GetCurrentWorldColor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetDrawMode(DrawModeType drawMode)
        {
            Interop.ActorInternal.Actor_SetDrawMode(swigCPtr, (int)drawMode);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal DrawModeType GetDrawMode()
        {
            DrawModeType ret = (DrawModeType)Interop.ActorInternal.Actor_GetDrawMode(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetKeyboardFocusable(bool focusable)
        {
            Interop.ActorInternal.Actor_SetKeyboardFocusable(swigCPtr, focusable);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal bool IsKeyboardFocusable()
        {
            bool ret = Interop.ActorInternal.Actor_IsKeyboardFocusable(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetResizePolicy(ResizePolicyType policy, DimensionType dimension)
        {
            Interop.Actor.Actor_SetResizePolicy(swigCPtr, (int)policy, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ResizePolicyType GetResizePolicy(DimensionType dimension)
        {
            ResizePolicyType ret = (ResizePolicyType)Interop.Actor.Actor_GetResizePolicy(swigCPtr, (int)dimension);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Vector3 GetSizeModeFactor()
        {
            Vector3 ret = new Vector3(Interop.Actor.Actor_GetSizeModeFactor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetMinimumSize(Vector2 size)
        {
            Interop.ActorInternal.Actor_SetMinimumSize(swigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector2 GetMinimumSize()
        {
            Vector2 ret = new Vector2(Interop.ActorInternal.Actor_GetMinimumSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetMaximumSize(Vector2 size)
        {
            Interop.ActorInternal.Actor_SetMaximumSize(swigCPtr, Vector2.getCPtr(size));
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector2 GetMaximumSize()
        {
            Vector2 ret = new Vector2(Interop.ActorInternal.Actor_GetMaximumSize(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal int GetHierarchyDepth()
        {
            int ret = Interop.Actor.Actor_GetHierarchyDepth(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal uint GetRendererCount()
        {
            uint ret = Interop.Actor.Actor_GetRendererCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TouchDataSignal TouchSignal()
        {
            TouchDataSignal ret = new TouchDataSignal(Interop.ActorSignal.Actor_TouchSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal HoverSignal HoveredSignal()
        {
            HoverSignal ret = new HoverSignal(Interop.ActorSignal.Actor_HoveredSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WheelSignal WheelEventSignal()
        {
            WheelSignal ret = new WheelSignal(Interop.ActorSignal.Actor_WheelEventSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ViewSignal OnWindowSignal()
        {
            ViewSignal ret = new ViewSignal(Interop.ActorSignal.Actor_OnStageSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ViewSignal OffWindowSignal()
        {
            ViewSignal ret = new ViewSignal(Interop.ActorSignal.Actor_OffStageSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ViewSignal OnRelayoutSignal()
        {
            ViewSignal ret = new ViewSignal(Interop.ActorSignal.Actor_OnRelayoutSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ViewVisibilityChangedSignal VisibilityChangedSignal(View view)
        {
            ViewVisibilityChangedSignal ret = new ViewVisibilityChangedSignal(Interop.NDalic.VisibilityChangedSignal(View.getCPtr(view)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ViewLayoutDirectionChangedSignal LayoutDirectionChangedSignal(View view)
        {
            ViewLayoutDirectionChangedSignal ret = new ViewLayoutDirectionChangedSignal(Interop.Layout.LayoutDirectionChangedSignal(View.getCPtr(view)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal ViewSignal ResourcesLoadedSignal()
        {
            ViewSignal ret = new ViewSignal(Interop.View.ResourceReadySignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(View obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal bool IsTopLevelView()
        {
            if (GetParent() is Layer)
            {
                return true;
            }
            return false;
        }

        internal void SetKeyInputFocus()
        {
            Interop.ViewInternal.View_SetKeyInputFocus(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal void ClearKeyInputFocus()
        {
            Interop.ViewInternal.View_ClearKeyInputFocus(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PinchGestureDetector GetPinchGestureDetector()
        {
            PinchGestureDetector ret = new PinchGestureDetector(Interop.ViewInternal.View_GetPinchGestureDetector(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal PanGestureDetector GetPanGestureDetector()
        {
            PanGestureDetector ret = new PanGestureDetector(Interop.ViewInternal.View_GetPanGestureDetector(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TapGestureDetector GetTapGestureDetector()
        {
            TapGestureDetector ret = new TapGestureDetector(Interop.ViewInternal.View_GetTapGestureDetector(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal LongPressGestureDetector GetLongPressGestureDetector()
        {
            LongPressGestureDetector ret = new LongPressGestureDetector(Interop.ViewInternal.View_GetLongPressGestureDetector(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetBackgroundColor(Vector4 color)
        {
            Interop.ViewInternal.View_SetBackgroundColor(swigCPtr, Vector4.getCPtr(color));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Vector4 GetBackgroundColor()
        {
            Vector4 ret = new Vector4(Interop.ViewInternal.View_GetBackgroundColor(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void SetBackgroundImage(Image image)
        {
            Interop.ViewInternal.View_SetBackgroundImage(swigCPtr, Image.getCPtr(image));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ControlKeySignal KeyEventSignal()
        {
            ControlKeySignal ret = new ControlKeySignal(Interop.ViewSignal.View_KeyEventSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal KeyInputFocusSignal KeyInputFocusGainedSignal()
        {
            KeyInputFocusSignal ret = new KeyInputFocusSignal(Interop.ViewSignal.View_KeyInputFocusGainedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal KeyInputFocusSignal KeyInputFocusLostSignal()
        {
            KeyInputFocusSignal ret = new KeyInputFocusSignal(Interop.ViewSignal.View_KeyInputFocusLostSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal IntPtr GetPtrfromView()
        {
            return (IntPtr)swigCPtr;
        }

        /// <summary>
        /// Removes the layout from this View.
        /// </summary>
        internal void ResetLayout()
        {
            _layout = null;
        }

        internal ResourceLoadingStatusType GetBackgroundResourceStatus()
        {
            return (ResourceLoadingStatusType)Interop.View.View_GetVisualResourceStatus(this.swigCPtr, Property.BACKGROUND);
        }

        /// <summary>
        /// you can override it to clean-up your own resources.
        /// </summary>
        /// <param name="type">DisposeTypes</param>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            if (this != null)
            {
                DisConnectFromSignals();
            }

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.View.delete_View(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            foreach (View view in Children)
            {
                view.InternalParent = null;
            }

            base.Dispose(type);

        }

        private void OnSize2DChanged(int width, int height)
        {
            Size2D = new Size2D(width, height);
        }

        private void OnPosition2DChanged(int x, int y)
        {
            Position2D = new Position2D(x, y);
        }

        private void DisConnectFromSignals()
        {
            // Save current CPtr.
            global::System.Runtime.InteropServices.HandleRef currentCPtr = swigCPtr;

            // Use BaseHandle CPtr as current might have been deleted already in derived classes.
            swigCPtr = GetBaseHandleCPtrHandleRef;

            if (_onRelayoutEventCallback != null)
            {
                this.OnRelayoutSignal().Disconnect(_onRelayoutEventCallback);
            }

            if (_offWindowEventCallback != null)
            {
                this.OffWindowSignal().Disconnect(_offWindowEventCallback);
            }

            if (_onWindowEventCallback != null)
            {
                this.OnWindowSignal().Disconnect(_onWindowEventCallback);
            }

            if (_wheelEventCallback != null)
            {
                this.WheelEventSignal().Disconnect(_wheelEventCallback);
            }

            if (_hoverEventCallback != null)
            {
                this.HoveredSignal().Disconnect(_hoverEventCallback);
            }

            if (_touchDataCallback != null)
            {
                this.TouchSignal().Disconnect(_touchDataCallback);
            }

            if (_ResourcesLoadedCallback != null)
            {
                this.ResourcesLoadedSignal().Disconnect(_ResourcesLoadedCallback);
            }

            if (_offWindowEventCallback != null)
            {
                this.OffWindowSignal().Disconnect(_offWindowEventCallback);
            }

            if (_onWindowEventCallback != null)
            {
                this.OnWindowSignal().Disconnect(_onWindowEventCallback);
            }

            if (_wheelEventCallback != null)
            {
                this.WheelEventSignal().Disconnect(_wheelEventCallback);
            }

            if (_hoverEventCallback != null)
            {
                this.HoveredSignal().Disconnect(_hoverEventCallback);
            }

            if (_touchDataCallback != null)
            {
                this.TouchSignal().Disconnect(_touchDataCallback);
            }

            if (_onRelayoutEventCallback != null)
            {
                this.OnRelayoutSignal().Disconnect(_onRelayoutEventCallback);
            }

            if (_keyCallback != null)
            {
                this.KeyEventSignal().Disconnect(_keyCallback);
            }

            if (_keyInputFocusLostCallback != null)
            {
                this.KeyInputFocusLostSignal().Disconnect(_keyInputFocusLostCallback);
            }

            if (_keyInputFocusGainedCallback != null)
            {
                this.KeyInputFocusGainedSignal().Disconnect(_keyInputFocusGainedCallback);
            }

            if (_backgroundResourceLoadedCallback != null)
            {
                this.ResourcesLoadedSignal().Disconnect(_backgroundResourceLoadedCallback);
            }

            if (_onWindowSendEventCallback != null)
            {
                this.OnWindowSignal().Disconnect(_onWindowSendEventCallback);
            }

            // BaseHandle CPtr is used in Registry and there is danger of deletion if we keep using it here.
            // Restore current CPtr.
            swigCPtr = currentCPtr;
        }

        private void OnKeyInputFocusGained(IntPtr view)
        {
            if (_keyInputFocusGainedEventHandler != null)
            {
                _keyInputFocusGainedEventHandler(this, null);
            }
        }

        private void OnKeyInputFocusLost(IntPtr view)
        {
            if (_keyInputFocusLostEventHandler != null)
            {
                _keyInputFocusLostEventHandler(this, null);
            }
        }

        private bool OnKeyEvent(IntPtr view, IntPtr keyEvent)
        {
            if (keyEvent == global::System.IntPtr.Zero)
            {
                NUILog.Error("keyEvent should not be null!");
                return true;
            }

            KeyEventArgs e = new KeyEventArgs();

            bool result = false;

            e.Key = Tizen.NUI.Key.GetKeyFromPtr(keyEvent);

            if (_keyEventHandler != null)
            {
                Delegate[] delegateList = _keyEventHandler.GetInvocationList();

                // Oring the result of each callback.
                foreach (EventHandlerWithReturnType<object, KeyEventArgs, bool> del in delegateList)
                {
                    result |= del(this, e);
                }
            }

            return result;
        }

        // Callback for View OnRelayout signal
        private void OnRelayout(IntPtr data)
        {
            if (_onRelayoutEventHandler != null)
            {
                _onRelayoutEventHandler(this, null);
            }
        }

        // Callback for View TouchSignal
        private bool OnTouch(IntPtr view, IntPtr touchData)
        {
            if (touchData == global::System.IntPtr.Zero)
            {
                NUILog.Error("touchData should not be null!");
                return true;
            }

            TouchEventArgs e = new TouchEventArgs();

            e.Touch = Tizen.NUI.Touch.GetTouchFromPtr(touchData);

            if (_touchDataEventHandler != null)
            {
                return _touchDataEventHandler(this, e);
            }
            return false;
        }

        // Callback for View Hover signal
        private bool OnHoverEvent(IntPtr view, IntPtr hoverEvent)
        {
            if (hoverEvent == global::System.IntPtr.Zero)
            {
                NUILog.Error("hoverEvent should not be null!");
                return true;
            }

            HoverEventArgs e = new HoverEventArgs();

            e.Hover = Tizen.NUI.Hover.GetHoverFromPtr(hoverEvent);

            if (_hoverEventHandler != null)
            {
                return _hoverEventHandler(this, e);
            }
            return false;
        }

        // Callback for View Wheel signal
        private bool OnWheelEvent(IntPtr view, IntPtr wheelEvent)
        {
            if (wheelEvent == global::System.IntPtr.Zero)
            {
                NUILog.Error("wheelEvent should not be null!");
                return true;
            }

            WheelEventArgs e = new WheelEventArgs();

            e.Wheel = Tizen.NUI.Wheel.GetWheelFromPtr(wheelEvent);

            if (_wheelEventHandler != null)
            {
                return _wheelEventHandler(this, e);
            }
            return false;
        }

        // Callback for View OnWindow signal
        private void OnWindow(IntPtr data)
        {
            if (_onWindowEventHandler != null)
            {
                _onWindowEventHandler(this, null);
            }
        }

        // Callback for View OffWindow signal
        private void OffWindow(IntPtr data)
        {
            if (_offWindowEventHandler != null)
            {
                _offWindowEventHandler(this, null);
            }
        }

        // Callback for View visibility change signal
        private void OnVisibilityChanged(IntPtr data, bool visibility, VisibilityChangeType type)
        {
            VisibilityChangedEventArgs e = new VisibilityChangedEventArgs();
            if (data != null)
            {
                e.View = Registry.GetManagedBaseHandleFromNativePtr(data) as View;
            }
            e.Visibility = visibility;
            e.Type = type;

            if (_visibilityChangedEventHandler != null)
            {
                _visibilityChangedEventHandler(this, e);
            }
        }

        // Callback for View layout direction change signal
        private void OnLayoutDirectionChanged(IntPtr data, ViewLayoutDirectionType type)
        {
            LayoutDirectionChangedEventArgs e = new LayoutDirectionChangedEventArgs();
            if (data != null)
            {
                e.View = Registry.GetManagedBaseHandleFromNativePtr(data) as View;
            }
            e.Type = type;

            if (_layoutDirectionChangedEventHandler != null)
            {
                _layoutDirectionChangedEventHandler(this, e);
            }
        }

        private void OnResourcesLoaded(IntPtr view)
        {
            if (_resourcesLoadedEventHandler != null)
            {
                _resourcesLoadedEventHandler(this, null);
            }
        }

        private View ConvertIdToView(uint id)
        {
            View view = null;
            if (GetParent() is View)
            {
                View parentView = GetParent() as View;
                view = parentView.FindChildById(id);
            }

            if (!view)
            {
                view = Window.Instance.GetRootLayer().FindChildById(id);
            }

            return view;
        }

        private void OnBackgroundResourceLoaded(IntPtr view)
        {
            BackgroundResourceLoadedEventArgs e = new BackgroundResourceLoadedEventArgs();
            e.Status = (ResourceLoadingStatusType)Interop.View.View_GetVisualResourceStatus(this.swigCPtr, Property.BACKGROUND);

            if (_backgroundResourceLoadedEventHandler != null)
            {
                _backgroundResourceLoadedEventHandler(this, e);
            }
        }

        /// <summary>
        /// Event argument passed through the ChildAdded event.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public class ChildAddedEventArgs : EventArgs
        {
            /// <summary>
            /// Added child view at moment.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public View Added { get; set; }
        }

        /// <summary>
        /// Event argument passed through the ChildRemoved event.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public class ChildRemovedEventArgs : EventArgs
        {
            /// <summary>
            /// Removed child view at moment.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            public View Removed { get; set; }
        }

        /// <summary>
        /// Event arguments that passed via the KeyEvent signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class KeyEventArgs : EventArgs
        {
            private Key _key;

            /// <summary>
            /// Key - is the key sent to the view.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public Key Key
            {
                get
                {
                    return _key;
                }
                set
                {
                    _key = value;
                }
            }
        }

        /// <summary>
        /// Event arguments that passed via the touch signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class TouchEventArgs : EventArgs
        {
            private Touch _touch;

            /// <summary>
            /// Touch - contains the information of touch points.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public Touch Touch
            {
                get
                {
                    return _touch;
                }
                set
                {
                    _touch = value;
                }
            }
        }

        /// <summary>
        /// Event arguments that passed via the hover signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class HoverEventArgs : EventArgs
        {
            private Hover _hover;

            /// <summary>
            /// Hover - contains touch points that represent the points that are currently being hovered or the points where a hover has stopped.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public Hover Hover
            {
                get
                {
                    return _hover;
                }
                set
                {
                    _hover = value;
                }
            }
        }

        /// <summary>
        /// Event arguments that passed via the wheel signal.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class WheelEventArgs : EventArgs
        {
            private Wheel _wheel;

            /// <summary>
            /// WheelEvent - store a wheel rolling type: MOUSE_WHEEL or CUSTOM_WHEEL.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public Wheel Wheel
            {
                get
                {
                    return _wheel;
                }
                set
                {
                    _wheel = value;
                }
            }
        }

        /// <summary>
        /// Event arguments of visibility changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public class VisibilityChangedEventArgs : EventArgs
        {
            private View _view;
            private bool _visibility;
            private VisibilityChangeType _type;

            /// <summary>
            /// The view, or child of view, whose visibility has changed.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public View View
            {
                get
                {
                    return _view;
                }
                set
                {
                    _view = value;
                }
            }

            /// <summary>
            /// Whether the view is now visible or not.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public bool Visibility
            {
                get
                {
                    return _visibility;
                }
                set
                {
                    _visibility = value;
                }
            }

            /// <summary>
            /// Whether the view's visible property has changed or a parent's.
            /// </summary>
            /// <since_tizen> 3 </since_tizen>
            public VisibilityChangeType Type
            {
                get
                {
                    return _type;
                }
                set
                {
                    _type = value;
                }
            }
        }

        /// <summary>
        /// Event arguments of layout direction changed.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public class LayoutDirectionChangedEventArgs : EventArgs
        {
            private View _view;
            private ViewLayoutDirectionType _type;

            /// <summary>
            /// The view, or child of view, whose layout direction has changed.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public View View
            {
                get
                {
                    return _view;
                }
                set
                {
                    _view = value;
                }
            }

            /// <summary>
            /// Whether the view's layout direction property has changed or a parent's.
            /// </summary>
            /// <since_tizen> 4 </since_tizen>
            public ViewLayoutDirectionType Type
            {
                get
                {
                    return _type;
                }
                set
                {
                    _type = value;
                }
            }
        }

        internal class BackgroundResourceLoadedEventArgs : EventArgs
        {
            private ResourceLoadingStatusType status = ResourceLoadingStatusType.Invalid;
            public ResourceLoadingStatusType Status
            {
                get
                {
                    return status;
                }
                set
                {
                    status = value;
                }
            }
        }

        internal class Property
        {
            internal static readonly int TOOLTIP = Interop.ViewProperty.View_Property_TOOLTIP_get();
            internal static readonly int STATE = Interop.ViewProperty.View_Property_STATE_get();
            internal static readonly int SUB_STATE = Interop.ViewProperty.View_Property_SUB_STATE_get();
            internal static readonly int LEFT_FOCUSABLE_VIEW_ID = Interop.ViewProperty.View_Property_LEFT_FOCUSABLE_ACTOR_ID_get();
            internal static readonly int RIGHT_FOCUSABLE_VIEW_ID = Interop.ViewProperty.View_Property_RIGHT_FOCUSABLE_ACTOR_ID_get();
            internal static readonly int UP_FOCUSABLE_VIEW_ID = Interop.ViewProperty.View_Property_UP_FOCUSABLE_ACTOR_ID_get();
            internal static readonly int DOWN_FOCUSABLE_VIEW_ID = Interop.ViewProperty.View_Property_DOWN_FOCUSABLE_ACTOR_ID_get();
            internal static readonly int STYLE_NAME = Interop.ViewProperty.View_Property_STYLE_NAME_get();
            internal static readonly int BACKGROUND = Interop.ViewProperty.View_Property_BACKGROUND_get();
            internal static readonly int SIBLING_ORDER = Interop.ActorProperty.Actor_Property_SIBLING_ORDER_get();
            internal static readonly int OPACITY = Interop.ActorProperty.Actor_Property_OPACITY_get();
            internal static readonly int SCREEN_POSITION = Interop.ActorProperty.Actor_Property_SCREEN_POSITION_get();
            internal static readonly int POSITION_USES_ANCHOR_POINT = Interop.ActorProperty.Actor_Property_POSITION_USES_ANCHOR_POINT_get();
            internal static readonly int PARENT_ORIGIN = Interop.ActorProperty.Actor_Property_PARENT_ORIGIN_get();
            internal static readonly int PARENT_ORIGIN_X = Interop.ActorProperty.Actor_Property_PARENT_ORIGIN_X_get();
            internal static readonly int PARENT_ORIGIN_Y = Interop.ActorProperty.Actor_Property_PARENT_ORIGIN_Y_get();
            internal static readonly int PARENT_ORIGIN_Z = Interop.ActorProperty.Actor_Property_PARENT_ORIGIN_Z_get();
            internal static readonly int ANCHOR_POINT = Interop.ActorProperty.Actor_Property_ANCHOR_POINT_get();
            internal static readonly int ANCHOR_POINT_X = Interop.ActorProperty.Actor_Property_ANCHOR_POINT_X_get();
            internal static readonly int ANCHOR_POINT_Y = Interop.ActorProperty.Actor_Property_ANCHOR_POINT_Y_get();
            internal static readonly int ANCHOR_POINT_Z = Interop.ActorProperty.Actor_Property_ANCHOR_POINT_Z_get();
            internal static readonly int SIZE = Interop.ActorProperty.Actor_Property_SIZE_get();
            internal static readonly int SIZE_WIDTH = Interop.ActorProperty.Actor_Property_SIZE_WIDTH_get();
            internal static readonly int SIZE_HEIGHT = Interop.ActorProperty.Actor_Property_SIZE_HEIGHT_get();
            internal static readonly int SIZE_DEPTH = Interop.ActorProperty.Actor_Property_SIZE_DEPTH_get();
            internal static readonly int POSITION = Interop.ActorProperty.Actor_Property_POSITION_get();
            internal static readonly int POSITION_X = Interop.ActorProperty.Actor_Property_POSITION_X_get();
            internal static readonly int POSITION_Y = Interop.ActorProperty.Actor_Property_POSITION_Y_get();
            internal static readonly int POSITION_Z = Interop.ActorProperty.Actor_Property_POSITION_Z_get();
            internal static readonly int WORLD_POSITION = Interop.ActorProperty.Actor_Property_WORLD_POSITION_get();
            internal static readonly int WORLD_POSITION_X = Interop.ActorProperty.Actor_Property_WORLD_POSITION_X_get();
            internal static readonly int WORLD_POSITION_Y = Interop.ActorProperty.Actor_Property_WORLD_POSITION_Y_get();
            internal static readonly int WORLD_POSITION_Z = Interop.ActorProperty.Actor_Property_WORLD_POSITION_Z_get();
            internal static readonly int ORIENTATION = Interop.ActorProperty.Actor_Property_ORIENTATION_get();
            internal static readonly int WORLD_ORIENTATION = Interop.ActorProperty.Actor_Property_WORLD_ORIENTATION_get();
            internal static readonly int SCALE = Interop.ActorProperty.Actor_Property_SCALE_get();
            internal static readonly int SCALE_X = Interop.ActorProperty.Actor_Property_SCALE_X_get();
            internal static readonly int SCALE_Y = Interop.ActorProperty.Actor_Property_SCALE_Y_get();
            internal static readonly int SCALE_Z = Interop.ActorProperty.Actor_Property_SCALE_Z_get();
            internal static readonly int WORLD_SCALE = Interop.ActorProperty.Actor_Property_WORLD_SCALE_get();
            internal static readonly int VISIBLE = Interop.ActorProperty.Actor_Property_VISIBLE_get();
            internal static readonly int WORLD_COLOR = Interop.ActorProperty.Actor_Property_WORLD_COLOR_get();
            internal static readonly int WORLD_MATRIX = Interop.ActorProperty.Actor_Property_WORLD_MATRIX_get();
            internal static readonly int NAME = Interop.ActorProperty.Actor_Property_NAME_get();
            internal static readonly int SENSITIVE = Interop.ActorProperty.Actor_Property_SENSITIVE_get();
            internal static readonly int LEAVE_REQUIRED = Interop.ActorProperty.Actor_Property_LEAVE_REQUIRED_get();
            internal static readonly int INHERIT_ORIENTATION = Interop.ActorProperty.Actor_Property_INHERIT_ORIENTATION_get();
            internal static readonly int INHERIT_SCALE = Interop.ActorProperty.Actor_Property_INHERIT_SCALE_get();
            internal static readonly int DRAW_MODE = Interop.ActorProperty.Actor_Property_DRAW_MODE_get();
            internal static readonly int SIZE_MODE_FACTOR = Interop.ActorProperty.Actor_Property_SIZE_MODE_FACTOR_get();
            internal static readonly int WIDTH_RESIZE_POLICY = Interop.ActorProperty.Actor_Property_WIDTH_RESIZE_POLICY_get();
            internal static readonly int HEIGHT_RESIZE_POLICY = Interop.ActorProperty.Actor_Property_HEIGHT_RESIZE_POLICY_get();
            internal static readonly int SIZE_SCALE_POLICY = Interop.ActorProperty.Actor_Property_SIZE_SCALE_POLICY_get();
            internal static readonly int WIDTH_FOR_HEIGHT = Interop.ActorProperty.Actor_Property_WIDTH_FOR_HEIGHT_get();
            internal static readonly int HEIGHT_FOR_WIDTH = Interop.ActorProperty.Actor_Property_HEIGHT_FOR_WIDTH_get();
            internal static readonly int MINIMUM_SIZE = Interop.ActorProperty.Actor_Property_MINIMUM_SIZE_get();
            internal static readonly int MAXIMUM_SIZE = Interop.ActorProperty.Actor_Property_MAXIMUM_SIZE_get();
            internal static readonly int INHERIT_POSITION = Interop.ActorProperty.Actor_Property_INHERIT_POSITION_get();
            internal static readonly int CLIPPING_MODE = Interop.ActorProperty.Actor_Property_CLIPPING_MODE_get();
            internal static readonly int INHERIT_LAYOUT_DIRECTION = Interop.ActorProperty.Actor_Property_INHERIT_LAYOUT_DIRECTION_get();
            internal static readonly int LAYOUT_DIRECTION = Interop.ActorProperty.Actor_Property_LAYOUT_DIRECTION_get();
            internal static readonly int MARGIN = Interop.ViewProperty.View_Property_MARGIN_get();
            internal static readonly int PADDING = Interop.ViewProperty.View_Property_PADDING_get();
        }
    }
}
