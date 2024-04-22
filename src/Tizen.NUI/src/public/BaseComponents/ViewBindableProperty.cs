/*
 * Copyright(c) 2019-2022 Samsung Electronics Co., Ltd.
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
        private float userSizeWidth = 0.0f;
        private float userSizeHeight = 0.0f;

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

                Object.InternalSetPropertyString(view.SwigCPtr, View.Property.StyleName, styleName);

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

            return Object.InternalGetPropertyString(view.SwigCPtr, View.Property.StyleName);
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
                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.KeyInputFocus, (bool)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.KeyInputFocus);
        }));

        // BackgroundColorProperty
        internal static void SetInternalBackgroundColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;

            if (NUIApplication.IsUsingXaml)
            {
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

            }
            else
            {
                view.SetBackgroundColor((Color)newValue);
            }
        }

        internal static object GetInternalBackgroundColorProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            if (view.internalBackgroundColor == null)
            {
                view.internalBackgroundColor = new Color(view.OnBackgroundColorChanged, 0, 0, 0, 0);
            }

            int visualType = (int)Visual.Type.Invalid;
            Interop.View.InternalRetrievingVisualPropertyInt(view.SwigCPtr, Property.BACKGROUND, Visual.Property.Type, out visualType);
            if (visualType == (int)Visual.Type.Color)
            {
                Interop.View.InternalRetrievingVisualPropertyVector4(view.SwigCPtr, Property.BACKGROUND, ColorVisualProperty.MixColor, Color.getCPtr(view.internalBackgroundColor));
            }
            return view.internalBackgroundColor;
        }

        /// <summary>
        /// BackgroundColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        public static BindableProperty BackgroundColorProperty = null;

        internal static BindableProperty GetBackgroundColorProperty()
        {
            if (BackgroundColorProperty == null)
            {
                BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(View), null,
                    propertyChanged: SetInternalBackgroundColorProperty, defaultValueCreator: GetInternalBackgroundColorProperty);
            }
            return BackgroundColorProperty;
        }
#else
        public static readonly BindableProperty BackgroundColorProperty = null;
#endif

        // ColorProperty
        internal static void SetInternalColorProperty(BindableObject bindable, object oldValue, object newValue)
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
        }

        internal static object GetInternalColorProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            if (view.internalColor == null)
            {
                view.internalColor = new Color(view.OnColorChanged, 0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(view.SwigCPtr, View.Property.COLOR, view.internalColor.SwigCPtr);
            return view.internalColor;
        }

        /// <summary>
        /// ColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        public static BindableProperty ColorProperty = null;

        internal static BindableProperty GetColorProperty()
        {
            if (ColorProperty == null)
            {
                ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(View), null,
                    propertyChanged: SetInternalColorProperty, defaultValueCreator: GetInternalColorProperty);
            }
            return ColorProperty;
        }
#else
        public static readonly BindableProperty ColorProperty = null;
#endif

        // ColorRedProperty
        internal static void SetInternalColorRedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            view.SetColorRed((float?)newValue);
        }

        internal static object GetInternalColorRedProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyFloat(view.SwigCPtr, View.Property.ColorRed);
        }

        /// <summary>
        /// ColorRedProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        public static BindableProperty ColorRedProperty = null;

        internal static BindableProperty GetColorRedProperty()
        {
            if (ColorRedProperty == null)
            {
                ColorRedProperty = BindableProperty.Create(nameof(ColorRed), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalColorRedProperty, defaultValueCreator: GetInternalColorRedProperty);
            }
            return ColorRedProperty;
        }
#else
        public static readonly BindableProperty ColorRedProperty = null;
#endif

        // ColorGreenProperty
        internal static void SetInternalColorGreenProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            view.SetColorGreen((float?)newValue);

        }

        internal static object GetInternalColorGreenProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyFloat(view.SwigCPtr, View.Property.ColorGreen);

        }

        /// <summary>
        /// ColorGreenProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        public static BindableProperty ColorGreenProperty = null;

        internal static BindableProperty GetColorGreenProperty()
        {
            if (ColorGreenProperty == null)
            {
                ColorGreenProperty = BindableProperty.Create(nameof(ColorGreen), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalColorGreenProperty, defaultValueCreator: GetInternalColorGreenProperty);
            }
            return ColorGreenProperty;
        }
#else
        public static readonly BindableProperty ColorGreenProperty = null;
#endif

        // ColorBlueProperty
        internal static void SetInternalColorBlueProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            view.SetColorBlue((float?)newValue);

        }

        internal static object GetInternalColorBlueProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyFloat(view.SwigCPtr, View.Property.ColorBlue);

        }

        /// <summary>
        /// ColorBlueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        public static BindableProperty ColorBlueProperty = null;

        internal static BindableProperty GetColorBlueProperty()
        {
            if (ColorBlueProperty == null)
            {
                ColorBlueProperty = BindableProperty.Create(nameof(ColorBlue), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalColorBlueProperty, defaultValueCreator: GetInternalColorBlueProperty);
            }
            return ColorBlueProperty;
        }
#else
        public static readonly BindableProperty ColorBlueProperty = null;
#endif

        /// <summary> BackgroundImageProperty </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BackgroundImageProperty = BindableProperty.Create(nameof(BackgroundImage), typeof(string), typeof(View), default(string),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                if (String.Equals(oldValue, newValue))
                {
                    NUILog.Debug($"oldValue={oldValue} newValue={newValue} are same. just return here");
                    return;
                }

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

                Interop.View.InternalRetrievingVisualPropertyString(view.SwigCPtr, Property.BACKGROUND, ImageVisualProperty.URL, out backgroundImage);

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

                    // Background extra data is not valid anymore. We should ignore lazy UpdateBackgroundExtraData
                    view.backgroundExtraDataUpdatedFlag = BackgroundExtraDataUpdatedFlag.None;
                    if (view.backgroundExtraDataUpdateProcessAttachedFlag)
                    {
                        ProcessorController.Instance.ProcessorOnceEvent -= view.UpdateBackgroundExtraData;
                        view.backgroundExtraDataUpdateProcessAttachedFlag = false;
                    }

                    propertyValue.Dispose();
                    propertyValue = null;
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var view = (View)bindable;

                // Sync as current properties
                view.UpdateBackgroundExtraData();

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
                Object.InternalSetPropertyInt(view.SwigCPtr, View.Property.STATE, (int)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            int temp = 0;
            temp = Object.InternalGetPropertyInt(view.SwigCPtr, View.Property.STATE);
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
                Object.InternalSetPropertyString(view.SwigCPtr, View.Property.SubState, valueToString);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            string temp;
            temp = Object.InternalGetPropertyString(view.SwigCPtr, View.Property.SubState);
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
                Object.InternalSetPropertyFloat(view.SwigCPtr, FlexContainer.ChildProperty.FLEX, (float)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyFloat(view.SwigCPtr, FlexContainer.ChildProperty.FLEX);
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
                Object.InternalSetPropertyInt(view.SwigCPtr, FlexContainer.ChildProperty.AlignSelf, (int)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyInt(view.SwigCPtr, FlexContainer.ChildProperty.AlignSelf);
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
                Object.InternalSetPropertyVector4(view.SwigCPtr, FlexContainer.ChildProperty.FlexMargin, ((Vector4)newValue).SwigCPtr);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Object.InternalRetrievingPropertyVector4(view.SwigCPtr, FlexContainer.ChildProperty.FlexMargin, temp.SwigCPtr);
            return temp;
        }));

        // CellIndexProperty
        internal static void SetInternalCellIndexProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyVector2(view.SwigCPtr, TableView.ChildProperty.CellIndex, ((Vector2)newValue).SwigCPtr);
            }

        }

        internal static object GetInternalCellIndexProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.internalCellIndex == null)
            {
                view.internalCellIndex = new Vector2(view.OnCellIndexChanged, 0, 0);
            }
            Object.InternalRetrievingPropertyVector2(view.SwigCPtr, TableView.ChildProperty.CellIndex, view.internalCellIndex.SwigCPtr);
            return view.internalCellIndex;

        }

        /// <summary>
        /// CellIndexProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetCellIndexProperty()
        {
            if (CellIndexProperty == null)
            {
                CellIndexProperty = BindableProperty.Create(nameof(CellIndex), typeof(Vector2), typeof(View), null,
                    propertyChanged: SetInternalCellIndexProperty, defaultValueCreator: GetInternalCellIndexProperty);
            }
            return CellIndexProperty;
        }

        public static BindableProperty CellIndexProperty = null;
#else
        public static readonly BindableProperty CellIndexProperty = null;
#endif

        /// <summary>
        /// RowSpanProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RowSpanProperty = BindableProperty.Create(nameof(RowSpan), typeof(float), typeof(View), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyFloat(view.SwigCPtr, TableView.ChildProperty.RowSpan, (float)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyFloat(view.SwigCPtr, TableView.ChildProperty.RowSpan);
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
                Object.InternalSetPropertyFloat(view.SwigCPtr, TableView.ChildProperty.ColumnSpan, (float)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyFloat(view.SwigCPtr, TableView.ChildProperty.ColumnSpan);
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
                Object.InternalSetPropertyString(view.SwigCPtr, TableView.ChildProperty.CellHorizontalAlignment, valueToString);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            string temp;
            temp = Object.InternalGetPropertyString(view.SwigCPtr, TableView.ChildProperty.CellHorizontalAlignment);
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
                Object.InternalSetPropertyString(view.SwigCPtr, TableView.ChildProperty.CellVerticalAlignment, valueToString);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            string temp;
            temp = Object.InternalGetPropertyString(view.SwigCPtr, TableView.ChildProperty.CellVerticalAlignment);
            return temp.GetValueByDescription<VerticalAlignmentType>();
        }));

        /// <summary>
        /// "DO not use this, that will be deprecated. Use 'View Weight' instead of BindableProperty"
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
        /// ClockwiseFocusableViewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ClockwiseFocusableViewProperty = BindableProperty.Create(nameof(View.ClockwiseFocusableView), typeof(View), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null && (newValue is View)) { view.ClockwiseFocusableViewId = (int)(newValue as View)?.GetId(); }
            else { view.ClockwiseFocusableViewId = -1; }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            if (view.ClockwiseFocusableViewId >= 0) { return view.ConvertIdToView((uint)view.ClockwiseFocusableViewId); }
            return null;
        });

        /// <summary>
        /// CounterClockwiseFocusableViewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CounterClockwiseFocusableViewProperty = BindableProperty.Create(nameof(View.CounterClockwiseFocusableView), typeof(View), typeof(View), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null && (newValue is View)) { view.CounterClockwiseFocusableViewId = (int)(newValue as View)?.GetId(); }
            else { view.CounterClockwiseFocusableViewId = -1; }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;
            if (view.CounterClockwiseFocusableViewId >= 0) { return view.ConvertIdToView((uint)view.CounterClockwiseFocusableViewId); }
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

        //Size2DProperty
        internal static void SetInternalSize2DProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                // Size property setter is only used by user.
                // Framework code uses SetSize() instead of Size property setter.
                // Size set by user is returned by GetUserSize2D() for SuggestedMinimumWidth/Height.
                // SuggestedMinimumWidth/Height is used by Layout calculation.
                int width = ((Size2D)newValue).Width;
                int height = ((Size2D)newValue).Height;
                view.userSizeWidth = (float)width;
                view.userSizeHeight = (float)height;

                bool relayoutRequired = false;
                // To avoid duplicated size setup, change internal policy directly.
                if (view.widthPolicy != width)
                {
                    view.widthPolicy = width;
                    relayoutRequired = true;
                }
                if (view.heightPolicy != height)
                {
                    view.heightPolicy = height;
                    relayoutRequired = true;
                }
                if (relayoutRequired)
                {
                    view.layout?.RequestLayout();
                }

                Object.InternalSetPropertyVector2ActualVector3(view.SwigCPtr, View.Property.SIZE, ((Size2D)newValue).SwigCPtr);
            }
        }

        internal static object GetInternalSize2DProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.internalSize2D == null)
            {
                view.internalSize2D = new Size2D(view.OnSize2DChanged, 0, 0);
            }
            Object.InternalRetrievingPropertyVector2ActualVector3(view.SwigCPtr, View.Property.SIZE, view.internalSize2D.SwigCPtr);

            return view.internalSize2D;
        }

        /// <summary>
        /// Size2DProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetSize2DProperty()
        {
            if (Size2DProperty == null)
            {
                Size2DProperty = BindableProperty.Create(nameof(Size2D), typeof(Size2D), typeof(View), null,
                    propertyChanged: SetInternalSize2DProperty, defaultValueCreator: GetInternalSize2DProperty);
            }
            return Size2DProperty;
        }

        public static BindableProperty Size2DProperty = null;
#else
        public static readonly BindableProperty Size2DProperty = null;
#endif

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
            return Object.InternalGetPropertyFloat(view.SwigCPtr, View.Property.OPACITY);
        }));

        // Position2DProperty
        internal static void SetInternalPosition2DProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyVector2ActualVector3(view.SwigCPtr, View.Property.POSITION, ((Position2D)newValue).SwigCPtr);
            }
        }

        internal static object GetInternalPosition2DProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.internalPosition2D == null)
            {
                view.internalPosition2D = new Position2D(view.OnPosition2DChanged, 0, 0);
            }
            Object.InternalRetrievingPropertyVector2ActualVector3(view.SwigCPtr, View.Property.POSITION, view.internalPosition2D.SwigCPtr);
            return view.internalPosition2D;
        }

        /// <summary>
        /// Position2DProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetPosition2DProperty()
        {
            if (Position2DProperty == null)
            {
                Position2DProperty = BindableProperty.Create(nameof(Position2D), typeof(Position2D), typeof(View), null,
                    propertyChanged: SetInternalPosition2DProperty, defaultValueCreator: GetInternalPosition2DProperty);
            }
            return Position2DProperty;
        }

        public static BindableProperty Position2DProperty = null;
#else
        public static readonly BindableProperty Position2DProperty = null;
#endif

        /// <summary>
        /// PositionUsesPivotPointProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PositionUsesPivotPointProperty = BindableProperty.Create(nameof(PositionUsesPivotPoint), typeof(bool), typeof(View), true, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.PositionUsesAnchorPoint, (bool)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.PositionUsesAnchorPoint);
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

        // ParentOriginProperty
        internal static void SetInternalParentOriginProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyVector3(view.SwigCPtr, View.Property.ParentOrigin, ((Position)newValue).SwigCPtr);
            }
        }

        internal static object GetInternalParentOriginProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            Position temp = new Position(0.0f, 0.0f, 0.0f);
            Object.InternalRetrievingPropertyVector3(view.SwigCPtr, View.Property.ParentOrigin, temp.SwigCPtr);
            return temp;
        }

        /// <summary>
        /// ParentOriginProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetParentOriginProperty()
        {
            if (ParentOriginProperty == null)
            {
                ParentOriginProperty = BindableProperty.Create(nameof(ParentOrigin), typeof(Position), typeof(View), null,
                    propertyChanged: SetInternalParentOriginProperty, defaultValueCreator: GetInternalParentOriginProperty);
            }
            return ParentOriginProperty;
        }

        public static BindableProperty ParentOriginProperty = null;
#else
        public static readonly BindableProperty ParentOriginProperty = null;
#endif

        // PivotPointProperty
        internal static void SetInternalPivotPointProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetAnchorPoint((Position)newValue);
            }
        }

        internal static object GetInternalPivotPointProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.internalPivotPoint == null)
            {
                view.internalPivotPoint = new Position(view.OnPivotPointChanged, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector3(view.SwigCPtr, View.Property.AnchorPoint, view.internalPivotPoint.SwigCPtr);
            return view.internalPivotPoint;
        }

        /// <summary>
        /// PivotPointProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetPivotPointProperty()
        {
            if (PivotPointProperty == null)
            {
                PivotPointProperty = BindableProperty.Create(nameof(PivotPoint), typeof(Position), typeof(View), null,
                    propertyChanged: SetInternalPivotPointProperty, defaultValueCreator: GetInternalPivotPointProperty);
            }
            return PivotPointProperty;
        }

        public static BindableProperty PivotPointProperty = null;
#else
        public static readonly BindableProperty PivotPointProperty = null;
#endif
        
        // SizeWidthProperty
        internal static void SetInternalSizeWidthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                // Size property setter is only used by user.
                // Framework code uses SetSize() instead of Size property setter.
                // Size set by user is returned by GetUserSize2D() for SuggestedMinimumWidth/Height.
                // SuggestedMinimumWidth/Height is used by Layout calculation.
                float width = (float)newValue;
                view.userSizeWidth = width;

                // To avoid duplicated size setup, change internal policy directly.
                int widthPolicy = (int)System.Math.Ceiling(width);
                if (view.widthPolicy != widthPolicy)
                {
                    view.widthPolicy = widthPolicy;
                    view.layout?.RequestLayout();
                }

                Object.InternalSetPropertyFloat(view.SwigCPtr, View.Property.SizeWidth, width);
            }
        }

        internal static object GetInternalSizeWidthProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyFloat(view.SwigCPtr, View.Property.SizeWidth);
        }

        /// <summary>
        /// SizeWidthProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetSizeWidthProperty()
        {
            if (SizeWidthProperty == null)
            {
                SizeWidthProperty = BindableProperty.Create(nameof(SizeWidth), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalSizeWidthProperty, defaultValueCreator: GetInternalSizeWidthProperty);
            }
            return SizeWidthProperty;
        }

        public static BindableProperty SizeWidthProperty = null;
#else
        public static readonly BindableProperty SizeWidthProperty = null;
#endif        

        // SizeHeightProperty
        internal static void SetInternalSizeHeightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                // Size property setter is only used by user.
                // Framework code uses SetSize() instead of Size property setter.
                // Size set by user is returned by GetUserSize2D() for SuggestedMinimumWidth/Height.
                // SuggestedMinimumWidth/Height is used by Layout calculation.
                float height = (float)newValue;
                view.userSizeHeight = height;

                // To avoid duplicated size setup, change internal policy directly.
                int heightPolicy = (int)System.Math.Ceiling(height);
                if (view.heightPolicy != heightPolicy)
                {
                    view.heightPolicy = heightPolicy;
                    view.layout?.RequestLayout();
                }

                Object.InternalSetPropertyFloat(view.SwigCPtr, View.Property.SizeHeight, height);
            }
        }

        internal static object GetInternalSizeHeightProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyFloat(view.SwigCPtr, View.Property.SizeHeight);
        }

        /// <summary>
        /// SizeHeightProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetSizeHeightProperty()
        {
            if (SizeHeightProperty == null)
            {
                SizeHeightProperty = BindableProperty.Create(nameof(SizeHeight), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalSizeHeightProperty, defaultValueCreator: GetInternalSizeHeightProperty);
            }
            return SizeHeightProperty;
        }

        public static BindableProperty SizeHeightProperty = null;
#else
        public static readonly BindableProperty SizeHeightProperty = null;
#endif

        // PositionProperty
        internal static void SetInternalPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyVector3(view.SwigCPtr, View.Property.POSITION, ((Position)newValue).SwigCPtr);
            }
        }

        internal static object GetInternalPositionProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.internalPosition == null)
            {
                view.internalPosition = new Position(view.OnPositionChanged, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector3(view.SwigCPtr, View.Property.POSITION, view.internalPosition.SwigCPtr);
            return view.internalPosition;
        }

        /// <summary>
        /// PositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetPositionProperty()
        {
            if (PositionProperty == null)
            {
                PositionProperty = BindableProperty.Create(nameof(Position), typeof(Position), typeof(View), null,
                    propertyChanged: SetInternalPositionProperty, defaultValueCreator: GetInternalPositionProperty);
            }
            return PositionProperty;
        }

        public static BindableProperty PositionProperty = null;
#else
        public static readonly BindableProperty PositionProperty = null;
#endif
        
        // PositionXProperty
        internal static void SetInternalPositionXProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyFloat(view.SwigCPtr, View.Property.PositionX, (float)newValue);
            }
        }

        internal static object GetInternalPositionXProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyFloat(view.SwigCPtr, View.Property.PositionX);
        }

        /// <summary>
        /// PositionXProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetPositionXProperty()
        {
            if (PositionXProperty == null)
            {
                PositionXProperty = BindableProperty.Create(nameof(PositionX), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalPositionXProperty, defaultValueCreator: GetInternalPositionXProperty);
            }
            return PositionXProperty;
        }

        public static BindableProperty PositionXProperty = null;
#else
        public static readonly BindableProperty PositionXProperty = null;
#endif

        // PositionYProperty
        internal static void SetInternalPositionYProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyFloat(view.SwigCPtr, View.Property.PositionY, (float)newValue);
            }
        }

        internal static object GetInternalPositionYProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyFloat(view.SwigCPtr, View.Property.PositionY);
        }

        /// <summary>
        /// PositionYProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetPositionYProperty()
        {
            if (PositionYProperty == null)
            {
                PositionYProperty = BindableProperty.Create(nameof(PositionY), typeof(float), typeof(View), default(float),
                propertyChanged: SetInternalPositionYProperty, defaultValueCreator: GetInternalPositionYProperty);
            }
            return PositionYProperty;
        }

        public static BindableProperty PositionYProperty = null;
#else
        public static readonly BindableProperty PositionYProperty = null;
#endif
        internal static void SetInternalPositionZProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyFloat(view.SwigCPtr, View.Property.PositionZ, (float)newValue);
            }

        }

        // PositionZProperty
        internal static object GetInternalPositionZProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyFloat(view.SwigCPtr, View.Property.PositionZ);
        }

        /// <summary>
        /// PositionZProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetPositionZProperty()
        {
            if (PositionZProperty == null)
            {
                PositionZProperty = BindableProperty.Create(nameof(PositionZ), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalPositionZProperty, defaultValueCreator: GetInternalPositionZProperty);
            }
            return PositionZProperty;
        }

        public static BindableProperty PositionZProperty = null;
#else
        public static readonly BindableProperty PositionZProperty = null;
#endif
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

        internal static void SetInternalScaleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetScale((Vector3)newValue);
            }

        }

        // ScaleProperty
        internal static object GetInternalScaleProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.internalScale == null)
            {
                view.internalScale = new Vector3(view.OnScaleChanged, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector3(view.SwigCPtr, View.Property.SCALE, view.internalScale.SwigCPtr);
            return view.internalScale;
        }

        /// <summary>
        /// ScaleProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetScaleProperty()
        {
            if (ScaleProperty == null)
            {
                ScaleProperty = BindableProperty.Create(nameof(Scale), typeof(Vector3), typeof(View), null,
                    propertyChanged: SetInternalScaleProperty, defaultValueCreator: GetInternalScaleProperty);
            }
            return ScaleProperty;
        }

        public static BindableProperty ScaleProperty = null;
#else
        public static readonly BindableProperty ScaleProperty = null;
#endif

        // ScaleXProperty
        internal static void SetInternalScaleXProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyFloat(view.SwigCPtr, View.Property.ScaleX, (float)newValue);
            }
        }

        internal static object GetInternalScaleXProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyFloat(view.SwigCPtr, View.Property.ScaleX);
        }

        /// <summary>
        /// ScaleXProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetScaleXProperty()
        {
            if (ScaleXProperty == null)
            {
                ScaleXProperty = BindableProperty.Create(nameof(ScaleX), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalScaleXProperty, defaultValueCreator: GetInternalScaleXProperty);
            }
            return ScaleXProperty;
        }

        public static BindableProperty ScaleXProperty = null;
#else
        public static readonly BindableProperty ScaleXProperty = null;
#endif

        // ScaleYProperty
        internal static void SetInternalScaleYProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyFloat(view.SwigCPtr, View.Property.ScaleY, (float)newValue);
            }
        }

        internal static object GetInternalScaleYProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyFloat(view.SwigCPtr, View.Property.ScaleY);
        }

        /// <summary>
        /// ScaleYProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetScaleYProperty()
        {
            if (ScaleYProperty == null)
            {
                ScaleYProperty = BindableProperty.Create(nameof(ScaleY), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalScaleYProperty, defaultValueCreator: GetInternalScaleYProperty);
            }
            return ScaleYProperty;
        }

        public static BindableProperty ScaleYProperty = null;
#else
        public static readonly BindableProperty ScaleYProperty = null;
#endif

        // ScaleZProperty
        internal static void SetInternalScaleZProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyFloat(view.SwigCPtr, View.Property.ScaleZ, (float)newValue);
            }
        }

        internal static object GetInternalScaleZProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyFloat(view.SwigCPtr, View.Property.ScaleZ);
        }

        /// <summary>
        /// ScaleZProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetScaleZProperty()
        {
            if (ScaleZProperty == null)
            {
                ScaleZProperty = BindableProperty.Create(nameof(ScaleZ), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalScaleZProperty, defaultValueCreator: GetInternalScaleZProperty);
            }
            return ScaleZProperty;
        }

        public static BindableProperty ScaleZProperty = null;
#else
        public static readonly BindableProperty ScaleZProperty = null;
#endif
        
        // NameProperty
        internal static void SetInternalNameProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.internalName = (string)newValue;
                Object.InternalSetPropertyString(view.SwigCPtr, View.Property.NAME, (string)newValue);
            }
        }

        internal static object GetInternalNameProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.internalName;
        }

        /// <summary>
        /// NameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetNameProperty()
        {
            if (NameProperty == null)
            {
                NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(View), string.Empty,
                    propertyChanged: SetInternalNameProperty, defaultValueCreator: GetInternalNameProperty);
            }
            return NameProperty;
        }

        public static BindableProperty NameProperty = null;
#else
        public static readonly BindableProperty NameProperty = null;
#endif
        /// <summary>
        /// SensitiveProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SensitiveProperty = BindableProperty.Create(nameof(Sensitive), typeof(bool), typeof(View), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.SENSITIVE, (bool)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.SENSITIVE);
        }));

        /// <summary>
        /// IsEnabledProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(View), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.UserInteractionEnabled, (bool)newValue);
                view.OnEnabled((bool)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.UserInteractionEnabled);
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
                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.DispatchKeyEvents, (bool)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.DispatchKeyEvents);
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
                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.LeaveRequired, (bool)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.LeaveRequired);
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
                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.InheritOrientation, (bool)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.InheritOrientation);
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
                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.InheritScale, (bool)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.InheritScale);
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
                Object.InternalSetPropertyInt(view.SwigCPtr, View.Property.DrawMode, (int)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            return (DrawModeType)Object.InternalGetPropertyInt(view.SwigCPtr, View.Property.DrawMode);
        }));

        internal static void SetInternalSizeModeFactorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyVector3(view.SwigCPtr, View.Property.SizeModeFactor, ((Vector3)newValue).SwigCPtr);
            }

        }

        // SizeModeFactorProperty
        internal static object GetInternalSizeModeFactorProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.internalSizeModeFactor == null)
            {
                view.internalSizeModeFactor = new Vector3(view.OnSizeModeFactorChanged, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector3(view.SwigCPtr, View.Property.SizeModeFactor, view.internalSizeModeFactor.SwigCPtr);
            return view.internalSizeModeFactor;
        }

        /// <summary>
        /// SizeModeFactorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetSizeModeFactorProperty()
        {
            if (SizeModeFactorProperty == null)
            {
                SizeModeFactorProperty = BindableProperty.Create(nameof(SizeModeFactor), typeof(Vector3), typeof(View), null,
                    propertyChanged: SetInternalSizeModeFactorProperty, defaultValueCreator: GetInternalSizeModeFactorProperty);
            }
            return SizeModeFactorProperty;
        }

        public static BindableProperty SizeModeFactorProperty = null;
#else
        public static readonly BindableProperty SizeModeFactorProperty = null;
#endif
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
                    Object.InternalSetPropertyInt(view.SwigCPtr, View.Property.WidthResizePolicy, (int)ResizePolicyType.FillToParent);
                }
                else
                {
                    view.widthConstraint?.Remove();
                    view.widthConstraint?.Dispose();
                    view.widthConstraint = null;

                    Object.InternalSetPropertyInt(view.SwigCPtr, View.Property.WidthResizePolicy, (int)newValue);
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

            temp = Object.InternalGetPropertyString(view.SwigCPtr, View.Property.WidthResizePolicy);
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

                    Object.InternalSetPropertyInt(view.SwigCPtr, View.Property.HeightResizePolicy, (int)ResizePolicyType.FillToParent);
                }
                else
                {
                    view.heightConstraint?.Remove();
                    view.heightConstraint?.Dispose();
                    view.heightConstraint = null;

                    Object.InternalSetPropertyInt(view.SwigCPtr, View.Property.HeightResizePolicy, (int)newValue);
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

            temp = Object.InternalGetPropertyString(view.SwigCPtr, View.Property.HeightResizePolicy);
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

                Object.InternalSetPropertyString(view.SwigCPtr, View.Property.SizeScalePolicy, valueToString);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;

            return (SizeScalePolicyType)Object.InternalGetPropertyInt(view.SwigCPtr, View.Property.SizeScalePolicy);
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
                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.WidthForHeight, (bool)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;

            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.WidthForHeight);
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

                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.HeightForWidth, (bool)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;

            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.HeightForWidth);
        }));

        // PaddingProperty
        internal static void SetInternalPaddingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                if (view.Layout != null)
                {
                    view.Layout.Padding = new Extents((Extents)newValue);
                    if ((view.Padding.Start != 0) || (view.Padding.End != 0) || (view.Padding.Top != 0) || (view.Padding.Bottom != 0))
                    {
                        var tmp = new PropertyValue(new Extents(0, 0, 0, 0));
                        Object.SetProperty(view.SwigCPtr, Property.PADDING, tmp);
                        tmp?.Dispose();
                    }
                    view.Layout.RequestLayout();
                }
                else
                {
                    var tmp = new PropertyValue((Extents)newValue);
                    Object.SetProperty(view.SwigCPtr, Property.PADDING, tmp);
                    tmp?.Dispose();
                }
            }
        }

        internal static object GetInternalPaddingProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if ((view.internalPadding == null) || (view.Layout != null))
            {
                ushort start = 0, end = 0, top = 0, bottom = 0;
                if (view.Layout != null)
                {
                    if (view.Layout.Padding != null)
                    {
                        start = view.Layout.Padding.Start;
                        end = view.Layout.Padding.End;
                        top = view.Layout.Padding.Top;
                        bottom = view.Layout.Padding.Bottom;
                    }
                }
                view.internalPadding = new Extents(view.OnPaddingChanged, start, end, top, bottom);
            }

            if (view.Layout == null)
            {
                var tmp = Object.GetProperty(view.SwigCPtr, Property.PADDING);
                tmp?.Get(view.internalPadding);
                tmp?.Dispose();
            }

            return view.internalPadding;
        }

        /// <summary>
        /// PaddingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetPaddingProperty()
        {
            if (PaddingProperty == null)
            {
                PaddingProperty = BindableProperty.Create(nameof(Padding), typeof(Extents), typeof(View), null,
                    propertyChanged: SetInternalPaddingProperty, defaultValueCreator: GetInternalPaddingProperty);
            }
            return PaddingProperty;
        }

        public static BindableProperty PaddingProperty = null;
#else
        public static readonly BindableProperty PaddingProperty = null;
#endif

        // SizeProperty
        internal static void SetInternalSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                // Size property setter is only used by user.
                // Framework code uses SetSize() instead of Size property setter.
                // Size set by user is returned by GetUserSize2D() for SuggestedMinimumWidth/Height.
                // SuggestedMinimumWidth/Height is used by Layout calculation.
                float width = ((Size)newValue).Width;
                float height = ((Size)newValue).Height;
                float depth = ((Size)newValue).Depth;

                view.userSizeWidth = width;
                view.userSizeHeight = height;

                // Set Specification so when layouts measure this View it matches the value set here.
                // All Views are currently Layouts.
                int widthPolicy = (int)System.Math.Ceiling(width);
                int heightPolicy = (int)System.Math.Ceiling(height);

                bool relayoutRequired = false;
                // To avoid duplicated size setup, change internal policy directly.
                if (view.widthPolicy != widthPolicy)
                {
                    view.widthPolicy = widthPolicy;
                    relayoutRequired = true;
                }
                if (view.heightPolicy != heightPolicy)
                {
                    view.heightPolicy = heightPolicy;
                    relayoutRequired = true;
                }
                if (relayoutRequired)
                {
                    view.layout?.RequestLayout();
                }

                view.SetSize(width, height, depth);
            }
        }

        internal static object GetInternalSizeProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            if (view.internalSize == null)
            {
                view.internalSize = new Size(view.OnSizeChanged, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector3(view.SwigCPtr, View.Property.SIZE, view.internalSize.SwigCPtr);

            return view.internalSize;
        }

        /// <summary>
        /// SizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetSizeProperty()
        {
            if (SizeProperty == null)
            {
                SizeProperty = BindableProperty.Create(nameof(Size), typeof(Size), typeof(View), null,
                    propertyChanged: SetInternalSizeProperty, defaultValueCreator: GetInternalSizeProperty);
            }
            return SizeProperty;
        }

        public static BindableProperty SizeProperty = null;
#else
        public static readonly BindableProperty SizeProperty = null;
#endif

        // MinimumSizeProperty
        internal static void SetInternalMinimumSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector2(view.SwigCPtr, View.Property.MinimumSize, ((Size2D)newValue).SwigCPtr);
            }
        }

        internal static object GetInternalMinimumSizeProperty(BindableObject bindable)
        {

            var view = (View)bindable;
            if (view.internalMinimumSize == null)
            {
                view.internalMinimumSize = new Size2D(view.OnMinimumSizeChanged, 0, 0);
            }
            Object.InternalRetrievingPropertyVector2(view.SwigCPtr, View.Property.MinimumSize, view.internalMinimumSize.SwigCPtr);
            return view.internalMinimumSize;
        }

        /// <summary>
        /// MinimumSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetMinimumSizeProperty()
        {
            if (MinimumSizeProperty == null)
            {
                MinimumSizeProperty = BindableProperty.Create(nameof(MinimumSize), typeof(Size2D), typeof(View), null,
                    propertyChanged: SetInternalMinimumSizeProperty, defaultValueCreator: GetInternalMinimumSizeProperty);
            }
            return MinimumSizeProperty;
        }

        public static BindableProperty MinimumSizeProperty = null;
#else
        public static readonly BindableProperty MinimumSizeProperty = null;
#endif

        // MaximumSizeProperty
        internal static void SetInternalMaximumSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector2(view.SwigCPtr, View.Property.MaximumSize, ((Size2D)newValue).SwigCPtr);
            }
        }

        internal static object GetInternalMaximumSizeProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            if (view.internalMaximumSize == null)
            {
                view.internalMaximumSize = new Size2D(view.OnMaximumSizeChanged, 0, 0);
            }
            Object.InternalRetrievingPropertyVector2(view.SwigCPtr, View.Property.MaximumSize, view.internalMaximumSize.SwigCPtr);
            return view.internalMaximumSize;
        }

        /// <summary>
        /// MaximumSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetMaximumSizeProperty()
        {
            if (MaximumSizeProperty == null)
            {
                MaximumSizeProperty = BindableProperty.Create(nameof(MaximumSize), typeof(Size2D), typeof(View), null,
                    propertyChanged: SetInternalMaximumSizeProperty, defaultValueCreator: GetInternalMaximumSizeProperty);
            }
            return MaximumSizeProperty;
        }

        public static BindableProperty MaximumSizeProperty = null;
#else
        public static readonly BindableProperty MaximumSizeProperty = null;
#endif

        /// <summary>
        /// InheritPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InheritPositionProperty = BindableProperty.Create(nameof(InheritPosition), typeof(bool), typeof(View), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.InheritPosition, (bool)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;

            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.InheritPosition);
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

                Object.InternalSetPropertyInt(view.SwigCPtr, View.Property.ClippingMode, (int)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;

            return (ClippingModeType)Object.InternalGetPropertyInt(view.SwigCPtr, View.Property.ClippingMode);
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

                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.InheritLayoutDirection, (bool)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;

            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.InheritLayoutDirection);
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

                Object.InternalSetPropertyInt(view.SwigCPtr, View.Property.LayoutDirection, (int)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;

            return (ViewLayoutDirectionType)Object.InternalGetPropertyInt(view.SwigCPtr, View.Property.LayoutDirection);
        }));

        // MarginProperty
        internal static void SetInternalMarginProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                if (view.Layout != null)
                {
                    view.Layout.Margin = new Extents((Extents)newValue);
                    if ((view.Margin.Start != 0) || (view.Margin.End != 0) || (view.Margin.Top != 0) || (view.Margin.Bottom != 0))
                    {
                        var tmp = new PropertyValue(new Extents(0, 0, 0, 0));
                        Object.SetProperty(view.SwigCPtr, Property.MARGIN, tmp);
                        tmp?.Dispose();
                    }
                    view.Layout.RequestLayout();
                }
                else
                {
                    var tmp = new PropertyValue((Extents)newValue);
                    Object.SetProperty(view.SwigCPtr, Property.MARGIN, tmp);
                    tmp?.Dispose();
                }
            }
        }

        internal static object GetInternalMarginProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if ((view.internalMargin == null) || (view.Layout != null))
            {
                ushort start = 0, end = 0, top = 0, bottom = 0;
                if (view.Layout != null)
                {
                    if (view.Layout.Margin != null)
                    {
                        start = view.Layout.Margin.Start;
                        end = view.Layout.Margin.End;
                        top = view.Layout.Margin.Top;
                        bottom = view.Layout.Margin.Bottom;
                    }
                }
                view.internalMargin = new Extents(view.OnMarginChanged, start, end, top, bottom);
            }

            if (view.Layout == null)
            {

                var tmp = Object.GetProperty(view.SwigCPtr, Property.MARGIN);
                tmp?.Get(view.internalMargin);
                tmp?.Dispose();
            }

            return view.internalMargin;
        }

        /// <summary>
        /// MarginProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetMarginProperty()
        {
            if (MarginProperty == null)
            {
                MarginProperty = BindableProperty.Create(nameof(Margin), typeof(Extents), typeof(View), null,
                    propertyChanged: SetInternalMarginProperty, defaultValueCreator: GetInternalMarginProperty);
            }
            return MarginProperty;
        }

        public static BindableProperty MarginProperty = null;
#else
        public static readonly BindableProperty MarginProperty = null;
#endif

        /// <summary>
        /// UpdateAreaHintProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UpdateAreaHintProperty = BindableProperty.Create(nameof(UpdateAreaHint), typeof(Vector4), typeof(View), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector4(view.SwigCPtr, Interop.ActorProperty.UpdateAreaHintGet(), ((Vector4)newValue).SwigCPtr);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var view = (View)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);

            Object.InternalRetrievingPropertyVector4(view.SwigCPtr, Interop.ActorProperty.UpdateAreaHintGet(), temp.SwigCPtr);
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

            // Sync as current properties
            view.UpdateBackgroundExtraData();
#if OBJECT_POOL
            using PropertyMap map = ObjectPool.NewPropertyMap();
#else
            PropertyMap map = new PropertyMap();
#endif
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

            // Sync as current properties
            view.UpdateBackgroundExtraData();
#if OBJECT_POOL
            using PropertyMap map = ObjectPool.NewPropertyMap();
#else
            PropertyMap map = new PropertyMap();
#endif
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
            view.UpdateBackgroundExtraData(BackgroundExtraDataUpdatedFlag.CornerRadius);
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
                view.UpdateBackgroundExtraData(BackgroundExtraDataUpdatedFlag.CornerRadius);
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
            view.UpdateBackgroundExtraData(BackgroundExtraDataUpdatedFlag.Borderline);
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
        public static readonly BindableProperty BorderlineColorProperty = BindableProperty.Create(nameof(BorderlineColor), typeof(Color), typeof(View), null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = (View)bindable;

                view.themeData?.selectorData?.BorderlineColor?.Reset(view);

                if (newValue is Selector<Color> selector)
                {
                    if (selector.HasAll()) view.SetBorderlineColor(selector.All);
                    else view.EnsureSelectorData().BorderlineColor = new TriggerableSelector<Color>(view, selector, view.SetBorderlineColor, true);
                }
                else
                {
                    view.SetBorderlineColor((Color)newValue);
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var view = (View)bindable;
                return view.backgroundExtraData == null ? Color.Black : view.backgroundExtraData.BorderlineColor;
            }
        );

        /// <summary>
        /// BorderlineColorSelector Property
        /// Like BackgroundColor, color selector typed BorderlineColor should be used in ViewStyle only.
        /// So this API is internally used only.
        /// </summary>
        internal static readonly BindableProperty BorderlineColorSelectorProperty = BindableProperty.Create(nameof(BorderlineColorSelector), typeof(Selector<Color>), typeof(View), null,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = (View)bindable;

                view.themeData?.selectorData?.BorderlineColor?.Reset(view);

                if (newValue is Selector<Color> selector)
                {
                    if (selector.HasAll()) view.SetBorderlineColor(selector.All);
                    else view.EnsureSelectorData().BorderlineColor = new TriggerableSelector<Color>(view, selector, view.SetBorderlineColor, true);
                }
                else
                {
                    view.SetBorderlineColor((Color)newValue);
                }
            },
            defaultValueCreator: (bindable) =>
            {
                var view = (View)bindable;
                var selector = view.themeData?.selectorData?.BorderlineColor?.Get();
                return (null != selector) ? selector : new Selector<Color>();
            }
        );

        /// <summary>
        /// BorderlineOffset Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BorderlineOffsetProperty = BindableProperty.Create(nameof(BorderlineOffset), typeof(float), typeof(View), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = (View)bindable;
            (view.backgroundExtraData ?? (view.backgroundExtraData = new BackgroundExtraData())).BorderlineOffset = (float)newValue;
            view.UpdateBackgroundExtraData(BackgroundExtraDataUpdatedFlag.Borderline);
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

                Object.InternalSetPropertyString(view.SwigCPtr, View.Property.AccessibilityName, (string)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;

            return Object.InternalGetPropertyString(view.SwigCPtr, View.Property.AccessibilityName);
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

                Object.InternalSetPropertyString(view.SwigCPtr, View.Property.AccessibilityDescription, (string)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;

            return Object.InternalGetPropertyString(view.SwigCPtr, View.Property.AccessibilityDescription);
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

                Object.InternalSetPropertyString(view.SwigCPtr, View.Property.AccessibilityTranslationDomain, (string)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;

            return Object.InternalGetPropertyString(view.SwigCPtr, View.Property.AccessibilityTranslationDomain);
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

                Object.InternalSetPropertyInt(view.SwigCPtr, View.Property.AccessibilityRole, (int)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;

            return (Role)Object.InternalGetPropertyInt(view.SwigCPtr, View.Property.AccessibilityRole);
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

                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.AccessibilityHighlightable, (bool)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;

            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.AccessibilityHighlightable);
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

                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.AccessibilityHidden, (bool)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var view = (View)bindable;

            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.AccessibilityHidden);
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

        // AnchorPointProperty
        internal static void SetInternalAnchorPointProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalAnchorPoint = (Tizen.NUI.Position)newValue;
            }
        }

        internal static object GetInternalAnchorPointProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalAnchorPoint;
        }

        /// <summary>
        /// AnchorPointProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY
        internal static BindableProperty GetAnchorPointProperty()
        {
            if (AnchorPointProperty == null)
            {
                AnchorPointProperty = BindableProperty.Create(nameof(AnchorPoint), typeof(Tizen.NUI.Position), typeof(View), null,
                    propertyChanged: SetInternalAnchorPointProperty, defaultValueCreator: GetInternalAnchorPointProperty);
            }
            return AnchorPointProperty;
        }

        public static BindableProperty AnchorPointProperty = null;
#else
        public static readonly BindableProperty AnchorPointProperty = null;
#endif

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
        /// PropagatableControlStatesProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PropagatableControlStatesProperty = BindableProperty.Create(nameof(PropagatableControlStates), typeof(ControlState), typeof(View), ControlState.All, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalPropagatableControlStates = (ControlState)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalPropagatableControlStates;
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
        /// AllowOnlyOwnTouchProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AllowOnlyOwnTouchProperty = BindableProperty.Create(nameof(AllowOnlyOwnTouch), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalAllowOnlyOwnTouch = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalAllowOnlyOwnTouch;
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

                Object.InternalSetPropertyString(instance.SwigCPtr, View.Property.AutomationId, (string)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;

            return Object.InternalGetPropertyString(instance.SwigCPtr, View.Property.AutomationId);
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

        /// <summary>
        /// DispatchTouchMotionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DispatchTouchMotionProperty = BindableProperty.Create(nameof(DispatchTouchMotion), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalDispatchTouchMotion = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalDispatchTouchMotion;
        });

        /// <summary>
        /// DispatchHoverMotionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DispatchHoverMotionProperty = BindableProperty.Create(nameof(DispatchHoverMotion), typeof(bool), typeof(View), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalDispatchHoverMotion = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalDispatchHoverMotion;
        });

        /// <summary>
        /// Gets View's Size2D set by user.
        /// </summary>
        internal Size2D GetUserSize2D()
        {
            return new Size2D((int)userSizeWidth, (int)userSizeHeight);
        }

#if REMOVE_READONLY
        internal static void CreateBindableProperties()
        {
            _ = GetBackgroundColorProperty();
            _ = GetColorProperty();
            _ = GetColorRedProperty();
            _ = GetColorGreenProperty();
            _ = GetColorBlueProperty();
            _ = GetCellIndexProperty();
            _ = GetSize2DProperty();
            _ = GetPosition2DProperty();
            _ = GetParentOriginProperty();
            _ = GetPivotPointProperty();
            _ = GetSizeWidthProperty();
            _ = GetSizeHeightProperty();
            _ = GetPositionProperty();
            _ = GetPositionXProperty();
            _ = GetPositionYProperty();
            _ = GetPositionZProperty();
            _ = GetScaleProperty();
            _ = GetScaleXProperty();
            _ = GetScaleYProperty();
            _ = GetScaleZProperty();
            _ = GetNameProperty();
            _ = GetSizeModeFactorProperty();
            _ = GetPaddingProperty();
            _ = GetSizeProperty();
            _ = GetMinimumSizeProperty();
            _ = GetMaximumSizeProperty();
            _ = GetMarginProperty();
            _ = GetAnchorPointProperty();
        }
#endif

        private void SetBackgroundImage(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                backgroundExtraDataUpdatedFlag &= ~BackgroundExtraDataUpdatedFlag.Background;

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

                Object.InternalSetPropertyString(SwigCPtr, View.Property.BACKGROUND, value);
                BackgroundImageSynchronousLoading = backgroundImageSynchronousLoading;
                return;
            }

#if OBJECT_POOL
            using PropertyMap map = ObjectPool.NewPropertyMap();
#else
            var map = new PropertyMap();
#endif
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

            backgroundExtraDataUpdatedFlag &= ~BackgroundExtraDataUpdatedFlag.Background;

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

            // Background extra data flag is not meanful anymore.
            backgroundExtraDataUpdatedFlag &= ~BackgroundExtraDataUpdatedFlag.Background;

            Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, View.Property.BACKGROUND, new PropertyValue(map));
        }

        private void SetBorderlineColor(Color value)
        {
            if (value == null)
            {
                return;
            }

            (backgroundExtraData ?? (backgroundExtraData = new BackgroundExtraData())).BorderlineColor = value;

            UpdateBackgroundExtraData(BackgroundExtraDataUpdatedFlag.Borderline);
        }

        private void SetBackgroundColor(Color value)
        {
            if (value == null)
            {
                return;
            }

            if (backgroundExtraData == null)
            {

                Object.InternalSetPropertyVector4(SwigCPtr, View.Property.BACKGROUND, ((Color)value).SwigCPtr);
                return;
            }
#if OBJECT_POOL
            using PropertyMap map = ObjectPool.NewPropertyMap();
#else
            var map = new PropertyMap();
#endif
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

            backgroundExtraDataUpdatedFlag &= ~BackgroundExtraDataUpdatedFlag.Background;

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

        private void SetColorRed(float? value)
        {
            if (value == null)
            {
                return;
            }

            Object.InternalSetPropertyFloat(SwigCPtr, View.Property.ColorRed, (float)value);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void SetColorGreen(float? value)
        {
            if (value == null)
            {
                return;
            }

            Object.InternalSetPropertyFloat(SwigCPtr, View.Property.ColorGreen, (float)value);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void SetColorBlue(float? value)
        {
            if (value == null)
            {
                return;
            }

            Object.InternalSetPropertyFloat(SwigCPtr, View.Property.ColorBlue, (float)value);
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void SetOpacity(float? value)
        {
            if (value == null)
            {
                return;
            }

            Object.InternalSetPropertyFloat(SwigCPtr, View.Property.OPACITY, (float)value);
        }

        private void SetShadow(ShadowBase value)
        {
            backgroundExtraDataUpdatedFlag &= ~BackgroundExtraDataUpdatedFlag.Shadow;
            Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, View.Property.SHADOW, value == null ? new PropertyValue() : value.ToPropertyValue(this));
        }
    }
}
