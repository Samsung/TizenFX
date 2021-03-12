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

using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// View is the base class for all views.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class View
    {
        /// <summary>
        /// StyleNameProperty (DALi json)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StyleNameProperty = BindableProperty.Create(nameof(StyleName), typeof(string), typeof(View), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                string styleName = (string)newValue;
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.STYLE_NAME, new Tizen.NUI.PropertyValue(styleName));

                view.styleName = styleName;
                view.UpdateStyle();
                view.ThemeChangeSensitive = true;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;

            if (!string.IsNullOrEmpty(view.styleName)) return view.styleName;

            string temp;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.STYLE_NAME).Get(out temp);
            return temp;
        });

        /// <summary>
        /// KeyInputFocusProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty KeyInputFocusProperty = BindableProperty.Create(nameof(KeyInputFocus), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.KEY_INPUT_FOCUS, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.KEY_INPUT_FOCUS).Get(out temp);
            return temp;
        });

        /// <summary>
        /// BackgroundColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                if (view.backgroundExtraData == null)
                {
                    Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.BACKGROUND, new PropertyValue((Color)newValue));
                    return;
                }

                PropertyMap map = new PropertyMap();

                map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Color))
                   .Add(ColorVisualProperty.MixColor, new PropertyValue((Color)newValue))
                   .Add(Visual.Property.CornerRadius, new PropertyValue(view.backgroundExtraData.CornerRadius));

                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.BACKGROUND, new PropertyValue(map));
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

        /// <summary>
        /// ColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetColor((Color)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Color color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            view.GetProperty(Interop.ActorProperty.Actor_Property_COLOR_get()).Get(color);
            return color;
        });

        /// <summary> BackgroundImageProperty </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageProperty = BindableProperty.Create(nameof(BackgroundImage), typeof(string), typeof(View), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                string url = (string)newValue;

                if (string.IsNullOrEmpty(url))
                {
                    // Clear background
                    Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.BACKGROUND, new PropertyValue());
                    return;
                }

                if (view.backgroundExtraData == null)
                {
                    Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.BACKGROUND, new PropertyValue(url));
                    view.BackgroundImageSynchronosLoading = view._backgroundImageSynchronosLoading;

                    return;
                }

                PropertyMap map = new PropertyMap();

                map.Add(ImageVisualProperty.URL, new PropertyValue(url))
                   .Add(Visual.Property.CornerRadius, new PropertyValue(view.backgroundExtraData.CornerRadius))
                   .Add(ImageVisualProperty.SynchronousLoading, new PropertyValue(view._backgroundImageSynchronosLoading));

                if (view.backgroundExtraData.BackgroundImageBorder != null)
                {
                    map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.NPatch))
                       .Add(NpatchImageVisualProperty.Border, new PropertyValue(view.backgroundExtraData.BackgroundImageBorder));
                }
                else
                {
                    map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
                }

                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.BACKGROUND, new PropertyValue(map));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            string backgroundImage = "";

            Tizen.NUI.PropertyMap background = view.Background;
            background.Find(ImageVisualProperty.URL)?.Get(out backgroundImage);

            return backgroundImage;
        });
        /// <summary>BackgroundImageBorderProperty</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageBorderProperty = BindableProperty.Create(nameof(BackgroundImageBorder), typeof(Rectangle), typeof(View), default(Rectangle), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;

            bool isEmptyValue = Rectangle.IsNullOrZero((Rectangle)newValue);

            var backgroundImageBorder = isEmptyValue ? null : (Rectangle)newValue;

            (view.backgroundExtraData ?? (view.backgroundExtraData = new BackgroundExtraData())).BackgroundImageBorder = backgroundImageBorder;

            if (isEmptyValue)
            {
                return;
            }

            PropertyMap map = view.Background;

            if (map.Empty())
            {
                return;
            }

            map[NpatchImageVisualProperty.Border] = new PropertyValue(backgroundImageBorder);

            int visualType = 0;

            map.Find(Visual.Property.Type)?.Get(out visualType);

            if (visualType == (int)Visual.Type.Image)
            {
                map[Visual.Property.Type] = new PropertyValue((int)Visual.Type.NPatch);
            }

            Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.BACKGROUND, new PropertyValue(map));

        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;

            return view.backgroundExtraData?.BackgroundImageBorder;
        });
        /// <summary>
        /// BackgroundProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundProperty = BindableProperty.Create(nameof(Background), typeof(PropertyMap), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.BACKGROUND, new Tizen.NUI.PropertyValue((PropertyMap)newValue));

                view.backgroundExtraData = null;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.BACKGROUND).Get(temp);
            return temp;
        });

        /// <summary>
        /// StateProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StateProperty = BindableProperty.Create(nameof(State), typeof(States), typeof(View), States.Normal, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// SubStateProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SubStateProperty = BindableProperty.Create(nameof(SubState), typeof(States), typeof(View), States.Normal, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            string valueToString = "";
            if (newValue != null)
            {
                valueToString = ((States)newValue).GetDescription<States>();
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
            return temp.GetValueByDescription<States>();
        });

        /// <summary>
        /// TooltipProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TooltipProperty = BindableProperty.Create(nameof(Tooltip), typeof(PropertyMap), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// FlexProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FlexProperty = BindableProperty.Create(nameof(Flex), typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// AlignSelfProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AlignSelfProperty = BindableProperty.Create(nameof(AlignSelf), typeof(int), typeof(View), default(int), propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// FlexMarginProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FlexMarginProperty = BindableProperty.Create(nameof(FlexMargin), typeof(Vector4), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// CellIndexProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CellIndexProperty = BindableProperty.Create(nameof(CellIndex), typeof(Vector2), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// RowSpanProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RowSpanProperty = BindableProperty.Create(nameof(RowSpan), typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// ColumnSpanProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ColumnSpanProperty = BindableProperty.Create(nameof(ColumnSpan), typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// CellHorizontalAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CellHorizontalAlignmentProperty = BindableProperty.Create(nameof(CellHorizontalAlignment), typeof(HorizontalAlignmentType), typeof(View), HorizontalAlignmentType.Left, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            string valueToString = "";

            if (newValue != null)
            {
                valueToString = ((HorizontalAlignmentType)newValue).GetDescription<HorizontalAlignmentType>();
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

            return temp.GetValueByDescription<HorizontalAlignmentType>();
        });

        /// <summary>
        /// CellVerticalAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CellVerticalAlignmentProperty = BindableProperty.Create(nameof(CellVerticalAlignment), typeof(VerticalAlignmentType), typeof(View), VerticalAlignmentType.Top, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            string valueToString = "";

            if (newValue != null)
            {
                valueToString = ((VerticalAlignmentType)newValue).GetDescription<VerticalAlignmentType>();
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

            return temp.GetValueByDescription<VerticalAlignmentType>();
        });

        /// <summary>
        /// "Please DO NOT use! This will be deprecated! Please use 'View Weight' instead of BindableProperty"
        /// This needs to be hidden as inhouse API until all applications using it have been updated.  Do not make public.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WeightProperty = BindableProperty.Create(nameof(Weight), typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// LeftFocusableViewProperty
        /// </summary>
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

        /// <summary>
        /// RightFocusableViewProperty
        /// </summary>
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

        /// <summary>
        /// UpFocusableViewProperty
        /// </summary>
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

        /// <summary>
        /// DownFocusableViewProperty
        /// </summary>
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

        /// <summary>
        /// FocusableProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FocusableProperty = BindableProperty.Create(nameof(Focusable), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null) { view.SetKeyboardFocusable((bool)newValue); }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            return view.IsKeyboardFocusable();
        });

        /// <summary>
        /// FocusableChildrenProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FocusableChildrenProperty = BindableProperty.Create(nameof(FocusableChildren), typeof(bool), typeof(View), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null) { view.SetKeyboardFocusableChildren((bool)newValue); }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            return view.AreChildrenKeyBoardFocusable();
        });

        /// <summary>
        /// FocusableInTouchProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FocusableInTouchProperty = BindableProperty.Create(nameof(FocusableInTouch), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null) { view.SetFocusableInTouch((bool)newValue); }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            return view.IsFocusableInTouch();
        });

        /// <summary>
        /// Size2DProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty Size2DProperty = BindableProperty.Create(nameof(Size2D), typeof(Size2D), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// OpacityProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OpacityProperty = BindableProperty.Create(nameof(Opacity), typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// Position2DProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty Position2DProperty = BindableProperty.Create(nameof(Position2D), typeof(Position2D), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// PositionUsesPivotPointProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionUsesPivotPointProperty = BindableProperty.Create(nameof(PositionUsesPivotPoint), typeof(bool), typeof(View), true, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// SiblingOrderProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SiblingOrderProperty = BindableProperty.Create(nameof(SiblingOrder), typeof(int), typeof(View), default(int), propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// ParentOriginProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ParentOriginProperty = BindableProperty.Create(nameof(ParentOrigin), typeof(Position), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// PivotPointProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PivotPointProperty = BindableProperty.Create(nameof(PivotPoint), typeof(Position), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// SizeWidthProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeWidthProperty = BindableProperty.Create(nameof(SizeWidth), typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.SIZE_WIDTH, new Tizen.NUI.PropertyValue((float)newValue));
                view.WidthSpecification = (int)System.Math.Ceiling((float)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.SIZE_WIDTH).Get(out temp);
            return temp;
        });

        /// <summary>
        /// SizeHeightProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeHeightProperty = BindableProperty.Create(nameof(SizeHeight), typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.SIZE_HEIGHT, new Tizen.NUI.PropertyValue((float)newValue));
                view.HeightSpecification = (int)System.Math.Ceiling((float)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.SIZE_HEIGHT).Get(out temp);
            return temp;
        });

        /// <summary>
        /// PositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionProperty = BindableProperty.Create(nameof(Position), typeof(Position), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// PositionXProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionXProperty = BindableProperty.Create(nameof(PositionX), typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// PositionYProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionYProperty = BindableProperty.Create(nameof(PositionY), typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// PositionZProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionZProperty = BindableProperty.Create(nameof(PositionZ), typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// OrientationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OrientationProperty = BindableProperty.Create(nameof(Orientation), typeof(Rotation), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// ScaleProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleProperty = BindableProperty.Create(nameof(Scale), typeof(Vector3), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// ScaleXProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleXProperty = BindableProperty.Create(nameof(ScaleX), typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// ScaleYProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleYProperty = BindableProperty.Create(nameof(ScaleY), typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// ScaleZProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleZProperty = BindableProperty.Create(nameof(ScaleZ), typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// NameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(View), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// SensitiveProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SensitiveProperty = BindableProperty.Create(nameof(Sensitive), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// LeaveRequiredProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LeaveRequiredProperty = BindableProperty.Create(nameof(LeaveRequired), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// InheritOrientationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InheritOrientationProperty = BindableProperty.Create(nameof(InheritOrientation), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// InheritScaleProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InheritScaleProperty = BindableProperty.Create(nameof(InheritScale), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// DrawModeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DrawModeProperty = BindableProperty.Create(nameof(DrawMode), typeof(DrawModeType), typeof(View), DrawModeType.Normal, propertyChanged: (bindable, oldValue, newValue) =>
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
            int temp;
            if (Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.DRAW_MODE).Get(out temp) == false)
            {
                NUILog.Error("DrawMode get error!");
            }
            return (DrawModeType)temp;
        });

        /// <summary>
        /// SizeModeFactorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeModeFactorProperty = BindableProperty.Create(nameof(SizeModeFactor), typeof(Vector3), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// WidthResizePolicyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WidthResizePolicyProperty = BindableProperty.Create(nameof(WidthResizePolicy), typeof(ResizePolicyType), typeof(View), ResizePolicyType.Fixed, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.WIDTH_RESIZE_POLICY, new Tizen.NUI.PropertyValue((int)newValue));
                // Match ResizePolicy to new Layouting.
                // Parent relative policies can not be mapped at this point as parent size unknown.
                switch ((ResizePolicyType)newValue)
                {
                    case ResizePolicyType.UseNaturalSize:
                        {
                            view.WidthSpecification = LayoutParamPolicies.WrapContent;
                            break;
                        }
                    case ResizePolicyType.FillToParent:
                        {
                            view.WidthSpecification = LayoutParamPolicies.MatchParent;
                            break;
                        }
                    case ResizePolicyType.FitToChildren:
                        {
                            view.WidthSpecification = LayoutParamPolicies.WrapContent;
                            break;
                        }
                    default:
                        break;
                }
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
            return temp.GetValueByDescription<ResizePolicyType>();
        });

        /// <summary>
        /// HeightResizePolicyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HeightResizePolicyProperty = BindableProperty.Create(nameof(HeightResizePolicy), typeof(ResizePolicyType), typeof(View), ResizePolicyType.Fixed, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.HEIGHT_RESIZE_POLICY, new Tizen.NUI.PropertyValue((int)newValue));
                // Match ResizePolicy to new Layouting.
                // Parent relative policies can not be mapped at this point as parent size unknown.
                switch ((ResizePolicyType)newValue)
                {
                    case ResizePolicyType.UseNaturalSize:
                        {
                            view.HeightSpecification = LayoutParamPolicies.WrapContent;
                            break;
                        }
                    case ResizePolicyType.FillToParent:
                        {
                            view.HeightSpecification = LayoutParamPolicies.MatchParent;
                            break;
                        }
                    case ResizePolicyType.FitToChildren:
                        {
                            view.HeightSpecification = LayoutParamPolicies.WrapContent;
                            break;
                        }
                    default:
                        break;
                }
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
            return temp.GetValueByDescription<ResizePolicyType>();
        });

        /// <summary>
        /// SizeScalePolicyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeScalePolicyProperty = BindableProperty.Create(nameof(SizeScalePolicy), typeof(SizeScalePolicyType), typeof(View), SizeScalePolicyType.UseSizeSet, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            string valueToString = "";
            if (newValue != null)
            {
                valueToString = ((SizeScalePolicyType)newValue).GetDescription<SizeScalePolicyType>();
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.SIZE_SCALE_POLICY, new Tizen.NUI.PropertyValue(valueToString));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            int temp;
            if (Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.SIZE_SCALE_POLICY).Get(out temp) == false)
            {
                NUILog.Error("SizeScalePolicy get error!");
            }
            return (SizeScalePolicyType)temp;
        });

        /// <summary>
        /// WidthForHeightProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WidthForHeightProperty = BindableProperty.Create(nameof(WidthForHeight), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// HeightForWidthProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HeightForWidthProperty = BindableProperty.Create(nameof(HeightForWidth), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// PaddingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PaddingProperty = BindableProperty.Create(nameof(Padding), typeof(Extents), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// SizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size), typeof(Size), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Size size = (Size)newValue;
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.SIZE, new Tizen.NUI.PropertyValue(size));
                // Set Specification so when layouts measure this View it matches the value set here.
                // All Views are currently Layouts.
                view.WidthSpecification = (int)System.Math.Ceiling(size.Width);
                view.HeightSpecification = (int)System.Math.Ceiling(size.Height);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Size temp = new Size(0, 0, 0);
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.SIZE).Get(temp);
            return temp;
        });

        /// <summary>
        /// MinimumSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinimumSizeProperty = BindableProperty.Create(nameof(MinimumSize), typeof(Size2D), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            Size2D temp = newValue as Size2D;
            if (temp != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.MINIMUM_SIZE, new Tizen.NUI.PropertyValue(temp));
            }
            else
            {
                Tizen.Log.Fatal("NUI", $"[ERROR] can't set MinimumSizeProperty!");
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Size2D temp = new Size2D(0, 0);
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.MINIMUM_SIZE).Get(temp);
            return temp;
        });

        /// <summary>
        /// MaximumSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaximumSizeProperty = BindableProperty.Create(nameof(MaximumSize), typeof(Size2D), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            Size2D temp = newValue as Size2D;
            if (temp != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.MAXIMUM_SIZE, new Tizen.NUI.PropertyValue(temp));
            }
            else
            {
                Tizen.Log.Fatal("NUI", $"[ERROR] can't set MaximumSizeProperty!");
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            Size2D temp = new Size2D(0, 0);
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.MAXIMUM_SIZE).Get(temp);
            return temp;
        });

        /// <summary>
        /// InheritPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InheritPositionProperty = BindableProperty.Create(nameof(InheritPosition), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// ClippingModeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ClippingModeProperty = BindableProperty.Create(nameof(ClippingMode), typeof(ClippingModeType), typeof(View), ClippingModeType.Disabled, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// InheritLayoutDirectionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InheritLayoutDirectionProperty = BindableProperty.Create(nameof(InheritLayoutDirection), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// LayoutDirectionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LayoutDirectionProperty = BindableProperty.Create(nameof(LayoutDirection), typeof(ViewLayoutDirectionType), typeof(View), ViewLayoutDirectionType.LTR, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// MarginProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MarginProperty = BindableProperty.Create(nameof(Margin), typeof(Extents), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
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

        /// <summary>
        /// UpdateSizeHintProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UpdateSizeHintProperty = BindableProperty.Create(nameof(UpdateSizeHint), typeof(Vector2), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(view.swigCPtr, Interop.ViewProperty.View_Property_UPDATE_SIZE_HINT_get(), new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;

            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(view.swigCPtr, Interop.ViewProperty.View_Property_UPDATE_SIZE_HINT_get()).Get(temp);
            return temp;
        });

        /// <summary>
        /// ImageShadow Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageShadowProperty = BindableProperty.Create(nameof(ImageShadow), typeof(ImageShadow), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var shadow = (ImageShadow)newValue;
            var view = (View)bindable;
            Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.SHADOW, shadow == null ? new PropertyValue() : shadow.ToPropertyValue(view));
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;

            PropertyMap map = new PropertyMap();
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.SHADOW).Get(map);

            var shadow = new ImageShadow(map);
            return shadow.IsEmpty() ? null : shadow;
        });

        /// <summary>
        /// Shadow Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BoxShadowProperty = BindableProperty.Create(nameof(BoxShadow), typeof(Shadow), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var shadow = (Shadow)newValue;
            var view = (View)bindable;
            Tizen.NUI.Object.SetProperty(view.swigCPtr, View.Property.SHADOW, shadow == null ? new PropertyValue() : shadow.ToPropertyValue(view));
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;

            PropertyMap map = new PropertyMap();
            Tizen.NUI.Object.GetProperty(view.swigCPtr, View.Property.SHADOW).Get(map);

            var shadow = new Shadow(map);
            return shadow.IsEmpty() ? null : shadow;
        });

        /// <summary>
        /// CornerRadius Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            view.UpdateCornerRadius((float)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            return view.backgroundExtraData == null ? 0 : view.backgroundExtraData.CornerRadius;
        });

        /// <summary>
        /// XamlStyleProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty XamlStyleProperty = BindableProperty.Create(nameof(XamlStyle), typeof(Style), typeof(View), default(Style), propertyChanged: (bindable, oldvalue, newvalue) => ((View)bindable)._mergedStyle.Style = (Style)newvalue);

        /// <summary>
        /// EnableControlState property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableControlStateProperty = BindableProperty.Create(nameof(EnableControlState), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            bool prev = view.enableControlState;
            view.enableControlState = (bool)newValue;

            if (prev != view.enableControlState)
            {
                if (prev)
                {
                    view.TouchEvent -= view.EmptyOnTouch;
                }
                else
                {
                    view.TouchEvent += view.EmptyOnTouch;
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            return ((View)bindable).enableControlState;
        });

        /// <summary>
        /// ThemeChangeSensitive property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ThemeChangeSensitiveProperty = BindableProperty.Create(nameof(ThemeChangeSensitive), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;

            if (view.themeChangeSensitive == (bool)newValue) return;

            view.themeChangeSensitive = (bool)newValue;

            if (view.themeChangeSensitive)
            {
                ThemeManager.ThemeChangedInternal += view.OnThemeChanged;
            }
            else
            {
                ThemeManager.ThemeChangedInternal -= view.OnThemeChanged;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            return ((View)bindable).themeChangeSensitive;
        });

        #region Selectors
        internal static readonly BindableProperty BackgroundImageSelectorProperty = BindableProperty.Create("BackgroundImageSelector", typeof(Selector<string>), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            view.SelectorData.BackgroundImage.Update(view, (Selector<string>)newValue, true);
            if (newValue != null) view.SelectorData.BackgroundColor.Reset(view);
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            return view.SelectorData.BackgroundImage.Get(view);
        });

        internal static readonly BindableProperty BackgroundColorSelectorProperty = BindableProperty.Create("BackgroundColorSelector", typeof(Selector<Color>), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            view.SelectorData.BackgroundColor.Update(view, (Selector<Color>)newValue, true);
            if (newValue != null) view.SelectorData.BackgroundImage.Reset(view);
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            return view.SelectorData.BackgroundColor.Get(view);
        });

        internal static readonly BindableProperty BackgroundImageBorderSelectorProperty = BindableProperty.Create("BackgroundImageBorderSelector", typeof(Selector<Rectangle>), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            view.SelectorData.BackgroundImageBorder.Update(view, (Selector<Rectangle>)newValue, true);
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            return view.SelectorData.BackgroundImageBorder.Get(view);
        });

        internal static readonly BindableProperty ColorSelectorProperty = BindableProperty.Create("ColorSelector", typeof(Selector<Color>), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            view.SelectorData.Color.Update(view, (Selector<Color>)newValue, true);
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            return view.SelectorData.Color.Get(view);
        });

        internal static readonly BindableProperty OpacitySelectorProperty = BindableProperty.Create("OpacitySelector", typeof(Selector<float?>), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            view.SelectorData.Opacity.Update(view, (Selector<float?>)newValue, true);
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            return view.SelectorData.Opacity.Get(view);
        });

        /// <summary>
        /// ImageShadow Selector Property for binding to ViewStyle
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageShadowSelectorProperty = BindableProperty.Create("ImageShadowSelector", typeof(Selector<ImageShadow>), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            view.SelectorData.ImageShadow.Update(view, (Selector<ImageShadow>)newValue, true);
            if (newValue != null) view.SelectorData.BoxShadow.Reset(view);
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            return view.SelectorData.ImageShadow.Get(view);
        });

        /// <summary>
        /// BoxShadow Selector Property for binding to ViewStyle
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BoxShadowSelectorProperty = BindableProperty.Create("BoxShadowSelector", typeof(Selector<Shadow>), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            view.SelectorData.BoxShadow.Update(view, (Selector<Shadow>)newValue, true);
            if (newValue != null) view.SelectorData.ImageShadow.Reset(view);
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            return view.SelectorData.BoxShadow.Get(view);
        });

        /// <summary>
        /// CornerRadius Selector Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CornerRadiusSelectorProperty = BindableProperty.Create("CornerRadiusSelector", typeof(Selector<float?>), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            view.SelectorData.CornerRadius.Update(view, (Selector<float?>)newValue, true);
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            return view.SelectorData.CornerRadius.Get(view);
        });
        #endregion
    }
}
