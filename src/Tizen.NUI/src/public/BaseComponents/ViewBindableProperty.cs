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
                view.UpdateStyle();
                view.ThemeChangeSensitive = true;
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
        public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(View), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;

            view.selectorData?.ClearBackground(view);

            if (newValue is Selector<Color> selector)
            {
                if (selector.HasAll()) view.SetBackgroundColor(selector.All);
                else view.EnsureSelectorData().BackgroundColor = new TriggerableSelector<Color>(view, selector, view.SetBackgroundColor, true);
            }
            else
            {
                view.SetBackgroundColor((Color)newValue);
            }
        }),
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

            view.selectorData?.Color?.Reset(view);

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
            Color color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            view.GetProperty(Interop.ActorProperty.ColorGet()).Get(color);
            return color;
        });
        /// <summary> BackgroundImageProperty </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageProperty = BindableProperty.Create(nameof(BackgroundImage), typeof(string), typeof(View), default(string), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;

            if (view.selectorData != null)
            {
                view.selectorData.BackgroundColor?.Reset(view);
                view.selectorData.BackgroundImage?.Reset(view);
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
        }),
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
        public static readonly BindableProperty BackgroundImageBorderProperty = BindableProperty.Create(nameof(BackgroundImageBorder), typeof(Rectangle), typeof(View), default(Rectangle), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;

            view.selectorData?.BackgroundImageBorder?.Reset(view);

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
        public static readonly BindableProperty BackgroundProperty = BindableProperty.Create(nameof(Background), typeof(PropertyMap), typeof(View), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.BACKGROUND, new Tizen.NUI.PropertyValue((PropertyMap)newValue));

                view.backgroundExtraData = null;
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.BACKGROUND).Get(temp);
            return temp;
        }));

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
        public static readonly BindableProperty CellIndexProperty = BindableProperty.Create(nameof(CellIndex), typeof(Vector2), typeof(View), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, TableView.ChildProperty.CellIndex, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, TableView.ChildProperty.CellIndex).Get(temp);
            return temp;
        }));

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
        /// Size2DProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty Size2DProperty = BindableProperty.Create(nameof(Size2D), typeof(Size2D), typeof(View), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SIZE, new Tizen.NUI.PropertyValue(new Size((Size2D)newValue)));
                view.widthPolicy = ((Size2D)newValue).Width;
                view.heightPolicy = ((Size2D)newValue).Height;

                view.layout?.RequestLayout();
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            Size temp = new Size(0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SIZE).Get(temp);
            Size2D size = new Size2D((int)temp.Width, (int)temp.Height);
            return size;
        }));

        /// <summary>
        /// OpacityProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OpacityProperty = BindableProperty.Create(nameof(Opacity), typeof(float), typeof(View), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;

            view.selectorData?.Opacity?.Reset(view);

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
        public static readonly BindableProperty Position2DProperty = BindableProperty.Create(nameof(Position2D), typeof(Position2D), typeof(View), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.POSITION, new Tizen.NUI.PropertyValue(new Position((Position2D)newValue)));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            Position temp = new Position(0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.POSITION).Get(temp);
            return new Position2D(temp);
        }));

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
        public static readonly BindableProperty PivotPointProperty = BindableProperty.Create(nameof(PivotPoint), typeof(Position), typeof(View), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.AnchorPoint, new Tizen.NUI.PropertyValue((Position)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            Position temp = new Position(0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.AnchorPoint).Get(temp);
            return temp;
        }));

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
        public static readonly BindableProperty PositionProperty = BindableProperty.Create(nameof(Position), typeof(Position), typeof(View), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.POSITION, new Tizen.NUI.PropertyValue((Position)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            Position temp = new Position(0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.POSITION).Get(temp);
            return temp;
        }));

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
        public static readonly BindableProperty ScaleProperty = BindableProperty.Create(nameof(Scale), typeof(Vector3), typeof(View), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SCALE, new Tizen.NUI.PropertyValue((Vector3)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SCALE).Get(temp);
            return temp;
        }));

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
        public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(View), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.NAME, new Tizen.NUI.PropertyValue((string)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.NAME).Get(out temp);
            return temp;
        }));

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
        public static readonly BindableProperty SizeModeFactorProperty = BindableProperty.Create(nameof(SizeModeFactor), typeof(Vector3), typeof(View), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SizeModeFactor, new Tizen.NUI.PropertyValue((Vector3)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SizeModeFactor).Get(temp);
            return temp;
        }));

        /// <summary>
        /// WidthResizePolicyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty WidthResizePolicyProperty = BindableProperty.Create(nameof(WidthResizePolicy), typeof(ResizePolicyType), typeof(View), ResizePolicyType.Fixed, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.WidthResizePolicy, new Tizen.NUI.PropertyValue((int)newValue));
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
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.HeightResizePolicy, new Tizen.NUI.PropertyValue((int)newValue));
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
        public static readonly BindableProperty PaddingProperty = BindableProperty.Create(nameof(Padding), typeof(Extents), typeof(View), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.PADDING, new Tizen.NUI.PropertyValue((Extents)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            Extents temp = new Extents(0, 0, 0, 0);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.PADDING).Get(temp);
            return temp;
        }));

        /// <summary>
        /// SizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SizeProperty = BindableProperty.Create(nameof(Size), typeof(Size), typeof(View), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Size size = (Size)newValue;
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SIZE, new Tizen.NUI.PropertyValue(size));
                // Set Specification so when layouts measure this View it matches the value set here.
                // All Views are currently Layouts.
                view.WidthSpecification = (int)System.Math.Ceiling(size.Width);
                view.HeightSpecification = (int)System.Math.Ceiling(size.Height);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            Size temp = new Size(0, 0, 0);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SIZE).Get(temp);
            return temp;
        }));

        /// <summary>
        /// MinimumSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinimumSizeProperty = BindableProperty.Create(nameof(MinimumSize), typeof(Size2D), typeof(View), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            Size2D temp = newValue as Size2D;
            if (temp != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.MinimumSize, new Tizen.NUI.PropertyValue(temp));
            }
            else
            {
                Tizen.Log.Fatal("NUI", $"[ERROR] can't set MinimumSizeProperty!");
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            Size2D temp = new Size2D(0, 0);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.MinimumSize).Get(temp);
            return temp;
        }));

        /// <summary>
        /// MaximumSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaximumSizeProperty = BindableProperty.Create(nameof(MaximumSize), typeof(Size2D), typeof(View), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            Size2D temp = newValue as Size2D;
            if (temp != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.MaximumSize, new Tizen.NUI.PropertyValue(temp));
            }
            else
            {
                Tizen.Log.Fatal("NUI", $"[ERROR] can't set MaximumSizeProperty!");
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            Size2D temp = new Size2D(0, 0);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.MaximumSize).Get(temp);
            return temp;
        }));

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
        public static readonly BindableProperty MarginProperty = BindableProperty.Create(nameof(Margin), typeof(Extents), typeof(View), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.MARGIN, new Tizen.NUI.PropertyValue((Extents)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            Extents temp = new Extents(0, 0, 0, 0);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.MARGIN).Get(temp);
            return temp;
        }));

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

            view.selectorData?.ClearShadow(view);

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

            view.selectorData?.ClearShadow(view);

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
            return view.backgroundExtraData == null ? 0 : view.backgroundExtraData.CornerRadius;
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
                ThemeManager.ThemeChangedInternal.Add(view.OnThemeChanged);
            }
            else
            {
                ThemeManager.ThemeChangedInternal.Remove(view.OnThemeChanged);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            return ((View)bindable).themeChangeSensitive;
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
        public static readonly BindableProperty AccessibilityRoleProperty = BindableProperty.Create(nameof(AccessibilityRole), typeof(int), typeof(View), default(int), propertyChanged: (bindable, oldValue, newValue) =>
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
            return temp;
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
        /// AccessibilityAnimatedProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AccessibilityAnimatedProperty = BindableProperty.Create(nameof(AccessibilityAnimated), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.AccessibilityAnimated, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.AccessibilityAnimated).Get(out temp);
            return temp;
        });

        private void SetBackgroundImage(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                // Clear background
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, View.Property.BACKGROUND, new PropertyValue());
                return;
            }

            if (value.StartsWith("*Resource*"))
            {
                string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
                value = value.Replace("*Resource*", resource);
            }

            if (backgroundExtraData == null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, View.Property.BACKGROUND, new PropertyValue(value));
                BackgroundImageSynchronosLoading = backgroundImageSynchronosLoading;

                return;
            }

            PropertyMap map = new PropertyMap();

            map.Add(ImageVisualProperty.URL, new PropertyValue(value))
               .Add(Visual.Property.CornerRadius, new PropertyValue(backgroundExtraData.CornerRadius == null ? new PropertyValue() : new PropertyValue(backgroundExtraData.CornerRadius)))
               .Add(Visual.Property.CornerRadiusPolicy, new PropertyValue((int)(backgroundExtraData.CornerRadiusPolicy)))
               .Add(ImageVisualProperty.SynchronousLoading, new PropertyValue(backgroundImageSynchronosLoading));

            if (backgroundExtraData.BackgroundImageBorder != null)
            {
                map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.NPatch))
                   .Add(NpatchImageVisualProperty.Border, new PropertyValue(backgroundExtraData.BackgroundImageBorder));
            }
            else
            {
                map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
            }

            Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, View.Property.BACKGROUND, new PropertyValue(map));
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
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, View.Property.BACKGROUND, new PropertyValue(value));
                return;
            }

            PropertyMap map = new PropertyMap();

            map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Color))
                .Add(ColorVisualProperty.MixColor, new PropertyValue(value))
                .Add(Visual.Property.CornerRadius, new PropertyValue(new PropertyValue(backgroundExtraData.CornerRadius == null ? new PropertyValue() : new PropertyValue(backgroundExtraData.CornerRadius))))
                .Add(Visual.Property.CornerRadiusPolicy, new PropertyValue((int)(backgroundExtraData.CornerRadiusPolicy)));

            Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, View.Property.BACKGROUND, new PropertyValue(map));
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
