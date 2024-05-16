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
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty StyleNameProperty = null;
#else
        public static readonly BindableProperty StyleNameProperty = null;
#endif
        internal static void SetInternalStyleNameProperty(BindableObject bindable, object oldValue, object newValue)
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
        }
        internal static object GetInternalStyleNameProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            if (!string.IsNullOrEmpty(view.styleName)) return view.styleName;

            return Object.InternalGetPropertyString(view.SwigCPtr, View.Property.StyleName);
        }

        /// <summary>
        /// KeyInputFocusProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty KeyInputFocusProperty = null;
#else
        public static readonly BindableProperty KeyInputFocusProperty = null;
#endif
        internal static void SetInternalKeyInputFocusProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.KeyInputFocus, (bool)newValue);
            }
        }
        internal static object GetInternalKeyInputFocusProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.KeyInputFocus);
        }

        /// <summary>
        /// BackgroundColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty BackgroundColorProperty = null;
#else
        public static readonly BindableProperty BackgroundColorProperty = null;
#endif
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
        /// ColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty ColorProperty = null;
#else
        public static readonly BindableProperty ColorProperty = null;
#endif
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
        /// ColorRedProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty ColorRedProperty = null;
#else
        public static readonly BindableProperty ColorRedProperty = null;
#endif
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
        /// ColorGreenProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty ColorGreenProperty = null;
#else
        public static readonly BindableProperty ColorGreenProperty = null;
#endif
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
        /// ColorBlueProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty ColorBlueProperty = null;
#else
        public static readonly BindableProperty ColorBlueProperty = null;
#endif
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
        /// BackgroundImageProperty 
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty BackgroundImageProperty = null;
#else
        public static readonly BindableProperty BackgroundImageProperty = null;
#endif
        internal static void SetInternalBackgroundImageProperty(BindableObject bindable, object oldValue, object newValue)
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
        }
        internal static object GetInternalBackgroundImageProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            return (string)view.backgroundImageUrl;
        }


        /// <summary>
        /// BackgroundImageBorderProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty BackgroundImageBorderProperty = null;
#else
        public static readonly BindableProperty BackgroundImageBorderProperty = null;
#endif
        internal static void SetInternalBackgroundImageBorderProperty(BindableObject bindable, object oldValue, object newValue)
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
        }
        internal static object GetInternalBackgroundImageBorderProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            return view.backgroundExtraData?.BackgroundImageBorder;
        }

        /// <summary>
        /// BackgroundProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty BackgroundProperty = null;
#else
        public static readonly BindableProperty BackgroundProperty = null;
#endif
        internal static void SetInternalBackgroundProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                PropertyMap map = (PropertyMap)newValue;

                // Background extra data is not valid anymore. We should ignore lazy UpdateBackgroundExtraData
                view.backgroundExtraData = null;
                view.backgroundExtraDataUpdatedFlag = BackgroundExtraDataUpdatedFlag.None;

                // Update backgroundImageUrl and backgroundImageSynchronousLoading from Map
                foreach (int key in cachedNUIViewBackgroundImagePropertyKeyList)
                {
                    using PropertyValue propertyValue = map.Find(key);
                    if (propertyValue != null)
                    {
                        if (key == ImageVisualProperty.URL)
                        {
                            propertyValue.Get(out view.backgroundImageUrl);
                        }
                        else if (key == ImageVisualProperty.SynchronousLoading)
                        {
                            propertyValue.Get(out view.backgroundImageSynchronousLoading);
                        }
                    }
                }

                using var mapValue = new PropertyValue(map);
                Object.SetProperty(view.SwigCPtr, Property.BACKGROUND, mapValue);
            }
        }
        internal static object GetInternalBackgroundProperty(BindableObject bindable)
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

        /// <summary>
        /// StateProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty StateProperty = null;
#else
        public static readonly BindableProperty StateProperty = null;
#endif
        internal static void SetInternalStateProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyInt(view.SwigCPtr, View.Property.STATE, (int)newValue);
            }
        }
        internal static object GetInternalStateProperty(BindableObject bindable)
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
        }

        /// <summary>
        /// SubStateProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty SubStateProperty = null;
#else
        public static readonly BindableProperty SubStateProperty = null;
#endif
        internal static void SetInternalSubStateProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            string valueToString = "";
            if (newValue != null)
            {
                valueToString = ((States)newValue).GetDescription();
                Object.InternalSetPropertyString(view.SwigCPtr, View.Property.SubState, valueToString);
            }
        }
        internal static object GetInternalSubStateProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            string temp;
            temp = Object.InternalGetPropertyString(view.SwigCPtr, View.Property.SubState);
            return temp.GetValueByDescription<States>();
        }

        /// <summary>
        /// TooltipProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty TooltipProperty = null;
#else
        public static readonly BindableProperty TooltipProperty = null;
#endif
        internal static void SetInternalTooltipProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.TOOLTIP, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalTooltipProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.TOOLTIP).Get(temp);
            return temp;
        }

        /// <summary>
        /// FlexProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty FlexProperty = null;
#else
        public static readonly BindableProperty FlexProperty = null;
#endif
        internal static void SetInternalFlexProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyFloat(view.SwigCPtr, FlexContainer.ChildProperty.FLEX, (float)newValue);
            }
        }
        internal static object GetInternalFlexProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyFloat(view.SwigCPtr, FlexContainer.ChildProperty.FLEX);
        }

        /// <summary>
        /// AlignSelfProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty AlignSelfProperty = null;
#else
        public static readonly BindableProperty AlignSelfProperty = null;
#endif
        internal static void SetInternalAlignSelfProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyInt(view.SwigCPtr, FlexContainer.ChildProperty.AlignSelf, (int)newValue);
            }
        }
        internal static object GetInternalAlignSelfProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyInt(view.SwigCPtr, FlexContainer.ChildProperty.AlignSelf);
        }

        /// <summary>
        /// FlexMarginProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty FlexMarginProperty = null;
#else
        public static readonly BindableProperty FlexMarginProperty = null;
#endif
        internal static void SetInternalFlexMarginProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyVector4(view.SwigCPtr, FlexContainer.ChildProperty.FlexMargin, ((Vector4)newValue).SwigCPtr);
            }
        }
        internal static object GetInternalFlexMarginProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Object.InternalRetrievingPropertyVector4(view.SwigCPtr, FlexContainer.ChildProperty.FlexMargin, temp.SwigCPtr);
            return temp;
        }

        /// <summary>
        /// CellIndexProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty CellIndexProperty = null;
#else
        public static readonly BindableProperty CellIndexProperty = null;
#endif
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
        /// RowSpanProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty RowSpanProperty = null;
#else
        public static readonly BindableProperty RowSpanProperty = null;
#endif
        internal static void SetInternalRowSpanProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyFloat(view.SwigCPtr, TableView.ChildProperty.RowSpan, (float)newValue);
            }
        }
        internal static object GetInternalRowSpanProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyFloat(view.SwigCPtr, TableView.ChildProperty.RowSpan);
        }

        /// <summary>
        /// ColumnSpanProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty ColumnSpanProperty = null;
#else
        public static readonly BindableProperty ColumnSpanProperty = null;
#endif
        internal static void SetInternalColumnSpanProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyFloat(view.SwigCPtr, TableView.ChildProperty.ColumnSpan, (float)newValue);
            }
        }
        internal static object GetInternalColumnSpanProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyFloat(view.SwigCPtr, TableView.ChildProperty.ColumnSpan);
        }

        /// <summary>
        /// CellHorizontalAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty CellHorizontalAlignmentProperty = null;
#else
        public static readonly BindableProperty CellHorizontalAlignmentProperty = null;
#endif
        internal static void SetInternalCellHorizontalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            string valueToString = "";

            if (newValue != null)
            {
                valueToString = ((HorizontalAlignmentType)newValue).GetDescription();
                Object.InternalSetPropertyString(view.SwigCPtr, TableView.ChildProperty.CellHorizontalAlignment, valueToString);
            }
        }
        internal static object GetInternalCellHorizontalAlignmentProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            string temp;
            temp = Object.InternalGetPropertyString(view.SwigCPtr, TableView.ChildProperty.CellHorizontalAlignment);
            return temp.GetValueByDescription<HorizontalAlignmentType>();
        }

        /// <summary>
        /// CellVerticalAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty CellVerticalAlignmentProperty = null;
#else
        public static readonly BindableProperty CellVerticalAlignmentProperty = null;
#endif
        internal static void SetInternalCellVerticalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            string valueToString = "";

            if (newValue != null)
            {
                valueToString = ((VerticalAlignmentType)newValue).GetDescription();
                Object.InternalSetPropertyString(view.SwigCPtr, TableView.ChildProperty.CellVerticalAlignment, valueToString);
            }
        }
        internal static object GetInternalCellVerticalAlignmentProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            string temp;
            temp = Object.InternalGetPropertyString(view.SwigCPtr, TableView.ChildProperty.CellVerticalAlignment);
            return temp.GetValueByDescription<VerticalAlignmentType>();
        }

        /// <summary>
        /// "DO not use this, that will be deprecated. Use 'View Weight' instead of BindableProperty"
        /// This needs to be hidden as inhouse API until all applications using it have been updated.  Do not make public.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty WeightProperty = null;
#else
        public static readonly BindableProperty WeightProperty = null;
#endif
        internal static void SetInternalWeightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.Weight = (float)newValue;
            }
        }
        internal static object GetInternalWeightProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.Weight;
        }

        /// <summary>
        /// LeftFocusableViewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty LeftFocusableViewProperty = null;
#else
        public static readonly BindableProperty LeftFocusableViewProperty = null;
#endif
        internal static void SetInternalLeftFocusableViewProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null) { view.LeftFocusableViewId = (int)(newValue as View)?.GetId(); }
            else { view.LeftFocusableViewId = -1; }
        }
        internal static object GetInternalLeftFocusableViewProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.LeftFocusableViewId >= 0) { return view.ConvertIdToView((uint)view.LeftFocusableViewId); }
            return null;
        }

        /// <summary>
        /// RightFocusableViewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty RightFocusableViewProperty = null;
#else
        public static readonly BindableProperty RightFocusableViewProperty = null;
#endif
        internal static void SetInternalRightFocusableViewProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null) { view.RightFocusableViewId = (int)(newValue as View)?.GetId(); }
            else { view.RightFocusableViewId = -1; }
        }
        internal static object GetInternalRightFocusableViewProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.RightFocusableViewId >= 0) { return view.ConvertIdToView((uint)view.RightFocusableViewId); }
            return null;
        }

        /// <summary>
        /// UpFocusableViewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty UpFocusableViewProperty = null;
#else
        public static readonly BindableProperty UpFocusableViewProperty = null;
#endif
        internal static void SetInternalUpFocusableViewProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null) { view.UpFocusableViewId = (int)(newValue as View)?.GetId(); }
            else { view.UpFocusableViewId = -1; }
        }
        internal static object GetInternalUpFocusableViewProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.UpFocusableViewId >= 0) { return view.ConvertIdToView((uint)view.UpFocusableViewId); }
            return null;
        }

        /// <summary>
        /// DownFocusableViewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty DownFocusableViewProperty = null;
#else
        public static readonly BindableProperty DownFocusableViewProperty = null;
#endif
        internal static void SetInternalDownFocusableViewProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null) { view.DownFocusableViewId = (int)(newValue as View)?.GetId(); }
            else { view.DownFocusableViewId = -1; }
        }
        internal static object GetInternalDownFocusableViewProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.DownFocusableViewId >= 0) { return view.ConvertIdToView((uint)view.DownFocusableViewId); }
            return null;
        }

        /// <summary>
        /// ClockwiseFocusableViewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty ClockwiseFocusableViewProperty = null;
#else
        public static readonly BindableProperty ClockwiseFocusableViewProperty = null;
#endif
        internal static void SetInternalClockwiseFocusableViewProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null && (newValue is View)) { view.ClockwiseFocusableViewId = (int)(newValue as View)?.GetId(); }
            else { view.ClockwiseFocusableViewId = -1; }
        }
        internal static object GetInternalClockwiseFocusableViewProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.ClockwiseFocusableViewId >= 0) { return view.ConvertIdToView((uint)view.ClockwiseFocusableViewId); }
            return null;
        }

        /// <summary>
        /// CounterClockwiseFocusableViewProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty CounterClockwiseFocusableViewProperty = null;
#else
        public static readonly BindableProperty CounterClockwiseFocusableViewProperty = null;
#endif
        internal static void SetInternalCounterClockwiseFocusableViewProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null && (newValue is View)) { view.CounterClockwiseFocusableViewId = (int)(newValue as View)?.GetId(); }
            else { view.CounterClockwiseFocusableViewId = -1; }
        }
        internal static object GetInternalCounterClockwiseFocusableViewProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            if (view.CounterClockwiseFocusableViewId >= 0) { return view.ConvertIdToView((uint)view.CounterClockwiseFocusableViewId); }
            return null;
        }

        /// <summary>
        /// FocusableProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty FocusableProperty = null;
#else
        public static readonly BindableProperty FocusableProperty = null;
#endif
        internal static void SetInternalFocusableProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null) { view.SetKeyboardFocusable((bool)newValue); }
        }
        internal static object GetInternalFocusableProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.IsKeyboardFocusable();
        }

        /// <summary>
        /// FocusableChildrenProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty FocusableChildrenProperty = null;
#else
        public static readonly BindableProperty FocusableChildrenProperty = null;
#endif
        internal static void SetInternalFocusableChildrenProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null) { view.SetKeyboardFocusableChildren((bool)newValue); }
        }
        internal static object GetInternalFocusableChildrenProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.AreChildrenKeyBoardFocusable();
        }

        /// <summary>
        /// FocusableInTouchProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty FocusableInTouchProperty = null;
#else
        public static readonly BindableProperty FocusableInTouchProperty = null;
#endif
        internal static void SetInternalFocusableInTouchProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null) { view.SetFocusableInTouch((bool)newValue); }
        }
        internal static object GetInternalFocusableInTouchProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.IsFocusableInTouch();
        }

        /// <summary>
        /// Size2DProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty Size2DProperty = null;
#else
        public static readonly BindableProperty Size2DProperty = null;
#endif
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
        /// OpacityProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty OpacityProperty = null;
#else
        public static readonly BindableProperty OpacityProperty = null;
#endif
        internal static void SetInternalOpacityProperty(BindableObject bindable, object oldValue, object newValue)
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
        }
        internal static object GetInternalOpacityProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyFloat(view.SwigCPtr, View.Property.OPACITY);
        }

        /// <summary>
        /// Position2DProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty Position2DProperty = null;
#else
        public static readonly BindableProperty Position2DProperty = null;
#endif
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
        /// PositionUsesPivotPointProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty PositionUsesPivotPointProperty = null;
#else
        public static readonly BindableProperty PositionUsesPivotPointProperty = null;
#endif
        internal static void SetInternalPositionUsesPivotPointProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.PositionUsesAnchorPoint, (bool)newValue);
            }
        }
        internal static object GetInternalPositionUsesPivotPointProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.PositionUsesAnchorPoint);
        }

        /// <summary>
        /// SiblingOrderProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty SiblingOrderProperty = null;
#else
        public static readonly BindableProperty SiblingOrderProperty = null;
#endif
        internal static void SetInternalSiblingOrderProperty(BindableObject bindable, object oldValue, object newValue)
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
        }
        internal static object GetInternalSiblingOrderProperty(BindableObject bindable)
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
        }

        /// <summary>
        /// ParentOriginProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty ParentOriginProperty = null;
#else
        public static readonly BindableProperty ParentOriginProperty = null;
#endif
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
        /// PivotPointProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty PivotPointProperty = null;
#else
        public static readonly BindableProperty PivotPointProperty = null;
#endif
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
        /// SizeWidthProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty SizeWidthProperty = null;
#else
        public static readonly BindableProperty SizeWidthProperty = null;
#endif
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
        /// SizeHeightProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty SizeHeightProperty = null;
#else
        public static readonly BindableProperty SizeHeightProperty = null;
#endif
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
        /// PositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty PositionProperty = null;
#else
        public static readonly BindableProperty PositionProperty = null;
#endif
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
        /// PositionXProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty PositionXProperty = null;
#else
        public static readonly BindableProperty PositionXProperty = null;
#endif
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
        /// PositionYProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty PositionYProperty = null;
#else
        public static readonly BindableProperty PositionYProperty = null;
#endif
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
        /// PositionZProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty PositionZProperty = null;
#else
        public static readonly BindableProperty PositionZProperty = null;
#endif
        internal static void SetInternalPositionZProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyFloat(view.SwigCPtr, View.Property.PositionZ, (float)newValue);
            }

        }
        internal static object GetInternalPositionZProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyFloat(view.SwigCPtr, View.Property.PositionZ);
        }

        /// <summary>
        /// OrientationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty OrientationProperty = null;
#else
        public static readonly BindableProperty OrientationProperty = null;
#endif
        internal static void SetInternalOrientationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.ORIENTATION, new Tizen.NUI.PropertyValue((Rotation)newValue));
            }
        }
        internal static object GetInternalOrientationProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            Rotation temp = new Rotation();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.ORIENTATION).Get(temp);
            return temp;
        }

        /// <summary>
        /// ScaleProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty ScaleProperty = null;
#else
        public static readonly BindableProperty ScaleProperty = null;
#endif
        internal static void SetInternalScaleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                view.SetScale((Vector3)newValue);
            }

        }
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
        /// ScaleXProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty ScaleXProperty = null;
#else
        public static readonly BindableProperty ScaleXProperty = null;
#endif
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
        /// ScaleYProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty ScaleYProperty = null;
#else
        public static readonly BindableProperty ScaleYProperty = null;
#endif
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
        /// ScaleZProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty ScaleZProperty = null;
#else
        public static readonly BindableProperty ScaleZProperty = null;
#endif
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
        /// NameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty NameProperty = null;
#else
        public static readonly BindableProperty NameProperty = null;
#endif
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
        /// SensitiveProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty SensitiveProperty = null;
#else
        public static readonly BindableProperty SensitiveProperty = null;
#endif
        internal static void SetInternalSensitiveProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.SENSITIVE, (bool)newValue);
            }
        }
        internal static object GetInternalSensitiveProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.SENSITIVE);
        }

        /// <summary>
        /// IsEnabledProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty IsEnabledProperty = null;
#else
        public static readonly BindableProperty IsEnabledProperty = null;
#endif
        internal static void SetInternalIsEnabledProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.UserInteractionEnabled, (bool)newValue);
                view.OnEnabled((bool)newValue);
            }
        }
        internal static object GetInternalIsEnabledProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.UserInteractionEnabled);
        }

        /// <summary>
        /// DispatchKeyEventsProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty DispatchKeyEventsProperty = null;
#else
        public static readonly BindableProperty DispatchKeyEventsProperty = null;
#endif
        internal static void SetInternalDispatchKeyEventsProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.DispatchKeyEvents, (bool)newValue);
            }
        }
        internal static object GetInternalDispatchKeyEventsProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.DispatchKeyEvents);
        }

        /// <summary>
        /// LeaveRequiredProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty LeaveRequiredProperty = null;
#else
        public static readonly BindableProperty LeaveRequiredProperty = null;
#endif
        internal static void SetInternalLeaveRequiredProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.LeaveRequired, (bool)newValue);
            }
        }
        internal static object GetInternalLeaveRequiredProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.LeaveRequired);
        }

        /// <summary>
        /// InheritOrientationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty InheritOrientationProperty = null;
#else
        public static readonly BindableProperty InheritOrientationProperty = null;
#endif
        internal static void SetInternalInheritOrientationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.InheritOrientation, (bool)newValue);
            }
        }
        internal static object GetInternalInheritOrientationProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.InheritOrientation);
        }

        /// <summary>
        /// InheritScaleProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty InheritScaleProperty = null;
#else
        public static readonly BindableProperty InheritScaleProperty = null;
#endif
        internal static void SetInternalInheritScaleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.InheritScale, (bool)newValue);
            }
        }
        internal static object GetInternalInheritScaleProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.InheritScale);
        }

        /// <summary>
        /// DrawModeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty DrawModeProperty = null;
#else
        public static readonly BindableProperty DrawModeProperty = null;
#endif
        internal static void SetInternalDrawModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyInt(view.SwigCPtr, View.Property.DrawMode, (int)newValue);
            }
        }
        internal static object GetInternalDrawModeProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return (DrawModeType)Object.InternalGetPropertyInt(view.SwigCPtr, View.Property.DrawMode);
        }

        /// <summary>
        /// SizeModeFactorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty SizeModeFactorProperty = null;
#else
        public static readonly BindableProperty SizeModeFactorProperty = null;
#endif
        internal static void SetInternalSizeModeFactorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyVector3(view.SwigCPtr, View.Property.SizeModeFactor, ((Vector3)newValue).SwigCPtr);
            }

        }
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
        /// WidthResizePolicyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty WidthResizePolicyProperty = null;
#else
        public static readonly BindableProperty WidthResizePolicyProperty = null;
#endif
        internal static void SetInternalWidthResizePolicyProperty(BindableObject bindable, object oldValue, object newValue)
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
        }
        internal static object GetInternalWidthResizePolicyProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            string temp;

            temp = Object.InternalGetPropertyString(view.SwigCPtr, View.Property.WidthResizePolicy);
            return temp.GetValueByDescription<ResizePolicyType>();
        }

        /// <summary>
        /// HeightResizePolicyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty HeightResizePolicyProperty = null;
#else
        public static readonly BindableProperty HeightResizePolicyProperty = null;
#endif
        internal static void SetInternalHeightResizePolicyProperty(BindableObject bindable, object oldValue, object newValue)
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
        }
        internal static object GetInternalHeightResizePolicyProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            string temp;

            temp = Object.InternalGetPropertyString(view.SwigCPtr, View.Property.HeightResizePolicy);
            return temp.GetValueByDescription<ResizePolicyType>();
        }

        /// <summary>
        /// SizeScalePolicyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty SizeScalePolicyProperty = null;
#else
        public static readonly BindableProperty SizeScalePolicyProperty = null;
#endif
        internal static void SetInternalSizeScalePolicyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            string valueToString = "";
            if (newValue != null)
            {
                valueToString = ((SizeScalePolicyType)newValue).GetDescription();

                Object.InternalSetPropertyString(view.SwigCPtr, View.Property.SizeScalePolicy, valueToString);
            }
        }
        internal static object GetInternalSizeScalePolicyProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            return (SizeScalePolicyType)Object.InternalGetPropertyInt(view.SwigCPtr, View.Property.SizeScalePolicy);
        }

        /// <summary>
        /// WidthForHeightProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty WidthForHeightProperty = null;
#else
        public static readonly BindableProperty WidthForHeightProperty = null;
#endif
        internal static void SetInternalWidthForHeightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.WidthForHeight, (bool)newValue);
            }
        }
        internal static object GetInternalWidthForHeightProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.WidthForHeight);
        }

        /// <summary>
        /// HeightForWidthProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty HeightForWidthProperty = null;
#else
        public static readonly BindableProperty HeightForWidthProperty = null;
#endif
        internal static void SetInternalHeightForWidthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.HeightForWidth, (bool)newValue);
            }
        }
        internal static object GetInternalHeightForWidthProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.HeightForWidth);
        }

        /// <summary>
        /// PaddingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty PaddingProperty = null;
#else
        public static readonly BindableProperty PaddingProperty = null;
#endif
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
        /// SizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty SizeProperty = null;
#else
        public static readonly BindableProperty SizeProperty = null;
#endif
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
        /// MinimumSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty MinimumSizeProperty = null;
#else
        public static readonly BindableProperty MinimumSizeProperty = null;
#endif
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
        /// MaximumSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty MaximumSizeProperty = null;
#else
        public static readonly BindableProperty MaximumSizeProperty = null;
#endif
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
        /// InheritPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty InheritPositionProperty = null;
#else
        public static readonly BindableProperty InheritPositionProperty = null;
#endif
        internal static void SetInternalInheritPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.InheritPosition, (bool)newValue);
            }
        }
        internal static object GetInternalInheritPositionProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.InheritPosition);
        }

        /// <summary>
        /// ClippingModeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty ClippingModeProperty = null;
#else
        public static readonly BindableProperty ClippingModeProperty = null;
#endif
        internal static void SetInternalClippingModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(view.SwigCPtr, View.Property.ClippingMode, (int)newValue);
            }
        }
        internal static object GetInternalClippingModeProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            return (ClippingModeType)Object.InternalGetPropertyInt(view.SwigCPtr, View.Property.ClippingMode);
        }

        /// <summary>
        /// InheritLayoutDirectionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty InheritLayoutDirectionProperty = null;
#else
        public static readonly BindableProperty InheritLayoutDirectionProperty = null;
#endif
        internal static void SetInternalInheritLayoutDirectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.InheritLayoutDirection, (bool)newValue);
            }
        }
        internal static object GetInternalInheritLayoutDirectionProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.InheritLayoutDirection);
        }

        /// <summary>
        /// LayoutDirectionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty LayoutDirectionProperty = null;
#else
        public static readonly BindableProperty LayoutDirectionProperty = null;
#endif
        internal static void SetInternalLayoutDirectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(view.SwigCPtr, View.Property.LayoutDirection, (int)newValue);
            }
        }
        internal static object GetInternalLayoutDirectionProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            return (ViewLayoutDirectionType)Object.InternalGetPropertyInt(view.SwigCPtr, View.Property.LayoutDirection);
        }

        /// <summary>
        /// MarginProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty MarginProperty = null;
#else
        public static readonly BindableProperty MarginProperty = null;
#endif
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
        /// UpdateAreaHintProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty UpdateAreaHintProperty = null;
#else
        public static readonly BindableProperty UpdateAreaHintProperty = null;
#endif
        internal static void SetInternalUpdateAreaHintProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector4(view.SwigCPtr, Interop.ActorProperty.UpdateAreaHintGet(), ((Vector4)newValue).SwigCPtr);
            }
        }
        internal static object GetInternalUpdateAreaHintProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);

            Object.InternalRetrievingPropertyVector4(view.SwigCPtr, Interop.ActorProperty.UpdateAreaHintGet(), temp.SwigCPtr);
            return temp;
        }

        /// <summary>
        /// ImageShadow Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty ImageShadowProperty = null;
#else
        public static readonly BindableProperty ImageShadowProperty = null;
#endif
        internal static void SetInternalImageShadowProperty(BindableObject bindable, object oldValue, object newValue)
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
        }
        internal static object GetInternalImageShadowProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            // Sync as current properties
            view.UpdateBackgroundExtraData();

            PropertyMap map = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SHADOW).Get(map);

            var shadow = new ImageShadow(map);
            return shadow.IsEmpty() ? null : shadow;
        }

        /// <summary>
        /// Shadow Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty BoxShadowProperty = null;
#else
        public static readonly BindableProperty BoxShadowProperty = null;
#endif
        internal static void SetInternalBoxShadowProperty(BindableObject bindable, object oldValue, object newValue)
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
        }
        internal static object GetInternalBoxShadowProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            // Sync as current properties
            view.UpdateBackgroundExtraData();

            PropertyMap map = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)view.SwigCPtr, View.Property.SHADOW).Get(map);

            var shadow = new Shadow(map);
            return shadow.IsEmpty() ? null : shadow;
        }

        /// <summary>
        /// CornerRadius Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty CornerRadiusProperty = null;
#else
        public static readonly BindableProperty CornerRadiusProperty = null;
#endif
        internal static void SetInternalCornerRadiusProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            (view.backgroundExtraData ?? (view.backgroundExtraData = new BackgroundExtraData())).CornerRadius = (Vector4)newValue;
            view.UpdateBackgroundExtraData(BackgroundExtraDataUpdatedFlag.CornerRadius);
        }
        internal static object GetInternalCornerRadiusProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.backgroundExtraData == null ? 0.0f : view.backgroundExtraData.CornerRadius;
        }

        /// <summary>
        /// CornerRadiusPolicy Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty CornerRadiusPolicyProperty = null;
#else
        public static readonly BindableProperty CornerRadiusPolicyProperty = null;
#endif
        internal static void SetInternalCornerRadiusPolicyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            (view.backgroundExtraData ?? (view.backgroundExtraData = new BackgroundExtraData())).CornerRadiusPolicy = (VisualTransformPolicyType)newValue;

            if (view.backgroundExtraData.CornerRadius != null)
            {
                view.UpdateBackgroundExtraData(BackgroundExtraDataUpdatedFlag.CornerRadius);
            }
        }
        internal static object GetInternalCornerRadiusPolicyProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.backgroundExtraData == null ? VisualTransformPolicyType.Absolute : view.backgroundExtraData.CornerRadiusPolicy;
        }

        /// <summary>
        /// BorderlineWidth Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty BorderlineWidthProperty = null;
#else
        public static readonly BindableProperty BorderlineWidthProperty = null;
#endif
        internal static void SetInternalBorderlineWidthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            (view.backgroundExtraData ?? (view.backgroundExtraData = new BackgroundExtraData())).BorderlineWidth = (float)newValue;
            view.UpdateBackgroundExtraData(BackgroundExtraDataUpdatedFlag.Borderline);
        }
        internal static object GetInternalBorderlineWidthProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.backgroundExtraData == null ? 0.0f : view.backgroundExtraData.BorderlineWidth;
        }

        /// <summary>
        /// BorderlineColor Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty BorderlineColorProperty = null;
#else
        public static readonly BindableProperty BorderlineColorProperty = null;
#endif
        internal static void SetInternalBorderlineColorProperty(BindableObject bindable, object oldValue, object newValue)
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
        }
        internal static object GetInternalBorderlineColorProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.backgroundExtraData == null ? Color.Black : view.backgroundExtraData.BorderlineColor;
        }

        /// <summary>
        /// BorderlineColorSelector Property
        /// Like BackgroundColor, color selector typed BorderlineColor should be used in ViewStyle only.
        /// So this API is internally used only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty BorderlineColorSelectorProperty = null;
#else
        public static readonly BindableProperty BorderlineColorSelectorProperty = null;
#endif
        internal static void SetInternalBorderlineColorSelectorProperty(BindableObject bindable, object oldValue, object newValue)
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
        }
        internal static object GetInternalBorderlineColorSelectorProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            var selector = view.themeData?.selectorData?.BorderlineColor?.Get();
            return (null != selector) ? selector : new Selector<Color>();
        }

        /// <summary>
        /// BorderlineOffset Property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty BorderlineOffsetProperty = null;
#else
        public static readonly BindableProperty BorderlineOffsetProperty = null;
#endif
        internal static void SetInternalBorderlineOffsetProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            (view.backgroundExtraData ?? (view.backgroundExtraData = new BackgroundExtraData())).BorderlineOffset = (float)newValue;
            view.UpdateBackgroundExtraData(BackgroundExtraDataUpdatedFlag.Borderline);
        }
        internal static object GetInternalBorderlineOffsetProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return view.backgroundExtraData == null ? 0.0f : view.backgroundExtraData.BorderlineOffset;
        }

        /// <summary>
        /// EnableControlState property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty EnableControlStateProperty = null;
#else
        public static readonly BindableProperty EnableControlStateProperty = null;
#endif
        internal static void SetInternalEnableControlStateProperty(BindableObject bindable, object oldValue, object newValue)
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
        }
        internal static object GetInternalEnableControlStateProperty(BindableObject bindable)
        {
            return ((View)bindable).enableControlState;
        }

        /// <summary>
        /// ThemeChangeSensitive property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty ThemeChangeSensitiveProperty = null;
#else
        public static readonly BindableProperty ThemeChangeSensitiveProperty = null;
#endif
        internal static void SetInternalThemeChangeSensitiveProperty(BindableObject bindable, object oldValue, object newValue)
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
        }
        internal static object GetInternalThemeChangeSensitiveProperty(BindableObject bindable)
        {
            return ((View)bindable).themeData?.ThemeChangeSensitive ?? ThemeManager.ApplicationThemeChangeSensitive;
        }

        /// <summary>
        /// AccessibilityNameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty AccessibilityNameProperty = null;
#else
        public static readonly BindableProperty AccessibilityNameProperty = null;
#endif
        internal static void SetInternalAccessibilityNameProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyString(view.SwigCPtr, View.Property.AccessibilityName, (string)newValue);
            }
        }
        internal static object GetInternalAccessibilityNameProperty(BindableObject bindable)
        {
            var view = (View)bindable;
            return Object.InternalGetPropertyString(view.SwigCPtr, View.Property.AccessibilityName);
        }

        /// <summary>
        /// AccessibilityDescriptionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty AccessibilityDescriptionProperty = null;
#else
        public static readonly BindableProperty AccessibilityDescriptionProperty = null;
#endif
        internal static void SetInternalAccessibilityDescriptionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(view.SwigCPtr, View.Property.AccessibilityDescription, (string)newValue);
            }
        }
        internal static object GetInternalAccessibilityDescriptionProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            return Object.InternalGetPropertyString(view.SwigCPtr, View.Property.AccessibilityDescription);
        }

        /// <summary>
        /// AccessibilityTranslationDomainProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty AccessibilityTranslationDomainProperty = null;
#else
        public static readonly BindableProperty AccessibilityTranslationDomainProperty = null;
#endif
        internal static void SetInternalAccessibilityTranslationDomainProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(view.SwigCPtr, View.Property.AccessibilityTranslationDomain, (string)newValue);
            }
        }
        internal static object GetInternalAccessibilityTranslationDomainProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            return Object.InternalGetPropertyString(view.SwigCPtr, View.Property.AccessibilityTranslationDomain);
        }

        /// <summary>
        /// AccessibilityRoleProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty AccessibilityRoleProperty = null;
#else
        public static readonly BindableProperty AccessibilityRoleProperty = null;
#endif
        internal static void SetInternalAccessibilityRoleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(view.SwigCPtr, View.Property.AccessibilityRole, (int)newValue);
            }
        }
        internal static object GetInternalAccessibilityRoleProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            return (Role)Object.InternalGetPropertyInt(view.SwigCPtr, View.Property.AccessibilityRole);
        }

        /// <summary>
        /// AccessibilityHighlightableProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty AccessibilityHighlightableProperty = null;
#else
        public static readonly BindableProperty AccessibilityHighlightableProperty = null;
#endif
        internal static void SetInternalAccessibilityHighlightableProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.AccessibilityHighlightable, (bool)newValue);
            }
        }
        internal static object GetInternalAccessibilityHighlightableProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.AccessibilityHighlightable);
        }

        /// <summary>
        /// AccessibilityHiddenProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty AccessibilityHiddenProperty = null;
#else
        public static readonly BindableProperty AccessibilityHiddenProperty = null;
#endif
        internal static void SetInternalAccessibilityHiddenProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var view = (View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(view.SwigCPtr, View.Property.AccessibilityHidden, (bool)newValue);
            }
        }
        internal static object GetInternalAccessibilityHiddenProperty(BindableObject bindable)
        {
            var view = (View)bindable;

            return Object.InternalGetPropertyBool(view.SwigCPtr, View.Property.AccessibilityHidden);
        }

        /// <summary>
        /// ExcludeLayoutingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty ExcludeLayoutingProperty = null;
#else
        public static readonly BindableProperty ExcludeLayoutingProperty = null;
#endif
        internal static void SetInternalExcludeLayoutingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalExcludeLayouting = (bool)newValue;
            }
        }
        internal static object GetInternalExcludeLayoutingProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalExcludeLayouting;
        }

        /// <summary>
        /// TooltipTextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty TooltipTextProperty = null;
#else
        public static readonly BindableProperty TooltipTextProperty = null;
#endif
        internal static void SetInternalTooltipTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalTooltipText = (string)newValue;
            }
        }
        internal static object GetInternalTooltipTextProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalTooltipText;
        }

        /// <summary>
        /// PositionUsesAnchorPointProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty PositionUsesAnchorPointProperty = null;
#else
        public static readonly BindableProperty PositionUsesAnchorPointProperty = null;
#endif
        internal static void SetInternalPositionUsesAnchorPointProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalPositionUsesAnchorPoint = (bool)newValue;
            }
        }
        internal static object GetInternalPositionUsesAnchorPointProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalPositionUsesAnchorPoint;
        }

        /// <summary>
        /// AnchorPointProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty AnchorPointProperty = null;
#else
        public static readonly BindableProperty AnchorPointProperty = null;
#endif
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
        /// WidthSpecificationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty WidthSpecificationProperty = null;
#else
        public static readonly BindableProperty WidthSpecificationProperty = null;
#endif
        internal static void SetInternalWidthSpecificationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalWidthSpecification = (int)newValue;
            }
        }
        internal static object GetInternalWidthSpecificationProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalWidthSpecification;
        }

        /// <summary>
        /// HeightSpecificationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty HeightSpecificationProperty = null;
#else
        public static readonly BindableProperty HeightSpecificationProperty = null;
#endif
        internal static void SetInternalHeightSpecificationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalHeightSpecification = (int)newValue;
            }
        }
        internal static object GetInternalHeightSpecificationProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalHeightSpecification;
        }

        /// <summary>
        /// LayoutTransitionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty LayoutTransitionProperty = null;
#else
        public static readonly BindableProperty LayoutTransitionProperty = null;
#endif
        internal static void SetInternalLayoutTransitionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalLayoutTransition = (Tizen.NUI.LayoutTransition)newValue;
            }
        }
        internal static object GetInternalLayoutTransitionProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalLayoutTransition;
        }

        /// <summary>
        /// PaddingEXProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty PaddingEXProperty = null;
#else
        public static readonly BindableProperty PaddingEXProperty = null;
#endif
        internal static void SetInternalPaddingEXProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalPaddingEX = (Tizen.NUI.Extents)newValue;
            }
        }
        internal static object GetInternalPaddingEXProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalPaddingEX;
        }

        /// <summary>
        /// LayoutProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty LayoutProperty = null;
#else
        public static readonly BindableProperty LayoutProperty = null;
#endif
        internal static void SetInternalLayoutProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalLayout = (Tizen.NUI.LayoutItem)newValue;
            }
        }
        internal static object GetInternalLayoutProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalLayout;
        }

        /// <summary>
        /// BackgroundImageSynchronosLoadingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty BackgroundImageSynchronosLoadingProperty = null;
#else
        public static readonly BindableProperty BackgroundImageSynchronosLoadingProperty = null;
#endif
        internal static void SetInternalBackgroundImageSynchronosLoadingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalBackgroundImageSynchronosLoading = (bool)newValue;
            }
        }
        internal static object GetInternalBackgroundImageSynchronosLoadingProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalBackgroundImageSynchronosLoading;
        }

        /// <summary>
        /// BackgroundImageSynchronousLoadingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty BackgroundImageSynchronousLoadingProperty = null;
#else
        public static readonly BindableProperty BackgroundImageSynchronousLoadingProperty = null;
#endif
        internal static void SetInternalBackgroundImageSynchronousLoadingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalBackgroundImageSynchronousLoading = (bool)newValue;
            }
        }
        internal static object GetInternalBackgroundImageSynchronousLoadingProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalBackgroundImageSynchronousLoading;
        }

        /// <summary>
        /// EnableControlStatePropagationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty EnableControlStatePropagationProperty = null;
#else
        public static readonly BindableProperty EnableControlStatePropagationProperty = null;
#endif
        internal static void SetInternalEnableControlStatePropagationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalEnableControlStatePropagation = (bool)newValue;
            }
        }
        internal static object GetInternalEnableControlStatePropagationProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalEnableControlStatePropagation;
        }

        /// <summary>
        /// PropagatableControlStatesProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty PropagatableControlStatesProperty = null;
#else
        public static readonly BindableProperty PropagatableControlStatesProperty = null;
#endif
        internal static void SetInternalPropagatableControlStatesProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalPropagatableControlStates = (ControlState)newValue;
            }
        }
        internal static object GetInternalPropagatableControlStatesProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalPropagatableControlStates;
        }

        /// <summary>
        /// GrabTouchAfterLeaveProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty GrabTouchAfterLeaveProperty = null;
#else
        public static readonly BindableProperty GrabTouchAfterLeaveProperty = null;
#endif
        internal static void SetInternalGrabTouchAfterLeaveProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalGrabTouchAfterLeave = (bool)newValue;
            }
        }
        internal static object GetInternalGrabTouchAfterLeaveProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalGrabTouchAfterLeave;
        }

        /// <summary>
        /// AllowOnlyOwnTouchProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty AllowOnlyOwnTouchProperty = null;
#else
        public static readonly BindableProperty AllowOnlyOwnTouchProperty = null;
#endif
        internal static void SetInternalAllowOnlyOwnTouchProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalAllowOnlyOwnTouch = (bool)newValue;
            }
        }
        internal static object GetInternalAllowOnlyOwnTouchProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalAllowOnlyOwnTouch;
        }

        /// <summary>
        /// BlendEquationProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty BlendEquationProperty = null;
#else
        public static readonly BindableProperty BlendEquationProperty = null;
#endif
        internal static void SetInternalBlendEquationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalBlendEquation = (Tizen.NUI.BlendEquationType)newValue;
            }
        }
        internal static object GetInternalBlendEquationProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalBlendEquation;
        }

        /// <summary>
        /// TransitionOptionsProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty TransitionOptionsProperty = null;
#else
        public static readonly BindableProperty TransitionOptionsProperty = null;
#endif
        internal static void SetInternalTransitionOptionsProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalTransitionOptions = (Tizen.NUI.TransitionOptions)newValue;
            }
        }
        internal static object GetInternalTransitionOptionsProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalTransitionOptions;
        }

        /// <summary>
        /// AutomationIdProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty AutomationIdProperty = null;
#else
        public static readonly BindableProperty AutomationIdProperty = null;
#endif
        internal static void SetInternalAutomationIdProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(instance.SwigCPtr, View.Property.AutomationId, (string)newValue);
            }
        }
        internal static object GetInternalAutomationIdProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;

            return Object.InternalGetPropertyString(instance.SwigCPtr, View.Property.AutomationId);
        }

        /// <summary>
        /// TouchAreaOffsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty TouchAreaOffsetProperty = null;
#else
        public static readonly BindableProperty TouchAreaOffsetProperty = null;
#endif
        internal static void SetInternalTouchAreaOffsetProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalTouchAreaOffset = (Tizen.NUI.Offset)newValue;
            }
        }
        internal static object GetInternalTouchAreaOffsetProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalTouchAreaOffset;
        }

        /// <summary>
        /// DispatchTouchMotionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty DispatchTouchMotionProperty = null;
#else
        public static readonly BindableProperty DispatchTouchMotionProperty = null;
#endif
        internal static void SetInternalDispatchTouchMotionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalDispatchTouchMotion = (bool)newValue;
            }
        }
        internal static object GetInternalDispatchTouchMotionProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalDispatchTouchMotion;
        }

        /// <summary>
        /// DispatchHoverMotionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        public static BindableProperty DispatchHoverMotionProperty = null;
#else
        public static readonly BindableProperty DispatchHoverMotionProperty = null;
#endif
        internal static void SetInternalDispatchHoverMotionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            if (newValue != null)
            {
                instance.InternalDispatchHoverMotion = (bool)newValue;
            }
        }

        internal static object GetInternalDispatchHoverMotionProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.View)bindable;
            return instance.InternalDispatchHoverMotion;
        }

#if REMOVE_READONLY_FOR_BINDABLE_PROPERTY
        internal static void CreateBindableProperties()
        {
            if (NUIApplication.IsUsingXaml)
            {
                StyleNameProperty = BindableProperty.Create(nameof(StyleName), typeof(string), typeof(View), string.Empty,
                    propertyChanged: SetInternalStyleNameProperty, defaultValueCreator: GetInternalStyleNameProperty);

                KeyInputFocusProperty = BindableProperty.Create(nameof(KeyInputFocus), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalKeyInputFocusProperty, defaultValueCreator: GetInternalKeyInputFocusProperty);

                BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(View), null,
                    propertyChanged: SetInternalBackgroundColorProperty, defaultValueCreator: GetInternalBackgroundColorProperty);

                ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(View), null,
                    propertyChanged: SetInternalColorProperty, defaultValueCreator: GetInternalColorProperty);
                
                ColorRedProperty = BindableProperty.Create(nameof(ColorRed), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalColorRedProperty, defaultValueCreator: GetInternalColorRedProperty);

                ColorGreenProperty = BindableProperty.Create(nameof(ColorGreen), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalColorGreenProperty, defaultValueCreator: GetInternalColorGreenProperty);

                ColorBlueProperty = BindableProperty.Create(nameof(ColorBlue), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalColorBlueProperty, defaultValueCreator: GetInternalColorBlueProperty);

                BackgroundImageProperty = BindableProperty.Create(nameof(BackgroundImage), typeof(string), typeof(View), default(string),
                    propertyChanged: SetInternalBackgroundImageProperty, defaultValueCreator: GetInternalBackgroundImageProperty);

                BackgroundImageBorderProperty = BindableProperty.Create(nameof(BackgroundImageBorder), typeof(Rectangle), typeof(View), default(Rectangle),
                    propertyChanged: SetInternalBackgroundImageBorderProperty, defaultValueCreator: GetInternalBackgroundImageBorderProperty);

                BackgroundProperty = BindableProperty.Create(nameof(Background), typeof(PropertyMap), typeof(View), null,
                    propertyChanged: SetInternalBackgroundProperty, defaultValueCreator: GetInternalBackgroundProperty);

                StateProperty = BindableProperty.Create(nameof(State), typeof(States), typeof(View), States.Normal,
                    propertyChanged: SetInternalStateProperty, defaultValueCreator: GetInternalStateProperty);

                SubStateProperty = BindableProperty.Create(nameof(SubState), typeof(States), typeof(View), States.Normal,
                    propertyChanged: SetInternalSubStateProperty, defaultValueCreator: GetInternalSubStateProperty);

                TooltipProperty = BindableProperty.Create(nameof(Tooltip), typeof(PropertyMap), typeof(View), null,
                    propertyChanged: SetInternalTooltipProperty, defaultValueCreator: GetInternalTooltipProperty);

                FlexProperty = BindableProperty.Create(nameof(Flex), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalFlexProperty, defaultValueCreator: GetInternalFlexProperty);

                AlignSelfProperty = BindableProperty.Create(nameof(AlignSelf), typeof(int), typeof(View), default(int),
                    propertyChanged: SetInternalAlignSelfProperty, defaultValueCreator: GetInternalAlignSelfProperty);

                FlexMarginProperty = BindableProperty.Create(nameof(FlexMargin), typeof(Vector4), typeof(View), null,
                    propertyChanged: SetInternalFlexMarginProperty, defaultValueCreator: GetInternalFlexMarginProperty);

                CellIndexProperty = BindableProperty.Create(nameof(CellIndex), typeof(Vector2), typeof(View), null,
                    propertyChanged: SetInternalCellIndexProperty, defaultValueCreator: GetInternalCellIndexProperty);

                RowSpanProperty = BindableProperty.Create(nameof(RowSpan), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalRowSpanProperty, defaultValueCreator: GetInternalRowSpanProperty);

                ColumnSpanProperty = BindableProperty.Create(nameof(ColumnSpan), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalColumnSpanProperty, defaultValueCreator: GetInternalColumnSpanProperty);

                CellHorizontalAlignmentProperty = BindableProperty.Create(nameof(CellHorizontalAlignment), typeof(HorizontalAlignmentType), typeof(View), HorizontalAlignmentType.Left,
                    propertyChanged: SetInternalCellHorizontalAlignmentProperty, defaultValueCreator: GetInternalCellHorizontalAlignmentProperty);

                CellVerticalAlignmentProperty = BindableProperty.Create(nameof(CellVerticalAlignment), typeof(VerticalAlignmentType), typeof(View), VerticalAlignmentType.Top,
                    propertyChanged: SetInternalCellVerticalAlignmentProperty, defaultValueCreator: GetInternalCellVerticalAlignmentProperty);

                WeightProperty = BindableProperty.Create(nameof(Weight), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalWeightProperty, defaultValueCreator: GetInternalWeightProperty);

                LeftFocusableViewProperty = BindableProperty.Create(nameof(View.LeftFocusableView), typeof(View), typeof(View), null,
                    propertyChanged: SetInternalLeftFocusableViewProperty, defaultValueCreator: GetInternalLeftFocusableViewProperty);

                RightFocusableViewProperty = BindableProperty.Create(nameof(View.RightFocusableView), typeof(View), typeof(View), null,
                    propertyChanged: SetInternalRightFocusableViewProperty, defaultValueCreator: GetInternalRightFocusableViewProperty);

                UpFocusableViewProperty = BindableProperty.Create(nameof(View.UpFocusableView), typeof(View), typeof(View), null,
                    propertyChanged: SetInternalUpFocusableViewProperty, defaultValueCreator: GetInternalUpFocusableViewProperty);

                DownFocusableViewProperty = BindableProperty.Create(nameof(View.DownFocusableView), typeof(View), typeof(View), null,
                    propertyChanged: SetInternalDownFocusableViewProperty, defaultValueCreator: GetInternalDownFocusableViewProperty);

                ClockwiseFocusableViewProperty = BindableProperty.Create(nameof(View.ClockwiseFocusableView), typeof(View), typeof(View), null,
                    propertyChanged: SetInternalClockwiseFocusableViewProperty, defaultValueCreator: GetInternalClockwiseFocusableViewProperty);

                CounterClockwiseFocusableViewProperty = BindableProperty.Create(nameof(View.CounterClockwiseFocusableView), typeof(View), typeof(View), null,
                    propertyChanged: SetInternalCounterClockwiseFocusableViewProperty, defaultValueCreator: GetInternalCounterClockwiseFocusableViewProperty);

                FocusableProperty = BindableProperty.Create(nameof(Focusable), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalFocusableProperty, defaultValueCreator: GetInternalFocusableProperty);

                FocusableChildrenProperty = BindableProperty.Create(nameof(FocusableChildren), typeof(bool), typeof(View), true,
                    propertyChanged: SetInternalFocusableChildrenProperty, defaultValueCreator: GetInternalFocusableChildrenProperty);

                FocusableInTouchProperty = BindableProperty.Create(nameof(FocusableInTouch), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalFocusableInTouchProperty, defaultValueCreator: GetInternalFocusableInTouchProperty);

                Size2DProperty = BindableProperty.Create(nameof(Size2D), typeof(Size2D), typeof(View), null,
                    propertyChanged: SetInternalSize2DProperty, defaultValueCreator: GetInternalSize2DProperty);

                OpacityProperty = BindableProperty.Create(nameof(Opacity), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalOpacityProperty, defaultValueCreator: GetInternalOpacityProperty);

                Position2DProperty = BindableProperty.Create(nameof(Position2D), typeof(Position2D), typeof(View), null,
                    propertyChanged: SetInternalPosition2DProperty, defaultValueCreator: GetInternalPosition2DProperty);

                PositionUsesPivotPointProperty = BindableProperty.Create(nameof(PositionUsesPivotPoint), typeof(bool), typeof(View), true,
                    propertyChanged: SetInternalPositionUsesPivotPointProperty, defaultValueCreator: GetInternalPositionUsesPivotPointProperty);

                SiblingOrderProperty = BindableProperty.Create(nameof(SiblingOrder), typeof(int), typeof(View), default(int),
                    propertyChanged: SetInternalSiblingOrderProperty, defaultValueCreator: GetInternalSiblingOrderProperty);

                ParentOriginProperty = BindableProperty.Create(nameof(ParentOrigin), typeof(Position), typeof(View), null,
                    propertyChanged: SetInternalParentOriginProperty, defaultValueCreator: GetInternalParentOriginProperty);

                PivotPointProperty = BindableProperty.Create(nameof(PivotPoint), typeof(Position), typeof(View), null,
                    propertyChanged: SetInternalPivotPointProperty, defaultValueCreator: GetInternalPivotPointProperty);

                SizeWidthProperty = BindableProperty.Create(nameof(SizeWidth), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalSizeWidthProperty, defaultValueCreator: GetInternalSizeWidthProperty);

                SizeHeightProperty = BindableProperty.Create(nameof(SizeHeight), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalSizeHeightProperty, defaultValueCreator: GetInternalSizeHeightProperty);

                PositionProperty = BindableProperty.Create(nameof(Position), typeof(Position), typeof(View), null,
                    propertyChanged: SetInternalPositionProperty, defaultValueCreator: GetInternalPositionProperty);

                PositionXProperty = BindableProperty.Create(nameof(PositionX), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalPositionXProperty, defaultValueCreator: GetInternalPositionXProperty);

                PositionYProperty = BindableProperty.Create(nameof(PositionY), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalPositionYProperty, defaultValueCreator: GetInternalPositionYProperty);

                PositionZProperty = BindableProperty.Create(nameof(PositionZ), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalPositionZProperty, defaultValueCreator: GetInternalPositionZProperty);

                OrientationProperty = BindableProperty.Create(nameof(Orientation), typeof(Rotation), typeof(View), null,
                    propertyChanged: SetInternalOrientationProperty, defaultValueCreator: GetInternalOrientationProperty);

                ScaleProperty = BindableProperty.Create(nameof(Scale), typeof(Vector3), typeof(View), null,
                    propertyChanged: SetInternalScaleProperty, defaultValueCreator: GetInternalScaleProperty);

                ScaleXProperty = BindableProperty.Create(nameof(ScaleX), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalScaleXProperty, defaultValueCreator: GetInternalScaleXProperty);

                ScaleYProperty = BindableProperty.Create(nameof(ScaleY), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalScaleYProperty, defaultValueCreator: GetInternalScaleYProperty);

                ScaleZProperty = BindableProperty.Create(nameof(ScaleZ), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalScaleZProperty, defaultValueCreator: GetInternalScaleZProperty);

                NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(View), string.Empty,
                    propertyChanged: SetInternalNameProperty, defaultValueCreator: GetInternalNameProperty);

                SensitiveProperty = BindableProperty.Create(nameof(Sensitive), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalSensitiveProperty, defaultValueCreator: GetInternalSensitiveProperty);

                IsEnabledProperty = BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalIsEnabledProperty, defaultValueCreator: GetInternalIsEnabledProperty);

                DispatchKeyEventsProperty = BindableProperty.Create(nameof(DispatchKeyEvents), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalDispatchKeyEventsProperty, defaultValueCreator: GetInternalDispatchKeyEventsProperty);

                LeaveRequiredProperty = BindableProperty.Create(nameof(LeaveRequired), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalLeaveRequiredProperty, defaultValueCreator: GetInternalLeaveRequiredProperty);

                InheritOrientationProperty = BindableProperty.Create(nameof(InheritOrientation), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalInheritOrientationProperty, defaultValueCreator: GetInternalInheritOrientationProperty);

                InheritScaleProperty = BindableProperty.Create(nameof(InheritScale), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalInheritScaleProperty, defaultValueCreator: GetInternalInheritScaleProperty);

                DrawModeProperty = BindableProperty.Create(nameof(DrawMode), typeof(DrawModeType), typeof(View), DrawModeType.Normal,
                    propertyChanged: SetInternalDrawModeProperty, defaultValueCreator: GetInternalDrawModeProperty);

                SizeModeFactorProperty = BindableProperty.Create(nameof(SizeModeFactor), typeof(Vector3), typeof(View), null,
                    propertyChanged: SetInternalSizeModeFactorProperty, defaultValueCreator: GetInternalSizeModeFactorProperty);

                WidthResizePolicyProperty = BindableProperty.Create(nameof(WidthResizePolicy), typeof(ResizePolicyType), typeof(View), ResizePolicyType.Fixed,
                    propertyChanged: SetInternalWidthResizePolicyProperty, defaultValueCreator: GetInternalWidthResizePolicyProperty);

                HeightResizePolicyProperty = BindableProperty.Create(nameof(HeightResizePolicy), typeof(ResizePolicyType), typeof(View), ResizePolicyType.Fixed,
                    propertyChanged: SetInternalHeightResizePolicyProperty, defaultValueCreator: GetInternalHeightResizePolicyProperty);

                SizeScalePolicyProperty = BindableProperty.Create(nameof(SizeScalePolicy), typeof(SizeScalePolicyType), typeof(View), SizeScalePolicyType.UseSizeSet,
                    propertyChanged: SetInternalSizeScalePolicyProperty, defaultValueCreator: GetInternalSizeScalePolicyProperty);

                WidthForHeightProperty = BindableProperty.Create(nameof(WidthForHeight), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalWidthForHeightProperty, defaultValueCreator: GetInternalWidthForHeightProperty);

                HeightForWidthProperty = BindableProperty.Create(nameof(HeightForWidth), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalHeightForWidthProperty, defaultValueCreator: GetInternalHeightForWidthProperty);

                PaddingProperty = BindableProperty.Create(nameof(Padding), typeof(Extents), typeof(View), null,
                    propertyChanged: SetInternalPaddingProperty, defaultValueCreator: GetInternalPaddingProperty);

                SizeProperty = BindableProperty.Create(nameof(Size), typeof(Size), typeof(View), null,
                    propertyChanged: SetInternalSizeProperty, defaultValueCreator: GetInternalSizeProperty);

                MinimumSizeProperty = BindableProperty.Create(nameof(MinimumSize), typeof(Size2D), typeof(View), null,
                    propertyChanged: SetInternalMinimumSizeProperty, defaultValueCreator: GetInternalMinimumSizeProperty);

                MaximumSizeProperty = BindableProperty.Create(nameof(MaximumSize), typeof(Size2D), typeof(View), null,
                    propertyChanged: SetInternalMaximumSizeProperty, defaultValueCreator: GetInternalMaximumSizeProperty);

                InheritPositionProperty = BindableProperty.Create(nameof(InheritPosition), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalInheritPositionProperty, defaultValueCreator: GetInternalInheritPositionProperty);

                ClippingModeProperty = BindableProperty.Create(nameof(ClippingMode), typeof(ClippingModeType), typeof(View), ClippingModeType.Disabled,
                    propertyChanged: SetInternalClippingModeProperty, defaultValueCreator: GetInternalClippingModeProperty);

                InheritLayoutDirectionProperty = BindableProperty.Create(nameof(InheritLayoutDirection), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalInheritLayoutDirectionProperty, defaultValueCreator: GetInternalInheritLayoutDirectionProperty);

                LayoutDirectionProperty = BindableProperty.Create(nameof(LayoutDirection), typeof(ViewLayoutDirectionType), typeof(View), ViewLayoutDirectionType.LTR,
                    propertyChanged: SetInternalLayoutDirectionProperty, defaultValueCreator: GetInternalLayoutDirectionProperty);

                MarginProperty = BindableProperty.Create(nameof(Margin), typeof(Extents), typeof(View), null,
                    propertyChanged: SetInternalMarginProperty, defaultValueCreator: GetInternalMarginProperty);

                UpdateAreaHintProperty = BindableProperty.Create(nameof(UpdateAreaHint), typeof(Vector4), typeof(View), null,
                    propertyChanged: SetInternalUpdateAreaHintProperty, defaultValueCreator: GetInternalUpdateAreaHintProperty);

                ImageShadowProperty = BindableProperty.Create(nameof(ImageShadow), typeof(ImageShadow), typeof(View), null,
                    propertyChanged: SetInternalImageShadowProperty, defaultValueCreator: GetInternalImageShadowProperty);

                BoxShadowProperty = BindableProperty.Create(nameof(BoxShadow), typeof(Shadow), typeof(View), null,
                    propertyChanged: SetInternalBoxShadowProperty, defaultValueCreator: GetInternalBoxShadowProperty);

                CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(Vector4), typeof(View), null,
                    propertyChanged: SetInternalCornerRadiusProperty, defaultValueCreator: GetInternalCornerRadiusProperty);

                CornerRadiusPolicyProperty = BindableProperty.Create(nameof(CornerRadiusPolicy), typeof(VisualTransformPolicyType), typeof(View), VisualTransformPolicyType.Absolute,
                    propertyChanged: SetInternalCornerRadiusPolicyProperty, defaultValueCreator: GetInternalCornerRadiusPolicyProperty);

                BorderlineWidthProperty = BindableProperty.Create(nameof(BorderlineWidth), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalBorderlineWidthProperty, defaultValueCreator: GetInternalBorderlineWidthProperty);

                BorderlineColorProperty = BindableProperty.Create(nameof(BorderlineColor), typeof(Color), typeof(View), null,
                    propertyChanged: SetInternalBorderlineColorProperty, defaultValueCreator: GetInternalBorderlineColorProperty);

                BorderlineColorSelectorProperty = BindableProperty.Create(nameof(BorderlineColorSelector), typeof(Selector<Color>), typeof(View), null,
                    propertyChanged: SetInternalBorderlineColorSelectorProperty, defaultValueCreator: GetInternalBorderlineColorSelectorProperty);

                BorderlineOffsetProperty = BindableProperty.Create(nameof(BorderlineOffset), typeof(float), typeof(View), default(float),
                    propertyChanged: SetInternalBorderlineOffsetProperty, defaultValueCreator: GetInternalBorderlineOffsetProperty);

                EnableControlStateProperty = BindableProperty.Create(nameof(EnableControlState), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalEnableControlStateProperty, defaultValueCreator: GetInternalEnableControlStateProperty);

                ThemeChangeSensitiveProperty = BindableProperty.Create(nameof(ThemeChangeSensitive), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalThemeChangeSensitiveProperty, defaultValueCreator: GetInternalThemeChangeSensitiveProperty);

                AccessibilityNameProperty = BindableProperty.Create(nameof(AccessibilityName), typeof(string), typeof(View), string.Empty,
                    propertyChanged: SetInternalAccessibilityNameProperty, defaultValueCreator: GetInternalAccessibilityNameProperty);

                AccessibilityDescriptionProperty = BindableProperty.Create(nameof(AccessibilityDescription), typeof(string), typeof(View), string.Empty,
                    propertyChanged: SetInternalAccessibilityDescriptionProperty, defaultValueCreator: GetInternalAccessibilityDescriptionProperty);

                AccessibilityTranslationDomainProperty = BindableProperty.Create(nameof(AccessibilityTranslationDomain), typeof(string), typeof(View), string.Empty,
                    propertyChanged: SetInternalAccessibilityTranslationDomainProperty, defaultValueCreator: GetInternalAccessibilityTranslationDomainProperty);

                AccessibilityRoleProperty = BindableProperty.Create(nameof(AccessibilityRole), typeof(Role), typeof(View), default(Role),
                    propertyChanged: SetInternalAccessibilityRoleProperty, defaultValueCreator: GetInternalAccessibilityRoleProperty);

                AccessibilityHighlightableProperty = BindableProperty.Create(nameof(AccessibilityHighlightable), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalAccessibilityHighlightableProperty, defaultValueCreator: GetInternalAccessibilityHighlightableProperty);

                AccessibilityHiddenProperty = BindableProperty.Create(nameof(AccessibilityHidden), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalAccessibilityHiddenProperty, defaultValueCreator: GetInternalAccessibilityHiddenProperty);

                ExcludeLayoutingProperty = BindableProperty.Create(nameof(ExcludeLayouting), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalExcludeLayoutingProperty, defaultValueCreator: GetInternalExcludeLayoutingProperty);

                TooltipTextProperty = BindableProperty.Create(nameof(TooltipText), typeof(string), typeof(View), string.Empty,
                    propertyChanged: SetInternalTooltipTextProperty, defaultValueCreator: GetInternalTooltipTextProperty);

                PositionUsesAnchorPointProperty = BindableProperty.Create(nameof(PositionUsesAnchorPoint), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalPositionUsesAnchorPointProperty, defaultValueCreator: GetInternalPositionUsesAnchorPointProperty);

                AnchorPointProperty = BindableProperty.Create(nameof(AnchorPoint), typeof(Tizen.NUI.Position), typeof(View), null,
                    propertyChanged: SetInternalAnchorPointProperty, defaultValueCreator: GetInternalAnchorPointProperty);
                
                WidthSpecificationProperty = BindableProperty.Create(nameof(WidthSpecification), typeof(int), typeof(View), 0,
                    propertyChanged: SetInternalWidthSpecificationProperty, defaultValueCreator: GetInternalWidthSpecificationProperty);

                HeightSpecificationProperty = BindableProperty.Create(nameof(HeightSpecification), typeof(int), typeof(View), 0,
                    propertyChanged: SetInternalHeightSpecificationProperty, defaultValueCreator: GetInternalHeightSpecificationProperty);

                LayoutTransitionProperty = BindableProperty.Create(nameof(LayoutTransition), typeof(Tizen.NUI.LayoutTransition), typeof(View), null,
                    propertyChanged: SetInternalLayoutTransitionProperty, defaultValueCreator: GetInternalLayoutTransitionProperty);

                PaddingEXProperty = BindableProperty.Create(nameof(PaddingEX), typeof(Tizen.NUI.Extents), typeof(View), null,
                    propertyChanged: SetInternalPaddingEXProperty, defaultValueCreator: GetInternalPaddingEXProperty);

                LayoutProperty = BindableProperty.Create(nameof(Layout), typeof(Tizen.NUI.LayoutItem), typeof(View), null,
                    propertyChanged: SetInternalLayoutProperty, defaultValueCreator: GetInternalLayoutProperty);

                BackgroundImageSynchronosLoadingProperty = BindableProperty.Create(nameof(BackgroundImageSynchronosLoading), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalBackgroundImageSynchronosLoadingProperty, defaultValueCreator: GetInternalBackgroundImageSynchronosLoadingProperty);

                BackgroundImageSynchronousLoadingProperty = BindableProperty.Create(nameof(BackgroundImageSynchronousLoading), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalBackgroundImageSynchronousLoadingProperty, defaultValueCreator: GetInternalBackgroundImageSynchronousLoadingProperty);

                EnableControlStatePropagationProperty = BindableProperty.Create(nameof(EnableControlStatePropagation), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalEnableControlStatePropagationProperty, defaultValueCreator: GetInternalEnableControlStatePropagationProperty);

                PropagatableControlStatesProperty = BindableProperty.Create(nameof(PropagatableControlStates), typeof(ControlState), typeof(View), ControlState.All,
                    propertyChanged: SetInternalPropagatableControlStatesProperty, defaultValueCreator: GetInternalPropagatableControlStatesProperty);

                GrabTouchAfterLeaveProperty = BindableProperty.Create(nameof(GrabTouchAfterLeave), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalGrabTouchAfterLeaveProperty, defaultValueCreator: GetInternalGrabTouchAfterLeaveProperty);

                AllowOnlyOwnTouchProperty = BindableProperty.Create(nameof(AllowOnlyOwnTouch), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalAllowOnlyOwnTouchProperty, defaultValueCreator: GetInternalAllowOnlyOwnTouchProperty);

                BlendEquationProperty = BindableProperty.Create(nameof(BlendEquation), typeof(BlendEquationType), typeof(View), default(BlendEquationType),
                    propertyChanged: SetInternalBlendEquationProperty, defaultValueCreator: GetInternalBlendEquationProperty);

                TransitionOptionsProperty = BindableProperty.Create(nameof(TransitionOptions), typeof(TransitionOptions), typeof(View), default(TransitionOptions),
                    propertyChanged: SetInternalTransitionOptionsProperty, defaultValueCreator: GetInternalTransitionOptionsProperty);

                AutomationIdProperty = BindableProperty.Create(nameof(AutomationId), typeof(string), typeof(View), string.Empty,
                    propertyChanged: SetInternalAutomationIdProperty, defaultValueCreator: GetInternalAutomationIdProperty);

                TouchAreaOffsetProperty = BindableProperty.Create(nameof(TouchAreaOffset), typeof(Offset), typeof(View), default(Offset),
                    propertyChanged: SetInternalTouchAreaOffsetProperty, defaultValueCreator: GetInternalTouchAreaOffsetProperty);

                DispatchTouchMotionProperty = BindableProperty.Create(nameof(DispatchTouchMotion), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalDispatchTouchMotionProperty, defaultValueCreator: GetInternalDispatchTouchMotionProperty);

                DispatchHoverMotionProperty = BindableProperty.Create(nameof(DispatchHoverMotion), typeof(bool), typeof(View), false,
                    propertyChanged: SetInternalDispatchHoverMotionProperty, defaultValueCreator: GetInternalDispatchHoverMotionProperty);


                RegisterPropertyGroup(PositionProperty, positionPropertyGroup);
                RegisterPropertyGroup(Position2DProperty, positionPropertyGroup);
                RegisterPropertyGroup(PositionXProperty, positionPropertyGroup);
                RegisterPropertyGroup(PositionYProperty, positionPropertyGroup);

                RegisterPropertyGroup(SizeProperty, sizePropertyGroup);
                RegisterPropertyGroup(Size2DProperty, sizePropertyGroup);
                RegisterPropertyGroup(SizeWidthProperty, sizePropertyGroup);
                RegisterPropertyGroup(SizeHeightProperty, sizePropertyGroup);

                RegisterPropertyGroup(ScaleProperty, scalePropertyGroup);
                RegisterPropertyGroup(ScaleXProperty, scalePropertyGroup);
                RegisterPropertyGroup(ScaleYProperty, scalePropertyGroup);
                RegisterPropertyGroup(ScaleZProperty, scalePropertyGroup);
            }
        }
#else
        // keep readonly for BindableProperty
#endif

        /// <summary>
        /// Gets View's Size2D set by user.
        /// </summary>
        internal Size2D GetUserSize2D()
        {
            return new Size2D((int)userSizeWidth, (int)userSizeHeight);
        }

        private void SetBackgroundImage(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                backgroundExtraDataUpdatedFlag &= ~BackgroundExtraDataUpdatedFlag.Background;

                backgroundImageUrl = null;

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

            backgroundImageUrl = value;

            // Fast return for usual cases.
            if (backgroundExtraData == null && !backgroundImageSynchronousLoading)
            {
                Object.InternalSetPropertyString(SwigCPtr, View.Property.BACKGROUND, value);
                return;
            }

            using var map = new PropertyMap();
            using var url = new PropertyValue(value);
            using var synchronousLoading = new PropertyValue(backgroundImageSynchronousLoading);

            map.Add(ImageVisualProperty.URL, url)
               .Add(ImageVisualProperty.SynchronousLoading, synchronousLoading);

            if ((backgroundExtraData?.BackgroundImageBorder) != null)
            {
                using var npatchType = new PropertyValue((int)Visual.Type.NPatch);
                using var border = new PropertyValue(backgroundExtraData.BackgroundImageBorder);
                map.Add(Visual.Property.Type, npatchType)
                   .Add(NpatchImageVisualProperty.Border, border);
            }
            else
            {
                using var imageType = new PropertyValue((int)Visual.Type.Image);
                map.Add(Visual.Property.Type, imageType);
            }

            if(backgroundExtraData != null)
            {
                using var cornerRadiusValue = backgroundExtraData.CornerRadius == null ? new PropertyValue() : new PropertyValue(backgroundExtraData.CornerRadius);
                using var cornerRadius = new PropertyValue(cornerRadiusValue);
                using var cornerRadiusPolicy = new PropertyValue((int)(backgroundExtraData.CornerRadiusPolicy));
                using var borderlineWidth = new PropertyValue(backgroundExtraData.BorderlineWidth);
                using var borderlineColorValue = backgroundExtraData.BorderlineColor == null ? new PropertyValue(Color.Black) : new PropertyValue(backgroundExtraData.BorderlineColor);
                using var borderlineColor = new PropertyValue(borderlineColorValue);
                using var borderlineOffset = new PropertyValue(backgroundExtraData.BorderlineOffset);

                map.Add(Visual.Property.CornerRadius, cornerRadius)
                   .Add(Visual.Property.CornerRadiusPolicy, cornerRadiusPolicy)
                   .Add(Visual.Property.BorderlineWidth, borderlineWidth)
                   .Add(Visual.Property.BorderlineColor, borderlineColor)
                   .Add(Visual.Property.BorderlineOffset, borderlineOffset);
            }

            backgroundExtraDataUpdatedFlag &= ~BackgroundExtraDataUpdatedFlag.Background;

            using var mapValue = new PropertyValue(map);
            Object.SetProperty(SwigCPtr, Property.BACKGROUND, mapValue);
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

            // Background property will be Color after now. Remove background image url information.
            backgroundImageUrl = null;

            if (backgroundExtraData == null)
            {
                Object.InternalSetPropertyVector4(SwigCPtr, View.Property.BACKGROUND, ((Color)value).SwigCPtr);
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
