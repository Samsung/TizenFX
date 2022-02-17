/*
 * Copyright(c) 2019-2021 Samsung Electronics Co., Ltd.
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

using global::System;
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
        public static readonly BindableProperty StyleNameProperty = BindableProperty.Create(nameof(StyleName), typeof(string), typeof(View), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                string styleName = (string)newValue;
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.StyleName, new Tizen.NUI.PropertyValue(styleName));

                view.styleName = styleName;

                if (string.IsNullOrEmpty(styleName)) return;

                var style = ThemeManager.GetUpdateStyleWithoutClone(styleName);

                if (style == null) return;

                view.ApplyStyle(style);
                view.SetThemeApplied();
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;

            if (!string.IsNullOrEmpty(view.styleName)) return view.styleName;

            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.StyleName).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// KeyInputFocusProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty KeyInputFocusProperty = BindableProperty.Create(nameof(KeyInputFocus), typeof(bool), typeof(View), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.KeyInputFocus, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.KeyInputFocus).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// BackgroundColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(View), null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = (View)bindable;

                view.themeData?.selectorData?.ClearBackground(view);

                if (newValue is Selector<Color> selector)
                {
                    if (selector.HasAll()) view.SetBackgroundColor(selector.All);
                    else view.EnsureSelectorData().BackgroundColor = new TriggerableSelector<Color>(view, selector, view.SetBackgroundColor, true);
                }
                else
                {
                    view.SetBackgroundColor((Color)newValue);
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var view = (View)bindable;

                if (view.internalBackgroundColor == null)
                {
                    view.internalBackgroundColor = new Color(view.OnBackgroundColorChanged, 0, 0, 0, 0);
                }

                PropertyMap background = view.Background;
                int visualType = 0;
                background.Find(Visual.Property.Type)?.Get(out visualType);
                if (visualType == (int)Visual.Type.Color)
                {
                    background.Find(ColorVisualProperty.MixColor)?.Get(view.internalBackgroundColor);
                }

                background?.Dispose();
                background = null;

                return view.internalBackgroundColor;
            }
        );

        /// <summary>
        /// ColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(View), null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = (View)bindable;

                view.themeData?.selectorData?.Color?.Reset(view);

                if (newValue is Selector<Color> selector)
                {
                    if (selector.HasAll()) view.SetColor(selector.All);
                    else view.EnsureSelectorData().Color = new TriggerableSelector<Color>(view, selector, view.SetColor, true);
                }
                else
                {
                    view.SetColor((Color)newValue);
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var view = (View)bindable;
                var tmpProperty = view.GetProperty(Interop.ActorProperty.ColorGet());

                if (view.internalColor == null)
                {
                    view.internalColor = new Color(view.OnColorChanged, 0, 0, 0, 0);
                }

                tmpProperty?.Get(view.internalColor);
                tmpProperty?.Dispose();

                return view.internalColor;
            }
        );

        /// <summary> BackgroundImageProperty </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageProperty = BindableProperty.Create(nameof(BackgroundImage), typeof(string), typeof(View), default(string),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = (View)bindable;

                if (view.themeData?.selectorData != null)
                {
                    view.themeData.selectorData.BackgroundColor?.Reset(view);
                    view.themeData.selectorData.BackgroundImage?.Reset(view);
                }

                if (newValue is Selector<string> selector)
                {
                    if (selector.HasAll()) view.SetBackgroundImage(selector.All);
                    else view.EnsureSelectorData().BackgroundImage = new TriggerableSelector<string>(view, selector, view.SetBackgroundImage, true);
                }
                else
                {
                    view.SetBackgroundImage((string)newValue);
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var view = (View)bindable;
                string backgroundImage = "";

                PropertyMap background = view.Background;
                background.Find(ImageVisualProperty.URL)?.Get(out backgroundImage);

                background.Dispose();
                background = null;

                return backgroundImage;
            }
        );


        /// <summary>BackgroundImageBorderProperty</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageBorderProperty = BindableProperty.Create(nameof(BackgroundImageBorder), typeof(Rectangle), typeof(View), default(Rectangle), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;

            view.themeData?.selectorData?.BackgroundImageBorder?.Reset(view);

            if (newValue is Selector<Rectangle> selector)
            {
                if (selector.HasAll()) view.SetBackgroundImageBorder(selector.All);
                else view.EnsureSelectorData().BackgroundImageBorder = new TriggerableSelector<Rectangle>(view, selector, view.SetBackgroundImageBorder, true);
            }
            else
            {
                view.SetBackgroundImageBorder((Rectangle)newValue);
            }
        }),
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;

            return view.backgroundExtraData?.BackgroundImageBorder;
        });

        /// <summary>
        /// BackgroundProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundProperty = BindableProperty.Create(nameof(Background), typeof(PropertyMap), typeof(View), null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = (View)bindable;
                if (newValue != null)
                {
                    var propertyValue = new PropertyValue((PropertyMap)newValue);
                    Object.SetProperty(view.SwigCPtr, Property.BACKGROUND, propertyValue);

                    view.backgroundExtraData = null;

                    propertyValue.Dispose();
                    propertyValue = null;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var view = (View)bindable;
                PropertyMap tmp = new PropertyMap();
                var propertyValue = Object.GetProperty(view.SwigCPtr, Property.BACKGROUND);
                propertyValue.Get(tmp);
                propertyValue.Dispose();
                propertyValue = null;
                return tmp;
            }
        );

        /// <summary>
        /// StateProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty StateProperty = BindableProperty.Create(nameof(State), typeof(States), typeof(View), States.Normal, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.STATE, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            int temp = 0;
            if (Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.STATE).Get(out temp) == false)
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
        }));

        /// <summary>
        /// SubStateProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SubStateProperty = BindableProperty.Create(nameof(SubState), typeof(States), typeof(View), States.Normal, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            string valueToString = "";
            if (newValue != null)
            {
                valueToString = ((States)newValue).GetDescription();
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SubState, new Tizen.NUI.PropertyValue(valueToString));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SubState).Get(out temp) == false)
            {
                NUILog.Error("subState get error!");
            }
            return temp.GetValueByDescription<States>();
        }));

        /// <summary>
        /// TooltipProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TooltipProperty = BindableProperty.Create(nameof(Tooltip), typeof(PropertyMap), typeof(View), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.TOOLTIP, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.TOOLTIP).Get(temp);
            return temp;
        }));

        /// <summary>
        /// FlexProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FlexProperty = BindableProperty.Create(nameof(Flex), typeof(float), typeof(View), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, FlexContainer.ChildProperty.FLEX, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, FlexContainer.ChildProperty.FLEX).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// AlignSelfProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AlignSelfProperty = BindableProperty.Create(nameof(AlignSelf), typeof(int), typeof(View), default(int), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, FlexContainer.ChildProperty.AlignSelf, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, FlexContainer.ChildProperty.AlignSelf).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// FlexMarginProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FlexMarginProperty = BindableProperty.Create(nameof(FlexMargin), typeof(Vector4), typeof(View), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, FlexContainer.ChildProperty.FlexMargin, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, FlexContainer.ChildProperty.FlexMargin).Get(temp);
            return temp;
        }));

        /// <summary>
        /// CellIndexProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CellIndexProperty = BindableProperty.Create(nameof(CellIndex), typeof(Vector2), typeof(View), null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = (View)bindable;
                if (newValue != null)
                {
                    var tmp = new PropertyValue((Vector2)newValue);
                    Object.SetProperty(view.SwigCPtr, TableView.ChildProperty.CellIndex, tmp);
                    tmp.Dispose();
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var view = (View)bindable;
                if (view.internalCellIndex == null)
                {
                    view.internalCellIndex = new Vector2(view.OnCellIndexChanged, 0, 0);
                }

                var tmp = Object.GetProperty(view.SwigCPtr, TableView.ChildProperty.CellIndex);
                tmp?.Get(view.internalCellIndex);
                tmp?.Dispose();

                return view.internalCellIndex;
            }
        );

        /// <summary>
        /// RowSpanProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RowSpanProperty = BindableProperty.Create(nameof(RowSpan), typeof(float), typeof(View), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, TableView.ChildProperty.RowSpan, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, TableView.ChildProperty.RowSpan).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// ColumnSpanProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ColumnSpanProperty = BindableProperty.Create(nameof(ColumnSpan), typeof(float), typeof(View), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, TableView.ChildProperty.ColumnSpan, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, TableView.ChildProperty.ColumnSpan).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// CellHorizontalAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CellHorizontalAlignmentProperty = BindableProperty.Create(nameof(CellHorizontalAlignment), typeof(HorizontalAlignmentType), typeof(View), HorizontalAlignmentType.Left, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            string valueToString = "";

            if (newValue != null)
            {
                valueToString = ((HorizontalAlignmentType)newValue).GetDescription();
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, TableView.ChildProperty.CellHorizontalAlignment, new Tizen.NUI.PropertyValue(valueToString));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, TableView.ChildProperty.CellHorizontalAlignment).Get(out temp) == false)
            {
                NUILog.Error("CellHorizontalAlignment get error!");
            }

            return temp.GetValueByDescription<HorizontalAlignmentType>();
        }));

        /// <summary>
        /// CellVerticalAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CellVerticalAlignmentProperty = BindableProperty.Create(nameof(CellVerticalAlignment), typeof(VerticalAlignmentType), typeof(View), VerticalAlignmentType.Top, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            string valueToString = "";

            if (newValue != null)
            {
                valueToString = ((VerticalAlignmentType)newValue).GetDescription();
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, TableView.ChildProperty.CellVerticalAlignment, new Tizen.NUI.PropertyValue(valueToString));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, TableView.ChildProperty.CellVerticalAlignment).Get(out temp);
            {
                NUILog.Error("CellVerticalAlignment get error!");
            }

            return temp.GetValueByDescription<VerticalAlignmentType>();
        }));

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
        public static readonly BindableProperty Size2DProperty = BindableProperty.Create(nameof(Size2D), typeof(Size2D), typeof(View), null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = (View)bindable;
                if (newValue != null)
                {
                    view.SetSize(((Size2D)newValue).Width, ((Size2D)newValue).Height, 0);

                    view.widthPolicy = ((Size2D)newValue).Width;
                    view.heightPolicy = ((Size2D)newValue).Height;

                    view.layout?.RequestLayout();
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var view = (View)bindable;
                var tmp = new Size(0, 0, 0);
                var tmpProperty = Object.GetProperty(view.SwigCPtr, Property.SIZE);
                tmpProperty?.Get(tmp);

                if (view.internalSize2D == null)
                {
                    view.internalSize2D = new Size2D(view.OnSize2DChanged, (int)tmp?.Width, (int)tmp?.Height);
                }
                else
                {
                    if (view.internalSize2D.SwigCPtr.Handle != global::System.IntPtr.Zero)
                    {
                        Interop.Vector2.WidthSet(view.internalSize2D.SwigCPtr, (float)tmp?.Width);
                        Interop.Vector2.HeightSet(view.internalSize2D.SwigCPtr, (float)tmp?.Height);
                    }
                }

                tmpProperty?.Dispose();
                tmp?.Dispose();

                return view.internalSize2D;
            }
        );

        /// <summary>
        /// OpacityProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OpacityProperty = BindableProperty.Create(nameof(Opacity), typeof(float), typeof(View), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;

            view.themeData?.selectorData?.Opacity?.Reset(view);

            if (newValue is Selector<float?> selector)
            {
                if (selector.HasAll()) view.SetOpacity(selector.All);
                else view.EnsureSelectorData().Opacity = new TriggerableSelector<float?>(view, selector, view.SetOpacity, true);
            }
            else
            {
                view.SetOpacity((float?)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.OPACITY).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// Position2DProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty Position2DProperty = BindableProperty.Create(nameof(Position2D), typeof(Position2D), typeof(View), null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = (View)bindable;
                if (newValue != null)
                {
                    view.SetPosition(((Position2D)newValue).X, ((Position2D)newValue).Y, 0);
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var view = (View)bindable;
                var tmp = new Position(0, 0, 0);
                var tmpProperty = Object.GetProperty(view.SwigCPtr, Property.POSITION);
                tmpProperty?.Get(tmp);

                if (view.internalPosition2D == null)
                {
                    view.internalPosition2D = new Position2D(view.OnPosition2DChanged, (int)tmp?.X, (int)tmp?.Y);
                }
                else
                {
                    if (view.internalPosition2D.SwigCPtr.Handle != IntPtr.Zero)
                    {
                        Interop.Vector2.XSet(view.internalPosition2D.SwigCPtr, (float)tmp?.X);
                        Interop.Vector2.YSet(view.internalPosition2D.SwigCPtr, (float)tmp?.Y);
                    }
                }

                tmpProperty?.Dispose();
                tmp?.Dispose();

                return view.internalPosition2D;
            }
        );

        /// <summary>
        /// PositionUsesPivotPointProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionUsesPivotPointProperty = BindableProperty.Create(nameof(PositionUsesPivotPoint), typeof(bool), typeof(View), true, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.PositionUsesAnchorPoint, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.PositionUsesAnchorPoint).Get(out temp);
            return temp;
        }));

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
        public static readonly BindableProperty ParentOriginProperty = BindableProperty.Create(nameof(ParentOrigin), typeof(Position), typeof(View), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.ParentOrigin, new Tizen.NUI.PropertyValue((Position)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            Position temp = new Position(0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.ParentOrigin).Get(temp);
            return temp;
        })
        );

        /// <summary>
        /// PivotPointProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PivotPointProperty = BindableProperty.Create(nameof(PivotPoint), typeof(Position), typeof(View), null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = (View)bindable;
                if (newValue != null)
                {
                    view.SetAnchorPoint((Position)newValue);
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var view = (View)bindable;
                if (view.internalPivotPoint == null)
                {
                    view.internalPivotPoint = new Position(view.OnPivotPointChanged, 0, 0, 0);
                }
                var tmp = Object.GetProperty(view.SwigCPtr, Property.AnchorPoint);
                tmp?.Get(view.internalPivotPoint);
                tmp?.Dispose();

                return view.internalPivotPoint;
            }
        );

        /// <summary>
        /// SizeWidthProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeWidthProperty = BindableProperty.Create(nameof(SizeWidth), typeof(float), typeof(View), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SizeWidth, new Tizen.NUI.PropertyValue((float)newValue));
                view.WidthSpecification = (int)System.Math.Ceiling((float)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SizeWidth).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// SizeHeightProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeHeightProperty = BindableProperty.Create(nameof(SizeHeight), typeof(float), typeof(View), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SizeHeight, new Tizen.NUI.PropertyValue((float)newValue));
                view.HeightSpecification = (int)System.Math.Ceiling((float)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SizeHeight).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// PositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionProperty = BindableProperty.Create(nameof(Position), typeof(Position), typeof(View), null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = (View)bindable;
                if (newValue != null)
                {
                    view.SetPosition(((Position)newValue).X, ((Position)newValue).Y, ((Position)newValue).Z);
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var view = (View)bindable;
                var tmpProperty = Object.GetProperty(view.SwigCPtr, Property.POSITION);

                if (view.internalPosition == null)
                {
                    view.internalPosition = new Position(view.OnPositionChanged, 0, 0, 0);
                }
                tmpProperty?.Get(view.internalPosition);
                tmpProperty?.Dispose();

                return view.internalPosition;
            }
        );

        /// <summary>
        /// PositionXProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionXProperty = BindableProperty.Create(nameof(PositionX), typeof(float), typeof(View), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.PositionX, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.PositionX).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// PositionYProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionYProperty = BindableProperty.Create(nameof(PositionY), typeof(float), typeof(View), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.PositionY, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.PositionY).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// PositionZProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionZProperty = BindableProperty.Create(nameof(PositionZ), typeof(float), typeof(View), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.PositionZ, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.PositionZ).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// OrientationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OrientationProperty = BindableProperty.Create(nameof(Orientation), typeof(Rotation), typeof(View), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.ORIENTATION, new Tizen.NUI.PropertyValue((Rotation)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            Rotation temp = new Rotation();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.ORIENTATION).Get(temp);
            return temp;
        }));

        /// <summary>
        /// ScaleProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleProperty = BindableProperty.Create(nameof(Scale), typeof(Vector3), typeof(View), null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = (View)bindable;
                if (newValue != null)
                {
                    view.SetScale((Vector3)newValue);
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var view = (View)bindable;
                if (view.internalScale == null)
                {
                    view.internalScale = new Vector3(view.OnScaleChanged, 0, 0, 0);
                }

                var tmpPropery = Object.GetProperty(view.SwigCPtr, Property.SCALE);
                tmpPropery?.Get(view.internalScale);
                tmpPropery?.Dispose();

                return view.internalScale;
            }
        );

        /// <summary>
        /// ScaleXProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleXProperty = BindableProperty.Create(nameof(ScaleX), typeof(float), typeof(View), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.ScaleX, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.ScaleX).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// ScaleYProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleYProperty = BindableProperty.Create(nameof(ScaleY), typeof(float), typeof(View), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.ScaleY, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.ScaleY).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// ScaleZProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScaleZProperty = BindableProperty.Create(nameof(ScaleZ), typeof(float), typeof(View), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.ScaleZ, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.ScaleZ).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// NameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(View), string.Empty,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = (View)bindable;
                if (newValue != null)
                {
                    view.SetName((string)newValue);
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var view = (View)bindable;
                string temp;
                temp = view.GetName();
                return temp;
            }
        );

        /// <summary>
        /// SensitiveProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SensitiveProperty = BindableProperty.Create(nameof(Sensitive), typeof(bool), typeof(View), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SENSITIVE, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SENSITIVE).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// DispatchKeyEventsProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DispatchKeyEventsProperty = BindableProperty.Create(nameof(DispatchKeyEvents), typeof(bool), typeof(View), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.DispatchKeyEvents, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.DispatchKeyEvents).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// LeaveRequiredProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LeaveRequiredProperty = BindableProperty.Create(nameof(LeaveRequired), typeof(bool), typeof(View), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.LeaveRequired, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.LeaveRequired).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// InheritOrientationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InheritOrientationProperty = BindableProperty.Create(nameof(InheritOrientation), typeof(bool), typeof(View), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.InheritOrientation, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.InheritOrientation).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// InheritScaleProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InheritScaleProperty = BindableProperty.Create(nameof(InheritScale), typeof(bool), typeof(View), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.InheritScale, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.InheritScale).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// DrawModeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DrawModeProperty = BindableProperty.Create(nameof(DrawMode), typeof(DrawModeType), typeof(View), DrawModeType.Normal, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.DrawMode, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            int temp;
            if (Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.DrawMode).Get(out temp) == false)
            {
                NUILog.Error("DrawMode get error!");
            }
            return (DrawModeType)temp;
        }));

        /// <summary>
        /// SizeModeFactorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeModeFactorProperty = BindableProperty.Create(nameof(SizeModeFactor), typeof(Vector3), typeof(View), null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = (View)bindable;
                if (newValue != null)
                {
                    var tmp = new PropertyValue((Vector3)newValue);
                    Object.SetProperty(view.SwigCPtr, Property.SizeModeFactor, tmp);
                    tmp?.Dispose();
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var view = (View)bindable;
                if (view.internalSizeModeFactor == null)
                {
                    view.internalSizeModeFactor = new Vector3(view.OnSizeModeFactorChanged, 0, 0, 0);
                }
                var tmp = Object.GetProperty(view.SwigCPtr, Property.SizeModeFactor);
                tmp?.Get(view.internalSizeModeFactor);
                tmp?.Dispose();

                return view.internalSizeModeFactor;
            }
        );

        /// <summary>
        /// WidthResizePolicyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WidthResizePolicyProperty = BindableProperty.Create(nameof(WidthResizePolicy), typeof(ResizePolicyType), typeof(View), ResizePolicyType.Fixed, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                if ((ResizePolicyType)newValue == ResizePolicyType.KeepSizeFollowingParent)
                {
                    if (view.widthConstraint == null)
                    {
                        view.widthConstraint = new EqualConstraintWithParentFloat((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SizeWidth, View.Property.SizeWidth);
                        view.widthConstraint.Apply();
                    }
                    Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.WidthResizePolicy, new Tizen.NUI.PropertyValue((int)ResizePolicyType.FillToParent));
                }
                else
                {
                    view.widthConstraint?.Remove();
                    view.widthConstraint?.Dispose();
                    view.widthConstraint = null;
                    Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.WidthResizePolicy, new Tizen.NUI.PropertyValue((int)newValue));
                }
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
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.WidthResizePolicy).Get(out temp) == false)
            {
                NUILog.Error("WidthResizePolicy get error!");
            }
            return temp.GetValueByDescription<ResizePolicyType>();
        }));

        /// <summary>
        /// HeightResizePolicyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HeightResizePolicyProperty = BindableProperty.Create(nameof(HeightResizePolicy), typeof(ResizePolicyType), typeof(View), ResizePolicyType.Fixed, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                if ((ResizePolicyType)newValue == ResizePolicyType.KeepSizeFollowingParent)
                {
                    if (view.heightConstraint == null)
                    {
                        view.heightConstraint = new EqualConstraintWithParentFloat((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SizeHeight, View.Property.SizeHeight);
                        view.heightConstraint.Apply();
                    }
                    Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.HeightResizePolicy, new Tizen.NUI.PropertyValue((int)ResizePolicyType.FillToParent));
                }
                else
                {
                    view.heightConstraint?.Remove();
                    view.heightConstraint?.Dispose();
                    view.heightConstraint = null;
                    Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.HeightResizePolicy, new Tizen.NUI.PropertyValue((int)newValue));
                }
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
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.HeightResizePolicy).Get(out temp) == false)
            {
                NUILog.Error("HeightResizePolicy get error!");
            }
            return temp.GetValueByDescription<ResizePolicyType>();
        }));

        /// <summary>
        /// SizeScalePolicyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeScalePolicyProperty = BindableProperty.Create(nameof(SizeScalePolicy), typeof(SizeScalePolicyType), typeof(View), SizeScalePolicyType.UseSizeSet, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            string valueToString = "";
            if (newValue != null)
            {
                valueToString = ((SizeScalePolicyType)newValue).GetDescription();
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SizeScalePolicy, new Tizen.NUI.PropertyValue(valueToString));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            int temp;
            if (Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SizeScalePolicy).Get(out temp) == false)
            {
                NUILog.Error("SizeScalePolicy get error!");
            }
            return (SizeScalePolicyType)temp;
        }));

        /// <summary>
        /// WidthForHeightProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WidthForHeightProperty = BindableProperty.Create(nameof(WidthForHeight), typeof(bool), typeof(View), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.WidthForHeight, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.WidthForHeight).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// HeightForWidthProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HeightForWidthProperty = BindableProperty.Create(nameof(HeightForWidth), typeof(bool), typeof(View), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.HeightForWidth, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.HeightForWidth).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// PaddingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PaddingProperty = BindableProperty.Create(nameof(Padding), typeof(Extents), typeof(View), null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = (View)bindable;
                if (newValue != null)
                {
                    var tmp = new PropertyValue((Extents)newValue);
                    Object.SetProperty(view.SwigCPtr, View.Property.PADDING, tmp);
                    tmp?.Dispose();
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var view = (View)bindable;
                if (view.internalPadding == null)
                {
                    view.internalPadding = new Extents(view.OnPaddingChanged, 0, 0, 0, 0);
                }

                var tmp = Object.GetProperty(view.SwigCPtr, Property.PADDING);
                tmp?.Get(view.internalPadding);
                tmp?.Dispose();

                return view.internalPadding;
            }
        );

        /// <summary>
        /// SizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size), typeof(Size), typeof(View), null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = (View)bindable;
                if (newValue != null)
                {
                    // Set Specification so when layouts measure this View it matches the value set here.
                    // All Views are currently Layouts.
                    view.WidthSpecification = (int)System.Math.Ceiling(((Size)newValue).Width);
                    view.HeightSpecification = (int)System.Math.Ceiling(((Size)newValue).Height);

                    view.SetSize(((Size)newValue).Width, ((Size)newValue).Height, ((Size)newValue).Depth);
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var view = (View)bindable;

                var tmpProperty = Object.GetProperty(view.SwigCPtr, Property.SIZE);
                if (view.internalSize == null)
                {
                    view.internalSize = new Size(view.OnSizeChanged, 0, 0, 0);
                }
                tmpProperty?.Get(view.internalSize);
                tmpProperty?.Dispose();

                return view.internalSize;
            }
        );

        /// <summary>
        /// MinimumSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinimumSizeProperty = BindableProperty.Create(nameof(MinimumSize), typeof(Size2D), typeof(View), null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = (View)bindable;
                if (newValue != null)
                {
                    view.SetMinimumSize((Size2D)newValue);
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var view = (View)bindable;
                if (view.internalMinimumSize == null)
                {
                    view.internalMinimumSize = new Size2D(view.OnMinimumSizeChanged, 0, 0);
                }
                var tmp = Object.GetProperty(view.SwigCPtr, Property.MinimumSize);
                tmp?.Get(view.internalMinimumSize);
                tmp?.Dispose();

                return view.internalMinimumSize;
            }
        );

        /// <summary>
        /// MaximumSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaximumSizeProperty = BindableProperty.Create(nameof(MaximumSize), typeof(Size2D), typeof(View), null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = (View)bindable;
                if (newValue != null)
                {
                    view.SetMaximumSize((Size2D)newValue);
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var view = (View)bindable;
                if (view.internalMaximumSize == null)
                {
                    view.internalMaximumSize = new Size2D(view.OnMaximumSizeChanged, 0, 0);
                }
                var tmp = Object.GetProperty(view.SwigCPtr, Property.MaximumSize);
                tmp?.Get(view.internalMaximumSize);
                tmp?.Dispose();

                return view.internalMaximumSize;
            }
        );

        /// <summary>
        /// InheritPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InheritPositionProperty = BindableProperty.Create(nameof(InheritPosition), typeof(bool), typeof(View), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.InheritPosition, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.InheritPosition).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// ClippingModeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ClippingModeProperty = BindableProperty.Create(nameof(ClippingMode), typeof(ClippingModeType), typeof(View), ClippingModeType.Disabled, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.ClippingMode, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            int temp = 0;
            if (Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.ClippingMode).Get(out temp) == false)
            {
                NUILog.Error("ClippingMode get error!");
            }
            return (ClippingModeType)temp;
        }));

        /// <summary>
        /// InheritLayoutDirectionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InheritLayoutDirectionProperty = BindableProperty.Create(nameof(InheritLayoutDirection), typeof(bool), typeof(View), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.InheritLayoutDirection, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.InheritLayoutDirection).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// LayoutDirectionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LayoutDirectionProperty = BindableProperty.Create(nameof(LayoutDirection), typeof(ViewLayoutDirectionType), typeof(View), ViewLayoutDirectionType.LTR, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.LayoutDirection, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            int temp;
            if (false == Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.LayoutDirection).Get(out temp))
            {
                NUILog.Error("LAYOUT_DIRECTION get error!");
            }
            return (ViewLayoutDirectionType)temp;
        }));

        /// <summary>
        /// MarginProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MarginProperty = BindableProperty.Create(nameof(Margin), typeof(Extents), typeof(View), null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = (View)bindable;
                if (newValue != null)
                {
                    var tmp = new PropertyValue((Extents)newValue);
                    Object.SetProperty(view.SwigCPtr, Property.MARGIN, tmp);
                    tmp?.Dispose();
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var view = (View)bindable;
                if (view.internalMargin == null)
                {
                    view.internalMargin = new Extents(view.OnMarginChanged, 0, 0, 0, 0);
                }
                var tmp = Object.GetProperty(view.SwigCPtr, Property.MARGIN);
                tmp?.Get(view.internalMargin);
                tmp?.Dispose();

                return view.internalMargin;
            }
        );

        /// <summary>
        /// UpdateSizeHintProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UpdateSizeHintProperty = BindableProperty.Create(nameof(UpdateSizeHint), typeof(Vector2), typeof(View), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, Interop.ViewProperty.UpdateSizeHintGet(), new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;

            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, Interop.ViewProperty.UpdateSizeHintGet()).Get(temp);
            return temp;
        }));

        /// <summary>
        /// ImageShadow Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ImageShadowProperty = BindableProperty.Create(nameof(ImageShadow), typeof(ImageShadow), typeof(View), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;

            view.themeData?.selectorData?.ClearShadow(view);

            if (newValue is Selector<ImageShadow> selector)
            {
                if (selector.HasAll()) view.SetShadow(selector.All);
                else view.EnsureSelectorData().ImageShadow = new TriggerableSelector<ImageShadow>(view, selector, view.SetShadow, true);
            }
            else
            {
                view.SetShadow((ImageShadow)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;

            PropertyMap map = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SHADOW).Get(map);

            var shadow = new ImageShadow(map);
            return shadow.IsEmpty() ? null : shadow;
        }));

        /// <summary>
        /// Shadow Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BoxShadowProperty = BindableProperty.Create(nameof(BoxShadow), typeof(Shadow), typeof(View), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;

            view.themeData?.selectorData?.ClearShadow(view);

            if (newValue is Selector<Shadow> selector)
            {
                if (selector.HasAll()) view.SetShadow(selector.All);
                else view.EnsureSelectorData().BoxShadow = new TriggerableSelector<Shadow>(view, selector, view.SetShadow, true);
            }
            else
            {
                view.SetShadow((Shadow)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;

            PropertyMap map = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SHADOW).Get(map);

            var shadow = new Shadow(map);
            return shadow.IsEmpty() ? null : shadow;
        }));

        /// <summary>
        /// CornerRadius Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(Vector4), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            (view.backgroundExtraData ?? (view.backgroundExtraData = new BackgroundExtraData())).CornerRadius = (Vector4)newValue;
            view.ApplyCornerRadius();
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            return view.backgroundExtraData == null ? 0.0f : view.backgroundExtraData.CornerRadius;
        });

        /// <summary>
        /// CornerRadiusPolicy Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CornerRadiusPolicyProperty = BindableProperty.Create(nameof(CornerRadiusPolicy), typeof(VisualTransformPolicyType), typeof(View), VisualTransformPolicyType.Absolute, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            (view.backgroundExtraData ?? (view.backgroundExtraData = new BackgroundExtraData())).CornerRadiusPolicy = (VisualTransformPolicyType)newValue;

            if (view.backgroundExtraData.CornerRadius != null)
            {
                view.ApplyCornerRadius();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            return view.backgroundExtraData == null ? VisualTransformPolicyType.Absolute : view.backgroundExtraData.CornerRadiusPolicy;
        });

        /// <summary>
        /// BorderlineWidth Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderlineWidthProperty = BindableProperty.Create(nameof(BorderlineWidth), typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            (view.backgroundExtraData ?? (view.backgroundExtraData = new BackgroundExtraData())).BorderlineWidth = (float)newValue;
            view.ApplyBorderline();
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            return view.backgroundExtraData == null ? 0.0f : view.backgroundExtraData.BorderlineWidth;
        });

        /// <summary>
        /// BorderlineColor Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderlineColorProperty = BindableProperty.Create(nameof(BorderlineColor), typeof(Color), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            (view.backgroundExtraData ?? (view.backgroundExtraData = new BackgroundExtraData())).BorderlineColor = (Color)newValue;
            view.ApplyBorderline();
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            return view.backgroundExtraData == null ? Color.Black : view.backgroundExtraData.BorderlineColor;
        });

        /// <summary>
        /// BorderlineOffset Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderlineOffsetProperty = BindableProperty.Create(nameof(BorderlineOffset), typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            (view.backgroundExtraData ?? (view.backgroundExtraData = new BackgroundExtraData())).BorderlineOffset = (float)newValue;
            view.ApplyBorderline();
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            return view.backgroundExtraData == null ? 0.0f : view.backgroundExtraData.BorderlineOffset;
        });

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

            if (view.ThemeChangeSensitive == (bool)newValue) return;

            if (view.themeData == null) view.themeData = new ThemeData();

            view.themeData.ThemeChangeSensitive = (bool)newValue;

            if (!view.themeData.ThemeApplied) return;

            if (view.themeData.ThemeChangeSensitive && !view.themeData.ListeningThemeChangeEvent)
            {
                view.themeData.ListeningThemeChangeEvent = true;
                ThemeManager.ThemeChangedInternal.Add(view.OnThemeChanged);
            }
            else if (!view.themeData.ThemeChangeSensitive && view.themeData.ListeningThemeChangeEvent)
            {
                view.themeData.ListeningThemeChangeEvent = false;
                ThemeManager.ThemeChangedInternal.Remove(view.OnThemeChanged);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            return ((View)bindable).themeData?.ThemeChangeSensitive ?? ThemeManager.ApplicationThemeChangeSensitive;
        });

        /// <summary>
        /// AccessibilityNameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AccessibilityNameProperty = BindableProperty.Create(nameof(AccessibilityName), typeof(string), typeof(View), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.AccessibilityName, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;

            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.AccessibilityName).Get(out temp);
            return temp;
        });

        /// <summary>
        /// AccessibilityDescriptionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AccessibilityDescriptionProperty = BindableProperty.Create(nameof(AccessibilityDescription), typeof(string), typeof(View), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.AccessibilityDescription, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;

            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.AccessibilityDescription).Get(out temp);
            return temp;
        });

        /// <summary>
        /// AccessibilityTranslationDomainProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AccessibilityTranslationDomainProperty = BindableProperty.Create(nameof(AccessibilityTranslationDomain), typeof(string), typeof(View), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.AccessibilityTranslationDomain, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;

            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.AccessibilityTranslationDomain).Get(out temp);
            return temp;
        });

        /// <summary>
        /// AccessibilityRoleProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AccessibilityRoleProperty = BindableProperty.Create(nameof(AccessibilityRole), typeof(Role), typeof(View), default(Role), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.AccessibilityRole, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;

            int temp = 0;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.AccessibilityRole).Get(out temp);
            return (Role)temp;
        });

        /// <summary>
        /// AccessibilityHighlightableProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AccessibilityHighlightableProperty = BindableProperty.Create(nameof(AccessibilityHighlightable), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.AccessibilityHighlightable, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.AccessibilityHighlightable).Get(out temp);
            return temp;
        });

        /// <summary>
        /// AccessibilityHiddenProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AccessibilityHiddenProperty = BindableProperty.Create(nameof(AccessibilityHidden), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.AccessibilityHidden, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.AccessibilityHidden).Get(out temp);
            return temp;
        });

        /// <summary>
        /// ExcludeLayoutingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ExcludeLayoutingProperty = BindableProperty.Create(nameof(ExcludeLayouting), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalExcludeLayouting = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalExcludeLayouting;
        });

        /// <summary>
        /// TooltipTextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TooltipTextProperty = BindableProperty.Create(nameof(TooltipText), typeof(string), typeof(View), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalTooltipText = (string)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalTooltipText;
        });

        /// <summary>
        /// PositionUsesAnchorPointProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionUsesAnchorPointProperty = BindableProperty.Create(nameof(PositionUsesAnchorPoint), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalPositionUsesAnchorPoint = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalPositionUsesAnchorPoint;
        });

        /// <summary>
        /// AnchorPointProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AnchorPointProperty = BindableProperty.Create(nameof(AnchorPoint), typeof(Tizen.NUI.Position), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalAnchorPoint = (Tizen.NUI.Position)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalAnchorPoint;
        });

        /// <summary>
        /// WidthSpecificationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WidthSpecificationProperty = BindableProperty.Create(nameof(WidthSpecification), typeof(int), typeof(View), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalWidthSpecification = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalWidthSpecification;
        });

        /// <summary>
        /// HeightSpecificationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HeightSpecificationProperty = BindableProperty.Create(nameof(HeightSpecification), typeof(int), typeof(View), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalHeightSpecification = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalHeightSpecification;
        });

        /// <summary>
        /// LayoutTransitionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LayoutTransitionProperty = BindableProperty.Create(nameof(LayoutTransition), typeof(Tizen.NUI.LayoutTransition), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalLayoutTransition = (Tizen.NUI.LayoutTransition)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalLayoutTransition;
        });

        /// <summary>
        /// PaddingEXProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PaddingEXProperty = BindableProperty.Create(nameof(PaddingEX), typeof(Tizen.NUI.Extents), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalPaddingEX = (Tizen.NUI.Extents)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalPaddingEX;
        });

        /// <summary>
        /// LayoutProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LayoutProperty = BindableProperty.Create(nameof(Layout), typeof(Tizen.NUI.LayoutItem), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalLayout = (Tizen.NUI.LayoutItem)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalLayout;
        });

        /// <summary>
        /// BackgroundImageSynchronosLoadingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageSynchronosLoadingProperty = BindableProperty.Create(nameof(BackgroundImageSynchronosLoading), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalBackgroundImageSynchronosLoading = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalBackgroundImageSynchronosLoading;
        });

        /// <summary>
        /// BackgroundImageSynchronousLoadingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageSynchronousLoadingProperty = BindableProperty.Create(nameof(BackgroundImageSynchronousLoading), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalBackgroundImageSynchronousLoading = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalBackgroundImageSynchronousLoading;
        });

        /// <summary>
        /// EnableControlStatePropagationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableControlStatePropagationProperty = BindableProperty.Create(nameof(EnableControlStatePropagation), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalEnableControlStatePropagation = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalEnableControlStatePropagation;
        });

        /// <summary>
        /// GrabTouchAfterLeaveProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabTouchAfterLeaveProperty = BindableProperty.Create(nameof(GrabTouchAfterLeave), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalGrabTouchAfterLeave = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalGrabTouchAfterLeave;
        });

        /// <summary>
        /// BlendEquationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BlendEquationProperty = BindableProperty.Create(nameof(BlendEquation), typeof(BlendEquationType), typeof(View), default(BlendEquationType), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalBlendEquation = (Tizen.NUI.BlendEquationType)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalBlendEquation;
        });

        /// <summary>
        /// TransitionOptionsProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TransitionOptionsProperty = BindableProperty.Create(nameof(TransitionOptions), typeof(TransitionOptions), typeof(View), default(TransitionOptions), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalTransitionOptions = (Tizen.NUI.TransitionOptions)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalTransitionOptions;
        });

        /// <summary>
        /// AutomationIdProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutomationIdProperty = BindableProperty.Create(nameof(AutomationId), typeof(string), typeof(View), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalAutomationId = (string)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalAutomationId;
        });

        /// <summary>
        /// TouchAreaOffsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TouchAreaOffsetProperty = BindableProperty.Create(nameof(TouchAreaOffset), typeof(Offset), typeof(View), default(Offset), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalTouchAreaOffset = (Tizen.NUI.Offset)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalTouchAreaOffset;
        });

        private void SetBackgroundImage(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                var empty = new PropertyValue();
                // Clear background
                Object.SetProperty(SwigCPtr, Property.BACKGROUND, empty);
                empty.Dispose();
                return;
            }

            if (value.StartsWith("*Resource*"))
            {
                string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
                value = value.Replace("*Resource*", resource);
            }

            if (backgroundExtraData == null)
            {
                var propertyValue = new PropertyValue(value);
                Object.SetProperty(SwigCPtr, Property.BACKGROUND, propertyValue);
                BackgroundImageSynchronousLoading = backgroundImageSynchronousLoading;
                propertyValue?.Dispose();
                return;
            }

            var map = new PropertyMap();
            var url = new PropertyValue(value);
            var cornerRadiusValue = backgroundExtraData.CornerRadius == null ? new PropertyValue() : new PropertyValue(backgroundExtraData.CornerRadius);
            var cornerRadius = new PropertyValue(cornerRadiusValue);
            var cornerRadiusPolicy = new PropertyValue((int)(backgroundExtraData.CornerRadiusPolicy));
            var borderlineWidth = new PropertyValue(backgroundExtraData.BorderlineWidth);
            var borderlineColorValue = backgroundExtraData.BorderlineColor == null ? new PropertyValue(Color.Black) : new PropertyValue(backgroundExtraData.BorderlineColor);
            var borderlineColor = new PropertyValue(borderlineColorValue);
            var borderlineOffset = new PropertyValue(backgroundExtraData.BorderlineOffset);
            var synchronousLoading = new PropertyValue(backgroundImageSynchronousLoading);
            var npatchType = new PropertyValue((int)Visual.Type.NPatch);
            var border = (backgroundExtraData.BackgroundImageBorder != null) ? new PropertyValue(backgroundExtraData.BackgroundImageBorder) : null;
            var imageType = new PropertyValue((int)Visual.Type.Image);

            map.Add(ImageVisualProperty.URL, url)
               .Add(Visual.Property.CornerRadius, cornerRadius)
               .Add(Visual.Property.CornerRadiusPolicy, cornerRadiusPolicy)
               .Add(Visual.Property.BorderlineWidth, borderlineWidth)
               .Add(Visual.Property.BorderlineColor, borderlineColor)
               .Add(Visual.Property.BorderlineOffset, borderlineOffset)
               .Add(ImageVisualProperty.SynchronousLoading, synchronousLoading);

            if (backgroundExtraData.BackgroundImageBorder != null)
            {
                map.Add(Visual.Property.Type, npatchType)
                   .Add(NpatchImageVisualProperty.Border, border);
            }
            else
            {
                map.Add(Visual.Property.Type, imageType);
            }

            var mapValue = new PropertyValue(map);
            Object.SetProperty(SwigCPtr, Property.BACKGROUND, mapValue);

            imageType?.Dispose();
            border?.Dispose();
            npatchType?.Dispose();
            synchronousLoading?.Dispose();
            borderlineOffset?.Dispose();
            borderlineColor?.Dispose();
            borderlineColorValue?.Dispose();
            borderlineWidth?.Dispose();
            cornerRadiusPolicy?.Dispose();
            cornerRadius?.Dispose();
            cornerRadiusValue?.Dispose();
            url?.Dispose();
            map?.Dispose();
            mapValue?.Dispose();
        }

        private void SetBackgroundImageBorder(Rectangle value)
        {
            bool isEmptyValue = Rectangle.IsNullOrZero(value);

            var backgroundImageBorder = isEmptyValue ? null : value;

            (backgroundExtraData ?? (backgroundExtraData = new BackgroundExtraData())).BackgroundImageBorder = backgroundImageBorder;

            if (isEmptyValue)
            {
                return;
            }

            PropertyMap map = Background;

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

            Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, View.Property.BACKGROUND, new PropertyValue(map));
        }

        private void SetBackgroundColor(Color value)
        {
            if (value == null)
            {
                return;
            }

            if (backgroundExtraData == null)
            {
                var background = new PropertyValue(value);
                Object.SetProperty(SwigCPtr, Property.BACKGROUND, background);
                background?.Dispose();
                return;
            }

            var map = new PropertyMap();
            var colorType = new PropertyValue((int)Visual.Type.Color);
            var mixColor = new PropertyValue(value);
            var cornerRadiusValue = backgroundExtraData.CornerRadius == null ? new PropertyValue() : new PropertyValue(backgroundExtraData.CornerRadius);
            var cornerRadius = new PropertyValue(cornerRadiusValue);
            var cornerRadiusPolicy = new PropertyValue((int)(backgroundExtraData.CornerRadiusPolicy));
            var borderlineWidth = new PropertyValue(backgroundExtraData.BorderlineWidth);
            var borderlineColorValue = backgroundExtraData.BorderlineColor == null ? new PropertyValue(Color.Black) : new PropertyValue(backgroundExtraData.BorderlineColor);
            var borderlineColor = new PropertyValue(borderlineColorValue);
            var borderlineOffset = new PropertyValue(backgroundExtraData.BorderlineOffset);

            map.Add(Visual.Property.Type, colorType)
               .Add(ColorVisualProperty.MixColor, mixColor)
               .Add(Visual.Property.CornerRadius, cornerRadius)
               .Add(Visual.Property.CornerRadiusPolicy, cornerRadiusPolicy)
               .Add(Visual.Property.BorderlineWidth, borderlineWidth)
               .Add(Visual.Property.BorderlineColor, borderlineColor)
               .Add(Visual.Property.BorderlineOffset, borderlineOffset);

            var mapValue = new PropertyValue(map);
            Object.SetProperty(SwigCPtr, Property.BACKGROUND, mapValue);

            borderlineOffset?.Dispose();
            borderlineColor?.Dispose();
            borderlineColorValue?.Dispose();
            borderlineWidth?.Dispose();
            cornerRadiusPolicy?.Dispose();
            cornerRadius?.Dispose();
            cornerRadiusValue?.Dispose();
            mixColor?.Dispose();
            colorType?.Dispose();
            map?.Dispose();
            mapValue?.Dispose();
        }

        private void SetColor(Color value)
        {
            if (value == null)
            {
                return;
            }

            Interop.ActorInternal.SetColor(SwigCPtr, value.SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void SetOpacity(float? value)
        {
            if (value == null)
            {
                return;
            }

            Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, View.Property.OPACITY, new Tizen.NUI.PropertyValue((float)value));
        }

        private void SetShadow(ShadowBase value)
        {
            Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, View.Property.SHADOW, value == null ? new PropertyValue() : value.ToPropertyValue(this));
        }
    }
}
